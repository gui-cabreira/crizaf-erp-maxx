using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.RPT;

public class rptEtiquetaScania : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRLine xrLine1;

	private XRLine xrLine2;

	private XRLine xrLine4;

	private XRLine xrLine5;

	private XRLine xrLine7;

	private XRLabel xrLabel8;

	private XRLabel xrLabel9;

	private XRLabel xrLabel7;

	private XRLabel xrLabel2;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel1;

	private XRLabel xrLabel6;

	private XRLabel txPartNumber;

	private XRLabel txCaixas;

	private XRLabel txQde;

	private XRLabel txPeso;

	private XRLabel txPartDescription;

	private XRLabel txFornecedor;

	private XRLabel txData;

	private XRLabel xrLabel10;

	public string CodigoPeca { get; set; }

	public string DescricaoPeca { get; set; }

	public string CodigoNomeFornecedor { get; set; }

	public string Quantidade { get; set; }

	public string Data { get; set; }

	public string Caixas { get; set; }

	public string Peso { get; set; }

	public rptEtiquetaScania()
	{
		InitializeComponent();
	}

	private void rptEtiquetaWMW_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)txPartNumber).Text = CodigoPeca;
		((XRControl)txPartDescription).Text = DescricaoPeca;
		((XRControl)txData).Text = Data;
		((XRControl)txQde).Text = Quantidade;
		((XRControl)txFornecedor).Text = CodigoNomeFornecedor;
		((XRControl)txPeso).Text = Peso;
		((XRControl)txCaixas).Text = Caixas;
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
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ede: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_127a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1367: Unknown result type (might be due to invalid IL or missing references)
		//IL_1392: Unknown result type (might be due to invalid IL or missing references)
		//IL_1454: Unknown result type (might be due to invalid IL or missing references)
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		Detail = new DetailBand();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		xrLine4 = new XRLine();
		xrLine5 = new XRLine();
		xrLine7 = new XRLine();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		xrLabel6 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel10 = new XRLabel();
		txData = new XRLabel();
		txFornecedor = new XRLabel();
		txPartDescription = new XRLabel();
		txPeso = new XRLabel();
		txQde = new XRLabel();
		txCaixas = new XRLabel();
		txPartNumber = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[22]
		{
			(XRControl)txPartNumber,
			(XRControl)txCaixas,
			(XRControl)txQde,
			(XRControl)txPeso,
			(XRControl)txPartDescription,
			(XRControl)txFornecedor,
			(XRControl)txData,
			(XRControl)xrLabel10,
			(XRControl)xrLabel8,
			(XRControl)xrLabel9,
			(XRControl)xrLabel7,
			(XRControl)xrLabel2,
			(XRControl)xrLabel5,
			(XRControl)xrLabel4,
			(XRControl)xrLabel3,
			(XRControl)xrLabel1,
			(XRControl)xrLabel6,
			(XRControl)xrLine1,
			(XRControl)xrLine2,
			(XRControl)xrLine4,
			(XRControl)xrLine5,
			(XRControl)xrLine7
		});
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 748.9295f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Dpi = 254f;
		xrLine1.LineWidth = 3f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(25f, 117.008f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine2).Dpi = 254f;
		xrLine2.LineWidth = 3f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(25f, 356.3808f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(976.6269f, 6.551147f);
		((XRControl)xrLine4).Dpi = 254f;
		xrLine4.LineWidth = 3f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(24.99999f, 616.8654f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine5).Dpi = 254f;
		xrLine5.LineWidth = 3f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(25f, 486.6231f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine7).Dpi = 254f;
		xrLine7.LineDirection = (LineDirection)3;
		xrLine7.LineWidth = 3f;
		((XRControl)xrLine7).LocationFloat = new PointFloat(517.1119f, 18f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(5.474121f, 602.0029f);
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 0f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)TopMargin).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)TopMargin).TextAlignment = (TextAlignment)1;
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 0f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)BottomMargin).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)BottomMargin).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel6).CanGrow = false;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(28.818f, 623.4166f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Observações / Remarks:";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel6).WordWrap = false;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(533.0159f, 493.1743f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Descrição / Description:";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel1).WordWrap = false;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(28.81799f, 493.1743f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Num. Caixa / No. of Boxes:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel3).WordWrap = false;
		((XRControl)xrLabel4).CanGrow = false;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(28.81801f, 362.932f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Quantidade / Quantity:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel4).WordWrap = false;
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(533.0159f, 362.932f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Fornecedor / Supplier:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel5).WordWrap = false;
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(28.81802f, 123.5592f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Peso Bruto / Gross Weigh (KG):";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel2).WordWrap = false;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(28.81802f, 25f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "Destinatário/ Receiver:";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel7).WordWrap = false;
		((XRControl)xrLabel8).CanGrow = false;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(533.0159f, 25f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel8).Text = "Data / Date:";
		((XRControl)xrLabel8).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel8).WordWrap = false;
		((XRControl)xrLabel9).CanGrow = false;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(533.0159f, 123.5592f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(386.7148f, 34.42316f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "Número da Peça / Part Number:";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel9).WordWrap = false;
		((XRControl)xrLabel10).CanGrow = false;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(28.81802f, 59.42317f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(488.2939f, 57.58483f);
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "SCANIA LATIN AMERICA";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel10).WordWrap = false;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txData).LocationFloat = new PointFloat(533.0159f, 59.42317f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(461.9842f, 57.58482f);
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).Text = "26/06/2015";
		((XRControl)txData).TextAlignment = (TextAlignment)32;
		((XRControl)txData).WordWrap = false;
		((XRControl)txFornecedor).CanGrow = false;
		((XRControl)txFornecedor).Dpi = 254f;
		((XRControl)txFornecedor).Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txFornecedor).LocationFloat = new PointFloat(533.0159f, 397.3551f);
		((XRControl)txFornecedor).Name = "txFornecedor";
		((XRControl)txFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txFornecedor).SizeF = new SizeF(461.9842f, 79.58482f);
		((XRControl)txFornecedor).StylePriority.UseFont = false;
		((XRControl)txFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txFornecedor).Text = "Metalurgica Cartec Ltda.";
		((XRControl)txFornecedor).TextAlignment = (TextAlignment)16;
		((XRControl)txFornecedor).WordWrap = false;
		((XRControl)txPartDescription).CanGrow = false;
		((XRControl)txPartDescription).Dpi = 254f;
		((XRControl)txPartDescription).Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPartDescription).LocationFloat = new PointFloat(533.0159f, 527.5974f);
		((XRControl)txPartDescription).Name = "txPartDescription";
		((XRControl)txPartDescription).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPartDescription).SizeF = new SizeF(461.9842f, 79.58482f);
		((XRControl)txPartDescription).StylePriority.UseFont = false;
		((XRControl)txPartDescription).StylePriority.UseTextAlignment = false;
		((XRControl)txPartDescription).Text = "PIPE PRESSURE";
		((XRControl)txPartDescription).TextAlignment = (TextAlignment)16;
		((XRControl)txPartDescription).WordWrap = false;
		((XRControl)txPeso).CanGrow = false;
		((XRControl)txPeso).Dpi = 254f;
		((XRControl)txPeso).Font = new Font("Arial", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPeso).LocationFloat = new PointFloat(28.81802f, 157.9823f);
		((XRControl)txPeso).Name = "txPeso";
		((XRControl)txPeso).Padding = new PaddingInfo(5, 30, 0, 0, 254f);
		((XRControl)txPeso).SizeF = new SizeF(488.2939f, 198.3985f);
		((XRControl)txPeso).StylePriority.UseFont = false;
		((XRControl)txPeso).StylePriority.UsePadding = false;
		((XRControl)txPeso).StylePriority.UseTextAlignment = false;
		((XRControl)txPeso).Text = "10.899";
		((XRControl)txPeso).TextAlignment = (TextAlignment)64;
		((XRControl)txPeso).WordWrap = false;
		((XRControl)txQde).CanGrow = false;
		((XRControl)txQde).Dpi = 254f;
		((XRControl)txQde).Font = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txQde).LocationFloat = new PointFloat(28.81802f, 397.3551f);
		((XRControl)txQde).Name = "txQde";
		((XRControl)txQde).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQde).SizeF = new SizeF(488.2939f, 89.26801f);
		((XRControl)txQde).StylePriority.UseFont = false;
		((XRControl)txQde).StylePriority.UseTextAlignment = false;
		((XRControl)txQde).Text = "150";
		((XRControl)txQde).TextAlignment = (TextAlignment)32;
		((XRControl)txQde).WordWrap = false;
		((XRControl)txCaixas).CanGrow = false;
		((XRControl)txCaixas).Dpi = 254f;
		((XRControl)txCaixas).Font = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCaixas).LocationFloat = new PointFloat(28.81802f, 527.5974f);
		((XRControl)txCaixas).Name = "txCaixas";
		((XRControl)txCaixas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCaixas).SizeF = new SizeF(488.2939f, 89.26801f);
		((XRControl)txCaixas).StylePriority.UseFont = false;
		((XRControl)txCaixas).StylePriority.UseTextAlignment = false;
		((XRControl)txCaixas).Text = "1/3";
		((XRControl)txCaixas).TextAlignment = (TextAlignment)32;
		((XRControl)txCaixas).WordWrap = false;
		((XRControl)txPartNumber).CanGrow = false;
		((XRControl)txPartNumber).Dpi = 254f;
		((XRControl)txPartNumber).Font = new Font("Arial", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPartNumber).LocationFloat = new PointFloat(533.0159f, 157.9823f);
		((XRControl)txPartNumber).Name = "txPartNumber";
		((XRControl)txPartNumber).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPartNumber).SizeF = new SizeF(461.9841f, 198.3985f);
		((XRControl)txPartNumber).StylePriority.UseFont = false;
		((XRControl)txPartNumber).StylePriority.UseTextAlignment = false;
		((XRControl)txPartNumber).Text = "1506341";
		((XRControl)txPartNumber).TextAlignment = (TextAlignment)32;
		((XRControl)txPartNumber).WordWrap = false;
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[3]
		{
			(Band)Detail,
			(Band)TopMargin,
			(Band)BottomMargin
		});
		((XtraReport)this).DisplayName = "EtiquetaWMW";
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 762;
		((XtraReport)this).PageWidth = 1016;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 5f;
		((XtraReport)this).Version = "19.2";
		((XRControl)this).BeforePrint += rptEtiquetaWMW_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
