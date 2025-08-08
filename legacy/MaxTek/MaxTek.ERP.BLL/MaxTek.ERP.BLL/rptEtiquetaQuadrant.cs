using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiquetaQuadrant : XtraReport
{
	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private int quandidadeEmbalagem;

	private int sequenciaEmbalagem;

	private int quantidade;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRBarCode txCodigoBarras;

	private XRLabel txCliente;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel txNotaFiscal;

	private XRLabel txQuantidade;

	private XRLabel txCodigoCliente;

	private XRLabel txDescricao;

	private XRLabel txData;

	private XRLabel txEmpresa;

	private XRPictureBox imLogoEmpresa;

	private XRLabel txCodigoAlmoxarifado;

	private XRLabel xrLabel11;

	private XRLabel xrLabel12;

	private XRLabel txTotalEmb;

	private XRLabel txSeqEmb;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel txProjeto;

	private XRLabel xrLabel15;

	private XRLabel txPedidoCompra;

	private XRLabel xrLabel13;

	private XRLabel txNumeroFornecimento;

	private XRLabel xrLabel8;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRLabel xrLabel17;

	public NotaFiscalNotasFiscaisItens ItemNotaFiscal
	{
		get
		{
			return _itemNotaFiscal;
		}
		set
		{
			_itemNotaFiscal = value;
		}
	}

	public int QuandidadeEmbalagem
	{
		get
		{
			return quandidadeEmbalagem;
		}
		set
		{
			if (quandidadeEmbalagem != value)
			{
				quandidadeEmbalagem = value;
			}
		}
	}

	public int SequenciaEmbalagem
	{
		get
		{
			return sequenciaEmbalagem;
		}
		set
		{
			if (sequenciaEmbalagem != value)
			{
				sequenciaEmbalagem = value;
			}
		}
	}

	public int Quantidade
	{
		get
		{
			return quantidade;
		}
		set
		{
			if (quantidade != value)
			{
				quantidade = value;
			}
		}
	}

	public rptEtiquetaQuadrant()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		imLogoEmpresa.Image = emitente.Logo;
		((XRControl)txEmpresa).Text = emitente.RazaoSocial;
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa != null)
		{
			((XRControl)txDescricao).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
			((XRControl)txCodigoCliente).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
		}
		else
		{
			((XRControl)txDescricao).Text = ItemNotaFiscal.DescricaoProduto;
			((XRControl)txCodigoCliente).Text = ItemNotaFiscal.CodigoProduto;
		}
		((XRControl)txCodigoAlmoxarifado).Text = ItemNotaFiscal.CodigoProduto;
		((XRControl)txQuantidade).Text = Quantidade.ToString();
		((XRControl)txSeqEmb).Text = SequenciaEmbalagem.ToString();
		((XRControl)txTotalEmb).Text = QuandidadeEmbalagem.ToString();
		((XRControl)txData).Text = DateTime.Today.ToShortDateString();
		((XRControl)txProjeto).Text = ItemNotaFiscal.CodigoPedidoVenda.ToString();
		((XRControl)txPedidoCompra).Text = ItemNotaFiscal.ContratoCliente.ToString();
		((XRControl)txNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString();
		((XRControl)txNumeroFornecimento).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoVendedorEDI;
		((XRControl)txCodigoBarras).Text = ((XRControl)txCodigoCliente).Text + Quantidade.ToString("00000") + ((XRControl)txNotaFiscal).Text + ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoVendedorEDI + SequenciaEmbalagem.ToString("00");
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_102f: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Unknown result type (might be due to invalid IL or missing references)
		//IL_112b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1169: Unknown result type (might be due to invalid IL or missing references)
		//IL_1247: Unknown result type (might be due to invalid IL or missing references)
		//IL_1272: Unknown result type (might be due to invalid IL or missing references)
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_1364: Unknown result type (might be due to invalid IL or missing references)
		//IL_142b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1456: Unknown result type (might be due to invalid IL or missing references)
		//IL_151d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1548: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_163a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1701: Unknown result type (might be due to invalid IL or missing references)
		//IL_172c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1800: Unknown result type (might be due to invalid IL or missing references)
		//IL_182b: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_192a: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f30: Unknown result type (might be due to invalid IL or missing references)
		//IL_2006: Unknown result type (might be due to invalid IL or missing references)
		//IL_2031: Unknown result type (might be due to invalid IL or missing references)
		//IL_20dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Unknown result type (might be due to invalid IL or missing references)
		Code39Generator val = new Code39Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptEtiquetaQuadrant));
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		txProjeto = new XRLabel();
		xrLabel15 = new XRLabel();
		txPedidoCompra = new XRLabel();
		xrLabel13 = new XRLabel();
		txNumeroFornecimento = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel12 = new XRLabel();
		txTotalEmb = new XRLabel();
		txSeqEmb = new XRLabel();
		txCodigoAlmoxarifado = new XRLabel();
		txCodigoBarras = new XRBarCode();
		xrLabel1 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel7 = new XRLabel();
		txCliente = new XRLabel();
		txEmpresa = new XRLabel();
		txData = new XRLabel();
		txDescricao = new XRLabel();
		txCodigoCliente = new XRLabel();
		txQuantidade = new XRLabel();
		txNotaFiscal = new XRLabel();
		imLogoEmpresa = new XRPictureBox();
		PageFooter = new PageFooterBand();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrLabel17 = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[30]
		{
			(XRControl)xrLabel10,
			(XRControl)xrLabel9,
			(XRControl)xrLabel17,
			(XRControl)txProjeto,
			(XRControl)xrLabel15,
			(XRControl)txPedidoCompra,
			(XRControl)xrLabel13,
			(XRControl)txNumeroFornecimento,
			(XRControl)xrLabel8,
			(XRControl)xrLabel11,
			(XRControl)xrLabel12,
			(XRControl)txTotalEmb,
			(XRControl)txSeqEmb,
			(XRControl)txCodigoAlmoxarifado,
			(XRControl)txCodigoBarras,
			(XRControl)xrLabel1,
			(XRControl)xrLabel2,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrLabel5,
			(XRControl)xrLabel6,
			(XRControl)xrLabel7,
			(XRControl)txCliente,
			(XRControl)txEmpresa,
			(XRControl)txData,
			(XRControl)txDescricao,
			(XRControl)txCodigoCliente,
			(XRControl)txQuantidade,
			(XRControl)txNotaFiscal,
			(XRControl)imLogoEmpresa
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 444.7395f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 11, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel10).Borders = (BorderSide)0;
		((XRControl)xrLabel10).CanGrow = false;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(775.506f, 385.5001f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(232.494f, 43f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "Kalil Aguiar";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(654.1002f, 385.4998f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(118.3882f, 42.00003f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "Resp.:";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)64;
		((XRControl)txProjeto).Borders = (BorderSide)0;
		((XRControl)txProjeto).CanGrow = false;
		((XRControl)txProjeto).Dpi = 254f;
		((XRControl)txProjeto).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txProjeto).LocationFloat = new PointFloat(773.0903f, 283.5f);
		((XRControl)txProjeto).Name = "txProjeto";
		((XRControl)txProjeto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txProjeto).SizeF = new SizeF(206.9097f, 42f);
		((XRControl)txProjeto).StylePriority.UseBorders = false;
		((XRControl)txProjeto).StylePriority.UseFont = false;
		((XRControl)txProjeto).StylePriority.UseTextAlignment = false;
		((XRControl)txProjeto).Text = "9999/99";
		((XRControl)txProjeto).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel15).Borders = (BorderSide)0;
		((XRControl)xrLabel15).CanGrow = false;
		((XRControl)xrLabel15).Dpi = 254f;
		((XRControl)xrLabel15).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(681.6181f, 283.5f);
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel15).SizeF = new SizeF(90.87024f, 42f);
		((XRControl)xrLabel15).StylePriority.UseBorders = false;
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel15).Text = "Proj.:";
		((XRControl)xrLabel15).TextAlignment = (TextAlignment)64;
		((XRControl)txPedidoCompra).Borders = (BorderSide)0;
		((XRControl)txPedidoCompra).CanGrow = false;
		((XRControl)txPedidoCompra).Dpi = 254f;
		((XRControl)txPedidoCompra).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPedidoCompra).LocationFloat = new PointFloat(858.627f, 206.5209f);
		((XRControl)txPedidoCompra).Name = "txPedidoCompra";
		((XRControl)txPedidoCompra).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPedidoCompra).SizeF = new SizeF(149.373f, 41.99995f);
		((XRControl)txPedidoCompra).StylePriority.UseBorders = false;
		((XRControl)txPedidoCompra).StylePriority.UseFont = false;
		((XRControl)txPedidoCompra).StylePriority.UseTextAlignment = false;
		((XRControl)txPedidoCompra).Text = "999999";
		((XRControl)txPedidoCompra).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel13).Borders = (BorderSide)0;
		((XRControl)xrLabel13).CanGrow = false;
		((XRControl)xrLabel13).Dpi = 254f;
		((XRControl)xrLabel13).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel13).LocationFloat = new PointFloat(739.136f, 206.5209f);
		((XRControl)xrLabel13).Name = "xrLabel13";
		((XRControl)xrLabel13).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel13).SizeF = new SizeF(119.491f, 42f);
		((XRControl)xrLabel13).StylePriority.UseBorders = false;
		((XRControl)xrLabel13).StylePriority.UseFont = false;
		((XRControl)xrLabel13).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel13).Text = "Pedido:";
		((XRControl)xrLabel13).TextAlignment = (TextAlignment)64;
		((XRControl)txNumeroFornecimento).Borders = (BorderSide)0;
		((XRControl)txNumeroFornecimento).CanGrow = false;
		((XRControl)txNumeroFornecimento).Dpi = 254f;
		((XRControl)txNumeroFornecimento).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNumeroFornecimento).LocationFloat = new PointFloat(858.627f, 121.8542f);
		((XRControl)txNumeroFornecimento).Name = "txNumeroFornecimento";
		((XRControl)txNumeroFornecimento).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNumeroFornecimento).SizeF = new SizeF(149.373f, 42f);
		((XRControl)txNumeroFornecimento).StylePriority.UseBorders = false;
		((XRControl)txNumeroFornecimento).StylePriority.UseFont = false;
		((XRControl)txNumeroFornecimento).StylePriority.UseTextAlignment = false;
		((XRControl)txNumeroFornecimento).Text = "5432";
		((XRControl)txNumeroFornecimento).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).CanGrow = false;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(739.136f, 121.8542f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(119.491f, 42f);
		((XRControl)xrLabel8).StylePriority.UseBorders = false;
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel8).Text = "No.";
		((XRControl)xrLabel8).TextAlignment = (TextAlignment)64;
		((XRControl)xrLabel11).Borders = (BorderSide)0;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(328.3748f, 385.5f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(145.5933f, 42f);
		((XRControl)xrLabel11).StylePriority.UseBorders = false;
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel11).Text = "Volumes";
		((XRControl)xrLabel11).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel12).Borders = (BorderSide)0;
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(557.9225f, 385.5f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(27.29878f, 42f);
		((XRControl)xrLabel12).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel12).Text = "/";
		((XRControl)xrLabel12).TextAlignment = (TextAlignment)16;
		((XRControl)txTotalEmb).Borders = (BorderSide)0;
		((XRControl)txTotalEmb).CanGrow = false;
		((XRControl)txTotalEmb).Dpi = 254f;
		((XRControl)txTotalEmb).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txTotalEmb).LocationFloat = new PointFloat(585.2213f, 385.5f);
		((XRControl)txTotalEmb).Name = "txTotalEmb";
		((XRControl)txTotalEmb).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTotalEmb).SizeF = new SizeF(62.56852f, 42f);
		((XRControl)txTotalEmb).StylePriority.UseBorders = false;
		((XRControl)txTotalEmb).StylePriority.UseFont = false;
		((XRControl)txTotalEmb).StylePriority.UseTextAlignment = false;
		((XRControl)txTotalEmb).Text = "99";
		((XRControl)txTotalEmb).TextAlignment = (TextAlignment)16;
		((XRControl)txSeqEmb).Borders = (BorderSide)0;
		((XRControl)txSeqEmb).CanGrow = false;
		((XRControl)txSeqEmb).Dpi = 254f;
		((XRControl)txSeqEmb).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txSeqEmb).LocationFloat = new PointFloat(495.3541f, 385.5f);
		((XRControl)txSeqEmb).Name = "txSeqEmb";
		((XRControl)txSeqEmb).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txSeqEmb).SizeF = new SizeF(62.56852f, 42f);
		((XRControl)txSeqEmb).StylePriority.UseBorders = false;
		((XRControl)txSeqEmb).StylePriority.UseFont = false;
		((XRControl)txSeqEmb).StylePriority.UseTextAlignment = false;
		((XRControl)txSeqEmb).Text = "99";
		((XRControl)txSeqEmb).TextAlignment = (TextAlignment)16;
		((XRControl)txCodigoAlmoxarifado).Borders = (BorderSide)0;
		((XRControl)txCodigoAlmoxarifado).CanGrow = false;
		((XRControl)txCodigoAlmoxarifado).Dpi = 254f;
		((XRControl)txCodigoAlmoxarifado).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoAlmoxarifado).LocationFloat = new PointFloat(189.7329f, 325.4998f);
		((XRControl)txCodigoAlmoxarifado).Name = "txCodigoAlmoxarifado";
		((XRControl)txCodigoAlmoxarifado).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoAlmoxarifado).SizeF = new SizeF(333.1262f, 41.99994f);
		((XRControl)txCodigoAlmoxarifado).StylePriority.UseBorders = false;
		((XRControl)txCodigoAlmoxarifado).StylePriority.UseFont = false;
		((XRControl)txCodigoAlmoxarifado).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoAlmoxarifado).Text = "5432";
		((XRControl)txCodigoAlmoxarifado).TextAlignment = (TextAlignment)16;
		txCodigoBarras.Alignment = (TextAlignment)32;
		((XRControl)txCodigoBarras).AnchorVertical = (VerticalAnchorStyles)1;
		txCodigoBarras.AutoModule = true;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(433.2083f, 13.00001f);
		txCodigoBarras.Module = 3.4f;
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		txCodigoBarras.ShowText = false;
		((XRControl)txCodigoBarras).SizeF = new SizeF(574.7917f, 88f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		val.WideNarrowRatio = 3f;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txCodigoBarras).Text = "160372";
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(9.232849f, 164.5209f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(166.6875f, 42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Cliente";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(9.232849f, 121.8542f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(180.227f, 42.00001f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Fornecedor";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(615.3201f, 325.4998f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(156.7516f, 42.00003f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Emissão";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)64;
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(9.232849f, 206.5209f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(166.6875f, 42f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Descrição";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(9.232849f, 283.5f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(166.7062f, 42f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Código:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(9.232849f, 385.5f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(180.227f, 43f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Quantidade";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(739.136f, 164.5209f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(119.491f, 42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "N.F.:";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)64;
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCliente).LocationFloat = new PointFloat(189.4599f, 164.5209f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(544.2484f, 42f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txEmpresa).Borders = (BorderSide)0;
		((XRControl)txEmpresa).CanGrow = false;
		((XRControl)txEmpresa).Dpi = 254f;
		((XRControl)txEmpresa).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txEmpresa).LocationFloat = new PointFloat(189.4599f, 121.8542f);
		((XRControl)txEmpresa).Name = "txEmpresa";
		((XRControl)txEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmpresa).SizeF = new SizeF(544.2484f, 42f);
		((XRControl)txEmpresa).StylePriority.UseBorders = false;
		((XRControl)txEmpresa).StylePriority.UseFont = false;
		((XRControl)txEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txEmpresa).Text = "QUADRANT SOLIDUR DO BRASIL LTDA";
		((XRControl)txEmpresa).TextAlignment = (TextAlignment)16;
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txData).LocationFloat = new PointFloat(772.0717f, 325.4999f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(211.6035f, 41.99994f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).Text = "15/05/01";
		((XRControl)txData).TextAlignment = (TextAlignment)16;
		((XRControl)txDescricao).Borders = (BorderSide)0;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txDescricao).LocationFloat = new PointFloat(189.4599f, 206.5209f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(543.6652f, 76.9791f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as";
		((XRControl)txDescricao).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(190.0245f, 283.5f);
		((XRControl)txCodigoCliente).Name = "txCodigoCliente";
		((XRControl)txCodigoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoCliente).SizeF = new SizeF(332.8345f, 42f);
		((XRControl)txCodigoCliente).StylePriority.UseBorders = false;
		((XRControl)txCodigoCliente).StylePriority.UseFont = false;
		((XRControl)txCodigoCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoCliente).Text = "160791J";
		((XRControl)txCodigoCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(189.4599f, 385.5f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(131.2067f, 41.99997f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).Text = "200";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)16;
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(858.627f, 164.5209f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(149.373f, 41.99995f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)16;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		imLogoEmpresa.Image = (Image)componentResourceManager.GetObject("imLogoEmpresa.Image");
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(0f, 13.00001f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(395.9375f, 87.99999f);
		imLogoEmpresa.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoEmpresa).StylePriority.UseBorders = false;
		((XRControl)imLogoEmpresa).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoEmpresa).StylePriority.UsePadding = false;
		((XRControl)PageFooter).Dpi = 254f;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 0f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).Dpi = 254f;
		((XRControl)bottomMarginBand1).HeightF = 0f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XRControl)xrLabel17).Borders = (BorderSide)0;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(9.232849f, 325.5f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(180.227f, 42f);
		((XRControl)xrLabel17).StylePriority.UseBorders = false;
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel17).Text = "Cód. Almox.:";
		((XRControl)xrLabel17).TextAlignment = (TextAlignment)16;
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[5]
		{
			(Band)Detail,
			(Band)PageHeader,
			(Band)PageFooter,
			(Band)topMarginBand1,
			(Band)bottomMarginBand1
		});
		((XRControl)this).Borders = (BorderSide)15;
		((XRControl)this).Dpi = 254f;
		((XtraReport)this).Margins = new Margins(5, 0, 0, 0);
		((XtraReport)this).PageHeight = 508;
		((XtraReport)this).PageWidth = 1013;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "16.1";
		((ISupportInitialize)this).EndInit();
	}
}
