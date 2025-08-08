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

public class rptEtiqueta : XtraReport
{
	private bool _isQdeQuebrada = false;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

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

	private XRLabel xrLabel10;

	private XRLabel txPecaInterno;

	private XRPictureBox imLogoCliente;

	private XRLabel xrLabel8;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

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

	public rptEtiqueta()
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
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem.ToString();
		}
		else
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.Quantidade.ToString();
		}
		if (IsQdeQuebrada)
		{
			int num = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
			((XRControl)txQuantidade).Text = num.ToString();
		}
		((XRControl)txNotaFiscal).Text = ItemNotaFiscal.NotaFiscalRef.NumeroNotaFiscal.ToString("000000");
		int num2 = ItemNotaFiscal.Ordem + 1;
		((XRControl)txItemNota).Text = num2.ToString("00");
		((XRControl)txCodigoBarras).Text = ((XRControl)txNotaFiscal).Text + ((XRControl)txItemNota).Text;
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
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1089: Unknown result type (might be due to invalid IL or missing references)
		//IL_113b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1166: Unknown result type (might be due to invalid IL or missing references)
		//IL_121a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_130f: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_148c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1551: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1623: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1710: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1878: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a3: Unknown result type (might be due to invalid IL or missing references)
		Code39Generator val = new Code39Generator();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		imLogoCliente = new XRPictureBox();
		xrLabel10 = new XRLabel();
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
		xrLabel8 = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 984f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[26]
		{
			(XRControl)xrLabel8,
			(XRControl)imLogoCliente,
			(XRControl)xrLabel10,
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
		((XRControl)PageHeader).HeightF = 1000f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)imLogoCliente).Borders = (BorderSide)0;
		((XRControl)imLogoCliente).BorderWidth = 0f;
		((XRControl)imLogoCliente).Dpi = 254f;
		((XRControl)imLogoCliente).LocationFloat = new PointFloat(423f, 37f);
		((XRControl)imLogoCliente).Name = "imLogoCliente";
		((XRControl)imLogoCliente).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoCliente).SizeF = new SizeF(254f, 64f);
		imLogoCliente.Sizing = (ImageSizeMode)1;
		((XRControl)imLogoCliente).StylePriority.UseBorders = false;
		((XRControl)imLogoCliente).StylePriority.UseBorderWidth = false;
		((XRControl)imLogoCliente).StylePriority.UsePadding = false;
		((XRControl)xrLabel10).Borders = (BorderSide)0;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(312f, 900f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(21f, 64f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).Text = "/";
		((XRControl)txPecaInterno).Borders = (BorderSide)0;
		((XRControl)txPecaInterno).CanGrow = false;
		((XRControl)txPecaInterno).Dpi = 254f;
		((XRControl)txPecaInterno).Font = new Font("Arial", 22f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txPecaInterno).LocationFloat = new PointFloat(339f, 875.5209f);
		((XRControl)txPecaInterno).Name = "txPecaInterno";
		((XRControl)txPecaInterno).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecaInterno).SizeF = new SizeF(265f, 88.47913f);
		((XRControl)txPecaInterno).StylePriority.UseBorders = false;
		((XRControl)txPecaInterno).StylePriority.UseFont = false;
		((XRControl)txPecaInterno).StylePriority.UseTextAlignment = false;
		((XRControl)txPecaInterno).Text = "5432";
		((XRControl)txPecaInterno).TextAlignment = (TextAlignment)256;
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(212f, 900f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(21f, 64f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "/";
		txCodigoBarras.Alignment = (TextAlignment)2;
		txCodigoBarras.BarCodeOrientation = (BarCodeOrientation)3;
		((XRControl)txCodigoBarras).Borders = (BorderSide)0;
		((XRControl)txCodigoBarras).Dpi = 254f;
		((XRControl)txCodigoBarras).LocationFloat = new PointFloat(508f, 201f);
		((XRControl)txCodigoBarras).Name = "txCodigoBarras";
		((XRControl)txCodigoBarras).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txCodigoBarras).SizeF = new SizeF(169f, 547.0209f);
		((XRControl)txCodigoBarras).StylePriority.UseBorders = false;
		((XRControl)txCodigoBarras).StylePriority.UseTextAlignment = false;
		val.WideNarrowRatio = 3f;
		txCodigoBarras.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txCodigoBarras).Text = "00543201";
		((XRControl)txCodigoBarras).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).LocationFloat = new PointFloat(32f, 109f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).Text = "Cliente";
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).LocationFloat = new PointFloat(32f, 209f);
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
		((XRControl)xrLabel4).LocationFloat = new PointFloat(32f, 423f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).Text = "Peça (Descrição)";
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).LocationFloat = new PointFloat(32f, 646f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).Text = "Código Peça";
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).LocationFloat = new PointFloat(32f, 751f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).Text = "Quantidade";
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).LocationFloat = new PointFloat(32f, 857f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).Text = "No Doc. Fiscal";
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCliente).LocationFloat = new PointFloat(32f, 152f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(593f, 42f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txEmpresa).Borders = (BorderSide)0;
		((XRControl)txEmpresa).CanGrow = false;
		((XRControl)txEmpresa).Dpi = 254f;
		((XRControl)txEmpresa).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txEmpresa).LocationFloat = new PointFloat(32f, 251f);
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
		((XRControl)txDescricao).LocationFloat = new PointFloat(32f, 466f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(466f, 159f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as";
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(32f, 688f);
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
		((XRControl)txQuantidade).LocationFloat = new PointFloat(31.99998f, 794f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(254f, 42f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).Text = "200";
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(32f, 900f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(180f, 64f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)1;
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
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(32f, 37f);
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
		((XRControl)txItemNota).Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txItemNota).LocationFloat = new PointFloat(241f, 900f);
		((XRControl)txItemNota).Name = "txItemNota";
		((XRControl)txItemNota).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItemNota).SizeF = new SizeF(66f, 64f);
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
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).LocationFloat = new PointFloat(339f, 833.5208f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel8).StylePriority.UseBorders = false;
		((XRControl)xrLabel8).Text = "Peça";
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
