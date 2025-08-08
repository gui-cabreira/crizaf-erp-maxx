using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiqueta100 : XtraReport
{
	private bool _isQdeQuebrada = false;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private XRLabel txCliente;

	private XRLabel txNotaFiscal;

	private XRLabel txDescricao;

	private XRLabel txData;

	private XRLine xrLine1;

	private XRLine xrLine3;

	private XRPictureBox imLogoEmpresa;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel txNroPedido;

	private XRLine xrLine4;

	private XRLabel txTelefoneEmpresa;

	private XRLabel txNomeEmpresa;

	private XRLine xrLine6;

	private XRLine xrLine8;

	private XRLine xrLine5;

	private XRLine xrLine2;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel lbCliente;

	private XRLabel txCodPeca;

	private XRLabel xrLabel5;

	private XRLabel xrLabel6;

	private XRLabel txQuantidade;

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

	public rptEtiqueta100()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		if (ItemNotaFiscal != null && ItemNotaFiscal.NotaFiscalRef != null && ItemNotaFiscal.NotaFiscalRef.Entidade != null)
		{
			((XRControl)txNomeEmpresa).Text = emitente.NomeFantasia;
			((XRControl)txTelefoneEmpresa).Text = emitente.Telefone;
			((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
			imLogoEmpresa.Image = emitente.Logo;
			((XRControl)txData).Text = ItemNotaFiscal.NotaFiscalRef.DataEmissao.ToShortDateString();
			((XRControl)txDescricao).Text = ItemNotaFiscal.DescricaoProduto;
			((XRControl)txCodPeca).Text = ItemNotaFiscal.CodigoProduto;
			((XRControl)txNotaFiscal).Text = string.Format("{0}/{1}", ItemNotaFiscal.CodigoNotaFiscal, ItemNotaFiscal.Ordem.ToString("00"));
			if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
			{
				((XRControl)txNroPedido).Text = ItemNotaFiscal.FichaExpedicaoItemRef.FichaExpedicao.CodigoProjeto.ToString();
			}
			((XRControl)txQuantidade).Text = ItemNotaFiscal.PecasPorEtiqueta.ToString();
			if (IsQdeQuebrada)
			{
				int num = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				((XRControl)txQuantidade).Text = num.ToString();
			}
		}
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
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_0992: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_100f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1390: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_148a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1580: Unknown result type (might be due to invalid IL or missing references)
		//IL_1638: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_178a: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b5: Unknown result type (might be due to invalid IL or missing references)
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel6 = new XRLabel();
		txQuantidade = new XRLabel();
		txCodPeca = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		lbCliente = new XRLabel();
		xrLine2 = new XRLine();
		xrLine6 = new XRLine();
		xrLine8 = new XRLine();
		xrLine5 = new XRLine();
		txTelefoneEmpresa = new XRLabel();
		txNomeEmpresa = new XRLabel();
		txNroPedido = new XRLabel();
		txCliente = new XRLabel();
		txData = new XRLabel();
		txDescricao = new XRLabel();
		txNotaFiscal = new XRLabel();
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
		((XRControl)Detail).Visible = false;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[24]
		{
			(XRControl)xrLabel6,
			(XRControl)txQuantidade,
			(XRControl)txCodPeca,
			(XRControl)xrLabel5,
			(XRControl)xrLabel4,
			(XRControl)xrLabel3,
			(XRControl)xrLabel2,
			(XRControl)xrLabel1,
			(XRControl)lbCliente,
			(XRControl)xrLine2,
			(XRControl)xrLine6,
			(XRControl)xrLine8,
			(XRControl)xrLine5,
			(XRControl)txTelefoneEmpresa,
			(XRControl)txNomeEmpresa,
			(XRControl)txNroPedido,
			(XRControl)txCliente,
			(XRControl)txData,
			(XRControl)txDescricao,
			(XRControl)txNotaFiscal,
			(XRControl)xrLine1,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)PageHeader).HeightF = 829.6458f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(678.0001f, 326.1249f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(96.64551f, 43.41989f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Qtd:";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Segoe UI", 11.25f);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(791.7916f, 326.1249f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(164.6249f, 43.41989f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)32;
		((XRControl)txCodPeca).Borders = (BorderSide)0;
		((XRControl)txCodPeca).CanGrow = false;
		((XRControl)txCodPeca).Dpi = 254f;
		((XRControl)txCodPeca).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodPeca).LocationFloat = new PointFloat(158.7082f, 326.1249f);
		((XRControl)txCodPeca).Name = "txCodPeca";
		((XRControl)txCodPeca).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodPeca).SizeF = new SizeF(490.7915f, 43.41998f);
		((XRControl)txCodPeca).StylePriority.UseBorders = false;
		((XRControl)txCodPeca).StylePriority.UseFont = false;
		((XRControl)txCodPeca).StylePriority.UseTextAlignment = false;
		((XRControl)txCodPeca).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(36.99985f, 326.1249f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(121.7084f, 43.41998f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Cód.:";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(37.00009f, 554.1422f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(278.4164f, 58.42004f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "N. Doc. Fiscal:";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(37.00001f, 492.7221f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(233.0623f, 58.42004f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Nr. Pedido:";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(37.00001f, 373.9374f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(121.7082f, 43.42001f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Desc.:";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(37.00001f, 243.4376f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(287.6456f, 58.42007f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Data Emissão:";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)lbCliente).Borders = (BorderSide)0;
		((XRControl)lbCliente).Dpi = 254f;
		((XRControl)lbCliente).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbCliente).LocationFloat = new PointFloat(37.00001f, 185.0175f);
		((XRControl)lbCliente).Name = "lbCliente";
		((XRControl)lbCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbCliente).SizeF = new SizeF(169.2918f, 58.42003f);
		((XRControl)lbCliente).StylePriority.UseBorders = false;
		((XRControl)lbCliente).StylePriority.UseFont = false;
		((XRControl)lbCliente).StylePriority.UseTextAlignment = false;
		((XRControl)lbCliente).Text = "Cliente:";
		((XRControl)lbCliente).TextAlignment = (TextAlignment)16;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 4f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(22.00004f, 639.7083f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(957.9999f, 18.9375f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine6).Borders = (BorderSide)0;
		((XRControl)xrLine6).Dpi = 254f;
		((XRControl)xrLine6).ForeColor = Color.Black;
		xrLine6.LineWidth = 4f;
		((XRControl)xrLine6).LocationFloat = new PointFloat(22.00012f, 475.0752f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).SizeF = new SizeF(955.9998f, 16.64688f);
		((XRControl)xrLine6).StylePriority.UseBorders = false;
		((XRControl)xrLine6).StylePriority.UseForeColor = false;
		((XRControl)xrLine8).Borders = (BorderSide)0;
		((XRControl)xrLine8).Dpi = 254f;
		((XRControl)xrLine8).ForeColor = Color.Black;
		xrLine8.LineWidth = 4f;
		((XRControl)xrLine8).LocationFloat = new PointFloat(25.00004f, 306.8577f);
		((XRControl)xrLine8).Name = "xrLine8";
		((XRControl)xrLine8).SizeF = new SizeF(952.9999f, 13.99997f);
		((XRControl)xrLine8).StylePriority.UseBorders = false;
		((XRControl)xrLine8).StylePriority.UseForeColor = false;
		((XRControl)xrLine5).Borders = (BorderSide)0;
		((XRControl)xrLine5).Dpi = 254f;
		((XRControl)xrLine5).ForeColor = Color.Black;
		xrLine5.LineWidth = 4f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(25.00012f, 166.8334f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(952.9999f, 11f);
		((XRControl)xrLine5).StylePriority.UseBorders = false;
		((XRControl)xrLine5).StylePriority.UseForeColor = false;
		((XRControl)txTelefoneEmpresa).Borders = (BorderSide)0;
		((XRControl)txTelefoneEmpresa).CanGrow = false;
		((XRControl)txTelefoneEmpresa).Dpi = 254f;
		((XRControl)txTelefoneEmpresa).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txTelefoneEmpresa).LocationFloat = new PointFloat(280.6456f, 103.1876f);
		((XRControl)txTelefoneEmpresa).Name = "txTelefoneEmpresa";
		((XRControl)txTelefoneEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTelefoneEmpresa).SizeF = new SizeF(675.7709f, 48.64585f);
		((XRControl)txTelefoneEmpresa).StylePriority.UseBorders = false;
		((XRControl)txTelefoneEmpresa).StylePriority.UseFont = false;
		((XRControl)txTelefoneEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txTelefoneEmpresa).TextAlignment = (TextAlignment)32;
		((XRControl)txNomeEmpresa).Borders = (BorderSide)0;
		((XRControl)txNomeEmpresa).CanGrow = false;
		((XRControl)txNomeEmpresa).Dpi = 254f;
		((XRControl)txNomeEmpresa).Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNomeEmpresa).LocationFloat = new PointFloat(280.6456f, 38.00001f);
		((XRControl)txNomeEmpresa).Name = "txNomeEmpresa";
		((XRControl)txNomeEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeEmpresa).SizeF = new SizeF(675.7709f, 65.18755f);
		((XRControl)txNomeEmpresa).StylePriority.UseBorders = false;
		((XRControl)txNomeEmpresa).StylePriority.UseFont = false;
		((XRControl)txNomeEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeEmpresa).TextAlignment = (TextAlignment)32;
		((XRControl)txNroPedido).Borders = (BorderSide)0;
		((XRControl)txNroPedido).CanGrow = false;
		((XRControl)txNroPedido).Dpi = 254f;
		((XRControl)txNroPedido).Font = new Font("Segoe UI", 11.25f);
		((XRControl)txNroPedido).LocationFloat = new PointFloat(270.0623f, 492.7221f);
		((XRControl)txNroPedido).Name = "txNroPedido";
		((XRControl)txNroPedido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNroPedido).SizeF = new SizeF(302.2082f, 58.42004f);
		((XRControl)txNroPedido).StylePriority.UseBorders = false;
		((XRControl)txNroPedido).StylePriority.UseFont = false;
		((XRControl)txNroPedido).StylePriority.UseTextAlignment = false;
		((XRControl)txNroPedido).TextAlignment = (TextAlignment)16;
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Segoe UI", 11.25f);
		((XRControl)txCliente).LocationFloat = new PointFloat(206.2917f, 185.0175f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(750.1248f, 58.42001f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCliente).TextAlignment = (TextAlignment)16;
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Segoe UI", 11.25f);
		((XRControl)txData).LocationFloat = new PointFloat(324.6456f, 243.4376f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(449.9999f, 58.42007f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).TextAlignment = (TextAlignment)16;
		((XRControl)txDescricao).Borders = (BorderSide)0;
		((XRControl)txDescricao).CanGrow = false;
		((XRControl)txDescricao).Dpi = 254f;
		((XRControl)txDescricao).Font = new Font("Segoe UI", 11.25f);
		((XRControl)txDescricao).LocationFloat = new PointFloat(158.7082f, 373.9374f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(797.7082f, 100.2708f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricao).TextAlignment = (TextAlignment)1;
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(316.4165f, 554.1422f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(256.854f, 58.42017f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)16;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 4f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(20.00004f, 13f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(960.9999f, 17.64583f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 4f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(18.00004f, 16.00005f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 642.6458f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 4f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(972f, 15.99999f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(11f, 623.7083f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(36.99985f, 38.00001f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(233.0624f, 113.8334f);
		imLogoEmpresa.Sizing = (ImageSizeMode)4;
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
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 700;
		((XtraReport)this).PageWidth = 1003;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).ShowPrintMarginsWarning = false;
		((XtraReport)this).ShowPrintStatusDialog = false;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "15.2";
		((ISupportInitialize)this).EndInit();
	}
}
