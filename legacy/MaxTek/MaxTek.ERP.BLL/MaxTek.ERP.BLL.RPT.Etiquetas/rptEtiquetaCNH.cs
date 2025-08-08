using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.BLL.RPT.Etiquetas;

public class rptEtiquetaCNH : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private XRLabel lblCnpj;

	private XRLabel lblDataEmissao;

	private XRLabel xrLabel6;

	private XRLabel lblNumeroNota;

	private XRLabel xrLabel3;

	private XRLabel lblInscricaoEstadual;

	private XRLabel xrLabel5;

	private XRLabel lblCep;

	private XRLabel xrLabel4;

	private XRLabel lblUf;

	private XRLabel xrLabel2;

	private XRLabel lblCidade;

	private XRLabel lblBairro;

	private XRLabel lblNumero;

	private XRLabel xrLabel1;

	private XRLabel lblEndereco;

	private XRLabel lblEmpresa;

	public rptEtiquetaCNH()
	{
		InitializeComponent();
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
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_100a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1042: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_112f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_121c: Unknown result type (might be due to invalid IL or missing references)
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		PageFooter = new PageFooterBand();
		lblCnpj = new XRLabel();
		lblEmpresa = new XRLabel();
		lblEndereco = new XRLabel();
		xrLabel1 = new XRLabel();
		lblNumero = new XRLabel();
		lblBairro = new XRLabel();
		lblCidade = new XRLabel();
		xrLabel2 = new XRLabel();
		lblUf = new XRLabel();
		xrLabel4 = new XRLabel();
		lblCep = new XRLabel();
		xrLabel5 = new XRLabel();
		lblInscricaoEstadual = new XRLabel();
		xrLabel3 = new XRLabel();
		lblNumeroNota = new XRLabel();
		xrLabel6 = new XRLabel();
		lblDataEmissao = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 0f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 0f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 0f;
		Detail.HierarchyPrintOptions.Indent = 50.8f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[17]
		{
			(XRControl)lblDataEmissao,
			(XRControl)xrLabel6,
			(XRControl)lblNumeroNota,
			(XRControl)xrLabel3,
			(XRControl)lblInscricaoEstadual,
			(XRControl)xrLabel5,
			(XRControl)lblCep,
			(XRControl)xrLabel4,
			(XRControl)lblUf,
			(XRControl)xrLabel2,
			(XRControl)lblCidade,
			(XRControl)lblBairro,
			(XRControl)lblNumero,
			(XRControl)xrLabel1,
			(XRControl)lblEndereco,
			(XRControl)lblEmpresa,
			(XRControl)lblCnpj
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).HeightF = 425.9792f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageFooter).Dpi = 254f;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)lblCnpj).CanGrow = false;
		((XRControl)lblCnpj).Dpi = 254f;
		((XRControl)lblCnpj).Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblCnpj).LocationFloat = new PointFloat(11.77084f, 11.77084f);
		lblCnpj.Multiline = true;
		((XRControl)lblCnpj).Name = "lblCnpj";
		((XRControl)lblCnpj).Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		((XRControl)lblCnpj).SizeF = new SizeF(711.8378f, 58.42f);
		((XRControl)lblCnpj).StylePriority.UseFont = false;
		((XRControl)lblCnpj).StylePriority.UseTextAlignment = false;
		((XRControl)lblCnpj).Text = "CNPJ. 01.844.555/0026-30";
		((XRControl)lblCnpj).TextAlignment = (TextAlignment)16;
		((XRControl)lblEmpresa).CanGrow = false;
		((XRControl)lblEmpresa).Dpi = 254f;
		((XRControl)lblEmpresa).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblEmpresa).LocationFloat = new PointFloat(11.77084f, 82.83865f);
		lblEmpresa.Multiline = true;
		((XRControl)lblEmpresa).Name = "lblEmpresa";
		((XRControl)lblEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEmpresa).SizeF = new SizeF(711.8378f, 35.58609f);
		((XRControl)lblEmpresa).StylePriority.UseFont = false;
		((XRControl)lblEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)lblEmpresa).Text = "CNH INDUSTRIAL BRASIL LTDA.";
		((XRControl)lblEmpresa).TextAlignment = (TextAlignment)16;
		((XRControl)lblEndereco).CanGrow = false;
		((XRControl)lblEndereco).Dpi = 254f;
		((XRControl)lblEndereco).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblEndereco).LocationFloat = new PointFloat(11.77083f, 129.4416f);
		lblEndereco.Multiline = true;
		((XRControl)lblEndereco).Name = "lblEndereco";
		((XRControl)lblEndereco).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEndereco).SizeF = new SizeF(421.521f, 35.58611f);
		((XRControl)lblEndereco).StylePriority.UseFont = false;
		((XRControl)lblEndereco).StylePriority.UseTextAlignment = false;
		((XRControl)lblEndereco).Text = "AVENIDA JEROME CASE";
		((XRControl)lblEndereco).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(585.1846f, 129.4416f);
		xrLabel1.Multiline = true;
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(108.3705f, 35.58611f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Num.:";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)lblNumero).CanGrow = false;
		((XRControl)lblNumero).Dpi = 254f;
		((XRControl)lblNumero).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblNumero).LocationFloat = new PointFloat(693.5551f, 129.4416f);
		lblNumero.Multiline = true;
		((XRControl)lblNumero).Name = "lblNumero";
		((XRControl)lblNumero).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblNumero).SizeF = new SizeF(131.1752f, 35.58611f);
		((XRControl)lblNumero).StylePriority.UseFont = false;
		((XRControl)lblNumero).StylePriority.UseTextAlignment = false;
		((XRControl)lblNumero).Text = "1801";
		((XRControl)lblNumero).TextAlignment = (TextAlignment)16;
		((XRControl)lblBairro).CanGrow = false;
		((XRControl)lblBairro).Dpi = 254f;
		((XRControl)lblBairro).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblBairro).LocationFloat = new PointFloat(11.77084f, 179.3065f);
		lblBairro.Multiline = true;
		((XRControl)lblBairro).Name = "lblBairro";
		((XRControl)lblBairro).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblBairro).SizeF = new SizeF(421.521f, 35.58611f);
		((XRControl)lblBairro).StylePriority.UseFont = false;
		((XRControl)lblBairro).StylePriority.UseTextAlignment = false;
		((XRControl)lblBairro).Text = "EDEN";
		((XRControl)lblBairro).TextAlignment = (TextAlignment)16;
		((XRControl)lblCidade).CanGrow = false;
		((XRControl)lblCidade).Dpi = 254f;
		((XRControl)lblCidade).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblCidade).LocationFloat = new PointFloat(11.77083f, 227.5404f);
		lblCidade.Multiline = true;
		((XRControl)lblCidade).Name = "lblCidade";
		((XRControl)lblCidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblCidade).SizeF = new SizeF(421.521f, 35.58611f);
		((XRControl)lblCidade).StylePriority.UseFont = false;
		((XRControl)lblCidade).StylePriority.UseTextAlignment = false;
		((XRControl)lblCidade).Text = "SOROCABA";
		((XRControl)lblCidade).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(624.3284f, 227.5404f);
		xrLabel2.Multiline = true;
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(69.22659f, 35.58612f);
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "UF:";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)lblUf).CanGrow = false;
		((XRControl)lblUf).Dpi = 254f;
		((XRControl)lblUf).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblUf).LocationFloat = new PointFloat(693.555f, 227.5404f);
		lblUf.Multiline = true;
		((XRControl)lblUf).Name = "lblUf";
		((XRControl)lblUf).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblUf).SizeF = new SizeF(131.1752f, 35.58611f);
		((XRControl)lblUf).StylePriority.UseFont = false;
		((XRControl)lblUf).StylePriority.UseTextAlignment = false;
		((XRControl)lblUf).Text = "SP";
		((XRControl)lblUf).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel4).CanGrow = false;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(11.77083f, 275.7743f);
		xrLabel4.Multiline = true;
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(95.32246f, 35.58612f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "CEP:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)16;
		((XRControl)lblCep).CanGrow = false;
		((XRControl)lblCep).Dpi = 254f;
		((XRControl)lblCep).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblCep).LocationFloat = new PointFloat(107.0933f, 275.7743f);
		lblCep.Multiline = true;
		((XRControl)lblCep).Name = "lblCep";
		((XRControl)lblCep).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblCep).SizeF = new SizeF(326.1985f, 35.58609f);
		((XRControl)lblCep).StylePriority.UseFont = false;
		((XRControl)lblCep).StylePriority.UseTextAlignment = false;
		((XRControl)lblCep).Text = "18087-220";
		((XRControl)lblCep).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(11.77082f, 326.0393f);
		xrLabel5.Multiline = true;
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(59.44062f, 35.58612f);
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "IE:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)lblInscricaoEstadual).CanGrow = false;
		((XRControl)lblInscricaoEstadual).Dpi = 254f;
		((XRControl)lblInscricaoEstadual).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblInscricaoEstadual).LocationFloat = new PointFloat(71.21144f, 326.0393f);
		lblInscricaoEstadual.Multiline = true;
		((XRControl)lblInscricaoEstadual).Name = "lblInscricaoEstadual";
		((XRControl)lblInscricaoEstadual).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblInscricaoEstadual).SizeF = new SizeF(362.0804f, 35.58609f);
		((XRControl)lblInscricaoEstadual).StylePriority.UseFont = false;
		((XRControl)lblInscricaoEstadual).StylePriority.UseTextAlignment = false;
		((XRControl)lblInscricaoEstadual).Text = "798010159111";
		((XRControl)lblInscricaoEstadual).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(11.77082f, 376.2f);
		xrLabel3.Multiline = true;
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(242.1118f, 35.58612f);
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Num. da nota:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)16;
		((XRControl)lblNumeroNota).CanGrow = false;
		((XRControl)lblNumeroNota).Dpi = 254f;
		((XRControl)lblNumeroNota).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblNumeroNota).LocationFloat = new PointFloat(253.8827f, 376.2f);
		lblNumeroNota.Multiline = true;
		((XRControl)lblNumeroNota).Name = "lblNumeroNota";
		((XRControl)lblNumeroNota).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblNumeroNota).SizeF = new SizeF(179.4092f, 35.58609f);
		((XRControl)lblNumeroNota).StylePriority.UseFont = false;
		((XRControl)lblNumeroNota).StylePriority.UseTextAlignment = false;
		((XRControl)lblNumeroNota).Text = "160227";
		((XRControl)lblNumeroNota).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel6).CanGrow = false;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(467.753f, 376.2f);
		xrLabel6.Multiline = true;
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(167.0862f, 35.58612f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Emissao:";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)16;
		((XRControl)lblDataEmissao).CanGrow = false;
		((XRControl)lblDataEmissao).Dpi = 254f;
		((XRControl)lblDataEmissao).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblDataEmissao).LocationFloat = new PointFloat(634.8392f, 376.2f);
		lblDataEmissao.Multiline = true;
		((XRControl)lblDataEmissao).Name = "lblDataEmissao";
		((XRControl)lblDataEmissao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblDataEmissao).SizeF = new SizeF(189.891f, 35.58609f);
		((XRControl)lblDataEmissao).StylePriority.UseFont = false;
		((XRControl)lblDataEmissao).StylePriority.UseTextAlignment = false;
		((XRControl)lblDataEmissao).Text = "07/10/2020";
		((XRControl)lblDataEmissao).TextAlignment = (TextAlignment)16;
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[5]
		{
			(Band)TopMargin,
			(Band)BottomMargin,
			(Band)Detail,
			(Band)PageHeader,
			(Band)PageFooter
		});
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f);
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(0, 3, 0, 0);
		((XtraReport)this).PageHeight = 1172;
		((XtraReport)this).PageWidth = 842;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 5f;
		((XtraReport)this).Version = "19.2";
		((ISupportInitialize)this).EndInit();
	}
}
