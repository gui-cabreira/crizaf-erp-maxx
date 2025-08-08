using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.RPT;

public class rptEtiquetaMBenzKLT : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private XRLabel xrLabel27;

	private XRLabel txSequencia;

	private XRLine xrLine2;

	private XRLabel xrLabel21;

	private XRLabel txDataChamada;

	private XRLabel xrLabel23;

	private XRLabel txNumeroChamada;

	private XRLabel xrLabel25;

	private XRLabel txPesoLiquido;

	private XRLabel xrLabel15;

	private XRLabel txCodigoFornecedor;

	private XRLabel xrLabel17;

	private XRLabel txNomeFornecedor;

	private XRLabel xrLabel19;

	private XRLabel txPesoBruto;

	private XRLabel txDescricaoItem;

	private XRLabel txEmbalagem;

	private XRLabel txCapacidadeEmbalagem;

	private XRLabel xrLabel11;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRLine xrLine1;

	private XRLabel txVolume;

	private XRLabel xrLabel6;

	private XRLabel txPlantaDestino;

	private XRLabel txLocalDescarga;

	private XRLabel xrLabel4;

	private XRLabel txPecas;

	private XRBarCode txDataMatrix;

	private XRLabel txItem;

	private XRLabel xrLabel1;

	public int capacidadeEmbalagem { get; set; }

	public string codigoFornecedor { get; set; }

	public DateTime dataChamada { get; set; }

	public string descricaoItem { get; set; }

	public string codigoEmbalagem { get; set; }

	public string codigoProduto { get; set; }

	public string localDescarga { get; set; }

	public string nomeFornecedor { get; set; }

	public string numeroChamada { get; set; }

	public int quantidade { get; set; }

	public decimal pesoBruto { get; set; }

	public decimal pesoLiquido { get; set; }

	public string plantaDestino { get; set; }

	public string sequencia { get; set; }

	public int volume { get; set; }

	public int volumesTotal { get; set; }

	public rptEtiquetaMBenzKLT()
	{
		InitializeComponent();
	}

	public rptEtiquetaMBenzKLT(int capacidadeEmbalagem, string codigoFornecedor, DateTime dataChamada, string descricaoItem, string codigoEmbalagem, string codigoProduto, string localDescarga, string nomeFornecedor, string numeroChamada, int quantidade, decimal pesoBruto, decimal pesoLiquido, string plantaDestino, string sequencia, int volume, int volumesTotal)
		: this()
	{
		this.capacidadeEmbalagem = capacidadeEmbalagem;
		this.codigoFornecedor = codigoFornecedor;
		this.dataChamada = dataChamada;
		this.descricaoItem = descricaoItem;
		this.codigoEmbalagem = codigoEmbalagem;
		this.codigoProduto = codigoProduto;
		this.localDescarga = localDescarga;
		this.nomeFornecedor = nomeFornecedor;
		this.numeroChamada = numeroChamada;
		this.quantidade = quantidade;
		this.pesoBruto = pesoBruto;
		this.pesoLiquido = pesoLiquido;
		this.plantaDestino = plantaDestino;
		this.sequencia = sequencia;
		this.volume = volume;
		this.volumesTotal = volumesTotal;
	}

	private void Detail_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)txCapacidadeEmbalagem).Text = capacidadeEmbalagem.ToString();
		((XRControl)txCodigoFornecedor).Text = codigoFornecedor;
		((XRControl)txDataChamada).Text = dataChamada.ToShortDateString();
		((XRControl)txDescricaoItem).Text = descricaoItem;
		((XRControl)txEmbalagem).Text = codigoEmbalagem;
		((XRControl)txItem).Text = codigoProduto;
		((XRControl)txLocalDescarga).Text = localDescarga;
		((XRControl)txNomeFornecedor).Text = nomeFornecedor;
		((XRControl)txNumeroChamada).Text = numeroChamada.PadLeft(12, '0');
		((XRControl)txPecas).Text = $"{quantidade} PÇS";
		((XRControl)txPesoBruto).Text = $"{pesoBruto:F3} Kg";
		((XRControl)txPesoLiquido).Text = $"{pesoLiquido:F3} Kg";
		((XRControl)txPlantaDestino).Text = plantaDestino;
		((XRControl)txSequencia).Text = sequencia.ToString();
		((XRControl)txVolume).Text = $"Volumes: {volume} de {volumesTotal}";
		((XRControl)txDataMatrix).Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", dataChamada.ToString("yy"), dataChamada.ToString("MM"), dataChamada.ToString("dd"), numeroChamada.PadLeft(12, '0'), sequencia.ToString().PadLeft(2, '0'), codigoProduto.PadRight(21), (quantidade * 1000).ToString().PadLeft(14, '0'), volume.ToString().PadLeft(2, '0'), volumesTotal.ToString().PadLeft(2, '0'));
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
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_103d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1075: Unknown result type (might be due to invalid IL or missing references)
		//IL_1119: Unknown result type (might be due to invalid IL or missing references)
		//IL_1151: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_122d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1309: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1489: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_154a: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1775: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_1889: Unknown result type (might be due to invalid IL or missing references)
		//IL_192d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1965: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cec: Unknown result type (might be due to invalid IL or missing references)
		DataMatrixGenerator val = new DataMatrixGenerator();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrLabel27 = new XRLabel();
		txSequencia = new XRLabel();
		xrLine2 = new XRLine();
		xrLabel21 = new XRLabel();
		txDataChamada = new XRLabel();
		xrLabel23 = new XRLabel();
		txNumeroChamada = new XRLabel();
		xrLabel25 = new XRLabel();
		txPesoLiquido = new XRLabel();
		xrLabel15 = new XRLabel();
		txCodigoFornecedor = new XRLabel();
		xrLabel17 = new XRLabel();
		txNomeFornecedor = new XRLabel();
		xrLabel19 = new XRLabel();
		txPesoBruto = new XRLabel();
		txDescricaoItem = new XRLabel();
		txEmbalagem = new XRLabel();
		txCapacidadeEmbalagem = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLine1 = new XRLine();
		txVolume = new XRLabel();
		xrLabel6 = new XRLabel();
		txPlantaDestino = new XRLabel();
		txLocalDescarga = new XRLabel();
		xrLabel4 = new XRLabel();
		txPecas = new XRLabel();
		txDataMatrix = new XRBarCode();
		txItem = new XRLabel();
		xrLabel1 = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 0f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 0f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[31]
		{
			(XRControl)xrLabel27,
			(XRControl)txSequencia,
			(XRControl)xrLine2,
			(XRControl)xrLabel21,
			(XRControl)txDataChamada,
			(XRControl)xrLabel23,
			(XRControl)txNumeroChamada,
			(XRControl)xrLabel25,
			(XRControl)txPesoLiquido,
			(XRControl)xrLabel15,
			(XRControl)txCodigoFornecedor,
			(XRControl)xrLabel17,
			(XRControl)txNomeFornecedor,
			(XRControl)xrLabel19,
			(XRControl)txPesoBruto,
			(XRControl)txDescricaoItem,
			(XRControl)txEmbalagem,
			(XRControl)txCapacidadeEmbalagem,
			(XRControl)xrLabel11,
			(XRControl)xrLabel10,
			(XRControl)xrLabel9,
			(XRControl)xrLine1,
			(XRControl)txVolume,
			(XRControl)xrLabel6,
			(XRControl)txPlantaDestino,
			(XRControl)txLocalDescarga,
			(XRControl)xrLabel4,
			(XRControl)txPecas,
			(XRControl)txDataMatrix,
			(XRControl)txItem,
			(XRControl)xrLabel1
		});
		((XRControl)Detail).Dpi = 254f;
		((XRControl)Detail).HeightF = 653.5325f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).BeforePrint += Detail_BeforePrint;
		((XRControl)xrLabel27).Dpi = 254f;
		((XRControl)xrLabel27).Font = new Font("Arial", 7f);
		((XRControl)xrLabel27).LocationFloat = new PointFloat(516.4041f, 563.5044f);
		xrLabel27.Multiline = true;
		((XRControl)xrLabel27).Name = "xrLabel27";
		((XRControl)xrLabel27).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel27).SizeF = new SizeF(249.6641f, 28.92224f);
		((XRControl)xrLabel27).StylePriority.UseFont = false;
		((XRControl)xrLabel27).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel27).Text = "Sequencia";
		((XRControl)xrLabel27).TextAlignment = (TextAlignment)1;
		((XRControl)txSequencia).Dpi = 254f;
		((XRControl)txSequencia).Font = new Font("Arial", 7f);
		((XRControl)txSequencia).LocationFloat = new PointFloat(516.4041f, 592.4266f);
		txSequencia.Multiline = true;
		((XRControl)txSequencia).Name = "txSequencia";
		((XRControl)txSequencia).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txSequencia).SizeF = new SizeF(249.6641f, 28.92224f);
		((XRControl)txSequencia).StylePriority.UseFont = false;
		((XRControl)txSequencia).StylePriority.UseTextAlignment = false;
		((XRControl)txSequencia).Text = "01";
		((XRControl)txSequencia).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(6.103516E-05f, 641.349f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(959.9999f, 5f);
		((XRControl)xrLabel21).Dpi = 254f;
		((XRControl)xrLabel21).Font = new Font("Arial", 7f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(24.99975f, 563.5044f);
		xrLabel21.Multiline = true;
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel21).SizeF = new SizeF(194.3006f, 28.92224f);
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel21).Text = "Data Chamada";
		((XRControl)xrLabel21).TextAlignment = (TextAlignment)1;
		((XRControl)txDataChamada).CanGrow = false;
		((XRControl)txDataChamada).Dpi = 254f;
		((XRControl)txDataChamada).Font = new Font("Arial", 7f);
		((XRControl)txDataChamada).LocationFloat = new PointFloat(24.99975f, 592.4266f);
		txDataChamada.Multiline = true;
		((XRControl)txDataChamada).Name = "txDataChamada";
		((XRControl)txDataChamada).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDataChamada).SizeF = new SizeF(194.3006f, 28.92224f);
		((XRControl)txDataChamada).StylePriority.UseFont = false;
		((XRControl)txDataChamada).StylePriority.UseTextAlignment = false;
		((XRControl)txDataChamada).Text = "28/02/2018";
		((XRControl)txDataChamada).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel23).Dpi = 254f;
		((XRControl)xrLabel23).Font = new Font("Arial", 7f);
		((XRControl)xrLabel23).LocationFloat = new PointFloat(219.3005f, 563.5044f);
		xrLabel23.Multiline = true;
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel23).SizeF = new SizeF(236.2611f, 28.92224f);
		((XRControl)xrLabel23).StylePriority.UseFont = false;
		((XRControl)xrLabel23).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel23).Text = "Numero Chamada";
		((XRControl)xrLabel23).TextAlignment = (TextAlignment)1;
		((XRControl)txNumeroChamada).Dpi = 254f;
		((XRControl)txNumeroChamada).Font = new Font("Arial", 7f);
		((XRControl)txNumeroChamada).LocationFloat = new PointFloat(219.3005f, 592.4266f);
		txNumeroChamada.Multiline = true;
		((XRControl)txNumeroChamada).Name = "txNumeroChamada";
		((XRControl)txNumeroChamada).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNumeroChamada).SizeF = new SizeF(236.2611f, 28.92224f);
		((XRControl)txNumeroChamada).StylePriority.UseFont = false;
		((XRControl)txNumeroChamada).StylePriority.UseTextAlignment = false;
		((XRControl)txNumeroChamada).Text = "000000000042";
		((XRControl)txNumeroChamada).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel25).Dpi = 254f;
		((XRControl)xrLabel25).Font = new Font("Arial", 7f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(776.1895f, 563.5044f);
		xrLabel25.Multiline = true;
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel25).SizeF = new SizeF(183.8106f, 28.92224f);
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel25).Text = "Peso Líquido";
		((XRControl)xrLabel25).TextAlignment = (TextAlignment)4;
		((XRControl)txPesoLiquido).Dpi = 254f;
		((XRControl)txPesoLiquido).Font = new Font("Arial", 7f);
		((XRControl)txPesoLiquido).LocationFloat = new PointFloat(776.1895f, 592.4266f);
		txPesoLiquido.Multiline = true;
		((XRControl)txPesoLiquido).Name = "txPesoLiquido";
		((XRControl)txPesoLiquido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoLiquido).SizeF = new SizeF(183.8106f, 28.92224f);
		((XRControl)txPesoLiquido).StylePriority.UseFont = false;
		((XRControl)txPesoLiquido).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoLiquido).Text = "9,000 Kg";
		((XRControl)txPesoLiquido).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel15).Dpi = 254f;
		((XRControl)xrLabel15).Font = new Font("Arial", 7f);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(24.99988f, 481.6599f);
		xrLabel15.Multiline = true;
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel15).SizeF = new SizeF(194.3006f, 28.92224f);
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel15).Text = "Fornecedor";
		((XRControl)xrLabel15).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoFornecedor).CanGrow = false;
		((XRControl)txCodigoFornecedor).Dpi = 254f;
		((XRControl)txCodigoFornecedor).Font = new Font("Arial", 7f);
		((XRControl)txCodigoFornecedor).LocationFloat = new PointFloat(24.99988f, 510.5822f);
		txCodigoFornecedor.Multiline = true;
		((XRControl)txCodigoFornecedor).Name = "txCodigoFornecedor";
		((XRControl)txCodigoFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoFornecedor).SizeF = new SizeF(194.3006f, 28.92224f);
		((XRControl)txCodigoFornecedor).StylePriority.UseFont = false;
		((XRControl)txCodigoFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoFornecedor).Text = "11827800";
		((XRControl)txCodigoFornecedor).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 7f);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(219.3005f, 481.6599f);
		xrLabel17.Multiline = true;
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(546.7676f, 28.92224f);
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel17).Text = "Nome Fornecedor";
		((XRControl)xrLabel17).TextAlignment = (TextAlignment)1;
		((XRControl)txNomeFornecedor).Dpi = 254f;
		((XRControl)txNomeFornecedor).Font = new Font("Arial", 7f);
		((XRControl)txNomeFornecedor).LocationFloat = new PointFloat(219.3005f, 510.5822f);
		txNomeFornecedor.Multiline = true;
		((XRControl)txNomeFornecedor).Name = "txNomeFornecedor";
		((XRControl)txNomeFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeFornecedor).SizeF = new SizeF(546.7676f, 28.92224f);
		((XRControl)txNomeFornecedor).StylePriority.UseFont = false;
		((XRControl)txNomeFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeFornecedor).Text = "METALURGICA CARTEC";
		((XRControl)txNomeFornecedor).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel19).Dpi = 254f;
		((XRControl)xrLabel19).Font = new Font("Arial", 7f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(776.1895f, 481.6599f);
		xrLabel19.Multiline = true;
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel19).SizeF = new SizeF(183.8106f, 28.92224f);
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel19).Text = "Peso Bruto";
		((XRControl)xrLabel19).TextAlignment = (TextAlignment)4;
		((XRControl)txPesoBruto).Dpi = 254f;
		((XRControl)txPesoBruto).Font = new Font("Arial", 7f);
		((XRControl)txPesoBruto).LocationFloat = new PointFloat(776.1895f, 510.5822f);
		txPesoBruto.Multiline = true;
		((XRControl)txPesoBruto).Name = "txPesoBruto";
		((XRControl)txPesoBruto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoBruto).SizeF = new SizeF(183.8106f, 28.92224f);
		((XRControl)txPesoBruto).StylePriority.UseFont = false;
		((XRControl)txPesoBruto).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoBruto).Text = "103,000 Kg";
		((XRControl)txPesoBruto).TextAlignment = (TextAlignment)4;
		((XRControl)txDescricaoItem).CanGrow = false;
		((XRControl)txDescricaoItem).Dpi = 254f;
		((XRControl)txDescricaoItem).Font = new Font("Arial", 7f);
		((XRControl)txDescricaoItem).LocationFloat = new PointFloat(24.99987f, 429.7377f);
		txDescricaoItem.Multiline = true;
		((XRControl)txDescricaoItem).Name = "txDescricaoItem";
		((XRControl)txDescricaoItem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricaoItem).SizeF = new SizeF(412.7311f, 28.92224f);
		((XRControl)txDescricaoItem).StylePriority.UseFont = false;
		((XRControl)txDescricaoItem).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricaoItem).Text = "PC1161 BT MBB BUS";
		((XRControl)txDescricaoItem).TextAlignment = (TextAlignment)1;
		((XRControl)txEmbalagem).Dpi = 254f;
		((XRControl)txEmbalagem).Font = new Font("Arial", 7f);
		((XRControl)txEmbalagem).LocationFloat = new PointFloat(450.9601f, 429.7377f);
		txEmbalagem.Multiline = true;
		((XRControl)txEmbalagem).Name = "txEmbalagem";
		((XRControl)txEmbalagem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmbalagem).SizeF = new SizeF(192.7401f, 28.92227f);
		((XRControl)txEmbalagem).StylePriority.UseFont = false;
		((XRControl)txEmbalagem).StylePriority.UseTextAlignment = false;
		((XRControl)txEmbalagem).Text = "T51312";
		((XRControl)txEmbalagem).TextAlignment = (TextAlignment)2;
		((XRControl)txCapacidadeEmbalagem).Dpi = 254f;
		((XRControl)txCapacidadeEmbalagem).Font = new Font("Arial", 7f);
		((XRControl)txCapacidadeEmbalagem).LocationFloat = new PointFloat(662.8965f, 429.7377f);
		txCapacidadeEmbalagem.Multiline = true;
		((XRControl)txCapacidadeEmbalagem).Name = "txCapacidadeEmbalagem";
		((XRControl)txCapacidadeEmbalagem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCapacidadeEmbalagem).SizeF = new SizeF(297.1035f, 28.92227f);
		((XRControl)txCapacidadeEmbalagem).StylePriority.UseFont = false;
		((XRControl)txCapacidadeEmbalagem).StylePriority.UseTextAlignment = false;
		((XRControl)txCapacidadeEmbalagem).Text = "50";
		((XRControl)txCapacidadeEmbalagem).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 7f);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(662.8965f, 400.8155f);
		xrLabel11.Multiline = true;
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(297.1035f, 28.92227f);
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel11).Text = "Capacidade Embalagem";
		((XRControl)xrLabel11).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 7f);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(437.731f, 400.8155f);
		xrLabel10.Multiline = true;
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(216.2586f, 28.92224f);
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "Embalagem";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 7f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(24.99988f, 400.8155f);
		xrLabel9.Multiline = true;
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(297.1035f, 28.92227f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "Denominação Item";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(0f, 392.8155f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(959.9999f, 5f);
		((XRControl)txVolume).Dpi = 254f;
		((XRControl)txVolume).Font = new Font("Arial", 12f);
		((XRControl)txVolume).LocationFloat = new PointFloat(25f, 340.2071f);
		txVolume.Multiline = true;
		((XRControl)txVolume).Name = "txVolume";
		((XRControl)txVolume).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txVolume).SizeF = new SizeF(628.9896f, 43.6084f);
		((XRControl)txVolume).StylePriority.UseFont = false;
		((XRControl)txVolume).StylePriority.UseTextAlignment = false;
		((XRControl)txVolume).Text = "Volume: 2 de 2";
		((XRControl)txVolume).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 9f);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(356.8861f, 152.591f);
		xrLabel6.Multiline = true;
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(297.1035f, 43.60838f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Planta de destino";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)2;
		((XRControl)txPlantaDestino).Dpi = 254f;
		((XRControl)txPlantaDestino).Font = new Font("Arial", 14f);
		((XRControl)txPlantaDestino).LocationFloat = new PointFloat(356.8861f, 196.1994f);
		txPlantaDestino.Multiline = true;
		((XRControl)txPlantaDestino).Name = "txPlantaDestino";
		((XRControl)txPlantaDestino).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPlantaDestino).SizeF = new SizeF(297.1035f, 49.30513f);
		((XRControl)txPlantaDestino).StylePriority.UseFont = false;
		((XRControl)txPlantaDestino).StylePriority.UseTextAlignment = false;
		((XRControl)txPlantaDestino).Text = "SBC";
		((XRControl)txPlantaDestino).TextAlignment = (TextAlignment)2;
		((XRControl)txLocalDescarga).Dpi = 254f;
		((XRControl)txLocalDescarga).Font = new Font("Arial", 14f);
		((XRControl)txLocalDescarga).LocationFloat = new PointFloat(25f, 196.1994f);
		txLocalDescarga.Multiline = true;
		((XRControl)txLocalDescarga).Name = "txLocalDescarga";
		((XRControl)txLocalDescarga).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txLocalDescarga).SizeF = new SizeF(297.1035f, 49.30513f);
		((XRControl)txLocalDescarga).StylePriority.UseFont = false;
		((XRControl)txLocalDescarga).StylePriority.UseTextAlignment = false;
		((XRControl)txLocalDescarga).Text = "21B";
		((XRControl)txLocalDescarga).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 9f);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(25f, 152.591f);
		xrLabel4.Multiline = true;
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(297.1035f, 43.60838f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Local Descarga";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)1;
		((XRControl)txPecas).Dpi = 254f;
		((XRControl)txPecas).Font = new Font("Arial", 11f);
		((XRControl)txPecas).LocationFloat = new PointFloat(503.4528f, 52.55938f);
		txPecas.Multiline = true;
		((XRControl)txPecas).Name = "txPecas";
		((XRControl)txPecas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecas).SizeF = new SizeF(431.5473f, 65.25611f);
		((XRControl)txPecas).StylePriority.UseFont = false;
		((XRControl)txPecas).StylePriority.UseTextAlignment = false;
		((XRControl)txPecas).Text = "20 pcs";
		((XRControl)txPecas).TextAlignment = (TextAlignment)64;
		txDataMatrix.AutoModule = true;
		((XRControl)txDataMatrix).Dpi = 254f;
		((XRControl)txDataMatrix).Font = new Font("Arial", 6f);
		((XRControl)txDataMatrix).LocationFloat = new PointFloat(674.9998f, 123.8155f);
		txDataMatrix.Module = 5.08f;
		((XRControl)txDataMatrix).Name = "txDataMatrix";
		((XRControl)txDataMatrix).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		txDataMatrix.ShowText = false;
		((XRControl)txDataMatrix).SizeF = new SizeF(260f, 260f);
		((XRControl)txDataMatrix).StylePriority.UseFont = false;
		((XRControl)txDataMatrix).StylePriority.UsePadding = false;
		val.MatrixSize = (DataMatrixSize)9;
		txDataMatrix.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txDataMatrix).Text = "2802201800000000004201A36432100062022";
		((XRControl)txItem).Dpi = 254f;
		((XRControl)txItem).Font = new Font("Arial", 16f);
		((XRControl)txItem).LocationFloat = new PointFloat(25f, 52.55938f);
		txItem.Multiline = true;
		((XRControl)txItem).Name = "txItem";
		((XRControl)txItem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItem).SizeF = new SizeF(478.4528f, 65.25611f);
		((XRControl)txItem).StylePriority.UseFont = false;
		((XRControl)txItem).Text = "A3643210006";
		((XRControl)xrLabel1).Borders = (BorderSide)8;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 9f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(0f, 5f);
		xrLabel1.Multiline = true;
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(20, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(959.9999f, 42.55938f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UsePadding = false;
		((XRControl)xrLabel1).Text = "Mercedes-Benz do Brasil Ltda.";
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[3]
		{
			(Band)TopMargin,
			(Band)BottomMargin,
			(Band)Detail
		});
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f);
		((XtraReport)this).Margins = new Margins(19, 19, 0, 0);
		((XtraReport)this).PageHeight = 750;
		((XtraReport)this).PageWidth = 1000;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 25f;
		((XtraReport)this).Version = "19.2";
		((ISupportInitialize)this).EndInit();
	}
}
