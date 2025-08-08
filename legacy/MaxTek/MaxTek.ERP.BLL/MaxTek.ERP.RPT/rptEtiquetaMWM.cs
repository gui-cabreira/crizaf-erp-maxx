using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.RPT;

public class rptEtiquetaMWM : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRBarCode cbCodigoPeca;

	private XRLabel xrLabel1;

	private XRLine xrLine1;

	private XRLine xrLine2;

	private XRLine xrLine3;

	private XRLine xrLine4;

	private XRLine xrLine5;

	private XRLine xrLine6;

	private XRLine xrLine7;

	private XRLabel xrLabel2;

	private XRLabel xrLabel3;

	private XRLabel xrLabel4;

	private XRLabel xrLabel5;

	private XRLabel txNomeFornecedor;

	private XRLabel txDataEntrega;

	private XRLabel txCodigoPeca;

	private XRLabel txDescricao;

	private XRLabel xrLabel7;

	private XRBarCode cdQuantidade;

	private XRLabel txQuantidade;

	private XRLabel xrLabel9;

	private XRLabel xrLabel10;

	private XRBarCode cbLote;

	private XRLabel txLote;

	private XRLabel xrLabel12;

	private XRLabel txID;

	private XRBarCode cbID;

	public string CodigoPeca { get; set; }

	public string DescricaoPeca { get; set; }

	public string CodigoNomeFornecedor { get; set; }

	public string Quantidade { get; set; }

	public string Data { get; set; }

	public string CodigoLote { get; set; }

	public string CodigoID { get; set; }

	public rptEtiquetaMWM()
	{
		InitializeComponent();
	}

	private void rptEtiquetaWMW_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)txCodigoPeca).Text = CodigoPeca;
		((XRControl)txDescricao).Text = DescricaoPeca;
		((XRControl)cbCodigoPeca).Text = CodigoPeca;
		((XRControl)txDataEntrega).Text = Data;
		((XRControl)txQuantidade).Text = Quantidade;
		((XRControl)cdQuantidade).Text = Quantidade;
		((XRControl)txNomeFornecedor).Text = CodigoNomeFornecedor;
		((XRControl)txLote).Text = CodigoLote;
		((XRControl)cbLote).Text = CodigoLote;
		((XRControl)txID).Text = CodigoID;
		((XRControl)cbID).Text = CodigoID;
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1011: Unknown result type (might be due to invalid IL or missing references)
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1123: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1210: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13de: Unknown result type (might be due to invalid IL or missing references)
		//IL_1487: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1573: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_165f: Unknown result type (might be due to invalid IL or missing references)
		//IL_168a: Unknown result type (might be due to invalid IL or missing references)
		//IL_172d: Unknown result type (might be due to invalid IL or missing references)
		//IL_176b: Unknown result type (might be due to invalid IL or missing references)
		//IL_180a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1864: Unknown result type (might be due to invalid IL or missing references)
		Code39Generator val = new Code39Generator();
		Code39Generator val2 = new Code39Generator();
		Code39Generator val3 = new Code39Generator();
		Code39Generator val4 = new Code39Generator();
		Detail = new DetailBand();
		cbCodigoPeca = new XRBarCode();
		xrLabel1 = new XRLabel();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		xrLine5 = new XRLine();
		xrLine6 = new XRLine();
		xrLine7 = new XRLine();
		xrLabel2 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel5 = new XRLabel();
		txNomeFornecedor = new XRLabel();
		txDataEntrega = new XRLabel();
		txCodigoPeca = new XRLabel();
		txDescricao = new XRLabel();
		xrLabel7 = new XRLabel();
		cdQuantidade = new XRBarCode();
		txQuantidade = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel10 = new XRLabel();
		cbLote = new XRBarCode();
		txLote = new XRLabel();
		xrLabel12 = new XRLabel();
		txID = new XRLabel();
		cbID = new XRBarCode();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[27]
		{
			(XRControl)cbCodigoPeca,
			(XRControl)xrLabel1,
			(XRControl)xrLine1,
			(XRControl)xrLine2,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)xrLine5,
			(XRControl)xrLine6,
			(XRControl)xrLine7,
			(XRControl)xrLabel2,
			(XRControl)xrLabel3,
			(XRControl)xrLabel4,
			(XRControl)xrLabel5,
			(XRControl)txNomeFornecedor,
			(XRControl)txDataEntrega,
			(XRControl)txCodigoPeca,
			(XRControl)txDescricao,
			(XRControl)xrLabel7,
			(XRControl)cdQuantidade,
			(XRControl)txQuantidade,
			(XRControl)xrLabel9,
			(XRControl)xrLabel10,
			(XRControl)cbLote,
			(XRControl)txLote,
			(XRControl)xrLabel12,
			(XRControl)txID,
			(XRControl)cbID
		});
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 784.5114f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		cbCodigoPeca.AutoModule = true;
		((XRControl)cbCodigoPeca).Dpi = 254f;
		((XRControl)cbCodigoPeca).LocationFloat = new PointFloat(150.7339f, 201.821f);
		cbCodigoPeca.Module = 3f;
		((XRControl)cbCodigoPeca).Name = "cbCodigoPeca";
		((XRControl)cbCodigoPeca).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		cbCodigoPeca.ShowText = false;
		((XRControl)cbCodigoPeca).SizeF = new SizeF(496.4543f, 71.12799f);
		val.WideNarrowRatio = 3f;
		cbCodigoPeca.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)cbCodigoPeca).Text = "9225009060355";
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(24.99999f, 24.99999f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(542.7277f, 28.94906f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "MWM INTERNATIONAL MOTORES";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel1).WordWrap = false;
		((XRControl)xrLine1).Dpi = 254f;
		xrLine1.LineWidth = 3f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(24.99999f, 59.29209f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine2).Dpi = 254f;
		xrLine2.LineWidth = 3f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(25f, 321.5076f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(976.6269f, 6.551147f);
		((XRControl)xrLine3).Dpi = 254f;
		xrLine3.LineWidth = 3f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(25f, 707.2299f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine4).Dpi = 254f;
		xrLine4.LineWidth = 3f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(25f, 567.7313f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine5).Dpi = 254f;
		xrLine5.LineWidth = 3f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(25f, 422.2343f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(976.6269f, 6.551163f);
		((XRControl)xrLine6).Dpi = 254f;
		xrLine6.LineDirection = (LineDirection)3;
		xrLine6.LineWidth = 3f;
		((XRControl)xrLine6).LocationFloat = new PointFloat(20f, 59.29209f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).SizeF = new SizeF(5f, 654.4889f);
		((XRControl)xrLine7).Dpi = 254f;
		xrLine7.LineDirection = (LineDirection)3;
		xrLine7.LineWidth = 3f;
		((XRControl)xrLine7).LocationFloat = new PointFloat(1001.627f, 59.29209f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(5f, 654.4889f);
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(863.2402f, 24.99999f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(138.3867f, 28.94906f);
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "V.2.3.4";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)1024;
		((XRControl)xrLabel2).WordWrap = false;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(41.81815f, 76.01704f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(89.74271f, 66.67181f);
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Part:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel3).WordWrap = false;
		((XRControl)xrLabel4).CanGrow = false;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(41.818f, 272.9489f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(108.9157f, 48.55867f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Supplier:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel4).WordWrap = false;
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(682.5706f, 272.9489f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(108.9158f, 48.55867f);
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Date:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel5).WordWrap = false;
		((XRControl)txNomeFornecedor).CanGrow = false;
		((XRControl)txNomeFornecedor).Dpi = 254f;
		((XRControl)txNomeFornecedor).Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNomeFornecedor).LocationFloat = new PointFloat(150.7337f, 272.9489f);
		((XRControl)txNomeFornecedor).Name = "txNomeFornecedor";
		((XRControl)txNomeFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeFornecedor).SizeF = new SizeF(531.837f, 48.55867f);
		((XRControl)txNomeFornecedor).StylePriority.UseFont = false;
		((XRControl)txNomeFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeFornecedor).Text = "Supplier:";
		((XRControl)txNomeFornecedor).TextAlignment = (TextAlignment)1;
		((XRControl)txNomeFornecedor).WordWrap = false;
		((XRControl)txDataEntrega).CanGrow = false;
		((XRControl)txDataEntrega).Dpi = 254f;
		((XRControl)txDataEntrega).Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txDataEntrega).LocationFloat = new PointFloat(791.4866f, 272.9489f);
		((XRControl)txDataEntrega).Name = "txDataEntrega";
		((XRControl)txDataEntrega).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDataEntrega).SizeF = new SizeF(189.0766f, 48.55867f);
		((XRControl)txDataEntrega).StylePriority.UseFont = false;
		((XRControl)txDataEntrega).StylePriority.UseTextAlignment = false;
		((XRControl)txDataEntrega).Text = "Date:";
		((XRControl)txDataEntrega).TextAlignment = (TextAlignment)1;
		((XRControl)txDataEntrega).WordWrap = false;
		((XRControl)txCodigoPeca).CanGrow = false;
		((XRControl)txCodigoPeca).Dpi = 254f;
		((XRControl)txCodigoPeca).Font = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoPeca).LocationFloat = new PointFloat(150.7339f, 76.01704f);
		((XRControl)txCodigoPeca).Name = "txCodigoPeca";
		((XRControl)txCodigoPeca).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoPeca).SizeF = new SizeF(829.8295f, 80.43251f);
		((XRControl)txCodigoPeca).StylePriority.UseFont = false;
		((XRControl)txCodigoPeca).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoPeca).Text = "9225009060355";
		((XRControl)txCodigoPeca).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoPeca).WordWrap = false;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txDescricao).LocationFloat = new PointFloat(150.7339f, 156.4496f);
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(829.8292f, 45.37141f);
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricao).Text = "TUBO";
		((XRControl)txDescricao).TextAlignment = (TextAlignment)1;
		((XRControl)txDescricao).WordWrap = false;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(41.818f, 334.0587f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(66.47763f, 49.47708f);
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "Qty:";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel7).WordWrap = false;
		cdQuantidade.AutoModule = true;
		((XRControl)cdQuantidade).Dpi = 254f;
		((XRControl)cdQuantidade).LocationFloat = new PointFloat(150.7337f, 334.0587f);
		cdQuantidade.Module = 3f;
		((XRControl)cdQuantidade).Name = "cdQuantidade";
		((XRControl)cdQuantidade).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		cdQuantidade.ShowText = false;
		((XRControl)cdQuantidade).SizeF = new SizeF(280.9109f, 83.17557f);
		val2.WideNarrowRatio = 3f;
		cdQuantidade.Symbology = (BarCodeGeneratorBase)(object)val2;
		((XRControl)cdQuantidade).Text = "30";
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(654.813f, 334.0587f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(136.6735f, 83.1756f);
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).Text = "30";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).WordWrap = false;
		((XRControl)xrLabel9).CanGrow = false;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 16f, FontStyle.Italic, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(843.8896f, 334.0587f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(136.6735f, 83.1756f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "PCS";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel9).WordWrap = false;
		((XRControl)xrLabel10).CanGrow = false;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(41.81815f, 442.7854f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(66.47762f, 42.6344f);
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "Lot:";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel10).WordWrap = false;
		cbLote.AutoModule = true;
		((XRControl)cbLote).Dpi = 254f;
		((XRControl)cbLote).LocationFloat = new PointFloat(150.7339f, 486.7885f);
		cbLote.Module = 2.5f;
		((XRControl)cbLote).Name = "cbLote";
		((XRControl)cbLote).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		cbLote.ShowText = false;
		((XRControl)cbLote).SizeF = new SizeF(531.8368f, 64.6178f);
		val3.WideNarrowRatio = 3f;
		cbLote.Symbology = (BarCodeGeneratorBase)(object)val3;
		((XRControl)cbLote).Text = "219/0000001";
		((XRControl)txLote).CanGrow = false;
		((XRControl)txLote).Dpi = 254f;
		((XRControl)txLote).Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txLote).LocationFloat = new PointFloat(150.7339f, 442.7854f);
		((XRControl)txLote).Name = "txLote";
		((XRControl)txLote).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txLote).SizeF = new SizeF(450.2439f, 42.6344f);
		((XRControl)txLote).StylePriority.UseFont = false;
		((XRControl)txLote).StylePriority.UseTextAlignment = false;
		((XRControl)txLote).Text = "219/0000001";
		((XRControl)txLote).TextAlignment = (TextAlignment)1;
		((XRControl)txLote).WordWrap = false;
		((XRControl)xrLabel12).CanGrow = false;
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(41.818f, 584.2824f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(66.47763f, 45.37146f);
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel12).Text = "ID:";
		((XRControl)xrLabel12).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel12).WordWrap = false;
		((XRControl)txID).CanGrow = false;
		((XRControl)txID).Dpi = 254f;
		((XRControl)txID).Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txID).LocationFloat = new PointFloat(150.7337f, 584.2824f);
		((XRControl)txID).Name = "txID";
		((XRControl)txID).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txID).SizeF = new SizeF(829.8295f, 48.1087f);
		((XRControl)txID).StylePriority.UseFont = false;
		((XRControl)txID).StylePriority.UseTextAlignment = false;
		((XRControl)txID).Text = "140080001810160004";
		((XRControl)txID).TextAlignment = (TextAlignment)1;
		((XRControl)txID).WordWrap = false;
		cbID.AutoModule = true;
		((XRControl)cbID).Dpi = 254f;
		((XRControl)cbID).LocationFloat = new PointFloat(150.7337f, 632.3912f);
		cbID.Module = 2.5f;
		((XRControl)cbID).Name = "cbID";
		((XRControl)cbID).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		cbID.ShowText = false;
		((XRControl)cbID).SizeF = new SizeF(726.642f, 58.12189f);
		val4.WideNarrowRatio = 3f;
		cbID.Symbology = (BarCodeGeneratorBase)(object)val4;
		((XRControl)cbID).Text = "140080001810160004";
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
