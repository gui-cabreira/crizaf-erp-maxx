using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiquetaSavTec334 : XtraReport
{
	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private int quandidadeEmbalagem;

	private int sequenciaEmbalagem;

	private int quantidade;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRLabel txCliente;

	private XRLabel xrLabel7;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel1;

	private XRLabel txNotaFiscal;

	private XRLabel txCodigoCliente;

	private XRLabel txDescricao;

	private XRLabel txData;

	private XRPictureBox imLogoEmpresa;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRBarCode txCodigoBarras;

	private XRLabel xrLabel2;

	private XRLabel txQuantidade;

	private XRLine xrLine3;

	private XRLine xrLine1;

	private XRLine xrLine2;

	private XRLine xrLine4;

	private XRLabel xrLabel8;

	private XRLabel xrLabel6;

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

	public rptEtiquetaSavTec334()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		imLogoEmpresa.Image = emitente.Logo;
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.NomeFantasia;
		((XRControl)txDescricao).Text = ItemNotaFiscal.DescricaoProduto;
		((XRControl)txCodigoCliente).Text = ItemNotaFiscal.CodigoProduto;
		((XRControl)txQuantidade).Text = Quantidade.ToString();
		((XRControl)txData).Text = ItemNotaFiscal.NotaFiscalRef.DataEmissao.ToShortDateString();
		((XRControl)txNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString();
		((XRControl)txCodigoBarras).Text = ItemNotaFiscal.CodigoProduto;
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
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1265: Unknown result type (might be due to invalid IL or missing references)
		//IL_1290: Unknown result type (might be due to invalid IL or missing references)
		//IL_1362: Unknown result type (might be due to invalid IL or missing references)
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1436: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ae: Unknown result type (might be due to invalid IL or missing references)
		Code128Generator symbology = new Code128Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptEtiquetaSavTec334));
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel8 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLine3 = new XRLine();
		xrLine1 = new XRLine();
		txCodigoBarras = new XRBarCode();
		xrLabel1 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel7 = new XRLabel();
		txCliente = new XRLabel();
		txData = new XRLabel();
		txDescricao = new XRLabel();
		txCodigoCliente = new XRLabel();
		txNotaFiscal = new XRLabel();
		imLogoEmpresa = new XRPictureBox();
		xrLabel2 = new XRLabel();
		txQuantidade = new XRLabel();
		xrLine2 = new XRLine();
		xrLine4 = new XRLine();
		PageFooter = new PageFooterBand();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[20]
		{
			(XRControl)xrLabel8,
			(XRControl)xrLabel6,
			(XRControl)xrLine3,
			(XRControl)xrLine1,
			(XRControl)txCodigoBarras,
			(XRControl)xrLabel1,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrLabel5,
			(XRControl)xrLabel7,
			(XRControl)txCliente,
			(XRControl)txData,
			(XRControl)txDescricao,
			(XRControl)txCodigoCliente,
			(XRControl)txNotaFiscal,
			(XRControl)imLogoEmpresa,
			(XRControl)xrLabel2,
			(XRControl)txQuantidade,
			(XRControl)xrLine2,
			(XRControl)xrLine4
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 453.5833f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(5, 5, 5, 5, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).CanGrow = false;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).Font = new Font("Segoe UI", 5f);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(791.5588f, 404.4165f);
		xrLabel8.Multiline = true;
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(159.8748f, 22.16681f);
		((XRControl)xrLabel8).StylePriority.UseBorders = false;
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel8).Text = "Form. 5.5.7.02019";
		((XRControl)xrLabel8).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Segoe UI", 10f, FontStyle.Bold | FontStyle.Italic);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(325.25f, 199.8525f);
		xrLabel6.Multiline = true;
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(399.5209f, 41.80661f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).Text = "PRODUTO ACABADO";
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 2f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(964.7672f, 9.583314f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)xrLine3).SizeF = new SizeF(5.291687f, 433.1041f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UsePadding = false;
		((XRControl)xrLine1).AnchorVertical = (VerticalAnchorStyles)2;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		xrLine1.LineWidth = 2f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(4.265001f, 438.0833f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)xrLine1).SizeF = new SizeF(965.7939f, 15.5f);
		((XRControl)xrLine1).StylePriority.UsePadding = false;
		txCodigoBarras.AutoModule = true;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(316.6249f, 25.00001f);
		txCodigoBarras.Module = 5.08f;
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		txCodigoBarras.ShowText = false;
		((XRControl)txCodigoBarras).SizeF = new SizeF(637.8089f, 144.3751f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)symbology;
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(48f, 258.8542f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(175.2858f, 42.99989f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Cliente:";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(636.9338f, 301.8541f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(140.428f, 42.66656f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Emissão:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).CanGrow = false;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(47.99999f, 346.1876f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(175.2858f, 42.66656f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Descrição:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(47.99999f, 302.5209f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(175.2858f, 42.66663f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Código:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(636.9338f, 258.8542f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(140.428f, 42.66656f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "N.F.:";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)16;
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)txCliente).LocationFloat = new PointFloat(223.2858f, 258.8542f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(360.7312f, 42.99989f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)txData).LocationFloat = new PointFloat(777.3618f, 301.8541f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(163.8426f, 42.66656f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).TextAlignment = (TextAlignment)64;
		((XRControl)txDescricao).Borders = (BorderSide)0;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		((XRControl)txDescricao).LocationFloat = new PointFloat(223.2858f, 346.1876f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(360.7313f, 42.66656f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricao).TextAlignment = (TextAlignment)256;
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(223.2858f, 302.5209f);
		((XRControl)txCodigoCliente).Name = "txCodigoCliente";
		((XRControl)txCodigoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoCliente).SizeF = new SizeF(360.7313f, 42.66663f);
		((XRControl)txCodigoCliente).StylePriority.UseBorders = false;
		((XRControl)txCodigoCliente).StylePriority.UseFont = false;
		((XRControl)txCodigoCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(777.3618f, 258.8542f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(163.8426f, 42.66656f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)64;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		imLogoEmpresa.Image = (Image)componentResourceManager.GetObject("imLogoEmpresa.Image");
		imLogoEmpresa.ImageAlignment = (ImageAlignment)2;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(25f, 25.00001f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(291.6249f, 144.3751f);
		imLogoEmpresa.Sizing = (ImageSizeMode)4;
		((XRControl)imLogoEmpresa).StylePriority.UseBorders = false;
		((XRControl)imLogoEmpresa).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoEmpresa).StylePriority.UsePadding = false;
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(637.256f, 346.1874f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(140.428f, 42.66656f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Quant.:";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(777.6839f, 346.1874f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(163.5207f, 42.66656f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)64;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		xrLine2.LineWidth = 2f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(4.156864f, 0f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)xrLine2).SizeF = new SizeF(965.902f, 15f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UsePadding = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 2f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(0.9999995f, 3.583317f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)xrLine4).SizeF = new SizeF(15f, 439.1041f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UsePadding = false;
		((XRControl)PageFooter).Dpi = 254f;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 40f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).Dpi = 254f;
		((XRControl)bottomMarginBand1).HeightF = 0f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
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
		((XtraReport)this).Margins = new Margins(40, 32, 40, 0);
		((XtraReport)this).PageHeight = 550;
		((XtraReport)this).PageWidth = 1073;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "18.1";
		((ISupportInitialize)this).EndInit();
	}
}
