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

public class rptDanfePaisagem : XtraReport
{
	private readonly NotaFiscalNotasFiscais _nf = new NotaFiscalNotasFiscais();

	private bool _visualizar = false;

	private bool ocultarICMS = false;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRLabel xrProdDesc;

	private BusinessObjectBindingSource nfItensBindingSource;

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

	private ReportHeaderBand ReportHeader;

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

	private XRBarCode xrChaveAcesso2;

	private XRPanel xrPanel12;

	private XRLabel xrEmitenteTelefone2;

	private XRLabel xrEmitenteEnderecoCidade2;

	private XRLabel xrEnderecoEmitenteBairro2;

	private XRLabel xrEnderecoEmitente2;

	private XRLabel xrRazaoSocialEmitente2;

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

	private XRPictureBox xrLogo2;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel64;

	private XRLabel xrLabel70;

	private GroupHeaderBand GroupHeader1;

	private XRPanel xrPanel16;

	private XRLabel xrLabel71;

	private XRLabel xrLabel73;

	private XRLabel xrLabel76;

	private XRLabel xrLabel80;

	private XRLabel xrLabel81;

	private XRLabel xrLabel82;

	private XRLabel xrLabel96;

	private XRLabel xrLabel100;

	private XRLabel xrLabel101;

	private XRLabel xrLabel102;

	private XRLabel xrLabel103;

	private XRLabel xrLabel104;

	private XRLabel txComentarioProduto;

	private XRLabel xrLabel18;

	private XRLabel xrLabel122;

	private XRLabel xrProtocolo2;

	private XRLabel xrLabel124;

	private XRLabel xrChave2;

	private XRPanel xrPanel18;

	private XRLabel xrLabel21;

	private XRLabel xrEmitenteIE;

	private XRLine xrLine3;

	private XRLine xrLine6;

	private XRLabel xrLabel86;

	private XRLabel xrEmitenteCNPJ;

	private XRLabel xrLabel88;

	private XRLabel xrEmitenteInscST;

	private XRLine xrLine7;

	private XRLabel xrNatOp;

	private XRLabel xrLabel91;

	private XRPanel xrPanel1;

	private XRBarCode xrChaveAcesso;

	private XRLabel xrLabel5;

	private XRLabel xrLabel6;

	private XRLabel xrLabel7;

	private XRLabel xrLabel8;

	private XRPanel xrPanel2;

	private XRLabel xrES1;

	private XRLabel xrNFeNum;

	private XRLabel xrLabel11;

	private XRLabel xrSerieNFe;

	private XRPageInfo xrPageInfo1;

	private XRLabel xrLabel13;

	private XRLabel xrLabel15;

	private XRLabel xrProtocolo;

	private XRLabel xrLabel17;

	private XRLabel xrChave;

	private XRPanel xrPanel17;

	private XRPictureBox xrLogo;

	private XRLabel xrRazaoSocialEmitente;

	private XRLabel xrEnderecoEmitente;

	private XRLabel xrEnderecoEmitenteBairro;

	private XRLabel xrEmitenteEnderecoCidade;

	private XRLabel xrEmitenteTelefone;

	private SubBand SubBand1;

	private XRPanel xrFirstPageOnly;

	private XRPanel xrPanel6;

	private XRLine xrLine18;

	private XRLine xrLine16;

	private XRLine xrLine15;

	private XRLine xrLine48;

	private XRLine xrLine47;

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

	private XRLabel xrLabel30;

	private XRLabel xrValorSeguro;

	private XRLine xrLine17;

	private XRLabel xrTotalProd;

	private XRLabel xrLabel36;

	private XRLabel xrBaseICMS;

	private XRLabel xrLabel43;

	private XRPanel xrPanel9;

	private XRLabel xrDadosFatura;

	private XRPanel xrPanel4;

	private XRLine xrLine46;

	private XRLine xrLine12;

	private XRLine xrLine10;

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

	private XRLabel xrLabel31;

	private XRLabel xrDestCEP;

	private XRLine xrLine11;

	private XRLabel xrLabel29;

	private XRLabel xrDestBairro;

	private XRLabel xrLabel27;

	private XRLabel xrDestCNPJ;

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

	private XRPanel xrPanel8;

	private XRLine xrLine32;

	private XRLine xrLine31;

	private XRLabel xrLabel68;

	private XRLabel xrTranspRazaoSocial;

	private XRLine xrLine30;

	private XRLabel xrTranspCNPJ;

	private XRLabel xrLabel63;

	private XRLabel xrTranspMunicipio;

	private XRLabel xrLabel60;

	private XRLine xrLine28;

	private XRLabel xrTranspCEP;

	private XRLabel xrLabel58;

	private XRLabel xrPesoLiquido;

	private XRLabel xrLabel56;

	private XRLabel xrPesoBruto;

	private XRLabel xrLabel53;

	private XRLine xrLine24;

	private XRLabel xrTranspEndereco;

	private XRLabel xrLabel44;

	private XRLabel xrTranspQt;

	private XRLabel xrLabel34;

	private XRLabel xrLabel69;

	private XRLine xrLine33;

	private XRLabel xrTranspPlaca;

	private XRLabel xrTranspPlacaUF;

	private XRLine xrLine34;

	private XRLabel xrLabel72;

	private XRLabel xrTranspUF;

	private XRLabel xrLabel74;

	private XRLabel xrLabel75;

	private XRLabel xrTranspANTT;

	private XRLabel xrLabel79;

	private XRLabel xrTranspPagoPor;

	private XRLine xrLine27;

	private XRLabel xrTranspNumeracao;

	private XRLabel xrLabel48;

	private XRLine xrLine35;

	private XRLabel xrLabel50;

	private XRLabel xrTranspEspecie;

	private XRLine xrLine36;

	private XRLabel xrLabel62;

	private XRLabel xrTranspMarca;

	private XRLine xrLine37;

	private XRLabel xrLabel84;

	private XRLabel xrLabel42;

	private XRLabel xrLabel23;

	private XRPanel xrPanel19;

	private XRLine xrLine25;

	private XRLabel xrLabel1;

	private XRLabel xrLabel2;

	private XRLabel xrInfoCpl2;

	private XRPanel xrPanel20;

	private XRLabel xrValorServico2;

	private XRLabel xrLabel9;

	private XRLabel xrBaseISSQN2;

	private XRLine xrLine39;

	private XRLabel xrLabel12;

	private XRLine xrLine45;

	private XRLine xrLine49;

	private XRLabel xrValorISSQN2;

	private XRLabel xrLabel19;

	private XRLabel xrIM2;

	private XRLabel xrLabel46;

	private XRLabel xrLabel66;

	private XRLabel xrLabel87;

	private GroupFooterBand GroupFooter1;

	private ReportFooterBand ReportFooter;

	private XRPanel xrPanel10;

	private XRLine xrLine38;

	private XRLabel xrLabel55;

	private XRLabel xrLabel59;

	private XRLabel xrInfoCpl;

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

	private XRLabel xrLabel14;

	private XRLabel xrLabel32;

	private XRPanel xrPanel21;

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

	private XRLine xrLine50;

	private XRCrossBandLine xrCrossBandLine12;

	private XRCrossBandLine xrCrossBandLine13;

	private XRLabel xrLabel3;

	private XRLabel xrLabel4;

	private XRLabel xrLabel10;

	private XRLabel xrLabel16;

	private XRLabel xrLabel28;

	private XRLabel xrLabel77;

	private XRCrossBandLine xrCrossBandLine14;

	private XRCrossBandLine xrCrossBandLine15;

	private XRLabel xrLabel57;

	private XRLabel xrLabel78;

	private XRLabel xrLabel85;

	public rptDanfePaisagem(NotaFiscalNotasFiscais nf)
		: this()
	{
		_nf = nf;
	}

	public rptDanfePaisagem(NotaFiscalNotasFiscais nf, bool Visualizar)
		: this()
	{
		_nf = nf;
		_visualizar = Visualizar;
	}

	private rptDanfePaisagem()
	{
		InitializeComponent();
	}

	private void xrLabel46_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = e.PageIndex > 0;
	}

	private void rptDanfe_BeforePrint(object sender, PrintEventArgs e)
	{
		if (!_visualizar)
		{
			((XRControl)xrChaveAcesso).Text = _nf.ChaveNfe;
			((XRControl)xrChaveAcesso2).Text = ((XRControl)xrChaveAcesso).Text;
			((XRControl)xrChave).Text = _nf.ChaveNfe.Substring(0, 2) + "." + _nf.ChaveNfe.Substring(2, 2) + "." + _nf.ChaveNfe.Substring(4, 2) + "." + _nf.ChaveNfe.Substring(6, 2) + "." + _nf.ChaveNfe.Substring(8, 3) + "." + _nf.ChaveNfe.Substring(11, 3) + "." + _nf.ChaveNfe.Substring(14, 4) + "/" + _nf.ChaveNfe.Substring(18, 2) + "-" + _nf.ChaveNfe.Substring(20, 2) + "-" + _nf.ChaveNfe.Substring(22, 3) + "." + _nf.ChaveNfe.Substring(25, 3) + "." + _nf.ChaveNfe.Substring(28, 3) + "-" + _nf.ChaveNfe.Substring(31, 3) + "-" + _nf.ChaveNfe.Substring(34, 3) + "." + _nf.ChaveNfe.Substring(37, 3) + "." + _nf.ChaveNfe.Substring(40, 3) + "-" + _nf.ChaveNfe.Substring(43);
			((XRControl)xrChave2).Text = ((XRControl)xrChave).Text;
			if (!string.IsNullOrEmpty(_nf.ProtocoloNfe))
			{
				((XRControl)xrProtocolo).Text = string.Format("{0} - {1}", _nf.ProtocoloNfe, _nf.DataEnvioNFE.ToString("g"));
			}
			else
			{
				((XRControl)xrProtocolo).Text = "DANFE EM CONTINGÊNCIA";
			}
			((XRControl)xrProtocolo2).Text = ((XRControl)xrProtocolo).Text;
		}
		else
		{
			((XRControl)xrChaveAcesso).Text = "Pré-Visualização";
			((XRControl)xrChaveAcesso2).Text = "Pré-Visualização";
			((XRControl)xrChave).Text = "Pré-Visualização";
			((XRControl)xrChave2).Text = ((XRControl)xrChave).Text;
			((XRControl)xrProtocolo).Text = "Pré-Visualização";
			((XRControl)xrProtocolo2).Text = ((XRControl)xrProtocolo).Text;
		}
		((XRControl)xrNFeNum).Text = _nf.NumeroNotaFiscal.ToString("000,000,000");
		((XRControl)xrNroNF2).Text = ((XRControl)xrNFeNum).Text;
		((XRControl)xrSerieNFe).Text = "SÉRIE " + _nf.SerieNotaFiscal;
		((XRControl)xrNFeNum).Text = ((XRControl)xrNFeNum).Text;
		((XRControl)xrNroNFe2).Text = ((XRControl)xrNFeNum).Text;
		((XRControl)xrSerieNFe).Text = ((XRControl)xrSerieNFe).Text;
		((XRControl)xrSerieNFe2).Text = ((XRControl)xrSerieNFe).Text;
		((XRControl)xrSerieNF2).Text = ((XRControl)xrSerieNFe).Text;
		((XRControl)xrES1).Text = (_nf.IsNotaFiscalEntrada ? "0" : "1");
		((XRControl)xrNatOp).Text = _nf.DescricaoCFOP;
		((XRControl)xrES2).Text = ((XRControl)xrES1).Text;
		((XRControl)xrRecebemosDe2).Text = $"RECEBEMOS DE {_nf.Emitente.RazaoSocial.ToUpper()} OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA ABAIXO";
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
		((XRControl)xrIM2).Text = _nf.Emitente.InscricaoMunicipal;
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
		((XRControl)xrValorDesconto).Text = (_nf.ValorDesconto + _nf.ValorIcmsDesonerado).ToString("N02");
		((XRControl)xrTotalNota).Text = _nf.ValorTotalNotaFiscal.ToString("N02");
		((XRControl)xrTotalProd).Text = _nf.ValorTotalProdutos.ToString("N02");
		((XRControl)xrBaseST).Text = "0.00";
		if (_nf.Itens != null && _nf.Itens.Count > 0 && (_nf.Itens[0].TipoIncidenciaIcms == "201" || _nf.Itens[0].TipoIncidenciaIcms == "102"))
		{
			((XRControl)xrBaseICMS).Text = "0,00";
			((XRControl)xrValorICMS).Text = "0,00";
		}
		else
		{
			((XRControl)xrBaseICMS).Text = _nf.ValorBaseICMS.ToString("N02");
			((XRControl)xrValorICMS).Text = _nf.ValorICMS.ToString("N02");
		}
		((XRControl)xrBaseST).Text = _nf.ValorBaseICMSSubstituto.ToString("N02");
		((XRControl)xrValorST).Text = _nf.ValorICMSSubstituto.ToString("N02");
		((XRControl)xrValorIPI).Text = _nf.ValorIPI.ToString("N02");
		((XRControl)xrValorFrete).Text = _nf.ValorFrete.ToString("N02");
		((XRControl)xrValorSeguro).Text = _nf.ValorSeguro.ToString("N02");
		((XRControl)xrValorOutras).Text = _nf.ValorOutrasDespesas.ToString("N02");
		((XRControl)xrValorISSQN).Text = "0,00";
		((XRControl)xrValorServico).Text = "0,00";
		((XRControl)xrBaseISSQN).Text = "0,00";
		((XRControl)xrValorISSQN2).Text = "0,00";
		((XRControl)xrValorServico2).Text = "0,00";
		((XRControl)xrBaseISSQN2).Text = "0,00";
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
			((XRControl)xrTranspPagoPor).Text = "1 Destinatario";
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
		((XRControl)xrPesoLiquido).Text = _nf.PesoLiquido.ToString("N03");
		((XRControl)xrPesoBruto).Text = _nf.PesoBruto.ToString("N03");
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
					((XRControl)obj2).Text = ((XRControl)obj2).Text + "\t| ";
				}
				XRLabel val = xrDadosFatura;
				((XRControl)val).Text = ((XRControl)val).Text + item.CodigoFatura + "\t" + item.Vencimento.ToString("dd/MM/yyyy") + "\t" + item.ValorFatura.ToString("C02");
				num++;
			}
		}
		string text = (string.IsNullOrEmpty(_nf.ProtocoloNfe) ? "DANFE em Contingência - impresso em decorrência de problemas técnicos\r\n" : string.Empty);
		text += _nf.TextoLegal;
		((XRControl)xrInfoCpl).Text = text;
		((XRControl)xrInfoCpl2).Text = text;
		nfItensBindingSource.DataSource = _nf.Itens;
		nfItensBindingSource.ResetBindings(metadataChanged: false);
	}

	private void Detail_BeforePrint(object sender, PrintEventArgs e)
	{
		NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = (NotaFiscalNotasFiscaisItens)((XtraReportBase)this).GetCurrentRow();
		if (notaFiscalNotasFiscaisItens.TipoIncidenciaIcms == "201" || notaFiscalNotasFiscaisItens.TipoIncidenciaIcms == "102")
		{
			((XRControl)xrProdBaseICMS).Text = "";
			((XRControl)xrProdICMS).Text = "";
			notaFiscalNotasFiscaisItens.ValorBaseICMS = 0m;
			notaFiscalNotasFiscaisItens.ValorICMS = 0m;
			notaFiscalNotasFiscaisItens.AliquotaICMS = 0m;
		}
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected O, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected O, but got Unknown
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Expected O, but got Unknown
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Expected O, but got Unknown
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected O, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Expected O, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Expected O, but got Unknown
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Expected O, but got Unknown
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Expected O, but got Unknown
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Expected O, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Expected O, but got Unknown
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Expected O, but got Unknown
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Expected O, but got Unknown
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Expected O, but got Unknown
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Expected O, but got Unknown
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Expected O, but got Unknown
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Expected O, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ab: Expected O, but got Unknown
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Expected O, but got Unknown
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Expected O, but got Unknown
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Expected O, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected O, but got Unknown
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Expected O, but got Unknown
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Expected O, but got Unknown
		//IL_080f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Expected O, but got Unknown
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082f: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected O, but got Unknown
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Expected O, but got Unknown
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_085b: Expected O, but got Unknown
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0887: Expected O, but got Unknown
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Expected O, but got Unknown
		//IL_0893: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Expected O, but got Unknown
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Expected O, but got Unknown
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Expected O, but got Unknown
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Expected O, but got Unknown
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Expected O, but got Unknown
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Expected O, but got Unknown
		//IL_0901: Unknown result type (might be due to invalid IL or missing references)
		//IL_090b: Expected O, but got Unknown
		//IL_090c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0916: Expected O, but got Unknown
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Expected O, but got Unknown
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected O, but got Unknown
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0937: Expected O, but got Unknown
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Expected O, but got Unknown
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Expected O, but got Unknown
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0958: Expected O, but got Unknown
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Expected O, but got Unknown
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Expected O, but got Unknown
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Expected O, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0984: Expected O, but got Unknown
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Expected O, but got Unknown
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Expected O, but got Unknown
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a5: Expected O, but got Unknown
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Expected O, but got Unknown
		//IL_09b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Expected O, but got Unknown
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Expected O, but got Unknown
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_09d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Expected O, but got Unknown
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Expected O, but got Unknown
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Expected O, but got Unknown
		//IL_09f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_0a09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Expected O, but got Unknown
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Expected O, but got Unknown
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Expected O, but got Unknown
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Expected O, but got Unknown
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3f: Expected O, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Expected O, but got Unknown
		//IL_0a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a55: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected O, but got Unknown
		//IL_0a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Expected O, but got Unknown
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Expected O, but got Unknown
		//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Expected O, but got Unknown
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Expected O, but got Unknown
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a97: Expected O, but got Unknown
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Expected O, but got Unknown
		//IL_0aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Expected O, but got Unknown
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Expected O, but got Unknown
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Expected O, but got Unknown
		//IL_0ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ace: Expected O, but got Unknown
		//IL_0acf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad9: Expected O, but got Unknown
		//IL_0ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Expected O, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Expected O, but got Unknown
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Expected O, but got Unknown
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b10: Expected O, but got Unknown
		//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1b: Expected O, but got Unknown
		//IL_0b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Expected O, but got Unknown
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Expected O, but got Unknown
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_0b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b47: Expected O, but got Unknown
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b52: Expected O, but got Unknown
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b68: Expected O, but got Unknown
		//IL_0b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Expected O, but got Unknown
		//IL_0b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Expected O, but got Unknown
		//IL_0b7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b89: Expected O, but got Unknown
		//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b94: Expected O, but got Unknown
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9f: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Expected O, but got Unknown
		//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb5: Expected O, but got Unknown
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Expected O, but got Unknown
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Expected O, but got Unknown
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd6: Expected O, but got Unknown
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be1: Expected O, but got Unknown
		//IL_0be2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Expected O, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Expected O, but got Unknown
		//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Expected O, but got Unknown
		//IL_0c03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0d: Expected O, but got Unknown
		//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Expected O, but got Unknown
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Expected O, but got Unknown
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Expected O, but got Unknown
		//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c39: Expected O, but got Unknown
		//IL_0c3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c44: Expected O, but got Unknown
		//IL_0c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Expected O, but got Unknown
		//IL_0c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Expected O, but got Unknown
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Expected O, but got Unknown
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c70: Expected O, but got Unknown
		//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7b: Expected O, but got Unknown
		//IL_0c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c86: Expected O, but got Unknown
		//IL_0c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c91: Expected O, but got Unknown
		//IL_0c92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9c: Expected O, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Expected O, but got Unknown
		//IL_0ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb2: Expected O, but got Unknown
		//IL_0cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Expected O, but got Unknown
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
		//IL_0cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd3: Expected O, but got Unknown
		//IL_0cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cde: Expected O, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected O, but got Unknown
		//IL_0cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf4: Expected O, but got Unknown
		//IL_0cf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Expected O, but got Unknown
		//IL_0d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0a: Expected O, but got Unknown
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d15: Expected O, but got Unknown
		//IL_0d16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d20: Expected O, but got Unknown
		//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2b: Expected O, but got Unknown
		//IL_0d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d36: Expected O, but got Unknown
		//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d41: Expected O, but got Unknown
		//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4c: Expected O, but got Unknown
		//IL_0d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d57: Expected O, but got Unknown
		//IL_0dcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Expected O, but got Unknown
		//IL_0fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c3: Expected O, but got Unknown
		//IL_10f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_111f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11da: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e0: Expected O, but got Unknown
		//IL_1211: Unknown result type (might be due to invalid IL or missing references)
		//IL_123c: Unknown result type (might be due to invalid IL or missing references)
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1313: Expected O, but got Unknown
		//IL_1344: Unknown result type (might be due to invalid IL or missing references)
		//IL_136f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1425: Unknown result type (might be due to invalid IL or missing references)
		//IL_142b: Expected O, but got Unknown
		//IL_145c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1487: Unknown result type (might be due to invalid IL or missing references)
		//IL_1561: Unknown result type (might be due to invalid IL or missing references)
		//IL_1567: Expected O, but got Unknown
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b0: Expected O, but got Unknown
		//IL_16e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_170c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f9: Expected O, but got Unknown
		//IL_182a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1855: Unknown result type (might be due to invalid IL or missing references)
		//IL_192f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1935: Expected O, but got Unknown
		//IL_1966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1991: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a64: Expected O, but got Unknown
		//IL_1a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b93: Expected O, but got Unknown
		//IL_1bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbd: Expected O, but got Unknown
		//IL_1cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcd: Expected O, but got Unknown
		//IL_1dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef7: Expected O, but got Unknown
		//IL_1f28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_201b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2021: Expected O, but got Unknown
		//IL_2052: Unknown result type (might be due to invalid IL or missing references)
		//IL_207d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2145: Unknown result type (might be due to invalid IL or missing references)
		//IL_214b: Expected O, but got Unknown
		//IL_217c: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_226f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2275: Expected O, but got Unknown
		//IL_22a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22de: Unknown result type (might be due to invalid IL or missing references)
		//IL_2387: Unknown result type (might be due to invalid IL or missing references)
		//IL_238d: Expected O, but got Unknown
		//IL_23be: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c9: Expected O, but got Unknown
		//IL_24fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2525: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f8: Expected O, but got Unknown
		//IL_2629: Unknown result type (might be due to invalid IL or missing references)
		//IL_2654: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2873: Unknown result type (might be due to invalid IL or missing references)
		//IL_289e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2985: Unknown result type (might be due to invalid IL or missing references)
		//IL_29b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_2caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3090: Unknown result type (might be due to invalid IL or missing references)
		//IL_30bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3175: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3237: Unknown result type (might be due to invalid IL or missing references)
		//IL_3262: Unknown result type (might be due to invalid IL or missing references)
		//IL_330a: Unknown result type (might be due to invalid IL or missing references)
		//IL_339d: Unknown result type (might be due to invalid IL or missing references)
		//IL_33c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_347e: Unknown result type (might be due to invalid IL or missing references)
		//IL_34a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3552: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_35f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_37a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_37cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3881: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_3943: Unknown result type (might be due to invalid IL or missing references)
		//IL_396e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_3abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4026: Unknown result type (might be due to invalid IL or missing references)
		//IL_4030: Expected O, but got Unknown
		//IL_4041: Unknown result type (might be due to invalid IL or missing references)
		//IL_40d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_410c: Unknown result type (might be due to invalid IL or missing references)
		//IL_41a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_41ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_4265: Unknown result type (might be due to invalid IL or missing references)
		//IL_4290: Unknown result type (might be due to invalid IL or missing references)
		//IL_4327: Unknown result type (might be due to invalid IL or missing references)
		//IL_4352: Unknown result type (might be due to invalid IL or missing references)
		//IL_43e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4414: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4584: Unknown result type (might be due to invalid IL or missing references)
		//IL_4609: Unknown result type (might be due to invalid IL or missing references)
		//IL_468e: Unknown result type (might be due to invalid IL or missing references)
		//IL_46b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4750: Unknown result type (might be due to invalid IL or missing references)
		//IL_477b: Unknown result type (might be due to invalid IL or missing references)
		//IL_481f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4857: Unknown result type (might be due to invalid IL or missing references)
		//IL_495a: Unknown result type (might be due to invalid IL or missing references)
		//IL_49f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b64: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ff0: Unknown result type (might be due to invalid IL or missing references)
		//IL_5076: Unknown result type (might be due to invalid IL or missing references)
		//IL_50a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_5185: Unknown result type (might be due to invalid IL or missing references)
		//IL_51b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_52d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5303: Unknown result type (might be due to invalid IL or missing references)
		//IL_5560: Unknown result type (might be due to invalid IL or missing references)
		//IL_558b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5671: Unknown result type (might be due to invalid IL or missing references)
		//IL_569c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5753: Unknown result type (might be due to invalid IL or missing references)
		//IL_577e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5857: Unknown result type (might be due to invalid IL or missing references)
		//IL_5882: Unknown result type (might be due to invalid IL or missing references)
		//IL_5983: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_5aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d15: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_5eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_603e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6069: Unknown result type (might be due to invalid IL or missing references)
		//IL_6111: Unknown result type (might be due to invalid IL or missing references)
		//IL_61e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_620e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6351: Unknown result type (might be due to invalid IL or missing references)
		//IL_63c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_649b: Unknown result type (might be due to invalid IL or missing references)
		//IL_64c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_65ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_6619: Unknown result type (might be due to invalid IL or missing references)
		//IL_6741: Unknown result type (might be due to invalid IL or missing references)
		//IL_676c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6996: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_6be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_6dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f41: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7003: Unknown result type (might be due to invalid IL or missing references)
		//IL_702e: Unknown result type (might be due to invalid IL or missing references)
		//IL_70c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_70f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_71a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_71cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7271: Unknown result type (might be due to invalid IL or missing references)
		//IL_729c: Unknown result type (might be due to invalid IL or missing references)
		//IL_732f: Unknown result type (might be due to invalid IL or missing references)
		//IL_73c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_73ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_7490: Unknown result type (might be due to invalid IL or missing references)
		//IL_74bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_7571: Unknown result type (might be due to invalid IL or missing references)
		//IL_759c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7633: Unknown result type (might be due to invalid IL or missing references)
		//IL_765e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7702: Unknown result type (might be due to invalid IL or missing references)
		//IL_7788: Unknown result type (might be due to invalid IL or missing references)
		//IL_77b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_786a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7895: Unknown result type (might be due to invalid IL or missing references)
		//IL_7939: Unknown result type (might be due to invalid IL or missing references)
		//IL_7964: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c38: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d88: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_8022: Unknown result type (might be due to invalid IL or missing references)
		//IL_80bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_814d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8185: Unknown result type (might be due to invalid IL or missing references)
		//IL_830c: Unknown result type (might be due to invalid IL or missing references)
		//IL_837f: Unknown result type (might be due to invalid IL or missing references)
		//IL_83f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8465: Unknown result type (might be due to invalid IL or missing references)
		//IL_84f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_8522: Unknown result type (might be due to invalid IL or missing references)
		//IL_85c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_85f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_8695: Unknown result type (might be due to invalid IL or missing references)
		//IL_86c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_8764: Unknown result type (might be due to invalid IL or missing references)
		//IL_878f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8814: Unknown result type (might be due to invalid IL or missing references)
		//IL_88a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_88d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_8975: Unknown result type (might be due to invalid IL or missing references)
		//IL_89a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8bc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_8f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_9004: Unknown result type (might be due to invalid IL or missing references)
		//IL_902f: Unknown result type (might be due to invalid IL or missing references)
		//IL_90d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_90fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_91a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_91cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_9271: Unknown result type (might be due to invalid IL or missing references)
		//IL_929c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9340: Unknown result type (might be due to invalid IL or missing references)
		//IL_936b: Unknown result type (might be due to invalid IL or missing references)
		//IL_93fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_9429: Unknown result type (might be due to invalid IL or missing references)
		//IL_94a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_9507: Unknown result type (might be due to invalid IL or missing references)
		//IL_95d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_966b: Unknown result type (might be due to invalid IL or missing references)
		//IL_9696: Unknown result type (might be due to invalid IL or missing references)
		//IL_9759: Unknown result type (might be due to invalid IL or missing references)
		//IL_9784: Unknown result type (might be due to invalid IL or missing references)
		//IL_9847: Unknown result type (might be due to invalid IL or missing references)
		//IL_9872: Unknown result type (might be due to invalid IL or missing references)
		//IL_9935: Unknown result type (might be due to invalid IL or missing references)
		//IL_9960: Unknown result type (might be due to invalid IL or missing references)
		//IL_9a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_9a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b11: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_9ec6: Unknown result type (might be due to invalid IL or missing references)
		//IL_9f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_9f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_a01a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a045: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_a14b: Unknown result type (might be due to invalid IL or missing references)
		//IL_a176: Unknown result type (might be due to invalid IL or missing references)
		//IL_a22c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a257: Unknown result type (might be due to invalid IL or missing references)
		//IL_a2fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_a326: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_a46d: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_a52a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_a60b: Unknown result type (might be due to invalid IL or missing references)
		//IL_a6af: Unknown result type (might be due to invalid IL or missing references)
		//IL_a6da: Unknown result type (might be due to invalid IL or missing references)
		//IL_a790: Unknown result type (might be due to invalid IL or missing references)
		//IL_a7bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_a85f: Unknown result type (might be due to invalid IL or missing references)
		//IL_a88a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a940: Unknown result type (might be due to invalid IL or missing references)
		//IL_a96b: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa82: Unknown result type (might be due to invalid IL or missing references)
		//IL_aaad: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab44: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac13: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_acd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad00: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad97: Unknown result type (might be due to invalid IL or missing references)
		//IL_adc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae47: Unknown result type (might be due to invalid IL or missing references)
		//IL_aed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_af04: Unknown result type (might be due to invalid IL or missing references)
		//IL_af97: Unknown result type (might be due to invalid IL or missing references)
		//IL_afc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_b036: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_b18a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b1b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_b24c: Unknown result type (might be due to invalid IL or missing references)
		//IL_b277: Unknown result type (might be due to invalid IL or missing references)
		//IL_b30e: Unknown result type (might be due to invalid IL or missing references)
		//IL_b339: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_b408: Unknown result type (might be due to invalid IL or missing references)
		//IL_b48e: Unknown result type (might be due to invalid IL or missing references)
		//IL_b4b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_b56b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b596: Unknown result type (might be due to invalid IL or missing references)
		//IL_b64d: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6df: Unknown result type (might be due to invalid IL or missing references)
		//IL_b70a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b790: Unknown result type (might be due to invalid IL or missing references)
		//IL_b7bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_b840: Unknown result type (might be due to invalid IL or missing references)
		//IL_b8c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_b8f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_b994: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba44: Unknown result type (might be due to invalid IL or missing references)
		//IL_bac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_baf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb98: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc37: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_bddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_be7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_beaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf52: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_c04a: Unknown result type (might be due to invalid IL or missing references)
		//IL_c075: Unknown result type (might be due to invalid IL or missing references)
		//IL_c10c: Unknown result type (might be due to invalid IL or missing references)
		//IL_c137: Unknown result type (might be due to invalid IL or missing references)
		//IL_c1f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_c21c: Unknown result type (might be due to invalid IL or missing references)
		//IL_c2b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c2de: Unknown result type (might be due to invalid IL or missing references)
		//IL_c386: Unknown result type (might be due to invalid IL or missing references)
		//IL_c419: Unknown result type (might be due to invalid IL or missing references)
		//IL_c444: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_c525: Unknown result type (might be due to invalid IL or missing references)
		//IL_c5bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_c5e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_c68b: Unknown result type (might be due to invalid IL or missing references)
		//IL_c6b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_c75c: Unknown result type (might be due to invalid IL or missing references)
		//IL_c787: Unknown result type (might be due to invalid IL or missing references)
		//IL_c83d: Unknown result type (might be due to invalid IL or missing references)
		//IL_c868: Unknown result type (might be due to invalid IL or missing references)
		//IL_c900: Unknown result type (might be due to invalid IL or missing references)
		//IL_c92b: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca78: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb59: Unknown result type (might be due to invalid IL or missing references)
		//IL_cbf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_ccb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_ccdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd94: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce87: Unknown result type (might be due to invalid IL or missing references)
		//IL_cefe: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_d034: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_d189: Unknown result type (might be due to invalid IL or missing references)
		//IL_d1b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_d24b: Unknown result type (might be due to invalid IL or missing references)
		//IL_d276: Unknown result type (might be due to invalid IL or missing references)
		//IL_d30d: Unknown result type (might be due to invalid IL or missing references)
		//IL_d338: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_d489: Unknown result type (might be due to invalid IL or missing references)
		//IL_d493: Expected O, but got Unknown
		//IL_d4a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_d550: Unknown result type (might be due to invalid IL or missing references)
		//IL_d588: Unknown result type (might be due to invalid IL or missing references)
		//IL_d66c: Unknown result type (might be due to invalid IL or missing references)
		//IL_d6a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_d77e: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_d957: Unknown result type (might be due to invalid IL or missing references)
		//IL_da0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_da38: Unknown result type (might be due to invalid IL or missing references)
		//IL_db0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_db38: Unknown result type (might be due to invalid IL or missing references)
		//IL_dbee: Unknown result type (might be due to invalid IL or missing references)
		//IL_dc19: Unknown result type (might be due to invalid IL or missing references)
		//IL_dccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_dcfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_ddb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_dddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_de91: Unknown result type (might be due to invalid IL or missing references)
		//IL_debc: Unknown result type (might be due to invalid IL or missing references)
		//IL_df72: Unknown result type (might be due to invalid IL or missing references)
		//IL_df9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_e053: Unknown result type (might be due to invalid IL or missing references)
		//IL_e07e: Unknown result type (might be due to invalid IL or missing references)
		//IL_e153: Unknown result type (might be due to invalid IL or missing references)
		//IL_e17e: Unknown result type (might be due to invalid IL or missing references)
		//IL_e234: Unknown result type (might be due to invalid IL or missing references)
		//IL_e25f: Unknown result type (might be due to invalid IL or missing references)
		//IL_e315: Unknown result type (might be due to invalid IL or missing references)
		//IL_e340: Unknown result type (might be due to invalid IL or missing references)
		//IL_e415: Unknown result type (might be due to invalid IL or missing references)
		//IL_e440: Unknown result type (might be due to invalid IL or missing references)
		//IL_e515: Unknown result type (might be due to invalid IL or missing references)
		//IL_e540: Unknown result type (might be due to invalid IL or missing references)
		//IL_e615: Unknown result type (might be due to invalid IL or missing references)
		//IL_e640: Unknown result type (might be due to invalid IL or missing references)
		//IL_e6fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_e739: Unknown result type (might be due to invalid IL or missing references)
		//IL_e784: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_e80d: Unknown result type (might be due to invalid IL or missing references)
		//IL_e84b: Unknown result type (might be due to invalid IL or missing references)
		//IL_e896: Unknown result type (might be due to invalid IL or missing references)
		//IL_e8d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_e91f: Unknown result type (might be due to invalid IL or missing references)
		//IL_e95d: Unknown result type (might be due to invalid IL or missing references)
		//IL_ea67: Unknown result type (might be due to invalid IL or missing references)
		//IL_eaec: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb71: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_ec33: Unknown result type (might be due to invalid IL or missing references)
		//IL_ec5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed02: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_eed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_eeff: Unknown result type (might be due to invalid IL or missing references)
		//IL_ef85: Unknown result type (might be due to invalid IL or missing references)
		//IL_efb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_f047: Unknown result type (might be due to invalid IL or missing references)
		//IL_f072: Unknown result type (might be due to invalid IL or missing references)
		//IL_f0f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_f17c: Unknown result type (might be due to invalid IL or missing references)
		//IL_f1a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_f22c: Unknown result type (might be due to invalid IL or missing references)
		//IL_f29f: Unknown result type (might be due to invalid IL or missing references)
		//IL_f324: Unknown result type (might be due to invalid IL or missing references)
		//IL_f34f: Unknown result type (might be due to invalid IL or missing references)
		//IL_f3e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_f411: Unknown result type (might be due to invalid IL or missing references)
		//IL_f4a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_f4d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_f559: Unknown result type (might be due to invalid IL or missing references)
		//IL_f584: Unknown result type (might be due to invalid IL or missing references)
		//IL_f668: Unknown result type (might be due to invalid IL or missing references)
		//IL_f693: Unknown result type (might be due to invalid IL or missing references)
		//IL_f7bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_f7e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_f8b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_f8f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_f93d: Unknown result type (might be due to invalid IL or missing references)
		//IL_f97b: Unknown result type (might be due to invalid IL or missing references)
		//IL_f9c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_fa04: Unknown result type (might be due to invalid IL or missing references)
		//IL_fa4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_fa8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_fad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb16: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb61: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_fc2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_fc6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_fcb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_fcf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_fd40: Unknown result type (might be due to invalid IL or missing references)
		//IL_fd7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_fdc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_fe07: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		Code128Generator val = new Code128Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptDanfePaisagem));
		ShapeLine shape = new ShapeLine();
		ShapeLine shape2 = new ShapeLine();
		ShapeLine shape3 = new ShapeLine();
		Code128Generator val2 = new Code128Generator();
		Detail = new DetailBand();
		SubBand1 = new SubBand();
		xrLabel57 = new XRLabel();
		xrLabel78 = new XRLabel();
		xrLabel85 = new XRLabel();
		txComentarioProduto = new XRLabel();
		xrLabel64 = new XRLabel();
		xrLabel70 = new XRLabel();
		xrProdICMSAliq = new XRLabel();
		xrProdICMS = new XRLabel();
		xrProdBaseICMS = new XRLabel();
		xrProdPT = new XRLabel();
		xrProdPU = new XRLabel();
		xrProdUN = new XRLabel();
		xrProdQt = new XRLabel();
		xrProdCFOP = new XRLabel();
		xrProdST = new XRLabel();
		xrProdNCM = new XRLabel();
		xrProdDesc = new XRLabel();
		xrProdCod = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		PageHeader = new PageHeaderBand();
		xrProtocolo = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrChave = new XRLabel();
		xrPanel18 = new XRPanel();
		xrLabel21 = new XRLabel();
		xrEmitenteIE = new XRLabel();
		xrLine3 = new XRLine();
		xrLine6 = new XRLine();
		xrLabel86 = new XRLabel();
		xrEmitenteCNPJ = new XRLabel();
		xrLabel88 = new XRLabel();
		xrEmitenteInscST = new XRLabel();
		xrLine7 = new XRLine();
		xrNatOp = new XRLabel();
		xrLabel91 = new XRLabel();
		xrPanel1 = new XRPanel();
		xrChaveAcesso = new XRBarCode();
		xrLabel5 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrPanel2 = new XRPanel();
		xrES1 = new XRLabel();
		xrNFeNum = new XRLabel();
		xrLabel11 = new XRLabel();
		xrSerieNFe = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		xrLabel13 = new XRLabel();
		xrPanel17 = new XRPanel();
		xrLogo = new XRPictureBox();
		xrRazaoSocialEmitente = new XRLabel();
		xrEnderecoEmitente = new XRLabel();
		xrEnderecoEmitenteBairro = new XRLabel();
		xrEmitenteEnderecoCidade = new XRLabel();
		xrEmitenteTelefone = new XRLabel();
		PageFooter = new PageFooterBand();
		xrPanel19 = new XRPanel();
		xrLine25 = new XRLine();
		xrLabel1 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrInfoCpl2 = new XRLabel();
		xrPanel20 = new XRPanel();
		xrValorServico2 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrBaseISSQN2 = new XRLabel();
		xrLine39 = new XRLine();
		xrLabel12 = new XRLabel();
		xrLine45 = new XRLine();
		xrLine49 = new XRLine();
		xrValorISSQN2 = new XRLabel();
		xrLabel19 = new XRLabel();
		xrIM2 = new XRLabel();
		xrLabel46 = new XRLabel();
		xrLabel66 = new XRLabel();
		xrLabel87 = new XRLabel();
		ReportHeader = new ReportHeaderBand();
		xrProtocolo2 = new XRLabel();
		xrLabel122 = new XRLabel();
		xrChave2 = new XRLabel();
		xrLabel124 = new XRLabel();
		xrPanel21 = new XRPanel();
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
		xrLine50 = new XRLine();
		xrLabel18 = new XRLabel();
		xrFirstPageOnly = new XRPanel();
		xrLine32 = new XRLine();
		xrLabel84 = new XRLabel();
		xrLabel42 = new XRLabel();
		xrLabel23 = new XRLabel();
		xrPanel6 = new XRPanel();
		xrLine18 = new XRLine();
		xrLine16 = new XRLine();
		xrLine15 = new XRLine();
		xrLine48 = new XRLine();
		xrLine47 = new XRLine();
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
		xrLabel30 = new XRLabel();
		xrValorSeguro = new XRLabel();
		xrLine17 = new XRLine();
		xrTotalProd = new XRLabel();
		xrLabel36 = new XRLabel();
		xrBaseICMS = new XRLabel();
		xrLabel43 = new XRLabel();
		xrPanel9 = new XRPanel();
		xrDadosFatura = new XRLabel();
		xrPanel4 = new XRPanel();
		xrLine46 = new XRLine();
		xrLine12 = new XRLine();
		xrLine10 = new XRLine();
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
		xrLabel31 = new XRLabel();
		xrDestCEP = new XRLabel();
		xrLine11 = new XRLine();
		xrLabel29 = new XRLabel();
		xrDestBairro = new XRLabel();
		xrLabel27 = new XRLabel();
		xrDestCNPJ = new XRLabel();
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
		xrPanel8 = new XRPanel();
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
		xrPanel15 = new XRPanel();
		xrLabel128 = new XRLabel();
		xrEmitenteIE2 = new XRLabel();
		xrLine40 = new XRLine();
		xrLine41 = new XRLine();
		xrLabel117 = new XRLabel();
		xrEmitenteCNPJ2 = new XRLabel();
		xrLabel119 = new XRLabel();
		xrEmitenteInscST2 = new XRLabel();
		xrLine42 = new XRLine();
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
		xrChaveAcesso2 = new XRBarCode();
		xrPanel12 = new XRPanel();
		xrRazaoSocialEmitente2 = new XRLabel();
		xrEnderecoEmitente2 = new XRLabel();
		xrEnderecoEmitenteBairro2 = new XRLabel();
		xrEmitenteEnderecoCidade2 = new XRLabel();
		xrEmitenteTelefone2 = new XRLabel();
		xrLogo2 = new XRPictureBox();
		xrLabel28 = new XRLabel();
		xrLabel77 = new XRLabel();
		xrCrossBandBox1 = new XRCrossBandBox();
		GroupFooter1 = new GroupFooterBand();
		GroupHeader1 = new GroupHeaderBand();
		xrPanel16 = new XRPanel();
		xrLabel10 = new XRLabel();
		xrLabel71 = new XRLabel();
		xrLabel73 = new XRLabel();
		xrLabel76 = new XRLabel();
		xrLabel80 = new XRLabel();
		xrLabel81 = new XRLabel();
		xrLabel82 = new XRLabel();
		xrLabel96 = new XRLabel();
		xrLabel100 = new XRLabel();
		xrLabel101 = new XRLabel();
		xrLabel102 = new XRLabel();
		xrLabel103 = new XRLabel();
		xrLabel104 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrCrossBandLine1 = new XRCrossBandLine();
		xrCrossBandLine2 = new XRCrossBandLine();
		xrCrossBandLine3 = new XRCrossBandLine();
		xrCrossBandLine4 = new XRCrossBandLine();
		xrCrossBandLine5 = new XRCrossBandLine();
		ReportFooter = new ReportFooterBand();
		xrPanel10 = new XRPanel();
		xrLine38 = new XRLine();
		xrLabel55 = new XRLabel();
		xrLabel59 = new XRLabel();
		xrInfoCpl = new XRLabel();
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
		xrLabel14 = new XRLabel();
		xrLabel32 = new XRLabel();
		xrCrossBandLine6 = new XRCrossBandLine();
		xrCrossBandLine7 = new XRCrossBandLine();
		xrCrossBandLine8 = new XRCrossBandLine();
		xrCrossBandLine9 = new XRCrossBandLine();
		xrCrossBandLine10 = new XRCrossBandLine();
		xrCrossBandLine11 = new XRCrossBandLine();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrCrossBandLine12 = new XRCrossBandLine();
		xrCrossBandLine13 = new XRCrossBandLine();
		xrCrossBandLine14 = new XRCrossBandLine();
		xrCrossBandLine15 = new XRCrossBandLine();
		nfItensBindingSource = new BusinessObjectBindingSource(components);
		((ISupportInitialize)nfItensBindingSource).BeginInit();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Borders = (BorderSide)15;
		((XRControl)Detail).BorderWidth = 1f;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((XRControl)Detail).StylePriority.UseBorders = false;
		((XRControl)Detail).StylePriority.UseBorderWidth = false;
		((Band)Detail).SubBands.AddRange((SubBand[])(object)new SubBand[1] { SubBand1 });
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)Detail).BeforePrint += Detail_BeforePrint;
		((XRControl)SubBand1).Controls.AddRange((XRControl[])(object)new XRControl[20]
		{
			(XRControl)xrLabel57,
			(XRControl)xrLabel78,
			(XRControl)xrLabel85,
			(XRControl)txComentarioProduto,
			(XRControl)xrLabel64,
			(XRControl)xrLabel70,
			(XRControl)xrProdICMSAliq,
			(XRControl)xrProdICMS,
			(XRControl)xrProdBaseICMS,
			(XRControl)xrProdPT,
			(XRControl)xrProdPU,
			(XRControl)xrProdUN,
			(XRControl)xrProdQt,
			(XRControl)xrProdCFOP,
			(XRControl)xrProdST,
			(XRControl)xrProdNCM,
			(XRControl)xrProdDesc,
			(XRControl)xrProdCod,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4
		});
		((XRControl)SubBand1).HeightF = 15.46942f;
		((XRControl)SubBand1).KeepTogether = true;
		((XRControl)SubBand1).Name = "SubBand1";
		((XRControl)xrLabel57).Borders = (BorderSide)1;
		((XRControl)xrLabel57).BorderWidth = 0f;
		((XRControl)xrLabel57).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorUnitarioTributarioDanfe", "{0:n4}")
		});
		((XRControl)xrLabel57).Font = new Font("Arial", 7f);
		((XRControl)xrLabel57).LocationFloat = new PointFloat(662.8812f, 12.00002f);
		((XRControl)xrLabel57).Name = "xrLabel57";
		((XRControl)xrLabel57).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel57).ProcessNullValues = (ValueSuppressType)2;
		((XRControl)xrLabel57).SizeF = new SizeF(50.11884f, 2.083334f);
		((XRControl)xrLabel57).StylePriority.UseBorders = false;
		((XRControl)xrLabel57).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel57).StylePriority.UseFont = false;
		((XRControl)xrLabel57).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel57).Text = "xrProdPU";
		((XRControl)xrLabel57).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel78).Borders = (BorderSide)1;
		((XRControl)xrLabel78).BorderWidth = 0f;
		((XRControl)xrLabel78).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "SiglaFaturamentoTributarioDanfe")
		});
		((XRControl)xrLabel78).Font = new Font("Arial", 7f);
		((XRControl)xrLabel78).LocationFloat = new PointFloat(638.9808f, 12.00002f);
		((XRControl)xrLabel78).Name = "xrLabel78";
		((XRControl)xrLabel78).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel78).ProcessNullValues = (ValueSuppressType)2;
		((XRControl)xrLabel78).SizeF = new SizeF(22.00006f, 2.083334f);
		((XRControl)xrLabel78).StylePriority.UseBorders = false;
		((XRControl)xrLabel78).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel78).StylePriority.UseFont = false;
		((XRControl)xrLabel78).Text = "xrProdUN";
		((XRControl)xrLabel85).Borders = (BorderSide)1;
		((XRControl)xrLabel85).BorderWidth = 0f;
		((XRControl)xrLabel85).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "QuantidadeTributarioDanfe", "{0:0.###}")
		});
		((XRControl)xrLabel85).Font = new Font("Arial", 7f);
		((XRControl)xrLabel85).LocationFloat = new PointFloat(592.0225f, 12.00002f);
		((XRControl)xrLabel85).Name = "xrLabel85";
		((XRControl)xrLabel85).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel85).ProcessNullValues = (ValueSuppressType)2;
		((XRControl)xrLabel85).SizeF = new SizeF(45.9585f, 2.083334f);
		((XRControl)xrLabel85).StylePriority.UseBorders = false;
		((XRControl)xrLabel85).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel85).StylePriority.UseFont = false;
		((XRControl)xrLabel85).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel85).Text = "xrProdQt";
		((XRControl)xrLabel85).TextAlignment = (TextAlignment)4;
		((XRControl)txComentarioProduto).Borders = (BorderSide)0;
		((XRControl)txComentarioProduto).CanShrink = true;
		((XRControl)txComentarioProduto).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "DescricaoComplementar")
		});
		((XRControl)txComentarioProduto).Font = new Font("Arial", 7f);
		((XRControl)txComentarioProduto).LocationFloat = new PointFloat(112f, 12f);
		((XRControl)txComentarioProduto).Name = "txComentarioProduto";
		((XRControl)txComentarioProduto).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)txComentarioProduto).ProcessNullValues = (ValueSuppressType)2;
		((XRControl)txComentarioProduto).SizeF = new SizeF(344.1475f, 3.469419f);
		((XRControl)txComentarioProduto).StylePriority.UseBorders = false;
		((XRControl)txComentarioProduto).StylePriority.UseFont = false;
		((XRControl)txComentarioProduto).Text = "txComentarioProduto";
		((XRControl)xrLabel64).Borders = (BorderSide)0;
		((XRControl)xrLabel64).BorderWidth = 0f;
		((XRControl)xrLabel64).CanGrow = false;
		((XRControl)xrLabel64).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "AliquotaIPI", "{0:0.00}")
		});
		((XRControl)xrLabel64).Font = new Font("Arial", 6f);
		((XRControl)xrLabel64).LocationFloat = new PointFloat(933.1941f, 4.768372E-06f);
		((XRControl)xrLabel64).Name = "xrLabel64";
		((XRControl)xrLabel64).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel64).SizeF = new SizeF(21.00006f, 12f);
		((XRControl)xrLabel64).StylePriority.UseBorders = false;
		((XRControl)xrLabel64).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel64).StylePriority.UseFont = false;
		((XRControl)xrLabel64).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel64).Text = "xrLabel64";
		((XRControl)xrLabel64).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel64).WordWrap = false;
		((XRControl)xrLabel70).Borders = (BorderSide)1;
		((XRControl)xrLabel70).BorderWidth = 0f;
		((XRControl)xrLabel70).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorIPI", "{0:n2}")
		});
		((XRControl)xrLabel70).Font = new Font("Arial", 6f);
		((XRControl)xrLabel70).LocationFloat = new PointFloat(895.1944f, 0f);
		((XRControl)xrLabel70).Name = "xrLabel70";
		((XRControl)xrLabel70).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel70).SizeF = new SizeF(37f, 12f);
		((XRControl)xrLabel70).StylePriority.UseBorders = false;
		((XRControl)xrLabel70).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel70).StylePriority.UseFont = false;
		((XRControl)xrLabel70).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel70).Text = "xrLabel70";
		((XRControl)xrLabel70).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel70).WordWrap = false;
		((XRControl)xrProdICMSAliq).Borders = (BorderSide)0;
		((XRControl)xrProdICMSAliq).BorderWidth = 0f;
		((XRControl)xrProdICMSAliq).CanGrow = false;
		((XRControl)xrProdICMSAliq).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "AliquotaICMS", "{0:0.00}")
		});
		((XRControl)xrProdICMSAliq).Font = new Font("Arial", 6f);
		((XRControl)xrProdICMSAliq).LocationFloat = new PointFloat(868.9448f, 4.768372E-06f);
		((XRControl)xrProdICMSAliq).Name = "xrProdICMSAliq";
		((XRControl)xrProdICMSAliq).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdICMSAliq).SizeF = new SizeF(24.24982f, 12f);
		((XRControl)xrProdICMSAliq).StylePriority.UseBorders = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseFont = false;
		((XRControl)xrProdICMSAliq).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdICMSAliq).Text = "xrProdICMSAliq";
		((XRControl)xrProdICMSAliq).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdICMSAliq).WordWrap = false;
		((XRControl)xrProdICMS).Borders = (BorderSide)1;
		((XRControl)xrProdICMS).BorderWidth = 0f;
		((XRControl)xrProdICMS).CanGrow = false;
		((XRControl)xrProdICMS).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorICMS", "{0:n2}")
		});
		((XRControl)xrProdICMS).Font = new Font("Arial", 6f);
		((XRControl)xrProdICMS).LocationFloat = new PointFloat(831.9448f, 0f);
		((XRControl)xrProdICMS).Name = "xrProdICMS";
		((XRControl)xrProdICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdICMS).SizeF = new SizeF(37f, 12f);
		((XRControl)xrProdICMS).StylePriority.UseBorders = false;
		((XRControl)xrProdICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdICMS).StylePriority.UseFont = false;
		((XRControl)xrProdICMS).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdICMS).Text = "xrProdICMS";
		((XRControl)xrProdICMS).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdICMS).WordWrap = false;
		((XRControl)xrProdBaseICMS).Borders = (BorderSide)1;
		((XRControl)xrProdBaseICMS).BorderWidth = 0f;
		((XRControl)xrProdBaseICMS).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorBaseICMS", "{0:n2}")
		});
		((XRControl)xrProdBaseICMS).Font = new Font("Arial", 6f);
		((XRControl)xrProdBaseICMS).LocationFloat = new PointFloat(777.9446f, 0f);
		((XRControl)xrProdBaseICMS).Name = "xrProdBaseICMS";
		((XRControl)xrProdBaseICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdBaseICMS).SizeF = new SizeF(53.00012f, 12f);
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
		((XRControl)xrProdPT).Font = new Font("Arial", 7f);
		((XRControl)xrProdPT).LocationFloat = new PointFloat(717.0506f, 0f);
		((XRControl)xrProdPT).Name = "xrProdPT";
		((XRControl)xrProdPT).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdPT).SizeF = new SizeF(59.89404f, 12f);
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
		((XRControl)xrProdPU).Font = new Font("Arial", 7f);
		((XRControl)xrProdPU).LocationFloat = new PointFloat(662.8812f, 0f);
		((XRControl)xrProdPU).Name = "xrProdPU";
		((XRControl)xrProdPU).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdPU).SizeF = new SizeF(50.11884f, 12f);
		((XRControl)xrProdPU).StylePriority.UseBorders = false;
		((XRControl)xrProdPU).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdPU).StylePriority.UseFont = false;
		((XRControl)xrProdPU).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdPU).Text = "xrProdPU";
		((XRControl)xrProdPU).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdUN).Borders = (BorderSide)1;
		((XRControl)xrProdUN).BorderWidth = 0f;
		((XRControl)xrProdUN).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "SiglaUnidadeFaturamento")
		});
		((XRControl)xrProdUN).Font = new Font("Arial", 7f);
		((XRControl)xrProdUN).LocationFloat = new PointFloat(638.9809f, 4.768372E-06f);
		((XRControl)xrProdUN).Name = "xrProdUN";
		((XRControl)xrProdUN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdUN).SizeF = new SizeF(22f, 11f);
		((XRControl)xrProdUN).StylePriority.UseBorders = false;
		((XRControl)xrProdUN).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdUN).StylePriority.UseFont = false;
		((XRControl)xrProdUN).Text = "xrProdUN";
		((XRControl)xrProdQt).Borders = (BorderSide)1;
		((XRControl)xrProdQt).BorderWidth = 0f;
		((XRControl)xrProdQt).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Quantidade", "{0:0.###}")
		});
		((XRControl)xrProdQt).Font = new Font("Arial", 7f);
		((XRControl)xrProdQt).LocationFloat = new PointFloat(592.0224f, 0f);
		((XRControl)xrProdQt).Name = "xrProdQt";
		((XRControl)xrProdQt).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdQt).SizeF = new SizeF(45.9585f, 12f);
		((XRControl)xrProdQt).StylePriority.UseBorders = false;
		((XRControl)xrProdQt).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdQt).StylePriority.UseFont = false;
		((XRControl)xrProdQt).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdQt).Text = "xrProdQt";
		((XRControl)xrProdQt).TextAlignment = (TextAlignment)4;
		((XRControl)xrProdCFOP).Borders = (BorderSide)1;
		((XRControl)xrProdCFOP).BorderWidth = 0f;
		((XRControl)xrProdCFOP).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "NomeCfop")
		});
		((XRControl)xrProdCFOP).Font = new Font("Arial", 7f);
		((XRControl)xrProdCFOP).LocationFloat = new PointFloat(550.4807f, 0f);
		((XRControl)xrProdCFOP).Name = "xrProdCFOP";
		((XRControl)xrProdCFOP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdCFOP).SizeF = new SizeF(39.66672f, 12f);
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
		((XRControl)xrProdST).Font = new Font("Arial", 7f);
		((XRControl)xrProdST).LocationFloat = new PointFloat(515.6057f, 4.768372E-06f);
		((XRControl)xrProdST).Name = "xrProdST";
		((XRControl)xrProdST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdST).SizeF = new SizeF(33.875f, 12f);
		((XRControl)xrProdST).StylePriority.UseBorders = false;
		((XRControl)xrProdST).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdST).StylePriority.UseFont = false;
		((XRControl)xrProdST).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdST).Text = "xrProdST";
		((XRControl)xrProdST).TextAlignment = (TextAlignment)2;
		((XRControl)xrProdNCM).Borders = (BorderSide)1;
		((XRControl)xrProdNCM).BorderWidth = 0f;
		((XRControl)xrProdNCM).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoClassificacaoFiscal")
		});
		((XRControl)xrProdNCM).Font = new Font("Arial", 7f);
		((XRControl)xrProdNCM).LocationFloat = new PointFloat(460.1058f, 0f);
		((XRControl)xrProdNCM).Name = "xrProdNCM";
		((XRControl)xrProdNCM).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdNCM).SizeF = new SizeF(53.00005f, 12f);
		((XRControl)xrProdNCM).StylePriority.UseBorders = false;
		((XRControl)xrProdNCM).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdNCM).StylePriority.UseFont = false;
		((XRControl)xrProdNCM).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdNCM).Text = "00000000";
		((XRControl)xrProdNCM).TextAlignment = (TextAlignment)2;
		((XRControl)xrProdDesc).Borders = (BorderSide)1;
		((XRControl)xrProdDesc).BorderWidth = 0f;
		((XRControl)xrProdDesc).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "DescricaoProduto")
		});
		((XRControl)xrProdDesc).Font = new Font("Arial", 7f);
		((XRControl)xrProdDesc).LocationFloat = new PointFloat(111f, 0f);
		xrProdDesc.Multiline = true;
		((XRControl)xrProdDesc).Name = "xrProdDesc";
		((XRControl)xrProdDesc).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdDesc).SizeF = new SizeF(345.1475f, 12f);
		((XRControl)xrProdDesc).StylePriority.UseBorders = false;
		((XRControl)xrProdDesc).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdDesc).StylePriority.UseFont = false;
		((XRControl)xrProdDesc).Text = "[DescricaoProduto]";
		((XRControl)xrProdCod).Borders = (BorderSide)1;
		((XRControl)xrProdCod).BorderWidth = 0f;
		((XRControl)xrProdCod).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoProduto")
		});
		((XRControl)xrProdCod).Font = new Font("Arial", 7f);
		((XRControl)xrProdCod).LocationFloat = new PointFloat(1.041662f, 0f);
		xrProdCod.Multiline = true;
		((XRControl)xrProdCod).Name = "xrProdCod";
		((XRControl)xrProdCod).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProdCod).SizeF = new SizeF(108f, 12f);
		((XRControl)xrProdCod).StylePriority.UseBorders = false;
		((XRControl)xrProdCod).StylePriority.UseBorderWidth = false;
		((XRControl)xrProdCod).StylePriority.UseFont = false;
		((XRControl)xrProdCod).StylePriority.UseTextAlignment = false;
		((XRControl)xrProdCod).Text = "xrProdCod";
		((XRControl)xrProdCod).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel3).Borders = (BorderSide)1;
		((XRControl)xrLabel3).BorderWidth = 0f;
		((XRControl)xrLabel3).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorBaseAgragadaICMSST", "{0:n2}")
		});
		((XRControl)xrLabel3).Font = new Font("Arial", 6f);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(956.1671f, 0f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel3).SizeF = new SizeF(55.25568f, 12f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "xrProdBaseICMS";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel4).Borders = (BorderSide)1;
		((XRControl)xrLabel4).BorderWidth = 0f;
		((XRControl)xrLabel4).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "ValorICMSSTAgregado", "{0:n2}")
		});
		((XRControl)xrLabel4).Font = new Font("Arial", 6f);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(1014f, 0f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel4).SizeF = new SizeF(46f, 12f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "xrProdBaseICMS";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)4;
		((XRControl)PageHeader).Borders = (BorderSide)15;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[17]
		{
			(XRControl)xrProtocolo,
			(XRControl)xrLabel15,
			(XRControl)xrLabel17,
			(XRControl)xrChave,
			(XRControl)xrPanel18,
			(XRControl)xrPanel1,
			(XRControl)xrLabel5,
			(XRControl)xrLabel6,
			(XRControl)xrLabel7,
			(XRControl)xrLabel8,
			(XRControl)xrPanel2,
			(XRControl)xrNFeNum,
			(XRControl)xrLabel11,
			(XRControl)xrSerieNFe,
			(XRControl)xrPageInfo1,
			(XRControl)xrLabel13,
			(XRControl)xrPanel17
		});
		((Band)PageHeader).Expanded = false;
		((XRControl)PageHeader).HeightF = 152.2433f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((PageBand)PageHeader).PrintOn = (PrintOnPages)2;
		((XRControl)PageHeader).StylePriority.UseBorders = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)xrProtocolo).Borders = (BorderSide)13;
		((XRControl)xrProtocolo).BorderWidth = 1f;
		((XRControl)xrProtocolo).CanGrow = false;
		((XRControl)xrProtocolo).Font = new Font("Arial", 8f);
		((XRControl)xrProtocolo).LocationFloat = new PointFloat(638.9809f, 92.99999f);
		((XRControl)xrProtocolo).Name = "xrProtocolo";
		((XRControl)xrProtocolo).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProtocolo).SizeF = new SizeF(423.0193f, 17f);
		((XRControl)xrProtocolo).StylePriority.UseBorders = false;
		((XRControl)xrProtocolo).StylePriority.UseBorderWidth = false;
		((XRControl)xrProtocolo).StylePriority.UseFont = false;
		((XRControl)xrProtocolo).StylePriority.UseTextAlignment = false;
		((XRControl)xrProtocolo).Text = "xrNatOp";
		((XRControl)xrProtocolo).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel15).Borders = (BorderSide)13;
		((XRControl)xrLabel15).BorderWidth = 1f;
		((XRControl)xrLabel15).CanGrow = false;
		((XRControl)xrLabel15).Font = new Font("Arial", 5f);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(638.981f, 81.99998f);
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel15).SizeF = new SizeF(423.018f, 11f);
		((XRControl)xrLabel15).StylePriority.UseBorders = false;
		((XRControl)xrLabel15).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).Text = "PROTOCOLO DE AUTORIZAÇÃO";
		((XRControl)xrLabel17).Borders = (BorderSide)13;
		((XRControl)xrLabel17).BorderWidth = 1f;
		((XRControl)xrLabel17).Font = new Font("Arial", 5f);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(638.981f, 50.00002f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel17).SizeF = new SizeF(423.0181f, 12.00001f);
		((XRControl)xrLabel17).StylePriority.UseBorders = false;
		((XRControl)xrLabel17).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).Text = "CHAVE DE ACESSO DA NF-  CONSULTA DE AUTENTICIDADE NO SITE WWW.NFE.FAZENDA.GOV.BR";
		((XRControl)xrChave).Borders = (BorderSide)13;
		((XRControl)xrChave).BorderWidth = 1f;
		((XRControl)xrChave).Font = new Font("Arial", 8f);
		((XRControl)xrChave).LocationFloat = new PointFloat(638.981f, 62.99995f);
		((XRControl)xrChave).Name = "xrChave";
		((XRControl)xrChave).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrChave).SizeF = new SizeF(423.0181f, 18f);
		((XRControl)xrChave).StylePriority.UseBorders = false;
		((XRControl)xrChave).StylePriority.UseBorderWidth = false;
		((XRControl)xrChave).StylePriority.UseFont = false;
		((XRControl)xrChave).StylePriority.UseTextAlignment = false;
		((XRControl)xrChave).Text = "xrNatOp";
		((XRControl)xrChave).TextAlignment = (TextAlignment)512;
		((XRControl)xrPanel18).BorderWidth = 1f;
		((XRControl)xrPanel18).CanGrow = false;
		((XRControl)xrPanel18).Controls.AddRange((XRControl[])(object)new XRControl[11]
		{
			(XRControl)xrLabel21,
			(XRControl)xrEmitenteIE,
			(XRControl)xrLine3,
			(XRControl)xrLine6,
			(XRControl)xrLabel86,
			(XRControl)xrEmitenteCNPJ,
			(XRControl)xrLabel88,
			(XRControl)xrEmitenteInscST,
			(XRControl)xrLine7,
			(XRControl)xrNatOp,
			(XRControl)xrLabel91
		});
		((XRControl)xrPanel18).LocationFloat = new PointFloat(0f, 122.4649f);
		((XRControl)xrPanel18).Name = "xrPanel18";
		((XRControl)xrPanel18).SizeF = new SizeF(1062f, 29.77843f);
		((XRControl)xrPanel18).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel21).BorderWidth = 0f;
		((XRControl)xrLabel21).Font = new Font("Arial", 5f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(446f, 2.000007f);
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel21).SizeF = new SizeF(112f, 11f);
		((XRControl)xrLabel21).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrEmitenteIE).BorderWidth = 0f;
		((XRControl)xrEmitenteIE).CanGrow = false;
		((XRControl)xrEmitenteIE).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteIE).LocationFloat = new PointFloat(447f, 13.00001f);
		((XRControl)xrEmitenteIE).Name = "xrEmitenteIE";
		((XRControl)xrEmitenteIE).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteIE).SizeF = new SizeF(108f, 14f);
		((XRControl)xrEmitenteIE).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteIE).StylePriority.UseFont = false;
		((XRControl)xrEmitenteIE).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteIE).Text = "244.669.501.115";
		((XRControl)xrEmitenteIE).TextAlignment = (TextAlignment)256;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		xrLine3.LineDirection = (LineDirection)3;
		((XRControl)xrLine3).LocationFloat = new PointFloat(435f, 0f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(2.155182f, 29.77843f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine6).Borders = (BorderSide)0;
		xrLine6.LineDirection = (LineDirection)3;
		((XRControl)xrLine6).LocationFloat = new PointFloat(713f, 1.644266E-05f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).SizeF = new SizeF(2.999939f, 29.77842f);
		((XRControl)xrLine6).StylePriority.UseBorders = false;
		((XRControl)xrLabel86).BorderWidth = 0f;
		((XRControl)xrLabel86).Font = new Font("Arial", 5f);
		((XRControl)xrLabel86).LocationFloat = new PointFloat(724.9584f, 2.000008f);
		((XRControl)xrLabel86).Name = "xrLabel86";
		((XRControl)xrLabel86).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel86).SizeF = new SizeF(51f, 11f);
		((XRControl)xrLabel86).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel86).StylePriority.UseFont = false;
		((XRControl)xrLabel86).Text = "CNPJ";
		((XRControl)xrEmitenteCNPJ).BorderWidth = 0f;
		((XRControl)xrEmitenteCNPJ).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteCNPJ).LocationFloat = new PointFloat(724.9585f, 13.00001f);
		((XRControl)xrEmitenteCNPJ).Name = "xrEmitenteCNPJ";
		((XRControl)xrEmitenteCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteCNPJ).SizeF = new SizeF(115f, 14f);
		((XRControl)xrEmitenteCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteCNPJ).StylePriority.UseFont = false;
		((XRControl)xrEmitenteCNPJ).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrEmitenteCNPJ).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel88).BorderWidth = 0f;
		((XRControl)xrLabel88).Font = new Font("Arial", 5f);
		((XRControl)xrLabel88).LocationFloat = new PointFloat(592f, 2.000007f);
		((XRControl)xrLabel88).Name = "xrLabel88";
		((XRControl)xrLabel88).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel88).SizeF = new SizeF(91f, 11f);
		((XRControl)xrLabel88).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel88).StylePriority.UseFont = false;
		((XRControl)xrLabel88).Text = "INSC. SUBST. TRIB.";
		((XRControl)xrEmitenteInscST).BorderWidth = 0f;
		((XRControl)xrEmitenteInscST).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteInscST).LocationFloat = new PointFloat(592f, 13.00001f);
		((XRControl)xrEmitenteInscST).Name = "xrEmitenteInscST";
		((XRControl)xrEmitenteInscST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteInscST).SizeF = new SizeF(95f, 14f);
		((XRControl)xrEmitenteInscST).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteInscST).StylePriority.UseFont = false;
		((XRControl)xrEmitenteInscST).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteInscST).Text = "244.669.501.115";
		((XRControl)xrEmitenteInscST).TextAlignment = (TextAlignment)256;
		((XRControl)xrLine7).Borders = (BorderSide)0;
		xrLine7.LineDirection = (LineDirection)3;
		((XRControl)xrLine7).LocationFloat = new PointFloat(575f, 0f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(9f, 29.77843f);
		((XRControl)xrLine7).StylePriority.UseBorders = false;
		((XRControl)xrNatOp).BorderWidth = 0f;
		((XRControl)xrNatOp).CanGrow = false;
		((XRControl)xrNatOp).Font = new Font("Arial", 8f, FontStyle.Bold);
		((XRControl)xrNatOp).LocationFloat = new PointFloat(7.999994f, 13.00002f);
		((XRControl)xrNatOp).Name = "xrNatOp";
		((XRControl)xrNatOp).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNatOp).SizeF = new SizeF(417f, 13.99999f);
		((XRControl)xrNatOp).StylePriority.UseBorderWidth = false;
		((XRControl)xrNatOp).StylePriority.UseFont = false;
		((XRControl)xrNatOp).StylePriority.UseTextAlignment = false;
		((XRControl)xrNatOp).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel91).BorderWidth = 0f;
		((XRControl)xrLabel91).CanGrow = false;
		((XRControl)xrLabel91).Font = new Font("Arial", 5f);
		((XRControl)xrLabel91).LocationFloat = new PointFloat(8f, 2f);
		((XRControl)xrLabel91).Name = "xrLabel91";
		((XRControl)xrLabel91).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel91).SizeF = new SizeF(192f, 11f);
		((XRControl)xrLabel91).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel91).StylePriority.UseFont = false;
		((XRControl)xrLabel91).Text = "NATUREZA DA OPERAÇÃO";
		((XRControl)xrPanel1).BorderWidth = 1f;
		((XRControl)xrPanel1).CanGrow = false;
		((XRControl)xrPanel1).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrChaveAcesso });
		((XRControl)xrPanel1).LocationFloat = new PointFloat(638.981f, 0f);
		((XRControl)xrPanel1).Name = "xrPanel1";
		((XRControl)xrPanel1).SizeF = new SizeF(423.0185f, 50.00001f);
		((XRControl)xrPanel1).StylePriority.UseBorderWidth = false;
		xrChaveAcesso.AutoModule = true;
		((XRControl)xrChaveAcesso).BorderWidth = 0f;
		((XRControl)xrChaveAcesso).LocationFloat = new PointFloat(75.0191f, 6.000005f);
		((XRControl)xrChaveAcesso).Name = "xrChaveAcesso";
		((XRControl)xrChaveAcesso).Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrChaveAcesso.ShowText = false;
		((XRControl)xrChaveAcesso).SizeF = new SizeF(316.826f, 31.99994f);
		((XRControl)xrChaveAcesso).StylePriority.UseBorderWidth = false;
		((XRControl)xrChaveAcesso).StylePriority.UseTextAlignment = false;
		val.CharacterSet = (Code128Charset)105;
		xrChaveAcesso.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)xrChaveAcesso).Text = "0115550010000000180405822968";
		((XRControl)xrChaveAcesso).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).BorderWidth = 0f;
		((XRControl)xrLabel5).Font = new Font("Arial", 11f, FontStyle.Bold);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(533.106f, 0f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel5).SizeF = new SizeF(100f, 16f);
		((XRControl)xrLabel5).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "DANFE";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel6).BorderWidth = 0f;
		((XRControl)xrLabel6).Font = new Font("Arial", 6f);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(532.1061f, 15.99992f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel6).SizeF = new SizeF(101f, 22.00001f);
		((XRControl)xrLabel6).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Documento Auxiliar de Nota Fiscal Eletrônica";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel7).BorderWidth = 0f;
		((XRControl)xrLabel7).Font = new Font("Arial", 6f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(532.1061f, 39.99998f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel7).SizeF = new SizeF(65f, 13f);
		((XRControl)xrLabel7).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).Text = "0 - ENTRADA";
		((XRControl)xrLabel8).BorderWidth = 0f;
		((XRControl)xrLabel8).Font = new Font("Arial", 6f);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(532.1061f, 52f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel8).SizeF = new SizeF(65f, 14f);
		((XRControl)xrLabel8).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).Text = "1 - SAÍDA";
		((XRControl)xrPanel2).BorderWidth = 1f;
		((XRControl)xrPanel2).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrES1 });
		((XRControl)xrPanel2).LocationFloat = new PointFloat(607.1061f, 42.99997f);
		((XRControl)xrPanel2).Name = "xrPanel2";
		((XRControl)xrPanel2).SizeF = new SizeF(25f, 21f);
		((XRControl)xrPanel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrES1).BorderWidth = 0f;
		((XRControl)xrES1).Font = new Font("Times New Roman", 10f, FontStyle.Bold);
		((XRControl)xrES1).LocationFloat = new PointFloat(0f, 2f);
		((XRControl)xrES1).Name = "xrES1";
		((XRControl)xrES1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrES1).SizeF = new SizeF(25f, 18f);
		((XRControl)xrES1).StylePriority.UseBorderWidth = false;
		((XRControl)xrES1).StylePriority.UseFont = false;
		((XRControl)xrES1).StylePriority.UseTextAlignment = false;
		((XRControl)xrES1).Text = "1";
		((XRControl)xrES1).TextAlignment = (TextAlignment)2;
		((XRControl)xrNFeNum).BorderWidth = 0f;
		((XRControl)xrNFeNum).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrNFeNum).LocationFloat = new PointFloat(555.106f, 64.99993f);
		((XRControl)xrNFeNum).Name = "xrNFeNum";
		((XRControl)xrNFeNum).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNFeNum).SizeF = new SizeF(77f, 17f);
		((XRControl)xrNFeNum).StylePriority.UseBorderWidth = false;
		((XRControl)xrNFeNum).StylePriority.UseFont = false;
		((XRControl)xrNFeNum).Text = "000.000.000";
		((XRControl)xrLabel11).BorderWidth = 0f;
		((XRControl)xrLabel11).Font = new Font("Arial", 9f);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(533.106f, 64.99993f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel11).SizeF = new SizeF(21.99997f, 17f);
		((XRControl)xrLabel11).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).Text = "Nº";
		((XRControl)xrSerieNFe).AnchorHorizontal = (HorizontalAnchorStyles)1;
		((XRControl)xrSerieNFe).BorderWidth = 0f;
		((XRControl)xrSerieNFe).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrSerieNFe).LocationFloat = new PointFloat(533.106f, 81.99998f);
		((XRControl)xrSerieNFe).Name = "xrSerieNFe";
		((XRControl)xrSerieNFe).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNFe).SizeF = new SizeF(100f, 14f);
		((XRControl)xrSerieNFe).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNFe).StylePriority.UseFont = false;
		((XRControl)xrSerieNFe).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNFe).Text = "SÉRIE 1";
		((XRControl)xrSerieNFe).TextAlignment = (TextAlignment)2;
		((XRControl)xrPageInfo1).BorderWidth = 0f;
		((XRControl)xrPageInfo1).Font = new Font("Arial", 7f);
		((XRControl)xrPageInfo1).LocationFloat = new PointFloat(573.1061f, 95.99999f);
		((XRControl)xrPageInfo1).Name = "xrPageInfo1";
		((XRControl)xrPageInfo1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPageInfo1).SizeF = new SizeF(42f, 14f);
		((XRControl)xrPageInfo1).StylePriority.UseBorderWidth = false;
		((XRControl)xrPageInfo1).StylePriority.UseFont = false;
		((XRControl)xrPageInfo1).StylePriority.UseTextAlignment = false;
		((XRControl)xrPageInfo1).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel13).BorderWidth = 0f;
		((XRControl)xrLabel13).Font = new Font("Arial", 7f);
		((XRControl)xrLabel13).LocationFloat = new PointFloat(548.1061f, 95.99999f);
		((XRControl)xrLabel13).Name = "xrLabel13";
		((XRControl)xrLabel13).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel13).SizeF = new SizeF(33f, 14f);
		((XRControl)xrLabel13).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel13).StylePriority.UseFont = false;
		((XRControl)xrLabel13).Text = "FLS:";
		((XRControl)xrPanel17).BorderWidth = 1f;
		((XRControl)xrPanel17).CanGrow = false;
		((XRControl)xrPanel17).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrLogo,
			(XRControl)xrRazaoSocialEmitente,
			(XRControl)xrEnderecoEmitente,
			(XRControl)xrEnderecoEmitenteBairro,
			(XRControl)xrEmitenteEnderecoCidade,
			(XRControl)xrEmitenteTelefone
		});
		((XRControl)xrPanel17).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrPanel17).Name = "xrPanel17";
		((XRControl)xrPanel17).SizeF = new SizeF(513.1058f, 116f);
		((XRControl)xrPanel17).StylePriority.UseBorderWidth = false;
		((XRControl)xrLogo).BorderWidth = 0f;
		xrLogo.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrLogo.ImageSource"));
		((XRControl)xrLogo).LocationFloat = new PointFloat(7.000001f, 0f);
		((XRControl)xrLogo).Name = "xrLogo";
		((XRControl)xrLogo).SizeF = new SizeF(257.4457f, 110f);
		xrLogo.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente).BorderWidth = 0f;
		((XRControl)xrRazaoSocialEmitente).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrRazaoSocialEmitente).LocationFloat = new PointFloat(272.0225f, 15.99994f);
		xrRazaoSocialEmitente.Multiline = true;
		((XRControl)xrRazaoSocialEmitente).Name = "xrRazaoSocialEmitente";
		((XRControl)xrRazaoSocialEmitente).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrRazaoSocialEmitente).SizeF = new SizeF(229.9584f, 15f);
		((XRControl)xrRazaoSocialEmitente).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente).StylePriority.UseFont = false;
		((XRControl)xrRazaoSocialEmitente).Text = "R.Castro Cia Ltda.";
		((XRControl)xrEnderecoEmitente).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitente).Font = new Font("Arial", 7f);
		((XRControl)xrEnderecoEmitente).LocationFloat = new PointFloat(272.0225f, 31.99997f);
		((XRControl)xrEnderecoEmitente).Name = "xrEnderecoEmitente";
		((XRControl)xrEnderecoEmitente).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitente).SizeF = new SizeF(229.9584f, 11.99999f);
		((XRControl)xrEnderecoEmitente).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitente).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitente).Text = "Avenida Ferraz Alvim, 622";
		((XRControl)xrEnderecoEmitenteBairro).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitenteBairro).Font = new Font("Arial", 7f);
		((XRControl)xrEnderecoEmitenteBairro).LocationFloat = new PointFloat(272.0225f, 43.99995f);
		((XRControl)xrEnderecoEmitenteBairro).Name = "xrEnderecoEmitenteBairro";
		((XRControl)xrEnderecoEmitenteBairro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitenteBairro).SizeF = new SizeF(229.9584f, 12.00001f);
		((XRControl)xrEnderecoEmitenteBairro).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitenteBairro).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitenteBairro).Text = "Jardim Ruyce - CEP 09961-550";
		((XRControl)xrEmitenteEnderecoCidade).BorderWidth = 0f;
		((XRControl)xrEmitenteEnderecoCidade).Font = new Font("Arial", 7f);
		((XRControl)xrEmitenteEnderecoCidade).LocationFloat = new PointFloat(272.0225f, 54.99988f);
		((XRControl)xrEmitenteEnderecoCidade).Name = "xrEmitenteEnderecoCidade";
		((XRControl)xrEmitenteEnderecoCidade).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteEnderecoCidade).SizeF = new SizeF(229.9584f, 12f);
		((XRControl)xrEmitenteEnderecoCidade).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteEnderecoCidade).StylePriority.UseFont = false;
		((XRControl)xrEmitenteEnderecoCidade).Text = "Diadema - SP";
		((XRControl)xrEmitenteTelefone).BorderWidth = 0f;
		((XRControl)xrEmitenteTelefone).Font = new Font("Arial", 7f);
		((XRControl)xrEmitenteTelefone).LocationFloat = new PointFloat(272.0225f, 66.99995f);
		((XRControl)xrEmitenteTelefone).Name = "xrEmitenteTelefone";
		((XRControl)xrEmitenteTelefone).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteTelefone).SizeF = new SizeF(100f, 12f);
		((XRControl)xrEmitenteTelefone).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone).StylePriority.UseFont = false;
		((XRControl)xrEmitenteTelefone).Text = "(11) 4067-1130";
		((XRControl)PageFooter).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrPanel19,
			(XRControl)xrPanel20,
			(XRControl)xrLabel66,
			(XRControl)xrLabel87
		});
		((Band)PageFooter).Expanded = false;
		((XRControl)PageFooter).HeightF = 126.9583f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((PageBand)PageFooter).PrintOn = (PrintOnPages)4;
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)xrPanel19).Borders = (BorderSide)13;
		((XRControl)xrPanel19).BorderWidth = 1f;
		((XRControl)xrPanel19).CanGrow = false;
		((XRControl)xrPanel19).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrLine25,
			(XRControl)xrLabel1,
			(XRControl)xrLabel2,
			(XRControl)xrInfoCpl2
		});
		((XRControl)xrPanel19).LocationFloat = new PointFloat(29.02277f, 33.99996f);
		((XRControl)xrPanel19).Name = "xrPanel19";
		((XRControl)xrPanel19).SizeF = new SizeF(1032.977f, 92.95831f);
		((XRControl)xrPanel19).StylePriority.UseBorders = false;
		((XRControl)xrPanel19).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine25).Borders = (BorderSide)0;
		xrLine25.LineDirection = (LineDirection)3;
		((XRControl)xrLine25).LocationFloat = new PointFloat(561.1247f, 0f);
		((XRControl)xrLine25).Name = "xrLine25";
		((XRControl)xrLine25).SizeF = new SizeF(2f, 91f);
		((XRControl)xrLine25).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).BorderWidth = 0f;
		((XRControl)xrLabel1).Font = new Font("Arial", 6f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(7f, 2f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel1).SizeF = new SizeF(200f, 11f);
		((XRControl)xrLabel1).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).Text = "INFORMAÇÔES COMPLEMENTARES";
		((XRControl)xrLabel2).BorderWidth = 0f;
		((XRControl)xrLabel2).Font = new Font("Arial", 6f);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(566.9694f, 2.000007f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel2).SizeF = new SizeF(200f, 11f);
		((XRControl)xrLabel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).Text = "RESERVADO AO FISCO";
		((XRControl)xrInfoCpl2).BorderWidth = 0f;
		((XRControl)xrInfoCpl2).CanGrow = false;
		((XRControl)xrInfoCpl2).Font = new Font("Arial", 6f);
		((XRControl)xrInfoCpl2).LocationFloat = new PointFloat(7.999994f, 14.00003f);
		xrInfoCpl2.Multiline = true;
		((XRControl)xrInfoCpl2).Name = "xrInfoCpl2";
		((XRControl)xrInfoCpl2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrInfoCpl2).SizeF = new SizeF(550.1246f, 74f);
		((XRControl)xrInfoCpl2).StylePriority.UseBorderWidth = false;
		((XRControl)xrInfoCpl2).StylePriority.UseFont = false;
		((XRControl)xrPanel20).Borders = (BorderSide)15;
		((XRControl)xrPanel20).BorderWidth = 1f;
		((XRControl)xrPanel20).CanGrow = false;
		((XRControl)xrPanel20).Controls.AddRange((XRControl[])(object)new XRControl[11]
		{
			(XRControl)xrValorServico2,
			(XRControl)xrLabel9,
			(XRControl)xrBaseISSQN2,
			(XRControl)xrLine39,
			(XRControl)xrLabel12,
			(XRControl)xrLine45,
			(XRControl)xrLine49,
			(XRControl)xrValorISSQN2,
			(XRControl)xrLabel19,
			(XRControl)xrIM2,
			(XRControl)xrLabel46
		});
		((XRControl)xrPanel20).LocationFloat = new PointFloat(29.02274f, 0.0001100393f);
		((XRControl)xrPanel20).Name = "xrPanel20";
		((XRControl)xrPanel20).SizeF = new SizeF(1032.977f, 33.99997f);
		((XRControl)xrPanel20).StylePriority.UseBorders = false;
		((XRControl)xrPanel20).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorServico2).BorderWidth = 0f;
		((XRControl)xrValorServico2).Font = new Font("Arial", 8f);
		((XRControl)xrValorServico2).LocationFloat = new PointFloat(226.3103f, 14.37499f);
		((XRControl)xrValorServico2).Name = "xrValorServico2";
		((XRControl)xrValorServico2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorServico2).SizeF = new SizeF(200.8144f, 15.625f);
		((XRControl)xrValorServico2).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorServico2).StylePriority.UseFont = false;
		((XRControl)xrLabel9).BorderWidth = 0f;
		((XRControl)xrLabel9).Font = new Font("Arial", 7f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(450.5006f, 3.208305f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel9).SizeF = new SizeF(156.25f, 10.41667f);
		((XRControl)xrLabel9).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "BASE DE CÁLCULO DO ISSQN";
		((XRControl)xrBaseISSQN2).BorderWidth = 0f;
		((XRControl)xrBaseISSQN2).Font = new Font("Arial", 8f);
		((XRControl)xrBaseISSQN2).LocationFloat = new PointFloat(450.5006f, 14.37499f);
		((XRControl)xrBaseISSQN2).Name = "xrBaseISSQN2";
		((XRControl)xrBaseISSQN2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseISSQN2).SizeF = new SizeF(208.9839f, 15.625f);
		((XRControl)xrBaseISSQN2).StylePriority.UseBorderWidth = false;
		((XRControl)xrBaseISSQN2).StylePriority.UseFont = false;
		((XRControl)xrBaseISSQN2).Text = "xrNatOp";
		((XRControl)xrLine39).Borders = (BorderSide)0;
		xrLine39.LineDirection = (LineDirection)3;
		((XRControl)xrLine39).LocationFloat = new PointFloat(429.5006f, 0f);
		((XRControl)xrLine39).Name = "xrLine39";
		((XRControl)xrLine39).SizeF = new SizeF(11.49908f, 33.99996f);
		((XRControl)xrLine39).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).BorderWidth = 0f;
		((XRControl)xrLabel12).Font = new Font("Arial", 7f);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(226.3103f, 3.208305f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel12).SizeF = new SizeF(166.6667f, 10.41667f);
		((XRControl)xrLabel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).Text = "VALOR TOTAL DOS SERVIÇOS";
		((XRControl)xrLine45).Borders = (BorderSide)0;
		xrLine45.LineDirection = (LineDirection)3;
		((XRControl)xrLine45).LocationFloat = new PointFloat(212.1247f, 0f);
		((XRControl)xrLine45).Name = "xrLine45";
		((XRControl)xrLine45).SizeF = new SizeF(2.130676f, 33.99996f);
		((XRControl)xrLine45).StylePriority.UseBorders = false;
		((XRControl)xrLine49).Borders = (BorderSide)0;
		xrLine49.LineDirection = (LineDirection)3;
		((XRControl)xrLine49).LocationFloat = new PointFloat(669.9941f, 0f);
		((XRControl)xrLine49).Name = "xrLine49";
		((XRControl)xrLine49).SizeF = new SizeF(2.130676f, 33.99996f);
		((XRControl)xrLine49).StylePriority.UseBorders = false;
		((XRControl)xrValorISSQN2).BorderWidth = 0f;
		((XRControl)xrValorISSQN2).Font = new Font("Arial", 8f);
		((XRControl)xrValorISSQN2).LocationFloat = new PointFloat(678.1248f, 14.37499f);
		((XRControl)xrValorISSQN2).Name = "xrValorISSQN2";
		((XRControl)xrValorISSQN2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorISSQN2).SizeF = new SizeF(225.2086f, 15.625f);
		((XRControl)xrValorISSQN2).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorISSQN2).StylePriority.UseFont = false;
		((XRControl)xrValorISSQN2).Text = "xrNatOp";
		((XRControl)xrLabel19).BorderWidth = 0f;
		((XRControl)xrLabel19).Font = new Font("Arial", 7f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(678.1248f, 3.20829f);
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel19).SizeF = new SizeF(189.0079f, 10.41667f);
		((XRControl)xrLabel19).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).Text = "VALOR DO ISSQN";
		((XRControl)xrIM2).BorderWidth = 0f;
		((XRControl)xrIM2).Font = new Font("Arial", 8f);
		((XRControl)xrIM2).LocationFloat = new PointFloat(8.000015f, 14.37499f);
		((XRControl)xrIM2).Name = "xrIM2";
		((XRControl)xrIM2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrIM2).SizeF = new SizeF(192.7083f, 15.625f);
		((XRControl)xrIM2).StylePriority.UseBorderWidth = false;
		((XRControl)xrIM2).StylePriority.UseFont = false;
		((XRControl)xrLabel46).BorderWidth = 0f;
		((XRControl)xrLabel46).Font = new Font("Arial", 7f);
		((XRControl)xrLabel46).LocationFloat = new PointFloat(8.000015f, 3.208305f);
		((XRControl)xrLabel46).Name = "xrLabel46";
		((XRControl)xrLabel46).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel46).SizeF = new SizeF(140.625f, 10.41667f);
		((XRControl)xrLabel46).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel46).StylePriority.UseFont = false;
		((XRControl)xrLabel46).Text = "INSCRIÇÃO MUNICIPAL";
		xrLabel66.Angle = 90f;
		((XRControl)xrLabel66).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel66).Borders = (BorderSide)11;
		((XRControl)xrLabel66).BorderWidth = 1f;
		((XRControl)xrLabel66).CanGrow = false;
		((XRControl)xrLabel66).Font = new Font("Arial", 6f, FontStyle.Bold);
		((XRControl)xrLabel66).LocationFloat = new PointFloat(0f, 32.95834f);
		((XRControl)xrLabel66).Name = "xrLabel66";
		((XRControl)xrLabel66).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel66).SizeF = new SizeF(29.02274f, 93.99998f);
		((XRControl)xrLabel66).StylePriority.UseBackColor = false;
		((XRControl)xrLabel66).StylePriority.UseBorders = false;
		((XRControl)xrLabel66).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel66).StylePriority.UseFont = false;
		((XRControl)xrLabel66).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel66).Text = "DADOS ADICIONAIS";
		((XRControl)xrLabel66).TextAlignment = (TextAlignment)32;
		xrLabel87.Angle = 90f;
		((XRControl)xrLabel87).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel87).Borders = (BorderSide)11;
		((XRControl)xrLabel87).BorderWidth = 1f;
		((XRControl)xrLabel87).CanGrow = false;
		((XRControl)xrLabel87).Font = new Font("Arial", 5f, FontStyle.Bold);
		((XRControl)xrLabel87).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel87).Name = "xrLabel87";
		((XRControl)xrLabel87).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel87).SizeF = new SizeF(29.02274f, 33.99997f);
		((XRControl)xrLabel87).StylePriority.UseBackColor = false;
		((XRControl)xrLabel87).StylePriority.UseBorders = false;
		((XRControl)xrLabel87).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel87).StylePriority.UseFont = false;
		((XRControl)xrLabel87).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel87).Text = "CÁLC  DO ISSQN";
		((XRControl)xrLabel87).TextAlignment = (TextAlignment)32;
		((XRControl)ReportHeader).Borders = (BorderSide)15;
		((XRControl)ReportHeader).BorderWidth = 1f;
		((XRControl)ReportHeader).Controls.AddRange((XRControl[])(object)new XRControl[23]
		{
			(XRControl)xrProtocolo2,
			(XRControl)xrLabel122,
			(XRControl)xrChave2,
			(XRControl)xrLabel124,
			(XRControl)xrPanel21,
			(XRControl)xrLine50,
			(XRControl)xrLabel18,
			(XRControl)xrFirstPageOnly,
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
			(XRControl)xrLabel28,
			(XRControl)xrLabel77
		});
		((Band)ReportHeader).Expanded = false;
		((XRControl)ReportHeader).HeightF = 493.3753f;
		((XRControl)ReportHeader).Name = "ReportHeader";
		((XRControl)ReportHeader).StylePriority.UseBorders = false;
		((XRControl)ReportHeader).StylePriority.UseBorderWidth = false;
		((XRControl)xrProtocolo2).Borders = (BorderSide)13;
		((XRControl)xrProtocolo2).BorderWidth = 1f;
		((XRControl)xrProtocolo2).CanGrow = false;
		((XRControl)xrProtocolo2).Font = new Font("Arial", 8f);
		((XRControl)xrProtocolo2).LocationFloat = new PointFloat(638.981f, 181.9999f);
		((XRControl)xrProtocolo2).Name = "xrProtocolo2";
		((XRControl)xrProtocolo2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrProtocolo2).SizeF = new SizeF(421.0194f, 11.99997f);
		((XRControl)xrProtocolo2).StylePriority.UseBorders = false;
		((XRControl)xrProtocolo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrProtocolo2).StylePriority.UseFont = false;
		((XRControl)xrProtocolo2).StylePriority.UseTextAlignment = false;
		((XRControl)xrProtocolo2).Text = "xrNatOp";
		((XRControl)xrProtocolo2).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel122).Borders = (BorderSide)5;
		((XRControl)xrLabel122).BorderWidth = 1f;
		((XRControl)xrLabel122).CanGrow = false;
		((XRControl)xrLabel122).Font = new Font("Arial", 5f);
		((XRControl)xrLabel122).LocationFloat = new PointFloat(638.981f, 170.9999f);
		((XRControl)xrLabel122).Name = "xrLabel122";
		((XRControl)xrLabel122).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel122).SizeF = new SizeF(421.0194f, 11f);
		((XRControl)xrLabel122).StylePriority.UseBorders = false;
		((XRControl)xrLabel122).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel122).StylePriority.UseFont = false;
		((XRControl)xrLabel122).Text = "PROTOCOLO DE AUTORIZAÇÃO";
		((XRControl)xrChave2).Borders = (BorderSide)13;
		((XRControl)xrChave2).BorderWidth = 1f;
		((XRControl)xrChave2).Font = new Font("Arial", 8f);
		((XRControl)xrChave2).LocationFloat = new PointFloat(638.981f, 127.9999f);
		((XRControl)xrChave2).Name = "xrChave2";
		((XRControl)xrChave2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrChave2).SizeF = new SizeF(421.0194f, 17.00003f);
		((XRControl)xrChave2).StylePriority.UseBorders = false;
		((XRControl)xrChave2).StylePriority.UseBorderWidth = false;
		((XRControl)xrChave2).StylePriority.UseFont = false;
		((XRControl)xrChave2).StylePriority.UseTextAlignment = false;
		((XRControl)xrChave2).Text = "xrNatOp";
		((XRControl)xrChave2).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel124).Borders = (BorderSide)7;
		((XRControl)xrLabel124).BorderWidth = 1f;
		((XRControl)xrLabel124).Font = new Font("Arial", 5f);
		((XRControl)xrLabel124).LocationFloat = new PointFloat(638.981f, 116.9999f);
		((XRControl)xrLabel124).Name = "xrLabel124";
		((XRControl)xrLabel124).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel124).SizeF = new SizeF(421.0194f, 11f);
		((XRControl)xrLabel124).StylePriority.UseBorders = false;
		((XRControl)xrLabel124).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel124).StylePriority.UseFont = false;
		((XRControl)xrLabel124).Text = "CHAVE DE ACESSO";
		((XRControl)xrPanel21).BorderWidth = 1f;
		((XRControl)xrPanel21).Controls.AddRange((XRControl[])(object)new XRControl[10]
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
		((XRControl)xrPanel21).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrPanel21).Name = "xrPanel21";
		((XRControl)xrPanel21).SizeF = new SizeF(1059.958f, 67f);
		((XRControl)xrPanel21).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel83).BorderWidth = 0f;
		((XRControl)xrLabel83).Font = new Font("Arial", 7f);
		((XRControl)xrLabel83).LocationFloat = new PointFloat(0f, 33f);
		((XRControl)xrLabel83).Name = "xrLabel83";
		((XRControl)xrLabel83).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel83).SizeF = new SizeF(129f, 25f);
		((XRControl)xrLabel83).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel83).StylePriority.UseFont = false;
		((XRControl)xrLabel83).Text = "Data de Recebimento";
		((XRControl)xrShape4).BorderWidth = 0f;
		((XRControl)xrShape4).LocationFloat = new PointFloat(953.1671f, 0f);
		((XRControl)xrShape4).Name = "xrShape4";
		xrShape4.Shape = (ShapeBase)(object)shape;
		((XRControl)xrShape4).SizeF = new SizeF(2f, 67f);
		((XRControl)xrShape4).StylePriority.UseBorderWidth = false;
		xrShape5.Angle = 270;
		((XRControl)xrShape5).BorderWidth = 0f;
		((XRControl)xrShape5).LocationFloat = new PointFloat(0f, 24.99999f);
		((XRControl)xrShape5).Name = "xrShape5";
		xrShape5.Shape = (ShapeBase)(object)shape2;
		((XRControl)xrShape5).SizeF = new SizeF(953.1671f, 2.10084f);
		((XRControl)xrShape5).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe2).BorderWidth = 0f;
		((XRControl)xrRecebemosDe2).Font = new Font("Arial", 8f);
		((XRControl)xrRecebemosDe2).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrRecebemosDe2).Name = "xrRecebemosDe2";
		((XRControl)xrRecebemosDe2).Padding = new PaddingInfo(4, 2, 4, 0, 100f);
		((XRControl)xrRecebemosDe2).SizeF = new SizeF(955.167f, 25f);
		((XRControl)xrRecebemosDe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrRecebemosDe2).StylePriority.UseFont = false;
		((XRControl)xrRecebemosDe2).StylePriority.UsePadding = false;
		((XRControl)xrRecebemosDe2).Text = "RECEBEMOS DE EDILSON VASCONCELOS DE MELO JUNIOR OS PRODUTOS CONSTANTES DA NOTA FISCAL INDICADA AO LADO";
		((XRControl)xrShape6).BorderWidth = 0f;
		((XRControl)xrShape6).LocationFloat = new PointFloat(125f, 25f);
		((XRControl)xrShape6).Name = "xrShape6";
		xrShape6.Shape = (ShapeBase)(object)shape3;
		((XRControl)xrShape6).SizeF = new SizeF(8f, 42f);
		((XRControl)xrShape6).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel97).BorderWidth = 0f;
		((XRControl)xrLabel97).Font = new Font("Arial", 7f);
		((XRControl)xrLabel97).LocationFloat = new PointFloat(142f, 33f);
		((XRControl)xrLabel97).Name = "xrLabel97";
		((XRControl)xrLabel97).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel97).SizeF = new SizeF(258f, 25f);
		((XRControl)xrLabel97).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel97).StylePriority.UseFont = false;
		((XRControl)xrLabel97).Text = "Identificação e Assinatura do Recebedor";
		((XRControl)xrLabel98).BorderWidth = 0f;
		((XRControl)xrLabel98).Font = new Font("Arial", 9f);
		((XRControl)xrLabel98).LocationFloat = new PointFloat(976.0001f, 6.999969f);
		((XRControl)xrLabel98).Name = "xrLabel98";
		((XRControl)xrLabel98).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel98).SizeF = new SizeF(74f, 18f);
		((XRControl)xrLabel98).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel98).StylePriority.UseFont = false;
		((XRControl)xrLabel98).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel98).Text = "NF-e";
		((XRControl)xrLabel98).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel99).BorderWidth = 0f;
		((XRControl)xrLabel99).Font = new Font("Arial", 9f);
		((XRControl)xrLabel99).LocationFloat = new PointFloat(955.1671f, 23.99996f);
		((XRControl)xrLabel99).Name = "xrLabel99";
		((XRControl)xrLabel99).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel99).SizeF = new SizeF(25f, 25f);
		((XRControl)xrLabel99).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel99).StylePriority.UseFont = false;
		((XRControl)xrLabel99).Text = "Nº";
		((XRControl)xrNroNFe2).BorderWidth = 0f;
		((XRControl)xrNroNFe2).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrNroNFe2).LocationFloat = new PointFloat(976.0001f, 23.99996f);
		((XRControl)xrNroNFe2).Name = "xrNroNFe2";
		((XRControl)xrNroNFe2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNFe2).SizeF = new SizeF(80.00006f, 17f);
		((XRControl)xrNroNFe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNFe2).StylePriority.UseFont = false;
		((XRControl)xrNroNFe2).Text = "000.000.000";
		((XRControl)xrSerieNF2).BorderWidth = 0f;
		((XRControl)xrSerieNF2).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrSerieNF2).LocationFloat = new PointFloat(976.0001f, 40.99998f);
		((XRControl)xrSerieNF2).Name = "xrSerieNF2";
		((XRControl)xrSerieNF2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNF2).SizeF = new SizeF(82f, 17f);
		((XRControl)xrSerieNF2).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNF2).StylePriority.UseFont = false;
		((XRControl)xrSerieNF2).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNF2).Text = "SÉRIE 1";
		((XRControl)xrSerieNF2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLine50).BorderWidth = 0f;
		xrLine50.LineStyle = DashStyle.Dash;
		((XRControl)xrLine50).LocationFloat = new PointFloat(0f, 69.99991f);
		((XRControl)xrLine50).Name = "xrLine50";
		((XRControl)xrLine50).SizeF = new SizeF(1061.999f, 2f);
		((XRControl)xrLine50).StylePriority.UseBorderWidth = false;
		xrLabel18.Angle = 90f;
		((XRControl)xrLabel18).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel18).Borders = (BorderSide)13;
		((XRControl)xrLabel18).BorderWidth = 1f;
		((XRControl)xrLabel18).CanGrow = false;
		((XRControl)xrLabel18).Font = new Font("Arial", 6f, FontStyle.Bold);
		((XRControl)xrLabel18).LocationFloat = new PointFloat(0f, 223.7783f);
		((XRControl)xrLabel18).Name = "xrLabel18";
		((XRControl)xrLabel18).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel18).SizeF = new SizeF(29.02274f, 87.22165f);
		((XRControl)xrLabel18).StylePriority.UseBackColor = false;
		((XRControl)xrLabel18).StylePriority.UseBorders = false;
		((XRControl)xrLabel18).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel18).StylePriority.UseFont = false;
		((XRControl)xrLabel18).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel18).Text = "DESTINATÁRIO / REMETENTE";
		((XRControl)xrLabel18).TextAlignment = (TextAlignment)32;
		((XRControl)xrFirstPageOnly).Borders = (BorderSide)0;
		((XRControl)xrFirstPageOnly).BorderWidth = 1f;
		((XRControl)xrFirstPageOnly).CanGrow = false;
		((XRControl)xrFirstPageOnly).Controls.AddRange((XRControl[])(object)new XRControl[9]
		{
			(XRControl)xrLine32,
			(XRControl)xrLabel84,
			(XRControl)xrLabel42,
			(XRControl)xrLabel23,
			(XRControl)xrPanel6,
			(XRControl)xrPanel9,
			(XRControl)xrPanel4,
			(XRControl)xrPanel5,
			(XRControl)xrPanel8
		});
		((XRControl)xrFirstPageOnly).LocationFloat = new PointFloat(0f, 223.7784f);
		((XRControl)xrFirstPageOnly).Name = "xrFirstPageOnly";
		((XRControl)xrFirstPageOnly).SizeF = new SizeF(1060.958f, 269.1366f);
		((XRControl)xrFirstPageOnly).StylePriority.UseBorders = false;
		((XRControl)xrFirstPageOnly).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine32).Borders = (BorderSide)0;
		((XRControl)xrLine32).LocationFloat = new PointFloat(27.68542f, 200.7544f);
		((XRControl)xrLine32).Name = "xrLine32";
		((XRControl)xrLine32).SizeF = new SizeF(1032.273f, 3.245483f);
		((XRControl)xrLine32).StylePriority.UseBorders = false;
		xrLabel84.Angle = 90f;
		((XRControl)xrLabel84).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel84).Borders = (BorderSide)13;
		((XRControl)xrLabel84).BorderWidth = 1f;
		((XRControl)xrLabel84).CanGrow = false;
		((XRControl)xrLabel84).Font = new Font("Arial", 4f, FontStyle.Bold);
		((XRControl)xrLabel84).LocationFloat = new PointFloat(0f, 137f);
		((XRControl)xrLabel84).Name = "xrLabel84";
		((XRControl)xrLabel84).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel84).SizeF = new SizeF(29.02274f, 33.99997f);
		((XRControl)xrLabel84).StylePriority.UseBackColor = false;
		((XRControl)xrLabel84).StylePriority.UseBorders = false;
		((XRControl)xrLabel84).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel84).StylePriority.UseFont = false;
		((XRControl)xrLabel84).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel84).Text = "CÁLCULO DO IMPOSTO";
		((XRControl)xrLabel84).TextAlignment = (TextAlignment)32;
		xrLabel42.Angle = 90f;
		((XRControl)xrLabel42).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel42).Borders = (BorderSide)13;
		((XRControl)xrLabel42).BorderWidth = 1f;
		((XRControl)xrLabel42).CanGrow = false;
		((XRControl)xrLabel42).Font = new Font("Arial", 6f, FontStyle.Bold);
		((XRControl)xrLabel42).LocationFloat = new PointFloat(0f, 87.22165f);
		((XRControl)xrLabel42).Name = "xrLabel42";
		((XRControl)xrLabel42).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel42).SizeF = new SizeF(29.02274f, 49.77837f);
		((XRControl)xrLabel42).StylePriority.UseBackColor = false;
		((XRControl)xrLabel42).StylePriority.UseBorders = false;
		((XRControl)xrLabel42).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel42).StylePriority.UseFont = false;
		((XRControl)xrLabel42).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel42).Text = "FATURA / DUPLICATA";
		((XRControl)xrLabel42).TextAlignment = (TextAlignment)32;
		xrLabel23.Angle = 90f;
		((XRControl)xrLabel23).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel23).Borders = (BorderSide)13;
		((XRControl)xrLabel23).BorderWidth = 1f;
		((XRControl)xrLabel23).CanGrow = false;
		((XRControl)xrLabel23).Font = new Font("Arial", 5f, FontStyle.Bold);
		((XRControl)xrLabel23).LocationFloat = new PointFloat(0f, 170.9999f);
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel23).SizeF = new SizeF(29.02274f, 98.13663f);
		((XRControl)xrLabel23).StylePriority.UseBackColor = false;
		((XRControl)xrLabel23).StylePriority.UseBorders = false;
		((XRControl)xrLabel23).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel23).StylePriority.UseFont = false;
		((XRControl)xrLabel23).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel23).Text = "TRANSPORTADORA / VOLUMES TRANSPORTADOS";
		((XRControl)xrLabel23).TextAlignment = (TextAlignment)32;
		((XRControl)xrPanel6).Borders = (BorderSide)12;
		((XRControl)xrPanel6).BorderWidth = 1f;
		((XRControl)xrPanel6).CanGrow = false;
		((XRControl)xrPanel6).Controls.AddRange((XRControl[])(object)new XRControl[32]
		{
			(XRControl)xrLine18,
			(XRControl)xrLine16,
			(XRControl)xrLine15,
			(XRControl)xrLine48,
			(XRControl)xrLine47,
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
			(XRControl)xrLabel30,
			(XRControl)xrValorSeguro,
			(XRControl)xrLine17,
			(XRControl)xrTotalProd,
			(XRControl)xrLabel36,
			(XRControl)xrBaseICMS,
			(XRControl)xrLabel43
		});
		((XRControl)xrPanel6).LocationFloat = new PointFloat(27.98126f, 137f);
		((XRControl)xrPanel6).Name = "xrPanel6";
		((XRControl)xrPanel6).SizeF = new SizeF(1031.977f, 33.99998f);
		((XRControl)xrPanel6).StylePriority.UseBorders = false;
		((XRControl)xrPanel6).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine18).Borders = (BorderSide)0;
		xrLine18.LineDirection = (LineDirection)3;
		((XRControl)xrLine18).LocationFloat = new PointFloat(821.9628f, 0f);
		((XRControl)xrLine18).Name = "xrLine18";
		((XRControl)xrLine18).SizeF = new SizeF(2.245544f, 33.99998f);
		((XRControl)xrLine18).StylePriority.UseBorders = false;
		((XRControl)xrLine16).Borders = (BorderSide)0;
		xrLine16.LineDirection = (LineDirection)3;
		((XRControl)xrLine16).LocationFloat = new PointFloat(741.3805f, 3.426375E-05f);
		((XRControl)xrLine16).Name = "xrLine16";
		((XRControl)xrLine16).SizeF = new SizeF(2.245483f, 33.99995f);
		((XRControl)xrLine16).StylePriority.UseBorders = false;
		((XRControl)xrLine15).Borders = (BorderSide)0;
		xrLine15.LineDirection = (LineDirection)3;
		((XRControl)xrLine15).LocationFloat = new PointFloat(659.0916f, 0f);
		((XRControl)xrLine15).Name = "xrLine15";
		((XRControl)xrLine15).SizeF = new SizeF(2.245544f, 33.99998f);
		((XRControl)xrLine15).StylePriority.UseBorders = false;
		((XRControl)xrLine48).Borders = (BorderSide)0;
		xrLine48.LineDirection = (LineDirection)3;
		((XRControl)xrLine48).LocationFloat = new PointFloat(493.7318f, 0f);
		((XRControl)xrLine48).Name = "xrLine48";
		((XRControl)xrLine48).SizeF = new SizeF(2.245544f, 33.99998f);
		((XRControl)xrLine48).StylePriority.UseBorders = false;
		((XRControl)xrLine47).Borders = (BorderSide)0;
		xrLine47.LineDirection = (LineDirection)3;
		((XRControl)xrLine47).LocationFloat = new PointFloat(410.2154f, 0.9999532f);
		((XRControl)xrLine47).Name = "xrLine47";
		((XRControl)xrLine47).SizeF = new SizeF(2.245514f, 33.00003f);
		((XRControl)xrLine47).StylePriority.UseBorders = false;
		((XRControl)xrLine22).Borders = (BorderSide)0;
		xrLine22.LineDirection = (LineDirection)3;
		((XRControl)xrLine22).LocationFloat = new PointFloat(328.6068f, 0f);
		((XRControl)xrLine22).Name = "xrLine22";
		((XRControl)xrLine22).SizeF = new SizeF(2.245514f, 33.99998f);
		((XRControl)xrLine22).StylePriority.UseBorders = false;
		((XRControl)xrValorOutras).BorderWidth = 0f;
		((XRControl)xrValorOutras).Font = new Font("Arial", 8f);
		((XRControl)xrValorOutras).LocationFloat = new PointFloat(579.4561f, 18.66118f);
		((XRControl)xrValorOutras).Name = "xrValorOutras";
		((XRControl)xrValorOutras).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorOutras).SizeF = new SizeF(78.52118f, 13.00001f);
		((XRControl)xrValorOutras).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorOutras).StylePriority.UseFont = false;
		((XRControl)xrValorOutras).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorOutras).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel52).BorderWidth = 0f;
		((XRControl)xrLabel52).Font = new Font("Arial", 5f);
		((XRControl)xrLabel52).LocationFloat = new PointFloat(579.4561f, 1.000056f);
		((XRControl)xrLabel52).Name = "xrLabel52";
		((XRControl)xrLabel52).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel52).SizeF = new SizeF(71f, 9f);
		((XRControl)xrLabel52).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel52).StylePriority.UseFont = false;
		((XRControl)xrLabel52).Text = "Outras";
		((XRControl)xrValorDesconto).BorderWidth = 0f;
		((XRControl)xrValorDesconto).Font = new Font("Arial", 8f);
		((XRControl)xrValorDesconto).LocationFloat = new PointFloat(496.6437f, 18.66118f);
		((XRControl)xrValorDesconto).Name = "xrValorDesconto";
		((XRControl)xrValorDesconto).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorDesconto).SizeF = new SizeF(80.33359f, 13.00001f);
		((XRControl)xrValorDesconto).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorDesconto).StylePriority.UseFont = false;
		((XRControl)xrValorDesconto).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorDesconto).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel25).BorderWidth = 0f;
		((XRControl)xrLabel25).Font = new Font("Arial", 5f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(496.6437f, 1.000022f);
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel25).SizeF = new SizeF(49.45618f, 9.000008f);
		((XRControl)xrLabel25).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).Text = "Desconto";
		((XRControl)xrLabel51).BorderWidth = 0f;
		((XRControl)xrLabel51).Font = new Font("Arial", 5f);
		((XRControl)xrLabel51).LocationFloat = new PointFloat(412.4609f, 1.000053f);
		((XRControl)xrLabel51).Name = "xrLabel51";
		((XRControl)xrLabel51).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel51).SizeF = new SizeF(56.8129f, 9.000008f);
		((XRControl)xrLabel51).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel51).StylePriority.UseFont = false;
		((XRControl)xrLabel51).Text = "Valor do Frete";
		((XRControl)xrValorFrete).BorderWidth = 0f;
		((XRControl)xrValorFrete).Font = new Font("Arial", 8f);
		((XRControl)xrValorFrete).LocationFloat = new PointFloat(412.4609f, 18.66118f);
		((XRControl)xrValorFrete).Name = "xrValorFrete";
		((XRControl)xrValorFrete).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorFrete).SizeF = new SizeF(81.27084f, 13.00001f);
		((XRControl)xrValorFrete).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorFrete).StylePriority.UseFont = false;
		((XRControl)xrValorFrete).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorFrete).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel49).BorderWidth = 0f;
		((XRControl)xrLabel49).CanGrow = false;
		((XRControl)xrLabel49).Font = new Font("Arial", 5f);
		((XRControl)xrLabel49).LocationFloat = new PointFloat(167.4561f, 1.000022f);
		((XRControl)xrLabel49).Name = "xrLabel49";
		((XRControl)xrLabel49).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel49).SizeF = new SizeF(69.00832f, 9.000008f);
		((XRControl)xrLabel49).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel49).StylePriority.UseFont = false;
		((XRControl)xrLabel49).Text = " B. Cálc ICMS Subst";
		((XRControl)xrBaseST).BorderWidth = 0f;
		((XRControl)xrBaseST).CanGrow = false;
		((XRControl)xrBaseST).Font = new Font("Arial", 8f);
		((XRControl)xrBaseST).LocationFloat = new PointFloat(167.4561f, 18.66118f);
		((XRControl)xrBaseST).Name = "xrBaseST";
		((XRControl)xrBaseST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseST).SizeF = new SizeF(76.52118f, 13.00001f);
		((XRControl)xrBaseST).StylePriority.UseBorderWidth = false;
		((XRControl)xrBaseST).StylePriority.UseFont = false;
		((XRControl)xrBaseST).StylePriority.UseTextAlignment = false;
		((XRControl)xrBaseST).TextAlignment = (TextAlignment)4;
		((XRControl)xrLine21).Borders = (BorderSide)0;
		xrLine21.LineDirection = (LineDirection)3;
		((XRControl)xrLine21).LocationFloat = new PointFloat(165.4561f, 1.000022f);
		((XRControl)xrLine21).Name = "xrLine21";
		((XRControl)xrLine21).SizeF = new SizeF(2.245514f, 32.99996f);
		((XRControl)xrLine21).StylePriority.UseBorders = false;
		((XRControl)xrLabel47).BorderWidth = 0f;
		((XRControl)xrLabel47).CanGrow = false;
		((XRControl)xrLabel47).Font = new Font("Arial", 5f);
		((XRControl)xrLabel47).LocationFloat = new PointFloat(250.9773f, 1.000022f);
		((XRControl)xrLabel47).Name = "xrLabel47";
		((XRControl)xrLabel47).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel47).SizeF = new SizeF(73.12517f, 9.000008f);
		((XRControl)xrLabel47).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel47).StylePriority.UseFont = false;
		((XRControl)xrLabel47).Text = "Valor ICMS Subst";
		((XRControl)xrValorST).BorderWidth = 0f;
		((XRControl)xrValorST).CanGrow = false;
		((XRControl)xrValorST).Font = new Font("Arial", 8f);
		((XRControl)xrValorST).LocationFloat = new PointFloat(249.5607f, 18.66118f);
		((XRControl)xrValorST).Name = "xrValorST";
		((XRControl)xrValorST).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorST).SizeF = new SizeF(75.72348f, 13.00001f);
		((XRControl)xrValorST).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorST).StylePriority.UseFont = false;
		((XRControl)xrValorST).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorST).Text = "xrNatOp";
		((XRControl)xrValorST).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel45).BorderWidth = 0f;
		((XRControl)xrLabel45).Font = new Font("Arial", 5f);
		((XRControl)xrLabel45).LocationFloat = new PointFloat(662.331f, 1.00009f);
		((XRControl)xrLabel45).Name = "xrLabel45";
		((XRControl)xrLabel45).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel45).SizeF = new SizeF(54.0191f, 8.99999f);
		((XRControl)xrLabel45).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel45).StylePriority.UseFont = false;
		((XRControl)xrLabel45).Text = "Valor do IPI";
		((XRControl)xrValorIPI).BorderWidth = 0f;
		((XRControl)xrValorIPI).Font = new Font("Arial", 8f);
		((XRControl)xrValorIPI).LocationFloat = new PointFloat(662.331f, 18.66118f);
		((XRControl)xrValorIPI).Name = "xrValorIPI";
		((XRControl)xrValorIPI).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorIPI).SizeF = new SizeF(79.0495f, 13.00001f);
		((XRControl)xrValorIPI).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorIPI).StylePriority.UseFont = false;
		((XRControl)xrValorIPI).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorIPI).Text = "xrNatOp";
		((XRControl)xrValorIPI).TextAlignment = (TextAlignment)4;
		((XRControl)xrLine20).Borders = (BorderSide)0;
		xrLine20.LineDirection = (LineDirection)3;
		((XRControl)xrLine20).LocationFloat = new PointFloat(246.2106f, 1.000022f);
		((XRControl)xrLine20).Name = "xrLine20";
		((XRControl)xrLine20).SizeF = new SizeF(2.245514f, 32.99996f);
		((XRControl)xrLine20).StylePriority.UseBorders = false;
		((XRControl)xrTotalNota).BorderWidth = 0f;
		((XRControl)xrTotalNota).Font = new Font("Arial", 8f, FontStyle.Bold);
		((XRControl)xrTotalNota).LocationFloat = new PointFloat(825.2085f, 18.66118f);
		((XRControl)xrTotalNota).Name = "xrTotalNota";
		((XRControl)xrTotalNota).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTotalNota).SizeF = new SizeF(83.97705f, 13.00001f);
		((XRControl)xrTotalNota).StylePriority.UseBorderWidth = false;
		((XRControl)xrTotalNota).StylePriority.UseFont = false;
		((XRControl)xrTotalNota).StylePriority.UseTextAlignment = false;
		((XRControl)xrTotalNota).Text = "xrNatOp";
		((XRControl)xrTotalNota).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel38).BorderWidth = 0f;
		((XRControl)xrLabel38).Font = new Font("Arial", 5f, FontStyle.Bold);
		((XRControl)xrLabel38).LocationFloat = new PointFloat(825.2085f, 1.000125f);
		((XRControl)xrLabel38).Name = "xrLabel38";
		((XRControl)xrLabel38).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel38).SizeF = new SizeF(79.97742f, 8.99999f);
		((XRControl)xrLabel38).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel38).StylePriority.UseFont = false;
		((XRControl)xrLabel38).Text = "Total da Nota";
		((XRControl)xrValorICMS).BorderWidth = 0f;
		((XRControl)xrValorICMS).CanGrow = false;
		((XRControl)xrValorICMS).Font = new Font("Arial", 8f);
		((XRControl)xrValorICMS).LocationFloat = new PointFloat(82.97726f, 20.99996f);
		((XRControl)xrValorICMS).Name = "xrValorICMS";
		((XRControl)xrValorICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorICMS).SizeF = new SizeF(80.47885f, 13.00001f);
		((XRControl)xrValorICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorICMS).StylePriority.UseFont = false;
		((XRControl)xrValorICMS).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorICMS).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel40).BorderWidth = 0f;
		((XRControl)xrLabel40).CanGrow = false;
		((XRControl)xrLabel40).Font = new Font("Arial", 5f);
		((XRControl)xrLabel40).LocationFloat = new PointFloat(82.97729f, 0f);
		((XRControl)xrLabel40).Name = "xrLabel40";
		((XRControl)xrLabel40).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel40).SizeF = new SizeF(50.47882f, 8.99999f);
		((XRControl)xrLabel40).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel40).StylePriority.UseFont = false;
		((XRControl)xrLabel40).Text = "Valor do ICMS";
		((XRControl)xrLine19).Borders = (BorderSide)0;
		xrLine19.LineDirection = (LineDirection)3;
		((XRControl)xrLine19).LocationFloat = new PointFloat(80.97726f, 0f);
		((XRControl)xrLine19).Name = "xrLine19";
		((XRControl)xrLine19).SizeF = new SizeF(2.245506f, 33.99998f);
		((XRControl)xrLine19).StylePriority.UseBorders = false;
		((XRControl)xrLabel30).BorderWidth = 0f;
		((XRControl)xrLabel30).Font = new Font("Arial", 5f);
		((XRControl)xrLabel30).LocationFloat = new PointFloat(332.8523f, 1.000039f);
		((XRControl)xrLabel30).Name = "xrLabel30";
		((XRControl)xrLabel30).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel30).SizeF = new SizeF(61.97726f, 9.000023f);
		((XRControl)xrLabel30).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel30).StylePriority.UseFont = false;
		((XRControl)xrLabel30).Text = "Valor do Seguro";
		((XRControl)xrValorSeguro).BorderWidth = 0f;
		((XRControl)xrValorSeguro).Font = new Font("Times New Roman", 8f);
		((XRControl)xrValorSeguro).LocationFloat = new PointFloat(332.8523f, 18.66118f);
		((XRControl)xrValorSeguro).Name = "xrValorSeguro";
		((XRControl)xrValorSeguro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorSeguro).SizeF = new SizeF(75.28021f, 13.00001f);
		((XRControl)xrValorSeguro).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorSeguro).StylePriority.UseFont = false;
		((XRControl)xrValorSeguro).StylePriority.UseTextAlignment = false;
		((XRControl)xrValorSeguro).TextAlignment = (TextAlignment)4;
		((XRControl)xrLine17).Borders = (BorderSide)0;
		xrLine17.LineDirection = (LineDirection)3;
		((XRControl)xrLine17).LocationFloat = new PointFloat(576.9774f, 0f);
		((XRControl)xrLine17).Name = "xrLine17";
		((XRControl)xrLine17).SizeF = new SizeF(2.245483f, 33.99998f);
		((XRControl)xrLine17).StylePriority.UseBorders = false;
		((XRControl)xrTotalProd).BorderWidth = 0f;
		((XRControl)xrTotalProd).CanGrow = false;
		((XRControl)xrTotalProd).Font = new Font("Arial", 8f);
		((XRControl)xrTotalProd).LocationFloat = new PointFloat(744.3805f, 18.66118f);
		((XRControl)xrTotalProd).Name = "xrTotalProd";
		((XRControl)xrTotalProd).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTotalProd).SizeF = new SizeF(77.58228f, 13.00001f);
		((XRControl)xrTotalProd).StylePriority.UseBorderWidth = false;
		((XRControl)xrTotalProd).StylePriority.UseFont = false;
		((XRControl)xrTotalProd).StylePriority.UseTextAlignment = false;
		((XRControl)xrTotalProd).Text = "xrNatOp";
		((XRControl)xrTotalProd).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel36).BorderWidth = 0f;
		((XRControl)xrLabel36).CanGrow = false;
		((XRControl)xrLabel36).Font = new Font("Arial", 5f);
		((XRControl)xrLabel36).LocationFloat = new PointFloat(744.3805f, 0.9999532f);
		((XRControl)xrLabel36).Name = "xrLabel36";
		((XRControl)xrLabel36).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel36).SizeF = new SizeF(68.52032f, 9.000008f);
		((XRControl)xrLabel36).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel36).StylePriority.UseFont = false;
		((XRControl)xrLabel36).Text = "Valor Total Produtos";
		((XRControl)xrBaseICMS).BorderWidth = 0f;
		((XRControl)xrBaseICMS).CanGrow = false;
		((XRControl)xrBaseICMS).Font = new Font("Arial", 8f);
		((XRControl)xrBaseICMS).LocationFloat = new PointFloat(1.852566f, 13.00012f);
		((XRControl)xrBaseICMS).Name = "xrBaseICMS";
		((XRControl)xrBaseICMS).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseICMS).SizeF = new SizeF(76.12474f, 13.00001f);
		((XRControl)xrBaseICMS).StylePriority.UseBorderWidth = false;
		((XRControl)xrBaseICMS).StylePriority.UseFont = false;
		((XRControl)xrBaseICMS).StylePriority.UseTextAlignment = false;
		((XRControl)xrBaseICMS).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel43).BorderWidth = 0f;
		((XRControl)xrLabel43).CanGrow = false;
		((XRControl)xrLabel43).Font = new Font("Arial", 5f);
		((XRControl)xrLabel43).LocationFloat = new PointFloat(3.857124f, 0f);
		((XRControl)xrLabel43).Name = "xrLabel43";
		((XRControl)xrLabel43).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel43).SizeF = new SizeF(62.97726f, 8.99999f);
		((XRControl)xrLabel43).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel43).StylePriority.UseFont = false;
		((XRControl)xrLabel43).Text = "Base Cálc ICMS";
		((XRControl)xrPanel9).Borders = (BorderSide)14;
		((XRControl)xrPanel9).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrDadosFatura });
		((XRControl)xrPanel9).LocationFloat = new PointFloat(27.68542f, 86.99997f);
		((XRControl)xrPanel9).Name = "xrPanel9";
		((XRControl)xrPanel9).SizeF = new SizeF(1032.273f, 50f);
		((XRControl)xrPanel9).StylePriority.UseBorders = false;
		((XRControl)xrDadosFatura).BorderWidth = 0f;
		((XRControl)xrDadosFatura).CanGrow = false;
		((XRControl)xrDadosFatura).Font = new Font("Arial", 9f);
		((XRControl)xrDadosFatura).LocationFloat = new PointFloat(2.147927f, 1.999965f);
		xrDadosFatura.Multiline = true;
		((XRControl)xrDadosFatura).Name = "xrDadosFatura";
		((XRControl)xrDadosFatura).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDadosFatura).SizeF = new SizeF(1022.167f, 45.66124f);
		((XRControl)xrDadosFatura).StylePriority.UseBorderWidth = false;
		((XRControl)xrDadosFatura).StylePriority.UseFont = false;
		((XRControl)xrPanel4).Borders = (BorderSide)0;
		((XRControl)xrPanel4).CanGrow = false;
		((XRControl)xrPanel4).Controls.AddRange((XRControl[])(object)new XRControl[26]
		{
			(XRControl)xrLine46,
			(XRControl)xrLine12,
			(XRControl)xrLine10,
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
			(XRControl)xrLabel31,
			(XRControl)xrDestCEP,
			(XRControl)xrLine11,
			(XRControl)xrLabel29,
			(XRControl)xrDestBairro,
			(XRControl)xrLabel27,
			(XRControl)xrDestCNPJ,
			(XRControl)xrDestRazaoSocial,
			(XRControl)xrLabel20,
			(XRControl)xrLine9,
			(XRControl)xrLine8
		});
		((XRControl)xrPanel4).LocationFloat = new PointFloat(28.83325f, 0f);
		((XRControl)xrPanel4).Name = "xrPanel4";
		((XRControl)xrPanel4).SizeF = new SizeF(865.3613f, 86.99998f);
		((XRControl)xrPanel4).StylePriority.UseBorders = false;
		((XRControl)xrLine46).Borders = (BorderSide)0;
		xrLine46.LineDirection = (LineDirection)3;
		((XRControl)xrLine46).LocationFloat = new PointFloat(426.4486f, 59.99998f);
		((XRControl)xrLine46).Name = "xrLine46";
		((XRControl)xrLine46).SizeF = new SizeF(2.155304f, 27.22162f);
		((XRControl)xrLine46).StylePriority.UseBorders = false;
		((XRControl)xrLine12).Borders = (BorderSide)0;
		xrLine12.LineDirection = (LineDirection)3;
		((XRControl)xrLine12).LocationFloat = new PointFloat(713.3429f, 0f);
		((XRControl)xrLine12).Name = "xrLine12";
		((XRControl)xrLine12).SizeF = new SizeF(2.155304f, 29f);
		((XRControl)xrLine12).StylePriority.UseBorders = false;
		((XRControl)xrLine10).Borders = (BorderSide)0;
		xrLine10.LineDirection = (LineDirection)3;
		((XRControl)xrLine10).LocationFloat = new PointFloat(567.1589f, 0f);
		((XRControl)xrLine10).Name = "xrLine10";
		((XRControl)xrLine10).SizeF = new SizeF(2.155304f, 29f);
		((XRControl)xrLine10).StylePriority.UseBorders = false;
		((XRControl)xrLabel41).BorderWidth = 0f;
		((XRControl)xrLabel41).CanGrow = false;
		((XRControl)xrLabel41).Font = new Font("Arial", 5f);
		((XRControl)xrLabel41).LocationFloat = new PointFloat(3.99991f, 61.00002f);
		((XRControl)xrLabel41).Name = "xrLabel41";
		((XRControl)xrLabel41).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel41).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel41).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel41).StylePriority.UseFont = false;
		((XRControl)xrLabel41).Text = "CIDADE";
		((XRControl)xrDestCidade).BorderWidth = 0f;
		((XRControl)xrDestCidade).CanGrow = false;
		((XRControl)xrDestCidade).Font = new Font("Arial", 8f);
		((XRControl)xrDestCidade).LocationFloat = new PointFloat(3.999907f, 72.00002f);
		((XRControl)xrDestCidade).Name = "xrDestCidade";
		((XRControl)xrDestCidade).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCidade).SizeF = new SizeF(367.1252f, 13.00001f);
		((XRControl)xrDestCidade).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCidade).StylePriority.UseFont = false;
		((XRControl)xrDestCidade).Text = "07.577.462/0001-15";
		((XRControl)xrLabel39).BorderWidth = 0f;
		((XRControl)xrLabel39).CanGrow = false;
		((XRControl)xrLabel39).Font = new Font("Arial", 5f);
		((XRControl)xrLabel39).LocationFloat = new PointFloat(3.004854f, 31.22159f);
		((XRControl)xrLabel39).Name = "xrLabel39";
		((XRControl)xrLabel39).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel39).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel39).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel39).StylePriority.UseFont = false;
		((XRControl)xrLabel39).Text = "ENDEREÇO";
		((XRControl)xrDestEndereco).BorderWidth = 0f;
		((XRControl)xrDestEndereco).CanGrow = false;
		((XRControl)xrDestEndereco).Font = new Font("Arial", 8f);
		((XRControl)xrDestEndereco).LocationFloat = new PointFloat(3.999905f, 42.2216f);
		((XRControl)xrDestEndereco).Name = "xrDestEndereco";
		((XRControl)xrDestEndereco).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestEndereco).SizeF = new SizeF(413.6458f, 14f);
		((XRControl)xrDestEndereco).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestEndereco).StylePriority.UseFont = false;
		((XRControl)xrDestEndereco).Text = "07.577.462/0001-15";
		((XRControl)xrLine14).Borders = (BorderSide)0;
		xrLine14.LineDirection = (LineDirection)3;
		((XRControl)xrLine14).LocationFloat = new PointFloat(377.6039f, 57.99994f);
		((XRControl)xrLine14).Name = "xrLine14";
		((XRControl)xrLine14).SizeF = new SizeF(3f, 31f);
		((XRControl)xrLine14).StylePriority.UseBorders = false;
		((XRControl)xrLabel37).BorderWidth = 0f;
		((XRControl)xrLabel37).CanGrow = false;
		((XRControl)xrLabel37).Font = new Font("Arial", 5f);
		((XRControl)xrLabel37).LocationFloat = new PointFloat(384.125f, 61f);
		((XRControl)xrLabel37).Name = "xrLabel37";
		((XRControl)xrLabel37).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel37).SizeF = new SizeF(25f, 11f);
		((XRControl)xrLabel37).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel37).StylePriority.UseFont = false;
		((XRControl)xrLabel37).Text = "UF";
		((XRControl)xrDestUF).BorderWidth = 0f;
		((XRControl)xrDestUF).CanGrow = false;
		((XRControl)xrDestUF).Font = new Font("Arial", 8f);
		((XRControl)xrDestUF).LocationFloat = new PointFloat(384.1251f, 72.00002f);
		((XRControl)xrDestUF).Name = "xrDestUF";
		((XRControl)xrDestUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestUF).SizeF = new SizeF(32.47885f, 13.00001f);
		((XRControl)xrDestUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestUF).StylePriority.UseFont = false;
		((XRControl)xrDestUF).Text = "SP";
		((XRControl)xrLabel35).BorderWidth = 0f;
		((XRControl)xrLabel35).CanGrow = false;
		((XRControl)xrLabel35).Font = new Font("Arial", 5f);
		((XRControl)xrLabel35).LocationFloat = new PointFloat(437.1251f, 61f);
		((XRControl)xrLabel35).Name = "xrLabel35";
		((XRControl)xrLabel35).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel35).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel35).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel35).StylePriority.UseFont = false;
		((XRControl)xrLabel35).Text = "FONE";
		((XRControl)xrDestFone).BorderWidth = 0f;
		((XRControl)xrDestFone).CanGrow = false;
		((XRControl)xrDestFone).Font = new Font("Arial", 8f);
		((XRControl)xrDestFone).LocationFloat = new PointFloat(438.1251f, 73f);
		((XRControl)xrDestFone).Name = "xrDestFone";
		((XRControl)xrDestFone).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestFone).SizeF = new SizeF(125f, 13f);
		((XRControl)xrDestFone).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestFone).StylePriority.UseFont = false;
		((XRControl)xrDestFone).Text = "07.577.462/0001-15";
		((XRControl)xrLine13).Borders = (BorderSide)0;
		xrLine13.LineDirection = (LineDirection)3;
		((XRControl)xrLine13).LocationFloat = new PointFloat(567.1251f, 60.22159f);
		((XRControl)xrLine13).Name = "xrLine13";
		((XRControl)xrLine13).SizeF = new SizeF(3f, 27.00002f);
		((XRControl)xrLine13).StylePriority.UseBorders = false;
		((XRControl)xrLabel33).BorderWidth = 0f;
		((XRControl)xrLabel33).CanGrow = false;
		((XRControl)xrLabel33).Font = new Font("Arial", 5f);
		((XRControl)xrLabel33).LocationFloat = new PointFloat(733.3613f, 2.221588f);
		((XRControl)xrLabel33).Name = "xrLabel33";
		((XRControl)xrLabel33).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel33).SizeF = new SizeF(122f, 11f);
		((XRControl)xrLabel33).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel33).StylePriority.UseFont = false;
		((XRControl)xrLabel33).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrDestIE).BorderWidth = 0f;
		((XRControl)xrDestIE).CanGrow = false;
		((XRControl)xrDestIE).Font = new Font("Arial", 8f);
		((XRControl)xrDestIE).LocationFloat = new PointFloat(733.3613f, 15.99998f);
		((XRControl)xrDestIE).Name = "xrDestIE";
		((XRControl)xrDestIE).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestIE).SizeF = new SizeF(122f, 13f);
		((XRControl)xrDestIE).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestIE).StylePriority.UseFont = false;
		((XRControl)xrDestIE).Text = "07.577.462/0001-15";
		((XRControl)xrLabel31).BorderWidth = 0f;
		((XRControl)xrLabel31).CanGrow = false;
		((XRControl)xrLabel31).Font = new Font("Arial", 5f);
		((XRControl)xrLabel31).LocationFloat = new PointFloat(574.1251f, 61f);
		((XRControl)xrLabel31).Name = "xrLabel31";
		((XRControl)xrLabel31).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel31).SizeF = new SizeF(58f, 11f);
		((XRControl)xrLabel31).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel31).StylePriority.UseFont = false;
		((XRControl)xrLabel31).Text = "CEP";
		((XRControl)xrDestCEP).BorderWidth = 0f;
		((XRControl)xrDestCEP).CanGrow = false;
		((XRControl)xrDestCEP).Font = new Font("Arial", 8f);
		((XRControl)xrDestCEP).LocationFloat = new PointFloat(582.1251f, 72f);
		((XRControl)xrDestCEP).Name = "xrDestCEP";
		((XRControl)xrDestCEP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCEP).SizeF = new SizeF(75f, 14f);
		((XRControl)xrDestCEP).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCEP).StylePriority.UseFont = false;
		((XRControl)xrDestCEP).Text = "13.026-075";
		((XRControl)xrLine11).Borders = (BorderSide)0;
		xrLine11.LineDirection = (LineDirection)3;
		((XRControl)xrLine11).LocationFloat = new PointFloat(425.6039f, 28.00001f);
		((XRControl)xrLine11).Name = "xrLine11";
		((XRControl)xrLine11).SizeF = new SizeF(4f, 32.00001f);
		((XRControl)xrLine11).StylePriority.UseBorders = false;
		((XRControl)xrLabel29).BorderWidth = 0f;
		((XRControl)xrLabel29).CanGrow = false;
		((XRControl)xrLabel29).Font = new Font("Arial", 5f);
		((XRControl)xrLabel29).LocationFloat = new PointFloat(438.1251f, 31.22159f);
		((XRControl)xrLabel29).Name = "xrLabel29";
		((XRControl)xrLabel29).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel29).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel29).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel29).StylePriority.UseFont = false;
		((XRControl)xrLabel29).Text = "BAIRRO";
		((XRControl)xrDestBairro).BorderWidth = 0f;
		((XRControl)xrDestBairro).CanGrow = false;
		((XRControl)xrDestBairro).Font = new Font("Arial", 8f);
		((XRControl)xrDestBairro).LocationFloat = new PointFloat(438.1251f, 42.22161f);
		((XRControl)xrDestBairro).Name = "xrDestBairro";
		((XRControl)xrDestBairro).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestBairro).SizeF = new SizeF(359.5213f, 14f);
		((XRControl)xrDestBairro).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestBairro).StylePriority.UseFont = false;
		((XRControl)xrDestBairro).Text = "07.577.462/0001-15";
		((XRControl)xrLabel27).BorderWidth = 0f;
		((XRControl)xrLabel27).CanGrow = false;
		((XRControl)xrLabel27).Font = new Font("Arial", 5f);
		((XRControl)xrLabel27).LocationFloat = new PointFloat(581.5213f, 2.221588f);
		((XRControl)xrLabel27).Name = "xrLabel27";
		((XRControl)xrLabel27).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel27).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel27).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel27).StylePriority.UseFont = false;
		((XRControl)xrLabel27).Text = "CNPJ";
		((XRControl)xrDestCNPJ).BorderWidth = 0f;
		((XRControl)xrDestCNPJ).CanGrow = false;
		((XRControl)xrDestCNPJ).Font = new Font("Arial", 8f);
		((XRControl)xrDestCNPJ).LocationFloat = new PointFloat(582.1251f, 13.22159f);
		((XRControl)xrDestCNPJ).Name = "xrDestCNPJ";
		((XRControl)xrDestCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestCNPJ).SizeF = new SizeF(125f, 13f);
		((XRControl)xrDestCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestCNPJ).StylePriority.UseFont = false;
		((XRControl)xrDestCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrDestRazaoSocial).BorderWidth = 0f;
		((XRControl)xrDestRazaoSocial).CanGrow = false;
		((XRControl)xrDestRazaoSocial).Font = new Font("Times New Roman", 8f);
		((XRControl)xrDestRazaoSocial).LocationFloat = new PointFloat(3.004853f, 13.22158f);
		((XRControl)xrDestRazaoSocial).Name = "xrDestRazaoSocial";
		((XRControl)xrDestRazaoSocial).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDestRazaoSocial).SizeF = new SizeF(555.3092f, 13.00003f);
		((XRControl)xrDestRazaoSocial).StylePriority.UseBorderWidth = false;
		((XRControl)xrDestRazaoSocial).StylePriority.UseFont = false;
		((XRControl)xrLabel20).BorderWidth = 0f;
		((XRControl)xrLabel20).CanGrow = false;
		((XRControl)xrLabel20).Font = new Font("Arial", 5f);
		((XRControl)xrLabel20).LocationFloat = new PointFloat(3.125031f, 2.221588f);
		((XRControl)xrLabel20).Name = "xrLabel20";
		((XRControl)xrLabel20).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel20).SizeF = new SizeF(192f, 11f);
		((XRControl)xrLabel20).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel20).StylePriority.UseFont = false;
		((XRControl)xrLabel20).Text = "RAZÃO SOCIAL";
		((XRControl)xrLine9).Borders = (BorderSide)0;
		((XRControl)xrLine9).LocationFloat = new PointFloat(0f, 56.22158f);
		((XRControl)xrLine9).Name = "xrLine9";
		((XRControl)xrLine9).SizeF = new SizeF(865.3613f, 3.778393f);
		((XRControl)xrLine9).StylePriority.UseBorders = false;
		((XRControl)xrLine8).Borders = (BorderSide)0;
		((XRControl)xrLine8).LocationFloat = new PointFloat(0f, 28.00001f);
		((XRControl)xrLine8).Name = "xrLine8";
		((XRControl)xrLine8).SizeF = new SizeF(865.3613f, 3.221575f);
		((XRControl)xrLine8).StylePriority.UseBorders = false;
		((XRControl)xrPanel5).Borders = (BorderSide)5;
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
		((XRControl)xrPanel5).LocationFloat = new PointFloat(894.1945f, 0f);
		((XRControl)xrPanel5).Name = "xrPanel5";
		((XRControl)xrPanel5).SizeF = new SizeF(165.7636f, 87f);
		((XRControl)xrPanel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel26).BorderWidth = 0f;
		((XRControl)xrLabel26).CanGrow = false;
		((XRControl)xrLabel26).Font = new Font("Arial", 5f);
		((XRControl)xrLabel26).LocationFloat = new PointFloat(2.999939f, 61f);
		((XRControl)xrLabel26).Name = "xrLabel26";
		((XRControl)xrLabel26).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel26).SizeF = new SizeF(164.8052f, 11f);
		((XRControl)xrLabel26).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel26).StylePriority.UseFont = false;
		((XRControl)xrLabel26).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel26).Text = "HORA DE SAÍDA";
		((XRControl)xrLabel26).TextAlignment = (TextAlignment)1;
		((XRControl)xrHrSaida).BorderWidth = 0f;
		((XRControl)xrHrSaida).CanGrow = false;
		((XRControl)xrHrSaida).Font = new Font("Arial", 8f);
		((XRControl)xrHrSaida).LocationFloat = new PointFloat(7.999954f, 72.00001f);
		((XRControl)xrHrSaida).Name = "xrHrSaida";
		((XRControl)xrHrSaida).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrHrSaida).SizeF = new SizeF(155.8055f, 13.00002f);
		((XRControl)xrHrSaida).StylePriority.UseBorderWidth = false;
		((XRControl)xrHrSaida).StylePriority.UseFont = false;
		((XRControl)xrHrSaida).StylePriority.UseTextAlignment = false;
		((XRControl)xrHrSaida).Text = "29/09/2000";
		((XRControl)xrHrSaida).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel24).BorderWidth = 0f;
		((XRControl)xrLabel24).CanGrow = false;
		((XRControl)xrLabel24).Font = new Font("Arial", 5f);
		((XRControl)xrLabel24).LocationFloat = new PointFloat(2.99997f, 31.22159f);
		((XRControl)xrLabel24).Name = "xrLabel24";
		((XRControl)xrLabel24).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel24).SizeF = new SizeF(164.8052f, 11f);
		((XRControl)xrLabel24).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel24).StylePriority.UseFont = false;
		((XRControl)xrLabel24).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel24).Text = "DATA DE SAÍDA";
		((XRControl)xrLabel24).TextAlignment = (TextAlignment)1;
		((XRControl)xrDtSaida).BorderWidth = 0f;
		((XRControl)xrDtSaida).CanGrow = false;
		((XRControl)xrDtSaida).Font = new Font("Arial", 8f);
		((XRControl)xrDtSaida).LocationFloat = new PointFloat(6.999998f, 42.22157f);
		((XRControl)xrDtSaida).Name = "xrDtSaida";
		((XRControl)xrDtSaida).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDtSaida).SizeF = new SizeF(160.8051f, 13.99999f);
		((XRControl)xrDtSaida).StylePriority.UseBorderWidth = false;
		((XRControl)xrDtSaida).StylePriority.UseFont = false;
		((XRControl)xrDtSaida).StylePriority.UseTextAlignment = false;
		((XRControl)xrDtSaida).Text = "29/09/2000";
		((XRControl)xrDtSaida).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel22).BorderWidth = 0f;
		((XRControl)xrLabel22).CanGrow = false;
		((XRControl)xrLabel22).Font = new Font("Arial", 5f);
		((XRControl)xrLabel22).LocationFloat = new PointFloat(2.999951f, 2.221584f);
		((XRControl)xrLabel22).Name = "xrLabel22";
		((XRControl)xrLabel22).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel22).SizeF = new SizeF(164.8052f, 11f);
		((XRControl)xrLabel22).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel22).StylePriority.UseFont = false;
		((XRControl)xrLabel22).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel22).Text = "DATA DE EMISSÃO";
		((XRControl)xrLabel22).TextAlignment = (TextAlignment)1;
		((XRControl)xrDtEmissao).BorderWidth = 0f;
		((XRControl)xrDtEmissao).CanGrow = false;
		((XRControl)xrDtEmissao).Font = new Font("Arial", 8f);
		((XRControl)xrDtEmissao).LocationFloat = new PointFloat(6.999725f, 13.22159f);
		((XRControl)xrDtEmissao).Name = "xrDtEmissao";
		((XRControl)xrDtEmissao).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrDtEmissao).SizeF = new SizeF(160.8054f, 12.99999f);
		((XRControl)xrDtEmissao).StylePriority.UseBorderWidth = false;
		((XRControl)xrDtEmissao).StylePriority.UseFont = false;
		((XRControl)xrDtEmissao).StylePriority.UseTextAlignment = false;
		((XRControl)xrDtEmissao).Text = "29/09/2000";
		((XRControl)xrDtEmissao).TextAlignment = (TextAlignment)2;
		((XRControl)xrLine5).Borders = (BorderSide)0;
		((XRControl)xrLine5).LocationFloat = new PointFloat(0f, 56.22157f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(172.8052f, 4f);
		((XRControl)xrLine5).StylePriority.UseBorders = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).LocationFloat = new PointFloat(0f, 26.22159f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(173.8052f, 4.999994f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrPanel8).Borders = (BorderSide)12;
		((XRControl)xrPanel8).CanGrow = false;
		((XRControl)xrPanel8).Controls.AddRange((XRControl[])(object)new XRControl[42]
		{
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
		((XRControl)xrPanel8).LocationFloat = new PointFloat(27.9809f, 170.9999f);
		((XRControl)xrPanel8).Name = "xrPanel8";
		((XRControl)xrPanel8).SizeF = new SizeF(1031.977f, 98.13666f);
		((XRControl)xrPanel8).StylePriority.UseBorders = false;
		((XRControl)xrLine31).Borders = (BorderSide)0;
		((XRControl)xrLine31).LocationFloat = new PointFloat(0f, 58f);
		((XRControl)xrLine31).Name = "xrLine31";
		((XRControl)xrLine31).SizeF = new SizeF(1038.977f, 2.428242f);
		((XRControl)xrLine31).StylePriority.UseBorders = false;
		((XRControl)xrLabel68).BorderWidth = 0f;
		((XRControl)xrLabel68).Font = new Font("Arial", 5f);
		((XRControl)xrLabel68).LocationFloat = new PointFloat(8f, 0f);
		((XRControl)xrLabel68).Name = "xrLabel68";
		((XRControl)xrLabel68).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel68).SizeF = new SizeF(192f, 11f);
		((XRControl)xrLabel68).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel68).StylePriority.UseFont = false;
		((XRControl)xrLabel68).Text = "Razão Social";
		((XRControl)xrTranspRazaoSocial).BorderWidth = 0f;
		((XRControl)xrTranspRazaoSocial).CanGrow = false;
		((XRControl)xrTranspRazaoSocial).Font = new Font("Arial", 8f);
		((XRControl)xrTranspRazaoSocial).LocationFloat = new PointFloat(8f, 12f);
		((XRControl)xrTranspRazaoSocial).Name = "xrTranspRazaoSocial";
		((XRControl)xrTranspRazaoSocial).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspRazaoSocial).SizeF = new SizeF(257f, 13f);
		((XRControl)xrTranspRazaoSocial).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspRazaoSocial).StylePriority.UseFont = false;
		((XRControl)xrLine30).Borders = (BorderSide)0;
		xrLine30.LineDirection = (LineDirection)3;
		((XRControl)xrLine30).LocationFloat = new PointFloat(758.0836f, 60.42823f);
		((XRControl)xrLine30).Name = "xrLine30";
		((XRControl)xrLine30).SizeF = new SizeF(2f, 36.42827f);
		((XRControl)xrLine30).StylePriority.UseBorders = false;
		((XRControl)xrTranspCNPJ).BorderWidth = 0f;
		((XRControl)xrTranspCNPJ).CanGrow = false;
		((XRControl)xrTranspCNPJ).Font = new Font("Arial", 8f);
		((XRControl)xrTranspCNPJ).LocationFloat = new PointFloat(669.5283f, 14.00002f);
		((XRControl)xrTranspCNPJ).Name = "xrTranspCNPJ";
		((XRControl)xrTranspCNPJ).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspCNPJ).SizeF = new SizeF(198.6048f, 13f);
		((XRControl)xrTranspCNPJ).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspCNPJ).StylePriority.UseFont = false;
		((XRControl)xrTranspCNPJ).StylePriority.UseTextAlignment = false;
		((XRControl)xrTranspCNPJ).Text = "07.577.462/0001-15";
		((XRControl)xrTranspCNPJ).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel63).BorderWidth = 0f;
		((XRControl)xrLabel63).Font = new Font("Arial", 5f);
		((XRControl)xrLabel63).LocationFloat = new PointFloat(669.5283f, 3.000015f);
		((XRControl)xrLabel63).Name = "xrLabel63";
		((XRControl)xrLabel63).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel63).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel63).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel63).StylePriority.UseFont = false;
		((XRControl)xrLabel63).Text = "CNPJ";
		((XRControl)xrTranspMunicipio).BorderWidth = 0f;
		((XRControl)xrTranspMunicipio).CanGrow = false;
		((XRControl)xrTranspMunicipio).Font = new Font("Arial", 8f);
		((XRControl)xrTranspMunicipio).LocationFloat = new PointFloat(399f, 44f);
		((XRControl)xrTranspMunicipio).Name = "xrTranspMunicipio";
		((XRControl)xrTranspMunicipio).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspMunicipio).SizeF = new SizeF(155f, 13f);
		((XRControl)xrTranspMunicipio).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspMunicipio).StylePriority.UseFont = false;
		((XRControl)xrTranspMunicipio).Text = "07.577.462/0001-15";
		((XRControl)xrLabel60).BorderWidth = 0f;
		((XRControl)xrLabel60).Font = new Font("Arial", 5f);
		((XRControl)xrLabel60).LocationFloat = new PointFloat(399f, 33f);
		((XRControl)xrLabel60).Name = "xrLabel60";
		((XRControl)xrLabel60).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel60).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel60).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel60).StylePriority.UseFont = false;
		((XRControl)xrLabel60).Text = "Município";
		((XRControl)xrLine28).Borders = (BorderSide)0;
		xrLine28.LineDirection = (LineDirection)3;
		((XRControl)xrLine28).LocationFloat = new PointFloat(391f, 0f);
		((XRControl)xrLine28).Name = "xrLine28";
		((XRControl)xrLine28).SizeF = new SizeF(2.170135f, 58.00003f);
		((XRControl)xrLine28).StylePriority.UseBorders = false;
		((XRControl)xrTranspCEP).BorderWidth = 0f;
		((XRControl)xrTranspCEP).CanGrow = false;
		((XRControl)xrTranspCEP).Font = new Font("Arial", 8f);
		((XRControl)xrTranspCEP).LocationFloat = new PointFloat(669.5284f, 44f);
		((XRControl)xrTranspCEP).Name = "xrTranspCEP";
		((XRControl)xrTranspCEP).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspCEP).SizeF = new SizeF(107.9999f, 13f);
		((XRControl)xrTranspCEP).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspCEP).StylePriority.UseFont = false;
		((XRControl)xrTranspCEP).StylePriority.UseTextAlignment = false;
		((XRControl)xrTranspCEP).Text = "13.026-075";
		((XRControl)xrTranspCEP).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel58).BorderWidth = 0f;
		((XRControl)xrLabel58).Font = new Font("Arial", 5f);
		((XRControl)xrLabel58).LocationFloat = new PointFloat(669.5284f, 32.99997f);
		((XRControl)xrLabel58).Name = "xrLabel58";
		((XRControl)xrLabel58).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel58).SizeF = new SizeF(58f, 11f);
		((XRControl)xrLabel58).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel58).StylePriority.UseFont = false;
		((XRControl)xrLabel58).Text = "CEP";
		((XRControl)xrPesoLiquido).BorderWidth = 0f;
		((XRControl)xrPesoLiquido).CanGrow = false;
		((XRControl)xrPesoLiquido).Font = new Font("Arial", 8f);
		((XRControl)xrPesoLiquido).LocationFloat = new PointFloat(774.7091f, 73.42824f);
		((XRControl)xrPesoLiquido).Name = "xrPesoLiquido";
		((XRControl)xrPesoLiquido).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPesoLiquido).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrPesoLiquido).StylePriority.UseBorderWidth = false;
		((XRControl)xrPesoLiquido).StylePriority.UseFont = false;
		((XRControl)xrPesoLiquido).StylePriority.UseTextAlignment = false;
		((XRControl)xrPesoLiquido).Text = "1.000,000";
		((XRControl)xrPesoLiquido).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel56).BorderWidth = 0f;
		((XRControl)xrLabel56).Font = new Font("Arial", 5f);
		((XRControl)xrLabel56).LocationFloat = new PointFloat(774.7091f, 60.42823f);
		((XRControl)xrLabel56).Name = "xrLabel56";
		((XRControl)xrLabel56).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel56).SizeF = new SizeF(107.9999f, 10.99999f);
		((XRControl)xrLabel56).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel56).StylePriority.UseFont = false;
		((XRControl)xrLabel56).Text = "Peso Líquido";
		((XRControl)xrPesoBruto).BorderWidth = 0f;
		((XRControl)xrPesoBruto).CanGrow = false;
		((XRControl)xrPesoBruto).Font = new Font("Arial", 8f);
		((XRControl)xrPesoBruto).LocationFloat = new PointFloat(610f, 73.42824f);
		((XRControl)xrPesoBruto).Name = "xrPesoBruto";
		((XRControl)xrPesoBruto).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPesoBruto).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrPesoBruto).StylePriority.UseBorderWidth = false;
		((XRControl)xrPesoBruto).StylePriority.UseFont = false;
		((XRControl)xrPesoBruto).StylePriority.UseTextAlignment = false;
		((XRControl)xrPesoBruto).Text = "1,000,000";
		((XRControl)xrPesoBruto).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel53).BorderWidth = 0f;
		((XRControl)xrLabel53).Font = new Font("Arial", 5f);
		((XRControl)xrLabel53).LocationFloat = new PointFloat(610f, 60.42824f);
		((XRControl)xrLabel53).Name = "xrLabel53";
		((XRControl)xrLabel53).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel53).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel53).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel53).StylePriority.UseFont = false;
		((XRControl)xrLabel53).Text = "Peso B ruto";
		((XRControl)xrLine24).Borders = (BorderSide)0;
		xrLine24.LineDirection = (LineDirection)3;
		((XRControl)xrLine24).LocationFloat = new PointFloat(601.1251f, 0f);
		((XRControl)xrLine24).Name = "xrLine24";
		((XRControl)xrLine24).SizeF = new SizeF(4f, 95.42828f);
		((XRControl)xrLine24).StylePriority.UseBorders = false;
		((XRControl)xrTranspEndereco).BorderWidth = 0f;
		((XRControl)xrTranspEndereco).CanGrow = false;
		((XRControl)xrTranspEndereco).Font = new Font("Arial", 8f);
		((XRControl)xrTranspEndereco).LocationFloat = new PointFloat(8f, 44f);
		((XRControl)xrTranspEndereco).Name = "xrTranspEndereco";
		((XRControl)xrTranspEndereco).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspEndereco).SizeF = new SizeF(381f, 13f);
		((XRControl)xrTranspEndereco).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspEndereco).StylePriority.UseFont = false;
		((XRControl)xrTranspEndereco).Text = "07.577.462/0001-15";
		((XRControl)xrLabel44).BorderWidth = 0f;
		((XRControl)xrLabel44).Font = new Font("Arial", 5f);
		((XRControl)xrLabel44).LocationFloat = new PointFloat(8f, 33f);
		((XRControl)xrLabel44).Name = "xrLabel44";
		((XRControl)xrLabel44).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel44).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel44).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel44).StylePriority.UseFont = false;
		((XRControl)xrLabel44).Text = "Endereço";
		((XRControl)xrTranspQt).BorderWidth = 0f;
		((XRControl)xrTranspQt).CanGrow = false;
		((XRControl)xrTranspQt).Font = new Font("Arial", 8f);
		((XRControl)xrTranspQt).LocationFloat = new PointFloat(8.000002f, 73.42824f);
		((XRControl)xrTranspQt).Name = "xrTranspQt";
		((XRControl)xrTranspQt).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspQt).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrTranspQt).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspQt).StylePriority.UseFont = false;
		((XRControl)xrTranspQt).Text = "00000";
		((XRControl)xrLabel34).BorderWidth = 0f;
		((XRControl)xrLabel34).Font = new Font("Arial", 5f);
		((XRControl)xrLabel34).LocationFloat = new PointFloat(8f, 60.42824f);
		((XRControl)xrLabel34).Name = "xrLabel34";
		((XRControl)xrLabel34).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel34).SizeF = new SizeF(76f, 11f);
		((XRControl)xrLabel34).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel34).StylePriority.UseFont = false;
		((XRControl)xrLabel34).Text = "Quantidade";
		((XRControl)xrLabel69).BorderWidth = 0f;
		((XRControl)xrLabel69).Font = new Font("Arial", 5f);
		((XRControl)xrLabel69).LocationFloat = new PointFloat(489.8333f, 1.000007f);
		((XRControl)xrLabel69).Name = "xrLabel69";
		((XRControl)xrLabel69).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel69).SizeF = new SizeF(106.2918f, 11f);
		((XRControl)xrLabel69).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel69).StylePriority.UseFont = false;
		((XRControl)xrLabel69).Text = "Placa do Veículo";
		((XRControl)xrLine33).Borders = (BorderSide)0;
		xrLine33.LineDirection = (LineDirection)3;
		((XRControl)xrLine33).LocationFloat = new PointFloat(485.125f, 0f);
		((XRControl)xrLine33).Name = "xrLine33";
		((XRControl)xrLine33).SizeF = new SizeF(2.170166f, 28.00001f);
		((XRControl)xrLine33).StylePriority.UseBorders = false;
		((XRControl)xrTranspPlaca).BorderWidth = 0f;
		((XRControl)xrTranspPlaca).CanGrow = false;
		((XRControl)xrTranspPlaca).Font = new Font("Arial", 8f);
		((XRControl)xrTranspPlaca).LocationFloat = new PointFloat(492.8795f, 14.00002f);
		((XRControl)xrTranspPlaca).Name = "xrTranspPlaca";
		((XRControl)xrTranspPlaca).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPlaca).SizeF = new SizeF(103.2456f, 12.99998f);
		((XRControl)xrTranspPlaca).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspPlaca).StylePriority.UseFont = false;
		((XRControl)xrTranspPlacaUF).BorderWidth = 0f;
		((XRControl)xrTranspPlacaUF).CanGrow = false;
		((XRControl)xrTranspPlacaUF).Font = new Font("Arial", 8f);
		((XRControl)xrTranspPlacaUF).LocationFloat = new PointFloat(610f, 14.00002f);
		((XRControl)xrTranspPlacaUF).Name = "xrTranspPlacaUF";
		((XRControl)xrTranspPlacaUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPlacaUF).SizeF = new SizeF(45.125f, 13f);
		((XRControl)xrTranspPlacaUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspPlacaUF).StylePriority.UseFont = false;
		((XRControl)xrLine34).Borders = (BorderSide)0;
		xrLine34.LineDirection = (LineDirection)3;
		((XRControl)xrLine34).LocationFloat = new PointFloat(658.2393f, 0f);
		((XRControl)xrLine34).Name = "xrLine34";
		((XRControl)xrLine34).SizeF = new SizeF(2f, 59f);
		((XRControl)xrLine34).StylePriority.UseBorders = false;
		((XRControl)xrLabel72).BorderWidth = 0f;
		((XRControl)xrLabel72).Font = new Font("Arial", 5f);
		((XRControl)xrLabel72).LocationFloat = new PointFloat(610f, 3.000015f);
		((XRControl)xrLabel72).Name = "xrLabel72";
		((XRControl)xrLabel72).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel72).SizeF = new SizeF(25f, 11f);
		((XRControl)xrLabel72).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel72).StylePriority.UseFont = false;
		((XRControl)xrLabel72).Text = "UF";
		((XRControl)xrTranspUF).BorderWidth = 0f;
		((XRControl)xrTranspUF).CanGrow = false;
		((XRControl)xrTranspUF).Font = new Font("Arial", 8f);
		((XRControl)xrTranspUF).LocationFloat = new PointFloat(610f, 44f);
		((XRControl)xrTranspUF).Name = "xrTranspUF";
		((XRControl)xrTranspUF).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspUF).SizeF = new SizeF(43.12506f, 13f);
		((XRControl)xrTranspUF).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspUF).StylePriority.UseFont = false;
		((XRControl)xrTranspUF).Text = "SP";
		((XRControl)xrLabel74).BorderWidth = 0f;
		((XRControl)xrLabel74).Font = new Font("Arial", 5f);
		((XRControl)xrLabel74).LocationFloat = new PointFloat(610f, 32.99997f);
		((XRControl)xrLabel74).Name = "xrLabel74";
		((XRControl)xrLabel74).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel74).SizeF = new SizeF(25f, 11f);
		((XRControl)xrLabel74).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel74).StylePriority.UseFont = false;
		((XRControl)xrLabel74).Text = "UF";
		((XRControl)xrLabel75).BorderWidth = 0f;
		((XRControl)xrLabel75).Font = new Font("Arial", 5f);
		((XRControl)xrLabel75).LocationFloat = new PointFloat(399f, 1f);
		((XRControl)xrLabel75).Name = "xrLabel75";
		((XRControl)xrLabel75).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel75).SizeF = new SizeF(75f, 11f);
		((XRControl)xrLabel75).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel75).StylePriority.UseFont = false;
		((XRControl)xrLabel75).Text = "Código ANTT";
		((XRControl)xrTranspANTT).BorderWidth = 0f;
		((XRControl)xrTranspANTT).CanGrow = false;
		((XRControl)xrTranspANTT).Font = new Font("Arial", 8f);
		((XRControl)xrTranspANTT).LocationFloat = new PointFloat(399f, 12f);
		((XRControl)xrTranspANTT).Name = "xrTranspANTT";
		((XRControl)xrTranspANTT).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspANTT).SizeF = new SizeF(67f, 13f);
		((XRControl)xrTranspANTT).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspANTT).StylePriority.UseFont = false;
		((XRControl)xrLabel79).BorderWidth = 0f;
		((XRControl)xrLabel79).Font = new Font("Arial", 5f);
		((XRControl)xrLabel79).LocationFloat = new PointFloat(285f, 0.999992f);
		((XRControl)xrLabel79).Name = "xrLabel79";
		((XRControl)xrLabel79).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel79).SizeF = new SizeF(83f, 11.00001f);
		((XRControl)xrLabel79).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel79).StylePriority.UseFont = false;
		((XRControl)xrLabel79).Text = "Frete por Conta";
		((XRControl)xrTranspPagoPor).Borders = (BorderSide)0;
		((XRControl)xrTranspPagoPor).BorderWidth = 1f;
		((XRControl)xrTranspPagoPor).CanGrow = false;
		((XRControl)xrTranspPagoPor).Font = new Font("Times New Roman", 10f, FontStyle.Bold);
		((XRControl)xrTranspPagoPor).LocationFloat = new PointFloat(285f, 10f);
		((XRControl)xrTranspPagoPor).Name = "xrTranspPagoPor";
		((XRControl)xrTranspPagoPor).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspPagoPor).SizeF = new SizeF(104f, 19f);
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
		((XRControl)xrLine27).SizeF = new SizeF(2f, 31f);
		((XRControl)xrLine27).StylePriority.UseBorders = false;
		((XRControl)xrTranspNumeracao).BorderWidth = 0f;
		((XRControl)xrTranspNumeracao).CanGrow = false;
		((XRControl)xrTranspNumeracao).Font = new Font("Arial", 8f);
		((XRControl)xrTranspNumeracao).LocationFloat = new PointFloat(462.5009f, 73.42824f);
		((XRControl)xrTranspNumeracao).Name = "xrTranspNumeracao";
		((XRControl)xrTranspNumeracao).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspNumeracao).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrTranspNumeracao).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspNumeracao).StylePriority.UseFont = false;
		((XRControl)xrLabel48).BorderWidth = 0f;
		((XRControl)xrLabel48).Font = new Font("Arial", 5f);
		((XRControl)xrLabel48).LocationFloat = new PointFloat(462.5009f, 60.42824f);
		((XRControl)xrLabel48).Name = "xrLabel48";
		((XRControl)xrLabel48).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel48).SizeF = new SizeF(110f, 11f);
		((XRControl)xrLabel48).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel48).StylePriority.UseFont = false;
		((XRControl)xrLabel48).Text = "Numeração";
		((XRControl)xrLine35).Borders = (BorderSide)0;
		xrLine35.LineDirection = (LineDirection)3;
		((XRControl)xrLine35).LocationFloat = new PointFloat(451.5009f, 60.00003f);
		((XRControl)xrLine35).Name = "xrLine35";
		((XRControl)xrLine35).SizeF = new SizeF(2f, 36.42822f);
		((XRControl)xrLine35).StylePriority.UseBorders = false;
		((XRControl)xrLabel50).BorderWidth = 0f;
		((XRControl)xrLabel50).Font = new Font("Arial", 5f);
		((XRControl)xrLabel50).LocationFloat = new PointFloat(160.4788f, 60.42825f);
		((XRControl)xrLabel50).Name = "xrLabel50";
		((XRControl)xrLabel50).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel50).SizeF = new SizeF(104.5212f, 11f);
		((XRControl)xrLabel50).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel50).StylePriority.UseFont = false;
		((XRControl)xrLabel50).Text = "Espécie";
		((XRControl)xrTranspEspecie).BorderWidth = 0f;
		((XRControl)xrTranspEspecie).CanGrow = false;
		((XRControl)xrTranspEspecie).Font = new Font("Arial", 8f);
		((XRControl)xrTranspEspecie).LocationFloat = new PointFloat(161.5009f, 73.42824f);
		((XRControl)xrTranspEspecie).Name = "xrTranspEspecie";
		((XRControl)xrTranspEspecie).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspEspecie).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrTranspEspecie).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspEspecie).StylePriority.UseFont = false;
		((XRControl)xrTranspEspecie).Text = "VOLUMES";
		((XRControl)xrLine36).Borders = (BorderSide)0;
		xrLine36.LineDirection = (LineDirection)3;
		((XRControl)xrLine36).LocationFloat = new PointFloat(151.125f, 58f);
		((XRControl)xrLine36).Name = "xrLine36";
		((XRControl)xrLine36).SizeF = new SizeF(2f, 38.42823f);
		((XRControl)xrLine36).StylePriority.UseBorders = false;
		((XRControl)xrLabel62).BorderWidth = 0f;
		((XRControl)xrLabel62).Font = new Font("Arial", 5f);
		((XRControl)xrLabel62).LocationFloat = new PointFloat(312.125f, 60.00001f);
		((XRControl)xrLabel62).Name = "xrLabel62";
		((XRControl)xrLabel62).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel62).SizeF = new SizeF(50f, 11f);
		((XRControl)xrLabel62).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel62).StylePriority.UseFont = false;
		((XRControl)xrLabel62).Text = "Marca";
		((XRControl)xrTranspMarca).BorderWidth = 0f;
		((XRControl)xrTranspMarca).CanGrow = false;
		((XRControl)xrTranspMarca).Font = new Font("Arial", 8f);
		((XRControl)xrTranspMarca).LocationFloat = new PointFloat(312.125f, 73.42824f);
		((XRControl)xrTranspMarca).Name = "xrTranspMarca";
		((XRControl)xrTranspMarca).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrTranspMarca).SizeF = new SizeF(133.6242f, 15.00001f);
		((XRControl)xrTranspMarca).StylePriority.UseBorderWidth = false;
		((XRControl)xrTranspMarca).StylePriority.UseFont = false;
		((XRControl)xrLine37).Borders = (BorderSide)0;
		xrLine37.LineDirection = (LineDirection)3;
		((XRControl)xrLine37).LocationFloat = new PointFloat(302.1251f, 59.00002f);
		((XRControl)xrLine37).Name = "xrLine37";
		((XRControl)xrLine37).SizeF = new SizeF(2f, 37.42821f);
		((XRControl)xrLine37).StylePriority.UseBorders = false;
		((XRControl)xrPanel15).BorderWidth = 1f;
		((XRControl)xrPanel15).CanGrow = false;
		((XRControl)xrPanel15).Controls.AddRange((XRControl[])(object)new XRControl[11]
		{
			(XRControl)xrLabel128,
			(XRControl)xrEmitenteIE2,
			(XRControl)xrLine40,
			(XRControl)xrLine41,
			(XRControl)xrLabel117,
			(XRControl)xrEmitenteCNPJ2,
			(XRControl)xrLabel119,
			(XRControl)xrEmitenteInscST2,
			(XRControl)xrLine42,
			(XRControl)xrNatOp2,
			(XRControl)xrLabel126
		});
		((XRControl)xrPanel15).LocationFloat = new PointFloat(0f, 193.9999f);
		((XRControl)xrPanel15).Name = "xrPanel15";
		((XRControl)xrPanel15).SizeF = new SizeF(1059.958f, 29.77843f);
		((XRControl)xrPanel15).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel128).BorderWidth = 0f;
		((XRControl)xrLabel128).Font = new Font("Arial", 5f);
		((XRControl)xrLabel128).LocationFloat = new PointFloat(446f, 2.000007f);
		((XRControl)xrLabel128).Name = "xrLabel128";
		((XRControl)xrLabel128).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel128).SizeF = new SizeF(112f, 11f);
		((XRControl)xrLabel128).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel128).StylePriority.UseFont = false;
		((XRControl)xrLabel128).Text = "INSCRIÇÃO ESTADUAL";
		((XRControl)xrEmitenteIE2).BorderWidth = 0f;
		((XRControl)xrEmitenteIE2).CanGrow = false;
		((XRControl)xrEmitenteIE2).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteIE2).LocationFloat = new PointFloat(447f, 13.00001f);
		((XRControl)xrEmitenteIE2).Name = "xrEmitenteIE2";
		((XRControl)xrEmitenteIE2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteIE2).SizeF = new SizeF(108f, 14f);
		((XRControl)xrEmitenteIE2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteIE2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteIE2).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteIE2).Text = "244.669.501.115";
		((XRControl)xrEmitenteIE2).TextAlignment = (TextAlignment)256;
		((XRControl)xrLine40).Borders = (BorderSide)0;
		xrLine40.LineDirection = (LineDirection)3;
		((XRControl)xrLine40).LocationFloat = new PointFloat(435f, 0f);
		((XRControl)xrLine40).Name = "xrLine40";
		((XRControl)xrLine40).SizeF = new SizeF(2.155182f, 29.77843f);
		((XRControl)xrLine40).StylePriority.UseBorders = false;
		((XRControl)xrLine41).Borders = (BorderSide)0;
		xrLine41.LineDirection = (LineDirection)3;
		((XRControl)xrLine41).LocationFloat = new PointFloat(713f, 1.644266E-05f);
		((XRControl)xrLine41).Name = "xrLine41";
		((XRControl)xrLine41).SizeF = new SizeF(2.999939f, 29.77842f);
		((XRControl)xrLine41).StylePriority.UseBorders = false;
		((XRControl)xrLabel117).BorderWidth = 0f;
		((XRControl)xrLabel117).Font = new Font("Arial", 5f);
		((XRControl)xrLabel117).LocationFloat = new PointFloat(724.9584f, 2.000008f);
		((XRControl)xrLabel117).Name = "xrLabel117";
		((XRControl)xrLabel117).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel117).SizeF = new SizeF(51f, 11f);
		((XRControl)xrLabel117).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel117).StylePriority.UseFont = false;
		((XRControl)xrLabel117).Text = "CNPJ";
		((XRControl)xrEmitenteCNPJ2).BorderWidth = 0f;
		((XRControl)xrEmitenteCNPJ2).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteCNPJ2).LocationFloat = new PointFloat(724.9585f, 13.00001f);
		((XRControl)xrEmitenteCNPJ2).Name = "xrEmitenteCNPJ2";
		((XRControl)xrEmitenteCNPJ2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteCNPJ2).SizeF = new SizeF(115f, 14f);
		((XRControl)xrEmitenteCNPJ2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteCNPJ2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteCNPJ2).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteCNPJ2).Text = "07.577.462/0001-15";
		((XRControl)xrEmitenteCNPJ2).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel119).BorderWidth = 0f;
		((XRControl)xrLabel119).Font = new Font("Arial", 5f);
		((XRControl)xrLabel119).LocationFloat = new PointFloat(592f, 2.000007f);
		((XRControl)xrLabel119).Name = "xrLabel119";
		((XRControl)xrLabel119).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel119).SizeF = new SizeF(91f, 11f);
		((XRControl)xrLabel119).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel119).StylePriority.UseFont = false;
		((XRControl)xrLabel119).Text = "INSC. SUBST. TRIB.";
		((XRControl)xrEmitenteInscST2).BorderWidth = 0f;
		((XRControl)xrEmitenteInscST2).Font = new Font("Arial", 8f);
		((XRControl)xrEmitenteInscST2).LocationFloat = new PointFloat(592f, 13.00001f);
		((XRControl)xrEmitenteInscST2).Name = "xrEmitenteInscST2";
		((XRControl)xrEmitenteInscST2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteInscST2).SizeF = new SizeF(95f, 14f);
		((XRControl)xrEmitenteInscST2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteInscST2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteInscST2).StylePriority.UseTextAlignment = false;
		((XRControl)xrEmitenteInscST2).Text = "244.669.501.115";
		((XRControl)xrEmitenteInscST2).TextAlignment = (TextAlignment)256;
		((XRControl)xrLine42).Borders = (BorderSide)0;
		xrLine42.LineDirection = (LineDirection)3;
		((XRControl)xrLine42).LocationFloat = new PointFloat(575f, 0f);
		((XRControl)xrLine42).Name = "xrLine42";
		((XRControl)xrLine42).SizeF = new SizeF(9f, 29.77843f);
		((XRControl)xrLine42).StylePriority.UseBorders = false;
		((XRControl)xrNatOp2).BorderWidth = 0f;
		((XRControl)xrNatOp2).CanGrow = false;
		((XRControl)xrNatOp2).Font = new Font("Arial", 8f, FontStyle.Bold);
		((XRControl)xrNatOp2).LocationFloat = new PointFloat(7.999994f, 13.00002f);
		((XRControl)xrNatOp2).Name = "xrNatOp2";
		((XRControl)xrNatOp2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNatOp2).SizeF = new SizeF(417f, 13.99999f);
		((XRControl)xrNatOp2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNatOp2).StylePriority.UseFont = false;
		((XRControl)xrNatOp2).StylePriority.UseTextAlignment = false;
		((XRControl)xrNatOp2).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel126).BorderWidth = 0f;
		((XRControl)xrLabel126).CanGrow = false;
		((XRControl)xrLabel126).Font = new Font("Arial", 5f);
		((XRControl)xrLabel126).LocationFloat = new PointFloat(8f, 2f);
		((XRControl)xrLabel126).Name = "xrLabel126";
		((XRControl)xrLabel126).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel126).SizeF = new SizeF(192f, 11f);
		((XRControl)xrLabel126).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel126).StylePriority.UseFont = false;
		((XRControl)xrLabel126).Text = "NATUREZA DA OPERAÇÃO";
		((XRControl)xrLabel116).BorderWidth = 0f;
		((XRControl)xrLabel116).Font = new Font("Arial", 7f);
		((XRControl)xrLabel116).LocationFloat = new PointFloat(539.6249f, 173.9999f);
		((XRControl)xrLabel116).Name = "xrLabel116";
		((XRControl)xrLabel116).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel116).SizeF = new SizeF(33f, 14f);
		((XRControl)xrLabel116).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel116).StylePriority.UseFont = false;
		((XRControl)xrLabel116).Text = "FLS:";
		((XRControl)xrPageInfo2).AnchorHorizontal = (HorizontalAnchorStyles)2;
		((XRControl)xrPageInfo2).BorderWidth = 0f;
		((XRControl)xrPageInfo2).Font = new Font("Arial", 7f);
		((XRControl)xrPageInfo2).LocationFloat = new PointFloat(563.6249f, 173.9999f);
		((XRControl)xrPageInfo2).Name = "xrPageInfo2";
		((XRControl)xrPageInfo2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrPageInfo2).SizeF = new SizeF(42f, 14f);
		((XRControl)xrPageInfo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrPageInfo2).StylePriority.UseFont = false;
		((XRControl)xrPageInfo2).StylePriority.UseTextAlignment = false;
		((XRControl)xrPageInfo2).TextAlignment = (TextAlignment)4;
		((XRControl)xrSerieNFe2).BorderWidth = 0f;
		((XRControl)xrSerieNFe2).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrSerieNFe2).LocationFloat = new PointFloat(524.6249f, 159.9999f);
		((XRControl)xrSerieNFe2).Name = "xrSerieNFe2";
		((XRControl)xrSerieNFe2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNFe2).SizeF = new SizeF(100f, 14f);
		((XRControl)xrSerieNFe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNFe2).StylePriority.UseFont = false;
		((XRControl)xrSerieNFe2).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNFe2).Text = "SÉRIE 1";
		((XRControl)xrSerieNFe2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel114).BorderWidth = 0f;
		((XRControl)xrLabel114).Font = new Font("Arial", 9f);
		((XRControl)xrLabel114).LocationFloat = new PointFloat(524.6249f, 142.9999f);
		((XRControl)xrLabel114).Name = "xrLabel114";
		((XRControl)xrLabel114).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel114).SizeF = new SizeF(21.99997f, 17f);
		((XRControl)xrLabel114).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel114).StylePriority.UseFont = false;
		((XRControl)xrLabel114).Text = "Nº";
		((XRControl)xrNroNF2).BorderWidth = 0f;
		((XRControl)xrNroNF2).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrNroNF2).LocationFloat = new PointFloat(546.6249f, 142.9999f);
		((XRControl)xrNroNF2).Name = "xrNroNF2";
		((XRControl)xrNroNF2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNF2).SizeF = new SizeF(77f, 17f);
		((XRControl)xrNroNF2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNF2).StylePriority.UseFont = false;
		((XRControl)xrNroNF2).Text = "000.000.000";
		((XRControl)xrPanel14).BorderWidth = 1f;
		((XRControl)xrPanel14).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrES2 });
		((XRControl)xrPanel14).LocationFloat = new PointFloat(598.6249f, 120.9999f);
		((XRControl)xrPanel14).Name = "xrPanel14";
		((XRControl)xrPanel14).SizeF = new SizeF(25f, 21f);
		((XRControl)xrPanel14).StylePriority.UseBorderWidth = false;
		((XRControl)xrES2).BorderWidth = 0f;
		((XRControl)xrES2).Font = new Font("Times New Roman", 12f, FontStyle.Bold);
		((XRControl)xrES2).LocationFloat = new PointFloat(0f, 2f);
		((XRControl)xrES2).Name = "xrES2";
		((XRControl)xrES2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrES2).SizeF = new SizeF(25f, 18f);
		((XRControl)xrES2).StylePriority.UseBorderWidth = false;
		((XRControl)xrES2).StylePriority.UseFont = false;
		((XRControl)xrES2).StylePriority.UseTextAlignment = false;
		((XRControl)xrES2).Text = "1";
		((XRControl)xrES2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel111).BorderWidth = 0f;
		((XRControl)xrLabel111).Font = new Font("Arial", 6f);
		((XRControl)xrLabel111).LocationFloat = new PointFloat(523.6249f, 129.9999f);
		((XRControl)xrLabel111).Name = "xrLabel111";
		((XRControl)xrLabel111).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel111).SizeF = new SizeF(65f, 14f);
		((XRControl)xrLabel111).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel111).StylePriority.UseFont = false;
		((XRControl)xrLabel111).Text = "1 - SAÍDA";
		((XRControl)xrLabel110).BorderWidth = 0f;
		((XRControl)xrLabel110).Font = new Font("Arial", 6f);
		((XRControl)xrLabel110).LocationFloat = new PointFloat(523.6249f, 117.9999f);
		((XRControl)xrLabel110).Name = "xrLabel110";
		((XRControl)xrLabel110).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel110).SizeF = new SizeF(65f, 13f);
		((XRControl)xrLabel110).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel110).StylePriority.UseFont = false;
		((XRControl)xrLabel110).Text = "0 - ENTRADA";
		((XRControl)xrLabel109).BorderWidth = 0f;
		((XRControl)xrLabel109).Font = new Font("Arial", 6f);
		((XRControl)xrLabel109).LocationFloat = new PointFloat(523.6249f, 93.99992f);
		((XRControl)xrLabel109).Name = "xrLabel109";
		((XRControl)xrLabel109).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel109).SizeF = new SizeF(101f, 22.00001f);
		((XRControl)xrLabel109).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel109).StylePriority.UseFont = false;
		((XRControl)xrLabel109).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel109).Text = "Documento Auxiliar de Nota Fiscal Eletrônica";
		((XRControl)xrLabel109).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel108).BorderWidth = 0f;
		((XRControl)xrLabel108).Font = new Font("Arial", 11f, FontStyle.Bold);
		((XRControl)xrLabel108).LocationFloat = new PointFloat(524.6249f, 77.99992f);
		((XRControl)xrLabel108).Name = "xrLabel108";
		((XRControl)xrLabel108).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel108).SizeF = new SizeF(100f, 16f);
		((XRControl)xrLabel108).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel108).StylePriority.UseFont = false;
		((XRControl)xrLabel108).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel108).Text = "DANFE";
		((XRControl)xrLabel108).TextAlignment = (TextAlignment)2;
		((XRControl)xrPanel13).BorderWidth = 1f;
		((XRControl)xrPanel13).CanGrow = false;
		((XRControl)xrPanel13).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrChaveAcesso2 });
		((XRControl)xrPanel13).LocationFloat = new PointFloat(638.981f, 74.99996f);
		((XRControl)xrPanel13).Name = "xrPanel13";
		((XRControl)xrPanel13).SizeF = new SizeF(420.9771f, 40.99997f);
		((XRControl)xrPanel13).StylePriority.UseBorderWidth = false;
		xrChaveAcesso2.AutoModule = true;
		((XRControl)xrChaveAcesso2).BorderWidth = 0f;
		((XRControl)xrChaveAcesso2).LocationFloat = new PointFloat(74.01898f, 2.999962f);
		((XRControl)xrChaveAcesso2).Name = "xrChaveAcesso2";
		((XRControl)xrChaveAcesso2).Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrChaveAcesso2.ShowText = false;
		((XRControl)xrChaveAcesso2).SizeF = new SizeF(316.8259f, 35.00003f);
		((XRControl)xrChaveAcesso2).StylePriority.UseBorderWidth = false;
		((XRControl)xrChaveAcesso2).StylePriority.UseTextAlignment = false;
		val2.CharacterSet = (Code128Charset)105;
		xrChaveAcesso2.Symbology = (BarCodeGeneratorBase)(object)val2;
		((XRControl)xrChaveAcesso2).Text = "0115550010000000180405822968";
		((XRControl)xrChaveAcesso2).TextAlignment = (TextAlignment)16;
		((XRControl)xrPanel12).BorderWidth = 1f;
		((XRControl)xrPanel12).CanGrow = false;
		((XRControl)xrPanel12).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrRazaoSocialEmitente2,
			(XRControl)xrEnderecoEmitente2,
			(XRControl)xrEnderecoEmitenteBairro2,
			(XRControl)xrEmitenteEnderecoCidade2,
			(XRControl)xrEmitenteTelefone2,
			(XRControl)xrLogo2
		});
		((XRControl)xrPanel12).LocationFloat = new PointFloat(0f, 74.99994f);
		((XRControl)xrPanel12).Name = "xrPanel12";
		((XRControl)xrPanel12).SizeF = new SizeF(513.1058f, 116f);
		((XRControl)xrPanel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).BorderWidth = 0f;
		((XRControl)xrRazaoSocialEmitente2).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)xrRazaoSocialEmitente2).LocationFloat = new PointFloat(275.7301f, 9.999992f);
		xrRazaoSocialEmitente2.Multiline = true;
		((XRControl)xrRazaoSocialEmitente2).Name = "xrRazaoSocialEmitente2";
		((XRControl)xrRazaoSocialEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrRazaoSocialEmitente2).SizeF = new SizeF(227.3757f, 14.99999f);
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseFont = false;
		((XRControl)xrRazaoSocialEmitente2).Text = "R.Castro Cia Ltda.";
		((XRControl)xrEnderecoEmitente2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitente2).Font = new Font("Arial", 7f);
		((XRControl)xrEnderecoEmitente2).LocationFloat = new PointFloat(275.7301f, 26.00002f);
		((XRControl)xrEnderecoEmitente2).Name = "xrEnderecoEmitente2";
		((XRControl)xrEnderecoEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitente2).SizeF = new SizeF(227.3757f, 11.99999f);
		((XRControl)xrEnderecoEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitente2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitente2).Text = "Avenida Ferraz Alvim, 622";
		((XRControl)xrEnderecoEmitenteBairro2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitenteBairro2).Font = new Font("Arial", 7f);
		((XRControl)xrEnderecoEmitenteBairro2).LocationFloat = new PointFloat(275.7301f, 37.99998f);
		((XRControl)xrEnderecoEmitenteBairro2).Name = "xrEnderecoEmitenteBairro2";
		((XRControl)xrEnderecoEmitenteBairro2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitenteBairro2).SizeF = new SizeF(227.3757f, 12.00001f);
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitenteBairro2).Text = "Jardim Ruyce - CEP 09961-550";
		((XRControl)xrEmitenteEnderecoCidade2).BorderWidth = 0f;
		((XRControl)xrEmitenteEnderecoCidade2).Font = new Font("Arial", 7f);
		((XRControl)xrEmitenteEnderecoCidade2).LocationFloat = new PointFloat(275.7301f, 48.99998f);
		((XRControl)xrEmitenteEnderecoCidade2).Name = "xrEmitenteEnderecoCidade2";
		((XRControl)xrEmitenteEnderecoCidade2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteEnderecoCidade2).SizeF = new SizeF(227.3757f, 11.99999f);
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteEnderecoCidade2).Text = "Diadema - SP";
		((XRControl)xrEmitenteTelefone2).BorderWidth = 0f;
		((XRControl)xrEmitenteTelefone2).Font = new Font("Arial", 7f);
		((XRControl)xrEmitenteTelefone2).LocationFloat = new PointFloat(275.7301f, 60.99995f);
		((XRControl)xrEmitenteTelefone2).Name = "xrEmitenteTelefone2";
		((XRControl)xrEmitenteTelefone2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteTelefone2).SizeF = new SizeF(129.3757f, 12.00002f);
		((XRControl)xrEmitenteTelefone2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteTelefone2).Text = "(11) 4067-1130";
		((XRControl)xrLogo2).BorderWidth = 0f;
		xrLogo2.ImageAlignment = (ImageAlignment)5;
		xrLogo2.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrLogo2.ImageSource"));
		((XRControl)xrLogo2).LocationFloat = new PointFloat(7.000097f, 2.999985f);
		((XRControl)xrLogo2).Name = "xrLogo2";
		((XRControl)xrLogo2).SizeF = new SizeF(257.4457f, 109.9999f);
		xrLogo2.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel28).Borders = (BorderSide)7;
		((XRControl)xrLabel28).BorderWidth = 1f;
		((XRControl)xrLabel28).CanGrow = false;
		((XRControl)xrLabel28).Font = new Font("Arial", 5f);
		((XRControl)xrLabel28).LocationFloat = new PointFloat(638.981f, 145.9999f);
		xrLabel28.Multiline = true;
		((XRControl)xrLabel28).Name = "xrLabel28";
		((XRControl)xrLabel28).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel28).SizeF = new SizeF(421.0194f, 10.99998f);
		((XRControl)xrLabel28).StylePriority.UseBorders = false;
		((XRControl)xrLabel28).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel28).StylePriority.UseFont = false;
		((XRControl)xrLabel28).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel28).Text = "CONSULTA DE AUTENTICIDADE NO PORTAL NACIONAL DA NF-e ";
		((XRControl)xrLabel28).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel77).Borders = (BorderSide)13;
		((XRControl)xrLabel77).BorderWidth = 1f;
		((XRControl)xrLabel77).CanGrow = false;
		((XRControl)xrLabel77).Font = new Font("Arial", 5f);
		((XRControl)xrLabel77).LocationFloat = new PointFloat(638.981f, 156.9999f);
		xrLabel77.Multiline = true;
		((XRControl)xrLabel77).Name = "xrLabel77";
		((XRControl)xrLabel77).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel77).SizeF = new SizeF(421.0194f, 14f);
		((XRControl)xrLabel77).StylePriority.UseBorders = false;
		((XRControl)xrLabel77).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel77).StylePriority.UseFont = false;
		((XRControl)xrLabel77).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel77).Text = "www.fazenda.gov.br/portal ou no site da SEFAZ AUTORIZADORA";
		((XRControl)xrLabel77).TextAlignment = (TextAlignment)32;
		((XRControl)xrCrossBandBox1).AnchorVertical = (VerticalAnchorStyles)3;
		((XRControl)xrCrossBandBox1).Borders = (BorderSide)7;
		((XRControl)xrCrossBandBox1).BorderWidth = 1f;
		((XRCrossBandControl)xrCrossBandBox1).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandBox1).EndPointFloat = new PointFloat(0f, 2f);
		((XRControl)xrCrossBandBox1).Name = "xrCrossBandBox1";
		((XRCrossBandControl)xrCrossBandBox1).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandBox1).StartPointFloat = new PointFloat(0f, 0f);
		((XRControl)xrCrossBandBox1).WidthF = 1062f;
		((Band)GroupFooter1).Expanded = false;
		((XRControl)GroupFooter1).HeightF = 2f;
		((XRControl)GroupFooter1).Name = "GroupFooter1";
		GroupFooter1.PrintAtBottom = true;
		((XRControl)GroupHeader1).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrPanel16 });
		((Band)GroupHeader1).Expanded = false;
		((XRControl)GroupHeader1).HeightF = 16f;
		((XRControl)GroupHeader1).Name = "GroupHeader1";
		((GroupBand)GroupHeader1).RepeatEveryPage = true;
		((XRControl)xrPanel16).BackColor = Color.LightGray;
		((XRControl)xrPanel16).Borders = (BorderSide)8;
		((XRControl)xrPanel16).BorderWidth = 1f;
		((XRControl)xrPanel16).CanGrow = false;
		((XRControl)xrPanel16).Controls.AddRange((XRControl[])(object)new XRControl[14]
		{
			(XRControl)xrLabel10,
			(XRControl)xrLabel71,
			(XRControl)xrLabel73,
			(XRControl)xrLabel76,
			(XRControl)xrLabel80,
			(XRControl)xrLabel81,
			(XRControl)xrLabel82,
			(XRControl)xrLabel96,
			(XRControl)xrLabel100,
			(XRControl)xrLabel101,
			(XRControl)xrLabel102,
			(XRControl)xrLabel103,
			(XRControl)xrLabel104,
			(XRControl)xrLabel16
		});
		((XRControl)xrPanel16).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrPanel16).Name = "xrPanel16";
		((XRControl)xrPanel16).SizeF = new SizeF(1062f, 16f);
		((XRControl)xrPanel16).StylePriority.UseBackColor = false;
		((XRControl)xrPanel16).StylePriority.UseBorders = false;
		((XRControl)xrPanel16).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel10).Borders = (BorderSide)1;
		((XRControl)xrLabel10).BorderWidth = 0f;
		((XRControl)xrLabel10).Font = new Font("Arial", 6f);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(956.1671f, 2.000028f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel10).SizeF = new SizeF(55.25568f, 12f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "BC ICMS ST";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel71).Borders = (BorderSide)1;
		((XRControl)xrLabel71).BorderWidth = 0f;
		((XRControl)xrLabel71).Font = new Font("Arial", 6f);
		((XRControl)xrLabel71).LocationFloat = new PointFloat(112f, 2.000023f);
		((XRControl)xrLabel71).Name = "xrLabel71";
		((XRControl)xrLabel71).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel71).SizeF = new SizeF(71.57838f, 12f);
		((XRControl)xrLabel71).StylePriority.UseBorders = false;
		((XRControl)xrLabel71).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel71).StylePriority.UseFont = false;
		((XRControl)xrLabel71).Text = "Produto";
		((XRControl)xrLabel73).Borders = (BorderSide)1;
		((XRControl)xrLabel73).BorderWidth = 0f;
		((XRControl)xrLabel73).Font = new Font("Arial", 6f);
		((XRControl)xrLabel73).LocationFloat = new PointFloat(899.1942f, 2.000023f);
		((XRControl)xrLabel73).Name = "xrLabel73";
		((XRControl)xrLabel73).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel73).SizeF = new SizeF(55.99994f, 12f);
		((XRControl)xrLabel73).StylePriority.UseBorders = false;
		((XRControl)xrLabel73).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel73).StylePriority.UseFont = false;
		((XRControl)xrLabel73).Text = "IPI           %";
		((XRControl)xrLabel76).Borders = (BorderSide)1;
		((XRControl)xrLabel76).BorderWidth = 0f;
		((XRControl)xrLabel76).Font = new Font("Arial", 6f);
		((XRControl)xrLabel76).LocationFloat = new PointFloat(832.3499f, 2.000023f);
		((XRControl)xrLabel76).Name = "xrLabel76";
		((XRControl)xrLabel76).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel76).SizeF = new SizeF(60.84467f, 12f);
		((XRControl)xrLabel76).StylePriority.UseBorders = false;
		((XRControl)xrLabel76).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel76).StylePriority.UseFont = false;
		((XRControl)xrLabel76).Text = "ICMS          %";
		((XRControl)xrLabel80).Borders = (BorderSide)1;
		((XRControl)xrLabel80).BorderWidth = 0f;
		((XRControl)xrLabel80).Font = new Font("Arial", 6f);
		((XRControl)xrLabel80).LocationFloat = new PointFloat(777.9446f, 2.000023f);
		((XRControl)xrLabel80).Name = "xrLabel80";
		((XRControl)xrLabel80).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel80).SizeF = new SizeF(53.00012f, 12f);
		((XRControl)xrLabel80).StylePriority.UseBorders = false;
		((XRControl)xrLabel80).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel80).StylePriority.UseFont = false;
		((XRControl)xrLabel80).Text = "BC ICMS";
		((XRControl)xrLabel81).Borders = (BorderSide)1;
		((XRControl)xrLabel81).BorderWidth = 0f;
		((XRControl)xrLabel81).Font = new Font("Arial", 6f);
		((XRControl)xrLabel81).LocationFloat = new PointFloat(717.0506f, 2.000023f);
		((XRControl)xrLabel81).Name = "xrLabel81";
		((XRControl)xrLabel81).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel81).SizeF = new SizeF(59.89404f, 12f);
		((XRControl)xrLabel81).StylePriority.UseBorders = false;
		((XRControl)xrLabel81).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel81).StylePriority.UseFont = false;
		((XRControl)xrLabel81).Text = "VL. TOTAL";
		((XRControl)xrLabel82).Borders = (BorderSide)1;
		((XRControl)xrLabel82).BorderWidth = 0f;
		((XRControl)xrLabel82).Font = new Font("Arial", 6f);
		((XRControl)xrLabel82).LocationFloat = new PointFloat(662.8812f, 2.000023f);
		((XRControl)xrLabel82).Name = "xrLabel82";
		((XRControl)xrLabel82).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel82).SizeF = new SizeF(50.11884f, 12f);
		((XRControl)xrLabel82).StylePriority.UseBorders = false;
		((XRControl)xrLabel82).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel82).StylePriority.UseFont = false;
		((XRControl)xrLabel82).Text = "VL. UNIT.";
		((XRControl)xrLabel96).Borders = (BorderSide)1;
		((XRControl)xrLabel96).BorderWidth = 0f;
		((XRControl)xrLabel96).Font = new Font("Arial", 6f);
		((XRControl)xrLabel96).LocationFloat = new PointFloat(592.0224f, 2.000023f);
		((XRControl)xrLabel96).Name = "xrLabel96";
		((XRControl)xrLabel96).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel96).SizeF = new SizeF(45.9585f, 12f);
		((XRControl)xrLabel96).StylePriority.UseBorders = false;
		((XRControl)xrLabel96).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel96).StylePriority.UseFont = false;
		((XRControl)xrLabel96).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel96).Text = "QUANT.";
		((XRControl)xrLabel96).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel100).Borders = (BorderSide)1;
		((XRControl)xrLabel100).BorderWidth = 0f;
		((XRControl)xrLabel100).Font = new Font("Arial", 6f);
		((XRControl)xrLabel100).LocationFloat = new PointFloat(638.9809f, 2.000023f);
		((XRControl)xrLabel100).Name = "xrLabel100";
		((XRControl)xrLabel100).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel100).SizeF = new SizeF(22f, 12f);
		((XRControl)xrLabel100).StylePriority.UseBorders = false;
		((XRControl)xrLabel100).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel100).StylePriority.UseFont = false;
		((XRControl)xrLabel100).Text = "UN";
		((XRControl)xrLabel101).Borders = (BorderSide)1;
		((XRControl)xrLabel101).BorderWidth = 0f;
		((XRControl)xrLabel101).Font = new Font("Arial", 6f);
		((XRControl)xrLabel101).LocationFloat = new PointFloat(550.4807f, 2.000023f);
		((XRControl)xrLabel101).Name = "xrLabel101";
		((XRControl)xrLabel101).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel101).SizeF = new SizeF(39.66672f, 12f);
		((XRControl)xrLabel101).StylePriority.UseBorders = false;
		((XRControl)xrLabel101).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel101).StylePriority.UseFont = false;
		((XRControl)xrLabel101).Text = "CFOP";
		((XRControl)xrLabel102).Borders = (BorderSide)1;
		((XRControl)xrLabel102).BorderWidth = 0f;
		((XRControl)xrLabel102).Font = new Font("Arial", 6f);
		((XRControl)xrLabel102).LocationFloat = new PointFloat(515.6057f, 2.000023f);
		((XRControl)xrLabel102).Name = "xrLabel102";
		((XRControl)xrLabel102).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel102).SizeF = new SizeF(33.875f, 12f);
		((XRControl)xrLabel102).StylePriority.UseBorders = false;
		((XRControl)xrLabel102).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel102).StylePriority.UseFont = false;
		((XRControl)xrLabel102).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel102).Text = "CST";
		((XRControl)xrLabel102).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel103).Borders = (BorderSide)1;
		((XRControl)xrLabel103).BorderWidth = 0f;
		((XRControl)xrLabel103).Font = new Font("Arial", 6f);
		((XRControl)xrLabel103).LocationFloat = new PointFloat(460.1058f, 2.000023f);
		((XRControl)xrLabel103).Name = "xrLabel103";
		((XRControl)xrLabel103).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel103).SizeF = new SizeF(53.00009f, 12f);
		((XRControl)xrLabel103).StylePriority.UseBorders = false;
		((XRControl)xrLabel103).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel103).StylePriority.UseFont = false;
		((XRControl)xrLabel103).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel103).Text = "NCM";
		((XRControl)xrLabel103).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel104).Borders = (BorderSide)0;
		((XRControl)xrLabel104).BorderWidth = 0f;
		((XRControl)xrLabel104).Font = new Font("Arial", 6f);
		((XRControl)xrLabel104).LocationFloat = new PointFloat(1.999995f, 2.000023f);
		((XRControl)xrLabel104).Name = "xrLabel104";
		((XRControl)xrLabel104).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel104).SizeF = new SizeF(108f, 12f);
		((XRControl)xrLabel104).StylePriority.UseBorders = false;
		((XRControl)xrLabel104).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel104).StylePriority.UseFont = false;
		((XRControl)xrLabel104).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel104).Text = "Código";
		((XRControl)xrLabel104).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel16).Borders = (BorderSide)1;
		((XRControl)xrLabel16).BorderWidth = 0f;
		((XRControl)xrLabel16).Font = new Font("Arial", 6f);
		((XRControl)xrLabel16).LocationFloat = new PointFloat(1014f, 2.000028f);
		((XRControl)xrLabel16).Name = "xrLabel16";
		((XRControl)xrLabel16).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel16).SizeF = new SizeF(46f, 12f);
		((XRControl)xrLabel16).StylePriority.UseBorders = false;
		((XRControl)xrLabel16).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel16).StylePriority.UseFont = false;
		((XRControl)xrLabel16).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel16).Text = "V ICMS ST";
		((XRControl)xrLabel16).TextAlignment = (TextAlignment)2;
		((XRControl)xrCrossBandLine1).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine1).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine1).EndPointFloat = new PointFloat(110f, 2f);
		((XRControl)xrCrossBandLine1).Name = "xrCrossBandLine1";
		((XRCrossBandControl)xrCrossBandLine1).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine1).StartPointFloat = new PointFloat(110f, 0f);
		((XRControl)xrCrossBandLine1).WidthF = 1f;
		((XRControl)xrCrossBandLine2).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine2).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine2).EndPointFloat = new PointFloat(955.1671f, 2f);
		((XRControl)xrCrossBandLine2).Name = "xrCrossBandLine2";
		((XRCrossBandControl)xrCrossBandLine2).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine2).StartPointFloat = new PointFloat(955.1671f, 0f);
		((XRControl)xrCrossBandLine2).WidthF = 1f;
		((XRControl)xrCrossBandLine3).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine3).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine3).EndPointFloat = new PointFloat(1013f, 2f);
		((XRControl)xrCrossBandLine3).Name = "xrCrossBandLine3";
		((XRCrossBandControl)xrCrossBandLine3).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine3).StartPointFloat = new PointFloat(1013f, 0f);
		((XRControl)xrCrossBandLine3).WidthF = 1f;
		((XRControl)xrCrossBandLine4).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine4).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine4).EndPointFloat = new PointFloat(893.1946f, 2f);
		((XRControl)xrCrossBandLine4).Name = "xrCrossBandLine4";
		((XRCrossBandControl)xrCrossBandLine4).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine4).StartPointFloat = new PointFloat(893.1946f, 0f);
		((XRControl)xrCrossBandLine4).WidthF = 1f;
		((XRControl)xrCrossBandLine5).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine5).EndBand = (Band)(object)ReportFooter;
		((XRCrossBandControl)xrCrossBandLine5).EndPointFloat = new PointFloat(549.4807f, 2f);
		((XRControl)xrCrossBandLine5).Name = "xrCrossBandLine5";
		((XRCrossBandControl)xrCrossBandLine5).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine5).StartPointFloat = new PointFloat(549.4807f, 1.999999f);
		((XRControl)xrCrossBandLine5).WidthF = 1f;
		((XRControl)ReportFooter).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrPanel10,
			(XRControl)xrPanel7,
			(XRControl)xrLabel14,
			(XRControl)xrLabel32
		});
		((Band)ReportFooter).Expanded = false;
		((XRControl)ReportFooter).HeightF = 116.9584f;
		((XRControl)ReportFooter).Name = "ReportFooter";
		ReportFooter.PrintAtBottom = true;
		((XRControl)xrPanel10).Borders = (BorderSide)13;
		((XRControl)xrPanel10).BorderWidth = 1f;
		((XRControl)xrPanel10).CanGrow = false;
		((XRControl)xrPanel10).Controls.AddRange((XRControl[])(object)new XRControl[4]
		{
			(XRControl)xrLine38,
			(XRControl)xrLabel55,
			(XRControl)xrLabel59,
			(XRControl)xrInfoCpl
		});
		((XRControl)xrPanel10).LocationFloat = new PointFloat(28.83324f, 34.00001f);
		((XRControl)xrPanel10).Name = "xrPanel10";
		((XRControl)xrPanel10).SizeF = new SizeF(1033.167f, 82.95835f);
		((XRControl)xrPanel10).StylePriority.UseBorders = false;
		((XRControl)xrPanel10).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine38).Borders = (BorderSide)0;
		xrLine38.LineDirection = (LineDirection)3;
		((XRControl)xrLine38).LocationFloat = new PointFloat(821.1108f, 0f);
		((XRControl)xrLine38).Name = "xrLine38";
		((XRControl)xrLine38).SizeF = new SizeF(2.130676f, 82.95835f);
		((XRControl)xrLine38).StylePriority.UseBorders = false;
		((XRControl)xrLabel55).BorderWidth = 0f;
		((XRControl)xrLabel55).Font = new Font("Arial", 6f);
		((XRControl)xrLabel55).LocationFloat = new PointFloat(7f, 2f);
		((XRControl)xrLabel55).Name = "xrLabel55";
		((XRControl)xrLabel55).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel55).SizeF = new SizeF(200f, 11f);
		((XRControl)xrLabel55).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel55).StylePriority.UseFont = false;
		((XRControl)xrLabel55).Text = "INFORMAÇÔES COMPLEMENTARES";
		((XRControl)xrLabel59).BorderWidth = 0f;
		((XRControl)xrLabel59).Font = new Font("Arial", 6f);
		((XRControl)xrLabel59).LocationFloat = new PointFloat(828.1667f, 1.999985f);
		((XRControl)xrLabel59).Name = "xrLabel59";
		((XRControl)xrLabel59).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel59).SizeF = new SizeF(200f, 11f);
		((XRControl)xrLabel59).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel59).StylePriority.UseFont = false;
		((XRControl)xrLabel59).Text = "RESERVADO AO FISCO";
		((XRControl)xrInfoCpl).BorderWidth = 0f;
		((XRControl)xrInfoCpl).CanGrow = false;
		((XRControl)xrInfoCpl).Font = new Font("Arial", 6f);
		((XRControl)xrInfoCpl).LocationFloat = new PointFloat(7.999996f, 14.00002f);
		xrInfoCpl.Multiline = true;
		((XRControl)xrInfoCpl).Name = "xrInfoCpl";
		((XRControl)xrInfoCpl).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrInfoCpl).SizeF = new SizeF(803.1252f, 58.95831f);
		((XRControl)xrInfoCpl).StylePriority.UseBorderWidth = false;
		((XRControl)xrInfoCpl).StylePriority.UseFont = false;
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
		((XRControl)xrPanel7).LocationFloat = new PointFloat(29.02274f, 5.501967E-05f);
		((XRControl)xrPanel7).Name = "xrPanel7";
		((XRControl)xrPanel7).SizeF = new SizeF(1032.977f, 33.99997f);
		((XRControl)xrPanel7).StylePriority.UseBorders = false;
		((XRControl)xrPanel7).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorServico).BorderWidth = 0f;
		((XRControl)xrValorServico).Font = new Font("Arial", 8f);
		((XRControl)xrValorServico).LocationFloat = new PointFloat(226.3103f, 14.37499f);
		((XRControl)xrValorServico).Name = "xrValorServico";
		((XRControl)xrValorServico).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorServico).SizeF = new SizeF(200.8144f, 15.625f);
		((XRControl)xrValorServico).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorServico).StylePriority.UseFont = false;
		((XRControl)xrLabel54).BorderWidth = 0f;
		((XRControl)xrLabel54).Font = new Font("Arial", 7f);
		((XRControl)xrLabel54).LocationFloat = new PointFloat(450.5006f, 3.208305f);
		((XRControl)xrLabel54).Name = "xrLabel54";
		((XRControl)xrLabel54).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel54).SizeF = new SizeF(156.25f, 10.41667f);
		((XRControl)xrLabel54).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel54).StylePriority.UseFont = false;
		((XRControl)xrLabel54).Text = "BASE DE CÁLCULO DO ISSQN";
		((XRControl)xrBaseISSQN).BorderWidth = 0f;
		((XRControl)xrBaseISSQN).Font = new Font("Arial", 8f);
		((XRControl)xrBaseISSQN).LocationFloat = new PointFloat(450.5006f, 14.37499f);
		((XRControl)xrBaseISSQN).Name = "xrBaseISSQN";
		((XRControl)xrBaseISSQN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrBaseISSQN).SizeF = new SizeF(208.9839f, 15.625f);
		((XRControl)xrBaseISSQN).StylePriority.UseBorderWidth = false;
		((XRControl)xrBaseISSQN).StylePriority.UseFont = false;
		((XRControl)xrBaseISSQN).Text = "xrNatOp";
		((XRControl)xrLine23).Borders = (BorderSide)0;
		xrLine23.LineDirection = (LineDirection)3;
		((XRControl)xrLine23).LocationFloat = new PointFloat(429.5006f, 0f);
		((XRControl)xrLine23).Name = "xrLine23";
		((XRControl)xrLine23).SizeF = new SizeF(11.49908f, 33.99996f);
		((XRControl)xrLine23).StylePriority.UseBorders = false;
		((XRControl)xrLabel61).BorderWidth = 0f;
		((XRControl)xrLabel61).Font = new Font("Arial", 7f);
		((XRControl)xrLabel61).LocationFloat = new PointFloat(226.3103f, 3.208305f);
		((XRControl)xrLabel61).Name = "xrLabel61";
		((XRControl)xrLabel61).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel61).SizeF = new SizeF(166.6667f, 10.41667f);
		((XRControl)xrLabel61).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel61).StylePriority.UseFont = false;
		((XRControl)xrLabel61).Text = "VALOR TOTAL DOS SERVIÇOS";
		((XRControl)xrLine26).Borders = (BorderSide)0;
		xrLine26.LineDirection = (LineDirection)3;
		((XRControl)xrLine26).LocationFloat = new PointFloat(212.1247f, 0f);
		((XRControl)xrLine26).Name = "xrLine26";
		((XRControl)xrLine26).SizeF = new SizeF(2.130676f, 33.99996f);
		((XRControl)xrLine26).StylePriority.UseBorders = false;
		((XRControl)xrLine29).Borders = (BorderSide)0;
		xrLine29.LineDirection = (LineDirection)3;
		((XRControl)xrLine29).LocationFloat = new PointFloat(669.9941f, 0f);
		((XRControl)xrLine29).Name = "xrLine29";
		((XRControl)xrLine29).SizeF = new SizeF(2.130676f, 33.99996f);
		((XRControl)xrLine29).StylePriority.UseBorders = false;
		((XRControl)xrValorISSQN).BorderWidth = 0f;
		((XRControl)xrValorISSQN).Font = new Font("Arial", 8f);
		((XRControl)xrValorISSQN).LocationFloat = new PointFloat(678.1248f, 14.37499f);
		((XRControl)xrValorISSQN).Name = "xrValorISSQN";
		((XRControl)xrValorISSQN).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrValorISSQN).SizeF = new SizeF(225.2086f, 15.625f);
		((XRControl)xrValorISSQN).StylePriority.UseBorderWidth = false;
		((XRControl)xrValorISSQN).StylePriority.UseFont = false;
		((XRControl)xrValorISSQN).Text = "xrNatOp";
		((XRControl)xrLabel65).BorderWidth = 0f;
		((XRControl)xrLabel65).Font = new Font("Arial", 7f);
		((XRControl)xrLabel65).LocationFloat = new PointFloat(678.1248f, 3.20829f);
		((XRControl)xrLabel65).Name = "xrLabel65";
		((XRControl)xrLabel65).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel65).SizeF = new SizeF(189.0079f, 10.41667f);
		((XRControl)xrLabel65).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel65).StylePriority.UseFont = false;
		((XRControl)xrLabel65).Text = "VALOR DO ISSQN";
		((XRControl)xrIM).BorderWidth = 0f;
		((XRControl)xrIM).Font = new Font("Arial", 8f);
		((XRControl)xrIM).LocationFloat = new PointFloat(8.000015f, 14.37499f);
		((XRControl)xrIM).Name = "xrIM";
		((XRControl)xrIM).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrIM).SizeF = new SizeF(192.7083f, 15.625f);
		((XRControl)xrIM).StylePriority.UseBorderWidth = false;
		((XRControl)xrIM).StylePriority.UseFont = false;
		((XRControl)xrLabel67).BorderWidth = 0f;
		((XRControl)xrLabel67).Font = new Font("Arial", 7f);
		((XRControl)xrLabel67).LocationFloat = new PointFloat(8.000015f, 3.208305f);
		((XRControl)xrLabel67).Name = "xrLabel67";
		((XRControl)xrLabel67).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel67).SizeF = new SizeF(140.625f, 10.41667f);
		((XRControl)xrLabel67).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel67).StylePriority.UseFont = false;
		((XRControl)xrLabel67).Text = "INSCRIÇÃO MUNICIPAL";
		xrLabel14.Angle = 90f;
		((XRControl)xrLabel14).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel14).Borders = (BorderSide)13;
		((XRControl)xrLabel14).BorderWidth = 1f;
		((XRControl)xrLabel14).CanGrow = false;
		((XRControl)xrLabel14).Font = new Font("Arial", 6f, FontStyle.Bold);
		((XRControl)xrLabel14).LocationFloat = new PointFloat(0f, 32.95833f);
		((XRControl)xrLabel14).Name = "xrLabel14";
		((XRControl)xrLabel14).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel14).SizeF = new SizeF(29.02274f, 84.00003f);
		((XRControl)xrLabel14).StylePriority.UseBackColor = false;
		((XRControl)xrLabel14).StylePriority.UseBorders = false;
		((XRControl)xrLabel14).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel14).StylePriority.UseFont = false;
		((XRControl)xrLabel14).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel14).Text = "DADOS ADICIONAIS";
		((XRControl)xrLabel14).TextAlignment = (TextAlignment)32;
		xrLabel32.Angle = 90f;
		((XRControl)xrLabel32).BackColor = Color.FromArgb(230, 230, 230);
		((XRControl)xrLabel32).Borders = (BorderSide)15;
		((XRControl)xrLabel32).BorderWidth = 1f;
		((XRControl)xrLabel32).CanGrow = false;
		((XRControl)xrLabel32).Font = new Font("Arial", 4f, FontStyle.Bold);
		((XRControl)xrLabel32).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel32).Name = "xrLabel32";
		((XRControl)xrLabel32).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel32).SizeF = new SizeF(29.02274f, 33.99997f);
		((XRControl)xrLabel32).StylePriority.UseBackColor = false;
		((XRControl)xrLabel32).StylePriority.UseBorders = false;
		((XRControl)xrLabel32).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel32).StylePriority.UseFont = false;
		((XRControl)xrLabel32).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel32).Text = "CÁLCULO DO ISSQN";
		((XRControl)xrLabel32).TextAlignment = (TextAlignment)32;
		((XRControl)xrCrossBandLine6).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine6).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine6).EndPointFloat = new PointFloat(590.1475f, 1.501335f);
		((XRControl)xrCrossBandLine6).Name = "xrCrossBandLine6";
		((XRCrossBandControl)xrCrossBandLine6).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine6).StartPointFloat = new PointFloat(590.1475f, 0f);
		((XRControl)xrCrossBandLine6).WidthF = 1.050415f;
		((XRControl)xrCrossBandLine7).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine7).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine7).EndPointFloat = new PointFloat(637.9809f, 2f);
		((XRControl)xrCrossBandLine7).Name = "xrCrossBandLine7";
		((XRCrossBandControl)xrCrossBandLine7).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine7).StartPointFloat = new PointFloat(637.9809f, 0.9973238f);
		((XRControl)xrCrossBandLine7).WidthF = 1f;
		((XRControl)xrCrossBandLine8).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine8).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine8).EndPointFloat = new PointFloat(830.9448f, 0f);
		((XRControl)xrCrossBandLine8).Name = "xrCrossBandLine8";
		((XRCrossBandControl)xrCrossBandLine8).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine8).StartPointFloat = new PointFloat(830.9448f, 0f);
		((XRControl)xrCrossBandLine8).WidthF = 1f;
		((XRControl)xrCrossBandLine9).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine9).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine9).EndPointFloat = new PointFloat(776.9446f, 2f);
		((XRControl)xrCrossBandLine9).Name = "xrCrossBandLine9";
		((XRCrossBandControl)xrCrossBandLine9).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine9).StartPointFloat = new PointFloat(776.9446f, 0f);
		((XRControl)xrCrossBandLine9).WidthF = 1f;
		((XRControl)xrCrossBandLine10).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine10).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine10).EndPointFloat = new PointFloat(713f, 2f);
		((XRControl)xrCrossBandLine10).Name = "xrCrossBandLine10";
		((XRCrossBandControl)xrCrossBandLine10).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine10).StartPointFloat = new PointFloat(713f, 0f);
		((XRControl)xrCrossBandLine10).WidthF = 1f;
		((XRControl)xrCrossBandLine11).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine11).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine11).EndPointFloat = new PointFloat(660.9809f, 2f);
		((XRControl)xrCrossBandLine11).Name = "xrCrossBandLine11";
		((XRCrossBandControl)xrCrossBandLine11).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine11).StartPointFloat = new PointFloat(660.9809f, 0f);
		((XRControl)xrCrossBandLine11).WidthF = 1f;
		((XRControl)topMarginBand1).HeightF = 30f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).HeightF = 30f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XRControl)xrCrossBandLine12).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine12).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine12).EndPointFloat = new PointFloat(513.1059f, 0.9583435f);
		((XRControl)xrCrossBandLine12).Name = "xrCrossBandLine12";
		((XRCrossBandControl)xrCrossBandLine12).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine12).StartPointFloat = new PointFloat(513.1059f, 0f);
		((XRControl)xrCrossBandLine12).WidthF = 1f;
		((XRControl)xrCrossBandLine13).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine13).EndBand = (Band)(object)GroupFooter1;
		((XRCrossBandControl)xrCrossBandLine13).EndPointFloat = new PointFloat(457.4372f, 1.999999f);
		((XRControl)xrCrossBandLine13).Name = "xrCrossBandLine13";
		((XRCrossBandControl)xrCrossBandLine13).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine13).StartPointFloat = new PointFloat(457.4372f, 1.041659f);
		((XRControl)xrCrossBandLine13).WidthF = 1f;
		((XRControl)xrCrossBandLine14).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine14).EndBand = (Band)(object)SubBand1;
		((XRCrossBandControl)xrCrossBandLine14).EndPointFloat = new PointFloat(868.9448f, 15.46942f);
		((XRControl)xrCrossBandLine14).Name = "xrCrossBandLine14";
		((XRCrossBandControl)xrCrossBandLine14).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine14).StartPointFloat = new PointFloat(868.9448f, 0f);
		((XRControl)xrCrossBandLine14).WidthF = 1.000012f;
		((XRControl)xrCrossBandLine15).AnchorVertical = (VerticalAnchorStyles)3;
		((XRCrossBandControl)xrCrossBandLine15).EndBand = (Band)(object)SubBand1;
		((XRCrossBandControl)xrCrossBandLine15).EndPointFloat = new PointFloat(933.1672f, 15.46942f);
		((XRControl)xrCrossBandLine15).Name = "xrCrossBandLine15";
		((XRCrossBandControl)xrCrossBandLine15).StartBand = (Band)(object)GroupHeader1;
		((XRCrossBandControl)xrCrossBandLine15).StartPointFloat = new PointFloat(933.1672f, 0f);
		((XRControl)xrCrossBandLine15).WidthF = 1.000012f;
		nfItensBindingSource.AutoCreateObjects = false;
		nfItensBindingSource.DataSource = typeof(NotaFiscalNotasFiscaisItens);
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[9]
		{
			(Band)Detail,
			(Band)PageHeader,
			(Band)PageFooter,
			(Band)ReportHeader,
			(Band)topMarginBand1,
			(Band)bottomMarginBand1,
			(Band)GroupHeader1,
			(Band)ReportFooter,
			(Band)GroupFooter1
		});
		((XRControl)this).BorderWidth = 0f;
		((XtraReport)this).ComponentStorage.AddRange(new IComponent[1] { nfItensBindingSource });
		((XtraReport)this).CrossBandControls.AddRange((XRCrossBandControl[])(object)new XRCrossBandControl[16]
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
			(XRCrossBandControl)xrCrossBandLine11,
			(XRCrossBandControl)xrCrossBandLine12,
			(XRCrossBandControl)xrCrossBandLine13,
			(XRCrossBandControl)xrCrossBandLine14,
			(XRCrossBandControl)xrCrossBandLine15
		});
		((XtraReportBase)this).DataSource = nfItensBindingSource;
		((XtraReport)this).DisplayName = "Danfe";
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(51, 51, 30, 30);
		((XtraReport)this).PageHeight = 827;
		((XtraReport)this).PageWidth = 1169;
		((XtraReport)this).PaperKind = PaperKind.A4;
		((XtraReport)this).SnapGridSize = 5.208333f;
		((XtraReport)this).Version = "19.2";
		((XRControl)this).BeforePrint += rptDanfe_BeforePrint;
		((ISupportInitialize)nfItensBindingSource).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
