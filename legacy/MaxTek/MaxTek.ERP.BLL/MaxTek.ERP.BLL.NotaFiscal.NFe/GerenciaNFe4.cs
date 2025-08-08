using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using MaxTek.ERP.BLL.Sefaz;
using MaxTek.GPS.BLL;
using MaxTek.MaxEditors.Windows.Forms;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class GerenciaNFe4
{
	private static CertificadoDigital _cd;

	private static SituacaoServicoNFe _ultimaSituacao;

	public static CertificadoDigital CarregarCertificado(int codigoEmpresa)
	{
		if (codigoEmpresa == 0)
		{
			codigoEmpresa = 1;
		}
		Sociedade sociedade = ModuloParametros.ObterSociedade(codigoEmpresa);
		if (_cd == null || !sociedade.ChaveCertificadoDigital.ToLower().Equals(_cd.oCertificado.SerialNumber.ToLower()))
		{
			_cd = new CertificadoDigital();
			string chaveCertificado = string.Empty;
			if (sociedade != null && !string.IsNullOrWhiteSpace(sociedade.ChaveCertificadoDigital))
			{
				chaveCertificado = sociedade.ChaveCertificadoDigital.ToLower();
			}
			string novoCertificado = string.Empty;
			if (_cd.SelecionarCertificado(chaveCertificado, out novoCertificado))
			{
				_cd.PrepInfCertificado(_cd.oCertificado);
			}
			if (!string.IsNullOrWhiteSpace(novoCertificado))
			{
				sociedade.ChaveCertificadoDigital = novoCertificado;
				sociedade.CertificadoDataEmissao = _cd.dValidadeInicial;
				sociedade.CertificadoDataValidade = _cd.dValidadeFinal;
				sociedade.CertificadoNome = _cd.sSubject;
				ModuloParametros.AlterarSociedade(sociedade, sociedade.PropriedadesModificadas);
			}
			else if (sociedade.CertificadoDataEmissao.Year < 2000)
			{
				sociedade.CertificadoDataEmissao = _cd.dValidadeInicial;
				sociedade.CertificadoDataValidade = _cd.dValidadeFinal;
				sociedade.CertificadoNome = _cd.sSubject;
				ModuloParametros.AlterarSociedade(sociedade, sociedade.PropriedadesModificadas);
			}
		}
		return _cd;
	}

	public static SituacaoServicoNFe VerificarSituacaoSefaz(int CodigoEmpresa)
	{
		Sociedade sociedade = ModuloParametros.ObterSociedade(CodigoEmpresa);
		Estado codigoUF = (Estado)sociedade.CodigoUF;
		return VerificarSituacaoSefaz(codigoUF, CodigoEmpresa);
	}

	public static SituacaoServicoNFe VerificarSituacaoSefaz(Estado UF, int CodigoEmpresa)
	{
		if (_ultimaSituacao != null)
		{
			DateTime dateTime = _ultimaSituacao.DataHora.AddMinutes(3.0);
			if (DateTime.Now < dateTime)
			{
				return _ultimaSituacao;
			}
		}
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		using (NFeStatusServico4 nFeStatusServico = new NFeStatusServico4())
		{
			nFeStatusServico.Url = SefazUrl.url(EnumServicosSefaz.NFeStatusServico, UF, ConfigNFe.Ambiente);
			nFeStatusServico.ClientCertificates.Add(CarregarCertificado(CodigoEmpresa).oCertificado);
			XmlElement xmlElement = nFeStatusServico.nfeStatusServicoNF(StringToXmlNode(GerarXML2.StatusServico4(ConfigNFe.Instancia.AmbienteInt, 1, (int)UF))) as XmlElement;
			_ultimaSituacao = new SituacaoServicoNFe(int.Parse(xmlElement.GetElementsByTagName("cStat")[0].InnerText), xmlElement.GetElementsByTagName("xMotivo")[0].InnerText, DateTime.Now);
		}
		return _ultimaSituacao;
	}

	public static RetornoNFe GerarNFe(ref NotaFiscalNotasFiscais nf)
	{
		TipoEmissao tipoEmissao = TipoEmissao.Normal;
		if (nf.SituacaoNfe == "EmContingencia" || nf.SituacaoNfe == "EmErroContingencia" || nf.SituacaoNfe == "AguardandoProcLoteContingencia")
		{
			tipoEmissao = TipoEmissao.ContingenciaFS;
		}
		RetornoNFe.EtapaEnvio etapa = RetornoNFe.EtapaEnvio.OK;
		string text = CriarNFe(ref nf, tipoEmissao);
		int num = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Codigo;
		string motivoRetorno = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Motivo;
		if (VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).OK)
		{
			int ilote;
			string text2 = GerarXML2.GerarXmlUmaNota4(text, out ilote);
			GerarXML2.SalvarXml(GerarXML2.GerarNomeArqXmlLote(ilote), ConfigNFe.ExtEnvioLoteNfe, text2);
			XmlElement xmlElement = null;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			using (NFeAutorizacao4 nFeAutorizacao = new NFeAutorizacao4())
			{
				nFeAutorizacao.Url = SefazUrl.url(EnumServicosSefaz.NFeAutorizacao, (Estado)nf.SociedadeRef.CodigoUF, ConfigNFe.Ambiente);
				nFeAutorizacao.ClientCertificates.Add(CarregarCertificado(nf.CodigoEmpresa).oCertificado);
				xmlElement = nFeAutorizacao.nfeAutorizacaoLote(StringToXmlNode(text2)) as XmlElement;
				GerarXML2.SalvarXml(GerarXML2.GerarNomeArqXmlLote(ilote), ConfigNFe.ExtReciboEnvioLoteNfe, text2);
			}
			if (xmlElement == null)
			{
				num = -1;
				motivoRetorno = "Recibo não retornou!";
				tipoEmissao = TipoEmissao.ContingenciaFS;
				etapa = RetornoNFe.EtapaEnvio.EnvioPedido;
			}
			else
			{
				num = int.Parse(xmlElement.GetElementsByTagName("cStat")[0].InnerText);
				motivoRetorno = xmlElement.GetElementsByTagName("xMotivo")[0].InnerText;
				if (num == 103)
				{
					nf.CodigoLote = xmlElement.GetElementsByTagName("nRec")[0].InnerText;
					nf.DataEnvioNFE = DateTime.Now;
					if (tipoEmissao == TipoEmissao.Normal)
					{
						nf.SituacaoNfe = SituacaoNFe.AguardandoProcLote.ToString();
					}
					else
					{
						nf.SituacaoNfe = SituacaoNFe.AguardandoProcLoteContingencia.ToString();
					}
				}
				else
				{
					tipoEmissao = TipoEmissao.ContingenciaFS;
					etapa = RetornoNFe.EtapaEnvio.EnvioPedido;
				}
			}
		}
		else
		{
			tipoEmissao = TipoEmissao.ContingenciaFS;
			etapa = RetornoNFe.EtapaEnvio.VerSituacao;
		}
		ModuloNotaFiscal.AlterarNotaFiscalNotasFiscaisCabecalho(nf, nf.PropriedadesModificadas);
		return new RetornoNFe(num, text, etapa, tipoEmissao, motivoRetorno);
	}

	public static List<RetornoLote> ConsultarLote(string recibo, int CodigoEmpresa)
	{
		if (CodigoEmpresa == 0)
		{
			CodigoEmpresa = 1;
		}
		XmlElement xmlElement = null;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		using (NFeRetAutorizacao4 nFeRetAutorizacao = new NFeRetAutorizacao4())
		{
			Sociedade sociedade = ModuloParametros.ObterSociedade(CodigoEmpresa);
			Estado codigoUF = (Estado)sociedade.CodigoUF;
			nFeRetAutorizacao.Url = SefazUrl.url(EnumServicosSefaz.NFeRetornoAutorizacao, codigoUF, ConfigNFe.Ambiente);
			int cUF = (int)codigoUF;
			nFeRetAutorizacao.ClientCertificates.Add(CarregarCertificado(CodigoEmpresa).oCertificado);
			xmlElement = nFeRetAutorizacao.nfeRetAutorizacaoLote(StringToXmlNode(GerarXML2.ConsultaLote4(ConfigNFe.Instancia.AmbienteInt, cUF, recibo))) as XmlElement;
		}
		List<RetornoLote> list = new List<RetornoLote>();
		if (xmlElement != null)
		{
			string innerText = xmlElement.GetElementsByTagName("cStat")[0].InnerText;
			string innerText2 = xmlElement.GetElementsByTagName("xMotivo")[0].InnerText;
			if (innerText == "109")
			{
				XtraMessageBox.Show($"Erro: {innerText} - {innerText2}");
			}
			else
			{
				foreach (XmlNode item in xmlElement.GetElementsByTagName("protNFe"))
				{
					XmlElement xmlElement2 = item as XmlElement;
					XmlNodeList elementsByTagName = xmlElement2.GetElementsByTagName("nProt");
					string innerText3 = xmlElement2.GetElementsByTagName("chNFe")[0].InnerText;
					string text = ((elementsByTagName == null || elementsByTagName.Count == 0) ? string.Empty : elementsByTagName[0].InnerText);
					string outerXml = xmlElement2.OuterXml;
					string innerText4 = xmlElement2.GetElementsByTagName("cStat")[0].InnerText;
					string innerText5 = xmlElement2.GetElementsByTagName("xMotivo")[0].InnerText;
					list.Add(new RetornoLote(innerText3, int.Parse(xmlElement2.GetElementsByTagName("cStat")[0].InnerText), xmlElement2.GetElementsByTagName("xMotivo")[0].InnerText, text, outerXml));
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					string text2 = GerarXML2.XmlToString(ConfigNFe.Instancia.DirNFeEmpresa + "\\" + innerText3 + ConfigNFe.ExtNfe);
					if (!Directory.Exists(ConfigNFe.Instancia.DirNFeAutorizadas))
					{
						Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeAutorizadas);
					}
					text2 = text2.Substring(text2.IndexOf("<NFe "));
					GerarXML2.SalvarCompleto($"{ConfigNFe.Instancia.DirNFeAutorizadas}\\{innerText3}{ConfigNFe.ExtNfe}", "<?xml version=\"1.0\" encoding=\"UTF-8\"?><nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.portalfiscal.inf.br/nfe procNFe_v4.00.xsd\" versao=\"4.00\">" + text2 + outerXml + "</nfeProc>");
					NotaFiscalNotasFiscais notaFiscalNotasFiscais = ModuloNotaFiscal.ObterNotaFiscalNotasFiscais(innerText3);
					if (notaFiscalNotasFiscais != null && notaFiscalNotasFiscais.Entidade != null && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscais.Entidade.LocalSalvarXml))
					{
						try
						{
							GerarXML2.SalvarCompleto($"{notaFiscalNotasFiscais.Entidade.LocalSalvarXml}\\{innerText3}{ConfigNFe.ExtNfe}", "<?xml version=\"1.0\" encoding=\"UTF-8\"?><nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.portalfiscal.inf.br/nfe procNFe_v4.00.xsd\" versao=\"4.00\">" + text2 + outerXml + "</nfeProc>");
						}
						catch
						{
						}
					}
				}
			}
		}
		return list;
	}

	public static RetornoNFe CancelarNFe(NotaFiscalNotasFiscais nf, string justificativa)
	{
		int num = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Codigo;
		string text = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Motivo;
		RetornoNFe.EtapaEnvio etapa = RetornoNFe.EtapaEnvio.OK;
		if (VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).OK)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			using NFeRecepcaoEvento4 nFeRecepcaoEvento = new NFeRecepcaoEvento4();
			nFeRecepcaoEvento.Url = SefazUrl.url(EnumServicosSefaz.NFeRecepcaoEvento, (Estado)nf.SociedadeRef.CodigoUF, ConfigNFe.Ambiente);
			nFeRecepcaoEvento.ClientCertificates.Add(CarregarCertificado(nf.CodigoEmpresa).oCertificado);
			string text2 = $"{ConfigNFe.Instancia.DirNFeStore}\\{nf.ChaveNfe}{ConfigNFe.ExtPedCanc}";
			GerarXML2.XmlCancelamento(nf.SociedadeRef.CodigoUF, ConfigNFe.Instancia.AmbienteInt, nf.SociedadeRef.Cnpj, nf.ChaveNfe, nf.ProtocoloNfe, justificativa);
			AssinaturaDigital assinaturaDigital = new AssinaturaDigital();
			assinaturaDigital.Assinar(text2, "infEvento", CarregarCertificado(nf.CodigoEmpresa).oCertificado);
			if (nFeRecepcaoEvento.nfeRecepcaoEvento(StringToXmlNode(GerarXML2.XmlToString(text2))) is XmlElement xmlElement)
			{
				GerarXML2.SalvarXml(nf.ChaveNfe, ConfigNFe.ExtCanc, xmlElement.OuterXml);
				num = int.Parse((xmlElement.GetElementsByTagName("cStat")[0] as XmlElement).InnerText);
				text = (xmlElement.GetElementsByTagName("xMotivo")[0] as XmlElement).InnerText;
				if (num != 128)
				{
					XtraMessageBox.Show($"Erro no Retorno da Solicitação de Cancelamento\nCódigo: {num}\nMotivo: {text}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					etapa = RetornoNFe.EtapaEnvio.VerSituacao;
				}
				else
				{
					XmlElement xmlElement2 = xmlElement.GetElementsByTagName("infEvento")[0] as XmlElement;
					num = int.Parse((xmlElement2.GetElementsByTagName("cStat")[0] as XmlElement).InnerText);
					text = (xmlElement2.GetElementsByTagName("xMotivo")[0] as XmlElement).InnerText;
					if (num == 135 || num == 136 || num == 155)
					{
						etapa = RetornoNFe.EtapaEnvio.OK;
						NotasFiscaisEventos notasFiscaisEventos = new NotasFiscaisEventos();
						notasFiscaisEventos.CodigoEmpresa = nf.CodigoEmpresa;
						notasFiscaisEventos.CodigoEvento = 110111;
						notasFiscaisEventos.CodigoNotaFiscal = nf.NumeroNotaFiscal;
						notasFiscaisEventos.CodigoSequenciaEvento = 1;
						notasFiscaisEventos.CodigoSerieNotaFiscal = nf.CodigoSerieNF;
						notasFiscaisEventos.Descricao = nf.MotivoCancelamento;
						notasFiscaisEventos.Evento = "Cancelamento";
						notasFiscaisEventos.Protocolo = (xmlElement2.GetElementsByTagName("nProt")[0] as XmlElement).InnerText;
						notasFiscaisEventos.DataEvento = (xmlElement2.GetElementsByTagName("dhRegEvento")[0] as XmlElement).InnerText;
						ModuloNotaFiscal.SalvarNotasFiscaisEventos(notasFiscaisEventos);
						XtraMessageBox.Show($"Código: {num}\n{text}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						etapa = RetornoNFe.EtapaEnvio.VerSituacao;
						XtraMessageBox.Show($"Código: {num}\n{text}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				etapa = RetornoNFe.EtapaEnvio.EnvioPedido;
			}
		}
		else
		{
			etapa = RetornoNFe.EtapaEnvio.VerSituacao;
		}
		return new RetornoNFe(num, nf.ChaveNfe, etapa, TipoEmissao.Normal, text);
	}

	public static RetornoNFe CartaCorrecaoNFe(NotaFiscalNotasFiscais nf, string correcao)
	{
		int num = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Codigo;
		string text = VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).Motivo;
		RetornoNFe.EtapaEnvio etapa = RetornoNFe.EtapaEnvio.OK;
		if (VerificarSituacaoSefaz((Estado)nf.SociedadeRef.CodigoUF, nf.CodigoEmpresa).OK)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			using NFeRecepcaoEvento4 nFeRecepcaoEvento = new NFeRecepcaoEvento4();
			nFeRecepcaoEvento.Url = SefazUrl.url(EnumServicosSefaz.NFeRecepcaoEvento, (Estado)nf.SociedadeRef.CodigoUF, ConfigNFe.Ambiente);
			nFeRecepcaoEvento.ClientCertificates.Add(CarregarCertificado(nf.CodigoEmpresa).oCertificado);
			int num2 = 0;
			if (nf.NotasFiscaisEventosRef != null && nf.NotasFiscaisEventosRef.Count > 0)
			{
				foreach (NotasFiscaisEventos item in nf.NotasFiscaisEventosRef)
				{
					if (item.CodigoEvento == 110110 && item.CodigoSequenciaEvento > num2)
					{
						num2 = item.CodigoSequenciaEvento;
					}
				}
			}
			num2++;
			string text2 = $"{ConfigNFe.Instancia.DirNFeStore}\\{nf.ChaveNfe}{ConfigNFe.ExtEnvCartaCorrecao}";
			GerarXML2.XmlCartaCorrecao(nf.SociedadeRef.CodigoUF, ConfigNFe.Instancia.AmbienteInt, nf.SociedadeRef.Cnpj, nf.ChaveNfe, correcao.Trim(), num2);
			AssinaturaDigital assinaturaDigital = new AssinaturaDigital();
			assinaturaDigital.Assinar(text2, "infEvento", CarregarCertificado(nf.CodigoEmpresa).oCertificado);
			if (nFeRecepcaoEvento.nfeRecepcaoEvento(StringToXmlNode(GerarXML2.XmlToString(text2))) is XmlElement xmlElement)
			{
				GerarXML2.SalvarXml(nf.ChaveNfe, ConfigNFe.ExtRetCartaCorrecao, xmlElement.OuterXml);
				num = int.Parse((xmlElement.GetElementsByTagName("cStat")[0] as XmlElement).InnerText);
				text = (xmlElement.GetElementsByTagName("xMotivo")[0] as XmlElement).InnerText;
				if (num != 128)
				{
					XtraMessageBox.Show($"Erro no Retorno da Solicitação de Evento\nCódigo: {num}\nMotivo: {text}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					etapa = RetornoNFe.EtapaEnvio.VerSituacao;
				}
				else
				{
					XmlElement xmlElement2 = xmlElement.GetElementsByTagName("infEvento")[0] as XmlElement;
					num = int.Parse((xmlElement2.GetElementsByTagName("cStat")[0] as XmlElement).InnerText);
					text = (xmlElement2.GetElementsByTagName("xMotivo")[0] as XmlElement).InnerText;
					if (num == 135 || num == 136)
					{
						etapa = RetornoNFe.EtapaEnvio.OK;
						NotasFiscaisEventos notasFiscaisEventos = new NotasFiscaisEventos();
						notasFiscaisEventos.CodigoEmpresa = nf.CodigoEmpresa;
						notasFiscaisEventos.CodigoEvento = 110110;
						notasFiscaisEventos.CodigoNotaFiscal = nf.NumeroNotaFiscal;
						notasFiscaisEventos.CodigoSequenciaEvento = num2;
						notasFiscaisEventos.CodigoSerieNotaFiscal = nf.CodigoSerieNF;
						notasFiscaisEventos.Descricao = correcao.Trim();
						notasFiscaisEventos.Evento = "Carta de Correção";
						notasFiscaisEventos.Protocolo = (xmlElement2.GetElementsByTagName("nProt")[0] as XmlElement).InnerText;
						notasFiscaisEventos.DataEvento = (xmlElement2.GetElementsByTagName("dhRegEvento")[0] as XmlElement).InnerText;
						ModuloNotaFiscal.SalvarNotasFiscaisEventos(notasFiscaisEventos);
						ModuloNotaFiscal.EnviarCartaCorrecao(nf, notasFiscaisEventos, text2);
						XtraMessageBox.Show($"Código: {num}\n{text}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						etapa = RetornoNFe.EtapaEnvio.VerSituacao;
						XtraMessageBox.Show($"Código: {num}\n{text}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				etapa = RetornoNFe.EtapaEnvio.EnvioPedido;
			}
		}
		else
		{
			etapa = RetornoNFe.EtapaEnvio.VerSituacao;
		}
		return new RetornoNFe(num, nf.ChaveNfe, etapa, TipoEmissao.Normal, text);
	}

	public static RetornoNFe InutilizarNFe(NotaFiscalInutilizacao NotaInutilizacao)
	{
		Sociedade sociedade = ModuloParametros.ObterSociedade(NotaInutilizacao.CodigoEmpresa);
		Estado codigoUF = (Estado)sociedade.CodigoUF;
		string cNPJ = MetodosUteis.LimpaNro(sociedade.Cnpj);
		int codigoUF2 = sociedade.CodigoUF;
		string text = $"IN{NotaInutilizacao.CodigoSerie:000}{NotaInutilizacao.Ano:00}{NotaInutilizacao.NotaInicial:000000000}{NotaInutilizacao.NotaFinal:000000000}";
		int num = VerificarSituacaoSefaz(codigoUF, NotaInutilizacao.CodigoEmpresa).Codigo;
		string text2 = VerificarSituacaoSefaz(codigoUF, NotaInutilizacao.CodigoEmpresa).Motivo;
		RetornoNFe.EtapaEnvio etapa = RetornoNFe.EtapaEnvio.OK;
		if (VerificarSituacaoSefaz(codigoUF, NotaInutilizacao.CodigoEmpresa).OK)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			using NFeInutilizacao4 nFeInutilizacao = new NFeInutilizacao4();
			nFeInutilizacao.Url = SefazUrl.url(EnumServicosSefaz.NFeInutilizacao, codigoUF, ConfigNFe.Ambiente);
			nFeInutilizacao.ClientCertificates.Add(CarregarCertificado(NotaInutilizacao.CodigoEmpresa).oCertificado);
			string text3 = $"{ConfigNFe.Instancia.DirNFeStore}\\{text}{ConfigNFe.ExtPedInu}";
			GerarXML2.Inutilizacao4(text, 1, codigoUF2, NotaInutilizacao.Ano, cNPJ, 55, NotaInutilizacao.CodigoSerie, NotaInutilizacao.NotaInicial, NotaInutilizacao.NotaFinal, NotaInutilizacao.Justificativa);
			AssinaturaDigital assinaturaDigital = new AssinaturaDigital();
			assinaturaDigital.Assinar(text3, "infInut", CarregarCertificado(NotaInutilizacao.CodigoEmpresa).oCertificado);
			ValidarXMLs validarXMLs = new ValidarXMLs();
			validarXMLs.Validar(text3, "inutNFe_v4.00.xsd", ValidarXMLs.SubFolder400);
			string retornoString = validarXMLs.RetornoString;
			if (!string.IsNullOrEmpty(retornoString))
			{
				MessageBox.Show(retornoString);
			}
			XmlElement xmlElement = nFeInutilizacao.nfeInutilizacaoNF(StringToXmlNode(GerarXML2.XmlToString(text3))) as XmlElement;
			GerarXML2.SalvarXml(text, ConfigNFe.ExtInu, xmlElement.OuterXml);
			if (xmlElement != null)
			{
				GerarXML2.SalvarXml(text, ConfigNFe.ExtInu, xmlElement.OuterXml);
				num = int.Parse((xmlElement.GetElementsByTagName("cStat")[0] as XmlElement).InnerText);
				text2 = (xmlElement.GetElementsByTagName("xMotivo")[0] as XmlElement).InnerText;
				NotaInutilizacao.CodigoStatus = num;
				NotaInutilizacao.Status = text2;
				if (num != 102)
				{
					MaxWaitDialog.FecharMensagem();
					XtraMessageBox.Show($"Erro no Retorno da Solicitação de Cancelamento\nCódigo: {num}\nMotivo: {text2}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					etapa = RetornoNFe.EtapaEnvio.VerSituacao;
				}
				else
				{
					XmlElement xmlElement2 = xmlElement.GetElementsByTagName("infInut")[0] as XmlElement;
					NotaInutilizacao.DataRecibo = DateTime.Parse((xmlElement2.GetElementsByTagName("dhRecbto")[0] as XmlElement).InnerText);
					NotaInutilizacao.Protocolo = (xmlElement2.GetElementsByTagName("nProt")[0] as XmlElement).InnerText;
				}
			}
			else
			{
				etapa = RetornoNFe.EtapaEnvio.EnvioPedido;
			}
		}
		else
		{
			etapa = RetornoNFe.EtapaEnvio.VerSituacao;
		}
		return new RetornoNFe(num, text, etapa, TipoEmissao.Normal, text2);
	}

	public static string CriarNFe(ref NotaFiscalNotasFiscais nf, TipoEmissao tEmis)
	{
		bool flag = false;
		bool flag2 = false;
		try
		{
			flag2 = ModuloParametros.ObterParametros("Faturamento", "Não Incluir Data Saida XML").Valor == 1;
		}
		catch
		{
		}
		SubstituirTagsTextoLegal(nf);
		bool flag3 = false;
		if (nf.Entidade.Pais.ToUpper() == "BR")
		{
			nf.Entidade.Pais = "Brasil";
		}
		bool flag4 = !(nf.Entidade.Pais.ToUpper() == "BRASIL");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
		XmlElement xmlElement = xmlDocument.CreateElement("NFe");
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("xmlns");
		xmlAttribute.Value = "http://www.portalfiscal.inf.br/nfe";
		xmlElement.Attributes.Append(xmlAttribute);
		xmlDocument.AppendChild(xmlElement);
		XmlElement xmlElement2 = xmlDocument.CreateElement("infNFe");
		nf.ChaveNfe = GerarChaveNFe(nf, tEmis);
		xmlAttribute = xmlDocument.CreateAttribute("Id");
		xmlAttribute.Value = "NFe" + nf.ChaveNfe;
		xmlElement2.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("versao");
		xmlAttribute.Value = "4.00";
		xmlElement2.Attributes.Append(xmlAttribute);
		xmlElement.AppendChild(xmlElement2);
		XmlElement xmlElement3 = xmlDocument.CreateElement("ide");
		xmlElement2.AppendChild(xmlElement3);
		XmlElement xmlElement4 = xmlDocument.CreateElement("cUF");
		string text = nf.Emitente.Estado.ToUpper();
		if (string.IsNullOrEmpty(text))
		{
			text = "SP";
		}
		xmlElement4.InnerText = ModuloNotaFiscal.ObterNotaFiscalUF(text).Id.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("cNF");
		string text2 = GerarXML2.LimpaNro(nf.SerieNotaFiscal);
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "0";
		}
		text2 = int.Parse(text2).ToString().Trim();
		xmlElement4.InnerText = GerarXML2.GerarCNF(int.Parse(text2), nf.NumeroNotaFiscal).Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("natOp");
		if (string.IsNullOrWhiteSpace(nf.DescricaoCFOP) && nf.Itens != null && nf.Itens.Count > 0)
		{
			nf.DescricaoCFOP = nf.Itens[0].CFOPRef.Nfe;
		}
		xmlElement4.InnerText = nf.DescricaoCFOP.Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("mod");
		xmlElement4.InnerText = "55";
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("serie");
		xmlElement4.InnerText = text2.Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("nNF");
		xmlElement4.InnerText = nf.NumeroNotaFiscal.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("dhEmi");
		xmlElement4.InnerText = nf.DataEmissao.ToString("yyyy-MM-ddTHH:mm:sszzz").Trim();
		xmlElement3.AppendChild(xmlElement4);
		if (!flag2)
		{
			xmlElement4 = xmlDocument.CreateElement("dhSaiEnt");
			if (nf.DataSaida < nf.DataEmissao)
			{
				nf.DataSaida = nf.DataEmissao;
			}
			xmlElement4.InnerText = nf.DataSaida.ToString("yyyy-MM-ddTHH:mm:sszzz").Trim();
			xmlElement3.AppendChild(xmlElement4);
		}
		xmlElement4 = xmlDocument.CreateElement("tpNF");
		int num = 1;
		if (nf.IsNotaFiscalEntrada)
		{
			num = 0;
		}
		xmlElement4.InnerText = num.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("idDest");
		int num2 = 1;
		if (flag4)
		{
			num2 = 3;
		}
		else if (nf.Emitente.CodigoUF != nf.Entidade.CodigoUf)
		{
			num2 = 2;
		}
		xmlElement4.InnerText = num2.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("cMunFG");
		xmlElement4.InnerText = ModuloNotaFiscal.ObterNotaFiscalCidades(nf.Emitente.Cidade).Id.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("tpImp");
		xmlElement4.InnerText = "1";
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("tpEmis");
		switch (tEmis)
		{
		case TipoEmissao.ContingenciaFS:
			xmlElement4.InnerText = "2";
			break;
		case TipoEmissao.ContingenciaSCAN:
			xmlElement4.InnerText = "3";
			throw new Exception("ContingenciaSCAN não tratada!!");
		case TipoEmissao.ContingenciaEletronicaSCE:
			xmlElement4.InnerText = "4";
			throw new Exception("ContingenciaEletronicaSCE não tratada!!");
		default:
			xmlElement4.InnerText = "1";
			break;
		}
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("cDV");
		xmlElement4.InnerText = nf.ChaveNfe[nf.ChaveNfe.Length - 1].ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("tpAmb");
		xmlElement4.InnerText = ConfigNFe.Instancia.AmbienteInt.ToString("0").Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("finNFe");
		xmlElement4.InnerText = nf.TipoNota.ToString().Trim();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("indFinal");
		xmlElement4.InnerText = (nf.IsConsumidorFinal ? "1" : "0");
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("indPres");
		xmlElement4.InnerText = nf.CodigoIndicadorPresenca.ToString();
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("procEmi");
		xmlElement4.InnerText = "0";
		xmlElement3.AppendChild(xmlElement4);
		xmlElement4 = xmlDocument.CreateElement("verProc");
		xmlElement4.InnerText = "MaxGPS";
		xmlElement3.AppendChild(xmlElement4);
		if (tEmis == TipoEmissao.ContingenciaFS)
		{
			xmlElement4 = xmlDocument.CreateElement("dhCont");
			xmlElement4.InnerText = nf.DataSaida.ToString("yyyy-MM-ddTHH:mm:sszzz").Trim();
			xmlElement3.AppendChild(xmlElement4);
			xmlElement4 = xmlDocument.CreateElement("xJust");
			xmlElement4.InnerText = "Falha impossibilitando o envio do arquivo XML para o Web Service";
			xmlElement3.AppendChild(xmlElement4);
		}
		if (nf.ChavesNotasReferenciadas != null && nf.ChavesNotasReferenciadas.Count > 0)
		{
			foreach (NotaFiscalNotaReferenciada chavesNotasReferenciada in nf.ChavesNotasReferenciadas)
			{
				if (!string.IsNullOrWhiteSpace(chavesNotasReferenciada.NotaReferenciada) && chavesNotasReferenciada.NotaReferenciada.Trim().Length == 44)
				{
					XmlElement xmlElement5 = xmlDocument.CreateElement("NFref");
					xmlElement3.AppendChild(xmlElement5);
					XmlElement xmlElement6 = xmlDocument.CreateElement("refNFe");
					xmlElement6.InnerText = chavesNotasReferenciada.NotaReferenciada.Trim();
					xmlElement5.AppendChild(xmlElement6);
				}
			}
		}
		else if (!string.IsNullOrWhiteSpace(nf.NotaReferenciada))
		{
			XmlElement xmlElement7 = xmlDocument.CreateElement("NFref");
			xmlElement3.AppendChild(xmlElement7);
			XmlElement xmlElement8 = xmlDocument.CreateElement("refNFe");
			xmlElement8.InnerText = nf.NotaReferenciada.Trim();
			xmlElement7.AppendChild(xmlElement8);
		}
		XmlElement xmlElement9 = xmlDocument.CreateElement("emit");
		xmlElement2.AppendChild(xmlElement9);
		string text3 = GerarXML2.LimpaNro(nf.Emitente.Cnpj);
		XmlElement xmlElement10 = xmlDocument.CreateElement((text3.Length == 14) ? "CNPJ" : "CPF");
		xmlElement10.InnerText = text3.Trim();
		xmlElement9.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("xNome");
		xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Emitente.RazaoSocial).Trim();
		xmlElement9.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("xFant");
		xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Emitente.NomeFantasia).Trim();
		xmlElement9.AppendChild(xmlElement10);
		XmlElement xmlElement11 = xmlDocument.CreateElement("enderEmit");
		xmlElement9.AppendChild(xmlElement11);
		string text4 = nf.Emitente.Endereco.Trim();
		string text5 = string.Empty;
		for (int i = text4.Length - 1; i >= 0 && char.IsDigit(text4[i]); i--)
		{
			text5 = text4[i] + text5;
		}
		text4 = text4.Substring(0, text4.Length - text5.Length);
		if (string.IsNullOrEmpty(text5))
		{
			text5 = "0";
		}
		xmlElement10 = xmlDocument.CreateElement("xLgr");
		xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(text4).Trim(',').Trim();
		xmlElement11.AppendChild(xmlElement10);
		if (!string.IsNullOrWhiteSpace(nf.Emitente.Numero))
		{
			text5 = nf.Emitente.Numero;
		}
		xmlElement10 = xmlDocument.CreateElement("nro");
		xmlElement10.InnerText = text5.Trim();
		xmlElement11.AppendChild(xmlElement10);
		if (!string.IsNullOrEmpty(nf.Emitente.Bairro))
		{
			xmlElement10 = xmlDocument.CreateElement("xBairro");
			xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Emitente.Bairro).Trim();
			xmlElement11.AppendChild(xmlElement10);
		}
		xmlElement10 = xmlDocument.CreateElement("cMun");
		xmlElement10.InnerText = nf.Emitente.CodigoCidade.ToString().Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("xMun");
		xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Emitente.Cidade).Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("UF");
		xmlElement10.InnerText = text.Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("CEP");
		xmlElement10.InnerText = GerarXML2.LimpaNro(nf.Emitente.CodigoPostal).Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("cPais");
		string text6 = nf.Emitente.Pais.Trim();
		if (string.IsNullOrEmpty(text6))
		{
			text6 = "Brasil";
		}
		NotaFiscalPaises notaFiscalPaises = ModuloNotaFiscal.ObterNotaFiscalPaises(text6);
		if (notaFiscalPaises == null)
		{
			throw new Exception("Cadastre o país " + text6 + " antes de gerar essa nota!");
		}
		xmlElement10.InnerText = notaFiscalPaises.Codigo.ToString().Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("xPais");
		xmlElement10.InnerText = GerarXML2.CodificaCaracteresEspeciais(text6).Trim();
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("fone");
		xmlElement10.InnerText = GerarXML2.LimpaNro(nf.Emitente.Telefone).Trim();
		if (string.IsNullOrEmpty(xmlElement10.InnerText))
		{
			xmlElement10.InnerText = "1100000000";
		}
		xmlElement11.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("IE");
		xmlElement10.InnerText = GerarXML2.LimpaNro(nf.Emitente.InscricaoEstadual).Trim();
		if (string.IsNullOrEmpty(xmlElement10.InnerText))
		{
			xmlElement10.InnerText = "ISENTO";
		}
		xmlElement9.AppendChild(xmlElement10);
		xmlElement10 = xmlDocument.CreateElement("CRT");
		xmlElement10.InnerText = ((int)nf.Emitente.RegimeTributacao).ToString().Trim();
		xmlElement9.AppendChild(xmlElement10);
		XmlElement xmlElement12 = xmlDocument.CreateElement("dest");
		xmlElement2.AppendChild(xmlElement12);
		XmlElement xmlElement13;
		if (!flag4)
		{
			text3 = GerarXML2.LimpaNro(nf.Entidade.CNPJ).Trim();
			xmlElement13 = xmlDocument.CreateElement((text3.Length == 14) ? "CNPJ" : "CPF");
			xmlElement13.InnerText = text3;
			xmlElement12.AppendChild(xmlElement13);
		}
		else
		{
			xmlElement13 = xmlDocument.CreateElement("idEstrangeiro");
			xmlElement13.InnerText = nf.Entidade.Codigo.ToString("0000000000").Trim();
			xmlElement12.AppendChild(xmlElement13);
		}
		xmlElement13 = xmlDocument.CreateElement("xNome");
		if (ConfigNFe.Instancia.AmbienteInt == 1)
		{
			xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.RazaoSocialNF).Trim();
		}
		else
		{
			xmlElement13.InnerText = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
		}
		xmlElement12.AppendChild(xmlElement13);
		if (!flag4)
		{
			if (nf.Entidade.CidadeRef == null)
			{
				throw new Exception("Cidade do destinatário não encontrado!!!!! Favor Corrigir o Cadastro!");
			}
			if (nf.Entidade.UfRef == null)
			{
				throw new Exception("Estado do destinatário não encontrado!!!!! Favor Corrigir o Cadastro!");
			}
		}
		else if (nf.Entidade.PaisRef == null)
		{
			throw new Exception("País do destinatário não encontrado!!!!! Favor Corrigir o Cadastro!");
		}
		XmlElement xmlElement14 = xmlDocument.CreateElement("enderDest");
		xmlElement12.AppendChild(xmlElement14);
		xmlElement13 = xmlDocument.CreateElement("xLgr");
		xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.AuxEndereco).Trim();
		xmlElement14.AppendChild(xmlElement13);
		xmlElement13 = xmlDocument.CreateElement("nro");
		xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.AuxEnderecoNumero).Trim();
		if (string.IsNullOrEmpty(xmlElement13.InnerText))
		{
			xmlElement13.InnerText = "00";
		}
		xmlElement14.AppendChild(xmlElement13);
		if (!string.IsNullOrEmpty(nf.Entidade.AuxBairro))
		{
			xmlElement13 = xmlDocument.CreateElement("xBairro");
			xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.AuxBairro).Trim();
			xmlElement14.AppendChild(xmlElement13);
		}
		else
		{
			xmlElement13 = xmlDocument.CreateElement("xBairro");
			xmlElement13.InnerText = "Não Informado";
			xmlElement14.AppendChild(xmlElement13);
		}
		xmlElement13 = xmlDocument.CreateElement("cMun");
		if (flag4)
		{
			xmlElement13.InnerText = "9999999";
		}
		else
		{
			xmlElement13.InnerText = nf.Entidade.CodigoCidade.ToString();
		}
		xmlElement14.AppendChild(xmlElement13);
		xmlElement13 = xmlDocument.CreateElement("xMun");
		if (flag4)
		{
			xmlElement13.InnerText = "EXTERIOR";
		}
		else
		{
			xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.AuxCidade).Trim();
		}
		xmlElement14.AppendChild(xmlElement13);
		xmlElement13 = xmlDocument.CreateElement("UF");
		if (flag4)
		{
			xmlElement13.InnerText = "EX";
		}
		else
		{
			xmlElement13.InnerText = nf.Entidade.AuxUf.Trim();
		}
		xmlElement14.AppendChild(xmlElement13);
		xmlElement13 = xmlDocument.CreateElement("CEP");
		xmlElement13.InnerText = GerarXML2.LimpaNro(nf.Entidade.CodigoPostal).Trim();
		if (string.IsNullOrEmpty(xmlElement13.InnerText))
		{
			xmlElement13.InnerText = "00000000";
		}
		xmlElement14.AppendChild(xmlElement13);
		if (flag4)
		{
			xmlElement13 = xmlDocument.CreateElement("cPais");
			xmlElement13.InnerText = nf.Entidade.CodigoPais.ToString().Trim();
			xmlElement14.AppendChild(xmlElement13);
			xmlElement13 = xmlDocument.CreateElement("xPais");
			xmlElement13.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.Entidade.AuxPais).Trim();
			xmlElement14.AppendChild(xmlElement13);
		}
		else
		{
			xmlElement13 = xmlDocument.CreateElement("cPais");
			xmlElement13.InnerText = "1058";
			xmlElement14.AppendChild(xmlElement13);
			xmlElement13 = xmlDocument.CreateElement("xPais");
			xmlElement13.InnerText = "BRASIL";
			xmlElement14.AppendChild(xmlElement13);
		}
		xmlElement13 = xmlDocument.CreateElement("fone");
		xmlElement13.InnerText = GerarXML2.LimpaNro(nf.Entidade.Telefone).Trim();
		if (string.IsNullOrEmpty(xmlElement13.InnerText))
		{
			xmlElement13.InnerText = "1100000000";
		}
		else
		{
			xmlElement13.InnerText = xmlElement13.InnerText.TrimStart('0');
		}
		if (xmlElement13.InnerText.Length > 10)
		{
			xmlElement13.InnerText = xmlElement13.InnerText.Substring(0, 10).Trim();
		}
		xmlElement14.AppendChild(xmlElement13);
		string text7 = GerarXML2.LimpaNro(nf.Entidade.InscricaoEstadual).Trim();
		string text8 = "1";
		if (nf.Entidade.CodigoIndIeDestinatario == 0)
		{
			if (string.IsNullOrWhiteSpace(text7))
			{
				text8 = "2";
			}
			if (flag4)
			{
				text8 = "9";
			}
			if (nf.ValorTotalIcmsInterestadualFundoPobreza + nf.ValorTotalIcmsInterestadualUfDestino + nf.ValorTotalIcmsInterestadualUfEnvolvidas > 0m)
			{
				text8 = "9";
			}
			if (GerarXML2.LimpaNro(nf.Entidade.CNPJ).Trim().Length < 14)
			{
				text8 = "9";
			}
			if (text8 == "2" && nf.Itens != null && nf.Itens.Count > 0)
			{
				decimal num3 = nf.Itens[0].PercentualIcmsInterestadualUfDestino + nf.Itens[0].PercentualIcmsInterestadualUfEnvolvidas + nf.Itens[0].PercentualIcmsInterestadualFundoPobreza;
				if (num3 > 0m)
				{
					text8 = "9";
				}
			}
		}
		else
		{
			text8 = nf.Entidade.CodigoIndIeDestinatario.ToString();
		}
		xmlElement13 = xmlDocument.CreateElement("indIEDest");
		xmlElement13.InnerText = text8.Trim();
		xmlElement12.AppendChild(xmlElement13);
		if (!string.IsNullOrWhiteSpace(text7) && text3.Length == 14)
		{
			xmlElement13 = xmlDocument.CreateElement("IE");
			xmlElement13.InnerText = text7.Trim();
			xmlElement12.AppendChild(xmlElement13);
		}
		if (!string.IsNullOrWhiteSpace(nf.Entidade.CodigoSuframa))
		{
			nf.Suframa = GerarXML2.LimpaNro(nf.Entidade.CodigoSuframa);
		}
		if (!string.IsNullOrWhiteSpace(nf.Suframa))
		{
			xmlElement13 = xmlDocument.CreateElement("ISUF");
			xmlElement13.InnerText = nf.Suframa;
			xmlElement12.AppendChild(xmlElement13);
		}
		if (!string.IsNullOrWhiteSpace(nf.Entidade.EmailNotaFiscal.Trim()))
		{
			string[] array = nf.Entidade.EmailNotaFiscal.Split(';');
			if (array.Length != 0)
			{
				xmlElement13 = xmlDocument.CreateElement("email");
				xmlElement13.InnerText = array[0].Trim();
				xmlElement12.AppendChild(xmlElement13);
			}
		}
		if (nf.EntidadeEntregaStruct.codigo > 0 && nf.EntidadeEntrega != null)
		{
			XmlElement xmlElement15 = xmlDocument.CreateElement("entrega");
			xmlElement2.AppendChild(xmlElement15);
			text3 = GerarXML2.LimpaNro(nf.EntidadeEntrega.CNPJLimpo).Trim();
			XmlElement xmlElement16 = xmlDocument.CreateElement((text3.Length == 14) ? "CNPJ" : "CPF");
			xmlElement16.InnerText = text3;
			xmlElement15.AppendChild(xmlElement16);
			if (nf.EntidadeEntrega.CidadeRef == null)
			{
				throw new Exception("Cidade do destinatário não encontrado!!!!! Favor Corrigir o Cadastro!");
			}
			if (nf.EntidadeEntrega.UfRef == null)
			{
				throw new Exception("Estado do destinatário não encontrado!!!!! Favor Corrigir o Cadastro!");
			}
			if (!string.IsNullOrWhiteSpace(nf.EntidadeEntrega.AuxEndereco))
			{
				xmlElement16 = xmlDocument.CreateElement("xLgr");
				xmlElement16.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.EntidadeEntrega.AuxEndereco).Trim();
				xmlElement15.AppendChild(xmlElement16);
				xmlElement16 = xmlDocument.CreateElement("nro");
				xmlElement16.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.EntidadeEntrega.AuxEnderecoNumero).Trim();
				if (string.IsNullOrEmpty(xmlElement16.InnerText))
				{
					xmlElement16.InnerText = "00";
				}
				xmlElement15.AppendChild(xmlElement16);
			}
			if (!string.IsNullOrEmpty(nf.EntidadeEntrega.AuxBairro))
			{
				xmlElement16 = xmlDocument.CreateElement("xBairro");
				xmlElement16.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.EntidadeEntrega.AuxBairro).Trim();
				xmlElement15.AppendChild(xmlElement16);
			}
			else
			{
				xmlElement16 = xmlDocument.CreateElement("xBairro");
				xmlElement16.InnerText = "Não Informado";
				xmlElement15.AppendChild(xmlElement16);
			}
			if (!string.IsNullOrEmpty(nf.EntidadeEntrega.CodigoCidade.ToString()))
			{
				xmlElement16 = xmlDocument.CreateElement("cMun");
				xmlElement16.InnerText = nf.EntidadeEntrega.CodigoCidade.ToString();
				xmlElement15.AppendChild(xmlElement16);
			}
			if (!string.IsNullOrEmpty(nf.EntidadeEntrega.AuxCidade))
			{
				xmlElement16 = xmlDocument.CreateElement("xMun");
				xmlElement16.InnerText = GerarXML2.CodificaCaracteresEspeciais(nf.EntidadeEntrega.AuxCidade).Trim();
				xmlElement15.AppendChild(xmlElement16);
			}
			if (!string.IsNullOrEmpty(nf.EntidadeEntrega.AuxUf))
			{
				xmlElement16 = xmlDocument.CreateElement("UF");
				xmlElement16.InnerText = nf.EntidadeEntrega.AuxUf.Trim();
				xmlElement15.AppendChild(xmlElement16);
			}
		}
		if (nf.Emitente.ContabilidadeRef != null && (!string.IsNullOrWhiteSpace(nf.Emitente.ContabilidadeRef.Cnpj) || !string.IsNullOrWhiteSpace(nf.Emitente.ContabilidadeRef.Cpf)))
		{
			XmlElement xmlElement17 = xmlDocument.CreateElement("autXML");
			xmlElement2.AppendChild(xmlElement17);
			string text9 = GerarXML2.LimpaNro(nf.Emitente.ContabilidadeRef.Cnpj).Trim();
			if (string.IsNullOrWhiteSpace(text9))
			{
				text9 = GerarXML2.LimpaNro(nf.Emitente.ContabilidadeRef.Cpf).Trim();
			}
			XmlElement xmlElement18 = xmlDocument.CreateElement((text9.Length == 14) ? "CNPJ" : "CPF");
			xmlElement18.InnerText = text9;
			xmlElement17.AppendChild(xmlElement18);
		}
		int num4 = 0;
		int num5 = 1;
		foreach (NotaFiscalNotasFiscaisItens iten in nf.Itens)
		{
			num4++;
			XmlElement xmlElement19 = xmlDocument.CreateElement("det");
			xmlElement2.AppendChild(xmlElement19);
			XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("nItem");
			xmlAttribute2.Value = num5.ToString();
			xmlElement19.Attributes.Append(xmlAttribute2);
			num5++;
			XmlElement xmlElement20 = xmlDocument.CreateElement("prod");
			xmlElement19.AppendChild(xmlElement20);
			XmlElement xmlElement21 = xmlDocument.CreateElement("cProd");
			xmlElement21.InnerText = iten.CodigoProduto.Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("cEAN");
			if (string.IsNullOrWhiteSpace(iten.CodigoEan))
			{
				xmlElement21.InnerText = "SEM GTIN";
			}
			else
			{
				xmlElement21.InnerText = iten.CodigoEan;
			}
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("xProd");
			xmlElement21.InnerText = GerarXML2.CodificaCaracteresEspeciais(iten.DescricaoProduto.Trim());
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("NCM");
			xmlElement21.InnerText = ((!string.IsNullOrEmpty(iten.CodigoClassificacaoFiscal)) ? iten.CodigoClassificacaoFiscal.Trim() : "00000000");
			xmlElement20.AppendChild(xmlElement21);
			if ((iten.ValorICMSSTAgregado > 0m && !string.IsNullOrWhiteSpace(iten.Cest)) || iten.TipoIncidenciaIcms == "60" || iten.TipoIncidenciaIcms == "500")
			{
				xmlElement21 = xmlDocument.CreateElement("CEST");
				xmlElement21.InnerText = ((!string.IsNullOrEmpty(GerarXML2.LimpaNro(iten.Cest))) ? GerarXML2.LimpaNro(iten.Cest) : "0000000");
				xmlElement20.AppendChild(xmlElement21);
			}
			if (iten.Extipi > 0)
			{
				xmlElement21 = xmlDocument.CreateElement("EXTIPI");
				xmlElement21.InnerText = iten.Extipi.ToString("000");
				xmlElement20.AppendChild(xmlElement21);
			}
			xmlElement21 = xmlDocument.CreateElement("CFOP");
			xmlElement21.InnerText = GerarXML2.LimpaNro(iten.NomeCfop).Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("uCom");
			xmlElement21.InnerText = iten.SiglaUnidadeFaturamento.Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("qCom");
			xmlElement21.InnerText = iten.Quantidade.ToString("F04").Replace(',', '.').Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("vUnCom");
			xmlElement21.InnerText = iten.ValorUnitarioComImpostoImportacao.ToString("F06").Replace(',', '.').Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("vProd");
			xmlElement21.InnerText = iten.ValorTotalComImpostoImportacao.ToString("F02").Replace(',', '.').Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("cEANTrib");
			if (string.IsNullOrWhiteSpace(iten.CodigoEan))
			{
				xmlElement21.InnerText = "SEM GTIN";
			}
			else
			{
				xmlElement21.InnerText = iten.CodigoEan;
			}
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("uTrib");
			xmlElement21.InnerText = iten.SiglaFaturamentoTributario.Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("qTrib");
			xmlElement21.InnerText = iten.QuantidadeTributario.ToString("F04").Replace(',', '.').Trim();
			xmlElement20.AppendChild(xmlElement21);
			xmlElement21 = xmlDocument.CreateElement("vUnTrib");
			xmlElement21.InnerText = iten.ValorUnitarioTributario.ToString("F06").Replace(',', '.').Trim();
			xmlElement20.AppendChild(xmlElement21);
			if (iten.ValorFrete > 0m)
			{
				xmlElement21 = xmlDocument.CreateElement("vFrete");
				xmlElement21.InnerText = iten.ValorFrete.ToString("F02").Replace(',', '.').Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			if (iten.ValorSeguro > 0m)
			{
				xmlElement21 = xmlDocument.CreateElement("vSeg");
				xmlElement21.InnerText = iten.ValorSeguro.ToString("F02").Replace(',', '.').Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			if (iten.ValorDesconto + iten.ValorIcmsDesonerado > 0m)
			{
				xmlElement21 = xmlDocument.CreateElement("vDesc");
				xmlElement21.InnerText = (iten.ValorDesconto + iten.ValorIcmsDesonerado).ToString("F02").Replace(',', '.').Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			if (iten.ValorOutros > 0m)
			{
				xmlElement21 = xmlDocument.CreateElement("vOutro");
				xmlElement21.InnerText = iten.ValorOutros.ToString("F02").Replace(',', '.').Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			xmlElement21 = xmlDocument.CreateElement("indTot");
			xmlElement21.InnerText = "1";
			xmlElement20.AppendChild(xmlElement21);
			if (iten.NomeCfop.Substring(0, 1) == "3" && iten.NotaFiscalItensDIRef != null)
			{
				XmlElement xmlElement22 = xmlDocument.CreateElement("DI");
				xmlElement20.AppendChild(xmlElement22);
				XmlElement xmlElement23 = xmlDocument.CreateElement("nDI");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.NumeroDI.Trim();
				xmlElement22.AppendChild(xmlElement23);
				xmlElement23 = xmlDocument.CreateElement("dDI");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.DatasDI.ToString("yyyy-MM-dd").Trim();
				xmlElement22.AppendChild(xmlElement23);
				xmlElement23 = xmlDocument.CreateElement("xLocDesemb");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.LocalDesembarque.Trim();
				xmlElement22.AppendChild(xmlElement23);
				xmlElement23 = xmlDocument.CreateElement("UFDesemb");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.UfDesembarque.Trim();
				xmlElement22.AppendChild(xmlElement23);
				xmlElement23 = xmlDocument.CreateElement("dDesemb");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.DataDesembarque.ToString("yyyy-MM-dd").Trim();
				xmlElement22.AppendChild(xmlElement23);
				xmlElement23 = xmlDocument.CreateElement("tpViaTransp");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.TipoViaTransporte.ToString().Trim();
				xmlElement22.AppendChild(xmlElement23);
				if (iten.NotaFiscalItensDIRef.Vafrmm > 0m)
				{
					xmlElement23 = xmlDocument.CreateElement("vAFRMM");
					xmlElement23.InnerText = iten.NotaFiscalItensDIRef.Vafrmm.ToString("F02").Replace(',', '.').Trim();
					xmlElement22.AppendChild(xmlElement23);
				}
				xmlElement23 = xmlDocument.CreateElement("tpIntermedio");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.TipoIntermedio.ToString().Trim();
				xmlElement22.AppendChild(xmlElement23);
				if (!string.IsNullOrWhiteSpace(iten.NotaFiscalItensDIRef.Cnpja))
				{
					xmlElement23 = xmlDocument.CreateElement("CNPJ");
					xmlElement23.InnerText = iten.NotaFiscalItensDIRef.Cnpja.Trim();
					xmlElement22.AppendChild(xmlElement23);
				}
				if (!string.IsNullOrWhiteSpace(iten.NotaFiscalItensDIRef.UfTerceiro))
				{
					xmlElement23 = xmlDocument.CreateElement("UFTerceiro");
					xmlElement23.InnerText = iten.NotaFiscalItensDIRef.UfTerceiro.Trim();
					xmlElement22.AppendChild(xmlElement23);
				}
				xmlElement23 = xmlDocument.CreateElement("cExportador");
				xmlElement23.InnerText = iten.NotaFiscalItensDIRef.CodigoExportador.Trim();
				xmlElement22.AppendChild(xmlElement23);
				if (iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes != null && iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes.Count > 0 && iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0] != null)
				{
					XmlElement xmlElement24 = xmlDocument.CreateElement("adi");
					xmlElement22.AppendChild(xmlElement24);
					XmlElement xmlElement25 = xmlDocument.CreateElement("nAdicao");
					xmlElement25.InnerText = iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].NumeroAdicao.ToString().Trim();
					xmlElement24.AppendChild(xmlElement25);
					xmlElement25 = xmlDocument.CreateElement("nSeqAdic");
					xmlElement25.InnerText = iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].NumeroSequenciaAdicao.ToString().Trim();
					xmlElement24.AppendChild(xmlElement25);
					xmlElement25 = xmlDocument.CreateElement("cFabricante");
					xmlElement25.InnerText = iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].CodigoFabricante.ToString().Trim();
					xmlElement24.AppendChild(xmlElement25);
					if (iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].ValorDescontoDI > 0m)
					{
						xmlElement25 = xmlDocument.CreateElement("vDescDI");
						xmlElement25.InnerText = iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].ValorDescontoDI.ToString().Trim();
						xmlElement24.AppendChild(xmlElement25);
					}
					if (!string.IsNullOrWhiteSpace(iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].CodigoDrawBack) && (iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].CodigoDrawBack.Length == 9 || iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].CodigoDrawBack.Length == 11))
					{
						xmlElement25 = xmlDocument.CreateElement("nDraw");
						xmlElement25.InnerText = iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes[0].CodigoDrawBack.Trim();
						xmlElement24.AppendChild(xmlElement25);
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(iten.ContratoCliente))
			{
				xmlElement21 = xmlDocument.CreateElement("xPed");
				xmlElement21.InnerText = iten.ContratoCliente.Trim();
				xmlElement20.AppendChild(xmlElement21);
				xmlElement21 = xmlDocument.CreateElement("nItemPed");
				xmlElement21.InnerText = iten.ContratoClienteItem.ToString().Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			else if (!string.IsNullOrWhiteSpace(iten.CodigoPedidoCompraCliente))
			{
				xmlElement21 = xmlDocument.CreateElement("xPed");
				xmlElement21.InnerText = iten.CodigoPedidoCompraCliente.Trim();
				xmlElement20.AppendChild(xmlElement21);
				xmlElement21 = xmlDocument.CreateElement("nItemPed");
				xmlElement21.InnerText = iten.CodigoPedidoCompraItemCliente.ToString().Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			if (!string.IsNullOrWhiteSpace(iten.CodigoFCI))
			{
				xmlElement21 = xmlDocument.CreateElement("nFCI");
				xmlElement21.InnerText = iten.CodigoFCI.Trim();
				xmlElement20.AppendChild(xmlElement21);
			}
			bool flag5 = false;
			XmlElement xmlElement26 = xmlDocument.CreateElement("imposto");
			xmlElement19.AppendChild(xmlElement26);
			string tipoIncidenciaIcms = iten.TipoIncidenciaIcms;
			XmlElement xmlElement27 = xmlDocument.CreateElement("ICMS");
			int num6 = int.Parse(tipoIncidenciaIcms);
			string text10 = tipoIncidenciaIcms;
			if (num6 < 100)
			{
				if (text10 == "41" || text10 == "50")
				{
					text10 = "40";
				}
				switch (num6)
				{
				case 0:
				{
					XmlElement xmlElement42 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement43 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement43.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement42.AppendChild(xmlElement43);
					xmlElement43 = xmlDocument.CreateElement("CST");
					xmlElement43.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement42.AppendChild(xmlElement43);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement43 = xmlDocument.CreateElement("modBC");
					xmlElement43.InnerText = iten.CodigoModalidadeIcms.Trim();
					xmlElement42.AppendChild(xmlElement43);
					xmlElement43 = xmlDocument.CreateElement("vBC");
					xmlElement43.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement42.AppendChild(xmlElement43);
					xmlElement43 = xmlDocument.CreateElement("pICMS");
					xmlElement43.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement42.AppendChild(xmlElement43);
					xmlElement43 = xmlDocument.CreateElement("vICMS");
					xmlElement43.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement42.AppendChild(xmlElement43);
					if (iten.ValorFundoCombatePobreza > 0m)
					{
						xmlElement43 = xmlDocument.CreateElement("pFCP");
						xmlElement43.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement42.AppendChild(xmlElement43);
						xmlElement43 = xmlDocument.CreateElement("vFCP");
						xmlElement43.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement42.AppendChild(xmlElement43);
					}
					xmlElement27.AppendChild(xmlElement42);
					break;
				}
				case 10:
				{
					XmlElement xmlElement34 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement35 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement35.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("CST");
					xmlElement35.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement34.AppendChild(xmlElement35);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement35 = xmlDocument.CreateElement("modBC");
					xmlElement35.InnerText = iten.CodigoModalidadeIcms.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("vBC");
					xmlElement35.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("pICMS");
					xmlElement35.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("vICMS");
					xmlElement35.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					if (iten.ValorFundoCombatePobreza > 0m)
					{
						xmlElement35 = xmlDocument.CreateElement("vBCFCP");
						xmlElement35.InnerText = iten.ValorBaseCalculoFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
						xmlElement35 = xmlDocument.CreateElement("pFCP");
						xmlElement35.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
						xmlElement35 = xmlDocument.CreateElement("vFCP");
						xmlElement35.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
					}
					xmlElement35 = xmlDocument.CreateElement("modBCST");
					xmlElement35.InnerText = iten.CodigoModalidadeICMSST.ToString().Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("pMVAST");
					xmlElement35.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						xmlElement35 = xmlDocument.CreateElement("pRedBCST");
						xmlElement35.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement34.AppendChild(xmlElement35);
					}
					xmlElement35 = xmlDocument.CreateElement("vBCST");
					xmlElement35.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("pICMSST");
					xmlElement35.InnerText = iten.PercentualICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					xmlElement35 = xmlDocument.CreateElement("vICMSST");
					xmlElement35.InnerText = iten.ValorICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement34.AppendChild(xmlElement35);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						xmlElement35 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement35.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
						xmlElement35 = xmlDocument.CreateElement("pFCPST");
						xmlElement35.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
						xmlElement35 = xmlDocument.CreateElement("vFCPST");
						xmlElement35.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement34.AppendChild(xmlElement35);
					}
					xmlElement27.AppendChild(xmlElement34);
					break;
				}
				case 20:
				{
					XmlElement xmlElement36 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement37 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement37.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement36.AppendChild(xmlElement37);
					xmlElement37 = xmlDocument.CreateElement("CST");
					xmlElement37.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement36.AppendChild(xmlElement37);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement37 = xmlDocument.CreateElement("modBC");
					xmlElement37.InnerText = iten.CodigoModalidadeIcms.Trim();
					xmlElement36.AppendChild(xmlElement37);
					xmlElement37 = xmlDocument.CreateElement("pRedBC");
					xmlElement37.InnerText = iten.PercentualBaseReducaoIcms.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement36.AppendChild(xmlElement37);
					xmlElement37 = xmlDocument.CreateElement("vBC");
					xmlElement37.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement36.AppendChild(xmlElement37);
					xmlElement37 = xmlDocument.CreateElement("pICMS");
					xmlElement37.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement36.AppendChild(xmlElement37);
					xmlElement37 = xmlDocument.CreateElement("vICMS");
					xmlElement37.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement36.AppendChild(xmlElement37);
					if (iten.ValorFundoCombatePobreza > 0m)
					{
						xmlElement37 = xmlDocument.CreateElement("vBCFCP");
						xmlElement37.InnerText = iten.ValorBaseCalculoFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement36.AppendChild(xmlElement37);
						xmlElement37 = xmlDocument.CreateElement("pFCP");
						xmlElement37.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement36.AppendChild(xmlElement37);
						xmlElement37 = xmlDocument.CreateElement("vFCP");
						xmlElement37.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement36.AppendChild(xmlElement37);
					}
					if (iten.MotivoDesoneracaoIcms > 0)
					{
						xmlElement37 = xmlDocument.CreateElement("vICMSDeson");
						xmlElement37.InnerText = iten.ValorIcmsDesonerado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement36.AppendChild(xmlElement37);
						xmlElement37 = xmlDocument.CreateElement("motDesICMS");
						xmlElement37.InnerText = iten.MotivoDesoneracaoIcms.ToString("");
						xmlElement36.AppendChild(xmlElement37);
					}
					xmlElement27.AppendChild(xmlElement36);
					break;
				}
				case 30:
				{
					XmlElement xmlElement44 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement45 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement45.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement44.AppendChild(xmlElement45);
					xmlElement45 = xmlDocument.CreateElement("CST");
					xmlElement45.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement44.AppendChild(xmlElement45);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement45 = xmlDocument.CreateElement("modBCST");
					xmlElement45.InnerText = iten.CodigoModalidadeICMSST.ToString().Trim();
					xmlElement44.AppendChild(xmlElement45);
					xmlElement45 = xmlDocument.CreateElement("pMVAST");
					xmlElement45.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement44.AppendChild(xmlElement45);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						xmlElement45 = xmlDocument.CreateElement("pRedBCST");
						xmlElement45.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement44.AppendChild(xmlElement45);
					}
					xmlElement45 = xmlDocument.CreateElement("vBCST");
					xmlElement45.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement44.AppendChild(xmlElement45);
					xmlElement45 = xmlDocument.CreateElement("pICMSST");
					xmlElement45.InnerText = iten.PercentualICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement44.AppendChild(xmlElement45);
					xmlElement45 = xmlDocument.CreateElement("vICMSST");
					xmlElement45.InnerText = iten.ValorICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement44.AppendChild(xmlElement45);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						xmlElement45 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement45.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement44.AppendChild(xmlElement45);
						xmlElement45 = xmlDocument.CreateElement("pFCPST");
						xmlElement45.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement44.AppendChild(xmlElement45);
						xmlElement45 = xmlDocument.CreateElement("vFCPST");
						xmlElement45.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement44.AppendChild(xmlElement45);
					}
					if (iten.MotivoDesoneracaoIcms > 0)
					{
						xmlElement45 = xmlDocument.CreateElement("vICMSDeson");
						xmlElement45.InnerText = iten.ValorIcmsDesonerado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement44.AppendChild(xmlElement45);
						xmlElement45 = xmlDocument.CreateElement("motDesICMS");
						xmlElement45.InnerText = iten.MotivoDesoneracaoIcms.ToString("");
						xmlElement44.AppendChild(xmlElement45);
					}
					xmlElement27.AppendChild(xmlElement44);
					break;
				}
				case 40:
				case 41:
				case 50:
				{
					XmlElement xmlElement38 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement39 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement39.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement38.AppendChild(xmlElement39);
					xmlElement39 = xmlDocument.CreateElement("CST");
					xmlElement39.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement38.AppendChild(xmlElement39);
					if (iten.MotivoDesoneracaoIcms > 0)
					{
						xmlElement39 = xmlDocument.CreateElement("vICMSDeson");
						xmlElement39.InnerText = iten.ValorIcmsDesonerado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement38.AppendChild(xmlElement39);
						xmlElement39 = xmlDocument.CreateElement("motDesICMS");
						xmlElement39.InnerText = iten.MotivoDesoneracaoIcms.ToString("");
						xmlElement38.AppendChild(xmlElement39);
					}
					xmlElement27.AppendChild(xmlElement38);
					break;
				}
				case 51:
				{
					XmlElement xmlElement30 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement31 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement31.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement30.AppendChild(xmlElement31);
					xmlElement31 = xmlDocument.CreateElement("CST");
					xmlElement31.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement30.AppendChild(xmlElement31);
					if (iten.ValorICMS > 0m)
					{
						if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
						{
							iten.CodigoModalidadeIcms = "0";
						}
						xmlElement31 = xmlDocument.CreateElement("modBC");
						xmlElement31.InnerText = iten.CodigoModalidadeIcms.Trim();
						xmlElement30.AppendChild(xmlElement31);
						xmlElement31 = xmlDocument.CreateElement("pRedBC");
						xmlElement31.InnerText = iten.PercentualBaseReducaoIcms.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement30.AppendChild(xmlElement31);
						xmlElement31 = xmlDocument.CreateElement("vBC");
						xmlElement31.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement30.AppendChild(xmlElement31);
						xmlElement31 = xmlDocument.CreateElement("pICMS");
						xmlElement31.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement30.AppendChild(xmlElement31);
						xmlElement31 = xmlDocument.CreateElement("vICMSOp");
						xmlElement31.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement30.AppendChild(xmlElement31);
						if (iten.ValorFundoCombatePobreza > 0m)
						{
							xmlElement31 = xmlDocument.CreateElement("vBCFCP");
							xmlElement31.InnerText = iten.ValorBaseCalculoFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement30.AppendChild(xmlElement31);
							xmlElement31 = xmlDocument.CreateElement("pFCP");
							xmlElement31.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement30.AppendChild(xmlElement31);
							xmlElement31 = xmlDocument.CreateElement("vFCP");
							xmlElement31.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement30.AppendChild(xmlElement31);
						}
					}
					xmlElement27.AppendChild(xmlElement30);
					break;
				}
				case 60:
				{
					XmlElement xmlElement32 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement33 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement33.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement33 = xmlDocument.CreateElement("CST");
					xmlElement33.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement33 = xmlDocument.CreateElement("vBCSTRet");
					xmlElement33.InnerText = iten.ValorBaseCalculoIcmsStRetido.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement33 = xmlDocument.CreateElement("pST");
					xmlElement33.InnerText = iten.PercentualSuportadoConsumidorFinal.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement33 = xmlDocument.CreateElement("vICMSSubstituto");
					xmlElement33.InnerText = iten.ValorIcmsSubstituto.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement33 = xmlDocument.CreateElement("vICMSSTRet");
					xmlElement33.InnerText = iten.ValorIcmsStRetido.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement32.AppendChild(xmlElement33);
					xmlElement27.AppendChild(xmlElement32);
					break;
				}
				case 70:
				{
					XmlElement xmlElement40 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement41 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement41.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("CST");
					xmlElement41.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement40.AppendChild(xmlElement41);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement41 = xmlDocument.CreateElement("modBC");
					xmlElement41.InnerText = iten.CodigoModalidadeIcms.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("pRedBC");
					xmlElement41.InnerText = iten.PercentualBaseReducaoIcms.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("vBC");
					xmlElement41.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("pICMS");
					xmlElement41.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("vICMS");
					xmlElement41.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					if (iten.ValorFundoCombatePobreza > 0m)
					{
						xmlElement41 = xmlDocument.CreateElement("vBCFCP");
						xmlElement41.InnerText = iten.ValorBaseCalculoFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
						xmlElement41 = xmlDocument.CreateElement("pFCP");
						xmlElement41.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
						xmlElement41 = xmlDocument.CreateElement("vFCP");
						xmlElement41.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
					}
					xmlElement41 = xmlDocument.CreateElement("modBCST");
					xmlElement41.InnerText = iten.CodigoModalidadeICMSST.ToString().Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("pMVAST");
					xmlElement41.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						xmlElement41 = xmlDocument.CreateElement("pRedBCST");
						xmlElement41.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement40.AppendChild(xmlElement41);
					}
					xmlElement41 = xmlDocument.CreateElement("vBCST");
					xmlElement41.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("pICMSST");
					xmlElement41.InnerText = iten.PercentualICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					xmlElement41 = xmlDocument.CreateElement("vICMSST");
					xmlElement41.InnerText = iten.ValorICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement40.AppendChild(xmlElement41);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						xmlElement41 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement41.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
						xmlElement41 = xmlDocument.CreateElement("pFCPST");
						xmlElement41.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
						xmlElement41 = xmlDocument.CreateElement("vFCPST");
						xmlElement41.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
					}
					if (iten.MotivoDesoneracaoIcms > 0)
					{
						xmlElement41 = xmlDocument.CreateElement("vICMSDeson");
						xmlElement41.InnerText = iten.ValorIcmsDesonerado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement40.AppendChild(xmlElement41);
						xmlElement41 = xmlDocument.CreateElement("motDesICMS");
						xmlElement41.InnerText = iten.MotivoDesoneracaoIcms.ToString("");
						xmlElement40.AppendChild(xmlElement41);
					}
					xmlElement27.AppendChild(xmlElement40);
					break;
				}
				case 90:
				{
					XmlElement xmlElement28 = xmlDocument.CreateElement("ICMS" + text10);
					XmlElement xmlElement29 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement29.InnerText = iten.CodigoOrigemProduto.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("CST");
					xmlElement29.InnerText = tipoIncidenciaIcms.Trim();
					xmlElement28.AppendChild(xmlElement29);
					if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
					{
						iten.CodigoModalidadeIcms = "0";
					}
					xmlElement29 = xmlDocument.CreateElement("modBC");
					xmlElement29.InnerText = iten.CodigoModalidadeIcms.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("vBC");
					xmlElement29.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("pICMS");
					xmlElement29.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("vICMS");
					xmlElement29.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					if (iten.ValorFundoCombatePobreza > 0m)
					{
						xmlElement29 = xmlDocument.CreateElement("vBCFCP");
						xmlElement29.InnerText = iten.ValorBaseCalculoFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
						xmlElement29 = xmlDocument.CreateElement("pFCP");
						xmlElement29.InnerText = iten.PercentualFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
						xmlElement29 = xmlDocument.CreateElement("vFCP");
						xmlElement29.InnerText = iten.ValorFundoCombatePobreza.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
					}
					xmlElement29 = xmlDocument.CreateElement("modBCST");
					xmlElement29.InnerText = iten.CodigoModalidadeICMSST.ToString().Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("pMVAST");
					xmlElement29.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						xmlElement29 = xmlDocument.CreateElement("pRedBCST");
						xmlElement29.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement28.AppendChild(xmlElement29);
					}
					xmlElement29 = xmlDocument.CreateElement("vBCST");
					xmlElement29.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("pICMSST");
					xmlElement29.InnerText = iten.PercentualICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					xmlElement29 = xmlDocument.CreateElement("vICMSST");
					xmlElement29.InnerText = iten.ValorICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement28.AppendChild(xmlElement29);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						xmlElement29 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement29.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
						xmlElement29 = xmlDocument.CreateElement("pFCPST");
						xmlElement29.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
						xmlElement29 = xmlDocument.CreateElement("vFCPST");
						xmlElement29.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
					}
					if (iten.MotivoDesoneracaoIcms > 0)
					{
						xmlElement29 = xmlDocument.CreateElement("vICMSDeson");
						xmlElement29.InnerText = iten.ValorIcmsDesonerado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement28.AppendChild(xmlElement29);
						xmlElement29 = xmlDocument.CreateElement("motDesICMS");
						xmlElement29.InnerText = iten.MotivoDesoneracaoIcms.ToString("");
						xmlElement28.AppendChild(xmlElement29);
					}
					xmlElement27.AppendChild(xmlElement28);
					break;
				}
				}
			}
			else
			{
				switch (text10)
				{
				case "102":
				case "103":
				case "300":
				case "400":
				{
					flag = true;
					XmlElement xmlElement96 = xmlDocument.CreateElement("ICMSSN102");
					XmlElement xmlElement97 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement97.InnerText = iten.CodigoOrigemProduto;
					xmlElement96.AppendChild(xmlElement97);
					XmlElement xmlElement98 = xmlDocument.CreateElement("CSOSN");
					xmlElement98.InnerText = tipoIncidenciaIcms;
					xmlElement96.AppendChild(xmlElement98);
					xmlElement27.AppendChild(xmlElement96);
					break;
				}
				case "201":
				{
					flag3 = true;
					XmlElement xmlElement84 = xmlDocument.CreateElement("ICMSSN" + text10);
					XmlElement xmlElement85 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement85.InnerText = iten.CodigoOrigemProduto;
					xmlElement84.AppendChild(xmlElement85);
					XmlElement xmlElement86 = xmlDocument.CreateElement("CSOSN");
					xmlElement86.InnerText = tipoIncidenciaIcms;
					xmlElement84.AppendChild(xmlElement86);
					XmlElement xmlElement87 = xmlDocument.CreateElement("modBCST");
					xmlElement87.InnerText = iten.CodigoModalidadeICMSST.ToString();
					xmlElement84.AppendChild(xmlElement87);
					XmlElement xmlElement88 = xmlDocument.CreateElement("pMVAST");
					xmlElement88.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F2").Replace(",", ".");
					xmlElement84.AppendChild(xmlElement88);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						XmlElement xmlElement89 = xmlDocument.CreateElement("pRedBCST");
						xmlElement89.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement84.AppendChild(xmlElement89);
					}
					XmlElement xmlElement90 = xmlDocument.CreateElement("vBCST");
					xmlElement90.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F2").Replace(",", ".");
					xmlElement84.AppendChild(xmlElement90);
					XmlElement xmlElement91 = xmlDocument.CreateElement("pICMSST");
					xmlElement91.InnerText = iten.PercentualICMSSTAgregado.ToString("F2").Replace(",", ".");
					xmlElement84.AppendChild(xmlElement91);
					XmlElement xmlElement92 = xmlDocument.CreateElement("vICMSST");
					decimal num7 = default(decimal);
					xmlElement92.InnerText = iten.ValorICMSSTAgregado.ToString("F2").Replace(",", ".");
					xmlElement84.AppendChild(xmlElement92);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						XmlElement xmlElement93 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement93.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement84.AppendChild(xmlElement93);
						xmlElement93 = xmlDocument.CreateElement("pFCPST");
						xmlElement93.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement84.AppendChild(xmlElement93);
						xmlElement93 = xmlDocument.CreateElement("vFCPST");
						xmlElement93.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement84.AppendChild(xmlElement93);
					}
					XmlElement xmlElement94 = xmlDocument.CreateElement("pCredSN");
					xmlElement94.InnerText = iten.PercentualCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
					xmlElement84.AppendChild(xmlElement94);
					XmlElement xmlElement95 = xmlDocument.CreateElement("vCredICMSSN");
					xmlElement95.InnerText = iten.ValorCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
					xmlElement84.AppendChild(xmlElement95);
					xmlElement27.AppendChild(xmlElement84);
					break;
				}
				case "101":
				{
					XmlElement xmlElement62 = xmlDocument.CreateElement("ICMSSN" + text10);
					XmlElement xmlElement63 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement63.InnerText = iten.CodigoOrigemProduto;
					xmlElement62.AppendChild(xmlElement63);
					XmlElement xmlElement64 = xmlDocument.CreateElement("CSOSN");
					xmlElement64.InnerText = tipoIncidenciaIcms;
					xmlElement62.AppendChild(xmlElement64);
					if (iten.PercentualCreditoIcms > 0m)
					{
						XmlElement xmlElement65 = xmlDocument.CreateElement("pCredSN");
						xmlElement65.InnerText = iten.PercentualCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement62.AppendChild(xmlElement65);
						XmlElement xmlElement66 = xmlDocument.CreateElement("vCredICMSSN");
						xmlElement66.InnerText = iten.ValorCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement62.AppendChild(xmlElement66);
					}
					xmlElement27.AppendChild(xmlElement62);
					break;
				}
				case "500":
				{
					XmlElement xmlElement58 = xmlDocument.CreateElement("ICMSSN" + text10);
					XmlElement xmlElement59 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement59.InnerText = iten.CodigoOrigemProduto;
					xmlElement58.AppendChild(xmlElement59);
					xmlElement59 = xmlDocument.CreateElement("CSOSN");
					xmlElement59.InnerText = tipoIncidenciaIcms;
					xmlElement58.AppendChild(xmlElement59);
					xmlElement59 = xmlDocument.CreateElement("vBCSTRet");
					xmlElement59.InnerText = iten.ValorBaseCalculoIcmsStRetido.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement58.AppendChild(xmlElement59);
					xmlElement59 = xmlDocument.CreateElement("pST");
					xmlElement59.InnerText = iten.PercentualSuportadoConsumidorFinal.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement58.AppendChild(xmlElement59);
					xmlElement59 = xmlDocument.CreateElement("vICMSSubstituto");
					xmlElement59.InnerText = iten.ValorIcmsSubstituto.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement58.AppendChild(xmlElement59);
					xmlElement59 = xmlDocument.CreateElement("vICMSSTRet");
					xmlElement59.InnerText = iten.ValorIcmsStRetido.ToString("F02").Replace(".", "").Replace(',', '.')
						.Trim();
					xmlElement58.AppendChild(xmlElement59);
					if (iten.PercentualCreditoIcms > 0m)
					{
						XmlElement xmlElement60 = xmlDocument.CreateElement("pCredSN");
						xmlElement60.InnerText = iten.PercentualCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement58.AppendChild(xmlElement60);
						XmlElement xmlElement61 = xmlDocument.CreateElement("vCredICMSSN");
						xmlElement61.InnerText = iten.ValorCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement58.AppendChild(xmlElement61);
					}
					xmlElement27.AppendChild(xmlElement58);
					break;
				}
				case "900":
				{
					XmlElement xmlElement67 = xmlDocument.CreateElement("ICMSSN" + text10);
					XmlElement xmlElement68 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement68.InnerText = iten.CodigoOrigemProduto;
					xmlElement67.AppendChild(xmlElement68);
					XmlElement xmlElement69 = xmlDocument.CreateElement("CSOSN");
					xmlElement69.InnerText = tipoIncidenciaIcms;
					xmlElement67.AppendChild(xmlElement69);
					if (iten.AliquotaICMS > 0m)
					{
						if (string.IsNullOrWhiteSpace(iten.CodigoModalidadeIcms))
						{
							iten.CodigoModalidadeIcms = "0";
						}
						XmlElement xmlElement70 = xmlDocument.CreateElement("modBC");
						xmlElement70.InnerText = iten.CodigoModalidadeIcms.Trim();
						xmlElement67.AppendChild(xmlElement70);
						XmlElement xmlElement71 = xmlDocument.CreateElement("vBC");
						xmlElement71.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement71);
						flag3 = true;
						if (iten.PercentualBaseReducaoIcms > 0m)
						{
							XmlElement xmlElement72 = xmlDocument.CreateElement("pRedBC");
							xmlElement72.InnerText = iten.PercentualBaseReducaoIcms.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement67.AppendChild(xmlElement72);
						}
						XmlElement xmlElement73 = xmlDocument.CreateElement("pICMS");
						xmlElement73.InnerText = iten.AliquotaICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement73);
						XmlElement xmlElement74 = xmlDocument.CreateElement("vICMS");
						xmlElement74.InnerText = iten.ValorICMS.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement74);
					}
					if (iten.PercentualBaseAgragadaICMSST > 0m)
					{
						XmlElement xmlElement75 = xmlDocument.CreateElement("modBCST");
						xmlElement75.InnerText = iten.CodigoModalidadeICMSST.ToString().Trim();
						xmlElement67.AppendChild(xmlElement75);
						XmlElement xmlElement76 = xmlDocument.CreateElement("pMVAST");
						xmlElement76.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement76);
						if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
						{
							XmlElement xmlElement77 = xmlDocument.CreateElement("pRedBCST");
							xmlElement77.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
							xmlElement67.AppendChild(xmlElement77);
						}
						XmlElement xmlElement78 = xmlDocument.CreateElement("vBCST");
						xmlElement78.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement78);
						XmlElement xmlElement79 = xmlDocument.CreateElement("pICMSST");
						xmlElement79.InnerText = iten.PercentualICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement79);
						XmlElement xmlElement80 = xmlDocument.CreateElement("vICMSST");
						xmlElement80.InnerText = iten.ValorICMSSTAgregado.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement67.AppendChild(xmlElement80);
						if (iten.ValorFundoCombatePobrezaST > 0m)
						{
							XmlElement xmlElement81 = xmlDocument.CreateElement("vBCFCPST");
							xmlElement81.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement67.AppendChild(xmlElement81);
							xmlElement81 = xmlDocument.CreateElement("pFCPST");
							xmlElement81.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement67.AppendChild(xmlElement81);
							xmlElement81 = xmlDocument.CreateElement("vFCPST");
							xmlElement81.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
								.Trim();
							xmlElement67.AppendChild(xmlElement81);
						}
					}
					if (iten.PercentualCreditoIcms > 0m)
					{
						XmlElement xmlElement82 = xmlDocument.CreateElement("pCredSN");
						xmlElement82.InnerText = iten.PercentualCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement67.AppendChild(xmlElement82);
						XmlElement xmlElement83 = xmlDocument.CreateElement("vCredICMSSN");
						xmlElement83.InnerText = iten.ValorCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement67.AppendChild(xmlElement83);
					}
					xmlElement27.AppendChild(xmlElement67);
					break;
				}
				case "202":
				case "203":
				{
					flag3 = true;
					XmlElement xmlElement46 = xmlDocument.CreateElement("ICMSSN" + text10);
					XmlElement xmlElement47 = xmlDocument.CreateElement("orig");
					if (string.IsNullOrWhiteSpace(iten.CodigoOrigemProduto))
					{
						iten.CodigoOrigemProduto = "0";
					}
					xmlElement47.InnerText = iten.CodigoOrigemProduto;
					xmlElement46.AppendChild(xmlElement47);
					XmlElement xmlElement48 = xmlDocument.CreateElement("CSOSN");
					xmlElement48.InnerText = tipoIncidenciaIcms;
					xmlElement46.AppendChild(xmlElement48);
					XmlElement xmlElement49 = xmlDocument.CreateElement("modBCST");
					xmlElement49.InnerText = iten.CodigoModalidadeICMSST.ToString();
					xmlElement46.AppendChild(xmlElement49);
					XmlElement xmlElement50 = xmlDocument.CreateElement("pMVAST");
					xmlElement50.InnerText = iten.PercentualBaseAgragadaICMSST.ToString("F2").Replace(",", ".");
					xmlElement46.AppendChild(xmlElement50);
					if (iten.PercentualReducaoBaseCalculoICMSST > 0m)
					{
						XmlElement xmlElement51 = xmlDocument.CreateElement("pRedBCST");
						xmlElement51.InnerText = iten.PercentualReducaoBaseCalculoICMSST.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement46.AppendChild(xmlElement51);
					}
					XmlElement xmlElement52 = xmlDocument.CreateElement("vBCST");
					xmlElement52.InnerText = iten.ValorBaseAgragadaICMSST.ToString("F2").Replace(",", ".");
					xmlElement46.AppendChild(xmlElement52);
					XmlElement xmlElement53 = xmlDocument.CreateElement("pICMSST");
					xmlElement53.InnerText = iten.PercentualICMSSTAgregado.ToString("F2").Replace(",", ".");
					xmlElement46.AppendChild(xmlElement53);
					XmlElement xmlElement54 = xmlDocument.CreateElement("vICMSST");
					xmlElement54.InnerText = iten.ValorICMSSTAgregado.ToString("F2").Replace(",", ".");
					xmlElement46.AppendChild(xmlElement54);
					if (iten.ValorFundoCombatePobrezaST > 0m)
					{
						XmlElement xmlElement55 = xmlDocument.CreateElement("vBCFCPST");
						xmlElement55.InnerText = iten.ValorBaseCalculoFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement46.AppendChild(xmlElement55);
						xmlElement55 = xmlDocument.CreateElement("pFCPST");
						xmlElement55.InnerText = iten.PercentualFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement46.AppendChild(xmlElement55);
						xmlElement55 = xmlDocument.CreateElement("vFCPST");
						xmlElement55.InnerText = iten.ValorFundoCombatePobrezaST.ToString("F02").Replace(".", "").Replace(',', '.')
							.Trim();
						xmlElement46.AppendChild(xmlElement55);
					}
					if (iten.PercentualCreditoIcms > 0m)
					{
						XmlElement xmlElement56 = xmlDocument.CreateElement("pCredSN");
						xmlElement56.InnerText = iten.PercentualCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement46.AppendChild(xmlElement56);
						XmlElement xmlElement57 = xmlDocument.CreateElement("vCredICMSSN");
						xmlElement57.InnerText = iten.ValorCreditoIcms.ToString("F02").Replace(".", "").Replace(',', '.');
						xmlElement46.AppendChild(xmlElement57);
					}
					xmlElement27.AppendChild(xmlElement46);
					break;
				}
				}
			}
			xmlElement26.AppendChild(xmlElement27);
			XmlElement xmlElement99 = xmlDocument.CreateElement("IPI");
			XmlElement xmlElement100 = xmlDocument.CreateElement("cEnq");
			if (iten.CodigoEnquadramentoIPI > 0)
			{
				xmlElement100.InnerText = iten.CodigoEnquadramentoIPI.ToString("000").Trim();
			}
			else
			{
				xmlElement100.InnerText = "999";
			}
			xmlElement99.AppendChild(xmlElement100);
			XmlElement xmlElement101 = xmlDocument.CreateElement("CST");
			xmlElement101.InnerText = iten.TipoIncidenciaIpi.Trim();
			switch (iten.TipoIncidenciaIpi)
			{
			case "00":
			case "49":
			case "50":
			case "99":
			{
				XmlElement xmlElement103 = xmlDocument.CreateElement("IPITrib");
				xmlElement103.AppendChild(xmlElement101);
				xmlElement99.AppendChild(xmlElement103);
				XmlElement xmlElement104 = xmlDocument.CreateElement("vBC");
				if (iten.ValorIPI > 0m)
				{
					xmlElement104.InnerText = iten.ValorBaseCalculoIpi.ToString("F02").Replace(',', '.').Trim();
				}
				else
				{
					xmlElement104.InnerText = "0.00";
				}
				xmlElement103.AppendChild(xmlElement104);
				XmlElement xmlElement105 = xmlDocument.CreateElement("pIPI");
				xmlElement105.InnerText = iten.AliquotaIPI.ToString("F02").Replace(',', '.').Trim();
				xmlElement103.AppendChild(xmlElement105);
				XmlElement xmlElement106 = xmlDocument.CreateElement("vIPI");
				xmlElement106.InnerText = iten.ValorIPI.ToString("F02").Replace(',', '.').Trim();
				xmlElement103.AppendChild(xmlElement106);
				break;
			}
			default:
			{
				XmlElement xmlElement102 = xmlDocument.CreateElement("IPINT");
				xmlElement102.AppendChild(xmlElement101);
				xmlElement99.AppendChild(xmlElement102);
				break;
			}
			}
			xmlElement26.AppendChild(xmlElement99);
			if (iten.NomeCfop.Substring(0, 1) == "3")
			{
				XmlElement xmlElement107 = xmlDocument.CreateElement("II");
				XmlElement xmlElement108 = xmlDocument.CreateElement("vBC");
				xmlElement108.InnerText = iten.ValorBaseCalculoImpostoImportacao.ToString("F02").Replace(',', '.').Trim();
				xmlElement107.AppendChild(xmlElement108);
				xmlElement108 = xmlDocument.CreateElement("vDespAdu");
				xmlElement108.InnerText = iten.ValorDespesasAduaneiras.ToString("F02").Replace(',', '.').Trim();
				xmlElement107.AppendChild(xmlElement108);
				xmlElement108 = xmlDocument.CreateElement("vII");
				xmlElement108.InnerText = iten.ValorImpostoImportacao.ToString("F02").Replace(',', '.').Trim();
				xmlElement107.AppendChild(xmlElement108);
				xmlElement108 = xmlDocument.CreateElement("vIOF");
				xmlElement108.InnerText = iten.ValorIof.ToString("F02").Replace(',', '.').Trim();
				xmlElement107.AppendChild(xmlElement108);
				xmlElement26.AppendChild(xmlElement107);
			}
			XmlElement xmlElement109 = xmlDocument.CreateElement("PIS");
			XmlElement xmlElement110 = xmlDocument.CreateElement("CST");
			xmlElement110.InnerText = iten.TipoIncidenciaPis.Trim();
			switch (iten.TipoIncidenciaPis)
			{
			case "01":
			case "02":
			{
				XmlElement xmlElement120 = xmlDocument.CreateElement("PISAliq");
				xmlElement120.AppendChild(xmlElement110);
				xmlElement109.AppendChild(xmlElement120);
				XmlElement xmlElement121 = xmlDocument.CreateElement("vBC");
				xmlElement121.InnerText = iten.ValorBaseCalculoPis.ToString("F02").Replace(',', '.').Trim();
				xmlElement120.AppendChild(xmlElement121);
				XmlElement xmlElement122 = xmlDocument.CreateElement("pPIS");
				xmlElement122.InnerText = iten.AliquotaPis.ToString("F02").Replace(',', '.').Trim();
				xmlElement120.AppendChild(xmlElement122);
				XmlElement xmlElement123 = xmlDocument.CreateElement("vPIS");
				xmlElement123.InnerText = iten.ValorPIS.ToString("F02").Replace(',', '.').Trim();
				xmlElement120.AppendChild(xmlElement123);
				break;
			}
			case "03":
			{
				XmlElement xmlElement116 = xmlDocument.CreateElement("PISQtde");
				xmlElement116.AppendChild(xmlElement110);
				xmlElement109.AppendChild(xmlElement116);
				XmlElement xmlElement117 = xmlDocument.CreateElement("qBCProd");
				xmlElement117.InnerText = iten.Quantidade.ToString("F04").Replace(',', '.').Trim();
				xmlElement116.AppendChild(xmlElement117);
				XmlElement xmlElement118 = xmlDocument.CreateElement("vAliqProd");
				xmlElement118.InnerText = Math.Round(iten.AliquotaPis / 100m * iten.ValorUnitario, 4).ToString("F04").Replace(',', '.')
					.Trim();
				xmlElement116.AppendChild(xmlElement118);
				XmlElement xmlElement119 = xmlDocument.CreateElement("vPIS");
				xmlElement119.InnerText = Math.Round(Math.Round(iten.AliquotaPis / 100m * iten.ValorUnitario, 4) * iten.Quantidade, 2).ToString("F02").Replace(',', '.')
					.Trim();
				xmlElement116.AppendChild(xmlElement119);
				break;
			}
			case "99":
			case "49":
			{
				XmlElement xmlElement112 = xmlDocument.CreateElement("PISOutr");
				xmlElement112.AppendChild(xmlElement110);
				xmlElement109.AppendChild(xmlElement112);
				XmlElement xmlElement113 = xmlDocument.CreateElement("vBC");
				if (iten.AliquotaPis > 0m)
				{
					xmlElement113.InnerText = iten.ValorBaseCalculoPis.ToString("F04").Replace(',', '.').Trim();
				}
				else
				{
					xmlElement113.InnerText = "0.00";
				}
				xmlElement112.AppendChild(xmlElement113);
				XmlElement xmlElement114 = xmlDocument.CreateElement("pPIS");
				xmlElement114.InnerText = iten.AliquotaPis.ToString("F02").Replace(',', '.').Trim();
				xmlElement112.AppendChild(xmlElement114);
				XmlElement xmlElement115 = xmlDocument.CreateElement("vPIS");
				xmlElement115.InnerText = iten.ValorPIS.ToString("F02").Replace(',', '.').Trim();
				xmlElement112.AppendChild(xmlElement115);
				break;
			}
			default:
			{
				XmlElement xmlElement111 = xmlDocument.CreateElement("PISNT");
				xmlElement111.AppendChild(xmlElement110);
				xmlElement109.AppendChild(xmlElement111);
				break;
			}
			}
			xmlElement26.AppendChild(xmlElement109);
			XmlElement xmlElement124 = xmlDocument.CreateElement("COFINS");
			XmlElement xmlElement125 = xmlDocument.CreateElement("CST");
			xmlElement125.InnerText = iten.TipoIncidenciaCofins;
			switch (iten.TipoIncidenciaCofins)
			{
			case "01":
			case "02":
			{
				XmlElement xmlElement135 = xmlDocument.CreateElement("COFINSAliq");
				xmlElement135.AppendChild(xmlElement125);
				xmlElement124.AppendChild(xmlElement135);
				XmlElement xmlElement136 = xmlDocument.CreateElement("vBC");
				xmlElement136.InnerText = iten.ValorBaseCalculoCofins.ToString("F02").Replace(',', '.');
				xmlElement135.AppendChild(xmlElement136);
				XmlElement xmlElement137 = xmlDocument.CreateElement("pCOFINS");
				xmlElement137.InnerText = iten.AliquotaCofins.ToString("F02").Replace(',', '.');
				xmlElement135.AppendChild(xmlElement137);
				XmlElement xmlElement138 = xmlDocument.CreateElement("vCOFINS");
				xmlElement138.InnerText = iten.ValorCofins.ToString("F02").Replace(',', '.');
				xmlElement135.AppendChild(xmlElement138);
				break;
			}
			case "03":
			{
				XmlElement xmlElement131 = xmlDocument.CreateElement("COFINSQtde");
				xmlElement131.AppendChild(xmlElement125);
				xmlElement124.AppendChild(xmlElement131);
				XmlElement xmlElement132 = xmlDocument.CreateElement("qBCProd");
				xmlElement132.InnerText = iten.Quantidade.ToString("F04").Replace(',', '.');
				xmlElement131.AppendChild(xmlElement132);
				XmlElement xmlElement133 = xmlDocument.CreateElement("vAliqProd");
				xmlElement133.InnerText = Math.Round(iten.AliquotaCofins / 100m * iten.ValorUnitario, 4).ToString("F04").Replace(',', '.');
				xmlElement131.AppendChild(xmlElement133);
				XmlElement xmlElement134 = xmlDocument.CreateElement("vCOFINS");
				xmlElement134.InnerText = iten.ValorCofins.ToString("F02").Replace(',', '.');
				xmlElement131.AppendChild(xmlElement134);
				break;
			}
			case "99":
			case "49":
			{
				XmlElement xmlElement127 = xmlDocument.CreateElement("COFINSOutr");
				xmlElement127.AppendChild(xmlElement125);
				xmlElement124.AppendChild(xmlElement127);
				XmlElement xmlElement128 = xmlDocument.CreateElement("vBC");
				if (iten.AliquotaCofins > 0m)
				{
					xmlElement128.InnerText = iten.ValorBaseCalculoCofins.ToString("F04").Replace(',', '.');
				}
				else
				{
					xmlElement128.InnerText = "0.00";
				}
				xmlElement127.AppendChild(xmlElement128);
				XmlElement xmlElement129 = xmlDocument.CreateElement("pCOFINS");
				xmlElement129.InnerText = iten.AliquotaCofins.ToString("F02").Replace(',', '.');
				xmlElement127.AppendChild(xmlElement129);
				XmlElement xmlElement130 = xmlDocument.CreateElement("vCOFINS");
				xmlElement130.InnerText = iten.ValorCofins.ToString("F02").Replace(',', '.');
				xmlElement127.AppendChild(xmlElement130);
				break;
			}
			default:
			{
				XmlElement xmlElement126 = xmlDocument.CreateElement("COFINSNT");
				xmlElement126.AppendChild(xmlElement125);
				xmlElement124.AppendChild(xmlElement126);
				break;
			}
			}
			xmlElement26.AppendChild(xmlElement124);
			if (iten.IsICMSInterestadual)
			{
				XmlElement xmlElement139 = xmlDocument.CreateElement("ICMSUFDest");
				XmlElement xmlElement140 = xmlDocument.CreateElement("vBCUFDest");
				xmlElement140.InnerText = iten.ValorBaseICMS.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement140);
				XmlElement xmlElement141 = xmlDocument.CreateElement("pFCPUFDest");
				xmlElement141.InnerText = iten.PercentualIcmsInterestadualFundoPobreza.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement141);
				XmlElement xmlElement142 = xmlDocument.CreateElement("pICMSUFDest");
				xmlElement142.InnerText = iten.PercentualIcmsInterestadualUfDestino.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement142);
				XmlElement xmlElement143 = xmlDocument.CreateElement("pICMSInter");
				xmlElement143.InnerText = iten.PercentualIcmsInterestadualUfEnvolvidas.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement143);
				XmlElement xmlElement144 = xmlDocument.CreateElement("pICMSInterPart");
				if (nf.DataEmissao.Year == 2016)
				{
					xmlElement144.InnerText = "40.00";
				}
				else if (nf.DataEmissao.Year == 2017)
				{
					xmlElement144.InnerText = "60.00";
				}
				else if (nf.DataEmissao.Year == 2018)
				{
					xmlElement144.InnerText = "80.00";
				}
				else
				{
					xmlElement144.InnerText = "100.00";
				}
				xmlElement139.AppendChild(xmlElement144);
				XmlElement xmlElement145 = xmlDocument.CreateElement("vFCPUFDest");
				xmlElement145.InnerText = iten.ValorIcmsInterestadualFundoPobreza.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement145);
				XmlElement xmlElement146 = xmlDocument.CreateElement("vICMSUFDest");
				xmlElement146.InnerText = iten.ValorIcmsInterestadualUfDestino.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement146);
				XmlElement xmlElement147 = xmlDocument.CreateElement("vICMSUFRemet");
				xmlElement147.InnerText = iten.ValorIcmsInterestadualUfEnvolvidas.ToString("F02").Replace(',', '.');
				xmlElement139.AppendChild(xmlElement147);
				xmlElement26.AppendChild(xmlElement139);
			}
			if (!string.IsNullOrWhiteSpace(iten.DescricaoComplementar) || !string.IsNullOrWhiteSpace(iten.TagXml))
			{
				XmlElement xmlElement148 = xmlDocument.CreateElement("infAdProd");
				string text11 = iten.DescricaoComplementar.Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty)
					.Trim();
				text11 = iten.TagXml + text11;
				xmlElement148.InnerText = ((text11.Length <= 500) ? text11 : text11.Substring(0, 500).Trim());
				xmlElement19.AppendChild(xmlElement148);
			}
		}
		XmlElement xmlElement149 = xmlDocument.CreateElement("total");
		xmlElement2.AppendChild(xmlElement149);
		XmlElement xmlElement150 = xmlDocument.CreateElement("ICMSTot");
		XmlElement xmlElement151 = xmlDocument.CreateElement("vBC");
		if (flag3)
		{
			if (nf.ValorBaseICMSSubstituto > 0m)
			{
				xmlElement151.InnerText = "0.00";
			}
			else
			{
				xmlElement151.InnerText = nf.ValorBaseICMS.ToString("F02").Replace(',', '.');
			}
			xmlElement150.AppendChild(xmlElement151);
			XmlElement xmlElement152 = xmlDocument.CreateElement("vICMS");
			if (nf.ValorBaseICMSSubstituto > 0m)
			{
				xmlElement152.InnerText = "0.00";
			}
			else
			{
				xmlElement152.InnerText = nf.ValorICMS.ToString("F02").Replace(',', '.');
			}
			xmlElement150.AppendChild(xmlElement152);
		}
		else
		{
			if (flag)
			{
				xmlElement151.InnerText = "0.00";
			}
			else
			{
				xmlElement151.InnerText = nf.ValorBaseICMS.ToString("F02").Replace(',', '.').Trim();
			}
			xmlElement150.AppendChild(xmlElement151);
			XmlElement xmlElement153 = xmlDocument.CreateElement("vICMS");
			if (flag)
			{
				xmlElement153.InnerText = "0.00";
			}
			else
			{
				xmlElement153.InnerText = nf.ValorICMS.ToString("F02").Replace(',', '.').Trim();
			}
			xmlElement150.AppendChild(xmlElement153);
		}
		XmlElement xmlElement154 = xmlDocument.CreateElement("vICMSDeson");
		xmlElement154.InnerText = nf.ValorIcmsDesonerado.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement154);
		if (nf.ValorTotalIcmsInterestadualFundoPobreza + nf.ValorTotalIcmsInterestadualUfDestino + nf.ValorTotalIcmsInterestadualUfEnvolvidas > 0m)
		{
			XmlElement xmlElement155 = xmlDocument.CreateElement("vFCPUFDest");
			xmlElement155.InnerText = nf.ValorTotalIcmsInterestadualFundoPobreza.ToString("F02").Replace(',', '.').Trim();
			xmlElement150.AppendChild(xmlElement155);
			XmlElement xmlElement156 = xmlDocument.CreateElement("vICMSUFDest");
			xmlElement156.InnerText = nf.ValorTotalIcmsInterestadualUfDestino.ToString("F02").Replace(',', '.').Trim();
			xmlElement150.AppendChild(xmlElement156);
			XmlElement xmlElement157 = xmlDocument.CreateElement("vICMSUFRemet");
			xmlElement157.InnerText = nf.ValorTotalIcmsInterestadualUfEnvolvidas.ToString("F02").Replace(',', '.').Trim();
			xmlElement150.AppendChild(xmlElement157);
		}
		XmlElement xmlElement158 = xmlDocument.CreateElement("vFCP");
		xmlElement158.InnerText = "0.00";
		xmlElement150.AppendChild(xmlElement158);
		XmlElement xmlElement159 = xmlDocument.CreateElement("vBCST");
		if (flag3)
		{
			if (nf.ValorBaseICMSSubstituto > 0m)
			{
				xmlElement159.InnerText = nf.ValorBaseICMSSubstituto.ToString("F02").Replace(',', '.').Trim();
			}
			else
			{
				xmlElement159.InnerText = "0.00";
			}
		}
		else if (nf.ValorBaseICMSSubstituto > 0m)
		{
			xmlElement159.InnerText = nf.ValorBaseICMSSubstituto.ToString("F02").Replace(',', '.').Trim();
		}
		else
		{
			xmlElement159.InnerText = "0.00";
		}
		xmlElement150.AppendChild(xmlElement159);
		XmlElement xmlElement160 = xmlDocument.CreateElement("vST");
		xmlElement160.InnerText = nf.ValorICMSSubstituto.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement160);
		XmlElement xmlElement161 = xmlDocument.CreateElement("vFCPST");
		xmlElement161.InnerText = "0.00";
		xmlElement150.AppendChild(xmlElement161);
		XmlElement xmlElement162 = xmlDocument.CreateElement("vFCPSTRet");
		xmlElement162.InnerText = "0.00";
		xmlElement150.AppendChild(xmlElement162);
		XmlElement xmlElement163 = xmlDocument.CreateElement("vProd");
		xmlElement163.InnerText = nf.ValorTotalProdutos.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement163);
		xmlElement149.AppendChild(xmlElement150);
		XmlElement xmlElement164 = xmlDocument.CreateElement("vFrete");
		xmlElement164.InnerText = nf.ValorFrete.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement164);
		XmlElement xmlElement165 = xmlDocument.CreateElement("vSeg");
		xmlElement165.InnerText = nf.ValorSeguro.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement165);
		XmlElement xmlElement166 = xmlDocument.CreateElement("vDesc");
		xmlElement166.InnerText = (nf.ValorDesconto + nf.ValorIcmsDesonerado).ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement166);
		XmlElement xmlElement167 = xmlDocument.CreateElement("vII");
		xmlElement167.InnerText = nf.ValorImpostoImportacao.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement167);
		XmlElement xmlElement168 = xmlDocument.CreateElement("vIPI");
		xmlElement168.InnerText = nf.ValorIPI.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement168);
		XmlElement xmlElement169 = xmlDocument.CreateElement("vIPIDevol");
		xmlElement169.InnerText = "0.00";
		xmlElement150.AppendChild(xmlElement169);
		XmlElement xmlElement170 = xmlDocument.CreateElement("vPIS");
		xmlElement170.InnerText = nf.ValorPIS.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement170);
		XmlElement xmlElement171 = xmlDocument.CreateElement("vCOFINS");
		xmlElement171.InnerText = nf.ValorCofins.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement171);
		XmlElement xmlElement172 = xmlDocument.CreateElement("vOutro");
		xmlElement172.InnerText = nf.ValorOutrasDespesas.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement172);
		XmlElement xmlElement173 = xmlDocument.CreateElement("vNF");
		xmlElement173.InnerText = nf.ValorTotalNotaFiscal.ToString("F02").Replace(',', '.').Trim();
		xmlElement150.AppendChild(xmlElement173);
		if (nf.ValorCofinsRetido > 0m || nf.ValorPISRetido > 0m)
		{
			XmlElement xmlElement174 = xmlDocument.CreateElement("retTrib");
			if (nf.ValorPISRetido > 0m)
			{
				XmlElement xmlElement175 = xmlDocument.CreateElement("vRetPIS");
				xmlElement175.InnerText = nf.ValorPISRetido.ToString("F02").Replace(',', '.').Trim();
				xmlElement174.AppendChild(xmlElement175);
			}
			if (nf.ValorCofinsRetido > 0m)
			{
				XmlElement xmlElement176 = xmlDocument.CreateElement("vRetCOFINS");
				xmlElement176.InnerText = nf.ValorCofinsRetido.ToString("F02").Replace(',', '.').Trim();
				xmlElement174.AppendChild(xmlElement176);
				xmlElement149.AppendChild(xmlElement174);
			}
		}
		if (nf.Transportadora != null || nf.IsFreteCliente)
		{
			XmlElement xmlElement177 = xmlDocument.CreateElement("transp");
			xmlElement2.AppendChild(xmlElement177);
			XmlElement xmlElement178 = xmlDocument.CreateElement("modFrete");
			xmlElement178.InnerText = nf.CodigoModalidadeFrete.ToString();
			xmlElement177.AppendChild(xmlElement178);
			if (!nf.IsFreteCliente)
			{
				if (nf.Transportadora.CNPJLimpo.Length == 11 || nf.Transportadora.CNPJLimpo.Length == 14)
				{
					XmlElement xmlElement179 = xmlDocument.CreateElement("transporta");
					xmlElement177.AppendChild(xmlElement179);
					xmlElement178 = xmlDocument.CreateElement((nf.Transportadora.CNPJLimpo.Length == 11) ? "CPF" : "CNPJ");
					string text12 = ((!string.IsNullOrEmpty(nf.Transportadora.CNPJ)) ? nf.Transportadora.CNPJLimpo.Trim() : (string.IsNullOrEmpty(nf.Transportadora.InscricaoEstadual) ? text3 : nf.Transportadora.InscricaoEstadual.Trim()));
					xmlElement178.InnerText = GerarXML2.LimpaNro(text12).Trim();
					if (!string.IsNullOrEmpty(text12))
					{
						xmlElement179.AppendChild(xmlElement178);
					}
					xmlElement178 = xmlDocument.CreateElement("xNome");
					xmlElement178.InnerText = nf.Transportadora.RazaoSocialNF.Trim();
					xmlElement179.AppendChild(xmlElement178);
					xmlElement178 = xmlDocument.CreateElement("IE");
					string innerText = GerarXML2.LimpaNro(nf.Transportadora.InscricaoEstadual).Trim();
					xmlElement178.InnerText = innerText;
					if (string.IsNullOrEmpty(xmlElement178.InnerText))
					{
						xmlElement178.InnerText = "ISENTO";
					}
					if (!string.IsNullOrEmpty(xmlElement178.InnerText))
					{
						xmlElement179.AppendChild(xmlElement178);
					}
					xmlElement178 = xmlDocument.CreateElement("xEnder");
					xmlElement178.InnerText = $"{nf.Transportadora.Endereco} {nf.Transportadora.AuxEnderecoNumero}".Trim();
					xmlElement179.AppendChild(xmlElement178);
					xmlElement178 = xmlDocument.CreateElement("xMun");
					xmlElement178.InnerText = nf.Transportadora.Cidade.Trim();
					xmlElement179.AppendChild(xmlElement178);
					xmlElement178 = xmlDocument.CreateElement("UF");
					string text13 = ((!string.IsNullOrEmpty(nf.Transportadora.UF)) ? nf.Transportadora.UF.ToUpper() : "SP");
					xmlElement178.InnerText = text13.Trim();
					xmlElement179.AppendChild(xmlElement178);
				}
			}
			else if (nf.Entidade.CNPJLimpo.Length == 14)
			{
				XmlElement xmlElement180 = xmlDocument.CreateElement("transporta");
				xmlElement177.AppendChild(xmlElement180);
				xmlElement178 = xmlDocument.CreateElement((nf.Entidade.CNPJLimpo.Length == 11) ? "CPF" : "CNPJ");
				xmlElement178 = xmlDocument.CreateElement("CNPJ");
				string text14 = ((!string.IsNullOrEmpty(nf.Entidade.CNPJLimpo)) ? nf.Entidade.CNPJLimpo : (string.IsNullOrEmpty(nf.Entidade.InscricaoEstadual) ? text3 : nf.Entidade.InscricaoEstadual));
				xmlElement178.InnerText = GerarXML2.LimpaNro(text14.Trim());
				if (!string.IsNullOrEmpty(text14))
				{
					xmlElement180.AppendChild(xmlElement178);
				}
				xmlElement178 = xmlDocument.CreateElement("xNome");
				xmlElement178.InnerText = nf.Entidade.RazaoSocialNF.Trim();
				xmlElement180.AppendChild(xmlElement178);
				xmlElement178 = xmlDocument.CreateElement("IE");
				string innerText2 = GerarXML2.LimpaNro(nf.Entidade.InscricaoEstadual).Trim();
				xmlElement178.InnerText = innerText2;
				if (string.IsNullOrEmpty(xmlElement178.InnerText))
				{
					if (nf.Entidade.Pais.ToUpper() != "BRASIL")
					{
						xmlElement178.InnerText = "";
					}
					else
					{
						xmlElement178.InnerText = "ISENTO";
					}
				}
				if (!string.IsNullOrEmpty(xmlElement178.InnerText))
				{
					xmlElement180.AppendChild(xmlElement178);
				}
				xmlElement178 = xmlDocument.CreateElement("xEnder");
				xmlElement178.InnerText = nf.Entidade.Endereco.Trim();
				xmlElement180.AppendChild(xmlElement178);
				xmlElement178 = xmlDocument.CreateElement("xMun");
				xmlElement178.InnerText = nf.Entidade.Cidade.Trim();
				xmlElement180.AppendChild(xmlElement178);
				xmlElement178 = xmlDocument.CreateElement("UF");
				string text15 = ((!string.IsNullOrEmpty(nf.Entidade.UF)) ? nf.Entidade.UF.ToUpper() : "SP");
				xmlElement178.InnerText = text15.Trim();
				xmlElement180.AppendChild(xmlElement178);
			}
			XmlElement xmlElement181 = xmlDocument.CreateElement("vol");
			xmlElement177.AppendChild(xmlElement181);
			XmlElement xmlElement182 = xmlDocument.CreateElement("qVol");
			xmlElement182.InnerText = nf.QuantidadeVolumes.ToString().Replace(',', '.');
			xmlElement181.AppendChild(xmlElement182);
			xmlElement182 = xmlDocument.CreateElement("esp");
			xmlElement182.InnerText = "VOLUMES";
			xmlElement181.AppendChild(xmlElement182);
			xmlElement182 = xmlDocument.CreateElement("pesoL");
			xmlElement182.InnerText = nf.PesoLiquido.ToString("F03").Replace(',', '.');
			xmlElement181.AppendChild(xmlElement182);
			xmlElement182 = xmlDocument.CreateElement("pesoB");
			xmlElement182.InnerText = nf.PesoBruto.ToString("F03").Replace(',', '.');
			xmlElement181.AppendChild(xmlElement182);
		}
		else
		{
			XmlElement xmlElement183 = xmlDocument.CreateElement("transp");
			xmlElement2.AppendChild(xmlElement183);
			XmlElement xmlElement184 = xmlDocument.CreateElement("modFrete");
			xmlElement184.InnerText = "9";
			xmlElement183.AppendChild(xmlElement184);
		}
		if (nf.Fatura != null && nf.Fatura.Count > 0)
		{
			XmlElement xmlElement185 = xmlDocument.CreateElement("cobr");
			xmlElement2.AppendChild(xmlElement185);
			XmlElement xmlElement186 = xmlDocument.CreateElement("fat");
			xmlElement185.AppendChild(xmlElement186);
			XmlElement xmlElement187 = xmlDocument.CreateElement("nFat");
			xmlElement187.InnerText = nf.NumeroNotaFiscal.ToString().Trim();
			xmlElement186.AppendChild(xmlElement187);
			XmlElement xmlElement188 = xmlDocument.CreateElement("vOrig");
			xmlElement188.InnerText = (nf.ValorTotalFatura + nf.ValorDesconto).ToString("F02").Replace(',', '.').Trim();
			xmlElement186.AppendChild(xmlElement188);
			XmlElement xmlElement189 = xmlDocument.CreateElement("vDesc");
			xmlElement189.InnerText = nf.ValorDesconto.ToString("F02").Replace(',', '.').Trim();
			xmlElement186.AppendChild(xmlElement189);
			XmlElement xmlElement190 = xmlDocument.CreateElement("vLiq");
			xmlElement190.InnerText = nf.ValorTotalFatura.ToString("F02").Replace(',', '.').Trim();
			xmlElement186.AppendChild(xmlElement190);
			int num8 = 0;
			foreach (NotaFiscalFatura item in nf.Fatura)
			{
				num8++;
				XmlElement xmlElement191 = xmlDocument.CreateElement("dup");
				xmlElement185.AppendChild(xmlElement191);
				XmlElement xmlElement192 = xmlDocument.CreateElement("nDup");
				xmlElement192.InnerText = num8.ToString("000");
				xmlElement191.AppendChild(xmlElement192);
				XmlElement xmlElement193 = xmlDocument.CreateElement("dVenc");
				xmlElement193.InnerText = item.Vencimento.ToString("yyyy-MM-dd").Trim();
				xmlElement191.AppendChild(xmlElement193);
				XmlElement xmlElement194 = xmlDocument.CreateElement("vDup");
				xmlElement194.InnerText = item.ValorFatura.ToString("F02").Replace(',', '.').Trim();
				xmlElement191.AppendChild(xmlElement194);
			}
		}
		XmlElement xmlElement195 = xmlDocument.CreateElement("pag");
		xmlElement2.AppendChild(xmlElement195);
		XmlElement xmlElement196 = xmlDocument.CreateElement("detPag");
		xmlElement195.AppendChild(xmlElement196);
		if (nf.ValorTotalFatura > 0m)
		{
			XmlElement xmlElement197 = xmlDocument.CreateElement("indPag");
			if (nf.Fatura != null && nf.Fatura.Count > 0 && nf.Fatura[0].Vencimento > DateTime.Today.AddDays(3.0))
			{
				xmlElement197.InnerText = "1";
			}
			else
			{
				xmlElement197.InnerText = "0";
			}
			xmlElement196.AppendChild(xmlElement197);
			XmlElement xmlElement198 = xmlDocument.CreateElement("tPag");
			if (nf.CodigoFormaPagto > 0)
			{
				xmlElement198.InnerText = nf.CodigoFormaPagto.ToString("00");
			}
			else
			{
				xmlElement198.InnerText = "15";
			}
			xmlElement196.AppendChild(xmlElement198);
			XmlElement xmlElement199 = xmlDocument.CreateElement("vPag");
			xmlElement199.InnerText = nf.ValorTotalFatura.ToString("F02").Replace(',', '.').Trim();
			xmlElement196.AppendChild(xmlElement199);
		}
		else
		{
			XmlElement xmlElement200 = xmlDocument.CreateElement("tPag");
			xmlElement200.InnerText = "90";
			xmlElement196.AppendChild(xmlElement200);
			XmlElement xmlElement201 = xmlDocument.CreateElement("vPag");
			xmlElement201.InnerText = nf.ValorTotalFatura.ToString("F02").Replace(',', '.').Trim();
			xmlElement196.AppendChild(xmlElement201);
		}
		if (!string.IsNullOrEmpty(nf.TextoLegal))
		{
			XmlElement xmlElement202 = xmlDocument.CreateElement("infAdic");
			XmlElement xmlElement203 = xmlDocument.CreateElement("infCpl");
			xmlElement202.AppendChild(xmlElement203);
			xmlElement203.InnerText = nf.TextoLegal.Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty)
				.Trim();
			xmlElement2.AppendChild(xmlElement202);
		}
		if (nf.Entidade.PaisRef.CodigoPais != notaFiscalPaises.Codigo && !nf.IsNotaFiscalEntrada)
		{
			XmlElement xmlElement204 = xmlDocument.CreateElement("exporta");
			xmlElement2.AppendChild(xmlElement204);
			XmlElement xmlElement205 = xmlDocument.CreateElement("UFSaidaPais");
			xmlElement205.InnerText = "SP";
			xmlElement204.AppendChild(xmlElement205);
			XmlElement xmlElement206 = xmlDocument.CreateElement("xLocExporta");
			xmlElement206.InnerText = "Porto";
			xmlElement204.AppendChild(xmlElement206);
		}
		if (!Directory.Exists(ConfigNFe.Instancia.DirNFeEmpresa))
		{
			Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeEmpresa);
		}
		string text16 = $"{ConfigNFe.Instancia.DirNFeEmpresa}\\{nf.ChaveNfe}-nfe.xml";
		xmlDocument.Save(text16);
		AssinaturaDigital assinaturaDigital = new AssinaturaDigital();
		assinaturaDigital.Assinar(text16, "infNFe", CarregarCertificado(nf.CodigoEmpresa).oCertificado);
		if (tEmis != TipoEmissao.Normal)
		{
			if (!Directory.Exists(ConfigNFe.Instancia.DirNFeContingencia))
			{
				Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeContingencia);
			}
			File.Copy(text16, $"{ConfigNFe.Instancia.DirNFeContingencia}\\{nf.ChaveNfe}-nfe.xml", overwrite: true);
		}
		ValidarXMLs validarXMLs = new ValidarXMLs();
		validarXMLs.Validar(text16, "nfe_v4.00.xsd", ValidarXMLs.SubFolder400);
		string retornoString = validarXMLs.RetornoString;
		if (!string.IsNullOrEmpty(retornoString))
		{
			MessageBox.Show(retornoString);
			if (tEmis == TipoEmissao.Normal)
			{
				nf.SituacaoNfe = SituacaoNFe.EmErro.ToString();
			}
			else
			{
				nf.SituacaoNfe = SituacaoNFe.EmErroContingencia.ToString();
			}
		}
		return text16;
	}

	internal static void SubstituirTagsTextoLegal(NotaFiscalNotasFiscais nf)
	{
		if (nf == null || string.IsNullOrEmpty(nf.TextoLegal))
		{
			return;
		}
		if (nf.TextoLegal.Contains("[FATURA]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[FATURA]", nf.ValorTotalFatura.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[PORTAO]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[PORTAO]", nf.PortaoEntrega);
		}
		if (nf.TextoLegal.Contains("[CREDITOICMS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[CREDITOICMS]", nf.ValorCreditoIcms.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[PERCENTUALCREDITOICMS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[PERCENTUALCREDITOICMS]", nf.PercentualCreditoIcms.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[TOTALAPROXIMADOIMPOSTOS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[TOTALAPROXIMADOIMPOSTOS]", nf.ValorTotalAproximadoImpostos.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[CODIGOVENDEDOREDI]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[CODIGOVENDEDOREDI]", nf.Entidade.CodigoVendedorEDI);
		}
		if (nf.TextoLegal.Contains("[CODIGOCOMPRADOREDI]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[CODIGOCOMPRADOREDI]", nf.Entidade.CodigoCompradorEDI);
		}
		if (nf.TextoLegal.Contains("[IDENTIFICADORFABRICA]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[IDENTIFICADORFABRICA]", nf.Entidade.CodigoContaDeposito);
		}
		if (nf.TextoLegal.Contains("[NOMECOMPRADOR]"))
		{
			if (nf.FichaExpedicaoRef != null && nf.FichaExpedicaoRef.PedidoVenda != null && !string.IsNullOrWhiteSpace(nf.FichaExpedicaoRef.PedidoVenda.NomeContato))
			{
				nf.TextoLegal = nf.TextoLegal.Replace("[NOMECOMPRADOR]", nf.Entidade.CodigoContaDeposito);
			}
			else
			{
				nf.TextoLegal = nf.TextoLegal.Replace("[NOMECOMPRADOR]", "");
			}
		}
		if (nf.TextoLegal.Contains("[RETENCAOPIS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[RETENCAOPIS]", nf.ValorPISRetido.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[RETENCAOCOFINS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[RETENCAOCOFINS]", nf.ValorCofinsRetido.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[VALORICMS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[VALORICMS]", nf.ValorICMSTotal.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[VALORIPI]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[VALORIPI]", nf.ValorIPI.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[VALORCOFINS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[VALORCOFINS]", nf.ValorCofins.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[VALORPIS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[VALORPIS]", nf.ValorPIS.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[VALORICMSST]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[VALORICMSST]", nf.ValorICMSTotal.ToString("N2"));
		}
		if (nf.TextoLegal.Contains("[SUFRAMA]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[SUFRAMA]", nf.Entidade.CodigoSuframa);
		}
		if (nf.TextoLegal.Contains("[RETENCAOTOTALPISCOFINS]"))
		{
			nf.TextoLegal = nf.TextoLegal.Replace("[RETENCAOTOTALPISCOFINS]", (nf.ValorCofinsRetido + nf.ValorPISRetido).ToString("N2"));
		}
	}

	public static string GerarChaveNFe(NotaFiscalNotasFiscais nf, TipoEmissao tEmis)
	{
		string empty = string.Empty;
		string text = GerarXML2.LimpaNro(nf.SerieNotaFiscal);
		if (string.IsNullOrEmpty(text))
		{
			text = "0";
		}
		int serie = int.Parse(text);
		string text2 = GerarXML2.GerarCNF(serie, nf.NumeroNotaFiscal);
		string uf = ((!string.IsNullOrEmpty(nf.Emitente.Estado)) ? nf.Emitente.Estado.ToUpper() : "SP");
		empty = ModuloNotaFiscal.ObterNotaFiscalUF(uf).Id.ToString("00") + nf.DataEmissao.ToString("yyMM") + GerarXML2.LimpaNro(nf.Emitente.Cnpj) + "55" + serie.ToString("000") + nf.NumeroNotaFiscal.ToString("000000000") + ((tEmis == TipoEmissao.Normal) ? "1" : "2") + text2;
		return empty + GerarDigito(empty).ToString("0");
	}

	public static int GerarDigito(string chave)
	{
		chave = chave.Replace("NFe", "");
		if (chave.Length != 43)
		{
			throw new Exception("Erro na composição da chave para obter o DV (" + chave.Length + ")");
		}
		int num = 0;
		int num2 = -1;
		try
		{
			for (int i = 0; i < 43; i++)
			{
				num += Convert.ToInt32(chave.Substring(i, 1)) * Convert.ToInt32("4329876543298765432987654329876543298765432".Substring(i, 1));
			}
			num2 = 11 - num % 11;
			if (num % 11 < 2)
			{
				num2 = 0;
			}
		}
		catch
		{
			num2 = -1;
		}
		if (num2 == -1)
		{
			throw new Exception("Erro no cálculo do DV");
		}
		return num2;
	}

	internal static XmlNode StringToXmlNode(string strXml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(strXml);
		return xmlDocument.DocumentElement;
	}
}
