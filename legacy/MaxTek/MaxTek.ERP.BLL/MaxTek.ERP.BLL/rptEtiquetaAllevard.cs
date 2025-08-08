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

public class rptEtiquetaAllevard : XtraReport
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

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRLine xrLine4;

	private XRLine xrLine3;

	private XRPictureBox imLogoEmpresa;

	private XRLabel xrLabel9;

	private XRLabel txItemNota;

	private XRLabel txPecaInterno;

	private XRPictureBox imLogoCliente;

	private XRLabel xrLabel11;

	private XRLabel xrLabel12;

	private XRLabel txTotalEmb;

	private XRLabel txSeqEmb;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

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

	public rptEtiquetaAllevard()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		((XRControl)txData).Text = DateTime.Today.ToShortDateString();
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
		imLogoCliente.Image = ItemNotaFiscal.NotaFiscalRef.Entidade.Logo;
		((XRControl)txEmpresa).Text = emitente.RazaoSocial;
		imLogoEmpresa.Image = emitente.Logo;
		((XRControl)txPecaInterno).Text = ItemNotaFiscal.CodigoProduto;
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
		((XRControl)txQuantidade).Text = Quantidade.ToString();
		((XRControl)txNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString("000000");
		int num = ItemNotaFiscal.Ordem + 1;
		((XRControl)txItemNota).Text = num.ToString("00");
		((XRControl)txSeqEmb).Text = SequenciaEmbalagem.ToString();
		((XRControl)txTotalEmb).Text = QuandidadeEmbalagem.ToString();
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
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1197: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1274: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_135e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1389: Unknown result type (might be due to invalid IL or missing references)
		//IL_143b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1466: Unknown result type (might be due to invalid IL or missing references)
		//IL_151a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1545: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_178c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acc: Unknown result type (might be due to invalid IL or missing references)
		EAN128Generator val = new EAN128Generator();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel11 = new XRLabel();
		xrLabel12 = new XRLabel();
		txTotalEmb = new XRLabel();
		txSeqEmb = new XRLabel();
		imLogoCliente = new XRPictureBox();
		txPecaInterno = new XRLabel();
		xrLabel9 = new XRLabel();
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
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		imLogoEmpresa = new XRPictureBox();
		txItemNota = new XRLabel();
		PageFooter = new PageFooterBand();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 984f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[28]
		{
			(XRControl)xrLabel11,
			(XRControl)xrLabel12,
			(XRControl)txTotalEmb,
			(XRControl)txSeqEmb,
			(XRControl)imLogoCliente,
			(XRControl)txPecaInterno,
			(XRControl)xrLabel9,
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
			(XRControl)xrLine1,
			(XRControl)xrLine2,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa,
			(XRControl)txItemNota
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 1015.875f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 11, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel11).Borders = (BorderSide)0;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).LocationFloat = new PointFloat(32f, 885f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(415.4683f, 31f);
		((XRControl)xrLabel11).StylePriority.UseBorders = false;
		((XRControl)xrLabel11).Text = "Sequência de Embalagem";
		((XRControl)xrLabel12).Borders = (BorderSide)0;
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(94.56852f, 924.3333f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(27.29878f, 48f);
		((XRControl)xrLabel12).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).Text = "/";
		((XRControl)txTotalEmb).Borders = (BorderSide)0;
		((XRControl)txTotalEmb).CanGrow = false;
		((XRControl)txTotalEmb).Dpi = 254f;
		((XRControl)txTotalEmb).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txTotalEmb).LocationFloat = new PointFloat(121.8673f, 924.3333f);
		((XRControl)txTotalEmb).Name = "txTotalEmb";
		((XRControl)txTotalEmb).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTotalEmb).SizeF = new SizeF(62.56852f, 48f);
		((XRControl)txTotalEmb).StylePriority.UseBorders = false;
		((XRControl)txTotalEmb).StylePriority.UseFont = false;
		((XRControl)txTotalEmb).StylePriority.UseTextAlignment = false;
		((XRControl)txTotalEmb).Text = "99";
		((XRControl)txTotalEmb).TextAlignment = (TextAlignment)1;
		((XRControl)txSeqEmb).Borders = (BorderSide)0;
		((XRControl)txSeqEmb).CanGrow = false;
		((XRControl)txSeqEmb).Dpi = 254f;
		((XRControl)txSeqEmb).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txSeqEmb).LocationFloat = new PointFloat(32f, 924.3333f);
		((XRControl)txSeqEmb).Name = "txSeqEmb";
		((XRControl)txSeqEmb).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txSeqEmb).SizeF = new SizeF(62.56852f, 48f);
		((XRControl)txSeqEmb).StylePriority.UseBorders = false;
		((XRControl)txSeqEmb).StylePriority.UseFont = false;
		((XRControl)txSeqEmb).StylePriority.UseTextAlignment = false;
		((XRControl)txSeqEmb).Text = "99";
		((XRControl)txSeqEmb).TextAlignment = (TextAlignment)1;
		((XRControl)imLogoCliente).Borders = (BorderSide)0;
		((XRControl)imLogoCliente).BorderWidth = 0f;
		((XRControl)imLogoCliente).Dpi = 254f;
		((XRControl)imLogoCliente).LocationFloat = new PointFloat(212f, 25.00001f);
		((XRControl)imLogoCliente).Name = "imLogoCliente";
		((XRControl)imLogoCliente).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoCliente).SizeF = new SizeF(288.3958f, 101.0417f);
		imLogoCliente.Sizing = (ImageSizeMode)4;
		((XRControl)imLogoCliente).StylePriority.UseBorders = false;
		((XRControl)imLogoCliente).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoCliente).StylePriority.UsePadding = false;
		((XRControl)imLogoCliente).Visible = false;
		((XRControl)txPecaInterno).Borders = (BorderSide)0;
		((XRControl)txPecaInterno).CanGrow = false;
		((XRControl)txPecaInterno).Dpi = 254f;
		((XRControl)txPecaInterno).Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPecaInterno).LocationFloat = new PointFloat(291.2084f, 918.3333f);
		((XRControl)txPecaInterno).Name = "txPecaInterno";
		((XRControl)txPecaInterno).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecaInterno).SizeF = new SizeF(206.7916f, 54f);
		((XRControl)txPecaInterno).StylePriority.UseBorders = false;
		((XRControl)txPecaInterno).StylePriority.UseFont = false;
		((XRControl)txPecaInterno).StylePriority.UseTextAlignment = false;
		((XRControl)txPecaInterno).Text = "5432";
		((XRControl)txPecaInterno).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(212f, 827f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(20.99998f, 47.69f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "/";
		txCodigoBarras.Alignment = (TextAlignment)32;
		((XRControl)txCodigoBarras).AnchorVertical = (VerticalAnchorStyles)1;
		txCodigoBarras.BarCodeOrientation = (BarCodeOrientation)3;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(508f, 62.04168f);
		txCodigoBarras.Module = 3.4f;
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txCodigoBarras).SizeF = new SizeF(169f, 910.2916f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		((Code128Generator)val).CharacterSet = (Code128Charset)0;
		val.FNC1Substitute = "";
		val.HumanReadableText = false;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txCodigoBarras).Text = "160372D00080028275F0016601";
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).LocationFloat = new PointFloat(32f, 121f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).Text = "Cliente";
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).LocationFloat = new PointFloat(32f, 218f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).Text = "Fornecedor";
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).LocationFloat = new PointFloat(32f, 318f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).Text = "Data Emissão";
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).LocationFloat = new PointFloat(32f, 512f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).Text = "Peça (Descrição)";
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).LocationFloat = new PointFloat(32f, 415f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).Text = "Código Peça";
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).LocationFloat = new PointFloat(31.99998f, 693f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(254f, 43f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).Text = "Quantidade";
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).LocationFloat = new PointFloat(32f, 784f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).Text = "No Doc. Fiscal";
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCliente).LocationFloat = new PointFloat(31.99998f, 164f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(466f, 42f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txEmpresa).Borders = (BorderSide)0;
		((XRControl)txEmpresa).CanGrow = false;
		((XRControl)txEmpresa).Dpi = 254f;
		((XRControl)txEmpresa).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txEmpresa).LocationFloat = new PointFloat(32f, 260f);
		((XRControl)txEmpresa).Name = "txEmpresa";
		((XRControl)txEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmpresa).SizeF = new SizeF(466f, 42f);
		((XRControl)txEmpresa).StylePriority.UseBorders = false;
		((XRControl)txEmpresa).StylePriority.UseFont = false;
		((XRControl)txEmpresa).Text = "RCastro & Cia Ltda";
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txData).LocationFloat = new PointFloat(32f, 360f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(466f, 42f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).Text = "15/05/01";
		((XRControl)txDescricao).Borders = (BorderSide)0;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txDescricao).LocationFloat = new PointFloat(31.99998f, 555f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(466f, 124.6041f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as";
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(32f, 457f);
		((XRControl)txCodigoCliente).Name = "txCodigoCliente";
		((XRControl)txCodigoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoCliente).SizeF = new SizeF(466f, 42f);
		((XRControl)txCodigoCliente).StylePriority.UseBorders = false;
		((XRControl)txCodigoCliente).StylePriority.UseFont = false;
		((XRControl)txCodigoCliente).Text = "160791J";
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(32f, 736f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(466f, 42f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).Text = "200";
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(32f, 827f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(180f, 47.69f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Borders = (BorderSide)2;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 4f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(5f, 0f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(693f, 11f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine1).Visible = false;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 4f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(0f, 996f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(693f, 11f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine2).Visible = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 4f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(0f, 23f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 974f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Visible = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 4f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(691f, 11f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(11f, 974f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Visible = false;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(32f, 49f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(254f, 64f);
		imLogoEmpresa.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoEmpresa).StylePriority.UseBorders = false;
		((XRControl)imLogoEmpresa).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoEmpresa).StylePriority.UsePadding = false;
		((XRControl)txItemNota).Borders = (BorderSide)0;
		((XRControl)txItemNota).CanGrow = false;
		((XRControl)txItemNota).Dpi = 254f;
		((XRControl)txItemNota).Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txItemNota).LocationFloat = new PointFloat(241f, 827f);
		((XRControl)txItemNota).Name = "txItemNota";
		((XRControl)txItemNota).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItemNota).SizeF = new SizeF(66f, 47.69f);
		((XRControl)txItemNota).StylePriority.UseBorders = false;
		((XRControl)txItemNota).StylePriority.UseFont = false;
		((XRControl)txItemNota).StylePriority.UseTextAlignment = false;
		((XRControl)txItemNota).Text = "99";
		((XRControl)txItemNota).TextAlignment = (TextAlignment)1;
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
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 1000;
		((XtraReport)this).PageWidth = 700;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "16.2";
		((ISupportInitialize)this).EndInit();
	}
}
