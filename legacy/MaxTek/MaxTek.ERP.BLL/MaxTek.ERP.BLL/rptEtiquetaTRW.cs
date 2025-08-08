using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiquetaTRW : XtraReport
{
	private bool _isQdeQuebrada = false;

	private NotaFiscalNotasFiscaisItens _itemNotaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private PageFooterBand PageFooter;

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

	private XRLine xrLine1;

	private XRLine xrLine4;

	private XRLine xrLine3;

	private XRLabel xrLabel9;

	private XRLabel txItemNota;

	private XRLabel xrLabel10;

	private XRLabel txPecaInterno;

	private XRPictureBox imLogoEmpresa;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLine xrLine5;

	private XRLabel xrLabel8;

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

	public rptEtiquetaTRW()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = ItemNotaFiscal.NotaFiscalRef.Emitente;
		((XRControl)txData).Text = DateTime.Today.ToShortDateString();
		((XRControl)txCliente).Text = ItemNotaFiscal.NotaFiscalRef.Entidade.RazaoSocial;
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
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1128: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1384: Unknown result type (might be due to invalid IL or missing references)
		//IL_1442: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_1621: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f8: Unknown result type (might be due to invalid IL or missing references)
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLine5 = new XRLine();
		xrLabel10 = new XRLabel();
		txPecaInterno = new XRLabel();
		xrLabel9 = new XRLabel();
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
		((Band)Detail).Expanded = false;
		((XRControl)Detail).HeightF = 984f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BorderWidth = 3f;
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[24]
		{
			(XRControl)xrLabel8,
			(XRControl)xrLine5,
			(XRControl)xrLabel10,
			(XRControl)txPecaInterno,
			(XRControl)xrLabel9,
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
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa,
			(XRControl)txItemNota
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).ForeColor = Color.Black;
		((XRControl)PageHeader).HeightF = 895.3336f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 10, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UseForeColor = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLine5).Borders = (BorderSide)0;
		((XRControl)xrLine5).Dpi = 254f;
		((XRControl)xrLine5).ForeColor = Color.Black;
		xrLine5.LineWidth = 4f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(10.77066f, 806.4169f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(596.2293f, 13.64581f);
		((XRControl)xrLine5).StylePriority.UseBorders = false;
		((XRControl)xrLine5).StylePriority.UseForeColor = false;
		((XRControl)xrLabel10).Borders = (BorderSide)0;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 14.25f, FontStyle.Bold);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(317.7707f, 756.0627f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(21f, 64f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).Text = "/";
		((XRControl)txPecaInterno).Borders = (BorderSide)0;
		((XRControl)txPecaInterno).CanGrow = false;
		((XRControl)txPecaInterno).Dpi = 254f;
		((XRControl)txPecaInterno).Font = new Font("Arial", 22f, FontStyle.Bold);
		((XRControl)txPecaInterno).LocationFloat = new PointFloat(344.7706f, 729.9377f);
		((XRControl)txPecaInterno).Name = "txPecaInterno";
		((XRControl)txPecaInterno).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecaInterno).SizeF = new SizeF(230.4375f, 89.12494f);
		((XRControl)txPecaInterno).StylePriority.UseBorders = false;
		((XRControl)txPecaInterno).StylePriority.UseFont = false;
		((XRControl)txPecaInterno).StylePriority.UseTextAlignment = false;
		((XRControl)txPecaInterno).Text = "54329";
		((XRControl)txPecaInterno).TextAlignment = (TextAlignment)256;
		((XRControl)txPecaInterno).WordWrap = false;
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 14.25f, FontStyle.Bold);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(217.7706f, 756.0627f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(21f, 64f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).Text = "/";
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).LocationFloat = new PointFloat(37.77063f, 83.97937f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).Text = "Cliente";
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).LocationFloat = new PointFloat(37.77063f, 182.4794f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).Text = "Fornecedor";
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).LocationFloat = new PointFloat(37.77063f, 278.2502f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).Text = "Data Emissão";
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).LocationFloat = new PointFloat(37.77063f, 375.3127f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).Text = "Peça (Descrição)";
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).LocationFloat = new PointFloat(37.77063f, 524.2295f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).Text = "Código Peça";
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).LocationFloat = new PointFloat(37.77063f, 618.6461f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).Text = "Quantidade";
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).LocationFloat = new PointFloat(37.77063f, 714.0627f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(254f, 42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).Text = "No Doc. Fiscal";
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCliente).LocationFloat = new PointFloat(37.77063f, 125.9795f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(561f, 42f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).Text = "Allevard Molas do Brasil";
		((XRControl)txEmpresa).Borders = (BorderSide)0;
		((XRControl)txEmpresa).CanGrow = false;
		((XRControl)txEmpresa).Dpi = 254f;
		((XRControl)txEmpresa).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txEmpresa).LocationFloat = new PointFloat(37.77063f, 224.4794f);
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
		((XRControl)txData).LocationFloat = new PointFloat(37.77063f, 320.2502f);
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
		((XRControl)txDescricao).LocationFloat = new PointFloat(37.77063f, 417.3129f);
		txDescricao.Multiline = true;
		((XRControl)txDescricao).Name = "txDescricao";
		((XRControl)txDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricao).SizeF = new SizeF(466f, 95.49994f);
		((XRControl)txDescricao).StylePriority.UseBorders = false;
		((XRControl)txDescricao).StylePriority.UseFont = false;
		((XRControl)txDescricao).Text = "Parafuso Mx1,5 adasd asdasd asdasd asd asdas das dasd asd as";
		((XRControl)txCodigoCliente).Borders = (BorderSide)0;
		((XRControl)txCodigoCliente).CanGrow = false;
		((XRControl)txCodigoCliente).Dpi = 254f;
		((XRControl)txCodigoCliente).Font = new Font("Arial", 10f, FontStyle.Bold);
		((XRControl)txCodigoCliente).LocationFloat = new PointFloat(37.77063f, 566.2294f);
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
		((XRControl)txQuantidade).LocationFloat = new PointFloat(37.77063f, 660.6461f);
		((XRControl)txQuantidade).Name = "txQuantidade";
		((XRControl)txQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txQuantidade).SizeF = new SizeF(180f, 42f);
		((XRControl)txQuantidade).StylePriority.UseBorders = false;
		((XRControl)txQuantidade).StylePriority.UseFont = false;
		((XRControl)txQuantidade).Text = "200";
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Arial", 14.25f, FontStyle.Bold);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(37.77063f, 756.0627f);
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
		((XRControl)xrLine1).LocationFloat = new PointFloat(10.77066f, 36.97941f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(596.2293f, 13.64583f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 4f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(5.770643f, 36.97941f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(14.22915f, 783.0834f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).BackColor = Color.Transparent;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).BorderWidth = 3f;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 4f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(598.7707f, 36.97941f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(13.22919f, 783.0834f);
		((XRControl)xrLine4).StylePriority.UseBackColor = false;
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseBorderWidth = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(344.7706f, 61.97942f);
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
		((XRControl)txItemNota).Font = new Font("Arial", 14.25f, FontStyle.Bold);
		((XRControl)txItemNota).LocationFloat = new PointFloat(246.7706f, 756.0627f);
		((XRControl)txItemNota).Name = "txItemNota";
		((XRControl)txItemNota).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItemNota).SizeF = new SizeF(66f, 64f);
		((XRControl)txItemNota).StylePriority.UseBorders = false;
		((XRControl)txItemNota).StylePriority.UseFont = false;
		((XRControl)txItemNota).StylePriority.UseTextAlignment = false;
		((XRControl)txItemNota).Text = "99";
		((XRControl)txItemNota).TextAlignment = (TextAlignment)1;
		((XRControl)PageFooter).Dpi = 254f;
		((Band)PageFooter).Expanded = false;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
		((XRControl)PageFooter).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)PageFooter).TextAlignment = (TextAlignment)1;
		((XRControl)topMarginBand1).Dpi = 254f;
		((XRControl)topMarginBand1).HeightF = 3f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).Dpi = 254f;
		((XRControl)bottomMarginBand1).HeightF = 56f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).LocationFloat = new PointFloat(344.7706f, 687.9377f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(230.4375f, 42f);
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
		((XtraReport)this).Margins = new Margins(0, 10, 3, 56);
		((XtraReport)this).PageHeight = 910;
		((XtraReport)this).PageWidth = 630;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "11.2";
		((ISupportInitialize)this).EndInit();
	}
}
