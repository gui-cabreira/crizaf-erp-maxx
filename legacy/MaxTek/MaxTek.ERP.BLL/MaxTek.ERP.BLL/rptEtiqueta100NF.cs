using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class rptEtiqueta100NF : XtraReport
{
	private NotaFiscalNotasFiscais _notaFiscal;

	private IContainer components = null;

	private DetailBand Detail;

	private PageHeaderBand PageHeader;

	private XRLabel txCliente;

	private XRLabel lbNotafiscal;

	private XRLabel lbEndereco;

	private XRLabel lbData;

	private XRLabel lbCliente;

	private XRLabel txNotaFiscal;

	private XRLabel txEndereco;

	private XRLabel txData;

	private XRLine xrLine1;

	private XRLine xrLine3;

	private XRPictureBox imLogoEmpresa;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel txNroPedido;

	private XRLabel lbNroPedido;

	private XRLine xrLine4;

	private XRLabel txTelefoneEmpresa;

	private XRLabel txNomeEmpresa;

	private XRLine xrLine6;

	private XRLine xrLine8;

	private XRLine xrLine5;

	private XRLine xrLine2;

	private XRLine xrLine7;

	private XRLabel txTransportadora;

	private XRLabel lbTransportadora;

	public NotaFiscalNotasFiscais NotaFiscal
	{
		get
		{
			return _notaFiscal;
		}
		set
		{
			_notaFiscal = value;
		}
	}

	public rptEtiqueta100NF()
	{
		InitializeComponent();
	}

	private void PageHeader_BeforePrint(object sender, PrintEventArgs e)
	{
		Sociedade emitente = NotaFiscal.Emitente;
		if (NotaFiscal != null && NotaFiscal.Entidade != null && NotaFiscal.Transportadora != null)
		{
			imLogoEmpresa.Image = emitente.Logo;
			((XRControl)txNomeEmpresa).Text = emitente.NomeFantasia;
			((XRControl)txTelefoneEmpresa).Text = emitente.Telefone;
			((XRControl)txData).Text = NotaFiscal.DataEmissao.ToShortDateString();
			if (NotaFiscal.EntidadeEntrega != null && !string.IsNullOrWhiteSpace(NotaFiscal.EntidadeEntrega.AuxEndereco))
			{
				((XRControl)txCliente).Text = NotaFiscal.EntidadeEntrega.RazaoSocial;
				((XRControl)txEndereco).Text = $"{NotaFiscal.EntidadeEntrega.Endereco}, {NotaFiscal.EntidadeEntrega.AuxEnderecoNumero} - CEP: {NotaFiscal.EntidadeEntrega.CodigoPostal} {NotaFiscal.EntidadeEntrega.ComplementoEndereco} - {NotaFiscal.EntidadeEntrega.Cidade} {NotaFiscal.EntidadeEntrega.UF}";
			}
			else
			{
				((XRControl)txCliente).Text = NotaFiscal.Entidade.RazaoSocial;
				((XRControl)txEndereco).Text = $"{NotaFiscal.Entidade.Endereco}, {NotaFiscal.Entidade.AuxEnderecoNumero} - CEP: {NotaFiscal.Entidade.CodigoPostal} {NotaFiscal.Entidade.ComplementoEndereco} - {NotaFiscal.Entidade.Cidade} {NotaFiscal.Entidade.UF}";
			}
			if (NotaFiscal.Itens != null && NotaFiscal.Itens.Count > 0)
			{
				((XRControl)txNroPedido).Text = NotaFiscal.Itens[0].CodigoPedidoVenda.ToString();
			}
			((XRControl)txNotaFiscal).Text = NotaFiscal.NumeroNotaFiscal.ToString();
			((XRControl)txTransportadora).Text = NotaFiscal.Transportadora.NomeFantasia;
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
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0927: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_107a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1167: Unknown result type (might be due to invalid IL or missing references)
		//IL_1192: Unknown result type (might be due to invalid IL or missing references)
		//IL_1254: Unknown result type (might be due to invalid IL or missing references)
		//IL_128c: Unknown result type (might be due to invalid IL or missing references)
		//IL_134e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1379: Unknown result type (might be due to invalid IL or missing references)
		//IL_1443: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_164d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1678: Unknown result type (might be due to invalid IL or missing references)
		Detail = new DetailBand();
		PageHeader = new PageHeaderBand();
		txTransportadora = new XRLabel();
		lbTransportadora = new XRLabel();
		xrLine7 = new XRLine();
		xrLine2 = new XRLine();
		xrLine6 = new XRLine();
		xrLine8 = new XRLine();
		xrLine5 = new XRLine();
		txTelefoneEmpresa = new XRLabel();
		txNomeEmpresa = new XRLabel();
		txNroPedido = new XRLabel();
		lbNroPedido = new XRLabel();
		lbCliente = new XRLabel();
		lbData = new XRLabel();
		lbEndereco = new XRLabel();
		lbNotafiscal = new XRLabel();
		txCliente = new XRLabel();
		txData = new XRLabel();
		txEndereco = new XRLabel();
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
		((XRControl)PageHeader).Controls.AddRange((XRControl[])(object)new XRControl[23]
		{
			(XRControl)txTransportadora,
			(XRControl)lbTransportadora,
			(XRControl)xrLine7,
			(XRControl)xrLine2,
			(XRControl)xrLine6,
			(XRControl)xrLine8,
			(XRControl)xrLine5,
			(XRControl)txTelefoneEmpresa,
			(XRControl)txNomeEmpresa,
			(XRControl)txNroPedido,
			(XRControl)lbNroPedido,
			(XRControl)lbCliente,
			(XRControl)lbData,
			(XRControl)lbEndereco,
			(XRControl)lbNotafiscal,
			(XRControl)txCliente,
			(XRControl)txData,
			(XRControl)txEndereco,
			(XRControl)txNotaFiscal,
			(XRControl)xrLine1,
			(XRControl)xrLine3,
			(XRControl)xrLine4,
			(XRControl)imLogoEmpresa
		});
		((XRControl)PageHeader).Dpi = 254f;
		((XRControl)PageHeader).Font = new Font("Arial", 8f);
		((XRControl)PageHeader).HeightF = 820.29f;
		((XRControl)PageHeader).Name = "PageHeader";
		((XRControl)PageHeader).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)PageHeader).StylePriority.UseBorderWidth = false;
		((XRControl)PageHeader).StylePriority.UseFont = false;
		((XRControl)PageHeader).StylePriority.UsePadding = false;
		((XRControl)PageHeader).TextAlignment = (TextAlignment)1;
		((XRControl)PageHeader).BeforePrint += PageHeader_BeforePrint;
		((XRControl)txTransportadora).Borders = (BorderSide)0;
		((XRControl)txTransportadora).CanGrow = false;
		((XRControl)txTransportadora).Dpi = 254f;
		((XRControl)txTransportadora).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txTransportadora).LocationFloat = new PointFloat(42.99999f, 538.8229f);
		txTransportadora.Multiline = true;
		((XRControl)txTransportadora).Name = "txTransportadora";
		((XRControl)txTransportadora).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTransportadora).SizeF = new SizeF(914.5411f, 126.3557f);
		((XRControl)txTransportadora).StylePriority.UseBorders = false;
		((XRControl)txTransportadora).StylePriority.UseFont = false;
		((XRControl)txTransportadora).StylePriority.UseTextAlignment = false;
		((XRControl)txTransportadora).TextAlignment = (TextAlignment)1;
		((XRControl)lbTransportadora).Borders = (BorderSide)0;
		((XRControl)lbTransportadora).Dpi = 254f;
		((XRControl)lbTransportadora).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbTransportadora).LocationFloat = new PointFloat(42.99999f, 486.6653f);
		((XRControl)lbTransportadora).Name = "lbTransportadora";
		((XRControl)lbTransportadora).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbTransportadora).SizeF = new SizeF(369.6665f, 52.15756f);
		((XRControl)lbTransportadora).StylePriority.UseBorders = false;
		((XRControl)lbTransportadora).StylePriority.UseFont = false;
		((XRControl)lbTransportadora).StylePriority.UseTextAlignment = false;
		((XRControl)lbTransportadora).Text = "Transportadora:";
		((XRControl)lbTransportadora).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine7).Borders = (BorderSide)0;
		((XRControl)xrLine7).Dpi = 254f;
		((XRControl)xrLine7).ForeColor = Color.Black;
		xrLine7.LineWidth = 4f;
		((XRControl)xrLine7).LocationFloat = new PointFloat(18.99997f, 469.6068f);
		((XRControl)xrLine7).Name = "xrLine7";
		((XRControl)xrLine7).SizeF = new SizeF(967.5833f, 8.058441f);
		((XRControl)xrLine7).StylePriority.UseBorders = false;
		((XRControl)xrLine7).StylePriority.UseForeColor = false;
		((XRControl)xrLine2).Borders = (BorderSide)0;
		((XRControl)xrLine2).Dpi = 254f;
		((XRControl)xrLine2).ForeColor = Color.Black;
		xrLine2.LineWidth = 4f;
		((XRControl)xrLine2).LocationFloat = new PointFloat(19.99998f, 667.1785f);
		((XRControl)xrLine2).Name = "xrLine2";
		((XRControl)xrLine2).SizeF = new SizeF(966.5833f, 6.111511f);
		((XRControl)xrLine2).StylePriority.UseBorders = false;
		((XRControl)xrLine2).StylePriority.UseForeColor = false;
		((XRControl)xrLine6).Borders = (BorderSide)0;
		((XRControl)xrLine6).Dpi = 254f;
		((XRControl)xrLine6).ForeColor = Color.Black;
		xrLine6.LineWidth = 4f;
		((XRControl)xrLine6).LocationFloat = new PointFloat(18.99997f, 387.523f);
		((XRControl)xrLine6).Name = "xrLine6";
		((XRControl)xrLine6).SizeF = new SizeF(967.5833f, 5f);
		((XRControl)xrLine6).StylePriority.UseBorders = false;
		((XRControl)xrLine6).StylePriority.UseForeColor = false;
		((XRControl)xrLine8).Borders = (BorderSide)0;
		((XRControl)xrLine8).Dpi = 254f;
		((XRControl)xrLine8).ForeColor = Color.Black;
		xrLine8.LineWidth = 4f;
		((XRControl)xrLine8).LocationFloat = new PointFloat(18.99997f, 269.8909f);
		((XRControl)xrLine8).Name = "xrLine8";
		((XRControl)xrLine8).SizeF = new SizeF(967.5833f, 5.000046f);
		((XRControl)xrLine8).StylePriority.UseBorders = false;
		((XRControl)xrLine8).StylePriority.UseForeColor = false;
		((XRControl)xrLine5).Borders = (BorderSide)0;
		((XRControl)xrLine5).Dpi = 254f;
		((XRControl)xrLine5).ForeColor = Color.Black;
		xrLine5.LineWidth = 4f;
		((XRControl)xrLine5).LocationFloat = new PointFloat(18.99997f, 139.8368f);
		((XRControl)xrLine5).Name = "xrLine5";
		((XRControl)xrLine5).SizeF = new SizeF(967.5833f, 5.000015f);
		((XRControl)xrLine5).StylePriority.UseBorders = false;
		((XRControl)xrLine5).StylePriority.UseForeColor = false;
		((XRControl)txTelefoneEmpresa).Borders = (BorderSide)0;
		((XRControl)txTelefoneEmpresa).CanGrow = false;
		((XRControl)txTelefoneEmpresa).Dpi = 254f;
		((XRControl)txTelefoneEmpresa).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txTelefoneEmpresa).LocationFloat = new PointFloat(299.9845f, 86.03146f);
		((XRControl)txTelefoneEmpresa).Name = "txTelefoneEmpresa";
		((XRControl)txTelefoneEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txTelefoneEmpresa).SizeF = new SizeF(664.6193f, 53.80533f);
		((XRControl)txTelefoneEmpresa).StylePriority.UseBorders = false;
		((XRControl)txTelefoneEmpresa).StylePriority.UseFont = false;
		((XRControl)txTelefoneEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txTelefoneEmpresa).TextAlignment = (TextAlignment)32;
		((XRControl)txNomeEmpresa).Borders = (BorderSide)0;
		((XRControl)txNomeEmpresa).CanGrow = false;
		((XRControl)txNomeEmpresa).Dpi = 254f;
		((XRControl)txNomeEmpresa).Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)txNomeEmpresa).LocationFloat = new PointFloat(299.9845f, 33.99999f);
		((XRControl)txNomeEmpresa).Name = "txNomeEmpresa";
		((XRControl)txNomeEmpresa).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNomeEmpresa).SizeF = new SizeF(664.6193f, 52.03148f);
		((XRControl)txNomeEmpresa).StylePriority.UseBorders = false;
		((XRControl)txNomeEmpresa).StylePriority.UseFont = false;
		((XRControl)txNomeEmpresa).StylePriority.UseTextAlignment = false;
		((XRControl)txNomeEmpresa).TextAlignment = (TextAlignment)32;
		((XRControl)txNroPedido).Borders = (BorderSide)0;
		((XRControl)txNroPedido).CanGrow = false;
		((XRControl)txNroPedido).Dpi = 254f;
		((XRControl)txNroPedido).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNroPedido).LocationFloat = new PointFloat(767.7289f, 404.0804f);
		((XRControl)txNroPedido).Name = "txNroPedido";
		((XRControl)txNroPedido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNroPedido).SizeF = new SizeF(176.7087f, 57.5264f);
		((XRControl)txNroPedido).StylePriority.UseBorders = false;
		((XRControl)txNroPedido).StylePriority.UseFont = false;
		((XRControl)txNroPedido).StylePriority.UseTextAlignment = false;
		((XRControl)txNroPedido).TextAlignment = (TextAlignment)1;
		((XRControl)lbNroPedido).Borders = (BorderSide)0;
		((XRControl)lbNroPedido).Dpi = 254f;
		((XRControl)lbNroPedido).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbNroPedido).LocationFloat = new PointFloat(524.0831f, 404.0804f);
		((XRControl)lbNroPedido).Name = "lbNroPedido";
		((XRControl)lbNroPedido).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbNroPedido).SizeF = new SizeF(243.6458f, 57.5264f);
		((XRControl)lbNroPedido).StylePriority.UseBorders = false;
		((XRControl)lbNroPedido).StylePriority.UseFont = false;
		((XRControl)lbNroPedido).StylePriority.UseTextAlignment = false;
		((XRControl)lbNroPedido).Text = "Nr. Pedido:";
		((XRControl)lbNroPedido).TextAlignment = (TextAlignment)1;
		((XRControl)lbCliente).Borders = (BorderSide)0;
		((XRControl)lbCliente).Dpi = 254f;
		((XRControl)lbCliente).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbCliente).LocationFloat = new PointFloat(42.99999f, 144.8368f);
		((XRControl)lbCliente).Name = "lbCliente";
		((XRControl)lbCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbCliente).SizeF = new SizeF(169.2918f, 56.7887f);
		((XRControl)lbCliente).StylePriority.UseBorders = false;
		((XRControl)lbCliente).StylePriority.UseFont = false;
		((XRControl)lbCliente).StylePriority.UseTextAlignment = false;
		((XRControl)lbCliente).Text = "Cliente:";
		((XRControl)lbCliente).TextAlignment = (TextAlignment)1;
		((XRControl)lbData).Borders = (BorderSide)0;
		((XRControl)lbData).Dpi = 254f;
		((XRControl)lbData).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbData).LocationFloat = new PointFloat(42.99998f, 201.6255f);
		((XRControl)lbData).Name = "lbData";
		((XRControl)lbData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbData).SizeF = new SizeF(294.0007f, 58.2654f);
		((XRControl)lbData).StylePriority.UseBorders = false;
		((XRControl)lbData).StylePriority.UseFont = false;
		((XRControl)lbData).StylePriority.UseTextAlignment = false;
		((XRControl)lbData).Text = "Data Emissão:";
		((XRControl)lbData).TextAlignment = (TextAlignment)1;
		((XRControl)lbEndereco).Borders = (BorderSide)0;
		((XRControl)lbEndereco).Dpi = 254f;
		((XRControl)lbEndereco).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbEndereco).LocationFloat = new PointFloat(42.99999f, 281.8909f);
		((XRControl)lbEndereco).Name = "lbEndereco";
		((XRControl)lbEndereco).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbEndereco).SizeF = new SizeF(182.5623f, 61.7887f);
		((XRControl)lbEndereco).StylePriority.UseBorders = false;
		((XRControl)lbEndereco).StylePriority.UseFont = false;
		((XRControl)lbEndereco).StylePriority.UseTextAlignment = false;
		((XRControl)lbEndereco).Text = "Entrega:";
		((XRControl)lbEndereco).TextAlignment = (TextAlignment)1;
		((XRControl)lbNotafiscal).Borders = (BorderSide)0;
		((XRControl)lbNotafiscal).Dpi = 254f;
		((XRControl)lbNotafiscal).Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)lbNotafiscal).LocationFloat = new PointFloat(42.99999f, 404.0804f);
		((XRControl)lbNotafiscal).Name = "lbNotafiscal";
		((XRControl)lbNotafiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)lbNotafiscal).SizeF = new SizeF(156.0626f, 57.5264f);
		((XRControl)lbNotafiscal).StylePriority.UseBorders = false;
		((XRControl)lbNotafiscal).StylePriority.UseFont = false;
		((XRControl)lbNotafiscal).StylePriority.UseTextAlignment = false;
		((XRControl)lbNotafiscal).Text = "NF N°:";
		((XRControl)lbNotafiscal).TextAlignment = (TextAlignment)1;
		((XRControl)txCliente).Borders = (BorderSide)0;
		((XRControl)txCliente).CanGrow = false;
		((XRControl)txCliente).Dpi = 254f;
		((XRControl)txCliente).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txCliente).LocationFloat = new PointFloat(212.2918f, 144.8368f);
		((XRControl)txCliente).Name = "txCliente";
		((XRControl)txCliente).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txCliente).SizeF = new SizeF(752.3122f, 56.7887f);
		((XRControl)txCliente).StylePriority.UseBorders = false;
		((XRControl)txCliente).StylePriority.UseFont = false;
		((XRControl)txCliente).StylePriority.UseTextAlignment = false;
		((XRControl)txCliente).TextAlignment = (TextAlignment)1;
		((XRControl)txData).Borders = (BorderSide)0;
		((XRControl)txData).CanGrow = false;
		((XRControl)txData).Dpi = 254f;
		((XRControl)txData).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txData).LocationFloat = new PointFloat(337.0007f, 201.6255f);
		((XRControl)txData).Name = "txData";
		((XRControl)txData).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txData).SizeF = new SizeF(450f, 58.2654f);
		((XRControl)txData).StylePriority.UseBorders = false;
		((XRControl)txData).StylePriority.UseFont = false;
		((XRControl)txData).StylePriority.UseTextAlignment = false;
		((XRControl)txData).TextAlignment = (TextAlignment)1;
		((XRControl)txEndereco).Borders = (BorderSide)0;
		((XRControl)txEndereco).CanGrow = false;
		((XRControl)txEndereco).Dpi = 254f;
		((XRControl)txEndereco).Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txEndereco).LocationFloat = new PointFloat(225.5623f, 281.8909f);
		txEndereco.Multiline = true;
		((XRControl)txEndereco).Name = "txEndereco";
		((XRControl)txEndereco).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txEndereco).SizeF = new SizeF(739.0417f, 105.1895f);
		((XRControl)txEndereco).StylePriority.UseBorders = false;
		((XRControl)txEndereco).StylePriority.UseFont = false;
		((XRControl)txEndereco).StylePriority.UseTextAlignment = false;
		((XRControl)txEndereco).TextAlignment = (TextAlignment)1;
		((XRControl)txNotaFiscal).Borders = (BorderSide)0;
		((XRControl)txNotaFiscal).CanGrow = false;
		((XRControl)txNotaFiscal).Dpi = 254f;
		((XRControl)txNotaFiscal).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XRControl)txNotaFiscal).LocationFloat = new PointFloat(199.0626f, 404.0804f);
		((XRControl)txNotaFiscal).Name = "txNotaFiscal";
		((XRControl)txNotaFiscal).Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		((XRControl)txNotaFiscal).SizeF = new SizeF(325.0204f, 57.5264f);
		((XRControl)txNotaFiscal).StylePriority.UseBorders = false;
		((XRControl)txNotaFiscal).StylePriority.UseFont = false;
		((XRControl)txNotaFiscal).StylePriority.UseTextAlignment = false;
		((XRControl)txNotaFiscal).Text = "999999";
		((XRControl)txNotaFiscal).TextAlignment = (TextAlignment)1;
		((XRControl)xrLine1).Borders = (BorderSide)0;
		((XRControl)xrLine1).Dpi = 254f;
		((XRControl)xrLine1).ForeColor = Color.Black;
		xrLine1.LineWidth = 4f;
		((XRControl)xrLine1).LocationFloat = new PointFloat(19f, 25f);
		((XRControl)xrLine1).Name = "xrLine1";
		((XRControl)xrLine1).SizeF = new SizeF(967.5833f, 5.737551f);
		((XRControl)xrLine1).StylePriority.UseBorders = false;
		((XRControl)xrLine1).StylePriority.UseForeColor = false;
		((XRControl)xrLine3).Borders = (BorderSide)0;
		((XRControl)xrLine3).Dpi = 254f;
		((XRControl)xrLine3).ForeColor = Color.Black;
		xrLine3.LineDirection = (LineDirection)3;
		xrLine3.LineWidth = 4f;
		((XRControl)xrLine3).LocationFloat = new PointFloat(14.99997f, 26.20242f);
		((XRControl)xrLine3).Name = "xrLine3";
		((XRControl)xrLine3).SizeF = new SizeF(11f, 715.0875f);
		((XRControl)xrLine3).StylePriority.UseBorders = false;
		((XRControl)xrLine3).StylePriority.UseForeColor = false;
		((XRControl)xrLine4).Borders = (BorderSide)0;
		((XRControl)xrLine4).Dpi = 254f;
		((XRControl)xrLine4).ForeColor = Color.Black;
		xrLine4.LineDirection = (LineDirection)3;
		xrLine4.LineWidth = 4f;
		((XRControl)xrLine4).LocationFloat = new PointFloat(977.5834f, 26.4166f);
		((XRControl)xrLine4).Name = "xrLine4";
		((XRControl)xrLine4).SizeF = new SizeF(10.99994f, 714.8733f);
		((XRControl)xrLine4).StylePriority.UseBorders = false;
		((XRControl)xrLine4).StylePriority.UseForeColor = false;
		((XRControl)imLogoEmpresa).Borders = (BorderSide)0;
		((XRControl)imLogoEmpresa).BorderWidth = 0f;
		((XRControl)imLogoEmpresa).Dpi = 254f;
		((XRControl)imLogoEmpresa).LocationFloat = new PointFloat(42.99999f, 33.99998f);
		((XRControl)imLogoEmpresa).Name = "imLogoEmpresa";
		((XRControl)imLogoEmpresa).Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		((XRControl)imLogoEmpresa).SizeF = new SizeF(235.419f, 84.8368f);
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
		((XRControl)this).Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		((XtraReport)this).Margins = new Margins(0, 0, 0, 0);
		((XtraReport)this).PageHeight = 730;
		((XtraReport)this).PageWidth = 999;
		((XtraReport)this).PaperKind = PaperKind.Custom;
		((XtraReport)this).ReportUnit = (ReportUnit)1;
		((XtraReport)this).ShowPrintMarginsWarning = false;
		((XtraReport)this).ShowPrintStatusDialog = false;
		((XtraReport)this).SnapGridSize = 10.58333f;
		((XtraReport)this).Version = "15.2";
		((ISupportInitialize)this).EndInit();
	}
}
