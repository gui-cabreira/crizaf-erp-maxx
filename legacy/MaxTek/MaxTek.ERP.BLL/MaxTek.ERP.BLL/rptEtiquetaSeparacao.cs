using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiquetaSeparacao : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRLine xrLine4;

	private XRLine xrLine3;

	private XRPictureBox imLogoEmpresa;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel1;

	public rptEtiquetaSeparacao()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade sociedade = ModuloParametros.ObterSociedade(1);
		imLogoEmpresa.Image = sociedade.Logo;
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
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
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
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel1 = new XRLabel();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		imLogoEmpresa = new XRPictureBox();
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
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrLabel1,
			(XRControl)xrLine1,
			(XRControl)xrLine2,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 1000f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 22f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(50.27083f, 539.6442f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(608.7917f, 151.0241f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Separação";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)32;
		((XRControl)xrLine1).Borders = (BorderSide)0;
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
		((XRControl)xrLine2).LocationFloat = new PointFloat(0f, 984f);
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
		((XRControl)xrLine3).LocationFloat = new PointFloat(0f, 11f);
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
		((XRControl)imLogoEmpresa).Borders = (BorderSide)15;
		((XRControl)imLogoEmpresa).BorderWidth = 2f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(39.93748f, 224.8542f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(619.125f, 183.0625f);
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
		((XtraReport)this).Version = "11.2";
		((ISupportInitialize)this).EndInit();
	}
}
