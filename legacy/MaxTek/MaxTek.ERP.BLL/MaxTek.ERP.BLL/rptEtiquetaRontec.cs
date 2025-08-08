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

public class rptEtiquetaRontec : XtraReport
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

	private XRLabel txNotaFiscal;

	private XRLabel txQuantidade;

	private XRLabel txCodigoCliente;

	private XRLabel txDescricao;

	private XRLabel txData;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel6;

	private XRPictureBox imLogoEmpresa;

	private XRBarCode txCodigoBarras;

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

	public rptEtiquetaRontec()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		((XRControl)txData).Text = DateTime.Today.ToShortDateString();
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
		((XRControl)txCodigoCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoCompradorEDI;
		imLogoEmpresa.Image = emitente.Logo;
		((XRControl)txDescricao).Text = ItemNotaFiscal.DescricaoProduto + " " + ItemNotaFiscal.DescricaoComplementar;
		((XRControl)txCodigoCliente).Text = ItemNotaFiscal.CodigoProduto;
		((XRControl)txCodigoBarras).Text = ItemNotaFiscal.CodigoProduto;
		((XRControl)txQuantidade).Text = Quantidade.ToString();
		((XRControl)txNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString("000000");
		int num = ItemNotaFiscal.Ordem + 1;
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
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		Code39Generator val = new Code39Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptEtiquetaRontec));
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		txCodigoBarras = new XRBarCode();
		imLogoEmpresa = new XRPictureBox();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel7 = new XRLabel();
		txCliente = new XRLabel();
		txData = new XRLabel();
		txDescricao = new XRLabel();
		txCodigoCliente = new XRLabel();
		txQuantidade = new XRLabel();
		txNotaFiscal = new XRLabel();
		PageFooter = new PageFooterBand();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((Band)Detail).Expanded = false;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)Detail).Visible = false;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[13]
		{
			(XRControl)txCodigoBarras,
			(XRControl)imLogoEmpresa,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrLabel5,
			(XRControl)xrLabel6,
			(XRControl)xrLabel7,
			(XRControl)txCliente,
			(XRControl)txData,
			(XRControl)txDescricao,
			(XRControl)txCodigoCliente,
			(XRControl)txQuantidade,
			(XRControl)txNotaFiscal
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 500.302f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 11, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		txCodigoBarras.Alignment = (TextAlignment)32;
		((XRControl)txCodigoBarras).AnchorVertical = (VerticalAnchorStyles)1;
		txCodigoBarras.AutoModule = true;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(443.5649f, 61.45835f);
		txCodigoBarras.Module = 3.4f;
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		txCodigoBarras.ShowText = false;
		((XRControl)txCodigoBarras).SizeF = new SizeF(549.4351f, 88f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		val.WideNarrowRatio = 3f;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txCodigoBarras).Text = "160372";
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)512;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		imLogoEmpresa.Image = (Image)componentResourceManager.GetObject("imLogoEmpresa.Image");
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(42.05444f, 61.52101f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(395.9375f, 87.99999f);
		imLogoEmpresa.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoEmpresa).StylePriority.UseBorders = false;
		((XRControl)imLogoEmpresa).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoEmpresa).StylePriority.UsePadding = false;
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 8f);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(513.1216f, 211.1876f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(255.388f, 41.99997f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "EMISSÃO:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)64;
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 8f);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(42.05444f, 312.5209f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(126.2521f, 41.99994f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "DESCR.:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 8f, FontStyle.Bold);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(42.05444f, 261.8542f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(100.5604f, 41.99997f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "CÓD:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 8f, FontStyle.Bold);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(653.3505f, 261.8542f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(115.1591f, 41.99998f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "QTDE:";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)64;
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 8f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(42.05444f, 211.1876f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(126.2521f, 41.99997f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "Nº NF:";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)16;
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCliente).LocationFloat = new PointFloat(42.05444f, 160.521f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(945.3726f, 41.99995f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 9f);
		((XRControl)txData).LocationFloat = new PointFloat(787.2927f, 211.1876f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(183.0799f, 41.99998f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).Text = "15/05/2016";
		((XRControl)txData).TextAlignment = (TextAlignment)16;
		((XRControl)txDescricao).Borders = (BorderSide)0;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Arial", 9f);
		((XRControl)txDescricao).LocationFloat = new PointFloat(170.3065f, 312.5209f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(802.066f, 115.8853f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as dDDD DD DDDDD DDDDDDDDDDD DDDDDDDDDDD DDDEA SS DD";
		((XRControl)txDescricao).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(168.3065f, 261.8542f);
		((XRControl)txCodigoCliente).Name = "txCodigoCliente";
		((XRControl)txCodigoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoCliente).SizeF = new SizeF(478.4606f, 41.99998f);
		((XRControl)txCodigoCliente).StylePriority.UseBorders = false;
		((XRControl)txCodigoCliente).StylePriority.UseFont = false;
		((XRControl)txCodigoCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoCliente).Text = "160791J";
		((XRControl)txCodigoCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(787.2927f, 261.8542f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(183.0798f, 41.99995f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).Text = "200";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)16;
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(168.3065f, 211.1876f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(251.0768f, 41.99997f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)16;
		((XRControl)PageFooter).Dpi = 254f;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)PageFooter).Visible = false;
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
		((XtraReport)this).Margins = new Margins(0, 7, 0, 0);
		((XtraReport)this).PageHeight = 500;
		((XtraReport)this).PageWidth = 1000;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "18.1";
		((ISupportInitialize)this).EndInit();
	}
}
