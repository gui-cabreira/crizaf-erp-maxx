using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiquetaFord : XtraReport
{
	private bool _isQdeQuebrada = false;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLine xrLine12;

	private XRLine xrLine11;

	private XRLine xrLine10;

	private XRLine xrLine9;

	private XRLine xrLine8;

	private XRLine xrLine7;

	private XRLine xrLine6;

	private XRLabel txCodigoCompradorEdi;

	private XRLabel txCliente;

	private XRLabel txDoca;

	private XRLabel txCodigoInterno;

	private XRLabel xrLabel17;

	private XRLabel xrLabel16;

	private XRLabel xrLabel15;

	private XRLabel xrLabel14;

	private XRLabel txDescrciaoProduto;

	private XRLabel txCodigoPeca2;

	private XRLabel txNF;

	private XRBarCode txNF2;

	private XRLabel xrLabel11;

	private XRLabel xrLabel10;

	private XRLine xrLine5;

	private XRLine xrLine4;

	private XRLine xrLine3;

	private XRShape xrShape1;

	private XRBarCode txCodigoPeca;

	private XRLabel xrLabel8;

	private XRLabel xrLabel9;

	private XRLabel txData;

	private XRLabel xrLabel7;

	private XRLine xrLine2;

	private XRLabel txPeso;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRBarCode txEmbalagem;

	private XRLabel xrLabel4;

	private XRBarCode txQuantidade;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLine xrLine1;

	private XRBarCode txNomeFantasia;

	private XRLabel txCodigoVendedorEDI;

	private XRLabel xrLabel1;

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

	public rptEtiquetaFord()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		((XRControl)txData).Text = DateTime.Today.ToShortDateString();
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.NomeFantasia;
		((XRControl)txCodigoVendedorEDI).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoVendedorEDI;
		((XRControl)txNomeFantasia).Text = emitente.NomeFantasia;
		((XRControl)txCodigoCompradorEdi).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoCompradorEDI;
		((XRControl)txCodigoInterno).Text = ItemNotaFiscal.CodigoProduto;
		((XRControl)txDoca).Text = string.Empty;
		((XRControl)txNF).Text = ItemNotaFiscal.CodigoNotaFiscal.ToString();
		((XRControl)txNF2).Text = ItemNotaFiscal.CodigoNotaFiscal.ToString();
		((XRControl)txPeso).Text = string.Empty;
		((XRControl)txQuantidade).Text = string.Empty;
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa != null)
		{
			((XRControl)txCodigoPeca).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
			((XRControl)txCodigoPeca2).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
			((XRControl)txDescrciaoProduto).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
			((XRControl)txEmbalagem).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoEmbalagem;
			((XRControl)txDoca).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.PortaoEntrega;
		}
		else
		{
			((XRControl)txCodigoPeca).Text = string.Empty;
			((XRControl)txCodigoPeca2).Text = string.Empty;
			((XRControl)txDescrciaoProduto).Text = string.Empty;
			((XRControl)txEmbalagem).Text = string.Empty;
			((XRControl)txPeso).Text = string.Empty;
		}
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem.ToString();
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPeso).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem, 2).ToString();
			}
		}
		else
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.Quantidade.ToString();
		}
		if (IsQdeQuebrada)
		{
			int num = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
			((XRControl)txQuantidade).Text = num.ToString();
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPeso).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num, 2).ToString();
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1067: Unknown result type (might be due to invalid IL or missing references)
		//IL_1092: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1165: Unknown result type (might be due to invalid IL or missing references)
		//IL_1234: Unknown result type (might be due to invalid IL or missing references)
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_131f: Unknown result type (might be due to invalid IL or missing references)
		//IL_139a: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1537: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1786: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1846: Unknown result type (might be due to invalid IL or missing references)
		//IL_1871: Unknown result type (might be due to invalid IL or missing references)
		//IL_1906: Unknown result type (might be due to invalid IL or missing references)
		//IL_1931: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_201f: Unknown result type (might be due to invalid IL or missing references)
		//IL_204a: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_214d: Unknown result type (might be due to invalid IL or missing references)
		//IL_218b: Unknown result type (might be due to invalid IL or missing references)
		//IL_224d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2278: Unknown result type (might be due to invalid IL or missing references)
		//IL_232d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2358: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e3: Unknown result type (might be due to invalid IL or missing references)
		Code128Generator symbology = new Code128Generator();
		ShapePolygon shape = new ShapePolygon();
		Code128Generator symbology2 = new Code128Generator();
		Code128Generator symbology3 = new Code128Generator();
		Code128Generator symbology4 = new Code128Generator();
		Code128Generator symbology5 = new Code128Generator();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLine12 = new XRLine();
		xrLine11 = new XRLine();
		xrLine10 = new XRLine();
		xrLine9 = new XRLine();
		xrLine8 = new XRLine();
		xrLine7 = new XRLine();
		xrLine6 = new XRLine();
		txCodigoCompradorEdi = new XRLabel();
		txCliente = new XRLabel();
		txDoca = new XRLabel();
		txCodigoInterno = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel14 = new XRLabel();
		txDescrciaoProduto = new XRLabel();
		txCodigoPeca2 = new XRLabel();
		txNF = new XRLabel();
		txNF2 = new XRBarCode();
		xrLabel11 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLine5 = new XRLine();
		xrLine4 = new XRLine();
		xrLine3 = new XRLine();
		xrShape1 = new XRShape();
		txCodigoPeca = new XRBarCode();
		xrLabel8 = new XRLabel();
		xrLabel9 = new XRLabel();
		txData = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLine2 = new XRLine();
		txPeso = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		txEmbalagem = new XRBarCode();
		xrLabel4 = new XRLabel();
		txQuantidade = new XRBarCode();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLine1 = new XRLine();
		txNomeFantasia = new XRBarCode();
		txCodigoVendedorEDI = new XRLabel();
		xrLabel1 = new XRLabel();
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
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[43]
		{
			(XRControl)xrLine12,
			(XRControl)xrLine11,
			(XRControl)xrLine10,
			(XRControl)xrLine9,
			(XRControl)xrLine8,
			(XRControl)xrLine7,
			(XRControl)xrLine6,
			(XRControl)txCodigoCompradorEdi,
			(XRControl)txCliente,
			(XRControl)txDoca,
			(XRControl)txCodigoInterno,
			(XRControl)xrLabel17,
			(XRControl)xrLabel16,
			(XRControl)xrLabel15,
			(XRControl)xrLabel14,
			(XRControl)txDescrciaoProduto,
			(XRControl)txCodigoPeca2,
			(XRControl)txNF,
			(XRControl)txNF2,
			(XRControl)xrLabel11,
			(XRControl)xrLabel10,
			(XRControl)xrLine5,
			(XRControl)xrLine4,
			(XRControl)xrLine3,
			(XRControl)xrShape1,
			(XRControl)txCodigoPeca,
			(XRControl)xrLabel8,
			(XRControl)xrLabel9,
			(XRControl)txData,
			(XRControl)xrLabel7,
			(XRControl)xrLine2,
			(XRControl)txPeso,
			(XRControl)xrLabel6,
			(XRControl)xrLabel5,
			(XRControl)txEmbalagem,
			(XRControl)xrLabel4,
			(XRControl)txQuantidade,
			(XRControl)xrLabel3,
			(XRControl)xrLabel2,
			(XRControl)xrLine1,
			(XRControl)txNomeFantasia,
			(XRControl)txCodigoVendedorEDI,
			(XRControl)xrLabel1
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 1024f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLine12).Dpi = 254f;
		xrLine12.LineDirection = (LineDirection)3;
		((XRControl)xrLine12).LocationFloat = new PointFloat(1796f, 2.999997f);
		((XRControl)xrLine12).Name = "xrLine12";
		((XRControl)xrLine12).SizeF = new SizeF(14.87488f, 982.5458f);
		((XRControl)xrLine11).Dpi = 254f;
		xrLine11.LineDirection = (LineDirection)3;
		((XRControl)xrLine11).LocationFloat = new PointFloat(0f, 2.999997f);
		((XRControl)xrLine11).Name = "xrLine11";
		((XRControl)xrLine11).SizeF = new SizeF(14.87494f, 982.5458f);
		((XRControl)xrLine10).BorderWidth = 5f;
		((XRControl)xrLine10).Dpi = 254f;
		((XRControl)xrLine10).LocationFloat = new PointFloat(6.000034f, 3f);
		((XRControl)xrLine10).Name = "xrLine10";
		((XRControl)xrLine10).Padding = new PaddingInfo(0, 0, 3, 0, 254f);
		((XRControl)xrLine10).SizeF = new SizeF(1799f, 21.07379f);
		((XRControl)xrLine10).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine10).StylePriority.UsePadding = false;
		((XRControl)xrLine9).Dpi = 254f;
		xrLine9.LineDirection = (LineDirection)3;
		((XRControl)xrLine9).LocationFloat = new PointFloat(1535.75f, 792.6876f);
		((XRControl)xrLine9).Name = "xrLine9";
		((XRControl)xrLine9).SizeF = new SizeF(14.875f, 192.8582f);
		((XRControl)xrLine8).Dpi = 254f;
		xrLine8.LineDirection = (LineDirection)3;
		((XRControl)xrLine8).LocationFloat = new PointFloat(986.7917f, 792.6876f);
		((XRControl)xrLine8).Name = "xrLine8";
		((XRControl)xrLine8).SizeF = new SizeF(14.87494f, 192.8582f);
		((XRControl)xrLine7).Dpi = 254f;
		xrLine7.LineDirection = (LineDirection)3;
		((XRControl)xrLine7).LocationFloat = new PointFloat(768.2083f, 648.0309f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(14.87494f, 153.6036f);
		((XRControl)xrLine6).Dpi = 254f;
		xrLine6.LineDirection = (LineDirection)3;
		((XRControl)xrLine6).LocationFloat = new PointFloat(618.9791f, 192.6686f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).Padding = new PaddingInfo(0, 0, 8, 0, 254f);
		((XRControl)xrLine6).SizeF = new SizeF(14.87494f, 288.6922f);
		((XRControl)xrLine6).StylePriority.UsePadding = false;
		((XRControl)txCodigoCompradorEdi).CanGrow = false;
		((XRControl)txCodigoCompradorEdi).Dpi = 254f;
		((XRControl)txCodigoCompradorEdi).Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoCompradorEdi).LocationFloat = new PointFloat(1175.667f, 913.4734f);
		((XRControl)txCodigoCompradorEdi).Name = "txCodigoCompradorEdi";
		((XRControl)txCodigoCompradorEdi).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoCompradorEdi).SizeF = new SizeF(345.6661f, 66.146f);
		((XRControl)txCodigoCompradorEdi).StylePriority.UseFont = false;
		((XRControl)txCodigoCompradorEdi).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoCompradorEdi).Text = "FI05E";
		((XRControl)txCodigoCompradorEdi).TextAlignment = (TextAlignment)32;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txCliente).LocationFloat = new PointFloat(1001.667f, 853.6909f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(519.6665f, 59.78253f);
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).Text = "FORD SBC - TRUCKS";
		((XRControl)txDoca).CanGrow = false;
		((XRControl)txDoca).Dpi = 254f;
		((XRControl)txDoca).Font = new Font("Arial", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txDoca).LocationFloat = new PointFloat(1550.625f, 871.5702f);
		((XRControl)txDoca).Name = "txDoca";
		((XRControl)txDoca).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDoca).SizeF = new SizeF(231.375f, 90.17004f);
		((XRControl)txDoca).StylePriority.UseFont = false;
		((XRControl)txDoca).StylePriority.UseTextAlignment = false;
		((XRControl)txDoca).Text = "102";
		((XRControl)txDoca).TextAlignment = (TextAlignment)32;
		((XRControl)txCodigoInterno).CanGrow = false;
		((XRControl)txCodigoInterno).Dpi = 254f;
		((XRControl)txCodigoInterno).Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoInterno).LocationFloat = new PointFloat(374.75f, 916.5494f);
		((XRControl)txCodigoInterno).Name = "txCodigoInterno";
		((XRControl)txCodigoInterno).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoInterno).SizeF = new SizeF(547.1873f, 63.07007f);
		((XRControl)txCodigoInterno).StylePriority.UseFont = false;
		((XRControl)txCodigoInterno).Text = "772";
		((XRControl)xrLabel17).CanGrow = false;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(25.00001f, 937.1458f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(330.7291f, 41.90338f);
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).Text = "SERIAL NO(S)";
		((XRControl)xrLabel16).CanGrow = false;
		((XRControl)xrLabel16).Dpi = 254f;
		((XRControl)xrLabel16).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel16).LocationFloat = new PointFloat(1550.625f, 808.5001f);
		((XRControl)xrLabel16).Name = "xrLabel16";
		((XRControl)xrLabel16).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel16).SizeF = new SizeF(231.375f, 45.19086f);
		((XRControl)xrLabel16).StylePriority.UseFont = false;
		((XRControl)xrLabel16).Text = "DOCK CODE";
		((XRControl)xrLabel15).CanGrow = false;
		((XRControl)xrLabel15).Dpi = 254f;
		((XRControl)xrLabel15).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(1001.667f, 916.5494f);
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel15).SizeF = new SizeF(142.875f, 45.19086f);
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).Text = "CUST:";
		((XRControl)xrLabel14).CanGrow = false;
		((XRControl)xrLabel14).Dpi = 254f;
		((XRControl)xrLabel14).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel14).LocationFloat = new PointFloat(1001.667f, 808.5001f);
		((XRControl)xrLabel14).Name = "xrLabel14";
		((XRControl)xrLabel14).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel14).SizeF = new SizeF(108.4791f, 45.19086f);
		((XRControl)xrLabel14).StylePriority.UseFont = false;
		((XRControl)xrLabel14).Text = "TO:";
		((XRControl)txDescrciaoProduto).CanGrow = false;
		((XRControl)txDescrciaoProduto).Dpi = 254f;
		((XRControl)txDescrciaoProduto).Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txDescrciaoProduto).LocationFloat = new PointFloat(24.99999f, 871.5702f);
		((XRControl)txDescrciaoProduto).Name = "txDescrciaoProduto";
		((XRControl)txDescrciaoProduto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescrciaoProduto).SizeF = new SizeF(896.9374f, 41.90332f);
		((XRControl)txDescrciaoProduto).StylePriority.UseFont = false;
		((XRControl)txDescrciaoProduto).Text = "STUD&WSHR M6X11 HX PIL SPHRCL10";
		((XRControl)txCodigoPeca2).CanGrow = false;
		((XRControl)txCodigoPeca2).Dpi = 254f;
		((XRControl)txCodigoPeca2).Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoPeca2).LocationFloat = new PointFloat(25.00001f, 808.5001f);
		((XRControl)txCodigoPeca2).Name = "txCodigoPeca2";
		((XRControl)txCodigoPeca2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoPeca2).SizeF = new SizeF(896.9374f, 63.07013f);
		((XRControl)txCodigoPeca2).StylePriority.UseFont = false;
		((XRControl)txCodigoPeca2).Text = "W708785 S437";
		((XRControl)txNF).CanGrow = false;
		((XRControl)txNF).Dpi = 254f;
		((XRControl)txNF).Font = new Font("Arial", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNF).LocationFloat = new PointFloat(796.375f, 711.0342f);
		((XRControl)txNF).Name = "txNF";
		((XRControl)txNF).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNF).SizeF = new SizeF(296.3333f, 73.65332f);
		((XRControl)txNF).StylePriority.UseFont = false;
		((XRControl)txNF).Text = "26837";
		txNF2.AutoModule = true;
		((XRControl)txNF2).Dpi = 254f;
		((XRControl)txNF2).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNF2).LocationFloat = new PointFloat(1092.708f, 711.0342f);
		txNF2.Module = 5.08f;
		((XRControl)txNF2).Name = "txNF2";
		((XRControl)txNF2).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		txNF2.ShowText = false;
		((XRControl)txNF2).SizeF = new SizeF(662.5001f, 73.65338f);
		((XRControl)txNF2).StylePriority.UseFont = false;
		((XRControl)txNF2).StylePriority.UseTextAlignment = false;
		txNF2.Symbology = (BarCodeGeneratorBase)(object)symbology;
		((XRControl)txNF2).Text = "26837";
		((XRControl)txNF2).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel11).CanGrow = false;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(796.375f, 665.8434f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(724.9581f, 45.19086f);
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).Text = "DELIVERY DOC/ASN NUMBER";
		((XRControl)xrLabel10).CanGrow = false;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(24.99999f, 665.8434f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(251.3542f, 45.19086f);
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).Text = "STR LOC 1";
		((XRControl)xrLine5).BorderWidth = 8f;
		((XRControl)xrLine5).Dpi = 254f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(6.999989f, 979.6194f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).Padding = new PaddingInfo(0, 0, 1, 0, 254f);
		((XRControl)xrLine5).SizeF = new SizeF(1798f, 9.000061f);
		((XRControl)xrLine5).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine5).StylePriority.UsePadding = false;
		((XRControl)xrLine4).BorderWidth = 5f;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(6.999989f, 784.6876f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(1798f, 23.8125f);
		((XRControl)xrLine4).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine3).BorderWidth = 5f;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(6.000034f, 642.0309f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(1799f, 23.8125f);
		((XRControl)xrLine3).StylePriority.UseBorderWidth = false;
		xrShape1.Angle = 180;
		((XRControl)xrShape1).Dpi = 254f;
		((XRControl)xrShape1).LocationFloat = new PointFloat(1640.647f, 533.5518f);
		((XRControl)xrShape1).Name = "xrShape1";
		xrShape1.Shape = (ShapeBase)(object)shape;
		((XRControl)xrShape1).SizeF = new SizeF(114.5614f, 83.01062f);
		txCodigoPeca.AutoModule = true;
		((XRControl)txCodigoPeca).Dpi = 254f;
		((XRControl)txCodigoPeca).Font = new Font("Arial", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoPeca).LocationFloat = new PointFloat(189.3542f, 488.3609f);
		txCodigoPeca.Module = 5.08f;
		((XRControl)txCodigoPeca).Name = "txCodigoPeca";
		((XRControl)txCodigoPeca).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txCodigoPeca).SizeF = new SizeF(1408.625f, 153.67f);
		((XRControl)txCodigoPeca).StylePriority.UseFont = false;
		((XRControl)txCodigoPeca).StylePriority.UseTextAlignment = false;
		txCodigoPeca.Symbology = (BarCodeGeneratorBase)(object)symbology2;
		((XRControl)txCodigoPeca).Text = "W708785 S437";
		((XRControl)txCodigoPeca).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel8).CanGrow = false;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel8).LocationFloat = new PointFloat(24.99999f, 488.3608f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(132.2917f, 45.19084f);
		((XRControl)xrLabel8).StylePriority.UseFont = false;
		((XRControl)xrLabel8).Text = "PART:";
		((XRControl)xrLabel9).CanGrow = false;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(24.99999f, 533.5518f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(132.2917f, 58.42f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "(P)";
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txData).LocationFloat = new PointFloat(758.2083f, 416.7117f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(269.8752f, 45.19092f);
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).Text = "DATE:";
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(633.8541f, 416.7117f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(124.3542f, 45.19092f);
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).Text = "DATE:";
		((XRControl)xrLine2).BorderWidth = 5f;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(6.000034f, 464.5483f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(1799f, 23.81244f);
		((XRControl)xrLine2).StylePriority.UseBorderWidth = false;
		((XRControl)txPeso).CanGrow = false;
		((XRControl)txPeso).Dpi = 254f;
		((XRControl)txPeso).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txPeso).LocationFloat = new PointFloat(869.3333f, 371.5208f);
		((XRControl)txPeso).Name = "txPeso";
		((XRControl)txPeso).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPeso).SizeF = new SizeF(158.7501f, 45.19089f);
		((XRControl)txPeso).StylePriority.UseFont = false;
		((XRControl)txPeso).Text = "13,70";
		((XRControl)xrLabel6).CanGrow = false;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(633.8541f, 371.5208f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(235.4792f, 45.19089f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).Text = "GROSS WGT:";
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(508.6875f, 416.7116f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(87.31247f, 47.83667f);
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "EA";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)4;
		txEmbalagem.AutoModule = true;
		((XRControl)txEmbalagem).Dpi = 254f;
		((XRControl)txEmbalagem).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txEmbalagem).LocationFloat = new PointFloat(796.375f, 206.375f);
		txEmbalagem.Module = 5.08f;
		((XRControl)txEmbalagem).Name = "txEmbalagem";
		((XRControl)txEmbalagem).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txEmbalagem).SizeF = new SizeF(958.8334f, 156.3158f);
		((XRControl)txEmbalagem).StylePriority.UseFont = false;
		((XRControl)txEmbalagem).StylePriority.UseTextAlignment = false;
		txEmbalagem.Symbology = (BarCodeGeneratorBase)(object)symbology3;
		((XRControl)txEmbalagem).Text = "KLT4314-DBNCA";
		((XRControl)txEmbalagem).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel4).CanGrow = false;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(633.8541f, 218.0625f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(235.4792f, 45.19084f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).Text = "CONTAINER:";
		txQuantidade.AutoModule = true;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(189.3542f, 218.0625f);
		txQuantidade.Module = 5.08f;
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(338.6667f, 198.6492f);
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		txQuantidade.Symbology = (BarCodeGeneratorBase)(object)symbology4;
		((XRControl)txQuantidade).Text = "100";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(25.00001f, 263.2534f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(132.2917f, 58.42f);
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).Text = "(Q)";
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(24.99999f, 218.0625f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(132.2917f, 45.19084f);
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).Text = "QTY:";
		((XRControl)xrLine1).BorderWidth = 5f;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(6.999989f, 182.5625f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(1798f, 23.8125f);
		((XRControl)xrLine1).StylePriority.UseBorderWidth = false;
		((XRControl)txNomeFantasia).Dpi = 254f;
		((XRControl)txNomeFantasia).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNomeFantasia).LocationFloat = new PointFloat(189.3542f, 25.00001f);
		txNomeFantasia.Module = 5.08f;
		((XRControl)txNomeFantasia).Name = "txNomeFantasia";
		((XRControl)txNomeFantasia).Padding = new PaddingInfo(25, 25, 0, 0, 254f);
		((XRControl)txNomeFantasia).SizeF = new SizeF(1169.458f, 148.3784f);
		((XRControl)txNomeFantasia).StylePriority.UseFont = false;
		((XRControl)txNomeFantasia).StylePriority.UseTextAlignment = false;
		txNomeFantasia.Symbology = (BarCodeGeneratorBase)(object)symbology5;
		((XRControl)txNomeFantasia).Text = "DHF METALURGICA";
		((XRControl)txNomeFantasia).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoVendedorEDI).CanGrow = false;
		((XRControl)txCodigoVendedorEDI).Dpi = 254f;
		((XRControl)txCodigoVendedorEDI).Font = new Font("Arial", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txCodigoVendedorEDI).LocationFloat = new PointFloat(1398.021f, 25.00001f);
		((XRControl)txCodigoVendedorEDI).Name = "txCodigoVendedorEDI";
		((XRControl)txCodigoVendedorEDI).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoVendedorEDI).SizeF = new SizeF(357.1875f, 148.3784f);
		((XRControl)txCodigoVendedorEDI).StylePriority.UseFont = false;
		((XRControl)txCodigoVendedorEDI).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoVendedorEDI).Text = "DBNCA";
		((XRControl)txCodigoVendedorEDI).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(25.00001f, 25.00001f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(132.2917f, 58.42f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).Text = "SUPP:";
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
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 1016;
		((XtraReport)this).PageWidth = 1830;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10f;
		((XtraReport)this).Version = "18.1";
		((ISupportInitialize)this).EndInit();
	}
}
