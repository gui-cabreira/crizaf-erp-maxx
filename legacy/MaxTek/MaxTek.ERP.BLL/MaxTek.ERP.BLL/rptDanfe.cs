using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.UI;
using MaxTek.Core.Windows.Controls;

namespace MaxTek.ERP.BLL;

public class rptDanfe : XtraReport
{
	private NotaFiscalNotasFiscais _nf = new NotaFiscalNotasFiscais();

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRPanel xrRecebemos;

	private XRLabel xrRecebemosDe;

	private XRLabel xrLabel1;

	private XRShape xrShape2;

	private XRShape xrShape1;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRShape xrShape3;

	private XRLabel xrSerieNFe;

	private XRLabel xrNFeNum;

	private XRLabel xrLabel4;

	private XRLine xrLine1;

	private XRPanel xrPanel1;

	private XRBarCode xrChaveAcesso;

	private XRLabel xrLabel5;

	private XRPanel xrEmissor;

	private XRLabel xrLabel6;

	private XRLabel xrLabel9;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private XRPanel xrPanel2;

	private XRLabel xrES;

	private XRLabel xrSerieNF;

	private XRLabel xrLabel11;

	private XRLabel xrNroNF;

	private XRPageInfo xrPageInfo1;

	private XRLabel xrLabel13;

	private XRLabel xrEnderecoEmitenteBairro;

	private XRLabel xrEnderecoEmitente;

	private XRLabel xrRazaoSocialEmitente;

	private XRLabel xrEmitenteTelefone;

	private XRLabel xrEmitenteEnderecoCidade;

	private XRLabel xrProdDesc;

	private BusinessObjectBindingSource nfItensBindingSource;

	private XRPanel xrPanel3;

	private XRLabel xrLabel10;

	private XRLabel xrChave;

	private XRLabel xrLabel15;

	private XRLine xrLine2;

	private XRLabel xrNatOp;

	private XRLine xrLine3;

	private XRLabel xrProtocolo;

	private XRLabel xrLabel16;

	private XRLabel xrLabel12;

	private XRLabel xrEmitenteIE;

	private XRLabel xrLabel21;

	private XRLabel xrEmitenteCNPJ;

	private XRLabel xrLabel19;

	private XRLabel xrEmitenteInscST;

	private XRLine xrLine7;

	private XRLine xrLine6;

	private XRPanel xrPanel10;

	private XRLine xrLine38;

	private XRLabel xrLabel46;

	private XRLabel xrLabel59;

	private XRLabel xrInfoCpl;

	private XRLabel xrLabel55;

	private XRLabel xrProdCod;

	private XRLabel xrProdNCM;

	private XRLabel xrProdCFOP;

	private XRLabel xrProdST;

	private XRLabel xrProdPU;

	private XRLabel xrProdQt;

	private XRLabel xrProdUN;

	private XRLabel xrProdICMS;

	private XRLabel xrProdBaseICMS;

	private XRLabel xrProdPT;

	private XRLabel xrProdICMSAliq;

	private XRPanel xrPnProdHeader;

	private ReportHeaderBand ReportHeader;

	private XRLabel xrLabel84;

	private XRLabel xrLabel85;

	private XRLabel xrLabel88;

	private XRLabel xrLabel87;

	private XRLabel xrLabel86;

	private XRLabel xrLabel95;

	private XRLabel xrLabel94;

	private XRLabel xrLabel93;

	private XRLabel xrLabel92;

	private XRLabel xrLabel91;

	private XRLabel xrLabel90;

	private XRLabel xrLabel89;

	private XRPanel xrPanel23;

	private XRLabel xrLabel223;

	private XRLabel xrLabel224;

	private XRLabel xrLabel225;

	private XRLabel xrLabel226;

	private XRLabel xrLabel227;

	private XRLabel xrLabel228;

	private XRLabel xrLabel229;

	private XRLabel xrLabel230;

	private XRLabel xrLabel231;

	private XRLabel xrLabel232;

	private XRLabel xrLabel233;

	private XRLabel xrLabel234;

	private XRLabel xrLabel128;

	private XRLabel xrEmitenteIE2;

	private XRPanel xrPanel15;

	private XRLine xrLine40;

	private XRLine xrLine41;

	private XRLabel xrLabel117;

	private XRLabel xrEmitenteCNPJ2;

	private XRLabel xrLabel119;

	private XRLabel xrEmitenteInscST2;

	private XRLine xrLine42;

	private XRLabel xrProtocolo2;

	private XRLabel xrLabel122;

	private XRLabel xrChave2;

	private XRLabel xrLabel124;

	private XRLine xrLine43;

	private XRLabel xrNatOp2;

	private XRLabel xrLabel126;

	private XRLabel xrLabel116;

	private XRPageInfo xrPageInfo2;

	private XRLabel xrSerieNFe2;

	private XRLabel xrLabel114;

	private XRLabel xrNroNF2;

	private XRPanel xrPanel14;

	private XRLabel xrES2;

	private XRLabel xrLabel111;

	private XRLabel xrLabel110;

	private XRLabel xrLabel109;

	private XRLabel xrLabel108;

	private XRPanel xrPanel13;

	private XRLabel xrLabel107;

	private XRBarCode xrChaveAcesso2;

	private XRPanel xrPanel12;

	private XRLabel xrEmitenteTelefone2;

	private XRLabel xrEmitenteEnderecoCidade2;

	private XRLabel xrEnderecoEmitenteBairro2;

	private XRLabel xrEnderecoEmitente2;

	private XRLabel xrRazaoSocialEmitente2;

	private XRLine xrLine39;

	private XRPanel xrPanel11;

	private XRLabel xrLabel83;

	private XRShape xrShape4;

	private XRShape xrShape5;

	private XRLabel xrRecebemosDe2;

	private XRShape xrShape6;

	private XRLabel xrLabel97;

	private XRLabel xrLabel98;

	private XRLabel xrLabel99;

	private XRLabel xrNroNFe2;

	private XRLabel xrSerieNF2;

	private XRPanel xrFirstPageOnly;

	private XRLabel xrLabel18;

	private XRPanel xrPanel4;

	private XRLabel xrLabel41;

	private XRLabel xrDestCidade;

	private XRLabel xrLabel39;

	private XRLabel xrDestEndereco;

	private XRLine xrLine14;

	private XRLabel xrLabel37;

	private XRLabel xrDestUF;

	private XRLabel xrLabel35;

	private XRLabel xrDestFone;

	private XRLine xrLine13;

	private XRLabel xrLabel33;

	private XRLabel xrDestIE;

	private XRLine xrLine12;

	private XRLabel xrLabel31;

	private XRLabel xrDestCEP;

	private XRLine xrLine11;

	private XRLabel xrLabel29;

	private XRLabel xrDestBairro;

	private XRLabel xrLabel27;

	private XRLabel xrDestCNPJ;

	private XRLine xrLine10;

	private XRLabel xrDestRazaoSocial;

	private XRLabel xrLabel20;

	private XRLine xrLine9;

	private XRLine xrLine8;

	private XRPanel xrPanel5;

	private XRLabel xrLabel26;

	private XRLabel xrHrSaida;

	private XRLabel xrLabel24;

	private XRLabel xrDtSaida;

	private XRLabel xrLabel22;

	private XRLabel xrDtEmissao;

	private XRLine xrLine5;

	private XRLine xrLine4;

	private XRLabel xrLabel23;

	private XRPanel xrPanel6;

	private XRLine xrLine22;

	private XRLabel xrValorOutras;

	private XRLabel xrLabel52;

	private XRLabel xrValorDesconto;

	private XRLabel xrLabel25;

	private XRLabel xrLabel51;

	private XRLabel xrValorFrete;

	private XRLabel xrLabel49;

	private XRLabel xrBaseST;

	private XRLine xrLine21;

	private XRLabel xrLabel47;

	private XRLabel xrValorST;

	private XRLabel xrLabel45;

	private XRLabel xrValorIPI;

	private XRLine xrLine20;

	private XRLabel xrTotalNota;

	private XRLabel xrLabel38;

	private XRLabel xrValorICMS;

	private XRLabel xrLabel40;

	private XRLine xrLine19;

	private XRLine xrLine15;

	private XRLine xrLine16;

	private XRLabel xrLabel30;

	private XRLabel xrValorSeguro;

	private XRLine xrLine17;

	private XRLabel xrTotalProd;

	private XRLabel xrLabel36;

	private XRLine xrLine18;

	private XRLabel xrBaseICMS;

	private XRLabel xrLabel43;

	private XRLabel xrLabel32;

	private XRLabel xrLabel42;

	private XRPanel xrPanel9;

	private XRLabel xrDadosFatura;

	private XRPanel xrPanel8;

	private XRLine xrLine37;

	private XRLabel xrTranspMarca;

	private XRLabel xrLabel62;

	private XRLine xrLine36;

	private XRLabel xrTranspEspecie;

	private XRLabel xrLabel50;

	private XRLine xrLine35;

	private XRLabel xrLabel48;

	private XRLabel xrTranspNumeracao;

	private XRLine xrLine27;

	private XRLabel xrTranspPagoPor;

	private XRLabel xrLabel79;

	private XRLabel xrTranspANTT;

	private XRLabel xrLabel75;

	private XRLabel xrLabel74;

	private XRLabel xrTranspUF;

	private XRLabel xrLabel72;

	private XRLine xrLine34;

	private XRLabel xrTranspPlacaUF;

	private XRLabel xrTranspPlaca;

	private XRLine xrLine33;

	private XRLabel xrLabel69;

	private XRLabel xrLabel34;

	private XRLabel xrTranspQt;

	private XRLabel xrLabel44;

	private XRLabel xrTranspEndereco;

	private XRLine xrLine24;

	private XRLabel xrLabel53;

	private XRLabel xrPesoBruto;

	private XRLine xrLine25;

	private XRLabel xrLabel56;

	private XRLabel xrPesoLiquido;

	private XRLabel xrLabel58;

	private XRLabel xrTranspCEP;

	private XRLine xrLine28;

	private XRLabel xrLabel60;

	private XRLabel xrTranspMunicipio;

	private XRLabel xrLabel63;

	private XRLabel xrTranspCNPJ;

	private XRLine xrLine30;

	private XRLabel xrTranspRazaoSocial;

	private XRLabel xrLabel68;

	private XRLine xrLine31;

	private XRLine xrLine32;

	private XRCrossBandBox xrCrossBandBox1;

	private XRCrossBandLine xrCrossBandLine1;

	private XRCrossBandLine xrCrossBandLine2;

	private XRCrossBandLine xrCrossBandLine3;

	private XRCrossBandLine xrCrossBandLine4;

	private XRCrossBandLine xrCrossBandLine5;

	private XRCrossBandLine xrCrossBandLine6;

	private XRCrossBandLine xrCrossBandLine7;

	private XRCrossBandLine xrCrossBandLine8;

	private XRCrossBandLine xrCrossBandLine9;

	private XRCrossBandLine xrCrossBandLine10;

	private XRCrossBandLine xrCrossBandLine11;

	private XRPanel xrPanel7;

	private XRLabel xrValorServico;

	private XRLabel xrLabel54;

	private XRLabel xrBaseISSQN;

	private XRLine xrLine23;

	private XRLabel xrLabel61;

	private XRLine xrLine26;

	private XRLine xrLine29;

	private XRLabel xrValorISSQN;

	private XRLabel xrLabel65;

	private XRLabel xrIM;

	private XRLabel xrLabel67;

	private XRLabel xrLabel28;

	private XRLabel xrLabel17;

	private XRLabel xrLabel14;

	private XRPictureBox xrLogo2;

	private XRPictureBox xrLogo;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	public rptDanfe(NotaFiscalNotasFiscais nf)
		: this()
	{
		_nf = nf;
	}

	private rptDanfe()
	{
		InitializeComponent();
	}

	private void xrLabel46_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = e.PageIndex > 0;
	}

	private void rptDanfe_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)xrChaveAcesso).Text = _nf.ChaveNfe;
		((XRControl)xrChaveAcesso2).Text = ((XRControl)xrChaveAcesso).Text;
		((XRControl)xrNroNF).Text = _nf.NumeroNotaFiscal.ToString("000,000,000");
		((XRControl)xrNroNF2).Text = ((XRControl)xrNroNF).Text;
		((XRControl)xrSerieNF).Text = "SÉRIE " + _nf.SerieNotaFiscal;
		((XRControl)xrNFeNum).Text = ((XRControl)xrNroNF).Text;
		((XRControl)xrNroNFe2).Text = ((XRControl)xrNroNF).Text;
		((XRControl)xrSerieNFe).Text = ((XRControl)xrSerieNF).Text;
		((XRControl)xrSerieNFe2).Text = ((XRControl)xrSerieNFe).Text;
		((XRControl)xrSerieNF2).Text = ((XRControl)xrSerieNF).Text;
		((XRControl)xrES).Text = (_nf.IsNotaFiscalEntrada ? "0" : "1");
		((XRControl)xrNatOp).Text = _nf.DescricaoCFOP;
		((XRControl)xrES2).Text = ((XRControl)xrES).Text;
		((XRControl)xrRecebemosDe).Text = $"RECEBEMOS DE {_nf.Emitente.RazaoSocial.ToUpper()} OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA ABAIXO";
		((XRControl)xrRecebemosDe2).Text = ((XRControl)xrRecebemosDe).Text;
		((XRControl)xrChave).Text = _nf.ChaveNfe.Substring(0, 2) + "." + _nf.ChaveNfe.Substring(2, 2) + "." + _nf.ChaveNfe.Substring(4, 2) + "." + _nf.ChaveNfe.Substring(6, 2) + "." + _nf.ChaveNfe.Substring(8, 3) + "." + _nf.ChaveNfe.Substring(11, 3) + "." + _nf.ChaveNfe.Substring(14, 4) + "/" + _nf.ChaveNfe.Substring(18, 2) + "-" + _nf.ChaveNfe.Substring(20, 2) + "-" + _nf.ChaveNfe.Substring(22, 3) + "." + _nf.ChaveNfe.Substring(25, 3) + "." + _nf.ChaveNfe.Substring(28, 3) + "-" + _nf.ChaveNfe.Substring(31, 3) + "-" + _nf.ChaveNfe.Substring(34, 3) + "." + _nf.ChaveNfe.Substring(37, 3) + "." + _nf.ChaveNfe.Substring(40, 3) + "-" + _nf.ChaveNfe.Substring(43);
		((XRControl)xrChave2).Text = ((XRControl)xrChave).Text;
		if (!string.IsNullOrEmpty(_nf.ProtocoloNfe))
		{
			((XRControl)xrProtocolo).Text = string.Format("{0} - {1}", _nf.ProtocoloNfe, _nf.DataEnvioNFE.ToString("g"));
		}
		else
		{
			((XRControl)xrProtocolo).Text = "DANFE em Contingência";
		}
		((XRControl)xrProtocolo2).Text = ((XRControl)xrProtocolo).Text;
		((XRControl)xrNatOp2).Text = ((XRControl)xrNatOp).Text;
		((XRControl)xrDtEmissao).Text = _nf.DataEmissao.ToString("dd/MM/yyyy");
		((XRControl)xrDtSaida).Text = _nf.DataSaida.ToString("dd/MM/yyyy");
		((XRControl)xrHrSaida).Text = _nf.DataSaida.ToString("HH:mm:ss");
		((XRControl)xrRazaoSocialEmitente).Text = _nf.Emitente.RazaoSocial;
		((XRControl)xrRazaoSocialEmitente2).Text = ((XRControl)xrRazaoSocialEmitente).Text;
		((XRControl)xrEnderecoEmitente).Text = _nf.Emitente.Endereco;
		((XRControl)xrEnderecoEmitente2).Text = ((XRControl)xrEnderecoEmitente).Text;
		((XRControl)xrEnderecoEmitenteBairro).Text = _nf.Emitente.Bairro + " - " + _nf.Emitente.CodigoPostal;
		((XRControl)xrEnderecoEmitenteBairro2).Text = ((XRControl)xrEnderecoEmitenteBairro).Text;
		((XRControl)xrEmitenteEnderecoCidade).Text = _nf.Emitente.Cidade + " / " + _nf.Emitente.Estado.ToUpper();
		((XRControl)xrEmitenteEnderecoCidade2).Text = ((XRControl)xrEmitenteEnderecoCidade).Text;
		((XRControl)xrEmitenteTelefone).Text = _nf.Emitente.Telefone;
		((XRControl)xrEmitenteTelefone2).Text = ((XRControl)xrEmitenteTelefone).Text;
		((XRControl)xrEmitenteCNPJ).Text = _nf.Emitente.Cnpj;
		((XRControl)xrEmitenteCNPJ2).Text = ((XRControl)xrEmitenteCNPJ).Text;
		((XRControl)xrEmitenteIE).Text = _nf.Emitente.InscricaoEstadual;
		((XRControl)xrEmitenteIE2).Text = ((XRControl)xrEmitenteIE).Text;
		((XRControl)xrIM).Text = _nf.Emitente.InscricaoMunicipal;
		((XRControl)xrEmitenteInscST).Text = string.Empty;
		((XRControl)xrEmitenteInscST2).Text = ((XRControl)xrEmitenteInscST).Text;
		xrLogo.Image = _nf.Emitente.Logo;
		xrLogo2.Image = xrLogo.Image;
		((XRControl)xrDestBairro).Text = _nf.Entidade.ComplementoEndereco;
		((XRControl)xrDestCEP).Text = _nf.Entidade.CodigoPostal;
		((XRControl)xrDestCidade).Text = _nf.Entidade.Cidade;
		((XRControl)xrDestCNPJ).Text = _nf.Entidade.CNPJ;
		if (string.IsNullOrEmpty(_nf.Entidade.AuxEnderecoNumero))
		{
			((XRControl)xrDestEndereco).Text = _nf.Entidade.Endereco;
		}
		else
		{
			((XRControl)xrDestEndereco).Text = $"{_nf.Entidade.Endereco},{_nf.Entidade.AuxEnderecoNumero}";
		}
		((XRControl)xrDestFone).Text = _nf.Entidade.Telefone;
		((XRControl)xrDestIE).Text = _nf.Entidade.InscricaoEstadual;
		((XRControl)xrDestRazaoSocial).Text = _nf.Entidade.RazaoSocial;
		((XRControl)xrDestUF).Text = _nf.Entidade.UF.ToUpper();
		((XRControl)xrValorDesconto).Text = (_nf.ValorDesconto + _nf.ValorIcmsDesonerado).ToString("F02");
		((XRControl)xrTotalNota).Text = _nf.ValorTotalNotaFiscal.ToString("F02");
		((XRControl)xrTotalProd).Text = _nf.ValorTotalProdutos.ToString("F02");
		((XRControl)xrBaseICMS).Text = _nf.ValorBaseICMS.ToString("F02");
		((XRControl)xrValorICMS).Text = _nf.ValorICMS.ToString("F02");
		((XRControl)xrBaseST).Text = _nf.ValorBaseICMSSubstituto.ToString("F02");
		((XRControl)xrValorST).Text = _nf.ValorICMSSubstituto.ToString("F02");
		((XRControl)xrValorIPI).Text = _nf.ValorIPI.ToString("F02");
		((XRControl)xrValorFrete).Text = _nf.ValorFrete.ToString("F02");
		((XRControl)xrValorSeguro).Text = _nf.ValorSeguro.ToString("F02");
		((XRControl)xrValorOutras).Text = _nf.ValorOutrasDespesas.ToString("F02");
		((XRControl)xrValorISSQN).Text = "0,00";
		((XRControl)xrValorServico).Text = "0,00";
		((XRControl)xrBaseISSQN).Text = "0,00";
		if (_nf.Transportadora != null)
		{
			((XRControl)xrTranspCNPJ).Text = _nf.Transportadora.CNPJ;
			if (string.IsNullOrEmpty(_nf.Transportadora.AuxEnderecoNumero))
			{
				((XRControl)xrTranspEndereco).Text = _nf.Transportadora.Endereco;
			}
			else
			{
				((XRControl)xrTranspEndereco).Text = $"{_nf.Transportadora.Endereco},{_nf.Transportadora.AuxEnderecoNumero}";
			}
			((XRControl)xrTranspMunicipio).Text = _nf.Transportadora.Cidade;
			((XRControl)xrTranspUF).Text = _nf.Transportadora.UF.ToUpper();
			((XRControl)xrTranspRazaoSocial).Text = _nf.Transportadora.RazaoSocial;
			((XRControl)xrTranspCEP).Text = _nf.Transportadora.CodigoPostal;
			((XRControl)xrTranspPlaca).Text = _nf.PlacaCaminhao;
		}
		else
		{
			((XRControl)xrTranspCNPJ).Text = string.Empty;
			((XRControl)xrTranspEndereco).Text = string.Empty;
			((XRControl)xrTranspMunicipio).Text = string.Empty;
			((XRControl)xrTranspUF).Text = string.Empty;
			((XRControl)xrTranspRazaoSocial).Text = string.Empty;
			((XRControl)xrTranspCEP).Text = string.Empty;
		}
		((XRControl)xrTranspPlaca).Text = _nf.PlacaCaminhao;
		switch (_nf.CodigoModalidadeFrete)
		{
		case 0:
			((XRControl)xrTranspPagoPor).Text = "0 Emitente";
			break;
		case 1:
			((XRControl)xrTranspPagoPor).Text = "1 Dest/Rem";
			break;
		case 2:
			((XRControl)xrTranspPagoPor).Text = "2 Terceiros";
			break;
		case 3:
			((XRControl)xrTranspPagoPor).Text = "3 Frete Proprio";
			break;
		case 4:
			((XRControl)xrTranspPagoPor).Text = "4 Frete Proprio";
			break;
		case 9:
			((XRControl)xrTranspPagoPor).Text = "9 Sem Frete";
			break;
		}
		((XRControl)xrPesoLiquido).Text = _nf.PesoLiquido.ToString("F03");
		((XRControl)xrPesoBruto).Text = _nf.PesoBruto.ToString("F03");
		((XRControl)xrTranspQt).Text = _nf.QuantidadeVolumes.ToString();
		((XRControl)xrTranspEspecie).Text = _nf.TipoVolume;
		((XRControl)xrDadosFatura).Text = string.Empty;
		int num = 0;
		if (_nf.Fatura != null)
		{
			foreach (NotaFiscalFatura item in _nf.Fatura)
			{
				if (num % 3 == 0)
				{
					if (num > 0)
					{
						XRLabel obj = xrDadosFatura;
						((XRControl)obj).Text = ((XRControl)obj).Text + "\n";
					}
				}
				else
				{
					XRLabel obj2 = xrDadosFatura;
					((XRControl)obj2).Text = ((XRControl)obj2).Text + "\t";
				}
				XRLabel val = xrDadosFatura;
				((XRControl)val).Text = ((XRControl)val).Text + item.CodigoFatura + "\t" + item.Vencimento.ToString("dd/MM/yyyy") + "\t" + item.ValorFatura.ToString("C02");
			}
		}
		string text = (string.IsNullOrEmpty(_nf.ProtocoloNfe) ? "DANFE em Contingência - impresso em decorrência de problemas técnicos\r\n" : string.Empty);
		text += _nf.TextoLegal;
		((XRControl)xrInfoCpl).Text = text;
		((XRControl)xrProdCFOP).Text = string.Empty;
		if (_nf.CFOP != null)
		{
			string numeracaoCFOP = _nf.CFOP.NumeracaoCFOP;
			for (int i = 0; i < numeracaoCFOP.Length; i++)
			{
				char c = numeracaoCFOP[i];
				if (char.IsDigit(c))
				{
					XRLabel obj3 = xrProdCFOP;
					((XRControl)obj3).Text = ((XRControl)obj3).Text + c;
				}
			}
		}
		else if (_nf.Itens[0] != null && _nf.Itens[0].CFOPRef != null)
		{
			string numeracaoCFOP2 = _nf.Itens[0].CFOPRef.NumeracaoCFOP;
			for (int j = 0; j < numeracaoCFOP2.Length; j++)
			{
				char c2 = numeracaoCFOP2[j];
				if (char.IsDigit(c2))
				{
					XRLabel obj4 = xrProdCFOP;
					((XRControl)obj4).Text = ((XRControl)obj4).Text + c2;
				}
			}
		}
		nfItensBindingSource.DataSource = _nf.Itens;
		nfItensBindingSource.ResetBindings(metadataChanged: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((XtraReport)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected O, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e7: Expected O, but got Unknown
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected O, but got Unknown
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected O, but got Unknown
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Expected O, but got Unknown
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0629: Expected O, but got Unknown
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Expected O, but got Unknown
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Expected O, but got Unknown
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Expected O, but got Unknown
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Expected O, but got Unknown
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Expected O, but got Unknown
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Expected O, but got Unknown
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c3: Expected O, but got Unknown
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Expected O, but got Unknown
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Expected O, but got Unknown
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Expected O, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Expected O, but got Unknown
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected O, but got Unknown
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Expected O, but got Unknown
		//IL_0753: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Expected O, but got Unknown
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Expected O, but got Unknown
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected O, but got Unknown
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Expected O, but got Unknown
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Expected O, but got Unknown
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Expected O, but got Unknown
		//IL_07ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Expected O, but got Unknown
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Expected O, but got Unknown
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Expected O, but got Unknown
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Expected O, but got Unknown
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Expected O, but got Unknown
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Expected O, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Expected O, but got Unknown
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		//IL_082f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Expected O, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected O, but got Unknown
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Expected O, but got Unknown
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected O, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected O, but got Unknown
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected O, but got Unknown
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Expected O, but got Unknown
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Expected O, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected O, but got Unknown
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Expected O, but got Unknown
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b2: Expected O, but got Unknown
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Expected O, but got Unknown
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Expected O, but got Unknown
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected O, but got Unknown
		//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Expected O, but got Unknown
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e9: Expected O, but got Unknown
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected O, but got Unknown
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ff: Expected O, but got Unknown
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_090a: Expected O, but got Unknown
		//IL_090b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Expected O, but got Unknown
		//IL_0916: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Expected O, but got Unknown
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_092b: Expected O, but got Unknown
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Expected O, but got Unknown
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_094c: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_0958: Unknown result type (might be due to invalid IL or missing references)
		//IL_0962: Expected O, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected O, but got Unknown
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Expected O, but got Unknown
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_0983: Expected O, but got Unknown
		//IL_0984: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected O, but got Unknown
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0999: Expected O, but got Unknown
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a4: Expected O, but got Unknown
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected O, but got Unknown
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected O, but got Unknown
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Expected O, but got Unknown
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Expected O, but got Unknown
		//IL_09d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Expected O, but got Unknown
		//IL_09dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Expected O, but got Unknown
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Expected O, but got Unknown
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fc: Expected O, but got Unknown
		//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Expected O, but got Unknown
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Expected O, but got Unknown
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Expected O, but got Unknown
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Expected O, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected O, but got Unknown
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3e: Expected O, but got Unknown
		//IL_0a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a49: Expected O, but got Unknown
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected O, but got Unknown
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Expected O, but got Unknown
		//IL_0a60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Expected O, but got Unknown
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a75: Expected O, but got Unknown
		//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Expected O, but got Unknown
		//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Expected O, but got Unknown
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Expected O, but got Unknown
		//IL_0a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Expected O, but got Unknown
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected O, but got Unknown
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Expected O, but got Unknown
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Expected O, but got Unknown
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Expected O, but got Unknown
		//IL_0ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Expected O, but got Unknown
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Expected O, but got Unknown
		//IL_0aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Expected O, but got Unknown
		//IL_0afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b04: Expected O, but got Unknown
		//IL_0b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0f: Expected O, but got Unknown
		//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected O, but got Unknown
		//IL_0b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b25: Expected O, but got Unknown
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b30: Expected O, but got Unknown
		//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3b: Expected O, but got Unknown
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Expected O, but got Unknown
		//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b51: Expected O, but got Unknown
		//IL_0b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5c: Expected O, but got Unknown
		//IL_0b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Expected O, but got Unknown
		//IL_0b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b72: Expected O, but got Unknown
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7d: Expected O, but got Unknown
		//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b88: Expected O, but got Unknown
		//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b93: Expected O, but got Unknown
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9e: Expected O, but got Unknown
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba9: Expected O, but got Unknown
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		//IL_0bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Expected O, but got Unknown
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bca: Expected O, but got Unknown
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Expected O, but got Unknown
		//IL_0bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Expected O, but got Unknown
		//IL_0be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0beb: Expected O, but got Unknown
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf6: Expected O, but got Unknown
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c01: Expected O, but got Unknown
		//IL_0c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0c: Expected O, but got Unknown
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c17: Expected O, but got Unknown
		//IL_0c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Expected O, but got Unknown
		//IL_0c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Expected O, but got Unknown
		//IL_0c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c38: Expected O, but got Unknown
		//IL_0c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c43: Expected O, but got Unknown
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Expected O, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Expected O, but got Unknown
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Expected O, but got Unknown
		//IL_0c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Expected O, but got Unknown
		//IL_0c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Expected O, but got Unknown
		//IL_0c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c90: Expected O, but got Unknown
		//IL_0c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9b: Expected O, but got Unknown
		//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Expected O, but got Unknown
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb1: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Expected O, but got Unknown
		//IL_0cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Expected O, but got Unknown
		//IL_0cd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdd: Expected O, but got Unknown
		//IL_0cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Expected O, but got Unknown
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d04: Expected O, but got Unknown
		//IL_0d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0f: Expected O, but got Unknown
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e89: Expected O, but got Unknown
		//IL_0eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb8: Expected O, but got Unknown
		//IL_0fe9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1014: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e7: Expected O, but got Unknown
		//IL_1118: Unknown result type (might be due to invalid IL or missing references)
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_1210: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216: Expected O, but got Unknown
		//IL_1247: Unknown result type (might be due to invalid IL or missing references)
		//IL_1272: Unknown result type (might be due to invalid IL or missing references)
		//IL_133f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1345: Expected O, but got Unknown
		//IL_1376: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_146e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1474: Expected O, but got Unknown
		//IL_14a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Expected O, but got Unknown
		//IL_15cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a9: Expected O, but got Unknown
		//IL_16da: Unknown result type (might be due to invalid IL or missing references)
		//IL_1705: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d3: Expected O, but got Unknown
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_182f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1904: Unknown result type (might be due to invalid IL or missing references)
		//IL_190a: Expected O, but got Unknown
		//IL_193b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Expected O, but got Unknown
		//IL_1a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4c: Expected O, but got Unknown
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_207f: Unknown result type (might be due to invalid IL or missing references)
		//IL_20aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_214f: Unknown result type (might be due to invalid IL or missing references)
		//IL_217a: Unknown result type (might be due to invalid IL or missing references)
		//IL_220d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2238: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2389: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2447: Unknown result type (might be due to invalid IL or missing references)
		//IL_2472: Unknown result type (might be due to invalid IL or missing references)
		//IL_2505: Unknown result type (might be due to invalid IL or missing references)
		//IL_2530: Unknown result type (might be due to invalid IL or missing references)
		//IL_25c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2681: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_273f: Unknown result type (might be due to invalid IL or missing references)
		//IL_276a: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2828: Unknown result type (might be due to invalid IL or missing references)
		//IL_28bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2973: Unknown result type (might be due to invalid IL or missing references)
		//IL_299e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b23: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e19: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3078: Unknown result type (might be due to invalid IL or missing references)
		//IL_30a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3128: Unknown result type (might be due to invalid IL or missing references)
		//IL_3153: Unknown result type (might be due to invalid IL or missing references)
		//IL_31cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3235: Unknown result type (might be due to invalid IL or missing references)
		//IL_3260: Unknown result type (might be due to invalid IL or missing references)
		//IL_32d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_336a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3395: Unknown result type (might be due to invalid IL or missing references)
		//IL_33dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3407: Unknown result type (might be due to invalid IL or missing references)
		//IL_3489: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_354f: Unknown result type (might be due to invalid IL or missing references)
		//IL_357a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3600: Unknown result type (might be due to invalid IL or missing references)
		//IL_362b: Unknown result type (might be due to invalid IL or missing references)
		//IL_36c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_374d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3778: Unknown result type (might be due to invalid IL or missing references)
		//IL_381d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3848: Unknown result type (might be due to invalid IL or missing references)
		//IL_38bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_395b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3986: Unknown result type (might be due to invalid IL or missing references)
		//IL_39fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d88: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d92: Expected O, but got Unknown
		//IL_3da3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f22: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_407b: Unknown result type (might be due to invalid IL or missing references)
		//IL_40a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_413e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4176: Unknown result type (might be due to invalid IL or missing references)
		//IL_41ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_42b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_433e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4369: Unknown result type (might be due to invalid IL or missing references)
		//IL_43e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_446d: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_452a: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_464b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4676: Unknown result type (might be due to invalid IL or missing references)
		//IL_46f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_471d: Unknown result type (might be due to invalid IL or missing references)
		//IL_47a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4857: Unknown result type (might be due to invalid IL or missing references)
		//IL_4882: Unknown result type (might be due to invalid IL or missing references)
		//IL_491a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4945: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ce9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f99: Unknown result type (might be due to invalid IL or missing references)
		//IL_501e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5049: Unknown result type (might be due to invalid IL or missing references)
		//IL_50c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_50f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_5164: Unknown result type (might be due to invalid IL or missing references)
		//IL_518f: Unknown result type (might be due to invalid IL or missing references)
		//IL_520b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5236: Unknown result type (might be due to invalid IL or missing references)
		//IL_52e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_5351: Unknown result type (might be due to invalid IL or missing references)
		//IL_535b: Expected O, but got Unknown
		//IL_5386: Unknown result type (might be due to invalid IL or missing references)
		//IL_540b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5436: Unknown result type (might be due to invalid IL or missing references)
		//IL_54cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_54f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_559f: Unknown result type (might be due to invalid IL or missing references)
		//IL_55d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5631: Unknown result type (might be due to invalid IL or missing references)
		//IL_565c: Unknown result type (might be due to invalid IL or missing references)
		//IL_56a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_56aa: Expected O, but got Unknown
		//IL_5804: Unknown result type (might be due to invalid IL or missing references)
		//IL_582f: Unknown result type (might be due to invalid IL or missing references)
		//IL_590f: Unknown result type (might be due to invalid IL or missing references)
		//IL_598b: Unknown result type (might be due to invalid IL or missing references)
		//IL_59b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_6057: Unknown result type (might be due to invalid IL or missing references)
		//IL_6082: Unknown result type (might be due to invalid IL or missing references)
		//IL_610b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6136: Unknown result type (might be due to invalid IL or missing references)
		//IL_61a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_622e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6259: Unknown result type (might be due to invalid IL or missing references)
		//IL_62e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_630d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6380: Unknown result type (might be due to invalid IL or missing references)
		//IL_6405: Unknown result type (might be due to invalid IL or missing references)
		//IL_6430: Unknown result type (might be due to invalid IL or missing references)
		//IL_64b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_64e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6557: Unknown result type (might be due to invalid IL or missing references)
		//IL_65dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_6607: Unknown result type (might be due to invalid IL or missing references)
		//IL_6690: Unknown result type (might be due to invalid IL or missing references)
		//IL_66bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_6740: Unknown result type (might be due to invalid IL or missing references)
		//IL_676b: Unknown result type (might be due to invalid IL or missing references)
		//IL_67f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_681f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6892: Unknown result type (might be due to invalid IL or missing references)
		//IL_6909: Unknown result type (might be due to invalid IL or missing references)
		//IL_6934: Unknown result type (might be due to invalid IL or missing references)
		//IL_69a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_69d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ce8: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d98: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e14: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_7062: Unknown result type (might be due to invalid IL or missing references)
		//IL_70cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_70f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_72b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_733c: Unknown result type (might be due to invalid IL or missing references)
		//IL_73a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_73d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_7445: Unknown result type (might be due to invalid IL or missing references)
		//IL_7470: Unknown result type (might be due to invalid IL or missing references)
		//IL_74ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_7517: Unknown result type (might be due to invalid IL or missing references)
		//IL_758b: Unknown result type (might be due to invalid IL or missing references)
		//IL_75b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_764d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7678: Unknown result type (might be due to invalid IL or missing references)
		//IL_76f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_771f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7793: Unknown result type (might be due to invalid IL or missing references)
		//IL_77be: Unknown result type (might be due to invalid IL or missing references)
		//IL_783a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7865: Unknown result type (might be due to invalid IL or missing references)
		//IL_78c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_794c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7977: Unknown result type (might be due to invalid IL or missing references)
		//IL_79f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b90: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ecf: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_7fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_803a: Unknown result type (might be due to invalid IL or missing references)
		//IL_80bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_80ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_8166: Unknown result type (might be due to invalid IL or missing references)
		//IL_8191: Unknown result type (might be due to invalid IL or missing references)
		//IL_81f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_825d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8288: Unknown result type (might be due to invalid IL or missing references)
		//IL_830d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8338: Unknown result type (might be due to invalid IL or missing references)
		//IL_83b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_841a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8445: Unknown result type (might be due to invalid IL or missing references)
		//IL_84b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_84e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_8560: Unknown result type (might be due to invalid IL or missing references)
		//IL_858b: Unknown result type (might be due to invalid IL or missing references)
		//IL_85e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_860f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8684: Unknown result type (might be due to invalid IL or missing references)
		//IL_86fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_8733: Unknown result type (might be due to invalid IL or missing references)
		//IL_895d: Unknown result type (might be due to invalid IL or missing references)
		//IL_89c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_8aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_8f1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_8fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_9037: Unknown result type (might be due to invalid IL or missing references)
		//IL_9062: Unknown result type (might be due to invalid IL or missing references)
		//IL_90de: Unknown result type (might be due to invalid IL or missing references)
		//IL_9109: Unknown result type (might be due to invalid IL or missing references)
		//IL_918e: Unknown result type (might be due to invalid IL or missing references)
		//IL_91b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_923e: Unknown result type (might be due to invalid IL or missing references)
		//IL_92a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_92d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_9358: Unknown result type (might be due to invalid IL or missing references)
		//IL_9383: Unknown result type (might be due to invalid IL or missing references)
		//IL_9408: Unknown result type (might be due to invalid IL or missing references)
		//IL_947f: Unknown result type (might be due to invalid IL or missing references)
		//IL_94aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_952f: Unknown result type (might be due to invalid IL or missing references)
		//IL_955a: Unknown result type (might be due to invalid IL or missing references)
		//IL_95e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_960e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9693: Unknown result type (might be due to invalid IL or missing references)
		//IL_96be: Unknown result type (might be due to invalid IL or missing references)
		//IL_9755: Unknown result type (might be due to invalid IL or missing references)
		//IL_9780: Unknown result type (might be due to invalid IL or missing references)
		//IL_9805: Unknown result type (might be due to invalid IL or missing references)
		//IL_986f: Unknown result type (might be due to invalid IL or missing references)
		//IL_989a: Unknown result type (might be due to invalid IL or missing references)
		//IL_98f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_991e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9980: Unknown result type (might be due to invalid IL or missing references)
		//IL_9a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_9a30: Unknown result type (might be due to invalid IL or missing references)
		//IL_9aac: Unknown result type (might be due to invalid IL or missing references)
		//IL_9ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_9cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_9cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_9d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_9d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_9f8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9fba: Unknown result type (might be due to invalid IL or missing references)
		//IL_a02e: Unknown result type (might be due to invalid IL or missing references)
		//IL_a059: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0de: Unknown result type (might be due to invalid IL or missing references)
		//IL_a163: Unknown result type (might be due to invalid IL or missing references)
		//IL_a18e: Unknown result type (might be due to invalid IL or missing references)
		//IL_a20a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a235: Unknown result type (might be due to invalid IL or missing references)
		//IL_a2a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_a32d: Unknown result type (might be due to invalid IL or missing references)
		//IL_a358: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_a461: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_a511: Unknown result type (might be due to invalid IL or missing references)
		//IL_a59a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_a6d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_a74a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a7bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_a842: Unknown result type (might be due to invalid IL or missing references)
		//IL_a86d: Unknown result type (might be due to invalid IL or missing references)
		//IL_a8e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_a914: Unknown result type (might be due to invalid IL or missing references)
		//IL_a999: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa40: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_aade: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab48: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab73: Unknown result type (might be due to invalid IL or missing references)
		//IL_abf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac23: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_acca: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_adf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae69: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae94: Unknown result type (might be due to invalid IL or missing references)
		//IL_af08: Unknown result type (might be due to invalid IL or missing references)
		//IL_af33: Unknown result type (might be due to invalid IL or missing references)
		//IL_afaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_afda: Unknown result type (might be due to invalid IL or missing references)
		//IL_b044: Unknown result type (might be due to invalid IL or missing references)
		//IL_b06f: Unknown result type (might be due to invalid IL or missing references)
		//IL_b103: Unknown result type (might be due to invalid IL or missing references)
		//IL_b12e: Unknown result type (might be due to invalid IL or missing references)
		//IL_b1c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_b1f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_b27a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b2a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_b341: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_b4a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_b4d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_b56a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b595: Unknown result type (might be due to invalid IL or missing references)
		//IL_b62c: Unknown result type (might be due to invalid IL or missing references)
		//IL_b657: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_b71a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b7de: Unknown result type (might be due to invalid IL or missing references)
		//IL_b863: Unknown result type (might be due to invalid IL or missing references)
		//IL_b88e: Unknown result type (might be due to invalid IL or missing references)
		//IL_b917: Unknown result type (might be due to invalid IL or missing references)
		//IL_b944: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba20: Unknown result type (might be due to invalid IL or missing references)
		//IL_baa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_bade: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb75: Unknown result type (might be due to invalid IL or missing references)
		//IL_bba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc37: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc62: Unknown result type (might be due to invalid IL or missing references)
		//IL_bcf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd24: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_bde6: Unknown result type (might be due to invalid IL or missing references)
		//IL_be68: Unknown result type (might be due to invalid IL or missing references)
		//IL_be72: Expected O, but got Unknown
		//IL_be83: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf07: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_c069: Unknown result type (might be due to invalid IL or missing references)
		//IL_c094: Unknown result type (might be due to invalid IL or missing references)
		//IL_c110: Unknown result type (might be due to invalid IL or missing references)
		//IL_c199: Unknown result type (might be due to invalid IL or missing references)
		//IL_c22c: Unknown result type (might be due to invalid IL or missing references)
		//IL_c257: Unknown result type (might be due to invalid IL or missing references)
		//IL_c2e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_c378: Unknown result type (might be due to invalid IL or missing references)
		//IL_c3a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c41f: Unknown result type (might be due to invalid IL or missing references)
		//IL_c44a: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_c584: Unknown result type (might be due to invalid IL or missing references)
		//IL_c5af: Unknown result type (might be due to invalid IL or missing references)
		//IL_c647: Unknown result type (might be due to invalid IL or missing references)
		//IL_c672: Unknown result type (might be due to invalid IL or missing references)
		//IL_c7c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_c85b: Unknown result type (might be due to invalid IL or missing references)
		//IL_c886: Unknown result type (might be due to invalid IL or missing references)
		//IL_c8fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_c929: Unknown result type (might be due to invalid IL or missing references)
		//IL_c98f: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca20: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_cab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_cadc: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb42: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_cbd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_cbfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc64: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ccf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd20: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd86: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce17: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce42: Unknown result type (might be due to invalid IL or missing references)
		//IL_cea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_ced3: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_cfe5: Unknown result type (might be due to invalid IL or missing references)
		//IL_d023: Unknown result type (might be due to invalid IL or missing references)
		//IL_d06e: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_d135: Unknown result type (might be due to invalid IL or missing references)
		//IL_d180: Unknown result type (might be due to invalid IL or missing references)
		//IL_d1be: Unknown result type (might be due to invalid IL or missing references)
		//IL_d209: Unknown result type (might be due to invalid IL or missing references)
		//IL_d247: Unknown result type (might be due to invalid IL or missing references)
		//IL_d292: Unknown result type (might be due to invalid IL or missing references)
		//IL_d2d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_d31b: Unknown result type (might be due to invalid IL or missing references)
		//IL_d359: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_d42d: Unknown result type (might be due to invalid IL or missing references)
		//IL_d46b: Unknown result type (might be due to invalid IL or missing references)
		//IL_d4b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_d4f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_d53f: Unknown result type (might be due to invalid IL or missing references)
		//IL_d57d: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		Code128Generator val = new Code128Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptDanfe));
		ShapeLine shape = new ShapeLine();
		ShapeLine shape2 = new ShapeLine();
		ShapeLine shape3 = new ShapeLine();
		Code128Generator val2 = new Code128Generator();
		ShapeLine shape4 = new ShapeLine();
		ShapeLine shape5 = new ShapeLine();
		ShapeLine shape6 = new ShapeLine();
		Detail = new DetailBand();
		xrProdICMSAliq = new XRLabel();
		xrProdICMS = new XRLabel();
		xrProdBaseICMS = new XRLabel();
		xrProdPT = new XRLabel();
		xrProdPU = new XRLabel();
		xrProdQt = new XRLabel();
		xrProdUN = new XRLabel();
		xrProdCFOP = new XRLabel();
		xrProdST = new XRLabel();
		xrProdCod = new XRLabel();
		xrProdDesc = new XRLabel();
		xrProdNCM = new XRLabel();
		PageHeader = new PageHeaderBand();
		xrLabel17 = new XRLabel();
		xrPnProdHeader = new XRPanel();
		xrLabel94 = new XRLabel();
		xrLabel85 = new XRLabel();
		xrLabel95 = new XRLabel();
		xrLabel93 = new XRLabel();
		xrLabel92 = new XRLabel();
		xrLabel91 = new XRLabel();
		xrLabel90 = new XRLabel();
		xrLabel89 = new XRLabel();
		xrLabel88 = new XRLabel();
		xrLabel87 = new XRLabel();
		xrLabel86 = new XRLabel();
		xrLabel84 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrEmitenteIE = new XRLabel();
		xrPanel3 = new XRPanel();
		xrLine7 = new XRLine();
		xrLine6 = new XRLine();
		xrLabel21 = new XRLabel();
		xrEmitenteCNPJ = new XRLabel();
		xrLabel19 = new XRLabel();
		xrEmitenteInscST = new XRLabel();
		xrLine3 = new XRLine();
		xrProtocolo = new XRLabel();
		xrLabel16 = new XRLabel();
		xrChave = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLine2 = new XRLine();
		xrNatOp = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		xrSerieNF = new XRLabel();
		xrLabel11 = new XRLabel();
		xrNroNF = new XRLabel();
		xrPanel2 = new XRPanel();
		xrES = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrPanel1 = new XRPanel();
		xrLabel5 = new XRLabel();
		xrChaveAcesso = new XRBarCode();
		xrEmissor = new XRPanel();
		xrLogo = new XRPictureBox();
		xrEmitenteTelefone = new XRLabel();
		xrEmitenteEnderecoCidade = new XRLabel();
		xrEnderecoEmitenteBairro = new XRLabel();
		xrEnderecoEmitente = new XRLabel();
		xrRazaoSocialEmitente = new XRLabel();
		xrLine1 = new XRLine();
		xrRecebemos = new XRPanel();
		xrLabel1 = new XRLabel();
		xrShape2 = new XRShape();
		xrShape1 = new XRShape();
		xrRecebemosDe = new XRLabel();
		xrShape3 = new XRShape();
		xrLabel2 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrNFeNum = new XRLabel();
		xrSerieNFe = new XRLabel();
		PageFooter = new PageFooterBand();
		xrPanel7 = new XRPanel();
		xrValorServico = new XRLabel();
		xrLabel54 = new XRLabel();
		xrBaseISSQN = new XRLabel();
		xrLine23 = new XRLine();
		xrLabel61 = new XRLabel();
		xrLine26 = new XRLine();
		xrLine29 = new XRLine();
		xrValorISSQN = new XRLabel();
		xrLabel65 = new XRLabel();
		xrIM = new XRLabel();
		xrLabel67 = new XRLabel();
		xrLabel28 = new XRLabel();
		xrPanel10 = new XRPanel();
		xrLine38 = new XRLine();
		xrLabel55 = new XRLabel();
		xrLabel59 = new XRLabel();
		xrInfoCpl = new XRLabel();
		xrLabel46 = new XRLabel();
		ReportHeader = new ReportHeaderBand();
		xrLabel14 = new XRLabel();
		xrFirstPageOnly = new XRPanel();
		xrLabel18 = new XRLabel();
		xrPanel4 = new XRPanel();
		xrLabel41 = new XRLabel();
		xrDestCidade = new XRLabel();
		xrLabel39 = new XRLabel();
		xrDestEndereco = new XRLabel();
		xrLine14 = new XRLine();
		xrLabel37 = new XRLabel();
		xrDestUF = new XRLabel();
		xrLabel35 = new XRLabel();
		xrDestFone = new XRLabel();
		xrLine13 = new XRLine();
		xrLabel33 = new XRLabel();
		xrDestIE = new XRLabel();
		xrLine12 = new XRLine();
		xrLabel31 = new XRLabel();
		xrDestCEP = new XRLabel();
		xrLine11 = new XRLine();
		xrLabel29 = new XRLabel();
		xrDestBairro = new XRLabel();
		xrLabel27 = new XRLabel();
		xrDestCNPJ = new XRLabel();
		xrLine10 = new XRLine();
		xrDestRazaoSocial = new XRLabel();
		xrLabel20 = new XRLabel();
		xrLine9 = new XRLine();
		xrLine8 = new XRLine();
		xrPanel5 = new XRPanel();
		xrLabel26 = new XRLabel();
		xrHrSaida = new XRLabel();
		xrLabel24 = new XRLabel();
		xrDtSaida = new XRLabel();
		xrLabel22 = new XRLabel();
		xrDtEmissao = new XRLabel();
		xrLine5 = new XRLine();
		xrLine4 = new XRLine();
		xrLabel23 = new XRLabel();
		xrPanel6 = new XRPanel();
		xrLine22 = new XRLine();
		xrValorOutras = new XRLabel();
		xrLabel52 = new XRLabel();
		xrValorDesconto = new XRLabel();
		xrLabel25 = new XRLabel();
		xrLabel51 = new XRLabel();
		xrValorFrete = new XRLabel();
		xrLabel49 = new XRLabel();
		xrBaseST = new XRLabel();
		xrLine21 = new XRLine();
		xrLabel47 = new XRLabel();
		xrValorST = new XRLabel();
		xrLabel45 = new XRLabel();
		xrValorIPI = new XRLabel();
		xrLine20 = new XRLine();
		xrTotalNota = new XRLabel();
		xrLabel38 = new XRLabel();
		xrValorICMS = new XRLabel();
		xrLabel40 = new XRLabel();
		xrLine19 = new XRLine();
		xrLine15 = new XRLine();
		xrLine16 = new XRLine();
		xrLabel30 = new XRLabel();
		xrValorSeguro = new XRLabel();
		xrLine17 = new XRLine();
		xrTotalProd = new XRLabel();
		xrLabel36 = new XRLabel();
		xrLine18 = new XRLine();
		xrBaseICMS = new XRLabel();
		xrLabel43 = new XRLabel();
		xrLabel32 = new XRLabel();
		xrLabel42 = new XRLabel();
		xrPanel9 = new XRPanel();
		xrDadosFatura = new XRLabel();
		xrPanel8 = new XRPanel();
		xrLine32 = new XRLine();
		xrLine31 = new XRLine();
		xrLabel68 = new XRLabel();
		xrTranspRazaoSocial = new XRLabel();
		xrLine30 = new XRLine();
		xrTranspCNPJ = new XRLabel();
		xrLabel63 = new XRLabel();
		xrTranspMunicipio = new XRLabel();
		xrLabel60 = new XRLabel();
		xrLine28 = new XRLine();
		xrTranspCEP = new XRLabel();
		xrLabel58 = new XRLabel();
		xrPesoLiquido = new XRLabel();
		xrLabel56 = new XRLabel();
		xrLine25 = new XRLine();
		xrPesoBruto = new XRLabel();
		xrLabel53 = new XRLabel();
		xrLine24 = new XRLine();
		xrTranspEndereco = new XRLabel();
		xrLabel44 = new XRLabel();
		xrTranspQt = new XRLabel();
		xrLabel34 = new XRLabel();
		xrLabel69 = new XRLabel();
		xrLine33 = new XRLine();
		xrTranspPlaca = new XRLabel();
		xrTranspPlacaUF = new XRLabel();
		xrLine34 = new XRLine();
		xrLabel72 = new XRLabel();
		xrTranspUF = new XRLabel();
		xrLabel74 = new XRLabel();
		xrLabel75 = new XRLabel();
		xrTranspANTT = new XRLabel();
		xrLabel79 = new XRLabel();
		xrTranspPagoPor = new XRLabel();
		xrLine27 = new XRLine();
		xrTranspNumeracao = new XRLabel();
		xrLabel48 = new XRLabel();
		xrLine35 = new XRLine();
		xrLabel50 = new XRLabel();
		xrTranspEspecie = new XRLabel();
		xrLine36 = new XRLine();
		xrLabel62 = new XRLabel();
		xrTranspMarca = new XRLabel();
		xrLine37 = new XRLine();
		xrLabel128 = new XRLabel();
		xrEmitenteIE2 = new XRLabel();
		xrPanel15 = new XRPanel();
		xrLine40 = new XRLine();
		xrLine41 = new XRLine();
		xrLabel117 = new XRLabel();
		xrEmitenteCNPJ2 = new XRLabel();
		xrLabel119 = new XRLabel();
		xrEmitenteInscST2 = new XRLabel();
		xrLine42 = new XRLine();
		xrProtocolo2 = new XRLabel();
		xrLabel122 = new XRLabel();
		xrChave2 = new XRLabel();
		xrLabel124 = new XRLabel();
		xrLine43 = new XRLine();
		xrNatOp2 = new XRLabel();
		xrLabel126 = new XRLabel();
		xrLabel116 = new XRLabel();
		xrPageInfo2 = new XRPageInfo();
		xrSerieNFe2 = new XRLabel();
		xrLabel114 = new XRLabel();
		xrNroNF2 = new XRLabel();
		xrPanel14 = new XRPanel();
		xrES2 = new XRLabel();
		xrLabel111 = new XRLabel();
		xrLabel110 = new XRLabel();
		xrLabel109 = new XRLabel();
		xrLabel108 = new XRLabel();
		xrPanel13 = new XRPanel();
		xrLabel107 = new XRLabel();
		xrChaveAcesso2 = new XRBarCode();
		xrPanel12 = new XRPanel();
		xrRazaoSocialEmitente2 = new XRLabel();
		xrEnderecoEmitente2 = new XRLabel();
		xrEnderecoEmitenteBairro2 = new XRLabel();
		xrEmitenteEnderecoCidade2 = new XRLabel();
		xrEmitenteTelefone2 = new XRLabel();
		xrLogo2 = new XRPictureBox();
		xrLine39 = new XRLine();
		xrPanel11 = new XRPanel();
		xrLabel83 = new XRLabel();
		xrShape4 = new XRShape();
		xrShape5 = new XRShape();
		xrRecebemosDe2 = new XRLabel();
		xrShape6 = new XRShape();
		xrLabel97 = new XRLabel();
		xrLabel98 = new XRLabel();
		xrLabel99 = new XRLabel();
		xrNroNFe2 = new XRLabel();
		xrSerieNF2 = new XRLabel();
		xrPanel23 = new XRPanel();
		xrLabel234 = new XRLabel();
		xrLabel223 = new XRLabel();
		xrLabel224 = new XRLabel();
		xrLabel225 = new XRLabel();
		xrLabel226 = new XRLabel();
		xrLabel227 = new XRLabel();
		xrLabel228 = new XRLabel();
		xrLabel229 = new XRLabel();
		xrLabel230 = new XRLabel();
		xrLabel231 = new XRLabel();
		xrLabel232 = new XRLabel();
		xrLabel233 = new XRLabel();
		xrCrossBandBox1 = new XRCrossBandBox();
		xrCrossBandLine1 = new XRCrossBandLine();
		xrCrossBandLine2 = new XRCrossBandLine();
		xrCrossBandLine3 = new XRCrossBandLine();
		xrCrossBandLine4 = new XRCrossBandLine();
		xrCrossBandLine5 = new XRCrossBandLine();
		xrCrossBandLine6 = new XRCrossBandLine();
		xrCrossBandLine7 = new XRCrossBandLine();
		xrCrossBandLine8 = new XRCrossBandLine();
		xrCrossBandLine9 = new XRCrossBandLine();
		xrCrossBandLine10 = new XRCrossBandLine();
		xrCrossBandLine11 = new XRCrossBandLine();
		nfItensBindingSource = new BusinessObjectBindingSource(components);
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)nfItensBindingSource).BeginInit();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Borders = (BorderSide)15;
		((XRControl)Detail).BorderWidth = 1f;
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[12]
		{
			(XRControl)xrProdICMSAliq,
			(XRControl)xrProdICMS,
			(XRControl)xrProdBaseICMS,
			(XRControl)xrProdPT,
			(XRControl)xrProdPU,
			(XRControl)xrProdQt,
			(XRControl)xrProdUN,
			(XRControl)xrProdCFOP,
			(XRControl)xrProdST,
			(XRControl)xrProdCod,
			(XRControl)xrProdDesc,
			(XRControl)xrProdNCM
		});
		((XRControl)Detail).HeightF = 17f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((XRControl)Detail).StylePriority.UseBorders = false;
		((XRControl)Detail).StylePriority.UseBorderWidth = false;
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)xrProdICMSAliq).Borders = (BorderSide)5;
		((XRControl)xrProdICMSAliq).BorderWidth = 0f;
		((XRControl)xrProdICMSAliq).CanGrow = false;
		((XRControl)xrProdICMSAliq).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "AliquotaICMS", "{0:0%}")
		});
		((XRControl)xrProdICMSAliq).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdICMSAliq).LocationFloat = new PointFloat(692f, 0f);
		((XRControl)xrProdICMSAliq).Name = "xrProdICMSAliq";
		((XRControl)xrProdICMSAliq).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdICMSAliq).SizeF = new SizeF(29f, 17f);
		((XRControl)xrProdICMSAliq).StylePriority.UseBorders = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseFont = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdICMSAliq).Text = "xrProdICMSAliq";
		((XRControl)xrProdICMSAliq).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdICMS).Borders = (BorderSide)1;
		((XRControl)xrProdICMS).BorderWidth = 0f;
		((XRControl)xrProdICMS).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorICMS", "{0:n2}")
		});
		((XRControl)xrProdICMS).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdICMS).LocationFloat = new PointFloat(642f, 0f);
		((XRControl)xrProdICMS).Name = "xrProdICMS";
		((XRControl)xrProdICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdICMS).SizeF = new SizeF(50f, 17f);
		((XRControl)xrProdICMS).StylePriority.UseBorders = false;
		((XRControl)xrProdICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdICMS).StylePriority.UseFont = false;
		((XRControl)xrProdICMS).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdICMS).Text = "xrProdICMS";
		((XRControl)xrProdICMS).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdBaseICMS).Borders = (BorderSide)1;
		((XRControl)xrProdBaseICMS).BorderWidth = 0f;
		((XRControl)xrProdBaseICMS).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorBaseICMS", "{0:n2}")
		});
		((XRControl)xrProdBaseICMS).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdBaseICMS).LocationFloat = new PointFloat(583f, 0f);
		((XRControl)xrProdBaseICMS).Name = "xrProdBaseICMS";
		((XRControl)xrProdBaseICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdBaseICMS).SizeF = new SizeF(60f, 17f);
		((XRControl)xrProdBaseICMS).StylePriority.UseBorders = false;
		((XRControl)xrProdBaseICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdBaseICMS).StylePriority.UseFont = false;
		((XRControl)xrProdBaseICMS).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdBaseICMS).Text = "xrProdBaseICMS";
		((XRControl)xrProdBaseICMS).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdPT).Borders = (BorderSide)1;
		((XRControl)xrProdPT).BorderWidth = 0f;
		((XRControl)xrProdPT).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorTotalComImpostoImportacao", "{0:n2}")
		});
		((XRControl)xrProdPT).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdPT).LocationFloat = new PointFloat(517f, 0f);
		((XRControl)xrProdPT).Name = "xrProdPT";
		((XRControl)xrProdPT).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdPT).SizeF = new SizeF(67f, 17f);
		((XRControl)xrProdPT).StylePriority.UseBorders = false;
		((XRControl)xrProdPT).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdPT).StylePriority.UseFont = false;
		((XRControl)xrProdPT).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdPT).Text = "xrProdPT";
		((XRControl)xrProdPT).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdPU).Borders = (BorderSide)1;
		((XRControl)xrProdPU).BorderWidth = 0f;
		((XRControl)xrProdPU).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorUnitarioComImpostoImportacao", "{0:n4}")
		});
		((XRControl)xrProdPU).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdPU).LocationFloat = new PointFloat(458f, 0f);
		((XRControl)xrProdPU).Name = "xrProdPU";
		((XRControl)xrProdPU).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdPU).SizeF = new SizeF(58f, 17f);
		((XRControl)xrProdPU).StylePriority.UseBorders = false;
		((XRControl)xrProdPU).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdPU).StylePriority.UseFont = false;
		((XRControl)xrProdPU).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdPU).Text = "xrProdPU";
		((XRControl)xrProdPU).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdQt).Borders = (BorderSide)1;
		((XRControl)xrProdQt).BorderWidth = 0f;
		((XRControl)xrProdQt).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Quantidade", "{0:f3}")
		});
		((XRControl)xrProdQt).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdQt).LocationFloat = new PointFloat(392f, 0f);
		((XRControl)xrProdQt).Name = "xrProdQt";
		((XRControl)xrProdQt).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdQt).SizeF = new SizeF(67f, 17f);
		((XRControl)xrProdQt).StylePriority.UseBorders = false;
		((XRControl)xrProdQt).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdQt).StylePriority.UseFont = false;
		((XRControl)xrProdQt).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdQt).Text = "xrProdQt";
		((XRControl)xrProdQt).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdUN).Borders = (BorderSide)1;
		((XRControl)xrProdUN).BorderWidth = 0f;
		((XRControl)xrProdUN).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "SiglaUnidadeFaturamento")
		});
		((XRControl)xrProdUN).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdUN).LocationFloat = new PointFloat(367f, 0f);
		((XRControl)xrProdUN).Name = "xrProdUN";
		((XRControl)xrProdUN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdUN).SizeF = new SizeF(25f, 17f);
		((XRControl)xrProdUN).StylePriority.UseBorders = false;
		((XRControl)xrProdUN).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdUN).StylePriority.UseFont = false;
		((XRControl)xrProdUN).Text = "xrProdUN";
		((XRControl)xrProdCFOP).Borders = (BorderSide)1;
		((XRControl)xrProdCFOP).BorderWidth = 0f;
		((XRControl)xrProdCFOP).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "NomeCfop")
		});
		((XRControl)xrProdCFOP).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdCFOP).LocationFloat = new PointFloat(325f, 0f);
		((XRControl)xrProdCFOP).Name = "xrProdCFOP";
		((XRControl)xrProdCFOP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdCFOP).SizeF = new SizeF(42f, 17f);
		((XRControl)xrProdCFOP).StylePriority.UseBorders = false;
		((XRControl)xrProdCFOP).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdCFOP).StylePriority.UseFont = false;
		((XRControl)xrProdCFOP).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdCFOP).Text = "xrProdCFOP";
		((XRControl)xrProdCFOP).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdST).Borders = (BorderSide)1;
		((XRControl)xrProdST).BorderWidth = 0f;
		((XRControl)xrProdST).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoSituacaoTributaria")
		});
		((XRControl)xrProdST).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdST).LocationFloat = new PointFloat(300f, 0f);
		((XRControl)xrProdST).Name = "xrProdST";
		((XRControl)xrProdST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdST).SizeF = new SizeF(25f, 17f);
		((XRControl)xrProdST).StylePriority.UseBorders = false;
		((XRControl)xrProdST).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdST).StylePriority.UseFont = false;
		((XRControl)xrProdST).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdST).Text = "xrProdST";
		((XRControl)xrProdST).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdCod).Borders = (BorderSide)1;
		((XRControl)xrProdCod).BorderWidth = 0f;
		((XRControl)xrProdCod).CanGrow = false;
		((XRControl)xrProdCod).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoProduto")
		});
		((XRControl)xrProdCod).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdCod).LocationFloat = new PointFloat(1f, 0f);
		((XRControl)xrProdCod).Name = "xrProdCod";
		((XRControl)xrProdCod).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdCod).SizeF = new SizeF(49f, 17f);
		((XRControl)xrProdCod).StylePriority.UseBorders = false;
		((XRControl)xrProdCod).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdCod).StylePriority.UseFont = false;
		((XRControl)xrProdCod).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdCod).Text = "xrProdCod";
		((XRControl)xrProdCod).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdDesc).Borders = (BorderSide)1;
		((XRControl)xrProdDesc).BorderWidth = 0f;
		((XRControl)xrProdDesc).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "DescricaoProduto")
		});
		((XRControl)xrProdDesc).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdDesc).LocationFloat = new PointFloat(50f, 0f);
		xrProdDesc.Multiline = true;
		((XRControl)xrProdDesc).Name = "xrProdDesc";
		((XRControl)xrProdDesc).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdDesc).SizeF = new SizeF(192f, 17f);
		((XRControl)xrProdDesc).StylePriority.UseBorders = false;
		((XRControl)xrProdDesc).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdDesc).StylePriority.UseFont = false;
		((XRControl)xrProdDesc).Text = "xrProdDesc";
		((XRControl)xrProdNCM).Borders = (BorderSide)1;
		((XRControl)xrProdNCM).BorderWidth = 0f;
		((XRControl)xrProdNCM).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoClassificacaoFiscal")
		});
		((XRControl)xrProdNCM).Font = new Font("Times New Roman", 8f);
		((XRControl)xrProdNCM).LocationFloat = new PointFloat(242f, 0f);
		((XRControl)xrProdNCM).Name = "xrProdNCM";
		((XRControl)xrProdNCM).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdNCM).SizeF = new SizeF(60f, 17f);
		((XRControl)xrProdNCM).StylePriority.UseBorders = false;
		((XRControl)xrProdNCM).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdNCM).StylePriority.UseFont = false;
		((XRControl)xrProdNCM).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdNCM).Text = "00000000";
		((XRControl)xrProdNCM).TextAlignment = (TextAlignment)4;
		((XRControl)PageHeader).Borders = (BorderSide)15;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[19]
		{
			(XRControl)xrLabel17,
			(XRControl)xrPnProdHeader,
			(XRControl)xrLabel12,
			(XRControl)xrEmitenteIE,
			(XRControl)xrPanel3,
			(XRControl)xrLabel13,
			(XRControl)xrPageInfo1,
			(XRControl)xrSerieNF,
			(XRControl)xrLabel11,
			(XRControl)xrNroNF,
			(XRControl)xrPanel2,
			(XRControl)xrLabel9,
			(XRControl)xrLabel8,
			(XRControl)xrLabel7,
			(XRControl)xrLabel6,
			(XRControl)xrPanel1,
			(XRControl)xrEmissor,
			(XRControl)xrLine1,
			(XRControl)xrRecebemos
		});
		((Band)PageHeader).Expanded = false;
		((XRControl)PageHeader).HeightF = 333f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((PageBand)PageHeader).PrintOn = (PrintOnPages)6;
		((XRControl)PageHeader).StylePriority.UseBorders = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel17).Borders = (BorderSide)0;
		((XRControl)xrLabel17).LocationFloat = new PointFloat(0f, 292f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel17).SizeF = new SizeF(183f, 22f);
		((XRControl)xrLabel17).StylePriority.UseBorders = false;
		((XRControl)xrLabel17).Text = "DADOS DOS PRODUTOS";
		((XRControl)xrPnProdHeader).BackColor = Color.LightGray;
		((XRControl)xrPnProdHeader).Borders = (BorderSide)8;
		((XRControl)xrPnProdHeader).BorderWidth = 1f;
		((XRControl)xrPnProdHeader).CanGrow = false;
		((XRControl)xrPnProdHeader).Controls.AddRange((XRControl[])(object)new XRControl[12]
		{
			(XRControl)xrLabel94,
			(XRControl)xrLabel85,
			(XRControl)xrLabel95,
			(XRControl)xrLabel93,
			(XRControl)xrLabel92,
			(XRControl)xrLabel91,
			(XRControl)xrLabel90,
			(XRControl)xrLabel89,
			(XRControl)xrLabel88,
			(XRControl)xrLabel87,
			(XRControl)xrLabel86,
			(XRControl)xrLabel84
		});
		((XRControl)xrPnProdHeader).LocationFloat = new PointFloat(0f, 308f);
		((XRControl)xrPnProdHeader).Name = "xrPnProdHeader";
		((XRControl)xrPnProdHeader).SizeF = new SizeF(725f, 25f);
		((XRControl)xrPnProdHeader).StylePriority.UseBackColor = false;
		((XRControl)xrPnProdHeader).StylePriority.UseBorders = false;
		((XRControl)xrPnProdHeader).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel94).Borders = (BorderSide)0;
		((XRControl)xrLabel94).BorderWidth = 0f;
		((XRControl)xrLabel94).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel94).LocationFloat = new PointFloat(642f, 0f);
		((XRControl)xrLabel94).Name = "xrLabel94";
		((XRControl)xrLabel94).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel94).SizeF = new SizeF(45f, 25f);
		((XRControl)xrLabel94).StylePriority.UseBorders = false;
		((XRControl)xrLabel94).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel94).StylePriority.UseFont = false;
		((XRControl)xrLabel94).Text = "ICMS";
		((XRControl)xrLabel85).Borders = (BorderSide)1;
		((XRControl)xrLabel85).BorderWidth = 0f;
		((XRControl)xrLabel85).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel85).LocationFloat = new PointFloat(49f, 0f);
		((XRControl)xrLabel85).Name = "xrLabel85";
		((XRControl)xrLabel85).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel85).SizeF = new SizeF(193f, 25f);
		((XRControl)xrLabel85).StylePriority.UseBorders = false;
		((XRControl)xrLabel85).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel85).StylePriority.UseFont = false;
		((XRControl)xrLabel85).Text = "Produto";
		((XRControl)xrLabel95).Borders = (BorderSide)0;
		((XRControl)xrLabel95).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel95).LocationFloat = new PointFloat(692f, 0f);
		((XRControl)xrLabel95).Name = "xrLabel95";
		((XRControl)xrLabel95).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel95).SizeF = new SizeF(33f, 25f);
		((XRControl)xrLabel95).StylePriority.UseBorders = false;
		((XRControl)xrLabel95).StylePriority.UseFont = false;
		((XRControl)xrLabel95).Text = "Aliq.";
		((XRControl)xrLabel93).Borders = (BorderSide)0;
		((XRControl)xrLabel93).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel93).LocationFloat = new PointFloat(583f, 0f);
		((XRControl)xrLabel93).Name = "xrLabel93";
		((XRControl)xrLabel93).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel93).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel93).StylePriority.UseBorders = false;
		((XRControl)xrLabel93).StylePriority.UseFont = false;
		((XRControl)xrLabel93).Text = "B ICMS";
		((XRControl)xrLabel92).Borders = (BorderSide)0;
		((XRControl)xrLabel92).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel92).LocationFloat = new PointFloat(517f, 0f);
		((XRControl)xrLabel92).Name = "xrLabel92";
		((XRControl)xrLabel92).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel92).SizeF = new SizeF(67f, 25f);
		((XRControl)xrLabel92).StylePriority.UseBorders = false;
		((XRControl)xrLabel92).StylePriority.UseFont = false;
		((XRControl)xrLabel92).Text = "V. Total";
		((XRControl)xrLabel91).Borders = (BorderSide)0;
		((XRControl)xrLabel91).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel91).LocationFloat = new PointFloat(458f, 0f);
		((XRControl)xrLabel91).Name = "xrLabel91";
		((XRControl)xrLabel91).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel91).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel91).StylePriority.UseBorders = false;
		((XRControl)xrLabel91).StylePriority.UseFont = false;
		((XRControl)xrLabel91).Text = "V.Unit.";
		((XRControl)xrLabel90).Borders = (BorderSide)0;
		((XRControl)xrLabel90).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel90).LocationFloat = new PointFloat(392f, 0f);
		((XRControl)xrLabel90).Name = "xrLabel90";
		((XRControl)xrLabel90).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel90).SizeF = new SizeF(67f, 25f);
		((XRControl)xrLabel90).StylePriority.UseBorders = false;
		((XRControl)xrLabel90).StylePriority.UseFont = false;
		((XRControl)xrLabel90).Text = "Quant.";
		((XRControl)xrLabel89).Borders = (BorderSide)0;
		((XRControl)xrLabel89).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel89).LocationFloat = new PointFloat(367f, 0f);
		((XRControl)xrLabel89).Name = "xrLabel89";
		((XRControl)xrLabel89).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel89).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel89).StylePriority.UseBorders = false;
		((XRControl)xrLabel89).StylePriority.UseFont = false;
		((XRControl)xrLabel89).Text = "UN";
		((XRControl)xrLabel88).Borders = (BorderSide)0;
		((XRControl)xrLabel88).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel88).LocationFloat = new PointFloat(325f, 0f);
		((XRControl)xrLabel88).Name = "xrLabel88";
		((XRControl)xrLabel88).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel88).SizeF = new SizeF(42f, 25f);
		((XRControl)xrLabel88).StylePriority.UseBorders = false;
		((XRControl)xrLabel88).StylePriority.UseFont = false;
		((XRControl)xrLabel88).Text = "CFOP";
		((XRControl)xrLabel87).Borders = (BorderSide)0;
		((XRControl)xrLabel87).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel87).LocationFloat = new PointFloat(300f, 0f);
		((XRControl)xrLabel87).Name = "xrLabel87";
		((XRControl)xrLabel87).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel87).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel87).StylePriority.UseBorders = false;
		((XRControl)xrLabel87).StylePriority.UseFont = false;
		((XRControl)xrLabel87).Text = "ST";
		((XRControl)xrLabel86).Borders = (BorderSide)0;
		((XRControl)xrLabel86).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel86).LocationFloat = new PointFloat(242f, 0f);
		((XRControl)xrLabel86).Name = "xrLabel86";
		((XRControl)xrLabel86).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel86).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel86).StylePriority.UseBorders = false;
		((XRControl)xrLabel86).StylePriority.UseFont = false;
		((XRControl)xrLabel86).Text = "NCM";
		((XRControl)xrLabel84).Borders = (BorderSide)0;
		((XRControl)xrLabel84).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel84).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel84).Name = "xrLabel84";
		((XRControl)xrLabel84).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel84).SizeF = new SizeF(49f, 25f);
		((XRControl)xrLabel84).StylePriority.UseBorders = false;
		((XRControl)xrLabel84).StylePriority.UseFont = false;
		((XRControl)xrLabel84).Text = "Código";
		((XRControl)xrLabel12).BorderWidth = 0f;
		((XRControl)xrLabel12).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(8f, 249f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel12).SizeF = new SizeF(119f, 17f);
		((XRControl)xrLabel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrEmitenteIE).BorderWidth = 0f;
		((XRControl)xrEmitenteIE).CanGrow = false;
		((XRControl)xrEmitenteIE).LocationFloat = new PointFloat(8f, 266f);
		((XRControl)xrEmitenteIE).Name = "xrEmitenteIE";
		((XRControl)xrEmitenteIE).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteIE).SizeF = new SizeF(110f, 17f);
		((XRControl)xrEmitenteIE).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteIE).Text = "244.669.501.115";
		((XRControl)xrPanel3).BorderWidth = 1f;
		((XRControl)xrPanel3).CanGrow = false;
		((XRControl)xrPanel3).Controls.AddRange((XRControl[])(object)new XRControl[14]
		{
			(XRControl)xrLine7,
			(XRControl)xrLine6,
			(XRControl)xrLabel21,
			(XRControl)xrEmitenteCNPJ,
			(XRControl)xrLabel19,
			(XRControl)xrEmitenteInscST,
			(XRControl)xrLine3,
			(XRControl)xrProtocolo,
			(XRControl)xrLabel16,
			(XRControl)xrChave,
			(XRControl)xrLabel15,
			(XRControl)xrLine2,
			(XRControl)xrNatOp,
			(XRControl)xrLabel10
		});
		((XRControl)xrPanel3).LocationFloat = new PointFloat(1f, 208f);
		((XRControl)xrPanel3).Name = "xrPanel3";
		((XRControl)xrPanel3).SizeF = new SizeF(724f, 75f);
		((XRControl)xrPanel3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine7).Borders = (BorderSide)0;
		xrLine7.LineDirection = (LineDirection)3;
		((XRControl)xrLine7).LocationFloat = new PointFloat(124f, 36f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(8f, 40f);
		((XRControl)xrLine7).StylePriority.UseBorders = false;
		((XRControl)xrLine6).Borders = (BorderSide)0;
		xrLine6.LineDirection = (LineDirection)3;
		((XRControl)xrLine6).LocationFloat = new PointFloat(232f, 33f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).SizeF = new SizeF(8f, 40f);
		((XRControl)xrLine6).StylePriority.UseBorders = false;
		((XRControl)xrLabel21).BorderWidth = 0f;
		((XRControl)xrLabel21).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(241f, 42f);
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel21).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel21).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).Text = "CNPJ";
		((XRControl)xrEmitenteCNPJ).BorderWidth = 0f;
		((XRControl)xrEmitenteCNPJ).LocationFloat = new PointFloat(241f, 58f);
		((XRControl)xrEmitenteCNPJ).Name = "xrEmitenteCNPJ";
		((XRControl)xrEmitenteCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteCNPJ).SizeF = new SizeF(117f, 17f);
		((XRControl)xrEmitenteCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrLabel19).BorderWidth = 0f;
		((XRControl)xrLabel19).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(132f, 43f);
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel19).SizeF = new SizeF(92f, 17f);
		((XRControl)xrLabel19).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).Text = "INSC. SUBST. TRIB.";
		((XRControl)xrEmitenteInscST).BorderWidth = 0f;
		((XRControl)xrEmitenteInscST).LocationFloat = new PointFloat(132f, 56f);
		((XRControl)xrEmitenteInscST).Name = "xrEmitenteInscST";
		((XRControl)xrEmitenteInscST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteInscST).SizeF = new SizeF(100f, 17f);
		((XRControl)xrEmitenteInscST).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteInscST).Text = "244.669.501.115";
		((XRControl)xrLine3).Borders = (BorderSide)0;
		xrLine3.LineDirection = (LineDirection)3;
		((XRControl)xrLine3).LocationFloat = new PointFloat(357f, 0f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(9f, 75f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrProtocolo).BorderWidth = 0f;
		((XRControl)xrProtocolo).LocationFloat = new PointFloat(366f, 17f);
		((XRControl)xrProtocolo).Name = "xrProtocolo";
		((XRControl)xrProtocolo).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProtocolo).SizeF = new SizeF(331f, 17.00002f);
		((XRControl)xrProtocolo).StylePriority.UseBorderWidth = false;
		((XRControl)xrProtocolo).Text = "xrNatOp";
		((XRControl)xrLabel16).BorderWidth = 0f;
		((XRControl)xrLabel16).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel16).LocationFloat = new PointFloat(366f, 0f);
		((XRControl)xrLabel16).Name = "xrLabel16";
		((XRControl)xrLabel16).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel16).SizeF = new SizeF(208f, 17f);
		((XRControl)xrLabel16).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel16).StylePriority.UseFont = false;
		((XRControl)xrLabel16).Text = "PROTOCOLO DE AUTORIZAÇÃO";
		((XRControl)xrChave).BorderWidth = 0f;
		((XRControl)xrChave).LocationFloat = new PointFloat(366f, 58f);
		((XRControl)xrChave).Name = "xrChave";
		((XRControl)xrChave).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrChave).SizeF = new SizeF(350f, 17f);
		((XRControl)xrChave).StylePriority.UseBorderWidth = false;
		((XRControl)xrChave).Text = "xrNatOp";
		((XRControl)xrLabel15).BorderWidth = 0f;
		((XRControl)xrLabel15).Font = new Font("Times New Roman", 5f);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(366f, 42f);
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel15).SizeF = new SizeF(333f, 17f);
		((XRControl)xrLabel15).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).Text = "CHAVE DE ACESSO DA NF-  CONSULTA DE AUTENTICIDADE NO SITE WWW.NFE.FAZENDA.GOV.BR";
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(723f, 9f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrNatOp).BorderWidth = 0f;
		((XRControl)xrNatOp).LocationFloat = new PointFloat(5f, 18f);
		((XRControl)xrNatOp).Name = "xrNatOp";
		((XRControl)xrNatOp).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNatOp).SizeF = new SizeF(352f, 17f);
		((XRControl)xrNatOp).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel10).BorderWidth = 0f;
		((XRControl)xrLabel10).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(5f, 5f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel10).SizeF = new SizeF(192f, 17f);
		((XRControl)xrLabel10).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).Text = "NATUREZA DA OPERAÇÃO";
		((XRControl)xrLabel13).LocationFloat = new PointFloat(233f, 183f);
		((XRControl)xrLabel13).Name = "xrLabel13";
		((XRControl)xrLabel13).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel13).SizeF = new SizeF(33f, 25f);
		((XRControl)xrLabel13).Text = "FLS:";
		((XRControl)xrPageInfo1).LocationFloat = new PointFloat(258f, 183f);
		((XRControl)xrPageInfo1).Name = "xrPageInfo1";
		((XRControl)xrPageInfo1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPageInfo1).SizeF = new SizeF(42f, 25f);
		((XRControl)xrPageInfo1).StylePriority.UseTextAlignment = false;
		((XRControl)xrPageInfo1).TextAlignment = (TextAlignment)4;
		((XRControl)xrSerieNF).BorderWidth = 0f;
		((XRControl)xrSerieNF).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrSerieNF).LocationFloat = new PointFloat(225f, 167f);
		((XRControl)xrSerieNF).Name = "xrSerieNF";
		((XRControl)xrSerieNF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNF).SizeF = new SizeF(92f, 17f);
		((XRControl)xrSerieNF).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNF).StylePriority.UseFont = false;
		((XRControl)xrSerieNF).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNF).Text = "SÉRIE 1";
		((XRControl)xrSerieNF).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel11).BorderWidth = 0f;
		((XRControl)xrLabel11).LocationFloat = new PointFloat(225f, 150f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel11).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel11).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel11).Text = "N.";
		((XRControl)xrNroNF).BorderWidth = 0f;
		((XRControl)xrNroNF).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrNroNF).LocationFloat = new PointFloat(242f, 150f);
		((XRControl)xrNroNF).Name = "xrNroNF";
		((XRControl)xrNroNF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNF).SizeF = new SizeF(77f, 17f);
		((XRControl)xrNroNF).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNF).StylePriority.UseFont = false;
		((XRControl)xrNroNF).Text = "000.000.000";
		((XRControl)xrPanel2).BorderWidth = 1f;
		((XRControl)xrPanel2).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrES });
		((XRControl)xrPanel2).LocationFloat = new PointFloat(283f, 117f);
		((XRControl)xrPanel2).Name = "xrPanel2";
		((XRControl)xrPanel2).SizeF = new SizeF(25f, 29f);
		((XRControl)xrPanel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrES).BorderWidth = 0f;
		((XRControl)xrES).Font = new Font("Times New Roman", 12f, FontStyle.Bold);
		((XRControl)xrES).LocationFloat = new PointFloat(0f, 3f);
		((XRControl)xrES).Name = "xrES";
		((XRControl)xrES).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrES).SizeF = new SizeF(25f, 25f);
		((XRControl)xrES).StylePriority.UseBorderWidth = false;
		((XRControl)xrES).StylePriority.UseFont = false;
		((XRControl)xrES).StylePriority.UseTextAlignment = false;
		((XRControl)xrES).Text = "1";
		((XRControl)xrES).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel9).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(208f, 133f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel9).SizeF = new SizeF(65f, 17f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "1 - Saída";
		((XRControl)xrLabel8).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(208f, 117f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel8).SizeF = new SizeF(65f, 17f);
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).Text = "0 - Entrada";
		((XRControl)xrLabel7).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(208f, 92f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel7).SizeF = new SizeF(117f, 33f);
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).Text = "Documento Auxiliar de Nota Fiscal Eletrônica";
		((XRControl)xrLabel6).Font = new Font("Times New Roman", 12f, FontStyle.Bold);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(208f, 75f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel6).SizeF = new SizeF(113f, 25f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "DANFE";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)2;
		((XRControl)xrPanel1).BorderWidth = 1f;
		((XRControl)xrPanel1).Controls.AddRange((XRControl[])(object)new XRControl[2]
		{
			(XRControl)xrLabel5,
			(XRControl)xrChaveAcesso
		});
		((XRControl)xrPanel1).LocationFloat = new PointFloat(325f, 83f);
		((XRControl)xrPanel1).Name = "xrPanel1";
		((XRControl)xrPanel1).SizeF = new SizeF(400f, 120f);
		((XRControl)xrPanel1).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel5).BorderWidth = 0f;
		((XRControl)xrLabel5).Font = new Font("Times New Roman", 6f);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(1f, 3f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel5).SizeF = new SizeF(92f, 25f);
		((XRControl)xrLabel5).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).Text = "CONTROLE DO FISCO";
		xrChaveAcesso.AutoModule = true;
		((XRControl)xrChaveAcesso).BorderWidth = 0f;
		((XRControl)xrChaveAcesso).LocationFloat = new PointFloat(34f, 21f);
		((XRControl)xrChaveAcesso).Name = "xrChaveAcesso";
		((XRControl)xrChaveAcesso).Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrChaveAcesso.ShowText = false;
		((XRControl)xrChaveAcesso).SizeF = new SizeF(344f, 80f);
		((XRControl)xrChaveAcesso).StylePriority.UseBorderWidth = false;
		val.CharacterSet = (Code128Charset)105;
		xrChaveAcesso.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)xrChaveAcesso).Text = "0115550010000000180405822968";
		((XRControl)xrEmissor).BorderWidth = 1f;
		((XRControl)xrEmissor).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrLogo,
			(XRControl)xrEmitenteTelefone,
			(XRControl)xrEmitenteEnderecoCidade,
			(XRControl)xrEnderecoEmitenteBairro,
			(XRControl)xrEnderecoEmitente,
			(XRControl)xrRazaoSocialEmitente
		});
		((XRControl)xrEmissor).LocationFloat = new PointFloat(1f, 80f);
		((XRControl)xrEmissor).Name = "xrEmissor";
		((XRControl)xrEmissor).SizeF = new SizeF(199f, 120f);
		((XRControl)xrEmissor).StylePriority.UseBorderWidth = false;
		((XRControl)xrLogo).BorderWidth = 0f;
		xrLogo.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrLogo.ImageSource"));
		((XRControl)xrLogo).LocationFloat = new PointFloat(4f, 3f);
		((XRControl)xrLogo).Name = "xrLogo";
		((XRControl)xrLogo).SizeF = new SizeF(112f, 50f);
		xrLogo.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone).BorderWidth = 0f;
		((XRControl)xrEmitenteTelefone).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteTelefone).LocationFloat = new PointFloat(5f, 102f);
		((XRControl)xrEmitenteTelefone).Name = "xrEmitenteTelefone";
		((XRControl)xrEmitenteTelefone).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteTelefone).SizeF = new SizeF(100f, 12f);
		((XRControl)xrEmitenteTelefone).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone).StylePriority.UseFont = false;
		((XRControl)xrEmitenteTelefone).Text = "(11) 4067-1130";
		((XRControl)xrEmitenteEnderecoCidade).BorderWidth = 0f;
		((XRControl)xrEmitenteEnderecoCidade).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteEnderecoCidade).LocationFloat = new PointFloat(5f, 92f);
		((XRControl)xrEmitenteEnderecoCidade).Name = "xrEmitenteEnderecoCidade";
		((XRControl)xrEmitenteEnderecoCidade).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteEnderecoCidade).SizeF = new SizeF(183f, 12f);
		((XRControl)xrEmitenteEnderecoCidade).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteEnderecoCidade).StylePriority.UseFont = false;
		((XRControl)xrEmitenteEnderecoCidade).Text = "Diadema - SP";
		((XRControl)xrEnderecoEmitenteBairro).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitenteBairro).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitenteBairro).LocationFloat = new PointFloat(5f, 82f);
		((XRControl)xrEnderecoEmitenteBairro).Name = "xrEnderecoEmitenteBairro";
		((XRControl)xrEnderecoEmitenteBairro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitenteBairro).SizeF = new SizeF(183f, 12f);
		((XRControl)xrEnderecoEmitenteBairro).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitenteBairro).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitenteBairro).Text = "Jardim Ruyce - CEP 09961-550";
		((XRControl)xrEnderecoEmitente).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitente).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitente).LocationFloat = new PointFloat(5f, 69f);
		((XRControl)xrEnderecoEmitente).Name = "xrEnderecoEmitente";
		((XRControl)xrEnderecoEmitente).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitente).SizeF = new SizeF(192f, 12f);
		((XRControl)xrEnderecoEmitente).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitente).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitente).Text = "Avenida Ferraz Alvim, 622";
		((XRControl)xrRazaoSocialEmitente).BorderWidth = 0f;
		((XRControl)xrRazaoSocialEmitente).Font = new Font("Times New Roman", 9f, FontStyle.Bold);
		((XRControl)xrRazaoSocialEmitente).LocationFloat = new PointFloat(5f, 56f);
		xrRazaoSocialEmitente.Multiline = true;
		((XRControl)xrRazaoSocialEmitente).Name = "xrRazaoSocialEmitente";
		((XRControl)xrRazaoSocialEmitente).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrRazaoSocialEmitente).SizeF = new SizeF(192f, 12f);
		((XRControl)xrRazaoSocialEmitente).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente).StylePriority.UseFont = false;
		((XRControl)xrRazaoSocialEmitente).Text = "R.Castro Cia Ltda.";
		xrLine1.LineStyle = DashStyle.Dash;
		((XRControl)xrLine1).LocationFloat = new PointFloat(0f, 70f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(722f, 8f);
		((XRControl)xrRecebemos).BorderWidth = 1f;
		((XRControl)xrRecebemos).Controls.AddRange((XRControl[])(object)new XRControl[10]
		{
			(XRControl)xrLabel1,
			(XRControl)xrShape2,
			(XRControl)xrShape1,
			(XRControl)xrRecebemosDe,
			(XRControl)xrShape3,
			(XRControl)xrLabel2,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrNFeNum,
			(XRControl)xrSerieNFe
		});
		((XRControl)xrRecebemos).LocationFloat = new PointFloat(1f, 1f);
		((XRControl)xrRecebemos).Name = "xrRecebemos";
		((XRControl)xrRecebemos).SizeF = new SizeF(724f, 67f);
		((XRControl)xrRecebemos).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel1).BorderWidth = 0f;
		((XRControl)xrLabel1).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(4f, 32f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel1).SizeF = new SizeF(129f, 25f);
		((XRControl)xrLabel1).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).Text = "DATA DE RECEBIMENTO";
		((XRControl)xrShape2).BorderWidth = 0f;
		((XRControl)xrShape2).LocationFloat = new PointFloat(624f, 0f);
		((XRControl)xrShape2).Name = "xrShape2";
		xrShape2.Shape = (ShapeBase)(object)shape;
		((XRControl)xrShape2).SizeF = new SizeF(2f, 67f);
		((XRControl)xrShape2).StylePriority.UseBorderWidth = false;
		xrShape1.Angle = 270;
		((XRControl)xrShape1).BorderWidth = 0f;
		((XRControl)xrShape1).LocationFloat = new PointFloat(0f, 25f);
		((XRControl)xrShape1).Name = "xrShape1";
		xrShape1.Shape = (ShapeBase)(object)shape2;
		((XRControl)xrShape1).SizeF = new SizeF(625f, 2f);
		((XRControl)xrShape1).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe).BorderWidth = 0f;
		((XRControl)xrRecebemosDe).Font = new Font("Times New Roman", 6f);
		((XRControl)xrRecebemosDe).LocationFloat = new PointFloat(2f, 3f);
		((XRControl)xrRecebemosDe).Name = "xrRecebemosDe";
		((XRControl)xrRecebemosDe).Padding = new PaddingInfo(4, 2, 4, 0, 100f);
		((XRControl)xrRecebemosDe).SizeF = new SizeF(514f, 25f);
		((XRControl)xrRecebemosDe).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe).StylePriority.UseFont = false;
		((XRControl)xrRecebemosDe).StylePriority.UsePadding = false;
		((XRControl)xrRecebemosDe).Text = "RECEBEMOS DE EDILSON VASCONCELOS DE MELO JUNIOR OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA AO LADO";
		((XRControl)xrShape3).BorderWidth = 0f;
		((XRControl)xrShape3).LocationFloat = new PointFloat(125f, 25f);
		((XRControl)xrShape3).Name = "xrShape3";
		xrShape3.Shape = (ShapeBase)(object)shape3;
		((XRControl)xrShape3).SizeF = new SizeF(8f, 42f);
		((XRControl)xrShape3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).BorderWidth = 0f;
		((XRControl)xrLabel2).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(142f, 33f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel2).SizeF = new SizeF(258f, 25f);
		((XRControl)xrLabel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).Text = "IDENTIFICAÇÃO E ASSINATURA DO RECEBEDOR";
		((XRControl)xrLabel3).BorderWidth = 0f;
		((XRControl)xrLabel3).LocationFloat = new PointFloat(632f, 7f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel3).SizeF = new SizeF(83f, 18f);
		((XRControl)xrLabel3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "NF-e";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel4).BorderWidth = 0f;
		((XRControl)xrLabel4).LocationFloat = new PointFloat(632f, 24f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel4).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel4).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel4).Text = "N.";
		((XRControl)xrNFeNum).BorderWidth = 0f;
		((XRControl)xrNFeNum).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrNFeNum).LocationFloat = new PointFloat(649f, 24f);
		((XRControl)xrNFeNum).Name = "xrNFeNum";
		((XRControl)xrNFeNum).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNFeNum).SizeF = new SizeF(73f, 15f);
		((XRControl)xrNFeNum).StylePriority.UseBorderWidth = false;
		((XRControl)xrNFeNum).StylePriority.UseFont = false;
		((XRControl)xrNFeNum).Text = "000.000.000";
		((XRControl)xrSerieNFe).BorderWidth = 0f;
		((XRControl)xrSerieNFe).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrSerieNFe).LocationFloat = new PointFloat(632f, 41f);
		((XRControl)xrSerieNFe).Name = "xrSerieNFe";
		((XRControl)xrSerieNFe).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNFe).SizeF = new SizeF(83f, 17f);
		((XRControl)xrSerieNFe).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNFe).StylePriority.UseFont = false;
		((XRControl)xrSerieNFe).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNFe).Text = "SÉRIE 1";
		((XRControl)xrSerieNFe).TextAlignment = (TextAlignment)2;
		((XRControl)PageFooter).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrPanel7,
			(XRControl)xrLabel28,
			(XRControl)xrPanel10,
			(XRControl)xrLabel46
		});
		((XRControl)PageFooter).HeightF = 171f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)xrPanel7).Borders = (BorderSide)15;
		((XRControl)xrPanel7).BorderWidth = 1f;
		((XRControl)xrPanel7).CanGrow = false;
		((XRControl)xrPanel7).Controls.AddRange((XRControl[])(object)new XRControl[11]
		{
			(XRControl)xrValorServico,
			(XRControl)xrLabel54,
			(XRControl)xrBaseISSQN,
			(XRControl)xrLine23,
			(XRControl)xrLabel61,
			(XRControl)xrLine26,
			(XRControl)xrLine29,
			(XRControl)xrValorISSQN,
			(XRControl)xrLabel65,
			(XRControl)xrIM,
			(XRControl)xrLabel67
		});
		((XRControl)xrPanel7).LocationFloat = new PointFloat(1f, 23f);
		((XRControl)xrPanel7).Name = "xrPanel7";
		((XRControl)xrPanel7).SizeF = new SizeF(724f, 39f);
		((XRControl)xrPanel7).StylePriority.UseBorders = false;
		((XRControl)xrPanel7).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorServico).BorderWidth = 0f;
		((XRControl)xrValorServico).LocationFloat = new PointFloat(174f, 17f);
		((XRControl)xrValorServico).Name = "xrValorServico";
		((XRControl)xrValorServico).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorServico).SizeF = new SizeF(183f, 17f);
		((XRControl)xrValorServico).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel54).BorderWidth = 0f;
		((XRControl)xrLabel54).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel54).LocationFloat = new PointFloat(374f, 0f);
		((XRControl)xrLabel54).Name = "xrLabel54";
		((XRControl)xrLabel54).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel54).SizeF = new SizeF(158f, 17f);
		((XRControl)xrLabel54).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel54).StylePriority.UseFont = false;
		((XRControl)xrLabel54).Text = "BASE DE CÁLCULO DO ISSQN";
		((XRControl)xrBaseISSQN).BorderWidth = 0f;
		((XRControl)xrBaseISSQN).LocationFloat = new PointFloat(374f, 17f);
		((XRControl)xrBaseISSQN).Name = "xrBaseISSQN";
		((XRControl)xrBaseISSQN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseISSQN).SizeF = new SizeF(150f, 17f);
		((XRControl)xrBaseISSQN).StylePriority.UseBorderWidth = false;
		((XRControl)xrBaseISSQN).Text = "xrNatOp";
		((XRControl)xrLine23).Borders = (BorderSide)0;
		xrLine23.LineDirection = (LineDirection)3;
		((XRControl)xrLine23).LocationFloat = new PointFloat(366f, 0f);
		((XRControl)xrLine23).Name = "xrLine23";
		((XRControl)xrLine23).SizeF = new SizeF(9f, 39f);
		((XRControl)xrLine23).StylePriority.UseBorders = false;
		((XRControl)xrLabel61).BorderWidth = 0f;
		((XRControl)xrLabel61).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel61).LocationFloat = new PointFloat(174f, 0f);
		((XRControl)xrLabel61).Name = "xrLabel61";
		((XRControl)xrLabel61).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel61).SizeF = new SizeF(168f, 17f);
		((XRControl)xrLabel61).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel61).StylePriority.UseFont = false;
		((XRControl)xrLabel61).Text = "VALOR TOTAL DOS SERVIÇOS";
		((XRControl)xrLine26).Borders = (BorderSide)0;
		xrLine26.LineDirection = (LineDirection)3;
		((XRControl)xrLine26).LocationFloat = new PointFloat(166f, 0f);
		((XRControl)xrLine26).Name = "xrLine26";
		((XRControl)xrLine26).SizeF = new SizeF(9f, 39f);
		((XRControl)xrLine26).StylePriority.UseBorders = false;
		((XRControl)xrLine29).Borders = (BorderSide)0;
		xrLine29.LineDirection = (LineDirection)3;
		((XRControl)xrLine29).LocationFloat = new PointFloat(574f, 0f);
		((XRControl)xrLine29).Name = "xrLine29";
		((XRControl)xrLine29).SizeF = new SizeF(9f, 39f);
		((XRControl)xrLine29).StylePriority.UseBorders = false;
		((XRControl)xrValorISSQN).BorderWidth = 0f;
		((XRControl)xrValorISSQN).LocationFloat = new PointFloat(582f, 17f);
		((XRControl)xrValorISSQN).Name = "xrValorISSQN";
		((XRControl)xrValorISSQN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorISSQN).SizeF = new SizeF(117f, 17f);
		((XRControl)xrValorISSQN).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorISSQN).Text = "xrNatOp";
		((XRControl)xrLabel65).BorderWidth = 0f;
		((XRControl)xrLabel65).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel65).LocationFloat = new PointFloat(582f, 0f);
		((XRControl)xrLabel65).Name = "xrLabel65";
		((XRControl)xrLabel65).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel65).SizeF = new SizeF(133f, 17f);
		((XRControl)xrLabel65).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel65).StylePriority.UseFont = false;
		((XRControl)xrLabel65).Text = "VALOR DO ISSQN";
		((XRControl)xrIM).BorderWidth = 0f;
		((XRControl)xrIM).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrIM).Name = "xrIM";
		((XRControl)xrIM).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrIM).SizeF = new SizeF(167f, 17f);
		((XRControl)xrIM).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel67).BorderWidth = 0f;
		((XRControl)xrLabel67).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel67).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel67).Name = "xrLabel67";
		((XRControl)xrLabel67).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel67).SizeF = new SizeF(141f, 17f);
		((XRControl)xrLabel67).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel67).StylePriority.UseFont = false;
		((XRControl)xrLabel67).Text = "INSCRIÇÃO MUNICIPAL";
		((XRControl)xrLabel28).BorderWidth = 0f;
		((XRControl)xrLabel28).LocationFloat = new PointFloat(1f, 6f);
		((XRControl)xrLabel28).Name = "xrLabel28";
		((XRControl)xrLabel28).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel28).SizeF = new SizeF(208f, 14f);
		((XRControl)xrLabel28).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel28).Text = "CÁLCULO DO ISSQN";
		((XRControl)xrPanel10).Borders = (BorderSide)15;
		((XRControl)xrPanel10).BorderWidth = 1f;
		((XRControl)xrPanel10).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrLine38,
			(XRControl)xrLabel55,
			(XRControl)xrLabel59,
			(XRControl)xrInfoCpl
		});
		((XRControl)xrPanel10).LocationFloat = new PointFloat(1f, 78f);
		((XRControl)xrPanel10).Name = "xrPanel10";
		((XRControl)xrPanel10).SizeF = new SizeF(724f, 92f);
		((XRControl)xrPanel10).StylePriority.UseBorders = false;
		((XRControl)xrPanel10).StylePriority.UseBorderWidth = false;
		((XRControl)xrPanel10).PrintOnPage += new PrintOnPageEventHandler(xrLabel46_PrintOnPage);
		((XRControl)xrLine38).Borders = (BorderSide)0;
		xrLine38.LineDirection = (LineDirection)3;
		((XRControl)xrLine38).LocationFloat = new PointFloat(383f, 0f);
		((XRControl)xrLine38).Name = "xrLine38";
		((XRControl)xrLine38).SizeF = new SizeF(9f, 92f);
		((XRControl)xrLine38).StylePriority.UseBorders = false;
		((XRControl)xrLabel55).BorderWidth = 0f;
		((XRControl)xrLabel55).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel55).LocationFloat = new PointFloat(7f, 1f);
		((XRControl)xrLabel55).Name = "xrLabel55";
		((XRControl)xrLabel55).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel55).SizeF = new SizeF(200f, 17f);
		((XRControl)xrLabel55).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel55).StylePriority.UseFont = false;
		((XRControl)xrLabel55).Text = "INFORMAÇÔES COMPLEMENTARES";
		((XRControl)xrLabel59).BorderWidth = 0f;
		((XRControl)xrLabel59).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel59).LocationFloat = new PointFloat(399f, 1f);
		((XRControl)xrLabel59).Name = "xrLabel59";
		((XRControl)xrLabel59).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel59).SizeF = new SizeF(200f, 17f);
		((XRControl)xrLabel59).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel59).StylePriority.UseFont = false;
		((XRControl)xrLabel59).Text = "RESERVADO AO FISCO";
		((XRControl)xrInfoCpl).BorderWidth = 0f;
		((XRControl)xrInfoCpl).CanGrow = false;
		((XRControl)xrInfoCpl).Font = new Font("Times New Roman", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrInfoCpl).LocationFloat = new PointFloat(8f, 17f);
		xrInfoCpl.Multiline = true;
		((XRControl)xrInfoCpl).Name = "xrInfoCpl";
		((XRControl)xrInfoCpl).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrInfoCpl).SizeF = new SizeF(372f, 70f);
		((XRControl)xrInfoCpl).StylePriority.UseBorderWidth = false;
		((XRControl)xrInfoCpl).StylePriority.UseFont = false;
		((XRControl)xrLabel46).LocationFloat = new PointFloat(1f, 64f);
		((XRControl)xrLabel46).Name = "xrLabel46";
		((XRControl)xrLabel46).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel46).SizeF = new SizeF(142f, 25f);
		((XRControl)xrLabel46).Text = "DADOS ADICIONAIS";
		((XRControl)xrLabel46).PrintOnPage += new PrintOnPageEventHandler(xrLabel46_PrintOnPage);
		((XRControl)ReportHeader).Borders = (BorderSide)15;
		((XRControl)ReportHeader).BorderWidth = 1f;
		((XRControl)ReportHeader).Controls.AddRange((XRControl[])(object)new XRControl[20]
		{
			(XRControl)xrLabel14,
			(XRControl)xrFirstPageOnly,
			(XRControl)xrLabel128,
			(XRControl)xrEmitenteIE2,
			(XRControl)xrPanel15,
			(XRControl)xrLabel116,
			(XRControl)xrPageInfo2,
			(XRControl)xrSerieNFe2,
			(XRControl)xrLabel114,
			(XRControl)xrNroNF2,
			(XRControl)xrPanel14,
			(XRControl)xrLabel111,
			(XRControl)xrLabel110,
			(XRControl)xrLabel109,
			(XRControl)xrLabel108,
			(XRControl)xrPanel13,
			(XRControl)xrPanel12,
			(XRControl)xrLine39,
			(XRControl)xrPanel11,
			(XRControl)xrPanel23
		});
		((XRControl)ReportHeader).HeightF = 764f;
		((XRControl)ReportHeader).Name = "ReportHeader";
		((XRControl)ReportHeader).StylePriority.UseBorders = false;
		((XRControl)ReportHeader).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel14).Borders = (BorderSide)0;
		((XRControl)xrLabel14).LocationFloat = new PointFloat(0f, 722f);
		((XRControl)xrLabel14).Name = "xrLabel14";
		((XRControl)xrLabel14).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel14).SizeF = new SizeF(183f, 22f);
		((XRControl)xrLabel14).StylePriority.UseBorders = false;
		((XRControl)xrLabel14).Text = "DADOS DOS PRODUTOS";
		((XRControl)xrFirstPageOnly).Borders = (BorderSide)0;
		((XRControl)xrFirstPageOnly).BorderWidth = 1f;
		((XRControl)xrFirstPageOnly).Controls.AddRange((XRControl[])(object)new XRControl[9]
		{
			(XRControl)xrLabel18,
			(XRControl)xrPanel4,
			(XRControl)xrPanel5,
			(XRControl)xrLabel23,
			(XRControl)xrPanel6,
			(XRControl)xrLabel32,
			(XRControl)xrLabel42,
			(XRControl)xrPanel9,
			(XRControl)xrPanel8
		});
		((XRControl)xrFirstPageOnly).LocationFloat = new PointFloat(1f, 281f);
		((XRControl)xrFirstPageOnly).Name = "xrFirstPageOnly";
		((XRControl)xrFirstPageOnly).SizeF = new SizeF(724f, 438f);
		((XRControl)xrFirstPageOnly).StylePriority.UseBorders = false;
		((XRControl)xrFirstPageOnly).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel18).BorderWidth = 0f;
		((XRControl)xrLabel18).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel18).Name = "xrLabel18";
		((XRControl)xrLabel18).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel18).SizeF = new SizeF(208f, 25f);
		((XRControl)xrLabel18).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel18).Text = "DESTINATÁRIO / REMETENTE";
		((XRControl)xrPanel4).Borders = (BorderSide)15;
		((XRControl)xrPanel4).CanGrow = false;
		((XRControl)xrPanel4).Controls.AddRange((XRControl[])(object)new XRControl[25]
		{
			(XRControl)xrLabel41,
			(XRControl)xrDestCidade,
			(XRControl)xrLabel39,
			(XRControl)xrDestEndereco,
			(XRControl)xrLine14,
			(XRControl)xrLabel37,
			(XRControl)xrDestUF,
			(XRControl)xrLabel35,
			(XRControl)xrDestFone,
			(XRControl)xrLine13,
			(XRControl)xrLabel33,
			(XRControl)xrDestIE,
			(XRControl)xrLine12,
			(XRControl)xrLabel31,
			(XRControl)xrDestCEP,
			(XRControl)xrLine11,
			(XRControl)xrLabel29,
			(XRControl)xrDestBairro,
			(XRControl)xrLabel27,
			(XRControl)xrDestCNPJ,
			(XRControl)xrLine10,
			(XRControl)xrDestRazaoSocial,
			(XRControl)xrLabel20,
			(XRControl)xrLine9,
			(XRControl)xrLine8
		});
		((XRControl)xrPanel4).LocationFloat = new PointFloat(0f, 17f);
		((XRControl)xrPanel4).Name = "xrPanel4";
		((XRControl)xrPanel4).SizeF = new SizeF(607f, 110f);
		((XRControl)xrPanel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel41).BorderWidth = 0f;
		((XRControl)xrLabel41).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel41).LocationFloat = new PointFloat(8f, 75f);
		((XRControl)xrLabel41).Name = "xrLabel41";
		((XRControl)xrLabel41).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel41).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel41).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel41).StylePriority.UseFont = false;
		((XRControl)xrLabel41).Text = "CIDADE";
		((XRControl)xrDestCidade).BorderWidth = 0f;
		((XRControl)xrDestCidade).CanGrow = false;
		((XRControl)xrDestCidade).LocationFloat = new PointFloat(8f, 92f);
		((XRControl)xrDestCidade).Name = "xrDestCidade";
		((XRControl)xrDestCidade).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCidade).SizeF = new SizeF(266f, 12f);
		((XRControl)xrDestCidade).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCidade).Text = "07.577.462/0001-15";
		((XRControl)xrLabel39).BorderWidth = 0f;
		((XRControl)xrLabel39).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel39).LocationFloat = new PointFloat(8f, 42f);
		((XRControl)xrLabel39).Name = "xrLabel39";
		((XRControl)xrLabel39).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel39).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel39).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel39).StylePriority.UseFont = false;
		((XRControl)xrLabel39).Text = "ENDEREÇO";
		((XRControl)xrDestEndereco).BorderWidth = 0f;
		((XRControl)xrDestEndereco).CanGrow = false;
		((XRControl)xrDestEndereco).LocationFloat = new PointFloat(7f, 51f);
		((XRControl)xrDestEndereco).Name = "xrDestEndereco";
		((XRControl)xrDestEndereco).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestEndereco).SizeF = new SizeF(308f, 17f);
		((XRControl)xrDestEndereco).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestEndereco).Text = "07.577.462/0001-15";
		((XRControl)xrLine14).Borders = (BorderSide)0;
		xrLine14.LineDirection = (LineDirection)3;
		((XRControl)xrLine14).LocationFloat = new PointFloat(274f, 74f);
		((XRControl)xrLine14).Name = "xrLine14";
		((XRControl)xrLine14).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine14).StylePriority.UseBorders = false;
		((XRControl)xrLabel37).BorderWidth = 0f;
		((XRControl)xrLabel37).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel37).LocationFloat = new PointFloat(291f, 74f);
		((XRControl)xrLabel37).Name = "xrLabel37";
		((XRControl)xrLabel37).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel37).SizeF = new SizeF(25f, 17f);
		((XRControl)xrLabel37).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel37).StylePriority.UseFont = false;
		((XRControl)xrLabel37).Text = "UF";
		((XRControl)xrDestUF).BorderWidth = 0f;
		((XRControl)xrDestUF).CanGrow = false;
		((XRControl)xrDestUF).LocationFloat = new PointFloat(291f, 91f);
		((XRControl)xrDestUF).Name = "xrDestUF";
		((XRControl)xrDestUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestUF).SizeF = new SizeF(25f, 12f);
		((XRControl)xrDestUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestUF).Text = "SP";
		((XRControl)xrLabel35).BorderWidth = 0f;
		((XRControl)xrLabel35).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel35).LocationFloat = new PointFloat(332f, 74f);
		((XRControl)xrLabel35).Name = "xrLabel35";
		((XRControl)xrLabel35).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel35).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel35).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel35).StylePriority.UseFont = false;
		((XRControl)xrLabel35).Text = "FONE";
		((XRControl)xrDestFone).BorderWidth = 0f;
		((XRControl)xrDestFone).CanGrow = false;
		((XRControl)xrDestFone).LocationFloat = new PointFloat(332f, 91f);
		((XRControl)xrDestFone).Name = "xrDestFone";
		((XRControl)xrDestFone).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestFone).SizeF = new SizeF(125f, 12f);
		((XRControl)xrDestFone).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestFone).Text = "07.577.462/0001-15";
		((XRControl)xrLine13).Borders = (BorderSide)0;
		xrLine13.LineDirection = (LineDirection)3;
		((XRControl)xrLine13).LocationFloat = new PointFloat(466f, 74f);
		((XRControl)xrLine13).Name = "xrLine13";
		((XRControl)xrLine13).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine13).StylePriority.UseBorders = false;
		((XRControl)xrLabel33).BorderWidth = 0f;
		((XRControl)xrLabel33).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel33).LocationFloat = new PointFloat(482f, 74f);
		((XRControl)xrLabel33).Name = "xrLabel33";
		((XRControl)xrLabel33).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel33).SizeF = new SizeF(125f, 17f);
		((XRControl)xrLabel33).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel33).StylePriority.UseFont = false;
		((XRControl)xrLabel33).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrDestIE).BorderWidth = 0f;
		((XRControl)xrDestIE).CanGrow = false;
		((XRControl)xrDestIE).LocationFloat = new PointFloat(482f, 91f);
		((XRControl)xrDestIE).Name = "xrDestIE";
		((XRControl)xrDestIE).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestIE).SizeF = new SizeF(125f, 12f);
		((XRControl)xrDestIE).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestIE).Text = "07.577.462/0001-15";
		((XRControl)xrLine12).Borders = (BorderSide)0;
		xrLine12.LineDirection = (LineDirection)3;
		((XRControl)xrLine12).LocationFloat = new PointFloat(507f, 41f);
		((XRControl)xrLine12).Name = "xrLine12";
		((XRControl)xrLine12).SizeF = new SizeF(9f, 32f);
		((XRControl)xrLine12).StylePriority.UseBorders = false;
		((XRControl)xrLabel31).BorderWidth = 0f;
		((XRControl)xrLabel31).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel31).LocationFloat = new PointFloat(524f, 41f);
		((XRControl)xrLabel31).Name = "xrLabel31";
		((XRControl)xrLabel31).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel31).SizeF = new SizeF(58f, 17f);
		((XRControl)xrLabel31).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel31).StylePriority.UseFont = false;
		((XRControl)xrLabel31).Text = "CEP";
		((XRControl)xrDestCEP).BorderWidth = 0f;
		((XRControl)xrDestCEP).CanGrow = false;
		((XRControl)xrDestCEP).LocationFloat = new PointFloat(524f, 49f);
		((XRControl)xrDestCEP).Name = "xrDestCEP";
		((XRControl)xrDestCEP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCEP).SizeF = new SizeF(75f, 17f);
		((XRControl)xrDestCEP).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCEP).Text = "13.026-075";
		((XRControl)xrLine11).Borders = (BorderSide)0;
		xrLine11.LineDirection = (LineDirection)3;
		((XRControl)xrLine11).LocationFloat = new PointFloat(316f, 41f);
		((XRControl)xrLine11).Name = "xrLine11";
		((XRControl)xrLine11).SizeF = new SizeF(9f, 75f);
		((XRControl)xrLine11).StylePriority.UseBorders = false;
		((XRControl)xrLabel29).BorderWidth = 0f;
		((XRControl)xrLabel29).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel29).LocationFloat = new PointFloat(332f, 41f);
		((XRControl)xrLabel29).Name = "xrLabel29";
		((XRControl)xrLabel29).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel29).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel29).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel29).StylePriority.UseFont = false;
		((XRControl)xrLabel29).Text = "BAIRRO";
		((XRControl)xrDestBairro).BorderWidth = 0f;
		((XRControl)xrDestBairro).CanGrow = false;
		((XRControl)xrDestBairro).LocationFloat = new PointFloat(332f, 49f);
		((XRControl)xrDestBairro).Name = "xrDestBairro";
		((XRControl)xrDestBairro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestBairro).SizeF = new SizeF(167f, 17f);
		((XRControl)xrDestBairro).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestBairro).Text = "07.577.462/0001-15";
		((XRControl)xrLabel27).BorderWidth = 0f;
		((XRControl)xrLabel27).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel27).LocationFloat = new PointFloat(482f, 0f);
		((XRControl)xrLabel27).Name = "xrLabel27";
		((XRControl)xrLabel27).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel27).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel27).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel27).StylePriority.UseFont = false;
		((XRControl)xrLabel27).Text = "CNPJ";
		((XRControl)xrDestCNPJ).BorderWidth = 0f;
		((XRControl)xrDestCNPJ).CanGrow = false;
		((XRControl)xrDestCNPJ).LocationFloat = new PointFloat(482f, 16f);
		((XRControl)xrDestCNPJ).Name = "xrDestCNPJ";
		((XRControl)xrDestCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCNPJ).SizeF = new SizeF(125f, 17f);
		((XRControl)xrDestCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrLine10).Borders = (BorderSide)0;
		xrLine10.LineDirection = (LineDirection)3;
		((XRControl)xrLine10).LocationFloat = new PointFloat(466f, 0f);
		((XRControl)xrLine10).Name = "xrLine10";
		((XRControl)xrLine10).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine10).StylePriority.UseBorders = false;
		((XRControl)xrDestRazaoSocial).BorderWidth = 0f;
		((XRControl)xrDestRazaoSocial).CanGrow = false;
		((XRControl)xrDestRazaoSocial).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrDestRazaoSocial).Name = "xrDestRazaoSocial";
		((XRControl)xrDestRazaoSocial).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestRazaoSocial).SizeF = new SizeF(457f, 17f);
		((XRControl)xrDestRazaoSocial).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel20).BorderWidth = 0f;
		((XRControl)xrLabel20).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel20).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel20).Name = "xrLabel20";
		((XRControl)xrLabel20).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel20).SizeF = new SizeF(192f, 17f);
		((XRControl)xrLabel20).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel20).StylePriority.UseFont = false;
		((XRControl)xrLabel20).Text = "RAZÃO SOCIAL";
		((XRControl)xrLine9).Borders = (BorderSide)0;
		((XRControl)xrLine9).LocationFloat = new PointFloat(0f, 70f);
		((XRControl)xrLine9).Name = "xrLine9";
		((XRControl)xrLine9).SizeF = new SizeF(612f, 9f);
		((XRControl)xrLine9).StylePriority.UseBorders = false;
		((XRControl)xrLine8).Borders = (BorderSide)0;
		((XRControl)xrLine8).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine8).Name = "xrLine8";
		((XRControl)xrLine8).SizeF = new SizeF(615f, 9f);
		((XRControl)xrLine8).StylePriority.UseBorders = false;
		((XRControl)xrPanel5).Borders = (BorderSide)15;
		((XRControl)xrPanel5).CanGrow = false;
		((XRControl)xrPanel5).Controls.AddRange((XRControl[])(object)new XRControl[8]
		{
			(XRControl)xrLabel26,
			(XRControl)xrHrSaida,
			(XRControl)xrLabel24,
			(XRControl)xrDtSaida,
			(XRControl)xrLabel22,
			(XRControl)xrDtEmissao,
			(XRControl)xrLine5,
			(XRControl)xrLine4
		});
		((XRControl)xrPanel5).LocationFloat = new PointFloat(616f, 17f);
		((XRControl)xrPanel5).Name = "xrPanel5";
		((XRControl)xrPanel5).SizeF = new SizeF(108f, 110f);
		((XRControl)xrPanel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel26).BorderWidth = 0f;
		((XRControl)xrLabel26).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel26).LocationFloat = new PointFloat(8f, 76f);
		((XRControl)xrLabel26).Name = "xrLabel26";
		((XRControl)xrLabel26).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel26).SizeF = new SizeF(92f, 17f);
		((XRControl)xrLabel26).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel26).StylePriority.UseFont = false;
		((XRControl)xrLabel26).Text = "HORA DE SAÍDA";
		((XRControl)xrHrSaida).BorderWidth = 0f;
		((XRControl)xrHrSaida).CanGrow = false;
		((XRControl)xrHrSaida).LocationFloat = new PointFloat(8f, 92f);
		((XRControl)xrHrSaida).Name = "xrHrSaida";
		((XRControl)xrHrSaida).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrHrSaida).SizeF = new SizeF(92f, 17f);
		((XRControl)xrHrSaida).StylePriority.UseBorderWidth = false;
		((XRControl)xrHrSaida).Text = "29/09/2000";
		((XRControl)xrLabel24).BorderWidth = 0f;
		((XRControl)xrLabel24).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel24).LocationFloat = new PointFloat(8f, 42f);
		((XRControl)xrLabel24).Name = "xrLabel24";
		((XRControl)xrLabel24).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel24).SizeF = new SizeF(92f, 17f);
		((XRControl)xrLabel24).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel24).StylePriority.UseFont = false;
		((XRControl)xrLabel24).Text = "DATA DE SAÍDA";
		((XRControl)xrDtSaida).BorderWidth = 0f;
		((XRControl)xrDtSaida).LocationFloat = new PointFloat(7f, 53f);
		((XRControl)xrDtSaida).Name = "xrDtSaida";
		((XRControl)xrDtSaida).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDtSaida).SizeF = new SizeF(92f, 17f);
		((XRControl)xrDtSaida).StylePriority.UseBorderWidth = false;
		((XRControl)xrDtSaida).Text = "29/09/2000";
		((XRControl)xrLabel22).BorderWidth = 0f;
		((XRControl)xrLabel22).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel22).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel22).Name = "xrLabel22";
		((XRControl)xrLabel22).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel22).SizeF = new SizeF(92f, 17f);
		((XRControl)xrLabel22).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel22).StylePriority.UseFont = false;
		((XRControl)xrLabel22).Text = "DATA DE EMISSÃO";
		((XRControl)xrDtEmissao).BorderWidth = 0f;
		((XRControl)xrDtEmissao).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrDtEmissao).Name = "xrDtEmissao";
		((XRControl)xrDtEmissao).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDtEmissao).SizeF = new SizeF(92f, 17f);
		((XRControl)xrDtEmissao).StylePriority.UseBorderWidth = false;
		((XRControl)xrDtEmissao).Text = "29/09/2000";
		((XRControl)xrLine5).Borders = (BorderSide)0;
		((XRControl)xrLine5).LocationFloat = new PointFloat(0f, 70f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(105f, 8f);
		((XRControl)xrLine5).StylePriority.UseBorders = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(106f, 9f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLabel23).BorderWidth = 0f;
		((XRControl)xrLabel23).LocationFloat = new PointFloat(0f, 133f);
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel23).SizeF = new SizeF(208f, 14f);
		((XRControl)xrLabel23).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel23).Text = "CÁLCULO DO IMPOSTO";
		((XRControl)xrPanel6).Borders = (BorderSide)15;
		((XRControl)xrPanel6).BorderWidth = 1f;
		((XRControl)xrPanel6).CanGrow = false;
		((XRControl)xrPanel6).Controls.AddRange((XRControl[])(object)new XRControl[30]
		{
			(XRControl)xrLine22,
			(XRControl)xrValorOutras,
			(XRControl)xrLabel52,
			(XRControl)xrValorDesconto,
			(XRControl)xrLabel25,
			(XRControl)xrLabel51,
			(XRControl)xrValorFrete,
			(XRControl)xrLabel49,
			(XRControl)xrBaseST,
			(XRControl)xrLine21,
			(XRControl)xrLabel47,
			(XRControl)xrValorST,
			(XRControl)xrLabel45,
			(XRControl)xrValorIPI,
			(XRControl)xrLine20,
			(XRControl)xrTotalNota,
			(XRControl)xrLabel38,
			(XRControl)xrValorICMS,
			(XRControl)xrLabel40,
			(XRControl)xrLine19,
			(XRControl)xrLine15,
			(XRControl)xrLine16,
			(XRControl)xrLabel30,
			(XRControl)xrValorSeguro,
			(XRControl)xrLine17,
			(XRControl)xrTotalProd,
			(XRControl)xrLabel36,
			(XRControl)xrLine18,
			(XRControl)xrBaseICMS,
			(XRControl)xrLabel43
		});
		((XRControl)xrPanel6).LocationFloat = new PointFloat(0f, 150f);
		((XRControl)xrPanel6).Name = "xrPanel6";
		((XRControl)xrPanel6).SizeF = new SizeF(724f, 75f);
		((XRControl)xrPanel6).StylePriority.UseBorders = false;
		((XRControl)xrPanel6).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine22).Borders = (BorderSide)0;
		xrLine22.LineDirection = (LineDirection)3;
		((XRControl)xrLine22).LocationFloat = new PointFloat(342f, 40f);
		((XRControl)xrLine22).Name = "xrLine22";
		((XRControl)xrLine22).SizeF = new SizeF(8f, 35f);
		((XRControl)xrLine22).StylePriority.UseBorders = false;
		((XRControl)xrValorOutras).BorderWidth = 0f;
		((XRControl)xrValorOutras).LocationFloat = new PointFloat(350f, 58f);
		((XRControl)xrValorOutras).Name = "xrValorOutras";
		((XRControl)xrValorOutras).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorOutras).SizeF = new SizeF(83f, 17f);
		((XRControl)xrValorOutras).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel52).BorderWidth = 0f;
		((XRControl)xrLabel52).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel52).LocationFloat = new PointFloat(358f, 42f);
		((XRControl)xrLabel52).Name = "xrLabel52";
		((XRControl)xrLabel52).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel52).SizeF = new SizeF(75f, 17f);
		((XRControl)xrLabel52).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel52).StylePriority.UseFont = false;
		((XRControl)xrLabel52).Text = "OUTRAS";
		((XRControl)xrValorDesconto).BorderWidth = 0f;
		((XRControl)xrValorDesconto).LocationFloat = new PointFloat(233f, 58f);
		((XRControl)xrValorDesconto).Name = "xrValorDesconto";
		((XRControl)xrValorDesconto).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorDesconto).SizeF = new SizeF(83f, 17f);
		((XRControl)xrValorDesconto).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel25).BorderWidth = 0f;
		((XRControl)xrLabel25).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(242f, 42f);
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel25).SizeF = new SizeF(75f, 17f);
		((XRControl)xrLabel25).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).Text = "DESCONTO";
		((XRControl)xrLabel51).BorderWidth = 0f;
		((XRControl)xrLabel51).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel51).LocationFloat = new PointFloat(8f, 42f);
		((XRControl)xrLabel51).Name = "xrLabel51";
		((XRControl)xrLabel51).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel51).SizeF = new SizeF(92f, 17f);
		((XRControl)xrLabel51).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel51).StylePriority.UseFont = false;
		((XRControl)xrLabel51).Text = "VALOR DO FRETE";
		((XRControl)xrValorFrete).BorderWidth = 0f;
		((XRControl)xrValorFrete).LocationFloat = new PointFloat(8f, 58f);
		((XRControl)xrValorFrete).Name = "xrValorFrete";
		((XRControl)xrValorFrete).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorFrete).SizeF = new SizeF(92f, 17f);
		((XRControl)xrValorFrete).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel49).BorderWidth = 0f;
		((XRControl)xrLabel49).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel49).LocationFloat = new PointFloat(308f, 0f);
		((XRControl)xrLabel49).Name = "xrLabel49";
		((XRControl)xrLabel49).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel49).SizeF = new SizeF(127f, 17f);
		((XRControl)xrLabel49).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel49).StylePriority.UseFont = false;
		((XRControl)xrLabel49).Text = "BASE SUBSTITUIÇÃO";
		((XRControl)xrBaseST).BorderWidth = 0f;
		((XRControl)xrBaseST).LocationFloat = new PointFloat(308f, 17f);
		((XRControl)xrBaseST).Name = "xrBaseST";
		((XRControl)xrBaseST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseST).SizeF = new SizeF(110f, 17f);
		((XRControl)xrBaseST).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine21).Borders = (BorderSide)0;
		xrLine21.LineDirection = (LineDirection)3;
		((XRControl)xrLine21).LocationFloat = new PointFloat(300f, 0f);
		((XRControl)xrLine21).Name = "xrLine21";
		((XRControl)xrLine21).SizeF = new SizeF(8f, 39f);
		((XRControl)xrLine21).StylePriority.UseBorders = false;
		((XRControl)xrLabel47).BorderWidth = 0f;
		((XRControl)xrLabel47).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel47).LocationFloat = new PointFloat(450f, 0f);
		((XRControl)xrLabel47).Name = "xrLabel47";
		((XRControl)xrLabel47).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel47).SizeF = new SizeF(107f, 17f);
		((XRControl)xrLabel47).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel47).StylePriority.UseFont = false;
		((XRControl)xrLabel47).Text = "VALOR DO ICMS SUB";
		((XRControl)xrValorST).BorderWidth = 0f;
		((XRControl)xrValorST).LocationFloat = new PointFloat(450f, 17f);
		((XRControl)xrValorST).Name = "xrValorST";
		((XRControl)xrValorST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorST).SizeF = new SizeF(99f, 17f);
		((XRControl)xrValorST).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorST).Text = "xrNatOp";
		((XRControl)xrLabel45).BorderWidth = 0f;
		((XRControl)xrLabel45).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel45).LocationFloat = new PointFloat(450f, 42f);
		((XRControl)xrLabel45).Name = "xrLabel45";
		((XRControl)xrLabel45).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel45).SizeF = new SizeF(91f, 17f);
		((XRControl)xrLabel45).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel45).StylePriority.UseFont = false;
		((XRControl)xrLabel45).Text = "VALOR DO IPI";
		((XRControl)xrValorIPI).BorderWidth = 0f;
		((XRControl)xrValorIPI).Font = new Font("Times New Roman", 9.75f);
		((XRControl)xrValorIPI).LocationFloat = new PointFloat(450f, 58f);
		((XRControl)xrValorIPI).Name = "xrValorIPI";
		((XRControl)xrValorIPI).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorIPI).SizeF = new SizeF(99f, 17f);
		((XRControl)xrValorIPI).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorIPI).StylePriority.UseFont = false;
		((XRControl)xrValorIPI).Text = "xrNatOp";
		((XRControl)xrLine20).Borders = (BorderSide)0;
		xrLine20.LineDirection = (LineDirection)3;
		((XRControl)xrLine20).LocationFloat = new PointFloat(442f, 0f);
		((XRControl)xrLine20).Name = "xrLine20";
		((XRControl)xrLine20).SizeF = new SizeF(9f, 75f);
		((XRControl)xrLine20).StylePriority.UseBorders = false;
		((XRControl)xrTotalNota).BorderWidth = 0f;
		((XRControl)xrTotalNota).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrTotalNota).LocationFloat = new PointFloat(565f, 58f);
		((XRControl)xrTotalNota).Name = "xrTotalNota";
		((XRControl)xrTotalNota).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTotalNota).SizeF = new SizeF(149f, 17f);
		((XRControl)xrTotalNota).StylePriority.UseBorderWidth = false;
		((XRControl)xrTotalNota).StylePriority.UseFont = false;
		((XRControl)xrTotalNota).Text = "xrNatOp";
		((XRControl)xrLabel38).BorderWidth = 0f;
		((XRControl)xrLabel38).Font = new Font("Times New Roman", 7f, FontStyle.Bold);
		((XRControl)xrLabel38).LocationFloat = new PointFloat(565f, 43f);
		((XRControl)xrLabel38).Name = "xrLabel38";
		((XRControl)xrLabel38).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel38).SizeF = new SizeF(157f, 17f);
		((XRControl)xrLabel38).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel38).StylePriority.UseFont = false;
		((XRControl)xrLabel38).Text = "TOTAL DA NOTA";
		((XRControl)xrValorICMS).BorderWidth = 0f;
		((XRControl)xrValorICMS).LocationFloat = new PointFloat(158f, 17f);
		((XRControl)xrValorICMS).Name = "xrValorICMS";
		((XRControl)xrValorICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorICMS).SizeF = new SizeF(110f, 17f);
		((XRControl)xrValorICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel40).BorderWidth = 0f;
		((XRControl)xrLabel40).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel40).LocationFloat = new PointFloat(158f, 0f);
		((XRControl)xrLabel40).Name = "xrLabel40";
		((XRControl)xrLabel40).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel40).SizeF = new SizeF(127f, 17f);
		((XRControl)xrLabel40).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel40).StylePriority.UseFont = false;
		((XRControl)xrLabel40).Text = "VALOR DO ICMS";
		((XRControl)xrLine19).Borders = (BorderSide)0;
		xrLine19.LineDirection = (LineDirection)3;
		((XRControl)xrLine19).LocationFloat = new PointFloat(150f, 0f);
		((XRControl)xrLine19).Name = "xrLine19";
		((XRControl)xrLine19).SizeF = new SizeF(8f, 39f);
		((XRControl)xrLine19).StylePriority.UseBorders = false;
		((XRControl)xrLine15).Borders = (BorderSide)0;
		xrLine15.LineDirection = (LineDirection)3;
		((XRControl)xrLine15).LocationFloat = new PointFloat(100f, 40f);
		((XRControl)xrLine15).Name = "xrLine15";
		((XRControl)xrLine15).SizeF = new SizeF(8f, 36f);
		((XRControl)xrLine15).StylePriority.UseBorders = false;
		((XRControl)xrLine16).Borders = (BorderSide)0;
		xrLine16.LineDirection = (LineDirection)3;
		((XRControl)xrLine16).LocationFloat = new PointFloat(225f, 40f);
		((XRControl)xrLine16).Name = "xrLine16";
		((XRControl)xrLine16).SizeF = new SizeF(8f, 34f);
		((XRControl)xrLine16).StylePriority.UseBorders = false;
		((XRControl)xrLabel30).BorderWidth = 0f;
		((XRControl)xrLabel30).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel30).LocationFloat = new PointFloat(117f, 42f);
		((XRControl)xrLabel30).Name = "xrLabel30";
		((XRControl)xrLabel30).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel30).SizeF = new SizeF(108f, 17f);
		((XRControl)xrLabel30).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel30).StylePriority.UseFont = false;
		((XRControl)xrLabel30).Text = "VALOR DO SEGURO";
		((XRControl)xrValorSeguro).BorderWidth = 0f;
		((XRControl)xrValorSeguro).LocationFloat = new PointFloat(117f, 58f);
		((XRControl)xrValorSeguro).Name = "xrValorSeguro";
		((XRControl)xrValorSeguro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorSeguro).SizeF = new SizeF(92f, 17f);
		((XRControl)xrValorSeguro).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine17).Borders = (BorderSide)0;
		xrLine17.LineDirection = (LineDirection)3;
		((XRControl)xrLine17).LocationFloat = new PointFloat(549f, 0f);
		((XRControl)xrLine17).Name = "xrLine17";
		((XRControl)xrLine17).SizeF = new SizeF(9f, 75f);
		((XRControl)xrLine17).StylePriority.UseBorders = false;
		((XRControl)xrTotalProd).BorderWidth = 0f;
		((XRControl)xrTotalProd).LocationFloat = new PointFloat(565f, 18f);
		((XRControl)xrTotalProd).Name = "xrTotalProd";
		((XRControl)xrTotalProd).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTotalProd).SizeF = new SizeF(149f, 17f);
		((XRControl)xrTotalProd).StylePriority.UseBorderWidth = false;
		((XRControl)xrTotalProd).Text = "xrNatOp";
		((XRControl)xrLabel36).BorderWidth = 0f;
		((XRControl)xrLabel36).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel36).LocationFloat = new PointFloat(565f, 0f);
		((XRControl)xrLabel36).Name = "xrLabel36";
		((XRControl)xrLabel36).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel36).SizeF = new SizeF(157f, 17f);
		((XRControl)xrLabel36).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel36).StylePriority.UseFont = false;
		((XRControl)xrLabel36).Text = "VALOR TOTAL DOS PRODUTOS";
		((XRControl)xrLine18).Borders = (BorderSide)0;
		((XRControl)xrLine18).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine18).Name = "xrLine18";
		((XRControl)xrLine18).SizeF = new SizeF(721f, 9f);
		((XRControl)xrLine18).StylePriority.UseBorders = false;
		((XRControl)xrBaseICMS).BorderWidth = 0f;
		((XRControl)xrBaseICMS).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrBaseICMS).Name = "xrBaseICMS";
		((XRControl)xrBaseICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseICMS).SizeF = new SizeF(132f, 17f);
		((XRControl)xrBaseICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel43).BorderWidth = 0f;
		((XRControl)xrLabel43).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel43).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel43).Name = "xrLabel43";
		((XRControl)xrLabel43).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel43).SizeF = new SizeF(141f, 17f);
		((XRControl)xrLabel43).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel43).StylePriority.UseFont = false;
		((XRControl)xrLabel43).Text = "BASE DE CÁLCULO DO ICMS";
		((XRControl)xrLabel32).BorderWidth = 0f;
		((XRControl)xrLabel32).LocationFloat = new PointFloat(0f, 233f);
		((XRControl)xrLabel32).Name = "xrLabel32";
		((XRControl)xrLabel32).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel32).SizeF = new SizeF(332f, 17f);
		((XRControl)xrLabel32).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel32).Text = "TRANSPORTADORA / VOLUMES TRANSPORTADOS";
		((XRControl)xrLabel42).LocationFloat = new PointFloat(0f, 366f);
		((XRControl)xrLabel42).Name = "xrLabel42";
		((XRControl)xrLabel42).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel42).SizeF = new SizeF(100f, 22f);
		((XRControl)xrLabel42).Text = "FATURA";
		((XRControl)xrPanel9).Borders = (BorderSide)15;
		((XRControl)xrPanel9).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrDadosFatura });
		((XRControl)xrPanel9).LocationFloat = new PointFloat(0f, 383f);
		((XRControl)xrPanel9).Name = "xrPanel9";
		((XRControl)xrPanel9).SizeF = new SizeF(723f, 50f);
		((XRControl)xrPanel9).StylePriority.UseBorders = false;
		((XRControl)xrDadosFatura).BorderWidth = 0f;
		((XRControl)xrDadosFatura).CanGrow = false;
		((XRControl)xrDadosFatura).LocationFloat = new PointFloat(8f, 8f);
		xrDadosFatura.Multiline = true;
		((XRControl)xrDadosFatura).Name = "xrDadosFatura";
		((XRControl)xrDadosFatura).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDadosFatura).SizeF = new SizeF(767f, 33f);
		((XRControl)xrDadosFatura).StylePriority.UseBorderWidth = false;
		((XRControl)xrPanel8).Borders = (BorderSide)15;
		((XRControl)xrPanel8).CanGrow = false;
		((XRControl)xrPanel8).Controls.AddRange((XRControl[])(object)new XRControl[44]
		{
			(XRControl)xrLine32,
			(XRControl)xrLine31,
			(XRControl)xrLabel68,
			(XRControl)xrTranspRazaoSocial,
			(XRControl)xrLine30,
			(XRControl)xrTranspCNPJ,
			(XRControl)xrLabel63,
			(XRControl)xrTranspMunicipio,
			(XRControl)xrLabel60,
			(XRControl)xrLine28,
			(XRControl)xrTranspCEP,
			(XRControl)xrLabel58,
			(XRControl)xrPesoLiquido,
			(XRControl)xrLabel56,
			(XRControl)xrLine25,
			(XRControl)xrPesoBruto,
			(XRControl)xrLabel53,
			(XRControl)xrLine24,
			(XRControl)xrTranspEndereco,
			(XRControl)xrLabel44,
			(XRControl)xrTranspQt,
			(XRControl)xrLabel34,
			(XRControl)xrLabel69,
			(XRControl)xrLine33,
			(XRControl)xrTranspPlaca,
			(XRControl)xrTranspPlacaUF,
			(XRControl)xrLine34,
			(XRControl)xrLabel72,
			(XRControl)xrTranspUF,
			(XRControl)xrLabel74,
			(XRControl)xrLabel75,
			(XRControl)xrTranspANTT,
			(XRControl)xrLabel79,
			(XRControl)xrTranspPagoPor,
			(XRControl)xrLine27,
			(XRControl)xrTranspNumeracao,
			(XRControl)xrLabel48,
			(XRControl)xrLine35,
			(XRControl)xrLabel50,
			(XRControl)xrTranspEspecie,
			(XRControl)xrLine36,
			(XRControl)xrLabel62,
			(XRControl)xrTranspMarca,
			(XRControl)xrLine37
		});
		((XRControl)xrPanel8).LocationFloat = new PointFloat(0f, 249f);
		((XRControl)xrPanel8).Name = "xrPanel8";
		((XRControl)xrPanel8).SizeF = new SizeF(724f, 110f);
		((XRControl)xrPanel8).StylePriority.UseBorders = false;
		((XRControl)xrLine32).Borders = (BorderSide)0;
		((XRControl)xrLine32).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine32).Name = "xrLine32";
		((XRControl)xrLine32).SizeF = new SizeF(722f, 9f);
		((XRControl)xrLine32).StylePriority.UseBorders = false;
		((XRControl)xrLine31).Borders = (BorderSide)0;
		((XRControl)xrLine31).LocationFloat = new PointFloat(0f, 69f);
		((XRControl)xrLine31).Name = "xrLine31";
		((XRControl)xrLine31).SizeF = new SizeF(724f, 9f);
		((XRControl)xrLine31).StylePriority.UseBorders = false;
		((XRControl)xrLabel68).BorderWidth = 0f;
		((XRControl)xrLabel68).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel68).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel68).Name = "xrLabel68";
		((XRControl)xrLabel68).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel68).SizeF = new SizeF(192f, 17f);
		((XRControl)xrLabel68).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel68).StylePriority.UseFont = false;
		((XRControl)xrLabel68).Text = "RAZÃO SOCIAL";
		((XRControl)xrTranspRazaoSocial).BorderWidth = 0f;
		((XRControl)xrTranspRazaoSocial).CanGrow = false;
		((XRControl)xrTranspRazaoSocial).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrTranspRazaoSocial).Name = "xrTranspRazaoSocial";
		((XRControl)xrTranspRazaoSocial).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspRazaoSocial).SizeF = new SizeF(257f, 17f);
		((XRControl)xrTranspRazaoSocial).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine30).Borders = (BorderSide)0;
		xrLine30.LineDirection = (LineDirection)3;
		((XRControl)xrLine30).LocationFloat = new PointFloat(599f, 1f);
		((XRControl)xrLine30).Name = "xrLine30";
		((XRControl)xrLine30).SizeF = new SizeF(9f, 72f);
		((XRControl)xrLine30).StylePriority.UseBorders = false;
		((XRControl)xrTranspCNPJ).BorderWidth = 0f;
		((XRControl)xrTranspCNPJ).LocationFloat = new PointFloat(607f, 18f);
		((XRControl)xrTranspCNPJ).Name = "xrTranspCNPJ";
		((XRControl)xrTranspCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspCNPJ).SizeF = new SizeF(117f, 17f);
		((XRControl)xrTranspCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrLabel63).BorderWidth = 0f;
		((XRControl)xrLabel63).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel63).LocationFloat = new PointFloat(607f, 1f);
		((XRControl)xrLabel63).Name = "xrLabel63";
		((XRControl)xrLabel63).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel63).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel63).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel63).StylePriority.UseFont = false;
		((XRControl)xrLabel63).Text = "CNPJ";
		((XRControl)xrTranspMunicipio).BorderWidth = 0f;
		((XRControl)xrTranspMunicipio).CanGrow = false;
		((XRControl)xrTranspMunicipio).LocationFloat = new PointFloat(399f, 51f);
		((XRControl)xrTranspMunicipio).Name = "xrTranspMunicipio";
		((XRControl)xrTranspMunicipio).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspMunicipio).SizeF = new SizeF(167f, 17f);
		((XRControl)xrTranspMunicipio).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspMunicipio).Text = "07.577.462/0001-15";
		((XRControl)xrLabel60).BorderWidth = 0f;
		((XRControl)xrLabel60).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel60).LocationFloat = new PointFloat(399f, 42f);
		((XRControl)xrLabel60).Name = "xrLabel60";
		((XRControl)xrLabel60).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel60).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel60).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel60).StylePriority.UseFont = false;
		((XRControl)xrLabel60).Text = "MUNICÍPIO";
		((XRControl)xrLine28).Borders = (BorderSide)0;
		xrLine28.LineDirection = (LineDirection)3;
		((XRControl)xrLine28).LocationFloat = new PointFloat(391f, 1f);
		((XRControl)xrLine28).Name = "xrLine28";
		((XRControl)xrLine28).SizeF = new SizeF(9f, 71f);
		((XRControl)xrLine28).StylePriority.UseBorders = false;
		((XRControl)xrTranspCEP).BorderWidth = 0f;
		((XRControl)xrTranspCEP).LocationFloat = new PointFloat(607f, 51f);
		((XRControl)xrTranspCEP).Name = "xrTranspCEP";
		((XRControl)xrTranspCEP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspCEP).SizeF = new SizeF(75f, 17f);
		((XRControl)xrTranspCEP).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspCEP).Text = "13.026-075";
		((XRControl)xrLabel58).BorderWidth = 0f;
		((XRControl)xrLabel58).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel58).LocationFloat = new PointFloat(607f, 43f);
		((XRControl)xrLabel58).Name = "xrLabel58";
		((XRControl)xrLabel58).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel58).SizeF = new SizeF(58f, 17f);
		((XRControl)xrLabel58).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel58).StylePriority.UseFont = false;
		((XRControl)xrLabel58).Text = "CEP";
		((XRControl)xrPesoLiquido).BorderWidth = 0f;
		((XRControl)xrPesoLiquido).LocationFloat = new PointFloat(607f, 92f);
		((XRControl)xrPesoLiquido).Name = "xrPesoLiquido";
		((XRControl)xrPesoLiquido).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPesoLiquido).SizeF = new SizeF(108f, 12f);
		((XRControl)xrPesoLiquido).StylePriority.UseBorderWidth = false;
		((XRControl)xrPesoLiquido).Text = "1.000,000";
		((XRControl)xrLabel56).BorderWidth = 0f;
		((XRControl)xrLabel56).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel56).LocationFloat = new PointFloat(607f, 76f);
		((XRControl)xrLabel56).Name = "xrLabel56";
		((XRControl)xrLabel56).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel56).SizeF = new SizeF(79f, 17f);
		((XRControl)xrLabel56).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel56).StylePriority.UseFont = false;
		((XRControl)xrLabel56).Text = "PESO LÍQUIDO";
		((XRControl)xrLine25).Borders = (BorderSide)0;
		xrLine25.LineDirection = (LineDirection)3;
		((XRControl)xrLine25).LocationFloat = new PointFloat(591f, 76f);
		((XRControl)xrLine25).Name = "xrLine25";
		((XRControl)xrLine25).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine25).StylePriority.UseBorders = false;
		((XRControl)xrPesoBruto).BorderWidth = 0f;
		((XRControl)xrPesoBruto).LocationFloat = new PointFloat(466f, 92f);
		((XRControl)xrPesoBruto).Name = "xrPesoBruto";
		((XRControl)xrPesoBruto).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPesoBruto).SizeF = new SizeF(92f, 12f);
		((XRControl)xrPesoBruto).StylePriority.UseBorderWidth = false;
		((XRControl)xrPesoBruto).Text = "1,000,000";
		((XRControl)xrLabel53).BorderWidth = 0f;
		((XRControl)xrLabel53).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel53).LocationFloat = new PointFloat(466f, 76f);
		((XRControl)xrLabel53).Name = "xrLabel53";
		((XRControl)xrLabel53).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel53).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel53).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel53).StylePriority.UseFont = false;
		((XRControl)xrLabel53).Text = "PESO BRUTO";
		((XRControl)xrLine24).Borders = (BorderSide)0;
		xrLine24.LineDirection = (LineDirection)3;
		((XRControl)xrLine24).LocationFloat = new PointFloat(449f, 76f);
		((XRControl)xrLine24).Name = "xrLine24";
		((XRControl)xrLine24).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine24).StylePriority.UseBorders = false;
		((XRControl)xrTranspEndereco).BorderWidth = 0f;
		((XRControl)xrTranspEndereco).CanGrow = false;
		((XRControl)xrTranspEndereco).LocationFloat = new PointFloat(8f, 52f);
		((XRControl)xrTranspEndereco).Name = "xrTranspEndereco";
		((XRControl)xrTranspEndereco).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspEndereco).SizeF = new SizeF(382f, 17f);
		((XRControl)xrTranspEndereco).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspEndereco).Text = "07.577.462/0001-15";
		((XRControl)xrLabel44).BorderWidth = 0f;
		((XRControl)xrLabel44).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel44).LocationFloat = new PointFloat(8f, 39f);
		((XRControl)xrLabel44).Name = "xrLabel44";
		((XRControl)xrLabel44).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel44).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel44).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel44).StylePriority.UseFont = false;
		((XRControl)xrLabel44).Text = "ENDEREÇO";
		((XRControl)xrTranspQt).BorderWidth = 0f;
		((XRControl)xrTranspQt).CanGrow = false;
		((XRControl)xrTranspQt).LocationFloat = new PointFloat(8f, 92f);
		((XRControl)xrTranspQt).Name = "xrTranspQt";
		((XRControl)xrTranspQt).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspQt).SizeF = new SizeF(66f, 12f);
		((XRControl)xrTranspQt).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspQt).Text = "00000";
		((XRControl)xrLabel34).BorderWidth = 0f;
		((XRControl)xrLabel34).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel34).LocationFloat = new PointFloat(8f, 75f);
		((XRControl)xrLabel34).Name = "xrLabel34";
		((XRControl)xrLabel34).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel34).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel34).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel34).StylePriority.UseFont = false;
		((XRControl)xrLabel34).Text = "QUANTIDADE";
		((XRControl)xrLabel69).BorderWidth = 0f;
		((XRControl)xrLabel69).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel69).LocationFloat = new PointFloat(499f, 1f);
		((XRControl)xrLabel69).Name = "xrLabel69";
		((XRControl)xrLabel69).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel69).SizeF = new SizeF(50f, 17f);
		((XRControl)xrLabel69).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel69).StylePriority.UseFont = false;
		((XRControl)xrLabel69).Text = "PLACA";
		((XRControl)xrLine33).Borders = (BorderSide)0;
		xrLine33.LineDirection = (LineDirection)3;
		((XRControl)xrLine33).LocationFloat = new PointFloat(491f, 1f);
		((XRControl)xrLine33).Name = "xrLine33";
		((XRControl)xrLine33).SizeF = new SizeF(9f, 35f);
		((XRControl)xrLine33).StylePriority.UseBorders = false;
		((XRControl)xrTranspPlaca).BorderWidth = 0f;
		((XRControl)xrTranspPlaca).LocationFloat = new PointFloat(499f, 17f);
		((XRControl)xrTranspPlaca).Name = "xrTranspPlaca";
		((XRControl)xrTranspPlaca).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPlaca).SizeF = new SizeF(67f, 17f);
		((XRControl)xrTranspPlaca).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspPlacaUF).BorderWidth = 0f;
		((XRControl)xrTranspPlacaUF).LocationFloat = new PointFloat(574f, 18f);
		((XRControl)xrTranspPlacaUF).Name = "xrTranspPlacaUF";
		((XRControl)xrTranspPlacaUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPlacaUF).SizeF = new SizeF(25f, 12f);
		((XRControl)xrTranspPlacaUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine34).Borders = (BorderSide)0;
		xrLine34.LineDirection = (LineDirection)3;
		((XRControl)xrLine34).LocationFloat = new PointFloat(557f, 1f);
		((XRControl)xrLine34).Name = "xrLine34";
		((XRControl)xrLine34).SizeF = new SizeF(8f, 73f);
		((XRControl)xrLine34).StylePriority.UseBorders = false;
		((XRControl)xrLabel72).BorderWidth = 0f;
		((XRControl)xrLabel72).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel72).LocationFloat = new PointFloat(566f, 1f);
		((XRControl)xrLabel72).Name = "xrLabel72";
		((XRControl)xrLabel72).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel72).SizeF = new SizeF(25f, 17f);
		((XRControl)xrLabel72).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel72).StylePriority.UseFont = false;
		((XRControl)xrLabel72).Text = "UF";
		((XRControl)xrTranspUF).BorderWidth = 0f;
		((XRControl)xrTranspUF).LocationFloat = new PointFloat(574f, 51f);
		((XRControl)xrTranspUF).Name = "xrTranspUF";
		((XRControl)xrTranspUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspUF).SizeF = new SizeF(25f, 12f);
		((XRControl)xrTranspUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspUF).Text = "SP";
		((XRControl)xrLabel74).BorderWidth = 0f;
		((XRControl)xrLabel74).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel74).LocationFloat = new PointFloat(566f, 43f);
		((XRControl)xrLabel74).Name = "xrLabel74";
		((XRControl)xrLabel74).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel74).SizeF = new SizeF(25f, 17f);
		((XRControl)xrLabel74).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel74).StylePriority.UseFont = false;
		((XRControl)xrLabel74).Text = "UF";
		((XRControl)xrLabel75).BorderWidth = 0f;
		((XRControl)xrLabel75).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel75).LocationFloat = new PointFloat(399f, 1f);
		((XRControl)xrLabel75).Name = "xrLabel75";
		((XRControl)xrLabel75).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel75).SizeF = new SizeF(75f, 17f);
		((XRControl)xrLabel75).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel75).StylePriority.UseFont = false;
		((XRControl)xrLabel75).Text = "CÓDIGO ANTT";
		((XRControl)xrTranspANTT).BorderWidth = 0f;
		((XRControl)xrTranspANTT).LocationFloat = new PointFloat(399f, 18f);
		((XRControl)xrTranspANTT).Name = "xrTranspANTT";
		((XRControl)xrTranspANTT).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspANTT).SizeF = new SizeF(67f, 17f);
		((XRControl)xrTranspANTT).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel79).BorderWidth = 0f;
		((XRControl)xrLabel79).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel79).LocationFloat = new PointFloat(291f, 1f);
		((XRControl)xrLabel79).Name = "xrLabel79";
		((XRControl)xrLabel79).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel79).SizeF = new SizeF(108f, 17f);
		((XRControl)xrLabel79).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel79).StylePriority.UseFont = false;
		((XRControl)xrLabel79).Text = "FRETE POR CONTA";
		((XRControl)xrTranspPagoPor).Borders = (BorderSide)0;
		((XRControl)xrTranspPagoPor).BorderWidth = 1f;
		((XRControl)xrTranspPagoPor).CanGrow = false;
		((XRControl)xrTranspPagoPor).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrTranspPagoPor).LocationFloat = new PointFloat(291f, 14f);
		((XRControl)xrTranspPagoPor).Name = "xrTranspPagoPor";
		((XRControl)xrTranspPagoPor).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPagoPor).SizeF = new SizeF(101f, 22f);
		((XRControl)xrTranspPagoPor).StylePriority.UseBorders = false;
		((XRControl)xrTranspPagoPor).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspPagoPor).StylePriority.UseFont = false;
		((XRControl)xrTranspPagoPor).StylePriority.UseTextAlignment = false;
		((XRControl)xrTranspPagoPor).Text = "1";
		((XRControl)xrTranspPagoPor).TextAlignment = (TextAlignment)16;
		((XRControl)xrLine27).Borders = (BorderSide)0;
		xrLine27.LineDirection = (LineDirection)3;
		((XRControl)xrLine27).LocationFloat = new PointFloat(282f, 1f);
		((XRControl)xrLine27).Name = "xrLine27";
		((XRControl)xrLine27).SizeF = new SizeF(9f, 39f);
		((XRControl)xrLine27).StylePriority.UseBorders = false;
		((XRControl)xrTranspNumeracao).BorderWidth = 0f;
		((XRControl)xrTranspNumeracao).LocationFloat = new PointFloat(383f, 92f);
		((XRControl)xrTranspNumeracao).Name = "xrTranspNumeracao";
		((XRControl)xrTranspNumeracao).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspNumeracao).SizeF = new SizeF(92f, 12f);
		((XRControl)xrTranspNumeracao).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel48).BorderWidth = 0f;
		((XRControl)xrLabel48).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel48).LocationFloat = new PointFloat(332f, 76f);
		((XRControl)xrLabel48).Name = "xrLabel48";
		((XRControl)xrLabel48).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel48).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel48).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel48).StylePriority.UseFont = false;
		((XRControl)xrLabel48).Text = "NUMERAÇÃO";
		((XRControl)xrLine35).Borders = (BorderSide)0;
		xrLine35.LineDirection = (LineDirection)3;
		((XRControl)xrLine35).LocationFloat = new PointFloat(316f, 76f);
		((XRControl)xrLine35).Name = "xrLine35";
		((XRControl)xrLine35).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine35).StylePriority.UseBorders = false;
		((XRControl)xrLabel50).BorderWidth = 0f;
		((XRControl)xrLabel50).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel50).LocationFloat = new PointFloat(107f, 75f);
		((XRControl)xrLabel50).Name = "xrLabel50";
		((XRControl)xrLabel50).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel50).SizeF = new SizeF(110f, 17f);
		((XRControl)xrLabel50).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel50).StylePriority.UseFont = false;
		((XRControl)xrLabel50).Text = "ESPÉCIE";
		((XRControl)xrTranspEspecie).BorderWidth = 0f;
		((XRControl)xrTranspEspecie).LocationFloat = new PointFloat(108f, 92f);
		((XRControl)xrTranspEspecie).Name = "xrTranspEspecie";
		((XRControl)xrTranspEspecie).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspEspecie).SizeF = new SizeF(92f, 12f);
		((XRControl)xrTranspEspecie).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspEspecie).Text = "VOLUMES";
		((XRControl)xrLine36).Borders = (BorderSide)0;
		xrLine36.LineDirection = (LineDirection)3;
		((XRControl)xrLine36).LocationFloat = new PointFloat(92f, 72f);
		((XRControl)xrLine36).Name = "xrLine36";
		((XRControl)xrLine36).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine36).StylePriority.UseBorders = false;
		((XRControl)xrLabel62).BorderWidth = 0f;
		((XRControl)xrLabel62).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel62).LocationFloat = new PointFloat(232f, 75f);
		((XRControl)xrLabel62).Name = "xrLabel62";
		((XRControl)xrLabel62).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel62).SizeF = new SizeF(50f, 17f);
		((XRControl)xrLabel62).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel62).StylePriority.UseFont = false;
		((XRControl)xrLabel62).Text = "MARCA";
		((XRControl)xrTranspMarca).BorderWidth = 0f;
		((XRControl)xrTranspMarca).LocationFloat = new PointFloat(233f, 92f);
		((XRControl)xrTranspMarca).Name = "xrTranspMarca";
		((XRControl)xrTranspMarca).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspMarca).SizeF = new SizeF(92f, 12f);
		((XRControl)xrTranspMarca).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine37).Borders = (BorderSide)0;
		xrLine37.LineDirection = (LineDirection)3;
		((XRControl)xrLine37).LocationFloat = new PointFloat(217f, 72f);
		((XRControl)xrLine37).Name = "xrLine37";
		((XRControl)xrLine37).SizeF = new SizeF(9f, 38f);
		((XRControl)xrLine37).StylePriority.UseBorders = false;
		((XRControl)xrLabel128).BorderWidth = 0f;
		((XRControl)xrLabel128).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel128).LocationFloat = new PointFloat(8f, 246f);
		((XRControl)xrLabel128).Name = "xrLabel128";
		((XRControl)xrLabel128).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel128).SizeF = new SizeF(112f, 17f);
		((XRControl)xrLabel128).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel128).StylePriority.UseFont = false;
		((XRControl)xrLabel128).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrEmitenteIE2).BorderWidth = 0f;
		((XRControl)xrEmitenteIE2).CanGrow = false;
		((XRControl)xrEmitenteIE2).LocationFloat = new PointFloat(8f, 263f);
		((XRControl)xrEmitenteIE2).Name = "xrEmitenteIE2";
		((XRControl)xrEmitenteIE2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteIE2).SizeF = new SizeF(110f, 17f);
		((XRControl)xrEmitenteIE2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteIE2).Text = "244.669.501.115";
		((XRControl)xrPanel15).BorderWidth = 1f;
		((XRControl)xrPanel15).CanGrow = false;
		((XRControl)xrPanel15).Controls.AddRange((XRControl[])(object)new XRControl[14]
		{
			(XRControl)xrLine40,
			(XRControl)xrLine41,
			(XRControl)xrLabel117,
			(XRControl)xrEmitenteCNPJ2,
			(XRControl)xrLabel119,
			(XRControl)xrEmitenteInscST2,
			(XRControl)xrLine42,
			(XRControl)xrProtocolo2,
			(XRControl)xrLabel122,
			(XRControl)xrChave2,
			(XRControl)xrLabel124,
			(XRControl)xrLine43,
			(XRControl)xrNatOp2,
			(XRControl)xrLabel126
		});
		((XRControl)xrPanel15).LocationFloat = new PointFloat(1f, 204f);
		((XRControl)xrPanel15).Name = "xrPanel15";
		((XRControl)xrPanel15).SizeF = new SizeF(724f, 75f);
		((XRControl)xrPanel15).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine40).Borders = (BorderSide)0;
		xrLine40.LineDirection = (LineDirection)3;
		((XRControl)xrLine40).LocationFloat = new PointFloat(116f, 38f);
		((XRControl)xrLine40).Name = "xrLine40";
		((XRControl)xrLine40).SizeF = new SizeF(8f, 36f);
		((XRControl)xrLine40).StylePriority.UseBorders = false;
		((XRControl)xrLine41).Borders = (BorderSide)0;
		xrLine41.LineDirection = (LineDirection)3;
		((XRControl)xrLine41).LocationFloat = new PointFloat(220f, 38f);
		((XRControl)xrLine41).Name = "xrLine41";
		((XRControl)xrLine41).SizeF = new SizeF(8f, 40f);
		((XRControl)xrLine41).StylePriority.UseBorders = false;
		((XRControl)xrLabel117).BorderWidth = 0f;
		((XRControl)xrLabel117).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel117).LocationFloat = new PointFloat(229f, 41f);
		((XRControl)xrLabel117).Name = "xrLabel117";
		((XRControl)xrLabel117).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel117).SizeF = new SizeF(51f, 17f);
		((XRControl)xrLabel117).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel117).StylePriority.UseFont = false;
		((XRControl)xrLabel117).Text = "CNPJ";
		((XRControl)xrEmitenteCNPJ2).BorderWidth = 0f;
		((XRControl)xrEmitenteCNPJ2).LocationFloat = new PointFloat(227f, 56f);
		((XRControl)xrEmitenteCNPJ2).Name = "xrEmitenteCNPJ2";
		((XRControl)xrEmitenteCNPJ2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteCNPJ2).SizeF = new SizeF(115f, 17f);
		((XRControl)xrEmitenteCNPJ2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteCNPJ2).Text = "07.577.462/0001-15";
		((XRControl)xrLabel119).BorderWidth = 0f;
		((XRControl)xrLabel119).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel119).LocationFloat = new PointFloat(127f, 42f);
		((XRControl)xrLabel119).Name = "xrLabel119";
		((XRControl)xrLabel119).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel119).SizeF = new SizeF(91f, 17f);
		((XRControl)xrLabel119).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel119).StylePriority.UseFont = false;
		((XRControl)xrLabel119).Text = "INSC. SUBST. TRIB.";
		((XRControl)xrEmitenteInscST2).BorderWidth = 0f;
		((XRControl)xrEmitenteInscST2).LocationFloat = new PointFloat(125f, 58f);
		((XRControl)xrEmitenteInscST2).Name = "xrEmitenteInscST2";
		((XRControl)xrEmitenteInscST2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteInscST2).SizeF = new SizeF(97f, 14f);
		((XRControl)xrEmitenteInscST2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteInscST2).Text = "244.669.501.115";
		((XRControl)xrLine42).Borders = (BorderSide)0;
		xrLine42.LineDirection = (LineDirection)3;
		((XRControl)xrLine42).LocationFloat = new PointFloat(341f, 0f);
		((XRControl)xrLine42).Name = "xrLine42";
		((XRControl)xrLine42).SizeF = new SizeF(9f, 75f);
		((XRControl)xrLine42).StylePriority.UseBorders = false;
		((XRControl)xrProtocolo2).BorderWidth = 0f;
		((XRControl)xrProtocolo2).LocationFloat = new PointFloat(349f, 17f);
		((XRControl)xrProtocolo2).Name = "xrProtocolo2";
		((XRControl)xrProtocolo2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProtocolo2).SizeF = new SizeF(330f, 17f);
		((XRControl)xrProtocolo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrProtocolo2).Text = "xrNatOp";
		((XRControl)xrLabel122).BorderWidth = 0f;
		((XRControl)xrLabel122).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel122).LocationFloat = new PointFloat(349f, 0f);
		((XRControl)xrLabel122).Name = "xrLabel122";
		((XRControl)xrLabel122).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel122).SizeF = new SizeF(166f, 17f);
		((XRControl)xrLabel122).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel122).StylePriority.UseFont = false;
		((XRControl)xrLabel122).Text = "PROTOCOLO DE AUTORIZAÇÃO";
		((XRControl)xrChave2).BorderWidth = 0f;
		((XRControl)xrChave2).LocationFloat = new PointFloat(349f, 58f);
		((XRControl)xrChave2).Name = "xrChave2";
		((XRControl)xrChave2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrChave2).SizeF = new SizeF(367f, 17f);
		((XRControl)xrChave2).StylePriority.UseBorderWidth = false;
		((XRControl)xrChave2).Text = "xrNatOp";
		((XRControl)xrLabel124).BorderWidth = 0f;
		((XRControl)xrLabel124).Font = new Font("Times New Roman", 5f);
		((XRControl)xrLabel124).LocationFloat = new PointFloat(349f, 42f);
		((XRControl)xrLabel124).Name = "xrLabel124";
		((XRControl)xrLabel124).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel124).SizeF = new SizeF(330f, 17f);
		((XRControl)xrLabel124).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel124).StylePriority.UseFont = false;
		((XRControl)xrLabel124).Text = "CHAVE DE ACESSO DA NF-  CONSULTA DE AUTENTICIDADE NO SITE WWW.NFE.FAZENDA.GOV.BR";
		((XRControl)xrLine43).Borders = (BorderSide)0;
		((XRControl)xrLine43).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLine43).Name = "xrLine43";
		((XRControl)xrLine43).SizeF = new SizeF(721f, 9f);
		((XRControl)xrLine43).StylePriority.UseBorders = false;
		((XRControl)xrNatOp2).BorderWidth = 0f;
		((XRControl)xrNatOp2).CanGrow = false;
		((XRControl)xrNatOp2).LocationFloat = new PointFloat(8f, 17f);
		((XRControl)xrNatOp2).Name = "xrNatOp2";
		((XRControl)xrNatOp2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNatOp2).SizeF = new SizeF(333f, 17f);
		((XRControl)xrNatOp2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel126).BorderWidth = 0f;
		((XRControl)xrLabel126).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel126).LocationFloat = new PointFloat(8f, 6f);
		((XRControl)xrLabel126).Name = "xrLabel126";
		((XRControl)xrLabel126).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel126).SizeF = new SizeF(192f, 17f);
		((XRControl)xrLabel126).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel126).StylePriority.UseFont = false;
		((XRControl)xrLabel126).Text = "NATUREZA DA OPERAÇÃO";
		((XRControl)xrLabel116).BorderWidth = 0f;
		((XRControl)xrLabel116).LocationFloat = new PointFloat(233f, 183f);
		((XRControl)xrLabel116).Name = "xrLabel116";
		((XRControl)xrLabel116).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel116).SizeF = new SizeF(33f, 16f);
		((XRControl)xrLabel116).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel116).Text = "FLS:";
		((XRControl)xrPageInfo2).BorderWidth = 0f;
		((XRControl)xrPageInfo2).LocationFloat = new PointFloat(258f, 183f);
		((XRControl)xrPageInfo2).Name = "xrPageInfo2";
		((XRControl)xrPageInfo2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPageInfo2).SizeF = new SizeF(42f, 16f);
		((XRControl)xrPageInfo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrPageInfo2).StylePriority.UseTextAlignment = false;
		((XRControl)xrPageInfo2).TextAlignment = (TextAlignment)4;
		((XRControl)xrSerieNFe2).BorderWidth = 0f;
		((XRControl)xrSerieNFe2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrSerieNFe2).LocationFloat = new PointFloat(225f, 167f);
		((XRControl)xrSerieNFe2).Name = "xrSerieNFe2";
		((XRControl)xrSerieNFe2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNFe2).SizeF = new SizeF(92f, 17f);
		((XRControl)xrSerieNFe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNFe2).StylePriority.UseFont = false;
		((XRControl)xrSerieNFe2).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNFe2).Text = "SÉRIE 1";
		((XRControl)xrSerieNFe2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel114).BorderWidth = 0f;
		((XRControl)xrLabel114).LocationFloat = new PointFloat(225f, 150f);
		((XRControl)xrLabel114).Name = "xrLabel114";
		((XRControl)xrLabel114).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel114).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel114).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel114).Text = "N.";
		((XRControl)xrNroNF2).BorderWidth = 0f;
		((XRControl)xrNroNF2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrNroNF2).LocationFloat = new PointFloat(242f, 150f);
		((XRControl)xrNroNF2).Name = "xrNroNF2";
		((XRControl)xrNroNF2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNF2).SizeF = new SizeF(77f, 17f);
		((XRControl)xrNroNF2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNF2).StylePriority.UseFont = false;
		((XRControl)xrNroNF2).Text = "000.000.000";
		((XRControl)xrPanel14).BorderWidth = 1f;
		((XRControl)xrPanel14).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrES2 });
		((XRControl)xrPanel14).LocationFloat = new PointFloat(283f, 117f);
		((XRControl)xrPanel14).Name = "xrPanel14";
		((XRControl)xrPanel14).SizeF = new SizeF(25f, 29f);
		((XRControl)xrPanel14).StylePriority.UseBorderWidth = false;
		((XRControl)xrES2).BorderWidth = 0f;
		((XRControl)xrES2).Font = new Font("Times New Roman", 12f, FontStyle.Bold);
		((XRControl)xrES2).LocationFloat = new PointFloat(0f, 6f);
		((XRControl)xrES2).Name = "xrES2";
		((XRControl)xrES2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrES2).SizeF = new SizeF(25f, 25f);
		((XRControl)xrES2).StylePriority.UseBorderWidth = false;
		((XRControl)xrES2).StylePriority.UseFont = false;
		((XRControl)xrES2).StylePriority.UseTextAlignment = false;
		((XRControl)xrES2).Text = "1";
		((XRControl)xrES2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel111).BorderWidth = 0f;
		((XRControl)xrLabel111).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel111).LocationFloat = new PointFloat(208f, 133f);
		((XRControl)xrLabel111).Name = "xrLabel111";
		((XRControl)xrLabel111).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel111).SizeF = new SizeF(65f, 17f);
		((XRControl)xrLabel111).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel111).StylePriority.UseFont = false;
		((XRControl)xrLabel111).Text = "1 - Saída";
		((XRControl)xrLabel110).BorderWidth = 0f;
		((XRControl)xrLabel110).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel110).LocationFloat = new PointFloat(208f, 117f);
		((XRControl)xrLabel110).Name = "xrLabel110";
		((XRControl)xrLabel110).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel110).SizeF = new SizeF(65f, 17f);
		((XRControl)xrLabel110).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel110).StylePriority.UseFont = false;
		((XRControl)xrLabel110).Text = "0 - Entrada";
		((XRControl)xrLabel109).BorderWidth = 0f;
		((XRControl)xrLabel109).Font = new Font("Times New Roman", 8f);
		((XRControl)xrLabel109).LocationFloat = new PointFloat(208f, 92f);
		((XRControl)xrLabel109).Name = "xrLabel109";
		((XRControl)xrLabel109).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel109).SizeF = new SizeF(117f, 33f);
		((XRControl)xrLabel109).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel109).StylePriority.UseFont = false;
		((XRControl)xrLabel109).Text = "Documento Auxiliar de Nota Fiscal Eletrônica";
		((XRControl)xrLabel108).BorderWidth = 0f;
		((XRControl)xrLabel108).Font = new Font("Times New Roman", 12f, FontStyle.Bold);
		((XRControl)xrLabel108).LocationFloat = new PointFloat(208f, 75f);
		((XRControl)xrLabel108).Name = "xrLabel108";
		((XRControl)xrLabel108).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel108).SizeF = new SizeF(113f, 25f);
		((XRControl)xrLabel108).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel108).StylePriority.UseFont = false;
		((XRControl)xrLabel108).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel108).Text = "DANFE";
		((XRControl)xrLabel108).TextAlignment = (TextAlignment)2;
		((XRControl)xrPanel13).BorderWidth = 1f;
		((XRControl)xrPanel13).Controls.AddRange((XRControl[])(object)new XRControl[2]
		{
			(XRControl)xrLabel107,
			(XRControl)xrChaveAcesso2
		});
		((XRControl)xrPanel13).LocationFloat = new PointFloat(324f, 79f);
		((XRControl)xrPanel13).Name = "xrPanel13";
		((XRControl)xrPanel13).SizeF = new SizeF(400f, 120f);
		((XRControl)xrPanel13).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel107).BorderWidth = 0f;
		((XRControl)xrLabel107).Font = new Font("Times New Roman", 6f);
		((XRControl)xrLabel107).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel107).Name = "xrLabel107";
		((XRControl)xrLabel107).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel107).SizeF = new SizeF(92f, 25f);
		((XRControl)xrLabel107).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel107).StylePriority.UseFont = false;
		((XRControl)xrLabel107).Text = "CONTROLE DO FISCO";
		xrChaveAcesso2.AutoModule = true;
		((XRControl)xrChaveAcesso2).BorderWidth = 0f;
		((XRControl)xrChaveAcesso2).LocationFloat = new PointFloat(30f, 25f);
		((XRControl)xrChaveAcesso2).Name = "xrChaveAcesso2";
		((XRControl)xrChaveAcesso2).Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrChaveAcesso2.ShowText = false;
		((XRControl)xrChaveAcesso2).SizeF = new SizeF(344f, 80f);
		((XRControl)xrChaveAcesso2).StylePriority.UseBorderWidth = false;
		val2.CharacterSet = (Code128Charset)105;
		xrChaveAcesso2.Symbology = (BarCodeGeneratorBase)(object)val2;
		((XRControl)xrChaveAcesso2).Text = "0115550010000000180405822968";
		((XRControl)xrPanel12).BorderWidth = 1f;
		((XRControl)xrPanel12).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrRazaoSocialEmitente2,
			(XRControl)xrEnderecoEmitente2,
			(XRControl)xrEnderecoEmitenteBairro2,
			(XRControl)xrEmitenteEnderecoCidade2,
			(XRControl)xrEmitenteTelefone2,
			(XRControl)xrLogo2
		});
		((XRControl)xrPanel12).LocationFloat = new PointFloat(1f, 79f);
		((XRControl)xrPanel12).Name = "xrPanel12";
		((XRControl)xrPanel12).SizeF = new SizeF(199f, 120f);
		((XRControl)xrPanel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).BorderWidth = 0f;
		((XRControl)xrRazaoSocialEmitente2).Font = new Font("Times New Roman", 9f, FontStyle.Bold);
		((XRControl)xrRazaoSocialEmitente2).LocationFloat = new PointFloat(10f, 49f);
		xrRazaoSocialEmitente2.Multiline = true;
		((XRControl)xrRazaoSocialEmitente2).Name = "xrRazaoSocialEmitente2";
		((XRControl)xrRazaoSocialEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrRazaoSocialEmitente2).SizeF = new SizeF(183f, 15f);
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseFont = false;
		((XRControl)xrRazaoSocialEmitente2).Text = "R.Castro Cia Ltda.";
		((XRControl)xrEnderecoEmitente2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitente2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitente2).LocationFloat = new PointFloat(9f, 65f);
		((XRControl)xrEnderecoEmitente2).Name = "xrEnderecoEmitente2";
		((XRControl)xrEnderecoEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitente2).SizeF = new SizeF(182f, 12f);
		((XRControl)xrEnderecoEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitente2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitente2).Text = "Avenida Ferraz Alvim, 622";
		((XRControl)xrEnderecoEmitenteBairro2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitenteBairro2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitenteBairro2).LocationFloat = new PointFloat(9f, 77f);
		((XRControl)xrEnderecoEmitenteBairro2).Name = "xrEnderecoEmitenteBairro2";
		((XRControl)xrEnderecoEmitenteBairro2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitenteBairro2).SizeF = new SizeF(182f, 12f);
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitenteBairro2).Text = "Jardim Ruyce - CEP 09961-550";
		((XRControl)xrEmitenteEnderecoCidade2).BorderWidth = 0f;
		((XRControl)xrEmitenteEnderecoCidade2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteEnderecoCidade2).LocationFloat = new PointFloat(9f, 88f);
		((XRControl)xrEmitenteEnderecoCidade2).Name = "xrEmitenteEnderecoCidade2";
		((XRControl)xrEmitenteEnderecoCidade2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteEnderecoCidade2).SizeF = new SizeF(182f, 12f);
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteEnderecoCidade2).Text = "Diadema - SP";
		((XRControl)xrEmitenteTelefone2).BorderWidth = 0f;
		((XRControl)xrEmitenteTelefone2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteTelefone2).LocationFloat = new PointFloat(9f, 100f);
		((XRControl)xrEmitenteTelefone2).Name = "xrEmitenteTelefone2";
		((XRControl)xrEmitenteTelefone2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteTelefone2).SizeF = new SizeF(100f, 12f);
		((XRControl)xrEmitenteTelefone2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteTelefone2).Text = "(11) 4067-1130";
		((XRControl)xrLogo2).BorderWidth = 0f;
		xrLogo2.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrLogo2.ImageSource"));
		((XRControl)xrLogo2).LocationFloat = new PointFloat(7f, 0f);
		((XRControl)xrLogo2).Name = "xrLogo2";
		((XRControl)xrLogo2).SizeF = new SizeF(112f, 50f);
		xrLogo2.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine39).BorderWidth = 0f;
		xrLine39.LineStyle = DashStyle.Dash;
		((XRControl)xrLine39).LocationFloat = new PointFloat(0f, 67f);
		((XRControl)xrLine39).Name = "xrLine39";
		((XRControl)xrLine39).SizeF = new SizeF(725f, 8f);
		((XRControl)xrLine39).StylePriority.UseBorderWidth = false;
		((XRControl)xrPanel11).BorderWidth = 1f;
		((XRControl)xrPanel11).Controls.AddRange((XRControl[])(object)new XRControl[10]
		{
			(XRControl)xrLabel83,
			(XRControl)xrShape4,
			(XRControl)xrShape5,
			(XRControl)xrRecebemosDe2,
			(XRControl)xrShape6,
			(XRControl)xrLabel97,
			(XRControl)xrLabel98,
			(XRControl)xrLabel99,
			(XRControl)xrNroNFe2,
			(XRControl)xrSerieNF2
		});
		((XRControl)xrPanel11).LocationFloat = new PointFloat(1f, 0f);
		((XRControl)xrPanel11).Name = "xrPanel11";
		((XRControl)xrPanel11).SizeF = new SizeF(724f, 67f);
		((XRControl)xrPanel11).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel83).BorderWidth = 0f;
		((XRControl)xrLabel83).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel83).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLabel83).Name = "xrLabel83";
		((XRControl)xrLabel83).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel83).SizeF = new SizeF(129f, 25f);
		((XRControl)xrLabel83).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel83).StylePriority.UseFont = false;
		((XRControl)xrLabel83).Text = "DATA DE RECEBIMENTO";
		((XRControl)xrShape4).BorderWidth = 0f;
		((XRControl)xrShape4).LocationFloat = new PointFloat(624f, 0f);
		((XRControl)xrShape4).Name = "xrShape4";
		xrShape4.Shape = (ShapeBase)(object)shape4;
		((XRControl)xrShape4).SizeF = new SizeF(2f, 67f);
		((XRControl)xrShape4).StylePriority.UseBorderWidth = false;
		xrShape5.Angle = 270;
		((XRControl)xrShape5).BorderWidth = 0f;
		((XRControl)xrShape5).LocationFloat = new PointFloat(0f, 25f);
		((XRControl)xrShape5).Name = "xrShape5";
		xrShape5.Shape = (ShapeBase)(object)shape5;
		((XRControl)xrShape5).SizeF = new SizeF(624f, 2f);
		((XRControl)xrShape5).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe2).BorderWidth = 0f;
		((XRControl)xrRecebemosDe2).Font = new Font("Times New Roman", 6f);
		((XRControl)xrRecebemosDe2).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrRecebemosDe2).Name = "xrRecebemosDe2";
		((XRControl)xrRecebemosDe2).Padding = new PaddingInfo(4, 2, 4, 0, 100f);
		((XRControl)xrRecebemosDe2).SizeF = new SizeF(633f, 25f);
		((XRControl)xrRecebemosDe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe2).StylePriority.UseFont = false;
		((XRControl)xrRecebemosDe2).StylePriority.UsePadding = false;
		((XRControl)xrRecebemosDe2).Text = "RECEBEMOS DE EDILSON VASCONCELOS DE MELO JUNIOR OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA AO LADO";
		((XRControl)xrShape6).BorderWidth = 0f;
		((XRControl)xrShape6).LocationFloat = new PointFloat(125f, 25f);
		((XRControl)xrShape6).Name = "xrShape6";
		xrShape6.Shape = (ShapeBase)(object)shape6;
		((XRControl)xrShape6).SizeF = new SizeF(8f, 42f);
		((XRControl)xrShape6).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel97).BorderWidth = 0f;
		((XRControl)xrLabel97).Font = new Font("Times New Roman", 7f);
		((XRControl)xrLabel97).LocationFloat = new PointFloat(142f, 33f);
		((XRControl)xrLabel97).Name = "xrLabel97";
		((XRControl)xrLabel97).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel97).SizeF = new SizeF(258f, 25f);
		((XRControl)xrLabel97).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel97).StylePriority.UseFont = false;
		((XRControl)xrLabel97).Text = "IDENTIFICAÇÃO E ASSINATURA DO RECEBEDOR";
		((XRControl)xrLabel98).BorderWidth = 0f;
		((XRControl)xrLabel98).LocationFloat = new PointFloat(639f, 8f);
		((XRControl)xrLabel98).Name = "xrLabel98";
		((XRControl)xrLabel98).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel98).SizeF = new SizeF(74f, 18f);
		((XRControl)xrLabel98).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel98).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel98).Text = "NF-e";
		((XRControl)xrLabel98).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel99).BorderWidth = 0f;
		((XRControl)xrLabel99).LocationFloat = new PointFloat(630f, 25f);
		((XRControl)xrLabel99).Name = "xrLabel99";
		((XRControl)xrLabel99).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel99).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel99).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel99).Text = "N.";
		((XRControl)xrNroNFe2).BorderWidth = 0f;
		((XRControl)xrNroNFe2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrNroNFe2).LocationFloat = new PointFloat(647f, 25f);
		((XRControl)xrNroNFe2).Name = "xrNroNFe2";
		((XRControl)xrNroNFe2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNFe2).SizeF = new SizeF(72f, 17f);
		((XRControl)xrNroNFe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNFe2).StylePriority.UseFont = false;
		((XRControl)xrNroNFe2).Text = "000.000.000";
		((XRControl)xrSerieNF2).BorderWidth = 0f;
		((XRControl)xrSerieNF2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrSerieNF2).LocationFloat = new PointFloat(639f, 42f);
		((XRControl)xrSerieNF2).Name = "xrSerieNF2";
		((XRControl)xrSerieNF2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNF2).SizeF = new SizeF(82f, 17f);
		((XRControl)xrSerieNF2).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNF2).StylePriority.UseFont = false;
		((XRControl)xrSerieNF2).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNF2).Text = "SÉRIE 1";
		((XRControl)xrSerieNF2).TextAlignment = (TextAlignment)2;
		((XRControl)xrPanel23).BackColor = Color.LightGray;
		((XRControl)xrPanel23).Borders = (BorderSide)15;
		((XRControl)xrPanel23).BorderWidth = 1f;
		((XRControl)xrPanel23).CanGrow = false;
		((XRControl)xrPanel23).Controls.AddRange((XRControl[])(object)new XRControl[12]
		{
			(XRControl)xrLabel234,
			(XRControl)xrLabel223,
			(XRControl)xrLabel224,
			(XRControl)xrLabel225,
			(XRControl)xrLabel226,
			(XRControl)xrLabel227,
			(XRControl)xrLabel228,
			(XRControl)xrLabel229,
			(XRControl)xrLabel230,
			(XRControl)xrLabel231,
			(XRControl)xrLabel232,
			(XRControl)xrLabel233
		});
		((XRControl)xrPanel23).LocationFloat = new PointFloat(0f, 738f);
		((XRControl)xrPanel23).Name = "xrPanel23";
		((XRControl)xrPanel23).SizeF = new SizeF(723f, 25f);
		((XRControl)xrPanel23).StylePriority.UseBackColor = false;
		((XRControl)xrPanel23).StylePriority.UseBorders = false;
		((XRControl)xrPanel23).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel234).Borders = (BorderSide)1;
		((XRControl)xrLabel234).BorderWidth = 1f;
		((XRControl)xrLabel234).LocationFloat = new PointFloat(49f, 1f);
		((XRControl)xrLabel234).Name = "xrLabel234";
		((XRControl)xrLabel234).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel234).SizeF = new SizeF(192f, 25f);
		((XRControl)xrLabel234).StylePriority.UseBorders = false;
		((XRControl)xrLabel234).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel234).Text = "Produto";
		((XRControl)xrLabel223).Borders = (BorderSide)1;
		((XRControl)xrLabel223).LocationFloat = new PointFloat(691f, 0f);
		((XRControl)xrLabel223).Name = "xrLabel223";
		((XRControl)xrLabel223).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel223).SizeF = new SizeF(30f, 25f);
		((XRControl)xrLabel223).StylePriority.UseBorders = false;
		((XRControl)xrLabel223).Text = "Aliq.";
		((XRControl)xrLabel224).Borders = (BorderSide)1;
		((XRControl)xrLabel224).LocationFloat = new PointFloat(641f, 0f);
		((XRControl)xrLabel224).Name = "xrLabel224";
		((XRControl)xrLabel224).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel224).SizeF = new SizeF(41f, 25f);
		((XRControl)xrLabel224).StylePriority.UseBorders = false;
		((XRControl)xrLabel224).Text = "ICMS";
		((XRControl)xrLabel225).Borders = (BorderSide)1;
		((XRControl)xrLabel225).LocationFloat = new PointFloat(582f, 0f);
		((XRControl)xrLabel225).Name = "xrLabel225";
		((XRControl)xrLabel225).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel225).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel225).StylePriority.UseBorders = false;
		((XRControl)xrLabel225).Text = "B ICMS";
		((XRControl)xrLabel226).Borders = (BorderSide)1;
		((XRControl)xrLabel226).LocationFloat = new PointFloat(516f, 0f);
		((XRControl)xrLabel226).Name = "xrLabel226";
		((XRControl)xrLabel226).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel226).SizeF = new SizeF(67f, 25f);
		((XRControl)xrLabel226).StylePriority.UseBorders = false;
		((XRControl)xrLabel226).Text = "V.Total";
		((XRControl)xrLabel227).Borders = (BorderSide)1;
		((XRControl)xrLabel227).LocationFloat = new PointFloat(457f, 0f);
		((XRControl)xrLabel227).Name = "xrLabel227";
		((XRControl)xrLabel227).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel227).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel227).StylePriority.UseBorders = false;
		((XRControl)xrLabel227).Text = "V.Unit.";
		((XRControl)xrLabel228).Borders = (BorderSide)1;
		((XRControl)xrLabel228).LocationFloat = new PointFloat(391f, 0f);
		((XRControl)xrLabel228).Name = "xrLabel228";
		((XRControl)xrLabel228).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel228).SizeF = new SizeF(67f, 25f);
		((XRControl)xrLabel228).StylePriority.UseBorders = false;
		((XRControl)xrLabel228).Text = "Quant.";
		((XRControl)xrLabel229).Borders = (BorderSide)1;
		((XRControl)xrLabel229).LocationFloat = new PointFloat(366f, 0f);
		((XRControl)xrLabel229).Name = "xrLabel229";
		((XRControl)xrLabel229).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel229).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel229).StylePriority.UseBorders = false;
		((XRControl)xrLabel229).Text = "UN";
		((XRControl)xrLabel230).Borders = (BorderSide)1;
		((XRControl)xrLabel230).LocationFloat = new PointFloat(324f, 0f);
		((XRControl)xrLabel230).Name = "xrLabel230";
		((XRControl)xrLabel230).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel230).SizeF = new SizeF(42f, 25f);
		((XRControl)xrLabel230).StylePriority.UseBorders = false;
		((XRControl)xrLabel230).Text = "CFOP";
		((XRControl)xrLabel231).Borders = (BorderSide)1;
		((XRControl)xrLabel231).LocationFloat = new PointFloat(299f, 0f);
		((XRControl)xrLabel231).Name = "xrLabel231";
		((XRControl)xrLabel231).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel231).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel231).StylePriority.UseBorders = false;
		((XRControl)xrLabel231).Text = "ST";
		((XRControl)xrLabel232).Borders = (BorderSide)1;
		((XRControl)xrLabel232).LocationFloat = new PointFloat(241f, 0f);
		((XRControl)xrLabel232).Name = "xrLabel232";
		((XRControl)xrLabel232).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel232).SizeF = new SizeF(58f, 25f);
		((XRControl)xrLabel232).StylePriority.UseBorders = false;
		((XRControl)xrLabel232).Text = "NCM";
		((XRControl)xrLabel233).Borders = (BorderSide)0;
		((XRControl)xrLabel233).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel233).Name = "xrLabel233";
		((XRControl)xrLabel233).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel233).SizeF = new SizeF(49f, 25f);
		((XRControl)xrLabel233).StylePriority.UseBorders = false;
		((XRControl)xrLabel233).Text = "Código";
		((XRControl)xrCrossBandBox1).AnchorVertical = (VerticalAnchorStyles)3;
		((XRControl)xrCrossBandBox1).BorderWidth = 1f;
		((XRCrossBandControl)xrCrossBandBox1).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandBox1).EndPointFloat = new PointFloat(1f, 2f);
		((XRControl)xrCrossBandBox1).Name = "xrCrossBandBox1";
		((XRCrossBandControl)xrCrossBandBox1).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandBox1).StartPointFloat = new PointFloat(1f, 308f);
		((XRControl)xrCrossBandBox1).WidthF = 722f;
		((XRControl)xrCrossBandLine1).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine1).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine1).EndPointFloat = new PointFloat(50f, 2f);
		((XRControl)xrCrossBandLine1).Name = "xrCrossBandLine1";
		((XRCrossBandControl)xrCrossBandLine1).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine1).StartPointFloat = new PointFloat(50f, 308f);
		((XRControl)xrCrossBandLine1).WidthF = 1f;
		((XRControl)xrCrossBandLine2).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine2).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine2).EndPointFloat = new PointFloat(642f, 2f);
		((XRControl)xrCrossBandLine2).Name = "xrCrossBandLine2";
		((XRCrossBandControl)xrCrossBandLine2).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine2).StartPointFloat = new PointFloat(642f, 308f);
		((XRControl)xrCrossBandLine2).WidthF = 1f;
		((XRControl)xrCrossBandLine3).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine3).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine3).EndPointFloat = new PointFloat(692f, 2f);
		((XRControl)xrCrossBandLine3).Name = "xrCrossBandLine3";
		((XRCrossBandControl)xrCrossBandLine3).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine3).StartPointFloat = new PointFloat(692f, 308f);
		((XRControl)xrCrossBandLine3).WidthF = 1f;
		((XRControl)xrCrossBandLine4).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine4).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine4).EndPointFloat = new PointFloat(583f, 2f);
		((XRControl)xrCrossBandLine4).Name = "xrCrossBandLine4";
		((XRCrossBandControl)xrCrossBandLine4).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine4).StartPointFloat = new PointFloat(583f, 308f);
		((XRControl)xrCrossBandLine4).WidthF = 1f;
		((XRControl)xrCrossBandLine5).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine5).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine5).EndPointFloat = new PointFloat(242f, 2f);
		((XRControl)xrCrossBandLine5).Name = "xrCrossBandLine5";
		((XRCrossBandControl)xrCrossBandLine5).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine5).StartPointFloat = new PointFloat(242f, 308f);
		((XRControl)xrCrossBandLine5).WidthF = 1f;
		((XRControl)xrCrossBandLine6).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine6).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine6).EndPointFloat = new PointFloat(300f, 2f);
		((XRControl)xrCrossBandLine6).Name = "xrCrossBandLine6";
		((XRCrossBandControl)xrCrossBandLine6).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine6).StartPointFloat = new PointFloat(300f, 308f);
		((XRControl)xrCrossBandLine6).WidthF = 1f;
		((XRControl)xrCrossBandLine7).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine7).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine7).EndPointFloat = new PointFloat(325f, 2f);
		((XRControl)xrCrossBandLine7).Name = "xrCrossBandLine7";
		((XRCrossBandControl)xrCrossBandLine7).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine7).StartPointFloat = new PointFloat(325f, 308f);
		((XRControl)xrCrossBandLine7).WidthF = 1f;
		((XRControl)xrCrossBandLine8).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine8).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine8).EndPointFloat = new PointFloat(517f, 2f);
		((XRControl)xrCrossBandLine8).Name = "xrCrossBandLine8";
		((XRCrossBandControl)xrCrossBandLine8).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine8).StartPointFloat = new PointFloat(517f, 308f);
		((XRControl)xrCrossBandLine8).WidthF = 1f;
		((XRControl)xrCrossBandLine9).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine9).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine9).EndPointFloat = new PointFloat(458f, 2f);
		((XRControl)xrCrossBandLine9).Name = "xrCrossBandLine9";
		((XRCrossBandControl)xrCrossBandLine9).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine9).StartPointFloat = new PointFloat(458f, 308f);
		((XRControl)xrCrossBandLine9).WidthF = 1f;
		((XRControl)xrCrossBandLine10).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine10).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine10).EndPointFloat = new PointFloat(392f, 2f);
		((XRControl)xrCrossBandLine10).Name = "xrCrossBandLine10";
		((XRCrossBandControl)xrCrossBandLine10).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine10).StartPointFloat = new PointFloat(392f, 308f);
		((XRControl)xrCrossBandLine10).WidthF = 1f;
		((XRControl)xrCrossBandLine11).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine11).EndBand = (Band)(object)PageFooter;
		((XRCrossBandControl)xrCrossBandLine11).EndPointFloat = new PointFloat(367f, 2f);
		((XRControl)xrCrossBandLine11).Name = "xrCrossBandLine11";
		((XRCrossBandControl)xrCrossBandLine11).StartBand = (Band)(object)PageHeader;
		((XRCrossBandControl)xrCrossBandLine11).StartPointFloat = new PointFloat(367f, 308f);
		((XRControl)xrCrossBandLine11).WidthF = 1f;
		nfItensBindingSource.AutoCreateObjects = false;
		nfItensBindingSource.DataSource = typeof(NotaFiscalNotasFiscaisItens);
		((XRControl)topMarginBand1).HeightF = 50f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).HeightF = 50f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[6]
		{
			(Band)Detail,
			(Band)PageHeader,
			(Band)PageFooter,
			(Band)ReportHeader,
			(Band)topMarginBand1,
			(Band)bottomMarginBand1
		});
		((XRControl)this).BorderWidth = 0f;
		((XtraReport)this).CrossBandControls.AddRange((XRCrossBandControl[])(object)new XRCrossBandControl[12]
		{
			(XRCrossBandControl)xrCrossBandBox1,
			(XRCrossBandControl)xrCrossBandLine1,
			(XRCrossBandControl)xrCrossBandLine2,
			(XRCrossBandControl)xrCrossBandLine3,
			(XRCrossBandControl)xrCrossBandLine4,
			(XRCrossBandControl)xrCrossBandLine5,
			(XRCrossBandControl)xrCrossBandLine6,
			(XRCrossBandControl)xrCrossBandLine7,
			(XRCrossBandControl)xrCrossBandLine8,
			(XRCrossBandControl)xrCrossBandLine9,
			(XRCrossBandControl)xrCrossBandLine10,
			(XRCrossBandControl)xrCrossBandLine11
		});
		((XtraReportBase)this).DataSource = nfItensBindingSource;
		((XtraReport)this).DisplayName = "Danfe";
		((XtraReport)this).Margins = new Margins(50, 50, 50, 50);
		((XtraReport)this).PageHeight = 1169;
		((XtraReport)this).PageWidth = 827;
		((XtraReport)this).PaperKind = PaperKind.A4;
		((XtraReport)this).SnapGridSize = 5.208333f;
		((XtraReport)this).Version = "19.2";
		((XRControl)this).BeforePrint += rptDanfe_BeforePrint;
		((ISupportInitialize)nfItensBindingSource).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
