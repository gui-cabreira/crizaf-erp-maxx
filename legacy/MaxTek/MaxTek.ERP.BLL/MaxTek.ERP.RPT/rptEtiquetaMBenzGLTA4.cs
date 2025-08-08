using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.RPT;

public class rptEtiquetaMBenzGLTA4 : XtraReport
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

	private XRLabel xrLabel2;

	private XRLabel txItem2;

	private XRBarCode txDataMatrix2;

	private XRLabel txPecas2;

	private XRLabel xrLabel7;

	private XRLabel txLocalDescarga2;

	private XRLabel txPlantaDestino2;

	private XRLabel xrLabel13;

	private XRLabel txVolume2;

	private XRLine xrLine3;

	private XRLabel xrLabel16;

	private XRLabel xrLabel18;

	private XRLabel xrLabel20;

	private XRLabel txCapacidadeEmbalagem2;

	private XRLabel txEmbalagem2;

	private XRLabel txDescricaoItem2;

	private XRLabel txPesoBruto2;

	private XRLabel xrLabel29;

	private XRLabel txNomeFornecedor2;

	private XRLabel xrLabel31;

	private XRLabel txCodigoFornecedor2;

	private XRLabel xrLabel33;

	private XRLabel txPesoLiquido2;

	private XRLabel xrLabel35;

	private XRLabel txNumeroChamada2;

	private XRLabel xrLabel37;

	private XRLabel txDataChamada2;

	private XRLabel xrLabel39;

	private XRLine xrLine4;

	private XRLabel txSequencia2;

	private XRLabel xrLabel41;

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

	public int capacidadeEmbalagem2 { get; set; }

	public string codigoFornecedor2 { get; set; }

	public DateTime dataChamada2 { get; set; }

	public string descricaoItem2 { get; set; }

	public string codigoEmbalagem2 { get; set; }

	public string codigoProduto2 { get; set; }

	public string localDescarga2 { get; set; }

	public string nomeFornecedor2 { get; set; }

	public string numeroChamada2 { get; set; }

	public int quantidade2 { get; set; }

	public decimal pesoBruto2 { get; set; }

	public decimal pesoLiquido2 { get; set; }

	public string plantaDestino2 { get; set; }

	public string sequencia2 { get; set; }

	public int volume2 { get; set; }

	public int volumesTotal2 { get; set; }

	public rptEtiquetaMBenzGLTA4()
	{
		InitializeComponent();
	}

	public rptEtiquetaMBenzGLTA4(int capacidadeEmbalagem, string codigoFornecedor, DateTime dataChamada, string descricaoItem, string codigoEmbalagem, string codigoProduto, string localDescarga, string nomeFornecedor, string numeroChamada, int quantidade, decimal pesoBruto, decimal pesoLiquido, string plantaDestino, string sequencia, int volume, int volumesTotal, int capacidadeEmbalagem2, string codigoFornecedor2, DateTime dataChamada2, string descricaoItem2, string codigoEmbalagem2, string codigoProduto2, string localDescarga2, string nomeFornecedor2, string numeroChamada2, int quantidade2, decimal pesoBruto2, decimal pesoLiquido2, string plantaDestino2, string sequencia2, int volume2, int volumesTotal2)
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
		this.capacidadeEmbalagem2 = capacidadeEmbalagem2;
		this.codigoFornecedor2 = codigoFornecedor2;
		this.dataChamada2 = dataChamada2;
		this.descricaoItem2 = descricaoItem2;
		this.codigoEmbalagem2 = codigoEmbalagem2;
		this.codigoProduto2 = codigoProduto2;
		this.localDescarga2 = localDescarga2;
		this.nomeFornecedor2 = nomeFornecedor2;
		this.numeroChamada2 = numeroChamada2;
		this.quantidade2 = quantidade2;
		this.pesoBruto2 = pesoBruto2;
		this.pesoLiquido2 = pesoLiquido2;
		this.plantaDestino2 = plantaDestino2;
		this.sequencia2 = sequencia2;
		this.volume2 = volume2;
		this.volumesTotal2 = volumesTotal2;
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
		((XRControl)txCapacidadeEmbalagem2).Text = capacidadeEmbalagem2.ToString();
		((XRControl)txCodigoFornecedor2).Text = codigoFornecedor2;
		((XRControl)txDataChamada2).Text = dataChamada2.ToShortDateString();
		((XRControl)txDescricaoItem2).Text = descricaoItem2;
		((XRControl)txEmbalagem2).Text = codigoEmbalagem2;
		((XRControl)txItem2).Text = codigoProduto2;
		((XRControl)txLocalDescarga2).Text = localDescarga2;
		((XRControl)txNomeFornecedor2).Text = nomeFornecedor2;
		((XRControl)txNumeroChamada2).Text = numeroChamada2.PadLeft(12, '0');
		((XRControl)txPecas2).Text = $"{quantidade2} PÇS";
		((XRControl)txPesoBruto2).Text = $"{pesoBruto2:F3} Kg";
		((XRControl)txPesoLiquido2).Text = $"{pesoLiquido2:F3} Kg";
		((XRControl)txPlantaDestino2).Text = plantaDestino2;
		((XRControl)txSequencia2).Text = sequencia.ToString();
		((XRControl)txVolume2).Text = $"Volumes: {volume2} de {volumesTotal2}";
		((XRControl)txDataMatrix2).Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", dataChamada2.ToString("yy"), dataChamada2.ToString("MM"), dataChamada2.ToString("dd"), numeroChamada2.PadLeft(12, '0'), sequencia.ToString().PadLeft(2, '0'), codigoProduto2.PadRight(21), (quantidade2 * 1000).ToString().PadLeft(14, '0'), volume2.ToString().PadLeft(2, '0'), volumesTotal2.ToString().PadLeft(2, '0'));
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
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_102d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1065: Unknown result type (might be due to invalid IL or missing references)
		//IL_1109: Unknown result type (might be due to invalid IL or missing references)
		//IL_1141: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_121d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1306: Unknown result type (might be due to invalid IL or missing references)
		//IL_13aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1486: Unknown result type (might be due to invalid IL or missing references)
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Unknown result type (might be due to invalid IL or missing references)
		//IL_159a: Unknown result type (might be due to invalid IL or missing references)
		//IL_163e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1676: Unknown result type (might be due to invalid IL or missing references)
		//IL_171a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1752: Unknown result type (might be due to invalid IL or missing references)
		//IL_17db: Unknown result type (might be due to invalid IL or missing references)
		//IL_184e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1886: Unknown result type (might be due to invalid IL or missing references)
		//IL_192a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1962: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2033: Unknown result type (might be due to invalid IL or missing references)
		//IL_206c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2115: Unknown result type (might be due to invalid IL or missing references)
		//IL_214d: Unknown result type (might be due to invalid IL or missing references)
		//IL_21df: Unknown result type (might be due to invalid IL or missing references)
		//IL_221b: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_230d: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_248e: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_256a: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2646: Unknown result type (might be due to invalid IL or missing references)
		//IL_267e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2722: Unknown result type (might be due to invalid IL or missing references)
		//IL_275a: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2856: Unknown result type (might be due to invalid IL or missing references)
		//IL_288e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2932: Unknown result type (might be due to invalid IL or missing references)
		//IL_296a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_301f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3057: Unknown result type (might be due to invalid IL or missing references)
		//IL_3108: Unknown result type (might be due to invalid IL or missing references)
		//IL_3140: Unknown result type (might be due to invalid IL or missing references)
		//IL_31e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_321c: Unknown result type (might be due to invalid IL or missing references)
		//IL_32c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_339c: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3478: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3554: Unknown result type (might be due to invalid IL or missing references)
		//IL_358c: Unknown result type (might be due to invalid IL or missing references)
		//IL_363d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3675: Unknown result type (might be due to invalid IL or missing references)
		//IL_3719: Unknown result type (might be due to invalid IL or missing references)
		//IL_3751: Unknown result type (might be due to invalid IL or missing references)
		//IL_37da: Unknown result type (might be due to invalid IL or missing references)
		//IL_384d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3885: Unknown result type (might be due to invalid IL or missing references)
		//IL_3929: Unknown result type (might be due to invalid IL or missing references)
		//IL_3961: Unknown result type (might be due to invalid IL or missing references)
		DataMatrixGenerator val = new DataMatrixGenerator();
		DataMatrixGenerator val2 = new DataMatrixGenerator();
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
		xrLabel2 = new XRLabel();
		txItem2 = new XRLabel();
		txDataMatrix2 = new XRBarCode();
		txPecas2 = new XRLabel();
		xrLabel7 = new XRLabel();
		txLocalDescarga2 = new XRLabel();
		txPlantaDestino2 = new XRLabel();
		xrLabel13 = new XRLabel();
		txVolume2 = new XRLabel();
		xrLine3 = new XRLine();
		xrLabel16 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel20 = new XRLabel();
		txCapacidadeEmbalagem2 = new XRLabel();
		txEmbalagem2 = new XRLabel();
		txDescricaoItem2 = new XRLabel();
		txPesoBruto2 = new XRLabel();
		xrLabel29 = new XRLabel();
		txNomeFornecedor2 = new XRLabel();
		xrLabel31 = new XRLabel();
		txCodigoFornecedor2 = new XRLabel();
		xrLabel33 = new XRLabel();
		txPesoLiquido2 = new XRLabel();
		xrLabel35 = new XRLabel();
		txNumeroChamada2 = new XRLabel();
		xrLabel37 = new XRLabel();
		txDataChamada2 = new XRLabel();
		xrLabel39 = new XRLabel();
		xrLine4 = new XRLine();
		txSequencia2 = new XRLabel();
		xrLabel41 = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)TopMargin).Dpi = 254f;
		((XRControl)TopMargin).HeightF = 80f;
		((XRControl)TopMargin).Name = "TopMargin";
		((XRControl)BottomMargin).Dpi = 254f;
		((XRControl)BottomMargin).HeightF = 0f;
		((XRControl)BottomMargin).Name = "BottomMargin";
		((XRControl)Detail).Controls.AddRange((XRControl[])(object)new XRControl[62]
		{
			(XRControl)xrLabel2,
			(XRControl)txItem2,
			(XRControl)txDataMatrix2,
			(XRControl)txPecas2,
			(XRControl)xrLabel7,
			(XRControl)txLocalDescarga2,
			(XRControl)txPlantaDestino2,
			(XRControl)xrLabel13,
			(XRControl)txVolume2,
			(XRControl)xrLine3,
			(XRControl)xrLabel16,
			(XRControl)xrLabel18,
			(XRControl)xrLabel20,
			(XRControl)txCapacidadeEmbalagem2,
			(XRControl)txEmbalagem2,
			(XRControl)txDescricaoItem2,
			(XRControl)txPesoBruto2,
			(XRControl)xrLabel29,
			(XRControl)txNomeFornecedor2,
			(XRControl)xrLabel31,
			(XRControl)txCodigoFornecedor2,
			(XRControl)xrLabel33,
			(XRControl)txPesoLiquido2,
			(XRControl)xrLabel35,
			(XRControl)txNumeroChamada2,
			(XRControl)xrLabel37,
			(XRControl)txDataChamada2,
			(XRControl)xrLabel39,
			(XRControl)xrLine4,
			(XRControl)txSequencia2,
			(XRControl)xrLabel41,
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
		((XRControl)Detail).HeightF = 2900.67f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).BeforePrint += Detail_BeforePrint;
		((XRControl)xrLabel27).Dpi = 254f;
		((XRControl)xrLabel27).Font = new Font("Arial", 12f);
		((XRControl)xrLabel27).LocationFloat = new PointFloat(1156.696f, 1164.109f);
		xrLabel27.Multiline = true;
		((XRControl)xrLabel27).Name = "xrLabel27";
		((XRControl)xrLabel27).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel27).SizeF = new SizeF(270.8309f, 55.38062f);
		((XRControl)xrLabel27).StylePriority.UseFont = false;
		((XRControl)xrLabel27).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel27).Text = "Sequencia";
		((XRControl)xrLabel27).TextAlignment = (TextAlignment)1;
		((XRControl)txSequencia).Dpi = 254f;
		((XRControl)txSequencia).Font = new Font("Arial", 12f);
		((XRControl)txSequencia).LocationFloat = new PointFloat(1156.696f, 1219.489f);
		txSequencia.Multiline = true;
		((XRControl)txSequencia).Name = "txSequencia";
		((XRControl)txSequencia).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txSequencia).SizeF = new SizeF(270.8309f, 55.38074f);
		((XRControl)txSequencia).StylePriority.UseFont = false;
		((XRControl)txSequencia).StylePriority.UseTextAlignment = false;
		((XRControl)txSequencia).Text = "01";
		((XRControl)txSequencia).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(0f, 1302.807f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(1940f, 5.291748f);
		((XRControl)xrLabel21).Dpi = 254f;
		((XRControl)xrLabel21).Font = new Font("Arial", 12f);
		((XRControl)xrLabel21).LocationFloat = new PointFloat(50.30152f, 1164.109f);
		xrLabel21.Multiline = true;
		((XRControl)xrLabel21).Name = "xrLabel21";
		((XRControl)xrLabel21).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel21).SizeF = new SizeF(382.155f, 55.38062f);
		((XRControl)xrLabel21).StylePriority.UseFont = false;
		((XRControl)xrLabel21).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel21).Text = "Data Chamada";
		((XRControl)xrLabel21).TextAlignment = (TextAlignment)1;
		((XRControl)txDataChamada).CanGrow = false;
		((XRControl)txDataChamada).Dpi = 254f;
		((XRControl)txDataChamada).Font = new Font("Arial", 12f);
		((XRControl)txDataChamada).LocationFloat = new PointFloat(50.30152f, 1219.489f);
		txDataChamada.Multiline = true;
		((XRControl)txDataChamada).Name = "txDataChamada";
		((XRControl)txDataChamada).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDataChamada).SizeF = new SizeF(382.155f, 55.38074f);
		((XRControl)txDataChamada).StylePriority.UseFont = false;
		((XRControl)txDataChamada).StylePriority.UseTextAlignment = false;
		((XRControl)txDataChamada).Text = "28/02/2018";
		((XRControl)txDataChamada).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel23).Dpi = 254f;
		((XRControl)xrLabel23).Font = new Font("Arial", 12f);
		((XRControl)xrLabel23).LocationFloat = new PointFloat(542.0925f, 1164.109f);
		xrLabel23.Multiline = true;
		((XRControl)xrLabel23).Name = "xrLabel23";
		((XRControl)xrLabel23).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel23).SizeF = new SizeF(418.8233f, 55.38062f);
		((XRControl)xrLabel23).StylePriority.UseFont = false;
		((XRControl)xrLabel23).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel23).Text = "Numero Chamada";
		((XRControl)xrLabel23).TextAlignment = (TextAlignment)1;
		((XRControl)txNumeroChamada).Dpi = 254f;
		((XRControl)txNumeroChamada).Font = new Font("Arial", 12f);
		((XRControl)txNumeroChamada).LocationFloat = new PointFloat(542.0925f, 1219.489f);
		txNumeroChamada.Multiline = true;
		((XRControl)txNumeroChamada).Name = "txNumeroChamada";
		((XRControl)txNumeroChamada).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNumeroChamada).SizeF = new SizeF(418.8233f, 55.38074f);
		((XRControl)txNumeroChamada).StylePriority.UseFont = false;
		((XRControl)txNumeroChamada).StylePriority.UseTextAlignment = false;
		((XRControl)txNumeroChamada).Text = "000000000042";
		((XRControl)txNumeroChamada).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel25).Dpi = 254f;
		((XRControl)xrLabel25).Font = new Font("Arial", 12f);
		((XRControl)xrLabel25).LocationFloat = new PointFloat(1548.167f, 1164.109f);
		xrLabel25.Multiline = true;
		((XRControl)xrLabel25).Name = "xrLabel25";
		((XRControl)xrLabel25).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel25).SizeF = new SizeF(339.4373f, 55.38062f);
		((XRControl)xrLabel25).StylePriority.UseFont = false;
		((XRControl)xrLabel25).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel25).Text = "Peso Líquido";
		((XRControl)xrLabel25).TextAlignment = (TextAlignment)4;
		((XRControl)txPesoLiquido).Dpi = 254f;
		((XRControl)txPesoLiquido).Font = new Font("Arial", 12f);
		((XRControl)txPesoLiquido).LocationFloat = new PointFloat(1548.167f, 1219.489f);
		txPesoLiquido.Multiline = true;
		((XRControl)txPesoLiquido).Name = "txPesoLiquido";
		((XRControl)txPesoLiquido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoLiquido).SizeF = new SizeF(339.4373f, 55.38086f);
		((XRControl)txPesoLiquido).StylePriority.UseFont = false;
		((XRControl)txPesoLiquido).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoLiquido).Text = "9,000 Kg";
		((XRControl)txPesoLiquido).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel15).Dpi = 254f;
		((XRControl)xrLabel15).Font = new Font("Arial", 12f);
		((XRControl)xrLabel15).LocationFloat = new PointFloat(50.30152f, 987.0143f);
		xrLabel15.Multiline = true;
		((XRControl)xrLabel15).Name = "xrLabel15";
		((XRControl)xrLabel15).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel15).SizeF = new SizeF(530.3217f, 55.38068f);
		((XRControl)xrLabel15).StylePriority.UseFont = false;
		((XRControl)xrLabel15).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel15).Text = "Fornecedor";
		((XRControl)xrLabel15).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoFornecedor).CanGrow = false;
		((XRControl)txCodigoFornecedor).Dpi = 254f;
		((XRControl)txCodigoFornecedor).Font = new Font("Arial", 12f);
		((XRControl)txCodigoFornecedor).LocationFloat = new PointFloat(50.30152f, 1042.395f);
		txCodigoFornecedor.Multiline = true;
		((XRControl)txCodigoFornecedor).Name = "txCodigoFornecedor";
		((XRControl)txCodigoFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoFornecedor).SizeF = new SizeF(530.3217f, 55.38062f);
		((XRControl)txCodigoFornecedor).StylePriority.UseFont = false;
		((XRControl)txCodigoFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoFornecedor).Text = "11827800";
		((XRControl)txCodigoFornecedor).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel17).Dpi = 254f;
		((XRControl)xrLabel17).Font = new Font("Arial", 12f);
		((XRControl)xrLabel17).LocationFloat = new PointFloat(619.6324f, 987.0145f);
		xrLabel17.Multiline = true;
		((XRControl)xrLabel17).Name = "xrLabel17";
		((XRControl)xrLabel17).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel17).SizeF = new SizeF(779.601f, 55.38049f);
		((XRControl)xrLabel17).StylePriority.UseFont = false;
		((XRControl)xrLabel17).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel17).Text = "Nome Fornecedor";
		((XRControl)xrLabel17).TextAlignment = (TextAlignment)1;
		((XRControl)txNomeFornecedor).Dpi = 254f;
		((XRControl)txNomeFornecedor).Font = new Font("Arial", 12f);
		((XRControl)txNomeFornecedor).LocationFloat = new PointFloat(619.6324f, 1042.395f);
		txNomeFornecedor.Multiline = true;
		((XRControl)txNomeFornecedor).Name = "txNomeFornecedor";
		((XRControl)txNomeFornecedor).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeFornecedor).SizeF = new SizeF(779.601f, 55.38062f);
		((XRControl)txNomeFornecedor).StylePriority.UseFont = false;
		((XRControl)txNomeFornecedor).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeFornecedor).Text = "METALURGICA CARTEC";
		((XRControl)txNomeFornecedor).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel19).Dpi = 254f;
		((XRControl)xrLabel19).Font = new Font("Arial", 12f);
		((XRControl)xrLabel19).LocationFloat = new PointFloat(1548.167f, 987.0142f);
		xrLabel19.Multiline = true;
		((XRControl)xrLabel19).Name = "xrLabel19";
		((XRControl)xrLabel19).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel19).SizeF = new SizeF(339.4373f, 55.38055f);
		((XRControl)xrLabel19).StylePriority.UseFont = false;
		((XRControl)xrLabel19).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel19).Text = "Peso Bruto";
		((XRControl)xrLabel19).TextAlignment = (TextAlignment)4;
		((XRControl)txPesoBruto).Dpi = 254f;
		((XRControl)txPesoBruto).Font = new Font("Arial", 12f);
		((XRControl)txPesoBruto).LocationFloat = new PointFloat(1548.167f, 1042.395f);
		txPesoBruto.Multiline = true;
		((XRControl)txPesoBruto).Name = "txPesoBruto";
		((XRControl)txPesoBruto).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoBruto).SizeF = new SizeF(339.4374f, 55.38062f);
		((XRControl)txPesoBruto).StylePriority.UseFont = false;
		((XRControl)txPesoBruto).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoBruto).Text = "103,000 Kg";
		((XRControl)txPesoBruto).TextAlignment = (TextAlignment)4;
		((XRControl)txDescricaoItem).CanGrow = false;
		((XRControl)txDescricaoItem).Dpi = 254f;
		((XRControl)txDescricaoItem).Font = new Font("Arial", 12f);
		((XRControl)txDescricaoItem).LocationFloat = new PointFloat(50.30152f, 850.4253f);
		txDescricaoItem.Multiline = true;
		((XRControl)txDescricaoItem).Name = "txDescricaoItem";
		((XRControl)txDescricaoItem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricaoItem).SizeF = new SizeF(837.2402f, 55.38062f);
		((XRControl)txDescricaoItem).StylePriority.UseFont = false;
		((XRControl)txDescricaoItem).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricaoItem).Text = "PC1161 BT MBB BUS";
		((XRControl)txDescricaoItem).TextAlignment = (TextAlignment)1;
		((XRControl)txEmbalagem).Dpi = 254f;
		((XRControl)txEmbalagem).Font = new Font("Arial", 12f);
		((XRControl)txEmbalagem).LocationFloat = new PointFloat(904.573f, 850.4253f);
		txEmbalagem.Multiline = true;
		((XRControl)txEmbalagem).Name = "txEmbalagem";
		((XRControl)txEmbalagem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmbalagem).SizeF = new SizeF(297.1035f, 55.38062f);
		((XRControl)txEmbalagem).StylePriority.UseFont = false;
		((XRControl)txEmbalagem).StylePriority.UseTextAlignment = false;
		((XRControl)txEmbalagem).Text = "T51312";
		((XRControl)txEmbalagem).TextAlignment = (TextAlignment)2;
		((XRControl)txCapacidadeEmbalagem).Dpi = 254f;
		((XRControl)txCapacidadeEmbalagem).Font = new Font("Arial", 12f);
		((XRControl)txCapacidadeEmbalagem).LocationFloat = new PointFloat(1292.015f, 850.4255f);
		txCapacidadeEmbalagem.Multiline = true;
		((XRControl)txCapacidadeEmbalagem).Name = "txCapacidadeEmbalagem";
		((XRControl)txCapacidadeEmbalagem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCapacidadeEmbalagem).SizeF = new SizeF(595.589f, 55.38062f);
		((XRControl)txCapacidadeEmbalagem).StylePriority.UseFont = false;
		((XRControl)txCapacidadeEmbalagem).StylePriority.UseTextAlignment = false;
		((XRControl)txCapacidadeEmbalagem).Text = "50";
		((XRControl)txCapacidadeEmbalagem).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel11).Dpi = 254f;
		((XRControl)xrLabel11).Font = new Font("Arial", 12f);
		((XRControl)xrLabel11).LocationFloat = new PointFloat(1292.016f, 795.0448f);
		xrLabel11.Multiline = true;
		((XRControl)xrLabel11).Name = "xrLabel11";
		((XRControl)xrLabel11).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel11).SizeF = new SizeF(595.589f, 55.38062f);
		((XRControl)xrLabel11).StylePriority.UseFont = false;
		((XRControl)xrLabel11).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel11).Text = "Capacidade Embalagem";
		((XRControl)xrLabel11).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel10).Dpi = 254f;
		((XRControl)xrLabel10).Font = new Font("Arial", 12f);
		((XRControl)xrLabel10).LocationFloat = new PointFloat(904.573f, 795.0445f);
		xrLabel10.Multiline = true;
		((XRControl)xrLabel10).Name = "xrLabel10";
		((XRControl)xrLabel10).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel10).SizeF = new SizeF(297.1035f, 55.38062f);
		((XRControl)xrLabel10).StylePriority.UseFont = false;
		((XRControl)xrLabel10).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel10).Text = "Embalagem";
		((XRControl)xrLabel10).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel9).Dpi = 254f;
		((XRControl)xrLabel9).Font = new Font("Arial", 12f);
		((XRControl)xrLabel9).LocationFloat = new PointFloat(50.30152f, 795.0447f);
		xrLabel9.Multiline = true;
		((XRControl)xrLabel9).Name = "xrLabel9";
		((XRControl)xrLabel9).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel9).SizeF = new SizeF(802.4575f, 55.38062f);
		((XRControl)xrLabel9).StylePriority.UseFont = false;
		((XRControl)xrLabel9).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel9).Text = "Denominação Item";
		((XRControl)xrLabel9).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(0f, 742.0655f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(1940f, 12.9375f);
		((XRControl)txVolume).Dpi = 254f;
		((XRControl)txVolume).Font = new Font("Arial", 24f);
		((XRControl)txVolume).LocationFloat = new PointFloat(368.9584f, 571.957f);
		txVolume.Multiline = true;
		((XRControl)txVolume).Name = "txVolume";
		((XRControl)txVolume).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txVolume).SizeF = new SizeF(779.8018f, 117.6918f);
		((XRControl)txVolume).StylePriority.UseFont = false;
		((XRControl)txVolume).StylePriority.UseTextAlignment = false;
		((XRControl)txVolume).Text = "Volume: 1 de 2";
		((XRControl)txVolume).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel6).Dpi = 254f;
		((XRControl)xrLabel6).Font = new Font("Arial", 16f);
		((XRControl)xrLabel6).LocationFloat = new PointFloat(802.3396f, 324.5701f);
		xrLabel6.Multiline = true;
		((XRControl)xrLabel6).Name = "xrLabel6";
		((XRControl)xrLabel6).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel6).SizeF = new SizeF(511.4158f, 67.42087f);
		((XRControl)xrLabel6).StylePriority.UseFont = false;
		((XRControl)xrLabel6).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel6).Text = "Planta de destino";
		((XRControl)xrLabel6).TextAlignment = (TextAlignment)2;
		((XRControl)txPlantaDestino).Dpi = 254f;
		((XRControl)txPlantaDestino).Font = new Font("Arial", 34f);
		((XRControl)txPlantaDestino).LocationFloat = new PointFloat(802.3396f, 391.991f);
		txPlantaDestino.Multiline = true;
		((XRControl)txPlantaDestino).Name = "txPlantaDestino";
		((XRControl)txPlantaDestino).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPlantaDestino).SizeF = new SizeF(511.4158f, 141.9093f);
		((XRControl)txPlantaDestino).StylePriority.UseFont = false;
		((XRControl)txPlantaDestino).StylePriority.UseTextAlignment = false;
		((XRControl)txPlantaDestino).Text = "SBC";
		((XRControl)txPlantaDestino).TextAlignment = (TextAlignment)2;
		((XRControl)txLocalDescarga).Dpi = 254f;
		((XRControl)txLocalDescarga).Font = new Font("Arial", 34f);
		((XRControl)txLocalDescarga).LocationFloat = new PointFloat(50.30152f, 391.991f);
		txLocalDescarga.Multiline = true;
		((XRControl)txLocalDescarga).Name = "txLocalDescarga";
		((XRControl)txLocalDescarga).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txLocalDescarga).SizeF = new SizeF(437.3325f, 141.9094f);
		((XRControl)txLocalDescarga).StylePriority.UseFont = false;
		((XRControl)txLocalDescarga).StylePriority.UseTextAlignment = false;
		((XRControl)txLocalDescarga).Text = "21B";
		((XRControl)txLocalDescarga).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel4).Dpi = 254f;
		((XRControl)xrLabel4).Font = new Font("Arial", 16f);
		((XRControl)xrLabel4).LocationFloat = new PointFloat(50.30152f, 324.5701f);
		xrLabel4.Multiline = true;
		((XRControl)xrLabel4).Name = "xrLabel4";
		((XRControl)xrLabel4).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel4).SizeF = new SizeF(437.3325f, 67.42087f);
		((XRControl)xrLabel4).StylePriority.UseFont = false;
		((XRControl)xrLabel4).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel4).Text = "Local Descarga";
		((XRControl)xrLabel4).TextAlignment = (TextAlignment)1;
		((XRControl)txPecas).Dpi = 254f;
		((XRControl)txPecas).Font = new Font("Arial", 18f);
		((XRControl)txPecas).LocationFloat = new PointFloat(1456.057f, 113.4135f);
		txPecas.Multiline = true;
		((XRControl)txPecas).Name = "txPecas";
		((XRControl)txPecas).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecas).SizeF = new SizeF(431.5472f, 91.71441f);
		((XRControl)txPecas).StylePriority.UseFont = false;
		((XRControl)txPecas).StylePriority.UseTextAlignment = false;
		((XRControl)txPecas).Text = "20 pcs";
		((XRControl)txPecas).TextAlignment = (TextAlignment)64;
		txDataMatrix.AutoModule = true;
		((XRControl)txDataMatrix).Dpi = 254f;
		((XRControl)txDataMatrix).Font = new Font("Arial", 6f);
		((XRControl)txDataMatrix).LocationFloat = new PointFloat(1427.604f, 229.6488f);
		txDataMatrix.Module = 5.08f;
		((XRControl)txDataMatrix).Name = "txDataMatrix";
		((XRControl)txDataMatrix).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		txDataMatrix.ShowText = false;
		((XRControl)txDataMatrix).SizeF = new SizeF(460f, 460f);
		((XRControl)txDataMatrix).StylePriority.UseFont = false;
		((XRControl)txDataMatrix).StylePriority.UsePadding = false;
		val.MatrixSize = (DataMatrixSize)14;
		txDataMatrix.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)txDataMatrix).Text = "2802201800000000004201A36432100062022";
		((XRControl)txItem).Dpi = 254f;
		((XRControl)txItem).Font = new Font("Arial", 34f);
		((XRControl)txItem).LocationFloat = new PointFloat(50.30152f, 113.4135f);
		txItem.Multiline = true;
		((XRControl)txItem).Name = "txItem";
		((XRControl)txItem).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItem).SizeF = new SizeF(1116.099f, 141.9853f);
		((XRControl)txItem).StylePriority.UseFont = false;
		((XRControl)txItem).Text = "A3643210006";
		((XRControl)xrLabel1).Borders = (BorderSide)8;
		((XRControl)xrLabel1).Dpi = 254f;
		((XRControl)xrLabel1).Font = new Font("Arial", 12f);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(0f, 0f);
		xrLabel1.Multiline = true;
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(20, 5, 0, 0, 254f);
		((XRControl)xrLabel1).SizeF = new SizeF(1940f, 79.30939f);
		((XRControl)xrLabel1).StylePriority.UseBorders = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UsePadding = false;
		((XRControl)xrLabel1).Text = "Mercedes-Benz do Brasil Ltda.";
		((XRControl)xrLabel2).Borders = (BorderSide)8;
		((XRControl)xrLabel2).Dpi = 254f;
		((XRControl)xrLabel2).Font = new Font("Arial", 12f);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(0f, 1439.793f);
		xrLabel2.Multiline = true;
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(20, 5, 0, 0, 254f);
		((XRControl)xrLabel2).SizeF = new SizeF(1940f, 79.30939f);
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UsePadding = false;
		((XRControl)xrLabel2).Text = "Mercedes-Benz do Brasil Ltda.";
		((XRControl)txItem2).Dpi = 254f;
		((XRControl)txItem2).Font = new Font("Arial", 34f);
		((XRControl)txItem2).LocationFloat = new PointFloat(50.30184f, 1553.206f);
		txItem2.Multiline = true;
		((XRControl)txItem2).Name = "txItem2";
		((XRControl)txItem2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txItem2).SizeF = new SizeF(1116.099f, 141.9853f);
		((XRControl)txItem2).StylePriority.UseFont = false;
		((XRControl)txItem2).Text = "A3643210006";
		txDataMatrix2.AutoModule = true;
		((XRControl)txDataMatrix2).Dpi = 254f;
		((XRControl)txDataMatrix2).Font = new Font("Arial", 6f);
		((XRControl)txDataMatrix2).LocationFloat = new PointFloat(1427.604f, 1669.442f);
		txDataMatrix2.Module = 5.08f;
		((XRControl)txDataMatrix2).Name = "txDataMatrix2";
		((XRControl)txDataMatrix2).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		txDataMatrix2.ShowText = false;
		((XRControl)txDataMatrix2).SizeF = new SizeF(460f, 460f);
		((XRControl)txDataMatrix2).StylePriority.UseFont = false;
		((XRControl)txDataMatrix2).StylePriority.UsePadding = false;
		val2.MatrixSize = (DataMatrixSize)14;
		txDataMatrix2.Symbology = (BarCodeGeneratorBase)(object)val2;
		((XRControl)txDataMatrix2).Text = "2802201800000000004201A36432100062022";
		((XRControl)txPecas2).Dpi = 254f;
		((XRControl)txPecas2).Font = new Font("Arial", 18f);
		((XRControl)txPecas2).LocationFloat = new PointFloat(1456.057f, 1553.206f);
		txPecas2.Multiline = true;
		((XRControl)txPecas2).Name = "txPecas2";
		((XRControl)txPecas2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPecas2).SizeF = new SizeF(431.5472f, 91.71441f);
		((XRControl)txPecas2).StylePriority.UseFont = false;
		((XRControl)txPecas2).StylePriority.UseTextAlignment = false;
		((XRControl)txPecas2).Text = "20 pcs";
		((XRControl)txPecas2).TextAlignment = (TextAlignment)64;
		((XRControl)xrLabel7).Dpi = 254f;
		((XRControl)xrLabel7).Font = new Font("Arial", 16f);
		((XRControl)xrLabel7).LocationFloat = new PointFloat(50.30184f, 1764.363f);
		xrLabel7.Multiline = true;
		((XRControl)xrLabel7).Name = "xrLabel7";
		((XRControl)xrLabel7).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel7).SizeF = new SizeF(437.3325f, 67.42087f);
		((XRControl)xrLabel7).StylePriority.UseFont = false;
		((XRControl)xrLabel7).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel7).Text = "Local Descarga";
		((XRControl)xrLabel7).TextAlignment = (TextAlignment)1;
		((XRControl)txLocalDescarga2).Dpi = 254f;
		((XRControl)txLocalDescarga2).Font = new Font("Arial", 34f);
		((XRControl)txLocalDescarga2).LocationFloat = new PointFloat(50.30184f, 1831.784f);
		txLocalDescarga2.Multiline = true;
		((XRControl)txLocalDescarga2).Name = "txLocalDescarga2";
		((XRControl)txLocalDescarga2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txLocalDescarga2).SizeF = new SizeF(437.3325f, 141.9094f);
		((XRControl)txLocalDescarga2).StylePriority.UseFont = false;
		((XRControl)txLocalDescarga2).StylePriority.UseTextAlignment = false;
		((XRControl)txLocalDescarga2).Text = "21B";
		((XRControl)txLocalDescarga2).TextAlignment = (TextAlignment)1;
		((XRControl)txPlantaDestino2).Dpi = 254f;
		((XRControl)txPlantaDestino2).Font = new Font("Arial", 34f);
		((XRControl)txPlantaDestino2).LocationFloat = new PointFloat(802.3399f, 1831.784f);
		txPlantaDestino2.Multiline = true;
		((XRControl)txPlantaDestino2).Name = "txPlantaDestino2";
		((XRControl)txPlantaDestino2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPlantaDestino2).SizeF = new SizeF(511.4158f, 141.9093f);
		((XRControl)txPlantaDestino2).StylePriority.UseFont = false;
		((XRControl)txPlantaDestino2).StylePriority.UseTextAlignment = false;
		((XRControl)txPlantaDestino2).Text = "SBC";
		((XRControl)txPlantaDestino2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel13).Dpi = 254f;
		((XRControl)xrLabel13).Font = new Font("Arial", 16f);
		((XRControl)xrLabel13).LocationFloat = new PointFloat(802.3399f, 1764.363f);
		xrLabel13.Multiline = true;
		((XRControl)xrLabel13).Name = "xrLabel13";
		((XRControl)xrLabel13).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel13).SizeF = new SizeF(511.4158f, 67.42087f);
		((XRControl)xrLabel13).StylePriority.UseFont = false;
		((XRControl)xrLabel13).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel13).Text = "Planta de destino";
		((XRControl)xrLabel13).TextAlignment = (TextAlignment)2;
		((XRControl)txVolume2).Dpi = 254f;
		((XRControl)txVolume2).Font = new Font("Arial", 24f);
		((XRControl)txVolume2).LocationFloat = new PointFloat(368.9581f, 2011.75f);
		txVolume2.Multiline = true;
		((XRControl)txVolume2).Name = "txVolume2";
		((XRControl)txVolume2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txVolume2).SizeF = new SizeF(779.8018f, 117.6918f);
		((XRControl)txVolume2).StylePriority.UseFont = false;
		((XRControl)txVolume2).StylePriority.UseTextAlignment = false;
		((XRControl)txVolume2).Text = "Volume: 2 de 2";
		((XRControl)txVolume2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(0f, 2181.858f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(1940f, 12.9375f);
		((XRControl)xrLabel16).Dpi = 254f;
		((XRControl)xrLabel16).Font = new Font("Arial", 12f);
		((XRControl)xrLabel16).LocationFloat = new PointFloat(50.30184f, 2234.838f);
		xrLabel16.Multiline = true;
		((XRControl)xrLabel16).Name = "xrLabel16";
		((XRControl)xrLabel16).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel16).SizeF = new SizeF(802.4575f, 55.38062f);
		((XRControl)xrLabel16).StylePriority.UseFont = false;
		((XRControl)xrLabel16).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel16).Text = "Denominação Item";
		((XRControl)xrLabel16).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel18).Dpi = 254f;
		((XRControl)xrLabel18).Font = new Font("Arial", 12f);
		((XRControl)xrLabel18).LocationFloat = new PointFloat(904.5731f, 2234.838f);
		xrLabel18.Multiline = true;
		((XRControl)xrLabel18).Name = "xrLabel18";
		((XRControl)xrLabel18).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel18).SizeF = new SizeF(297.1035f, 55.38062f);
		((XRControl)xrLabel18).StylePriority.UseFont = false;
		((XRControl)xrLabel18).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel18).Text = "Embalagem";
		((XRControl)xrLabel18).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel20).Dpi = 254f;
		((XRControl)xrLabel20).Font = new Font("Arial", 12f);
		((XRControl)xrLabel20).LocationFloat = new PointFloat(1292.016f, 2234.838f);
		xrLabel20.Multiline = true;
		((XRControl)xrLabel20).Name = "xrLabel20";
		((XRControl)xrLabel20).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel20).SizeF = new SizeF(595.589f, 55.38062f);
		((XRControl)xrLabel20).StylePriority.UseFont = false;
		((XRControl)xrLabel20).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel20).Text = "Capacidade Embalagem";
		((XRControl)xrLabel20).TextAlignment = (TextAlignment)4;
		((XRControl)txCapacidadeEmbalagem2).Dpi = 254f;
		((XRControl)txCapacidadeEmbalagem2).Font = new Font("Arial", 12f);
		((XRControl)txCapacidadeEmbalagem2).LocationFloat = new PointFloat(1292.016f, 2290.218f);
		txCapacidadeEmbalagem2.Multiline = true;
		((XRControl)txCapacidadeEmbalagem2).Name = "txCapacidadeEmbalagem2";
		((XRControl)txCapacidadeEmbalagem2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCapacidadeEmbalagem2).SizeF = new SizeF(595.589f, 55.38062f);
		((XRControl)txCapacidadeEmbalagem2).StylePriority.UseFont = false;
		((XRControl)txCapacidadeEmbalagem2).StylePriority.UseTextAlignment = false;
		((XRControl)txCapacidadeEmbalagem2).Text = "50";
		((XRControl)txCapacidadeEmbalagem2).TextAlignment = (TextAlignment)4;
		((XRControl)txEmbalagem2).Dpi = 254f;
		((XRControl)txEmbalagem2).Font = new Font("Arial", 12f);
		((XRControl)txEmbalagem2).LocationFloat = new PointFloat(904.5731f, 2290.218f);
		txEmbalagem2.Multiline = true;
		((XRControl)txEmbalagem2).Name = "txEmbalagem2";
		((XRControl)txEmbalagem2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEmbalagem2).SizeF = new SizeF(297.1035f, 55.38062f);
		((XRControl)txEmbalagem2).StylePriority.UseFont = false;
		((XRControl)txEmbalagem2).StylePriority.UseTextAlignment = false;
		((XRControl)txEmbalagem2).Text = "T51312";
		((XRControl)txEmbalagem2).TextAlignment = (TextAlignment)2;
		((XRControl)txDescricaoItem2).CanGrow = false;
		((XRControl)txDescricaoItem2).Dpi = 254f;
		((XRControl)txDescricaoItem2).Font = new Font("Arial", 12f);
		((XRControl)txDescricaoItem2).LocationFloat = new PointFloat(50.30184f, 2290.218f);
		txDescricaoItem2.Multiline = true;
		((XRControl)txDescricaoItem2).Name = "txDescricaoItem2";
		((XRControl)txDescricaoItem2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDescricaoItem2).SizeF = new SizeF(837.2402f, 55.38062f);
		((XRControl)txDescricaoItem2).StylePriority.UseFont = false;
		((XRControl)txDescricaoItem2).StylePriority.UseTextAlignment = false;
		((XRControl)txDescricaoItem2).Text = "PC1161 BT MBB BUS";
		((XRControl)txDescricaoItem2).TextAlignment = (TextAlignment)1;
		((XRControl)txPesoBruto2).Dpi = 254f;
		((XRControl)txPesoBruto2).Font = new Font("Arial", 12f);
		((XRControl)txPesoBruto2).LocationFloat = new PointFloat(1548.167f, 2482.188f);
		txPesoBruto2.Multiline = true;
		((XRControl)txPesoBruto2).Name = "txPesoBruto2";
		((XRControl)txPesoBruto2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoBruto2).SizeF = new SizeF(339.4374f, 55.38062f);
		((XRControl)txPesoBruto2).StylePriority.UseFont = false;
		((XRControl)txPesoBruto2).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoBruto2).Text = "103,000 Kg";
		((XRControl)txPesoBruto2).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel29).Dpi = 254f;
		((XRControl)xrLabel29).Font = new Font("Arial", 12f);
		((XRControl)xrLabel29).LocationFloat = new PointFloat(1548.167f, 2426.807f);
		xrLabel29.Multiline = true;
		((XRControl)xrLabel29).Name = "xrLabel29";
		((XRControl)xrLabel29).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel29).SizeF = new SizeF(339.4373f, 55.38055f);
		((XRControl)xrLabel29).StylePriority.UseFont = false;
		((XRControl)xrLabel29).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel29).Text = "Peso Bruto";
		((XRControl)xrLabel29).TextAlignment = (TextAlignment)4;
		((XRControl)txNomeFornecedor2).Dpi = 254f;
		((XRControl)txNomeFornecedor2).Font = new Font("Arial", 12f);
		((XRControl)txNomeFornecedor2).LocationFloat = new PointFloat(619.6327f, 2482.188f);
		txNomeFornecedor2.Multiline = true;
		((XRControl)txNomeFornecedor2).Name = "txNomeFornecedor2";
		((XRControl)txNomeFornecedor2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeFornecedor2).SizeF = new SizeF(779.601f, 55.38062f);
		((XRControl)txNomeFornecedor2).StylePriority.UseFont = false;
		((XRControl)txNomeFornecedor2).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeFornecedor2).Text = "METALURGICA CARTEC";
		((XRControl)txNomeFornecedor2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel31).Dpi = 254f;
		((XRControl)xrLabel31).Font = new Font("Arial", 12f);
		((XRControl)xrLabel31).LocationFloat = new PointFloat(619.6327f, 2426.808f);
		xrLabel31.Multiline = true;
		((XRControl)xrLabel31).Name = "xrLabel31";
		((XRControl)xrLabel31).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel31).SizeF = new SizeF(779.601f, 55.38049f);
		((XRControl)xrLabel31).StylePriority.UseFont = false;
		((XRControl)xrLabel31).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel31).Text = "Nome Fornecedor";
		((XRControl)xrLabel31).TextAlignment = (TextAlignment)1;
		((XRControl)txCodigoFornecedor2).CanGrow = false;
		((XRControl)txCodigoFornecedor2).Dpi = 254f;
		((XRControl)txCodigoFornecedor2).Font = new Font("Arial", 12f);
		((XRControl)txCodigoFornecedor2).LocationFloat = new PointFloat(50.30184f, 2482.188f);
		txCodigoFornecedor2.Multiline = true;
		((XRControl)txCodigoFornecedor2).Name = "txCodigoFornecedor2";
		((XRControl)txCodigoFornecedor2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCodigoFornecedor2).SizeF = new SizeF(530.3217f, 55.38062f);
		((XRControl)txCodigoFornecedor2).StylePriority.UseFont = false;
		((XRControl)txCodigoFornecedor2).StylePriority.UseTextAlignment = false;
		((XRControl)txCodigoFornecedor2).Text = "11827800";
		((XRControl)txCodigoFornecedor2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel33).Dpi = 254f;
		((XRControl)xrLabel33).Font = new Font("Arial", 12f);
		((XRControl)xrLabel33).LocationFloat = new PointFloat(50.30184f, 2426.807f);
		xrLabel33.Multiline = true;
		((XRControl)xrLabel33).Name = "xrLabel33";
		((XRControl)xrLabel33).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel33).SizeF = new SizeF(530.3217f, 55.38068f);
		((XRControl)xrLabel33).StylePriority.UseFont = false;
		((XRControl)xrLabel33).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel33).Text = "Fornecedor";
		((XRControl)xrLabel33).TextAlignment = (TextAlignment)1;
		((XRControl)txPesoLiquido2).Dpi = 254f;
		((XRControl)txPesoLiquido2).Font = new Font("Arial", 12f);
		((XRControl)txPesoLiquido2).LocationFloat = new PointFloat(1548.167f, 2659.282f);
		txPesoLiquido2.Multiline = true;
		((XRControl)txPesoLiquido2).Name = "txPesoLiquido2";
		((XRControl)txPesoLiquido2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txPesoLiquido2).SizeF = new SizeF(339.4373f, 55.38086f);
		((XRControl)txPesoLiquido2).StylePriority.UseFont = false;
		((XRControl)txPesoLiquido2).StylePriority.UseTextAlignment = false;
		((XRControl)txPesoLiquido2).Text = "9,000 Kg";
		((XRControl)txPesoLiquido2).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel35).Dpi = 254f;
		((XRControl)xrLabel35).Font = new Font("Arial", 12f);
		((XRControl)xrLabel35).LocationFloat = new PointFloat(1548.167f, 2603.902f);
		xrLabel35.Multiline = true;
		((XRControl)xrLabel35).Name = "xrLabel35";
		((XRControl)xrLabel35).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel35).SizeF = new SizeF(339.4373f, 55.38062f);
		((XRControl)xrLabel35).StylePriority.UseFont = false;
		((XRControl)xrLabel35).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel35).Text = "Peso Líquido";
		((XRControl)xrLabel35).TextAlignment = (TextAlignment)4;
		((XRControl)txNumeroChamada2).Dpi = 254f;
		((XRControl)txNumeroChamada2).Font = new Font("Arial", 12f);
		((XRControl)txNumeroChamada2).LocationFloat = new PointFloat(542.0931f, 2659.282f);
		txNumeroChamada2.Multiline = true;
		((XRControl)txNumeroChamada2).Name = "txNumeroChamada2";
		((XRControl)txNumeroChamada2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNumeroChamada2).SizeF = new SizeF(418.8233f, 55.38074f);
		((XRControl)txNumeroChamada2).StylePriority.UseFont = false;
		((XRControl)txNumeroChamada2).StylePriority.UseTextAlignment = false;
		((XRControl)txNumeroChamada2).Text = "000000000042";
		((XRControl)txNumeroChamada2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel37).Dpi = 254f;
		((XRControl)xrLabel37).Font = new Font("Arial", 12f);
		((XRControl)xrLabel37).LocationFloat = new PointFloat(542.0931f, 2603.902f);
		xrLabel37.Multiline = true;
		((XRControl)xrLabel37).Name = "xrLabel37";
		((XRControl)xrLabel37).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel37).SizeF = new SizeF(418.8233f, 55.38062f);
		((XRControl)xrLabel37).StylePriority.UseFont = false;
		((XRControl)xrLabel37).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel37).Text = "Numero Chamada";
		((XRControl)xrLabel37).TextAlignment = (TextAlignment)1;
		((XRControl)txDataChamada2).CanGrow = false;
		((XRControl)txDataChamada2).Dpi = 254f;
		((XRControl)txDataChamada2).Font = new Font("Arial", 12f);
		((XRControl)txDataChamada2).LocationFloat = new PointFloat(50.30184f, 2659.282f);
		txDataChamada2.Multiline = true;
		((XRControl)txDataChamada2).Name = "txDataChamada2";
		((XRControl)txDataChamada2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txDataChamada2).SizeF = new SizeF(382.155f, 55.38074f);
		((XRControl)txDataChamada2).StylePriority.UseFont = false;
		((XRControl)txDataChamada2).StylePriority.UseTextAlignment = false;
		((XRControl)txDataChamada2).Text = "28/02/2018";
		((XRControl)txDataChamada2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel39).Dpi = 254f;
		((XRControl)xrLabel39).Font = new Font("Arial", 12f);
		((XRControl)xrLabel39).LocationFloat = new PointFloat(50.30184f, 2603.902f);
		xrLabel39.Multiline = true;
		((XRControl)xrLabel39).Name = "xrLabel39";
		((XRControl)xrLabel39).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel39).SizeF = new SizeF(382.155f, 55.38062f);
		((XRControl)xrLabel39).StylePriority.UseFont = false;
		((XRControl)xrLabel39).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel39).Text = "Data Chamada";
		((XRControl)xrLabel39).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(0f, 2742.6f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(1940f, 5.291748f);
		((XRControl)txSequencia2).Dpi = 254f;
		((XRControl)txSequencia2).Font = new Font("Arial", 12f);
		((XRControl)txSequencia2).LocationFloat = new PointFloat(1156.696f, 2659.282f);
		txSequencia2.Multiline = true;
		((XRControl)txSequencia2).Name = "txSequencia2";
		((XRControl)txSequencia2).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txSequencia2).SizeF = new SizeF(270.8309f, 55.38074f);
		((XRControl)txSequencia2).StylePriority.UseFont = false;
		((XRControl)txSequencia2).StylePriority.UseTextAlignment = false;
		((XRControl)txSequencia2).Text = "01";
		((XRControl)txSequencia2).TextAlignment = (TextAlignment)1;
		((XRControl)xrLabel41).Dpi = 254f;
		((XRControl)xrLabel41).Font = new Font("Arial", 12f);
		((XRControl)xrLabel41).LocationFloat = new PointFloat(1156.696f, 2603.902f);
		xrLabel41.Multiline = true;
		((XRControl)xrLabel41).Name = "xrLabel41";
		((XRControl)xrLabel41).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)xrLabel41).SizeF = new SizeF(270.8309f, 55.38062f);
		((XRControl)xrLabel41).StylePriority.UseFont = false;
		((XRControl)xrLabel41).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel41).Text = "Sequencia";
		((XRControl)xrLabel41).TextAlignment = (TextAlignment)1;
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[3]
		{
			(Band)TopMargin,
			(Band)BottomMargin,
			(Band)Detail
		});
		((XtraReport)this).DesignerOptions.ShowPrintingWarnings = false;
		((XRControl)this).Dpi = 254f;
		((XRControl)this).Font = new Font("Arial", 9.75f);
		((XtraReport)this).Margins = new Margins(80, 80, 80, 0);
		((XtraReport)this).PageHeight = 2970;
		((XtraReport)this).PageWidth = 2100;
		((XtraReport)this).PaperKind = PaperKind.A4;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).SnapGridSize = 25f;
		((XtraReport)this).Version = "19.2";
		((ISupportInitialize)this).EndInit();
	}
}
