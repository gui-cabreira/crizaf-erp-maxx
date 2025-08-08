using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

internal class rptEtiquetaDispofix : XtraReport
{
	private IList<ClasseEtiquetaDispofix> listagemEtiquetas;

	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRPanel xrPanel1;

	private XRLabel xrLabel12;

	private XRLabel xrLabel11;

	private XRLabel txTelefone;

	private XRLabel txEmpresa;

	private XRPictureBox imLogo;

	private XRLabel lbTransportadora;

	private XRLabel lbEntrega;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel colEntrega;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLine xrLinhaCabecalho;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private ObjectDataSource objectDataSource1;

	private XRLabel lbQuantidade;

	private XRLabel lbPedidoCliente;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRLabel lbDescricao;

	private XRLabel xrLabel4;

	public rptEtiquetaDispofix(IList<ClasseEtiquetaDispofix> ListagemEtiquetas)
	{
		InitializeComponent();
		listagemEtiquetas = ListagemEtiquetas;
		objectDataSource1.DataSource = listagemEtiquetas;
	}

	private void rptEtiquetaDispofix_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade sociedade = ModuloParametros.ObterSociedade(1);
		imLogo.Image = sociedade.Logo;
		((XRControl)txEmpresa).Text = sociedade.NomeFantasia;
		((XRControl)txTelefone).Text = sociedade.Telefone;
	}

	private void Detail_BeforePrint(object sender, PrintEventArgs e)
	{
		ClasseEtiquetaDispofix classeEtiquetaDispofix = (ClasseEtiquetaDispofix)((XtraReportBase)this).GetCurrentRow();
		if (classeEtiquetaDispofix.Embalagem)
		{
			((XRControl)lbEntrega).Text = "Código:";
			((XRControl)lbTransportadora).Text = "Pedido:";
			((XRControl)lbQuantidade).Visible = true;
			((XRControl)lbDescricao).Visible = true;
			((XRControl)lbPedidoCliente).Visible = true;
			((XRControl)xrLinhaCabecalho).Visible = false;
		}
		else
		{
			((XRControl)lbEntrega).Text = "Entrega:";
			((XRControl)lbTransportadora).Text = "Transportadora:";
			((XRControl)lbQuantidade).Visible = false;
			((XRControl)lbDescricao).Visible = false;
			((XRControl)lbPedidoCliente).Visible = false;
			((XRControl)xrLinhaCabecalho).Visible = true;
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
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086b: Expected O, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0937: Expected O, but got Unknown
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcf: Expected O, but got Unknown
		//IL_0ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a8: Expected O, but got Unknown
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_117b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Expected O, but got Unknown
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1254: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Expected O, but got Unknown
		//IL_1281: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1333: Expected O, but got Unknown
		//IL_135a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1385: Unknown result type (might be due to invalid IL or missing references)
		//IL_1400: Unknown result type (might be due to invalid IL or missing references)
		//IL_1469: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_154b: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a5: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		Detail = new DetailBand();
		xrPanel1 = new XRPanel();
		lbPedidoCliente = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		lbDescricao = new XRLabel();
		xrLabel4 = new XRLabel();
		lbQuantidade = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel11 = new XRLabel();
		txTelefone = new XRLabel();
		txEmpresa = new XRLabel();
		imLogo = new XRPictureBox();
		lbTransportadora = new XRLabel();
		lbEntrega = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		colEntrega = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrLinhaCabecalho = new XRLine();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		objectDataSource1 = new ObjectDataSource(components);
		((ISupportInitialize)objectDataSource1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[1] { (XRControl)xrPanel1 });
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 570f;
		Detail.MultiColumn.ColumnWidth = 1050f;
		Detail.MultiColumn.Layout = (ColumnLayout)1;
		Detail.MultiColumn.Mode = (MultiColumnMode)2;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)Detail).BeforePrint += Detail_BeforePrint;
		((XRControl)xrPanel1).Borders = (BorderSide)15;
		((XRControl)xrPanel1).CanGrow = false;
		((XRControl)xrPanel1).Controls.AddRange((XRControl[])(object)new XRControl[24]
		{
			(XRControl)lbPedidoCliente,
			(XRControl)xrLabel10,
			(XRControl)xrLabel9,
			(XRControl)lbDescricao,
			(XRControl)xrLabel4,
			(XRControl)lbQuantidade,
			(XRControl)xrLabel12,
			(XRControl)xrLabel11,
			(XRControl)txTelefone,
			(XRControl)txEmpresa,
			(XRControl)imLogo,
			(XRControl)lbTransportadora,
			(XRControl)lbEntrega,
			(XRControl)xrLabel8,
			(XRControl)xrLabel7,
			(XRControl)xrLabel6,
			(XRControl)xrLabel5,
			(XRControl)colEntrega,
			(XRControl)xrLabel3,
			(XRControl)xrLabel2,
			(XRControl)xrLabel1,
			(XRControl)xrLinhaCabecalho,
			(XRControl)xrLine2,
			(XRControl)xrLine1
		});
		((XRControl)xrPanel1).Dpi = 254f;
		((XRControl)xrPanel1).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrPanel1).Name = "xrPanel1";
		((XRControl)xrPanel1).SizeF = new SizeF(1050f, 570f);
		((XRControl)lbPedidoCliente).Borders = (BorderSide)0;
		((XRControl)lbPedidoCliente).CanGrow = false;
		((XRControl)lbPedidoCliente).Dpi = 254f;
		((XRControl)lbPedidoCliente).LocationFloat = new PointFloat(487.0417f, 426.7499f);
		((XRControl)lbPedidoCliente).Name = "lbPedidoCliente";
		((XRControl)lbPedidoCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbPedidoCliente).SizeF = new SizeF(272.2292f, 58.41998f);
		((XRControl)lbPedidoCliente).StylePriority.UseBorders = false;
		((XRControl)lbPedidoCliente).Text = "Pedido Cliente:";
		((XRControl)lbPedidoCliente).WordWrap = false;
		((XRControl)xrLabel10).Borders = (BorderSide)0;
		((XRControl)xrLabel10).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "PedidoCliente")
		});
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).LocationFloat = new PointFloat(771.0001f, 426.7499f);
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(254f, 58.42f);
		((XRControl)xrLabel10).StylePriority.UseBorders = false;
		((XRControl)xrLabel10).Text = "xrLabel10";
		((XRControl)xrLabel9).Borders = (BorderSide)0;
		((XRControl)xrLabel9).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Pedido")
		});
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).LocationFloat = new PointFloat(164.1667f, 426.7499f);
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(254f, 58.42f);
		((XRControl)xrLabel9).StylePriority.UseBorders = false;
		((XRControl)xrLabel9).Text = "xrLabel9";
		((XRControl)lbDescricao).Borders = (BorderSide)0;
		((XRControl)lbDescricao).CanGrow = false;
		((XRControl)lbDescricao).Dpi = 254f;
		((XRControl)lbDescricao).LocationFloat = new PointFloat(17.81254f, 341.4199f);
		((XRControl)lbDescricao).Name = "lbDescricao";
		((XRControl)lbDescricao).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbDescricao).SizeF = new SizeF(145.2292f, 58.42f);
		((XRControl)lbDescricao).StylePriority.UseBorders = false;
		((XRControl)lbDescricao).Text = "Descr.:";
		((XRControl)lbDescricao).WordWrap = false;
		((XRControl)xrLabel4).Borders = (BorderSide)0;
		((XRControl)xrLabel4).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Descrição")
		});
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).LocationFloat = new PointFloat(163.0417f, 341.42f);
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(861.958f, 58.41998f);
		((XRControl)xrLabel4).StylePriority.UseBorders = false;
		((XRControl)xrLabel4).Text = "xrLabel4";
		((XRControl)lbQuantidade).Borders = (BorderSide)0;
		((XRControl)lbQuantidade).CanGrow = false;
		((XRControl)lbQuantidade).Dpi = 254f;
		((XRControl)lbQuantidade).LocationFloat = new PointFloat(789.8123f, 283.0001f);
		((XRControl)lbQuantidade).Name = "lbQuantidade";
		((XRControl)lbQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbQuantidade).SizeF = new SizeF(145.2292f, 58.42f);
		((XRControl)lbQuantidade).StylePriority.UseBorders = false;
		((XRControl)lbQuantidade).Text = "Qtd:";
		((XRControl)lbQuantidade).WordWrap = false;
		((XRControl)xrLabel12).Borders = (BorderSide)0;
		((XRControl)xrLabel12).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Quantidade")
		});
		((XRControl)xrLabel12).Dpi = 254f;
		((XRControl)xrLabel12).LocationFloat = new PointFloat(935.0414f, 283f);
		((XRControl)xrLabel12).Name = "xrLabel12";
		((XRControl)xrLabel12).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel12).SizeF = new SizeF(89.95831f, 58.42004f);
		((XRControl)xrLabel12).StylePriority.UseBorders = false;
		((XRControl)xrLabel12).Text = "xrLabel12";
		((XRControl)xrLabel11).Borders = (BorderSide)0;
		((XRControl)xrLabel11).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "CodigoPeca")
		});
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).LocationFloat = new PointFloat(164.1667f, 283.0001f);
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(321.2085f, 58.42001f);
		((XRControl)xrLabel11).StylePriority.UseBorders = false;
		((XRControl)xrLabel11).Text = "xrLabel11";
		((XRControl)txTelefone).Borders = (BorderSide)0;
		((XRControl)txTelefone).Dpi = 254f;
		((XRControl)txTelefone).LocationFloat = new PointFloat(517.0001f, 72.83664f);
		((XRControl)txTelefone).Name = "txTelefone";
		((XRControl)txTelefone).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTelefone).SizeF = new SizeF(507.9996f, 42.33331f);
		((XRControl)txTelefone).StylePriority.UseBorders = false;
		((XRControl)txTelefone).StylePriority.UseTextAlignment = false;
		((XRControl)txTelefone).Text = "xrLabel11";
		((XRControl)txTelefone).TextAlignment = (TextAlignment)2;
		((XRControl)txEmpresa).Borders = (BorderSide)0;
		((XRControl)txEmpresa).Dpi = 254f;
		((XRControl)txEmpresa).LocationFloat = new PointFloat(517.0001f, 25.00001f);
		((XRControl)txEmpresa).Name = "txEmpresa";
		((XRControl)txEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmpresa).SizeF = new SizeF(507.9996f, 47.83666f);
		((XRControl)txEmpresa).StylePriority.UseBorders = false;
		((XRControl)txEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txEmpresa).Text = "txEmpresa";
		((XRControl)txEmpresa).TextAlignment = (TextAlignment)2;
		((XRControl)imLogo).Borders = (BorderSide)0;
		((XRControl)imLogo).Dpi = 254f;
		imLogo.ImageAlignment = (ImageAlignment)1;
		((XRControl)imLogo).LocationFloat = new PointFloat(25.00009f, 25.00001f);
		((XRControl)imLogo).Name = "imLogo";
		((XRControl)imLogo).SizeF = new SizeF(460.375f, 90.17f);
		imLogo.Sizing = (ImageSizeMode)4;
		((XRControl)imLogo).StylePriority.UseBorders = false;
		((XRControl)lbTransportadora).Borders = (BorderSide)0;
		((XRControl)lbTransportadora).CanGrow = false;
		((XRControl)lbTransportadora).Dpi = 254f;
		((XRControl)lbTransportadora).LocationFloat = new PointFloat(17.81254f, 426.75f);
		((XRControl)lbTransportadora).Name = "lbTransportadora";
		((XRControl)lbTransportadora).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbTransportadora).SizeF = new SizeF(339.3751f, 58.42001f);
		((XRControl)lbTransportadora).StylePriority.UseBorders = false;
		((XRControl)lbTransportadora).Text = "Transportadora:";
		((XRControl)lbTransportadora).WordWrap = false;
		((XRControl)lbEntrega).Borders = (BorderSide)0;
		((XRControl)lbEntrega).CanGrow = false;
		((XRControl)lbEntrega).Dpi = 254f;
		((XRControl)lbEntrega).LocationFloat = new PointFloat(17.81254f, 283f);
		((XRControl)lbEntrega).Name = "lbEntrega";
		((XRControl)lbEntrega).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbEntrega).SizeF = new SizeF(145.2292f, 58.42f);
		((XRControl)lbEntrega).StylePriority.UseBorders = false;
		((XRControl)lbEntrega).Text = "Entrega:";
		((XRControl)lbEntrega).WordWrap = false;
		((XRControl)xrLabel8).Borders = (BorderSide)0;
		((XRControl)xrLabel8).CanGrow = false;
		((XRControl)xrLabel8).Dpi = 254f;
		((XRControl)xrLabel8).LocationFloat = new PointFloat(504.0626f, 198.7725f);
		((XRControl)xrLabel8).Name = "xrLabel8";
		((XRControl)xrLabel8).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel8).SizeF = new SizeF(266.9375f, 58.42003f);
		((XRControl)xrLabel8).StylePriority.UseBorders = false;
		((XRControl)xrLabel8).Text = "Nota Fiscal No.";
		((XRControl)xrLabel8).WordWrap = false;
		((XRControl)xrLabel7).Borders = (BorderSide)0;
		((XRControl)xrLabel7).CanGrow = false;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).LocationFloat = new PointFloat(17.81254f, 198.7725f);
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(145.2292f, 58.42f);
		((XRControl)xrLabel7).StylePriority.UseBorders = false;
		((XRControl)xrLabel7).Text = "Emissão:";
		((XRControl)xrLabel7).WordWrap = false;
		((XRControl)xrLabel6).Borders = (BorderSide)0;
		((XRControl)xrLabel6).CanGrow = false;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).LocationFloat = new PointFloat(17.81248f, 140.3525f);
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(145.2292f, 58.42f);
		((XRControl)xrLabel6).StylePriority.UseBorders = false;
		((XRControl)xrLabel6).Text = "Cliente:";
		((XRControl)xrLabel6).WordWrap = false;
		((XRControl)xrLabel5).Borders = (BorderSide)0;
		((XRControl)xrLabel5).CanGrow = false;
		((XRControl)xrLabel5).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "NomeTransportadora")
		});
		((XRControl)xrLabel5).Dpi = 254f;
		((XRControl)xrLabel5).LocationFloat = new PointFloat(17.81254f, 497.3109f);
		((XRControl)xrLabel5).Name = "xrLabel5";
		((XRControl)xrLabel5).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel5).SizeF = new SizeF(860.9583f, 58.42001f);
		((XRControl)xrLabel5).StylePriority.UseBorders = false;
		((XRControl)xrLabel5).Text = "xrLabel5";
		((XRControl)colEntrega).Borders = (BorderSide)0;
		((XRControl)colEntrega).CanGrow = false;
		((XRControl)colEntrega).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "EndereçoEntrega")
		});
		((XRControl)colEntrega).Dpi = 254f;
		((XRControl)colEntrega).LocationFloat = new PointFloat(164.0417f, 283f);
		((XRControl)colEntrega).Name = "colEntrega";
		((XRControl)colEntrega).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)colEntrega).SizeF = new SizeF(860.9583f, 135.75f);
		((XRControl)colEntrega).StylePriority.UseBorders = false;
		((XRControl)colEntrega).Text = "colEntrega";
		((XRControl)xrLabel3).Borders = (BorderSide)0;
		((XRControl)xrLabel3).CanGrow = false;
		((XRControl)xrLabel3).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "NotaFiscal")
		});
		((XRControl)xrLabel3).Dpi = 254f;
		((XRControl)xrLabel3).LocationFloat = new PointFloat(771.0001f, 198.7725f);
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel3).SizeF = new SizeF(254f, 58.42f);
		((XRControl)xrLabel3).StylePriority.UseBorders = false;
		((XRControl)xrLabel3).Text = "xrLabel3";
		((XRControl)xrLabel2).Borders = (BorderSide)0;
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Emissão")
		});
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).LocationFloat = new PointFloat(164.0417f, 198.7725f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(301.6251f, 58.42001f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).Text = "xrLabel2";
		((XRControl)xrLabel1).Borders = (BorderSide)0;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).DataBindings.AddRange((XRBinding[])(object)new XRBinding[1]
		{
			new XRBinding("Text", (object)null, "Cliente")
		});
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).LocationFloat = new PointFloat(164.0417f, 139.3525f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(860.9583f, 58.42f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).Text = "xrLabel1";
		((XRControl)xrLinhaCabecalho).Dpi = 254f;
		xrLinhaCabecalho.LineWidth = 3f;
		((XRControl)xrLinhaCabecalho).LocationFloat = new PointFloat(0f, 421.75f);
		((XRControl)xrLinhaCabecalho).Name = "xrLinhaCabecalho";
		((XRControl)xrLinhaCabecalho).SizeF = new SizeF(1029.229f, 5f);
		((XRControl)xrLine2).Dpi = 254f;
		xrLine2.LineWidth = 3f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(0f, 275f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(1029.229f, 5f);
		((XRControl)xrLine1).Dpi = 254f;
		xrLine1.LineWidth = 3f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(4f, 134.3526f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(1029.229f, 5f);
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 60f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)TopMargin).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)TopMargin).TextAlignment = (TextAlignment)1;
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 130f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)BottomMargin).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)BottomMargin).TextAlignment = (TextAlignment)1;
		objectDataSource1.DataSource = typeof(ClasseEtiquetaDispofix);
		((DataComponentBase)objectDataSource1).Name = "objectDataSource1";
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[3]
		{
			(Band)Detail,
			(Band)TopMargin,
			(Band)BottomMargin
		});
		((XtraReport)this).ComponentStorage.AddRange(new IComponent[1] { (IComponent)objectDataSource1 });
		((XtraReportBase)this).DataSource = objectDataSource1;
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XtraReport)this).Margins = new Margins(0, 0, 60, 130);
		((XtraReport)this).PageHeight = 2970;
		((XtraReport)this).PageWidth = 2100;
		((XtraReport)this).PaperKind = PaperKind.A4;
		((XtraReportBase)this).ReportPrintOptions.DetailCountOnEmptyDataSource = 10;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 25f;
		((XtraReport)this).Version = "16.1";
		((XRControl)this).BeforePrint += rptEtiquetaDispofix_BeforePrint;
		((ISupportInitialize)objectDataSource1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
