using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.BLL.RPT.Etiquetas;

public class rptEtiquetaFlexGrd : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private XRBarCode bceNotaFiscal;

	private XRLabel lblEmpresaRemetente;

	private XRLabel lblEnderecoRemetente;

	private XRLabel lblCidadeRemetente;

	private XRBarCode bcePedidoVendas;

	private XRLabel lblEmpresaDestinatario;

	private XRLabel lblEnderecoDestinatario;

	private XRLabel lblCidadeDestinatario;

	private XRLabel lblPeso;

	private XRBarCode bceProdutoAcabado;

	private XRBarCode bcePecas;

	private XRLabel lblData;

	private XRBarCode bceData;

	private XRBarCode bceBr;

	private XRBarCode bceQuantidade;

	private PageFooterBand PageFooter;

	private XRLabel lblNotaFiscal;

	private XRLabel lblPedidoVendas;

	private XRLabel lblBr;

	private XRLabel lblQuantidade;

	private XRLabel lblPecas;

	private XRLabel lblProdutoAcabado;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	public string empresaRemetente { get; set; }

	public string enderecoRemetente { get; set; }

	public string cidadeRemetente { get; set; }

	public string empresaDestinatario { get; set; }

	public string enderecoDestinatario { get; set; }

	public string cidadeDestinatario { get; set; }

	public decimal peso { get; set; }

	public string notaFiscal { get; set; }

	public string pedidoVendas { get; set; }

	public string ProdutoAcabado { get; set; }

	public int caixaTotal { get; set; }

	public int caixa { get; set; }

	public DateTime data { get; set; }

	public int Quantidade { get; set; }

	public rptEtiquetaFlexGrd()
	{
		InitializeComponent();
	}

	public rptEtiquetaFlexGrd(string empresaRemetente, string enderecoRemetente, string cidadeRemetente, string empresaDestinatario, string enderecoDestinatario, string cidadeDestinatario, decimal peso, string notaFiscal, string pedidoVendas, string ProdutoAcabado, int caixa, int caixaTotal, DateTime data, int Quantidade)
		: this()
	{
		this.empresaRemetente = empresaRemetente;
		this.enderecoRemetente = enderecoRemetente;
		this.cidadeRemetente = cidadeRemetente;
		this.empresaDestinatario = empresaDestinatario;
		this.enderecoDestinatario = enderecoDestinatario;
		this.cidadeDestinatario = cidadeDestinatario;
		this.peso = peso;
		this.notaFiscal = notaFiscal;
		this.pedidoVendas = pedidoVendas;
		this.ProdutoAcabado = ProdutoAcabado;
		this.caixa = caixa;
		this.caixaTotal = caixaTotal;
		this.data = data;
		this.Quantidade = Quantidade;
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)lblEmpresaRemetente).Text = empresaRemetente.ToUpper();
		((XRControl)lblEnderecoRemetente).Text = enderecoRemetente.ToUpper();
		((XRControl)lblCidadeRemetente).Text = cidadeRemetente.ToUpper();
		((XRControl)lblEmpresaDestinatario).Text = empresaDestinatario.ToUpper();
		((XRControl)lblEnderecoDestinatario).Text = enderecoDestinatario.ToUpper();
		((XRControl)lblCidadeDestinatario).Text = cidadeDestinatario.ToUpper();
		((XRControl)lblPeso).Text = $"PKG. WT:{peso} KG";
		((XRControl)bceNotaFiscal).Text = $"3SN80326+{notaFiscal}";
		((XRControl)lblNotaFiscal).Text = $"(3S) PKG. ID:N80326 - {notaFiscal}";
		((XRControl)bcePedidoVendas).Text = string.Format("K{0}", pedidoVendas.Replace("/", "-"));
		((XRControl)lblPedidoVendas).Text = $"(K) TRANS. ID:{pedidoVendas}";
		((XRControl)bceProdutoAcabado).Text = $"P{ProdutoAcabado.ToUpper()}";
		((XRControl)lblProdutoAcabado).Text = $"(P) CUST. PART NO:{ProdutoAcabado.ToUpper()}";
		((XRControl)bcePecas).Text = string.Format("13Q{0}/{1}", caixa.ToString("D2"), caixaTotal.ToString("D2"));
		((XRControl)lblPecas).Text = string.Format("(13Q) BOX:{0}/{1}", caixa.ToString("D2"), caixaTotal.ToString("D2"));
		((XRControl)bceData).Text = data.ToString("yyMMdd");
		((XRControl)lblData).Text = string.Format("(9D) DATE CODE:{0}", data.ToString("yyMMdd"));
		((XRControl)bceBr).Text = "4LBR";
		((XRControl)lblBr).Text = "(4L) BR";
		((XRControl)bceQuantidade).Text = $"Q{Quantidade}";
		((XRControl)lblQuantidade).Text = $"(Q) QUANTITY:{Quantidade}";
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1074: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Unknown result type (might be due to invalid IL or missing references)
		//IL_1199: Unknown result type (might be due to invalid IL or missing references)
		//IL_124e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1286: Unknown result type (might be due to invalid IL or missing references)
		//IL_133b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1379: Unknown result type (might be due to invalid IL or missing references)
		//IL_1447: Unknown result type (might be due to invalid IL or missing references)
		//IL_1485: Unknown result type (might be due to invalid IL or missing references)
		//IL_1546: Unknown result type (might be due to invalid IL or missing references)
		//IL_157e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1633: Unknown result type (might be due to invalid IL or missing references)
		//IL_1671: Unknown result type (might be due to invalid IL or missing references)
		//IL_1740: Unknown result type (might be due to invalid IL or missing references)
		//IL_177e: Unknown result type (might be due to invalid IL or missing references)
		//IL_184d: Unknown result type (might be due to invalid IL or missing references)
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		Code128Generator symbology = new Code128Generator();
		Code128Generator symbology2 = new Code128Generator();
		Code128Generator symbology3 = new Code128Generator();
		Code128Generator symbology4 = new Code128Generator();
		Code128Generator symbology5 = new Code128Generator();
		Code128Generator symbology6 = new Code128Generator();
		Code128Generator symbology7 = new Code128Generator();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		lblNotaFiscal = new XRLabel();
		lblPedidoVendas = new XRLabel();
		lblBr = new XRLabel();
		lblQuantidade = new XRLabel();
		lblPecas = new XRLabel();
		lblProdutoAcabado = new XRLabel();
		bceNotaFiscal = new XRBarCode();
		lblEmpresaRemetente = new XRLabel();
		lblEnderecoRemetente = new XRLabel();
		lblCidadeRemetente = new XRLabel();
		bcePedidoVendas = new XRBarCode();
		lblEmpresaDestinatario = new XRLabel();
		lblEnderecoDestinatario = new XRLabel();
		lblCidadeDestinatario = new XRLabel();
		lblPeso = new XRLabel();
		bceProdutoAcabado = new XRBarCode();
		bcePecas = new XRBarCode();
		lblData = new XRLabel();
		bceData = new XRBarCode();
		bceBr = new XRBarCode();
		bceQuantidade = new XRBarCode();
		PageFooter = new PageFooterBand();
		((ISupportInitialize)this).BeginInit();
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 0f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 0f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 0f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[23]
		{
			(XRControl)xrLabel2,
			(XRControl)xrLabel1,
			(XRControl)lblNotaFiscal,
			(XRControl)lblPedidoVendas,
			(XRControl)lblBr,
			(XRControl)lblQuantidade,
			(XRControl)lblPecas,
			(XRControl)lblProdutoAcabado,
			(XRControl)bceNotaFiscal,
			(XRControl)lblEmpresaRemetente,
			(XRControl)lblEnderecoRemetente,
			(XRControl)lblCidadeRemetente,
			(XRControl)bcePedidoVendas,
			(XRControl)lblEmpresaDestinatario,
			(XRControl)lblEnderecoDestinatario,
			(XRControl)lblCidadeDestinatario,
			(XRControl)lblPeso,
			(XRControl)bceProdutoAcabado,
			(XRControl)bcePecas,
			(XRControl)lblData,
			(XRControl)bceData,
			(XRControl)bceBr,
			(XRControl)bceQuantidade
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).HeightF = 938.7418f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)xrLabel2).CanGrow = false;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(1044.896f, 230.3167f);
		xrLabel2.Multiline = true;
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(575.1063f, 45.19083f);
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "TO:";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)16;
		((XRControl)xrLabel1).CanGrow = false;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(1044.894f, 25.00001f);
		xrLabel1.Multiline = true;
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(575.1063f, 45.19083f);
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "FROM:";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)16;
		((XRControl)lblNotaFiscal).Dpi = 254f;
		((XRControl)lblNotaFiscal).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblNotaFiscal).LocationFloat = new PointFloat(35.58342f, 25.00001f);
		lblNotaFiscal.Multiline = true;
		((XRControl)lblNotaFiscal).Name = "lblNotaFiscal";
		((XRControl)lblNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblNotaFiscal).SizeF = new SizeF(947.208f, 58.41978f);
		((XRControl)lblNotaFiscal).StylePriority.UseFont = false;
		((XRControl)lblNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)lblNotaFiscal).Text = "(3S) PKG. ID:N80326 - 00000";
		((XRControl)lblNotaFiscal).TextAlignment = (TextAlignment)16;
		((XRControl)lblPedidoVendas).Dpi = 254f;
		((XRControl)lblPedidoVendas).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblPedidoVendas).LocationFloat = new PointFloat(35.58342f, 266.6174f);
		lblPedidoVendas.Multiline = true;
		((XRControl)lblPedidoVendas).Name = "lblPedidoVendas";
		((XRControl)lblPedidoVendas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblPedidoVendas).SizeF = new SizeF(947.208f, 58.41977f);
		((XRControl)lblPedidoVendas).StylePriority.UseFont = false;
		((XRControl)lblPedidoVendas).StylePriority.UseTextAlignment = false;
		((XRControl)lblPedidoVendas).Text = "(K) TRANS. ID:00000000/0000";
		((XRControl)lblPedidoVendas).TextAlignment = (TextAlignment)16;
		((XRControl)lblBr).Dpi = 254f;
		((XRControl)lblBr).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblBr).LocationFloat = new PointFloat(659.3002f, 757.767f);
		lblBr.Multiline = true;
		((XRControl)lblBr).Name = "lblBr";
		((XRControl)lblBr).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblBr).SizeF = new SizeF(323.4913f, 58.4198f);
		((XRControl)lblBr).StylePriority.UseFont = false;
		((XRControl)lblBr).StylePriority.UseTextAlignment = false;
		((XRControl)lblBr).Text = "(4L) BR";
		((XRControl)lblBr).TextAlignment = (TextAlignment)16;
		((XRControl)lblQuantidade).Dpi = 254f;
		((XRControl)lblQuantidade).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblQuantidade).LocationFloat = new PointFloat(1044.893f, 757.767f);
		lblQuantidade.Multiline = true;
		((XRControl)lblQuantidade).Name = "lblQuantidade";
		((XRControl)lblQuantidade).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblQuantidade).SizeF = new SizeF(575.1031f, 58.4198f);
		((XRControl)lblQuantidade).StylePriority.UseFont = false;
		((XRControl)lblQuantidade).StylePriority.UseTextAlignment = false;
		((XRControl)lblQuantidade).Text = "(Q) QUANTITY:000";
		((XRControl)lblQuantidade).TextAlignment = (TextAlignment)16;
		((XRControl)lblPecas).Dpi = 254f;
		((XRControl)lblPecas).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblPecas).LocationFloat = new PointFloat(1060.768f, 508.7643f);
		lblPecas.Multiline = true;
		((XRControl)lblPecas).Name = "lblPecas";
		((XRControl)lblPecas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblPecas).SizeF = new SizeF(559.2281f, 58.41983f);
		((XRControl)lblPecas).StylePriority.UseFont = false;
		((XRControl)lblPecas).StylePriority.UseTextAlignment = false;
		((XRControl)lblPecas).Text = "(13Q) BOX:00/00";
		((XRControl)lblPecas).TextAlignment = (TextAlignment)16;
		((XRControl)lblProdutoAcabado).Dpi = 254f;
		((XRControl)lblProdutoAcabado).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblProdutoAcabado).LocationFloat = new PointFloat(35.58342f, 508.7643f);
		lblProdutoAcabado.Multiline = true;
		((XRControl)lblProdutoAcabado).Name = "lblProdutoAcabado";
		((XRControl)lblProdutoAcabado).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblProdutoAcabado).SizeF = new SizeF(947.208f, 58.41977f);
		((XRControl)lblProdutoAcabado).StylePriority.UseFont = false;
		((XRControl)lblProdutoAcabado).StylePriority.UseTextAlignment = false;
		((XRControl)lblProdutoAcabado).Text = "(P) CUST. PART NO:000-0000000000-0";
		((XRControl)lblProdutoAcabado).TextAlignment = (TextAlignment)16;
		bceNotaFiscal.AutoModule = true;
		((XRControl)bceNotaFiscal).Dpi = 254f;
		((XRControl)bceNotaFiscal).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bceNotaFiscal).LocationFloat = new PointFloat(11.7706f, 83.41977f);
		bceNotaFiscal.Module = 5.08f;
		((XRControl)bceNotaFiscal).Name = "bceNotaFiscal";
		((XRControl)bceNotaFiscal).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bceNotaFiscal.ShowText = false;
		((XRControl)bceNotaFiscal).SizeF = new SizeF(971.0209f, 122.555f);
		((XRControl)bceNotaFiscal).StylePriority.UseFont = false;
		((XRControl)bceNotaFiscal).StylePriority.UseTextAlignment = false;
		bceNotaFiscal.Symbology = (BarCodeGeneratorBase)(object)symbology;
		((XRControl)bceNotaFiscal).Text = "3SN80326+00000";
		((XRControl)bceNotaFiscal).TextAlignment = (TextAlignment)1;
		((XRControl)lblEmpresaRemetente).CanGrow = false;
		((XRControl)lblEmpresaRemetente).Dpi = 254f;
		((XRControl)lblEmpresaRemetente).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblEmpresaRemetente).LocationFloat = new PointFloat(1044.894f, 70.19085f);
		lblEmpresaRemetente.Multiline = true;
		((XRControl)lblEmpresaRemetente).Name = "lblEmpresaRemetente";
		((XRControl)lblEmpresaRemetente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEmpresaRemetente).SizeF = new SizeF(575.1063f, 45.19083f);
		((XRControl)lblEmpresaRemetente).StylePriority.UseFont = false;
		((XRControl)lblEmpresaRemetente).StylePriority.UseTextAlignment = false;
		((XRControl)lblEmpresaRemetente).Text = "Empresa Remetente";
		((XRControl)lblEmpresaRemetente).TextAlignment = (TextAlignment)16;
		((XRControl)lblEnderecoRemetente).CanGrow = false;
		((XRControl)lblEnderecoRemetente).Dpi = 254f;
		((XRControl)lblEnderecoRemetente).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblEnderecoRemetente).LocationFloat = new PointFloat(1044.894f, 115.3817f);
		lblEnderecoRemetente.Multiline = true;
		((XRControl)lblEnderecoRemetente).Name = "lblEnderecoRemetente";
		((XRControl)lblEnderecoRemetente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEnderecoRemetente).SizeF = new SizeF(575.1063f, 45.1908f);
		((XRControl)lblEnderecoRemetente).StylePriority.UseFont = false;
		((XRControl)lblEnderecoRemetente).StylePriority.UseTextAlignment = false;
		((XRControl)lblEnderecoRemetente).Text = "Endereço Remetente";
		((XRControl)lblEnderecoRemetente).TextAlignment = (TextAlignment)16;
		((XRControl)lblCidadeRemetente).CanGrow = false;
		((XRControl)lblCidadeRemetente).Dpi = 254f;
		((XRControl)lblCidadeRemetente).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblCidadeRemetente).LocationFloat = new PointFloat(1044.896f, 160.5725f);
		lblCidadeRemetente.Multiline = true;
		((XRControl)lblCidadeRemetente).Name = "lblCidadeRemetente";
		((XRControl)lblCidadeRemetente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblCidadeRemetente).SizeF = new SizeF(575.1044f, 45.19078f);
		((XRControl)lblCidadeRemetente).StylePriority.UseFont = false;
		((XRControl)lblCidadeRemetente).StylePriority.UseTextAlignment = false;
		((XRControl)lblCidadeRemetente).Text = "Cidade Remetente";
		((XRControl)lblCidadeRemetente).TextAlignment = (TextAlignment)16;
		bcePedidoVendas.AutoModule = true;
		((XRControl)bcePedidoVendas).Dpi = 254f;
		((XRControl)bcePedidoVendas).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bcePedidoVendas).LocationFloat = new PointFloat(11.77125f, 325.0372f);
		bcePedidoVendas.Module = 5.08f;
		((XRControl)bcePedidoVendas).Name = "bcePedidoVendas";
		((XRControl)bcePedidoVendas).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bcePedidoVendas.ShowText = false;
		((XRControl)bcePedidoVendas).SizeF = new SizeF(971.0202f, 122.5551f);
		((XRControl)bcePedidoVendas).StylePriority.UseFont = false;
		((XRControl)bcePedidoVendas).StylePriority.UseTextAlignment = false;
		bcePedidoVendas.Symbology = (BarCodeGeneratorBase)(object)symbology2;
		((XRControl)bcePedidoVendas).Text = "K00000000-0000";
		((XRControl)bcePedidoVendas).TextAlignment = (TextAlignment)1;
		((XRControl)lblEmpresaDestinatario).CanGrow = false;
		((XRControl)lblEmpresaDestinatario).Dpi = 254f;
		((XRControl)lblEmpresaDestinatario).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblEmpresaDestinatario).LocationFloat = new PointFloat(1044.898f, 275.5076f);
		lblEmpresaDestinatario.Multiline = true;
		((XRControl)lblEmpresaDestinatario).Name = "lblEmpresaDestinatario";
		((XRControl)lblEmpresaDestinatario).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEmpresaDestinatario).SizeF = new SizeF(575.1044f, 45.1908f);
		((XRControl)lblEmpresaDestinatario).StylePriority.UseFont = false;
		((XRControl)lblEmpresaDestinatario).StylePriority.UseTextAlignment = false;
		((XRControl)lblEmpresaDestinatario).Text = "Empresa Destinatario";
		((XRControl)lblEmpresaDestinatario).TextAlignment = (TextAlignment)16;
		((XRControl)lblEnderecoDestinatario).CanGrow = false;
		((XRControl)lblEnderecoDestinatario).Dpi = 254f;
		((XRControl)lblEnderecoDestinatario).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblEnderecoDestinatario).LocationFloat = new PointFloat(1044.899f, 320.6984f);
		lblEnderecoDestinatario.Multiline = true;
		((XRControl)lblEnderecoDestinatario).Name = "lblEnderecoDestinatario";
		((XRControl)lblEnderecoDestinatario).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblEnderecoDestinatario).SizeF = new SizeF(575.1031f, 45.19083f);
		((XRControl)lblEnderecoDestinatario).StylePriority.UseFont = false;
		((XRControl)lblEnderecoDestinatario).StylePriority.UseTextAlignment = false;
		((XRControl)lblEnderecoDestinatario).Text = "Endereço Destinatario";
		((XRControl)lblEnderecoDestinatario).TextAlignment = (TextAlignment)16;
		((XRControl)lblCidadeDestinatario).CanGrow = false;
		((XRControl)lblCidadeDestinatario).Dpi = 254f;
		((XRControl)lblCidadeDestinatario).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblCidadeDestinatario).LocationFloat = new PointFloat(1044.899f, 365.8892f);
		lblCidadeDestinatario.Multiline = true;
		((XRControl)lblCidadeDestinatario).Name = "lblCidadeDestinatario";
		((XRControl)lblCidadeDestinatario).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblCidadeDestinatario).SizeF = new SizeF(575.1031f, 45.19086f);
		((XRControl)lblCidadeDestinatario).StylePriority.UseFont = false;
		((XRControl)lblCidadeDestinatario).StylePriority.UseTextAlignment = false;
		((XRControl)lblCidadeDestinatario).Text = "Cidade Destinatario";
		((XRControl)lblCidadeDestinatario).TextAlignment = (TextAlignment)16;
		((XRControl)lblPeso).CanGrow = false;
		((XRControl)lblPeso).Dpi = 254f;
		((XRControl)lblPeso).Font = new Font("Arial", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lblPeso).LocationFloat = new PointFloat(1044.899f, 437.1151f);
		lblPeso.Multiline = true;
		((XRControl)lblPeso).Name = "lblPeso";
		((XRControl)lblPeso).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblPeso).SizeF = new SizeF(575.1031f, 45.19086f);
		((XRControl)lblPeso).StylePriority.UseFont = false;
		((XRControl)lblPeso).StylePriority.UseTextAlignment = false;
		((XRControl)lblPeso).Text = "PKG. WT:XX,XX KG";
		((XRControl)lblPeso).TextAlignment = (TextAlignment)16;
		bceProdutoAcabado.AutoModule = true;
		((XRControl)bceProdutoAcabado).Dpi = 254f;
		((XRControl)bceProdutoAcabado).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bceProdutoAcabado).LocationFloat = new PointFloat(11.7706f, 567.1842f);
		bceProdutoAcabado.Module = 5.08f;
		((XRControl)bceProdutoAcabado).Name = "bceProdutoAcabado";
		((XRControl)bceProdutoAcabado).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bceProdutoAcabado.ShowText = false;
		((XRControl)bceProdutoAcabado).SizeF = new SizeF(971.0209f, 122.5551f);
		((XRControl)bceProdutoAcabado).StylePriority.UseFont = false;
		((XRControl)bceProdutoAcabado).StylePriority.UseTextAlignment = false;
		bceProdutoAcabado.Symbology = (BarCodeGeneratorBase)(object)symbology3;
		((XRControl)bceProdutoAcabado).Text = "P000-0000000000-0";
		((XRControl)bceProdutoAcabado).TextAlignment = (TextAlignment)1;
		bcePecas.AutoModule = true;
		((XRControl)bcePecas).Dpi = 254f;
		((XRControl)bcePecas).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bcePecas).LocationFloat = new PointFloat(1044.893f, 567.1842f);
		bcePecas.Module = 5.08f;
		((XRControl)bcePecas).Name = "bcePecas";
		((XRControl)bcePecas).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bcePecas.ShowText = false;
		((XRControl)bcePecas).SizeF = new SizeF(575.1077f, 122.5549f);
		((XRControl)bcePecas).StylePriority.UseFont = false;
		((XRControl)bcePecas).StylePriority.UseTextAlignment = false;
		bcePecas.Symbology = (BarCodeGeneratorBase)(object)symbology4;
		((XRControl)bcePecas).Text = "13Q00/00";
		((XRControl)bcePecas).TextAlignment = (TextAlignment)1;
		((XRControl)lblData).Dpi = 254f;
		((XRControl)lblData).Font = new Font("Arial", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)lblData).LocationFloat = new PointFloat(35.58342f, 757.767f);
		lblData.Multiline = true;
		((XRControl)lblData).Name = "lblData";
		((XRControl)lblData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lblData).SizeF = new SizeF(563.5621f, 58.4198f);
		((XRControl)lblData).StylePriority.UseFont = false;
		((XRControl)lblData).StylePriority.UseTextAlignment = false;
		((XRControl)lblData).Text = "(9D) DATE CODE:000000";
		((XRControl)lblData).TextAlignment = (TextAlignment)16;
		bceData.AutoModule = true;
		((XRControl)bceData).Dpi = 254f;
		((XRControl)bceData).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bceData).LocationFloat = new PointFloat(11.7706f, 816.1868f);
		bceData.Module = 5.08f;
		((XRControl)bceData).Name = "bceData";
		((XRControl)bceData).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bceData.ShowText = false;
		((XRControl)bceData).SizeF = new SizeF(587.3749f, 119.6974f);
		((XRControl)bceData).StylePriority.UseFont = false;
		((XRControl)bceData).StylePriority.UseTextAlignment = false;
		bceData.Symbology = (BarCodeGeneratorBase)(object)symbology5;
		((XRControl)bceData).Text = "200422";
		((XRControl)bceData).TextAlignment = (TextAlignment)1;
		bceBr.AutoModule = true;
		((XRControl)bceBr).Dpi = 254f;
		((XRControl)bceBr).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bceBr).LocationFloat = new PointFloat(646.071f, 816.1868f);
		bceBr.Module = 5.08f;
		((XRControl)bceBr).Name = "bceBr";
		((XRControl)bceBr).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bceBr.ShowText = false;
		((XRControl)bceBr).SizeF = new SizeF(336.7204f, 116.84f);
		((XRControl)bceBr).StylePriority.UseFont = false;
		((XRControl)bceBr).StylePriority.UseTextAlignment = false;
		bceBr.Symbology = (BarCodeGeneratorBase)(object)symbology6;
		((XRControl)bceBr).Text = "4LBR";
		((XRControl)bceBr).TextAlignment = (TextAlignment)1;
		bceQuantidade.AutoModule = true;
		((XRControl)bceQuantidade).Dpi = 254f;
		((XRControl)bceQuantidade).Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)bceQuantidade).LocationFloat = new PointFloat(1021.076f, 816.1867f);
		bceQuantidade.Module = 5.08f;
		((XRControl)bceQuantidade).Name = "bceQuantidade";
		((XRControl)bceQuantidade).Padding = new PaddingInfo(26, 26, 0, 0, 254f);
		bceQuantidade.ShowText = false;
		((XRControl)bceQuantidade).SizeF = new SizeF(598.9202f, 116.8401f);
		((XRControl)bceQuantidade).StylePriority.UseFont = false;
		((XRControl)bceQuantidade).StylePriority.UseTextAlignment = false;
		bceQuantidade.Symbology = (BarCodeGeneratorBase)(object)symbology7;
		((XRControl)bceQuantidade).Text = "Q000";
		((XRControl)bceQuantidade).TextAlignment = (TextAlignment)1;
		((XRControl)PageFooter).Dpi = 254f;
		((XRControl)PageFooter).HeightF = 0f;
		((XRControl)PageFooter).Name = "PageFooter";
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
		((XtraReport)this).Margins = new Margins(0, 5, 0, 0);
		((XtraReport)this).PageHeight = 1000;
		((XtraReport)this).PageWidth = 1650;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 10f;
		((XtraReport)this).Version = "19.2";
		((ISupportInitialize)this).EndInit();
	}
}
