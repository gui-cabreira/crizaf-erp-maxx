using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiqueta400NF : XtraReport
{
	private bool _isQdeQuebrada = false;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private XRBarCode txCodigoBarras;

	private XRLabel txtCliente;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel1;

	private XRLabel txtNotaFiscal;

	private XRLabel txtQuantidade;

	private XRLabel txtCodigoCliente;

	private XRLabel txtDescricao;

	private XRLabel txtContato;

	private XRLabel txtEmpresa;

	private XRLine xrLine1;

	private XRLine xrLine4;

	private XRLine xrLine3;

	private XRPictureBox imLogoEmpresa;

	private XRLabel txtReferencia;

	private XRPictureBox imLogoCliente;

	private XRLabel xrLabel8;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel txtPedido;

	private XRLabel xrLabel2;

	private XRLine xrLine2;

	private XRLabel txtDesenho;

	private XRLabel xrLabel9;

	public bool IsQdeQuebrada
	{
		get
		{
			return _isQdeQuebrada;
		}
		set
		{
			_isQdeQuebrada = value;
		}
	}

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

	public rptEtiqueta400NF()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		imLogoCliente.Image = ItemNotaFiscal.NotaFiscalRef.Entidade.Logo;
		imLogoEmpresa.Image = emitente.Logo;
		((XRControl)txtEmpresa).Text = emitente.RazaoSocial;
		((XRControl)txtPedido).Text = ItemNotaFiscal.NotaFiscalRef.FichaExpedicaoRef.PedidoVenda.CodigoPedidoVenda.ToString();
		((XRControl)txtContato).Text = ItemNotaFiscal.NotaFiscalRef.FichaExpedicaoRef.PedidoVenda.NomeContato;
		((XRControl)txtCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
		((XRControl)txtDesenho).Text = ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.Desenho;
		((XRControl)txtCodigoCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.Codigo.ToString();
		((XRControl)txtReferencia).Text = ItemNotaFiscal.NotaFiscalRef.FichaExpedicaoRef.PedidoVenda.ReferenciaPedido;
		((XRControl)txCodigoBarras).Text = ItemNotaFiscal.CodigoProduto;
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa != null)
		{
			((XRControl)txtDescricao).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
		}
		else
		{
			((XRControl)txtDescricao).Text = ItemNotaFiscal.DescricaoProduto;
		}
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
		{
			((XRControl)txtQuantidade).Text = ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem.ToString();
		}
		else
		{
			((XRControl)txtQuantidade).Text = ItemNotaFiscal.Quantidade.ToString();
		}
		if (IsQdeQuebrada)
		{
			int num = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
			((XRControl)txtQuantidade).Text = num.ToString();
		}
		((XRControl)txtNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString("000000");
		int num2 = ItemNotaFiscal.Ordem + 1;
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
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ede: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1098: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_128a: Unknown result type (might be due to invalid IL or missing references)
		//IL_133c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1367: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Unknown result type (might be due to invalid IL or missing references)
		//IL_1444: Unknown result type (might be due to invalid IL or missing references)
		//IL_150e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1698: Unknown result type (might be due to invalid IL or missing references)
		//IL_173f: Unknown result type (might be due to invalid IL or missing references)
		//IL_176a: Unknown result type (might be due to invalid IL or missing references)
		Code39Generator val = new Code39Generator();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		txtDesenho = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLine2 = new XRLine();
		txtPedido = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel8 = new XRLabel();
		imLogoCliente = new XRPictureBox();
		txtReferencia = new XRLabel();
		txCodigoBarras = new XRBarCode();
		xrLabel1 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel7 = new XRLabel();
		txtCliente = new XRLabel();
		txtEmpresa = new XRLabel();
		txtContato = new XRLabel();
		txtDescricao = new XRLabel();
		txtCodigoCliente = new XRLabel();
		txtQuantidade = new XRLabel();
		txtNotaFiscal = new XRLabel();
		xrLine1 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		imLogoEmpresa = new XRPictureBox();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[26]
		{
			(XRControl)txtDesenho,
			(XRControl)xrLabel9,
			(XRControl)xrLine2,
			(XRControl)txtPedido,
			(XRControl)xrLabel2,
			(XRControl)xrLabel8,
			(XRControl)imLogoCliente,
			(XRControl)txtReferencia,
			(XRControl)txCodigoBarras,
			(XRControl)xrLabel1,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrLabel5,
			(XRControl)xrLabel6,
			(XRControl)xrLabel7,
			(XRControl)txtCliente,
			(XRControl)txtEmpresa,
			(XRControl)txtContato,
			(XRControl)txtDescricao,
			(XRControl)txtCodigoCliente,
			(XRControl)txtQuantidade,
			(XRControl)txtNotaFiscal,
			(XRControl)xrLine1,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 955f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)txtDesenho).Borders = (BorderSide)0;
		((XRControl)txtDesenho).CanGrow = false;
		((XRControl)txtDesenho).Dpi = 254f;
		((XRControl)txtDesenho).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtDesenho).LocationFloat = new PointFloat(32.00003f, 553.0002f);
		((XRControl)txtDesenho).Name = "txtDesenho";
		((XRControl)txtDesenho).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtDesenho).SizeF = new SizeF(466f, 42f);
		((XRControl)txtDesenho).StylePriority.UseBorders = false;
		((XRControl)txtDesenho).StylePriority.UseFont = false;
		((XRControl)txtDesenho).Text = "160791J";
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).LocationFloat = new PointFloat(32f, 595.0002f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(254f, 33.99982f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).Text = "Cód. Cliente:";
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 2f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(7f, 944f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(693f, 11f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine2).Visible = false;
		((XRControl)txtPedido).Borders = (BorderSide)0;
		((XRControl)txtPedido).CanGrow = false;
		((XRControl)txtPedido).Dpi = 254f;
		((XRControl)txtPedido).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtPedido).LocationFloat = new PointFloat(32f, 307.6877f);
		((XRControl)txtPedido).Name = "txtPedido";
		((XRControl)txtPedido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtPedido).SizeF = new SizeF(466f, 42f);
		((XRControl)txtPedido).StylePriority.UseBorders = false;
		((XRControl)txtPedido).StylePriority.UseFont = false;
		((XRControl)txtPedido).Text = "001";
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).LocationFloat = new PointFloat(32f, 265.6877f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).Text = "Pedido:";
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).LocationFloat = new PointFloat(287.7291f, 840.0001f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(210.2709f, 42f);
		((XRControl)xrLabel8).StylePriority.UseBorders = false;
		((XRControl)xrLabel8).Text = "Referência:";
		((XRControl)imLogoCliente).Borders = (BorderSide)0;
		((XRControl)imLogoCliente).BorderWidth = 0f;
		((XRControl)imLogoCliente).Dpi = 254f;
		((XRControl)imLogoCliente).LocationFloat = new PointFloat(423f, 25.00001f);
		((XRControl)imLogoCliente).Name = "imLogoCliente";
		((XRControl)imLogoCliente).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoCliente).SizeF = new SizeF(254f, 99.64581f);
		imLogoCliente.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoCliente).StylePriority.UseBorders = false;
		((XRControl)imLogoCliente).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoCliente).StylePriority.UsePadding = false;
		((XRControl)txtReferencia).Borders = (BorderSide)0;
		((XRControl)txtReferencia).CanGrow = false;
		((XRControl)txtReferencia).Dpi = 254f;
		((XRControl)txtReferencia).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtReferencia).LocationFloat = new PointFloat(287.7291f, 882.0001f);
		((XRControl)txtReferencia).Name = "txtReferencia";
		((XRControl)txtReferencia).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtReferencia).SizeF = new SizeF(389.2709f, 41.99994f);
		((XRControl)txtReferencia).StylePriority.UseBorders = false;
		((XRControl)txtReferencia).StylePriority.UseFont = false;
		((XRControl)txtReferencia).StylePriority.UseTextAlignment = false;
		((XRControl)txtReferencia).Text = "54329";
		((XRControl)txtReferencia).TextAlignment = (TextAlignment)1;
		txCodigoBarras.Alignment = (TextAlignment)2;
		txCodigoBarras.BarCodeOrientation = (BarCodeOrientation)3;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(508f, 207f);
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txCodigoBarras).SizeF = new SizeF(169f, 631.021f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		val.WideNarrowRatio = 3f;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txCodigoBarras).Text = "00543201";
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).LocationFloat = new PointFloat(31.99997f, 181.6877f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).Text = "Empresa:";
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).LocationFloat = new PointFloat(32f, 755f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).Text = "A/C:";
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).LocationFloat = new PointFloat(32f, 349.6877f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).Text = "Descrição:";
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).LocationFloat = new PointFloat(32f, 511.0002f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).Text = "Desenho:";
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).LocationFloat = new PointFloat(32f, 671f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).Text = "Quantidade:";
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).LocationFloat = new PointFloat(32f, 840.0001f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).Text = "NF:";
		((XRControl)txtCliente).Borders = (BorderSide)0;
		((XRControl)txtCliente).CanGrow = false;
		((XRControl)txtCliente).Dpi = 254f;
		((XRControl)txtCliente).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtCliente).LocationFloat = new PointFloat(31.99998f, 223.6877f);
		((XRControl)txtCliente).Name = "txtCliente";
		((XRControl)txtCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtCliente).SizeF = new SizeF(466f, 42f);
		((XRControl)txtCliente).StylePriority.UseBorders = false;
		((XRControl)txtCliente).StylePriority.UseFont = false;
		((XRControl)txtCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txtEmpresa).Borders = (BorderSide)0;
		((XRControl)txtEmpresa).CanGrow = false;
		((XRControl)txtEmpresa).Dpi = 254f;
		((XRControl)txtEmpresa).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtEmpresa).LocationFloat = new PointFloat(32f, 139.6877f);
		((XRControl)txtEmpresa).Name = "txtEmpresa";
		((XRControl)txtEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtEmpresa).SizeF = new SizeF(466f, 42f);
		((XRControl)txtEmpresa).StylePriority.UseBorders = false;
		((XRControl)txtEmpresa).StylePriority.UseFont = false;
		((XRControl)txtEmpresa).Text = "Leravi Indústrial";
		((XRControl)txtContato).Borders = (BorderSide)0;
		((XRControl)txtContato).CanGrow = false;
		((XRControl)txtContato).Dpi = 254f;
		((XRControl)txtContato).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtContato).LocationFloat = new PointFloat(32f, 797.0001f);
		((XRControl)txtContato).Name = "txtContato";
		((XRControl)txtContato).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtContato).SizeF = new SizeF(466f, 42f);
		((XRControl)txtContato).StylePriority.UseBorders = false;
		((XRControl)txtContato).StylePriority.UseFont = false;
		((XRControl)txtContato).Text = "Comprador";
		((XRControl)txtDescricao).Borders = (BorderSide)0;
		((XRControl)txtDescricao).CanGrow = false;
		((XRControl)txtDescricao).Dpi = 254f;
		((XRControl)txtDescricao).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtDescricao).LocationFloat = new PointFloat(32f, 391.6877f);
		txtDescricao.Multiline = true;
		((XRControl)txtDescricao).Name = "txtDescricao";
		((XRControl)txtDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtDescricao).SizeF = new SizeF(466f, 119.3124f);
		((XRControl)txtDescricao).StylePriority.UseBorders = false;
		((XRControl)txtDescricao).StylePriority.UseFont = false;
		((XRControl)txtDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as";
		((XRControl)txtCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txtCodigoCliente).CanGrow = false;
		((XRControl)txtCodigoCliente).Dpi = 254f;
		((XRControl)txtCodigoCliente).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtCodigoCliente).LocationFloat = new PointFloat(32f, 629f);
		((XRControl)txtCodigoCliente).Name = "txtCodigoCliente";
		((XRControl)txtCodigoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtCodigoCliente).SizeF = new SizeF(466f, 42f);
		((XRControl)txtCodigoCliente).StylePriority.UseBorders = false;
		((XRControl)txtCodigoCliente).StylePriority.UseFont = false;
		((XRControl)txtCodigoCliente).Text = "55555";
		((XRControl)txtQuantidade).Borders = (BorderSide)0;
		((XRControl)txtQuantidade).CanGrow = false;
		((XRControl)txtQuantidade).Dpi = 254f;
		((XRControl)txtQuantidade).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtQuantidade).LocationFloat = new PointFloat(31.99998f, 713f);
		((XRControl)txtQuantidade).Name = "txtQuantidade";
		((XRControl)txtQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtQuantidade).SizeF = new SizeF(466f, 42f);
		((XRControl)txtQuantidade).StylePriority.UseBorders = false;
		((XRControl)txtQuantidade).StylePriority.UseFont = false;
		((XRControl)txtQuantidade).Text = "200";
		((XRControl)txtNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txtNotaFiscal).CanGrow = false;
		((XRControl)txtNotaFiscal).Dpi = 254f;
		((XRControl)txtNotaFiscal).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txtNotaFiscal).LocationFloat = new PointFloat(32f, 882.0001f);
		((XRControl)txtNotaFiscal).Name = "txtNotaFiscal";
		((XRControl)txtNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txtNotaFiscal).SizeF = new SizeF(180f, 42f);
		((XRControl)txtNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txtNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txtNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txtNotaFiscal).Text = "999999";
		((XRControl)txtNotaFiscal).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 2f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(5f, 0f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(693f, 11f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine1).Visible = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 2f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(0f, 10.99999f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 933.0001f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Visible = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 2f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(691f, 10.99999f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(11f, 933.0001f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Visible = false;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(32f, 25.00001f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(254f, 99.64581f);
		imLogoEmpresa.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoEmpresa).StylePriority.UseBorders = false;
		((XRControl)imLogoEmpresa).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoEmpresa).StylePriority.UsePadding = false;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 0f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).Dpi = 254f;
		((XRControl)bottomMarginBand1).HeightF = 0f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[4]
		{
			(Band)Detail,
			(Band)PageHeader,
			(Band)topMarginBand1,
			(Band)bottomMarginBand1
		});
		((XRControl)this).Borders = (BorderSide)15;
		((XRControl)this).Dpi = 254f;
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 1000;
		((XtraReport)this).PageWidth = 700;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "19.2";
		((ISupportInitialize)this).EndInit();
	}
}
