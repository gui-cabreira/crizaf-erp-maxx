using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiqueta309 : XtraReport
{
	private bool _isQdeQuebrada = false;

	private string _nroEtiq = string.Empty;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private XRLine xrLine1;

	private XRLine xrLine3;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLine xrLine4;

	private XRLabel xrLabel1;

	private XRLabel txNomeFantasia;

	private XRLine xrLine7;

	private XRLabel xrLabel5;

	private XRLabel xrCarga;

	private XRLabel xrLabel29;

	private XRLabel txVersao;

	private XRLabel txData;

	private XRLabel xrLabel26;

	private XRLabel xrLabel25;

	private XRLabel txCodigoPeca2;

	private XRLabel xrLabel23;

	private XRLabel txLote;

	private XRLabel xrLabel21;

	private XRLabel xrLabel19;

	private XRLabel txCodigoVendedorEDI;

	private XRLabel txDescricaoProduto;

	private XRLabel xrLabel17;

	private XRLabel txQuantidade;

	private XRLabel xrLabel9;

	private XRLabel txQtdCaixas;

	private XRLabel txPesoBru;

	private XRLabel xrLabel12;

	private XRLabel xrLabel11;

	private XRLabel xrLabel3;

	private XRLabel txPesoLiq;

	private XRLabel txCodigoPeca;

	private XRLabel txEndereco;

	private XRLabel xrLabel2;

	private XRLabel txNF;

	private XRLabel xrLabel7;

	private XRLine xrLine2;

	private XRLabel xrLabel15;

	private XRPictureBox xrLogo2;

	private XRLabel txRazao;

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

	public string nroEtiq
	{
		get
		{
			return _nroEtiq;
		}
		set
		{
			_nroEtiq = value;
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

	public rptEtiqueta309()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		xrLogo2.Image = emitente.Logo;
		((XRControl)txEndereco).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.EnderecoImpressao;
		((XRControl)txData).Text = ItemNotaFiscal.NotaFiscalRef.DataEmissao.ToShortDateString();
		((XRControl)txNomeFantasia).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.NomeFantasia;
		((XRControl)txRazao).Text = emitente.RazaoSocial;
		((XRControl)txCodigoVendedorEDI).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.CodigoVendedorEDI;
		if (string.IsNullOrEmpty(((XRControl)txCodigoVendedorEDI).Text))
		{
			((XRControl)txCodigoVendedorEDI).Text = emitente.NomeFantasia;
		}
		((XRControl)txNF).Text = ItemNotaFiscal.CodigoNotaFiscal.ToString();
		((XRControl)txPesoLiq).Text = string.Empty;
		((XRControl)txQuantidade).Text = string.Empty;
		((XRControl)txLote).Text = string.Empty;
		((XRControl)txQtdCaixas).Text = nroEtiq;
		((XRControl)txVersao).Text = ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.DesenhoRevisao;
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa != null)
		{
			if (!string.IsNullOrEmpty(ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade))
			{
				((XRControl)txCodigoPeca).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
			}
			else
			{
				((XRControl)txCodigoPeca).Text = ItemNotaFiscal.CodigoProduto;
			}
			if (!string.IsNullOrEmpty(ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade))
			{
				((XRControl)txDescricaoProduto).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
			}
			else
			{
				((XRControl)txDescricaoProduto).Text = ItemNotaFiscal.DescricaoProduto;
			}
			foreach (FichaExpedicaoLote lote in ItemNotaFiscal.FichaExpedicaoItemRef.Lotes)
			{
				XRLabel obj = txLote;
				((XRControl)obj).Text = ((XRControl)obj).Text + lote.NumeroLote + "  ";
			}
		}
		else
		{
			((XRControl)txCodigoPeca).Text = ItemNotaFiscal.CodigoProduto;
			((XRControl)txDescricaoProduto).Text = ItemNotaFiscal.DescricaoProduto;
			((XRControl)txPesoLiq).Text = string.Empty;
			((XRControl)txLote).Text = string.Empty;
		}
		((XRControl)txCodigoPeca2).Text = ((XRControl)txCodigoPeca).Text;
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem + " pç";
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPesoLiq).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem, 2).ToString();
				((XRControl)txPesoBru).Text = ((XRControl)txPesoLiq).Text;
			}
		}
		else
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.Quantidade.ToString();
		}
		if (IsQdeQuebrada)
		{
			int num = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
			((XRControl)txQuantidade).Text = num + " pç";
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPesoLiq).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num, 2).ToString();
				((XRControl)txPesoBru).Text = ((XRControl)txPesoLiq).Text;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_111b: Unknown result type (might be due to invalid IL or missing references)
		//IL_120f: Unknown result type (might be due to invalid IL or missing references)
		//IL_123a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1310: Unknown result type (might be due to invalid IL or missing references)
		//IL_133b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1421: Unknown result type (might be due to invalid IL or missing references)
		//IL_144c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1533: Unknown result type (might be due to invalid IL or missing references)
		//IL_155e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1634: Unknown result type (might be due to invalid IL or missing references)
		//IL_165f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1744: Unknown result type (might be due to invalid IL or missing references)
		//IL_176f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1867: Unknown result type (might be due to invalid IL or missing references)
		//IL_1892: Unknown result type (might be due to invalid IL or missing references)
		//IL_197a: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2000: Unknown result type (might be due to invalid IL or missing references)
		//IL_202b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2122: Unknown result type (might be due to invalid IL or missing references)
		//IL_214d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2235: Unknown result type (might be due to invalid IL or missing references)
		//IL_2260: Unknown result type (might be due to invalid IL or missing references)
		//IL_2336: Unknown result type (might be due to invalid IL or missing references)
		//IL_2361: Unknown result type (might be due to invalid IL or missing references)
		//IL_2432: Unknown result type (might be due to invalid IL or missing references)
		//IL_245d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2506: Unknown result type (might be due to invalid IL or missing references)
		//IL_2531: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2753: Unknown result type (might be due to invalid IL or missing references)
		//IL_280b: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2979: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a50: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptEtiqueta309));
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrCarga = new XRLabel();
		xrLabel29 = new XRLabel();
		txVersao = new XRLabel();
		txData = new XRLabel();
		xrLabel26 = new XRLabel();
		xrLabel25 = new XRLabel();
		txCodigoPeca2 = new XRLabel();
		xrLabel23 = new XRLabel();
		txLote = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel19 = new XRLabel();
		txCodigoVendedorEDI = new XRLabel();
		txDescricaoProduto = new XRLabel();
		xrLabel17 = new XRLabel();
		txQuantidade = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel9 = new XRLabel();
		txQtdCaixas = new XRLabel();
		txPesoBru = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel3 = new XRLabel();
		txPesoLiq = new XRLabel();
		txCodigoPeca = new XRLabel();
		txEndereco = new XRLabel();
		xrLabel2 = new XRLabel();
		txNF = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel5 = new XRLabel();
		txNomeFantasia = new XRLabel();
		xrLine7 = new XRLine();
		xrLabel1 = new XRLabel();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		xrLogo2 = new XRPictureBox();
		txRazao = new XRLabel();
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
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[38]
		{
			(XRControl)xrCarga,
			(XRControl)xrLabel29,
			(XRControl)txVersao,
			(XRControl)txData,
			(XRControl)xrLabel26,
			(XRControl)xrLabel25,
			(XRControl)txCodigoPeca2,
			(XRControl)xrLabel23,
			(XRControl)txLote,
			(XRControl)xrLabel21,
			(XRControl)xrLabel19,
			(XRControl)txCodigoVendedorEDI,
			(XRControl)txDescricaoProduto,
			(XRControl)xrLabel17,
			(XRControl)txQuantidade,
			(XRControl)xrLabel15,
			(XRControl)xrLabel9,
			(XRControl)txQtdCaixas,
			(XRControl)txPesoBru,
			(XRControl)xrLabel12,
			(XRControl)xrLabel11,
			(XRControl)xrLabel3,
			(XRControl)txPesoLiq,
			(XRControl)txCodigoPeca,
			(XRControl)txEndereco,
			(XRControl)xrLabel2,
			(XRControl)txNF,
			(XRControl)xrLabel7,
			(XRControl)xrLabel5,
			(XRControl)txNomeFantasia,
			(XRControl)xrLine7,
			(XRControl)xrLabel1,
			(XRControl)xrLine2,
			(XRControl)xrLine1,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)xrLogo2,
			(XRControl)txRazao
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
		((XRControl)xrCarga).Borders = (BorderSide)4;
		((XRControl)xrCarga).BorderWidth = 1f;
		((XRControl)xrCarga).CanGrow = false;
		((XRControl)xrCarga).Dpi = 254f;
		((XRControl)xrCarga).Font = new Font("Arial", 15.75f);
		((XRControl)xrCarga).LocationFloat = new PointFloat(749.3228f, 742.6459f);
		((XRControl)xrCarga).Name = "xrCarga";
		((XRControl)xrCarga).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrCarga).SizeF = new SizeF(714.8956f, 80.9375f);
		((XRControl)xrCarga).StylePriority.UseBorders = false;
		((XRControl)xrCarga).StylePriority.UseBorderWidth = false;
		((XRControl)xrCarga).StylePriority.UseFont = false;
		((XRControl)xrCarga).StylePriority.UseTextAlignment = false;
		((XRControl)xrCarga).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel29).Borders = (BorderSide)0;
		((XRControl)xrLabel29).BorderWidth = 1f;
		((XRControl)xrLabel29).Dpi = 254f;
		((XRControl)xrLabel29).Font = new Font("Arial", 6f);
		((XRControl)xrLabel29).LocationFloat = new PointFloat(760.3234f, 708.2484f);
		xrLabel29.Multiline = true;
		((XRControl)xrLabel29).Name = "xrLabel29";
		((XRControl)xrLabel29).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel29).SizeF = new SizeF(703.895f, 33.37152f);
		((XRControl)xrLabel29).StylePriority.UseBorders = false;
		((XRControl)xrLabel29).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel29).StylePriority.UseFont = false;
		((XRControl)xrLabel29).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel29).Text = "Charge No. / Carga nº";
		((XRControl)xrLabel29).TextAlignment = (TextAlignment)16;
		((XRControl)txVersao).Borders = (BorderSide)8;
		((XRControl)txVersao).BorderWidth = 1f;
		((XRControl)txVersao).CanGrow = false;
		((XRControl)txVersao).Dpi = 254f;
		((XRControl)txVersao).Font = new Font("Arial", 15.75f);
		((XRControl)txVersao).LocationFloat = new PointFloat(1056.763f, 646.2485f);
		((XRControl)txVersao).Name = "txVersao";
		((XRControl)txVersao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txVersao).SizeF = new SizeF(407.4554f, 61.99988f);
		((XRControl)txVersao).StylePriority.UseBorders = false;
		((XRControl)txVersao).StylePriority.UseBorderWidth = false;
		((XRControl)txVersao).StylePriority.UseFont = false;
		((XRControl)txVersao).StylePriority.UseTextAlignment = false;
		((XRControl)txVersao).Text = "03";
		((XRControl)txVersao).TextAlignment = (TextAlignment)32;
		((XRControl)txData).Borders = (BorderSide)12;
		((XRControl)txData).BorderWidth = 1f;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 15.75f);
		((XRControl)txData).LocationFloat = new PointFloat(749.3227f, 646.2485f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(307.4407f, 62f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseBorderWidth = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).Text = "06/01/2015";
		((XRControl)txData).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel26).Borders = (BorderSide)0;
		((XRControl)xrLabel26).Dpi = 254f;
		((XRControl)xrLabel26).Font = new Font("Arial", 6f);
		((XRControl)xrLabel26).LocationFloat = new PointFloat(1056.763f, 615.8171f);
		((XRControl)xrLabel26).Name = "xrLabel26";
		((XRControl)xrLabel26).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel26).SizeF = new SizeF(407.4553f, 30.43152f);
		((XRControl)xrLabel26).StylePriority.UseBorders = false;
		((XRControl)xrLabel26).StylePriority.UseFont = false;
		((XRControl)xrLabel26).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel26).Text = "Eng. Change / Alteração Engenharia";
		((XRControl)xrLabel26).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel25).Borders = (BorderSide)4;
		((XRControl)xrLabel25).BorderWidth = 1f;
		((XRControl)xrLabel25).Dpi = 254f;
		((XRControl)xrLabel25).Font = new Font("Arial", 6f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(748.4883f, 615.8171f);
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel25).SizeF = new SizeF(308.2751f, 30.43152f);
		((XRControl)xrLabel25).StylePriority.UseBorders = false;
		((XRControl)xrLabel25).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel25).Text = "Date / Data";
		((XRControl)xrLabel25).TextAlignment = (TextAlignment)16;
		((XRControl)txCodigoPeca2).Borders = (BorderSide)8;
		((XRControl)txCodigoPeca2).BorderWidth = 1f;
		((XRControl)txCodigoPeca2).CanGrow = false;
		((XRControl)txCodigoPeca2).Dpi = 254f;
		((XRControl)txCodigoPeca2).Font = new Font("Arial", 14f);
		((XRControl)txCodigoPeca2).LocationFloat = new PointFloat(748.4883f, 553.817f);
		((XRControl)txCodigoPeca2).Name = "txCodigoPeca2";
		((XRControl)txCodigoPeca2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoPeca2).SizeF = new SizeF(715.73f, 62f);
		((XRControl)txCodigoPeca2).StylePriority.UseBorders = false;
		((XRControl)txCodigoPeca2).StylePriority.UseBorderWidth = false;
		((XRControl)txCodigoPeca2).StylePriority.UseFont = false;
		((XRControl)txCodigoPeca2).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoPeca2).Text = "39695A01/03";
		((XRControl)txCodigoPeca2).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel23).Borders = (BorderSide)0;
		((XRControl)xrLabel23).Dpi = 254f;
		((XRControl)xrLabel23).Font = new Font("Arial", 6f);
		((XRControl)xrLabel23).LocationFloat = new PointFloat(749.3227f, 523.3854f);
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel23).SizeF = new SizeF(714.8957f, 30.43152f);
		((XRControl)xrLabel23).StylePriority.UseBorders = false;
		((XRControl)xrLabel23).StylePriority.UseFont = false;
		((XRControl)xrLabel23).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel23).Text = "Supplier Part No. / Nº da Peça no Fornecedor";
		((XRControl)xrLabel23).TextAlignment = (TextAlignment)16;
		((XRControl)txLote).Borders = (BorderSide)4;
		((XRControl)txLote).BorderWidth = 1f;
		((XRControl)txLote).CanGrow = false;
		((XRControl)txLote).Dpi = 254f;
		((XRControl)txLote).Font = new Font("Arial", 9f);
		((XRControl)txLote).LocationFloat = new PointFloat(24.98947f, 742.6458f);
		((XRControl)txLote).Name = "txLote";
		((XRControl)txLote).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txLote).SizeF = new SizeF(724.3334f, 63f);
		((XRControl)txLote).StylePriority.UseBorders = false;
		((XRControl)txLote).StylePriority.UseBorderWidth = false;
		((XRControl)txLote).StylePriority.UseFont = false;
		((XRControl)txLote).StylePriority.UseTextAlignment = false;
		((XRControl)txLote).Text = "277/14 Lote: 001";
		((XRControl)txLote).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel21).Borders = (BorderSide)4;
		((XRControl)xrLabel21).BorderWidth = 1f;
		((XRControl)xrLabel21).Dpi = 254f;
		((XRControl)xrLabel21).Font = new Font("Arial", 6f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(29.41647f, 708.2484f);
		xrLabel21.Multiline = true;
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel21).SizeF = new SizeF(719.9064f, 34.3974f);
		((XRControl)xrLabel21).StylePriority.UseBorders = false;
		((XRControl)xrLabel21).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel21).Text = "Serial No./ Número de Série / Nº Rolo / Ordem de Serviço";
		((XRControl)xrLabel21).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel19).Borders = (BorderSide)4;
		((XRControl)xrLabel19).BorderWidth = 1f;
		((XRControl)xrLabel19).Dpi = 254f;
		((XRControl)xrLabel19).Font = new Font("Arial", 6f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(29.41649f, 554.1114f);
		xrLabel19.Multiline = true;
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel19).SizeF = new SizeF(719.9063f, 33.3714f);
		((XRControl)xrLabel19).StylePriority.UseBorders = false;
		((XRControl)xrLabel19).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel19).Text = "Supplier No. / Fornecedor Nº";
		((XRControl)xrLabel19).TextAlignment = (TextAlignment)16;
		((XRControl)txCodigoVendedorEDI).Borders = (BorderSide)12;
		((XRControl)txCodigoVendedorEDI).BorderWidth = 1f;
		((XRControl)txCodigoVendedorEDI).CanGrow = false;
		((XRControl)txCodigoVendedorEDI).Dpi = 254f;
		((XRControl)txCodigoVendedorEDI).Font = new Font("Arial", 15.75f);
		((XRControl)txCodigoVendedorEDI).LocationFloat = new PointFloat(29.41649f, 587.4827f);
		((XRControl)txCodigoVendedorEDI).Name = "txCodigoVendedorEDI";
		((XRControl)txCodigoVendedorEDI).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoVendedorEDI).SizeF = new SizeF(719.9062f, 120.7658f);
		((XRControl)txCodigoVendedorEDI).StylePriority.UseBorders = false;
		((XRControl)txCodigoVendedorEDI).StylePriority.UseBorderWidth = false;
		((XRControl)txCodigoVendedorEDI).StylePriority.UseFont = false;
		((XRControl)txCodigoVendedorEDI).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoVendedorEDI).Text = "210016 - SEMIL";
		((XRControl)txCodigoVendedorEDI).TextAlignment = (TextAlignment)32;
		((XRControl)txDescricaoProduto).Borders = (BorderSide)8;
		((XRControl)txDescricaoProduto).BorderWidth = 1f;
		((XRControl)txDescricaoProduto).CanGrow = false;
		((XRControl)txDescricaoProduto).Dpi = 254f;
		((XRControl)txDescricaoProduto).Font = new Font("Arial", 12f);
		((XRControl)txDescricaoProduto).LocationFloat = new PointFloat(749.3228f, 459.8432f);
		((XRControl)txDescricaoProduto).Name = "txDescricaoProduto";
		((XRControl)txDescricaoProduto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricaoProduto).SizeF = new SizeF(714.8954f, 61.99991f);
		((XRControl)txDescricaoProduto).StylePriority.UseBorders = false;
		((XRControl)txDescricaoProduto).StylePriority.UseBorderWidth = false;
		((XRControl)txDescricaoProduto).StylePriority.UseFont = false;
		((XRControl)txDescricaoProduto).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricaoProduto).Text = "BUCHA METÁLICA";
		((XRControl)txDescricaoProduto).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel17).Borders = (BorderSide)0;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 6f);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(749.3226f, 429.4117f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(714.8957f, 30.43158f);
		((XRControl)xrLabel17).StylePriority.UseBorders = false;
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel17).Text = "Description / Descrição";
		((XRControl)xrLabel17).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)12;
		((XRControl)txQuantidade).BorderWidth = 1f;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(24.98947f, 459.8432f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(724.3333f, 94.26807f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseBorderWidth = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).Text = "400 pç";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel15).Borders = (BorderSide)4;
		((XRControl)xrLabel15).BorderWidth = 1f;
		((XRControl)xrLabel15).Dpi = 254f;
		((XRControl)xrLabel15).Font = new Font("Arial", 6f);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(29.00004f, 429.4116f);
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel15).SizeF = new SizeF(720.3228f, 30.43158f);
		((XRControl)xrLabel15).StylePriority.UseBorders = false;
		((XRControl)xrLabel15).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel15).Text = "Quantity / Quantidade";
		((XRControl)xrLabel15).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 6f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(29.0001f, 318.9801f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(639.5414f, 30.43158f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "Part No. / Peça Nº / Código Matéria Prima";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)16;
		((XRControl)txQtdCaixas).Borders = (BorderSide)8;
		((XRControl)txQtdCaixas).BorderWidth = 1f;
		((XRControl)txQtdCaixas).CanGrow = false;
		((XRControl)txQtdCaixas).Dpi = 254f;
		((XRControl)txQtdCaixas).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txQtdCaixas).LocationFloat = new PointFloat(1222.323f, 249.4593f);
		((XRControl)txQtdCaixas).Name = "txQtdCaixas";
		((XRControl)txQtdCaixas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQtdCaixas).SizeF = new SizeF(241.8953f, 68.99994f);
		((XRControl)txQtdCaixas).StylePriority.UseBorders = false;
		((XRControl)txQtdCaixas).StylePriority.UseBorderWidth = false;
		((XRControl)txQtdCaixas).StylePriority.UseFont = false;
		((XRControl)txQtdCaixas).StylePriority.UseTextAlignment = false;
		((XRControl)txQtdCaixas).Text = "1/2";
		((XRControl)txQtdCaixas).TextAlignment = (TextAlignment)32;
		((XRControl)txPesoBru).Borders = (BorderSide)12;
		((XRControl)txPesoBru).BorderWidth = 1f;
		((XRControl)txPesoBru).CanGrow = false;
		((XRControl)txPesoBru).Dpi = 254f;
		((XRControl)txPesoBru).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txPesoBru).LocationFloat = new PointFloat(984.6146f, 249.4593f);
		((XRControl)txPesoBru).Name = "txPesoBru";
		((XRControl)txPesoBru).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoBru).SizeF = new SizeF(237.7083f, 69f);
		((XRControl)txPesoBru).StylePriority.UseBorders = false;
		((XRControl)txPesoBru).StylePriority.UseBorderWidth = false;
		((XRControl)txPesoBru).StylePriority.UseFont = false;
		((XRControl)txPesoBru).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoBru).Text = "13,96";
		((XRControl)txPesoBru).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel12).Borders = (BorderSide)10;
		((XRControl)xrLabel12).BorderWidth = 1f;
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).Font = new Font("Arial", 6f);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(1217.477f, 218.6296f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(246.7413f, 30.35043f);
		((XRControl)xrLabel12).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel12).Text = "nº Boxes/nº Emb.";
		((XRControl)xrLabel12).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel11).Borders = (BorderSide)14;
		((XRControl)xrLabel11).BorderWidth = 1f;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 6f);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(984.3228f, 218.6296f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(238.0001f, 30.35045f);
		((XRControl)xrLabel11).StylePriority.UseBorders = false;
		((XRControl)xrLabel11).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel11).Text = "Gross Wt/PesoBruto";
		((XRControl)xrLabel11).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel3).Borders = (BorderSide)14;
		((XRControl)xrLabel3).BorderWidth = 1f;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 6f);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(747.4883f, 218.6296f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(237.1263f, 30.35046f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "Net Wt/PesoLíquido";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)32;
		((XRControl)txPesoLiq).Borders = (BorderSide)12;
		((XRControl)txPesoLiq).BorderWidth = 1f;
		((XRControl)txPesoLiq).CanGrow = false;
		((XRControl)txPesoLiq).Dpi = 254f;
		((XRControl)txPesoLiq).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txPesoLiq).LocationFloat = new PointFloat(749.6147f, 248.9801f);
		((XRControl)txPesoLiq).Name = "txPesoLiq";
		((XRControl)txPesoLiq).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoLiq).SizeF = new SizeF(234.9999f, 69.47919f);
		((XRControl)txPesoLiq).StylePriority.UseBorders = false;
		((XRControl)txPesoLiq).StylePriority.UseBorderWidth = false;
		((XRControl)txPesoLiq).StylePriority.UseFont = false;
		((XRControl)txPesoLiq).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoLiq).Text = "13,96";
		((XRControl)txPesoLiq).TextAlignment = (TextAlignment)32;
		((XRControl)txCodigoPeca).Borders = (BorderSide)8;
		((XRControl)txCodigoPeca).BorderWidth = 1f;
		((XRControl)txCodigoPeca).CanGrow = false;
		((XRControl)txCodigoPeca).Dpi = 254f;
		((XRControl)txCodigoPeca).Font = new Font("Arial", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txCodigoPeca).LocationFloat = new PointFloat(29.41649f, 349.4117f);
		((XRControl)txCodigoPeca).Name = "txCodigoPeca";
		((XRControl)txCodigoPeca).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoPeca).SizeF = new SizeF(1434.802f, 79.99994f);
		((XRControl)txCodigoPeca).StylePriority.UseBorders = false;
		((XRControl)txCodigoPeca).StylePriority.UseBorderWidth = false;
		((XRControl)txCodigoPeca).StylePriority.UseFont = false;
		((XRControl)txCodigoPeca).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoPeca).Text = "39695A01/03";
		((XRControl)txCodigoPeca).TextAlignment = (TextAlignment)32;
		((XRControl)txEndereco).Borders = (BorderSide)0;
		((XRControl)txEndereco).CanGrow = false;
		((XRControl)txEndereco).Dpi = 254f;
		((XRControl)txEndereco).Font = new Font("Arial", 8.5f);
		((XRControl)txEndereco).LocationFloat = new PointFloat(749.3228f, 148.6297f);
		txEndereco.Multiline = true;
		((XRControl)txEndereco).Name = "txEndereco";
		((XRControl)txEndereco).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEndereco).SizeF = new SizeF(714.8954f, 70.00002f);
		((XRControl)txEndereco).StylePriority.UseBorders = false;
		((XRControl)txEndereco).StylePriority.UseFont = false;
		((XRControl)txEndereco).StylePriority.UseTextAlignment = false;
		((XRControl)txEndereco).Text = "R. Valdemar Rigout, 41 - Sertãozinho - Mauá - SP - CEP 09370-830";
		((XRControl)txEndereco).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel2).Borders = (BorderSide)2;
		((XRControl)xrLabel2).BorderWidth = 1f;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 6f);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(747.4883f, 119.5948f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(716.7301f, 29.03483f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Receiver Adress / Endereço Cliente";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)txNF).Borders = (BorderSide)8;
		((XRControl)txNF).BorderWidth = 1f;
		((XRControl)txNF).CanGrow = false;
		((XRControl)txNF).Dpi = 254f;
		((XRControl)txNF).Font = new Font("Arial", 24f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNF).LocationFloat = new PointFloat(29.41647f, 148.6296f);
		((XRControl)txNF).Name = "txNF";
		((XRControl)txNF).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNF).SizeF = new SizeF(714.8956f, 169.8297f);
		((XRControl)txNF).StylePriority.UseBorders = false;
		((XRControl)txNF).StylePriority.UseBorderWidth = false;
		((XRControl)txNF).StylePriority.UseFont = false;
		((XRControl)txNF).StylePriority.UseTextAlignment = false;
		((XRControl)txNF).Text = "9417";
		((XRControl)txNF).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel7).Borders = (BorderSide)10;
		((XRControl)xrLabel7).BorderWidth = 1f;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 6f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(29.00004f, 119.5948f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(718.8954f, 29.03483f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "Advise Note No. / Nota Entrega nº (NF)";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 6f);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(749.3228f, 17.64581f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(714.8956f, 31.94896f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "Receiver/Local de Entrega /Cliente ";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)txNomeFantasia).Borders = (BorderSide)0;
		((XRControl)txNomeFantasia).CanGrow = false;
		((XRControl)txNomeFantasia).Dpi = 254f;
		((XRControl)txNomeFantasia).Font = new Font("Arial", 11f);
		((XRControl)txNomeFantasia).LocationFloat = new PointFloat(749.3228f, 49.59484f);
		((XRControl)txNomeFantasia).Name = "txNomeFantasia";
		((XRControl)txNomeFantasia).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeFantasia).SizeF = new SizeF(714.8954f, 70f);
		((XRControl)txNomeFantasia).StylePriority.UseBorders = false;
		((XRControl)txNomeFantasia).StylePriority.UseFont = false;
		((XRControl)txNomeFantasia).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeFantasia).Text = "ISRINGHAUSEN LTDA (SP)";
		((XRControl)txNomeFantasia).TextAlignment = (TextAlignment)32;
		((XRControl)xrLine7).Dpi = 254f;
		xrLine7.LineDirection = (LineDirection)3;
		((XRControl)xrLine7).LocationFloat = new PointFloat(743.8954f, 4.000001f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).Padding = new PaddingInfo(0, 0, 8, 0, 254f);
		((XRControl)xrLine7).SizeF = new SizeF(5.427307f, 314.4593f);
		((XRControl)xrLine7).StylePriority.UsePadding = false;
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 6f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(29.00005f, 17.64585f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(719.7391f, 31.94896f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Supplier/ Fornecedor";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 2f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(22.00003f, 805.6459f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(1442.218f, 18.93744f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 2f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(20.00003f, 0f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(1444.218f, 17.64583f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 2f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(18.00004f, 3.99999f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 819.5833f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 2f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(1453.218f, 0.99998f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(11.00012f, 822.5833f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)xrLogo2).BorderWidth = 0f;
		((XRControl)xrLogo2).Dpi = 254f;
		xrLogo2.Image = (Image)componentResourceManager.GetObject("xrLogo2.Image");
		xrLogo2.ImageAlignment = (ImageAlignment)5;
		((XRControl)xrLogo2).LocationFloat = new PointFloat(29.41649f, 49.59484f);
		((XRControl)xrLogo2).Name = "xrLogo2";
		((XRControl)xrLogo2).SizeF = new SizeF(140.7902f, 70.00001f);
		xrLogo2.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo2).StylePriority.UseBorderWidth = false;
		((XRControl)txRazao).Borders = (BorderSide)0;
		((XRControl)txRazao).Dpi = 254f;
		((XRControl)txRazao).Font = new Font("Arial", 10f);
		((XRControl)txRazao).LocationFloat = new PointFloat(182.0574f, 49.59484f);
		txRazao.Multiline = true;
		((XRControl)txRazao).Name = "txRazao";
		((XRControl)txRazao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txRazao).SizeF = new SizeF(561.838f, 69.99996f);
		((XRControl)txRazao).StylePriority.UseBorders = false;
		((XRControl)txRazao).StylePriority.UseFont = false;
		((XRControl)txRazao).StylePriority.UseTextAlignment = false;
		((XRControl)txRazao).Text = "Supplier/ Fornecedor";
		((XRControl)txRazao).TextAlignment = (TextAlignment)16;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 113.7708f;
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
		((XRControl)this).BorderWidth = 0.2f;
		((XRControl)this).Dpi = 254f;
		((XtraReport)this).Landscape = true;
		((XtraReport)this).Margins = new Margins(0, 0, 114, 0);
		((XtraReport)this).PageHeight = 1016;
		((XtraReport)this).PageWidth = 1519;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).ShowPrintMarginsWarning = false;
		((XtraReport)this).ShowPrintStatusDialog = false;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "18.1";
		((ISupportInitialize)this).EndInit();
	}
}
