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

public class rptEtiquetaNakayone : XtraReport
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

	private XRLabel xrLabel5;

	private XRLabel xrLabel29;

	private XRLabel txData;

	private XRLabel xrLabel25;

	private XRLabel xrLabel23;

	private XRLabel xrLabel21;

	private XRLabel xrLabel19;

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

	private XRLabel txForEnder;

	private XRLabel xrLabel2;

	private XRLabel txNF;

	private XRLabel xrLabel7;

	private XRLine xrLine2;

	private XRLabel txDoca;

	private XRLabel txForNome;

	private XRLabel txDestNome;

	private XRLabel txDestEnd;

	private XRBarCode txBarSerie;

	private XRBarCode txForEDI;

	private XRLabel txForFantasia;

	private XRBarCode txBarQuant;

	private XRLabel xrLabel10;

	private XRBarCode txBarForFant;

	private XRBarCode txBarNF;

	private XRLabel txProd;

	private XRBarCode txBarProd;

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

	public rptEtiquetaNakayone()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)txDestNome).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocialNF;
		((XRControl)txDestEnd).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.EnderecoImpressao;
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		((XRControl)txForNome).Text = emitente.RazaoSocial;
		((XRControl)txForEnder).Text = $"{emitente.Endereco} - {emitente.Bairro} - {emitente.Cidade} -{emitente.Estado}";
		((XRControl)txForFantasia).Text = emitente.NomeFantasia.ToUpper();
		((XRControl)txNF).Text = ItemNotaFiscal.CodigoNotaFiscal.ToString();
		((XRControl)txBarNF).Text = ItemNotaFiscal.CodigoNotaFiscal.ToString();
		((XRControl)txData).Text = ItemNotaFiscal.NotaFiscalRef.DataEmissao.ToShortDateString();
		((XRControl)txPesoLiq).Text = string.Empty;
		((XRControl)txQuantidade).Text = string.Empty;
		((XRControl)txBarSerie).Text = string.Empty;
		((XRControl)txQtdCaixas).Text = nroEtiq;
		((XRControl)txForEDI).Text = removerAcentos(emitente.NomeFantasia.ToUpper() + "-" + emitente.Cidade.ToUpper() + "-" + emitente.Estado + "-" + emitente.CodigoPostal.Replace("-", ""));
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa != null)
		{
			((XRControl)txProd).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
			((XRControl)txDescricaoProduto).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
			((XRControl)txDoca).Text = ItemNotaFiscal.FichaExpedicaoItemRef.Tarifa.PortaoEntrega;
			foreach (FichaExpedicaoLote lote in ItemNotaFiscal.FichaExpedicaoItemRef.Lotes)
			{
				if (!string.IsNullOrEmpty(lote.NumeroLote))
				{
					((XRControl)txBarSerie).Text = lote.NumeroLote;
				}
				else
				{
					((XRControl)txBarSerie).Text = "";
				}
			}
		}
		else
		{
			((XRControl)txProd).Text = string.Empty;
			((XRControl)txDescricaoProduto).Text = string.Empty;
			((XRControl)txPesoLiq).Text = string.Empty;
			((XRControl)txBarSerie).Text = "";
		}
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
		if (ItemNotaFiscal.FichaExpedicaoItemRef != null)
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem.ToString();
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPesoLiq).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem, 2).ToString();
				((XRControl)txPesoBru).Text = ((XRControl)txPesoLiq).Text;
				try
				{
					if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.EmbalagemRef != null)
					{
						((XRControl)txPesoBru).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem + ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem, 2).ToString();
					}
				}
				catch
				{
				}
			}
		}
		else
		{
			((XRControl)txQuantidade).Text = ItemNotaFiscal.Quantidade.ToString();
		}
		if (IsQdeQuebrada)
		{
			int num2 = (int)ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEntregue - ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (ItemNotaFiscal.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
			((XRControl)txQuantidade).Text = num2.ToString();
			if (ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef != null)
			{
				((XRControl)txPesoLiq).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num2, 2).ToString();
				((XRControl)txPesoBru).Text = ((XRControl)txPesoLiq).Text;
				try
				{
					if (ItemNotaFiscal.FichaExpedicaoItemRef != null && ItemNotaFiscal.FichaExpedicaoItemRef.EmbalagemRef != null)
					{
						((XRControl)txPesoBru).Text = Math.Round(ItemNotaFiscal.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem + ItemNotaFiscal.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num2, 2).ToString();
					}
				}
				catch
				{
				}
			}
		}
		((XRControl)txBarQuant).Text = ((XRControl)txQuantidade).Text;
		((XRControl)txBarProd).Text = ((XRControl)txProd).Text;
	}

	private string Removeracentos(string v)
	{
		throw new NotImplementedException();
	}

	private static string removerAcentos(string texto)
	{
		string text = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
		string text2 = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
		for (int i = 0; i < text.Length; i++)
		{
			texto = texto.Replace(text[i].ToString(), text2[i].ToString());
		}
		return texto;
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
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Unknown result type (might be due to invalid IL or missing references)
		//IL_108f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1176: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1288: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_139a: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15db: Unknown result type (might be due to invalid IL or missing references)
		//IL_1613: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1725: Unknown result type (might be due to invalid IL or missing references)
		//IL_181a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1845: Unknown result type (might be due to invalid IL or missing references)
		//IL_192c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1957: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_204f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2087: Unknown result type (might be due to invalid IL or missing references)
		//IL_217c: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2401: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2520: Unknown result type (might be due to invalid IL or missing references)
		//IL_2612: Unknown result type (might be due to invalid IL or missing references)
		//IL_263d: Unknown result type (might be due to invalid IL or missing references)
		//IL_272e: Unknown result type (might be due to invalid IL or missing references)
		//IL_276c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2851: Unknown result type (might be due to invalid IL or missing references)
		//IL_287c: Unknown result type (might be due to invalid IL or missing references)
		//IL_296d: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cda: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e36: Unknown result type (might be due to invalid IL or missing references)
		Code93ExtendedGenerator symbology = new Code93ExtendedGenerator();
		Code93ExtendedGenerator symbology2 = new Code93ExtendedGenerator();
		Code93ExtendedGenerator symbology3 = new Code93ExtendedGenerator();
		Code93ExtendedGenerator symbology4 = new Code93ExtendedGenerator();
		Code93ExtendedGenerator symbology5 = new Code93ExtendedGenerator();
		Code93ExtendedGenerator symbology6 = new Code93ExtendedGenerator();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		txData = new XRLabel();
		xrLabel25 = new XRLabel();
		xrLabel23 = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel19 = new XRLabel();
		txDescricaoProduto = new XRLabel();
		xrLabel17 = new XRLabel();
		txQuantidade = new XRLabel();
		xrLabel9 = new XRLabel();
		txQtdCaixas = new XRLabel();
		txPesoBru = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel3 = new XRLabel();
		txPesoLiq = new XRLabel();
		txForEnder = new XRLabel();
		xrLabel2 = new XRLabel();
		txNF = new XRLabel();
		xrLabel7 = new XRLabel();
		txDoca = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrLine3 = new XRLine();
		xrLine4 = new XRLine();
		txForNome = new XRLabel();
		txDestNome = new XRLabel();
		txDestEnd = new XRLabel();
		txBarSerie = new XRBarCode();
		txForEDI = new XRBarCode();
		txForFantasia = new XRLabel();
		txBarQuant = new XRBarCode();
		xrLabel10 = new XRLabel();
		txBarForFant = new XRBarCode();
		txBarNF = new XRBarCode();
		txProd = new XRLabel();
		txBarProd = new XRBarCode();
		xrLabel29 = new XRLabel();
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
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[39]
		{
			(XRControl)txData,
			(XRControl)xrLabel25,
			(XRControl)xrLabel23,
			(XRControl)xrLabel21,
			(XRControl)xrLabel19,
			(XRControl)txDescricaoProduto,
			(XRControl)xrLabel17,
			(XRControl)txQuantidade,
			(XRControl)xrLabel9,
			(XRControl)txQtdCaixas,
			(XRControl)txPesoBru,
			(XRControl)xrLabel12,
			(XRControl)xrLabel11,
			(XRControl)xrLabel3,
			(XRControl)txPesoLiq,
			(XRControl)txForEnder,
			(XRControl)xrLabel2,
			(XRControl)txNF,
			(XRControl)xrLabel7,
			(XRControl)txDoca,
			(XRControl)xrLabel5,
			(XRControl)xrLabel1,
			(XRControl)xrLine2,
			(XRControl)xrLine1,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)txForNome,
			(XRControl)txDestNome,
			(XRControl)txDestEnd,
			(XRControl)txBarSerie,
			(XRControl)txForEDI,
			(XRControl)txForFantasia,
			(XRControl)txBarQuant,
			(XRControl)xrLabel10,
			(XRControl)txBarForFant,
			(XRControl)txBarNF,
			(XRControl)txProd,
			(XRControl)txBarProd,
			(XRControl)xrLabel29
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)PageHeader).HeightF = 917.1875f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)txData).Borders = (BorderSide)1;
		((XRControl)txData).BorderWidth = 1f;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Arial", 9f);
		((XRControl)txData).LocationFloat = new PointFloat(756.8537f, 718.8281f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(691.1418f, 55.96179f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseBorderWidth = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).Text = "06/01/2015";
		((XRControl)txData).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel25).Borders = (BorderSide)3;
		((XRControl)xrLabel25).BorderWidth = 1f;
		((XRControl)xrLabel25).Dpi = 254f;
		((XRControl)xrLabel25).Font = new Font("Arial", 5f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(756.8537f, 688.3965f);
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel25).SizeF = new SizeF(695.1418f, 30.43152f);
		((XRControl)xrLabel25).StylePriority.UseBorders = false;
		((XRControl)xrLabel25).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel25).Text = "DATA";
		((XRControl)xrLabel25).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel23).Borders = (BorderSide)3;
		((XRControl)xrLabel23).BorderWidth = 1f;
		((XRControl)xrLabel23).Dpi = 254f;
		((XRControl)xrLabel23).Font = new Font("Arial", 5f);
		((XRControl)xrLabel23).LocationFloat = new PointFloat(756.8537f, 581.1825f);
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel23).SizeF = new SizeF(696.1418f, 107.2141f);
		((XRControl)xrLabel23).StylePriority.UseBorders = false;
		((XRControl)xrLabel23).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel23).StylePriority.UseFont = false;
		((XRControl)xrLabel23).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel23).Text = "EMBALAGEM NR";
		((XRControl)xrLabel23).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel21).Borders = (BorderSide)2;
		((XRControl)xrLabel21).BorderWidth = 1f;
		((XRControl)xrLabel21).Dpi = 254f;
		((XRControl)xrLabel21).Font = new Font("Arial", 5f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(25f, 774.7899f);
		xrLabel21.Multiline = true;
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel21).SizeF = new SizeF(731.8537f, 24.4339f);
		((XRControl)xrLabel21).StylePriority.UseBorders = false;
		((XRControl)xrLabel21).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel21).Text = "NR SERIAL (S/M/G)";
		((XRControl)xrLabel21).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel19).Borders = (BorderSide)2;
		((XRControl)xrLabel19).BorderWidth = 1f;
		((XRControl)xrLabel19).Dpi = 254f;
		((XRControl)xrLabel19).Font = new Font("Arial", 5f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(25.42731f, 605.2651f);
		xrLabel19.Multiline = true;
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel19).SizeF = new SizeF(731.4264f, 27.65717f);
		((XRControl)xrLabel19).StylePriority.UseBorders = false;
		((XRControl)xrLabel19).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel19).Text = "FORNECEDOR";
		((XRControl)xrLabel19).TextAlignment = (TextAlignment)16;
		((XRControl)txDescricaoProduto).Borders = (BorderSide)1;
		((XRControl)txDescricaoProduto).BorderWidth = 1f;
		((XRControl)txDescricaoProduto).CanGrow = false;
		((XRControl)txDescricaoProduto).Dpi = 254f;
		((XRControl)txDescricaoProduto).Font = new Font("Arial", 8f);
		((XRControl)txDescricaoProduto).LocationFloat = new PointFloat(756.8537f, 470.3532f);
		txDescricaoProduto.Multiline = true;
		((XRControl)txDescricaoProduto).Name = "txDescricaoProduto";
		((XRControl)txDescricaoProduto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricaoProduto).SizeF = new SizeF(702.142f, 110.8293f);
		((XRControl)txDescricaoProduto).StylePriority.UseBorders = false;
		((XRControl)txDescricaoProduto).StylePriority.UseBorderWidth = false;
		((XRControl)txDescricaoProduto).StylePriority.UseFont = false;
		((XRControl)txDescricaoProduto).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricaoProduto).Text = "BUCHA METÁLICA";
		((XRControl)txDescricaoProduto).TextAlignment = (TextAlignment)16;
		((XRControl)txDescricaoProduto).WordWrap = false;
		((XRControl)xrLabel17).Borders = (BorderSide)3;
		((XRControl)xrLabel17).BorderWidth = 1f;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 5f);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(756.8537f, 439.9216f);
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(695.1418f, 30.43152f);
		((XRControl)xrLabel17).StylePriority.UseBorders = false;
		((XRControl)xrLabel17).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel17).Text = "DESCRIÇÃO";
		((XRControl)xrLabel17).TextAlignment = (TextAlignment)16;
		((XRControl)txQuantidade).Borders = (BorderSide)0;
		((XRControl)txQuantidade).BorderWidth = 1f;
		((XRControl)txQuantidade).CanGrow = false;
		((XRControl)txQuantidade).Dpi = 254f;
		((XRControl)txQuantidade).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txQuantidade).LocationFloat = new PointFloat(29.00005f, 470.3532f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(347.7409f, 24.91196f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseBorderWidth = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)txQuantidade).Text = "400";
		((XRControl)txQuantidade).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel9).Borders = (BorderSide)2;
		((XRControl)xrLabel9).BorderWidth = 1f;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 5f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(24.57257f, 439.9216f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(732.2811f, 30.43158f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "QUANTIDADE (Q) PÇ";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)16;
		((XRControl)txQtdCaixas).Borders = (BorderSide)1;
		((XRControl)txQtdCaixas).BorderWidth = 1f;
		((XRControl)txQtdCaixas).CanGrow = false;
		((XRControl)txQtdCaixas).Dpi = 254f;
		((XRControl)txQtdCaixas).Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txQtdCaixas).LocationFloat = new PointFloat(1216.384f, 234.8591f);
		((XRControl)txQtdCaixas).Name = "txQtdCaixas";
		((XRControl)txQtdCaixas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQtdCaixas).SizeF = new SizeF(231.6115f, 44.75638f);
		((XRControl)txQtdCaixas).StylePriority.UseBorders = false;
		((XRControl)txQtdCaixas).StylePriority.UseBorderWidth = false;
		((XRControl)txQtdCaixas).StylePriority.UseFont = false;
		((XRControl)txQtdCaixas).StylePriority.UseTextAlignment = false;
		((XRControl)txQtdCaixas).Text = "1/2";
		((XRControl)txQtdCaixas).TextAlignment = (TextAlignment)32;
		((XRControl)txPesoBru).Borders = (BorderSide)1;
		((XRControl)txPesoBru).BorderWidth = 1f;
		((XRControl)txPesoBru).CanGrow = false;
		((XRControl)txPesoBru).Dpi = 254f;
		((XRControl)txPesoBru).Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txPesoBru).LocationFloat = new PointFloat(982.2296f, 234.8591f);
		((XRControl)txPesoBru).Name = "txPesoBru";
		((XRControl)txPesoBru).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoBru).SizeF = new SizeF(234.1545f, 44.75641f);
		((XRControl)txPesoBru).StylePriority.UseBorders = false;
		((XRControl)txPesoBru).StylePriority.UseBorderWidth = false;
		((XRControl)txPesoBru).StylePriority.UseFont = false;
		((XRControl)txPesoBru).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoBru).Text = "13,96";
		((XRControl)txPesoBru).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel12).Borders = (BorderSide)3;
		((XRControl)xrLabel12).BorderWidth = 1f;
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).Font = new Font("Arial", 5f);
		((XRControl)xrLabel12).LocationFloat = new PointFloat(1216.384f, 202.528f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(235.6115f, 34.33105f);
		((XRControl)xrLabel12).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel12).StylePriority.UseFont = false;
		((XRControl)xrLabel12).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel12).Text = "CAIXAS";
		((XRControl)xrLabel12).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel11).Borders = (BorderSide)3;
		((XRControl)xrLabel11).BorderWidth = 1f;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 5f);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(982.2295f, 202.528f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(234.1545f, 34.33104f);
		((XRControl)xrLabel11).StylePriority.UseBorders = false;
		((XRControl)xrLabel11).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel11).Text = "PESO BRUTO (KG)";
		((XRControl)xrLabel11).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel3).Borders = (BorderSide)3;
		((XRControl)xrLabel3).BorderWidth = 1f;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).Font = new Font("Arial", 5f);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(755.1364f, 202.528f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(227.0932f, 34.33105f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel3).Text = "PESO LÍQUIDO (KG)";
		((XRControl)xrLabel3).TextAlignment = (TextAlignment)32;
		((XRControl)txPesoLiq).Borders = (BorderSide)1;
		((XRControl)txPesoLiq).BorderWidth = 1f;
		((XRControl)txPesoLiq).CanGrow = false;
		((XRControl)txPesoLiq).Dpi = 254f;
		((XRControl)txPesoLiq).Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txPesoLiq).LocationFloat = new PointFloat(755.1364f, 234.8591f);
		((XRControl)txPesoLiq).Name = "txPesoLiq";
		((XRControl)txPesoLiq).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoLiq).SizeF = new SizeF(227.0932f, 45.23569f);
		((XRControl)txPesoLiq).StylePriority.UseBorders = false;
		((XRControl)txPesoLiq).StylePriority.UseBorderWidth = false;
		((XRControl)txPesoLiq).StylePriority.UseFont = false;
		((XRControl)txPesoLiq).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoLiq).Text = "13,96";
		((XRControl)txPesoLiq).TextAlignment = (TextAlignment)32;
		((XRControl)txForEnder).Borders = (BorderSide)1;
		((XRControl)txForEnder).BorderWidth = 1f;
		((XRControl)txForEnder).CanGrow = false;
		((XRControl)txForEnder).Dpi = 254f;
		((XRControl)txForEnder).Font = new Font("Arial", 8f);
		((XRControl)txForEnder).LocationFloat = new PointFloat(755.1364f, 170.0948f);
		txForEnder.Multiline = true;
		((XRControl)txForEnder).Name = "txForEnder";
		((XRControl)txForEnder).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txForEnder).SizeF = new SizeF(703.8593f, 31.43321f);
		((XRControl)txForEnder).StylePriority.UseBorders = false;
		((XRControl)txForEnder).StylePriority.UseBorderWidth = false;
		((XRControl)txForEnder).StylePriority.UseFont = false;
		((XRControl)txForEnder).StylePriority.UseTextAlignment = false;
		((XRControl)txForEnder).Text = "R. Valdemar Rigout, 41 - Sertãozinho - Mauá";
		((XRControl)txForEnder).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel2).Borders = (BorderSide)2;
		((XRControl)xrLabel2).BorderWidth = 1f;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 5f);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(755.1364f, 112.2407f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(700.8592f, 24.95898f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "ENDEREÇO FORNECEDOR";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)txNF).Borders = (BorderSide)0;
		((XRControl)txNF).BorderWidth = 1f;
		((XRControl)txNF).CanGrow = false;
		((XRControl)txNF).Dpi = 254f;
		((XRControl)txNF).Font = new Font("Arial", 7f, FontStyle.Bold);
		((XRControl)txNF).LocationFloat = new PointFloat(29.00005f, 140.1997f);
		((XRControl)txNF).Name = "txNF";
		((XRControl)txNF).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNF).SizeF = new SizeF(304.0365f, 28.82692f);
		((XRControl)txNF).StylePriority.UseBorders = false;
		((XRControl)txNF).StylePriority.UseBorderWidth = false;
		((XRControl)txNF).StylePriority.UseFont = false;
		((XRControl)txNF).StylePriority.UseTextAlignment = false;
		((XRControl)txNF).Text = "9417";
		((XRControl)txNF).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel7).Borders = (BorderSide)6;
		((XRControl)xrLabel7).BorderWidth = 1f;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 5f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(25f, 112.2406f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(731.8537f, 24.959f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "NR NOTA FISCAL (N)";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)16;
		((XRControl)txDoca).Borders = (BorderSide)0;
		((XRControl)txDoca).BorderWidth = 1f;
		((XRControl)txDoca).CanGrow = false;
		((XRControl)txDoca).Dpi = 254f;
		((XRControl)txDoca).Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txDoca).LocationFloat = new PointFloat(755.1364f, 41.2407f);
		((XRControl)txDoca).Name = "txDoca";
		((XRControl)txDoca).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDoca).SizeF = new SizeF(703.8593f, 70f);
		((XRControl)txDoca).StylePriority.UseBorders = false;
		((XRControl)txDoca).StylePriority.UseBorderWidth = false;
		((XRControl)txDoca).StylePriority.UseFont = false;
		((XRControl)txDoca).StylePriority.UseTextAlignment = false;
		((XRControl)txDoca).TextAlignment = (TextAlignment)32;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).Font = new Font("Arial", 5f);
		((XRControl)xrLabel5).LocationFloat = new PointFloat(755.1364f, 15.64585f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(703.8592f, 24.59483f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).StylePriority.UseFont = false;
		((XRControl)xrLabel5).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel5).Text = "PORTARIA";
		((XRControl)xrLabel5).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel1).Borders = (BorderSide)4;
		((XRControl)xrLabel1).BorderWidth = 1f;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 5f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(25.42733f, 16.6458f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(731.4264f, 24.59484f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "DESTINATÁRIO";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 2f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(22.00002f, 893.3487f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).Padding = new PaddingInfo(0, 0, 5, 0, 254f);
		((XRControl)xrLine2).SizeF = new SizeF(1435.995f, 5.291687f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine2).StylePriority.UsePadding = false;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 2f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(20f, 0f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(1442.996f, 15.64585f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 2f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(18.00003f, 0f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 898.7708f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 2f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(1447.995f, 5.125122f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(11.00012f, 893.6457f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)txForNome).Borders = (BorderSide)1;
		((XRControl)txForNome).BorderWidth = 1f;
		((XRControl)txForNome).CanGrow = false;
		((XRControl)txForNome).Dpi = 254f;
		((XRControl)txForNome).Font = new Font("Arial", 9f);
		((XRControl)txForNome).LocationFloat = new PointFloat(755.1364f, 137.2679f);
		txForNome.Multiline = true;
		((XRControl)txForNome).Name = "txForNome";
		((XRControl)txForNome).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txForNome).SizeF = new SizeF(692.8591f, 32.82689f);
		((XRControl)txForNome).StylePriority.UseBorders = false;
		((XRControl)txForNome).StylePriority.UseBorderWidth = false;
		((XRControl)txForNome).StylePriority.UseFont = false;
		((XRControl)txForNome).StylePriority.UseTextAlignment = false;
		((XRControl)txForNome).Text = "SEMIL METALÚRGICA LTDA.";
		((XRControl)txForNome).TextAlignment = (TextAlignment)32;
		((XRControl)txDestNome).Borders = (BorderSide)4;
		((XRControl)txDestNome).BorderWidth = 1f;
		((XRControl)txDestNome).CanGrow = false;
		((XRControl)txDestNome).Dpi = 254f;
		((XRControl)txDestNome).Font = new Font("Arial", 9f, FontStyle.Bold);
		((XRControl)txDestNome).LocationFloat = new PointFloat(29.00003f, 41.24068f);
		txDestNome.Multiline = true;
		((XRControl)txDestNome).Name = "txDestNome";
		((XRControl)txDestNome).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDestNome).SizeF = new SizeF(727.8537f, 35.75744f);
		((XRControl)txDestNome).StylePriority.UseBorders = false;
		((XRControl)txDestNome).StylePriority.UseBorderWidth = false;
		((XRControl)txDestNome).StylePriority.UseFont = false;
		((XRControl)txDestNome).StylePriority.UseTextAlignment = false;
		((XRControl)txDestNome).Text = "METALÚRGICA NAKAYONE LTDA";
		((XRControl)txDestNome).TextAlignment = (TextAlignment)32;
		((XRControl)txDestEnd).Borders = (BorderSide)4;
		((XRControl)txDestEnd).BorderWidth = 1f;
		((XRControl)txDestEnd).CanGrow = false;
		((XRControl)txDestEnd).Dpi = 254f;
		((XRControl)txDestEnd).Font = new Font("Arial", 6f);
		((XRControl)txDestEnd).LocationFloat = new PointFloat(29.00003f, 76.99812f);
		((XRControl)txDestEnd).Name = "txDestEnd";
		((XRControl)txDestEnd).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDestEnd).SizeF = new SizeF(727.8537f, 35.24252f);
		((XRControl)txDestEnd).StylePriority.UseBorders = false;
		((XRControl)txDestEnd).StylePriority.UseBorderWidth = false;
		((XRControl)txDestEnd).StylePriority.UseFont = false;
		((XRControl)txDestEnd).StylePriority.UseTextAlignment = false;
		((XRControl)txDestEnd).Text = "VIA FRANCISCO BOTTI, 105 13315-000 - PINHAL - CABREÚVA";
		((XRControl)txDestEnd).TextAlignment = (TextAlignment)32;
		((XRControl)txDestEnd).WordWrap = false;
		txBarSerie.AutoModule = true;
		((XRControl)txBarSerie).Borders = (BorderSide)0;
		((XRControl)txBarSerie).Dpi = 254f;
		((XRControl)txBarSerie).Font = new Font("Segoe UI", 5f);
		((XRControl)txBarSerie).LocationFloat = new PointFloat(756.8537f, 799.2238f);
		txBarSerie.Module = 5.08f;
		((XRControl)txBarSerie).Name = "txBarSerie";
		((XRControl)txBarSerie).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txBarSerie).SizeF = new SizeF(702.142f, 99.41663f);
		((XRControl)txBarSerie).StylePriority.UseBorders = false;
		((XRControl)txBarSerie).StylePriority.UseFont = false;
		((XRControl)txBarSerie).StylePriority.UseTextAlignment = false;
		txBarSerie.Symbology = (BarCodeGeneratorBase)(object)symbology;
		((XRControl)txBarSerie).Text = "0314/15+001";
		((XRControl)txBarSerie).TextAlignment = (TextAlignment)512;
		txForEDI.AutoModule = true;
		((XRControl)txForEDI).Borders = (BorderSide)0;
		((XRControl)txForEDI).Dpi = 254f;
		((XRControl)txForEDI).Font = new Font("Segoe UI", 5f);
		((XRControl)txForEDI).LocationFloat = new PointFloat(29.41649f, 799.2238f);
		txForEDI.Module = 5.08f;
		((XRControl)txForEDI).Name = "txForEDI";
		((XRControl)txForEDI).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txForEDI).SizeF = new SizeF(713.3801f, 99.41663f);
		((XRControl)txForEDI).StylePriority.UseBorders = false;
		((XRControl)txForEDI).StylePriority.UseFont = false;
		((XRControl)txForEDI).StylePriority.UseTextAlignment = false;
		txForEDI.Symbology = (BarCodeGeneratorBase)(object)symbology2;
		((XRControl)txForEDI).Text = "SEMIL-MAUA-SP-09370830";
		((XRControl)txForEDI).TextAlignment = (TextAlignment)512;
		((XRControl)txForFantasia).Borders = (BorderSide)0;
		((XRControl)txForFantasia).BorderWidth = 1f;
		((XRControl)txForFantasia).CanGrow = false;
		((XRControl)txForFantasia).Dpi = 254f;
		((XRControl)txForFantasia).Font = new Font("Arial", 8f);
		((XRControl)txForFantasia).LocationFloat = new PointFloat(29.41649f, 632.9223f);
		((XRControl)txForFantasia).Name = "txForFantasia";
		((XRControl)txForFantasia).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txForFantasia).SizeF = new SizeF(414.2066f, 27.86761f);
		((XRControl)txForFantasia).StylePriority.UseBorders = false;
		((XRControl)txForFantasia).StylePriority.UseBorderWidth = false;
		((XRControl)txForFantasia).StylePriority.UseFont = false;
		((XRControl)txForFantasia).StylePriority.UseTextAlignment = false;
		((XRControl)txForFantasia).Text = "SEMIL";
		((XRControl)txForFantasia).TextAlignment = (TextAlignment)32;
		txBarQuant.Alignment = (TextAlignment)32;
		txBarQuant.AutoModule = true;
		((XRControl)txBarQuant).Borders = (BorderSide)0;
		((XRControl)txBarQuant).Dpi = 254f;
		((XRControl)txBarQuant).Font = new Font("Segoe UI", 5f);
		((XRControl)txBarQuant).LocationFloat = new PointFloat(29.00003f, 495.2651f);
		txBarQuant.Module = 5.08f;
		((XRControl)txBarQuant).Name = "txBarQuant";
		((XRControl)txBarQuant).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txBarQuant).SizeF = new SizeF(347.7409f, 110f);
		((XRControl)txBarQuant).StylePriority.UseBorders = false;
		((XRControl)txBarQuant).StylePriority.UseFont = false;
		((XRControl)txBarQuant).StylePriority.UseTextAlignment = false;
		txBarQuant.Symbology = (BarCodeGeneratorBase)(object)symbology3;
		((XRControl)txBarQuant).Text = "400";
		((XRControl)txBarQuant).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel10).Borders = (BorderSide)2;
		((XRControl)xrLabel10).BorderWidth = 1f;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 5f);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(22.00002f, 280.0948f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(1429.995f, 24.71661f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "NR PEÇA (P)";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)16;
		txBarForFant.Alignment = (TextAlignment)32;
		txBarForFant.AutoModule = true;
		((XRControl)txBarForFant).Borders = (BorderSide)0;
		((XRControl)txBarForFant).Dpi = 254f;
		((XRControl)txBarForFant).Font = new Font("Segoe UI", 5f);
		((XRControl)txBarForFant).LocationFloat = new PointFloat(30.42731f, 660.7899f);
		txBarForFant.Module = 5.08f;
		((XRControl)txBarForFant).Name = "txBarForFant";
		((XRControl)txBarForFant).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txBarForFant).SizeF = new SizeF(413.1958f, 110f);
		((XRControl)txBarForFant).StylePriority.UseBorders = false;
		((XRControl)txBarForFant).StylePriority.UseFont = false;
		((XRControl)txBarForFant).StylePriority.UseTextAlignment = false;
		txBarForFant.Symbology = (BarCodeGeneratorBase)(object)symbology4;
		((XRControl)txBarForFant).Text = "SEMIL";
		((XRControl)txBarForFant).TextAlignment = (TextAlignment)512;
		txBarNF.AutoModule = true;
		((XRControl)txBarNF).Borders = (BorderSide)0;
		((XRControl)txBarNF).Dpi = 254f;
		((XRControl)txBarNF).Font = new Font("Segoe UI", 5f);
		((XRControl)txBarNF).LocationFloat = new PointFloat(29.41649f, 170.0948f);
		txBarNF.Module = 5.08f;
		((XRControl)txBarNF).Name = "txBarNF";
		((XRControl)txBarNF).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txBarNF).SizeF = new SizeF(303.62f, 110f);
		((XRControl)txBarNF).StylePriority.UseBorders = false;
		((XRControl)txBarNF).StylePriority.UseFont = false;
		((XRControl)txBarNF).StylePriority.UseTextAlignment = false;
		txBarNF.Symbology = (BarCodeGeneratorBase)(object)symbology5;
		((XRControl)txBarNF).Text = "9417";
		((XRControl)txBarNF).TextAlignment = (TextAlignment)512;
		((XRControl)txProd).Borders = (BorderSide)0;
		((XRControl)txProd).BorderWidth = 1f;
		((XRControl)txProd).CanGrow = false;
		((XRControl)txProd).Dpi = 254f;
		((XRControl)txProd).Font = new Font("Arial", 11f, FontStyle.Bold);
		((XRControl)txProd).LocationFloat = new PointFloat(521.015f, 290.0948f);
		((XRControl)txProd).Name = "txProd";
		((XRControl)txProd).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txProd).SizeF = new SizeF(504.6969f, 39.82684f);
		((XRControl)txProd).StylePriority.UseBorders = false;
		((XRControl)txProd).StylePriority.UseBorderWidth = false;
		((XRControl)txProd).StylePriority.UseFont = false;
		((XRControl)txProd).StylePriority.UseTextAlignment = false;
		((XRControl)txProd).Text = "02.04.00.003-A";
		((XRControl)txProd).TextAlignment = (TextAlignment)32;
		txBarProd.Alignment = (TextAlignment)32;
		txBarProd.AutoModule = true;
		((XRControl)txBarProd).Borders = (BorderSide)0;
		((XRControl)txBarProd).Dpi = 254f;
		((XRControl)txBarProd).Font = new Font("Segoe UI", 5f);
		((XRControl)txBarProd).LocationFloat = new PointFloat(521.015f, 329.9216f);
		txBarProd.Module = 5.08f;
		((XRControl)txBarProd).Name = "txBarProd";
		((XRControl)txBarProd).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		((XRControl)txBarProd).SizeF = new SizeF(504.7f, 110f);
		((XRControl)txBarProd).StylePriority.UseBorders = false;
		((XRControl)txBarProd).StylePriority.UseFont = false;
		((XRControl)txBarProd).StylePriority.UseTextAlignment = false;
		txBarProd.Symbology = (BarCodeGeneratorBase)(object)symbology6;
		((XRControl)txBarProd).Text = "02.04.00.003-A";
		((XRControl)txBarProd).TextAlignment = (TextAlignment)512;
		((XRControl)xrLabel29).Borders = (BorderSide)3;
		((XRControl)xrLabel29).BorderWidth = 1f;
		((XRControl)xrLabel29).Dpi = 254f;
		((XRControl)xrLabel29).Font = new Font("Arial", 5f);
		((XRControl)xrLabel29).LocationFloat = new PointFloat(756.8538f, 774.7899f);
		xrLabel29.Multiline = true;
		((XRControl)xrLabel29).Name = "xrLabel29";
		((XRControl)xrLabel29).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel29).SizeF = new SizeF(698.142f, 123.8505f);
		((XRControl)xrLabel29).StylePriority.UseBorders = false;
		((XRControl)xrLabel29).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel29).StylePriority.UseFont = false;
		((XRControl)xrLabel29).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel29).Text = "NR LOTE (H)";
		((XRControl)xrLabel29).TextAlignment = (TextAlignment)1;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 49.72916f;
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
		((XtraReport)this).Margins = new Margins(0, 0, 50, 0);
		((XtraReport)this).PageHeight = 1016;
		((XtraReport)this).PageWidth = 1516;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).ShowPrintMarginsWarning = false;
		((XtraReport)this).ShowPrintStatusDialog = false;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "18.1";
		((ISupportInitialize)this).EndInit();
	}
}
