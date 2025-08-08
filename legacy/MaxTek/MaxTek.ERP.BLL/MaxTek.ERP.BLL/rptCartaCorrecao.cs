using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace MaxTek.ERP.BLL;

public class rptCartaCorrecao : XtraReport
{
	private NotaFiscalNotasFiscais _nf = new NotaFiscalNotasFiscais();

	private NotasFiscaisEventos _evento = new NotasFiscaisEventos();

	private IContainer components = null;

	private DetailBand Detail;

	private ReportHeaderBand ReportHeader;

	private XRLabel xrSerieNFe2;

	private XRLabel xrLabel114;

	private XRLabel xrNroNF2;

	private XRPanel xrPanel13;

	private XRLabel xrLabel107;

	private XRBarCode xrChaveAcesso2;

	private XRPanel xrPanel12;

	private XRLabel xrEmitenteTelefone2;

	private XRLabel xrEmitenteEnderecoCidade2;

	private XRLabel xrEnderecoEmitenteBairro2;

	private XRLabel xrEnderecoEmitente2;

	private XRLabel xrRazaoSocialEmitente2;

	private XRPictureBox xrLogo2;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel txCorrecao;

	private XRLabel xrLabel1;

	private ReportFooterBand ReportFooter;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel txNFe;

	public rptCartaCorrecao(NotasFiscaisEventos evento)
		: this()
	{
		_evento = evento;
		_nf = evento.NotaFiscalRef;
	}

	private rptCartaCorrecao()
	{
		InitializeComponent();
	}

	private void rptCartaCorrecao_BeforePrint(object sender, PrintEventArgs e)
	{
		((XRControl)xrChaveAcesso2).Text = _nf.ChaveNfe;
		((XRControl)txNFe).Text = _nf.ChaveNfe;
		((XRControl)xrNroNF2).Text = _nf.NumeroNotaFiscal.ToString("000,000,000");
		((XRControl)xrSerieNFe2).Text = "SÉRIE " + _nf.SerieNotaFiscal;
		((XRControl)xrRazaoSocialEmitente2).Text = _nf.Emitente.RazaoSocial;
		((XRControl)xrEnderecoEmitente2).Text = _nf.Emitente.Endereco;
		((XRControl)xrEnderecoEmitenteBairro2).Text = $"{_nf.Emitente.Bairro} - {_nf.Emitente.CodigoPostal}";
		((XRControl)xrEmitenteEnderecoCidade2).Text = $"{_nf.Emitente.Cidade} / {_nf.Emitente.Estado.ToUpper()}";
		((XRControl)xrEmitenteTelefone2).Text = _nf.Emitente.Telefone;
		xrLogo2.Image = _nf.Emitente.Logo;
		((XRControl)txCorrecao).Text = _evento.Descricao;
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
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0982: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		Code128Generator val = new Code128Generator();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptCartaCorrecao));
		Detail = new DetailBand();
		ReportHeader = new ReportHeaderBand();
		txCorrecao = new XRLabel();
		xrLabel1 = new XRLabel();
		xrSerieNFe2 = new XRLabel();
		xrLabel114 = new XRLabel();
		xrNroNF2 = new XRLabel();
		xrPanel13 = new XRPanel();
		txNFe = new XRLabel();
		xrLabel107 = new XRLabel();
		xrChaveAcesso2 = new XRBarCode();
		xrPanel12 = new XRPanel();
		xrRazaoSocialEmitente2 = new XRLabel();
		xrEnderecoEmitente2 = new XRLabel();
		xrEnderecoEmitenteBairro2 = new XRLabel();
		xrEmitenteEnderecoCidade2 = new XRLabel();
		xrEmitenteTelefone2 = new XRLabel();
		xrLogo2 = new XRPictureBox();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		ReportFooter = new ReportFooterBand();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		((ISupportInitialize)this).BeginInit();
		((XRControl)Detail).Borders = (BorderSide)15;
		((XRControl)Detail).BorderWidth = 1f;
		((XRControl)Detail).HeightF = 17f;
		((XRControl)Detail).Name = "Detail";
		((XRControl)Detail).Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		((XRControl)Detail).StylePriority.UseBorders = false;
		((XRControl)Detail).StylePriority.UseBorderWidth = false;
		((XRControl)Detail).TextAlignment = (TextAlignment)1;
		((XRControl)ReportHeader).Borders = (BorderSide)15;
		((XRControl)ReportHeader).BorderWidth = 1f;
		((XRControl)ReportHeader).Controls.AddRange((XRControl[])(object)new XRControl[7]
		{
			(XRControl)txCorrecao,
			(XRControl)xrLabel1,
			(XRControl)xrSerieNFe2,
			(XRControl)xrLabel114,
			(XRControl)xrNroNF2,
			(XRControl)xrPanel13,
			(XRControl)xrPanel12
		});
		((XRControl)ReportHeader).HeightF = 227.5417f;
		((XRControl)ReportHeader).Name = "ReportHeader";
		((XRControl)ReportHeader).StylePriority.UseBorders = false;
		((XRControl)ReportHeader).StylePriority.UseBorderWidth = false;
		((XRControl)txCorrecao).Borders = (BorderSide)0;
		((XRControl)txCorrecao).Font = new Font("Arial", 12f);
		((XRControl)txCorrecao).LocationFloat = new PointFloat(0f, 196.8333f);
		((XRControl)txCorrecao).Name = "txCorrecao";
		((XRControl)txCorrecao).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)txCorrecao).SizeF = new SizeF(724.0001f, 25.08331f);
		((XRControl)txCorrecao).StylePriority.UseBorders = false;
		((XRControl)txCorrecao).StylePriority.UseFont = false;
		((XRControl)txCorrecao).Text = "txCorrecao";
		((XRControl)xrLabel1).BackColor = Color.LightGray;
		((XRControl)xrLabel1).Font = new Font("Arial", 21.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel1).LocationFloat = new PointFloat(0f, 139.5417f);
		((XRControl)xrLabel1).Name = "xrLabel1";
		((XRControl)xrLabel1).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel1).SizeF = new SizeF(724.0001f, 40.70834f);
		((XRControl)xrLabel1).StylePriority.UseBackColor = false;
		((XRControl)xrLabel1).StylePriority.UseFont = false;
		((XRControl)xrLabel1).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel1).Text = "Carta de Correção";
		((XRControl)xrLabel1).TextAlignment = (TextAlignment)32;
		((XRControl)xrSerieNFe2).BorderWidth = 0f;
		((XRControl)xrSerieNFe2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrSerieNFe2).LocationFloat = new PointFloat(227f, 71.99999f);
		((XRControl)xrSerieNFe2).Name = "xrSerieNFe2";
		((XRControl)xrSerieNFe2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrSerieNFe2).SizeF = new SizeF(92f, 17f);
		((XRControl)xrSerieNFe2).StylePriority.UseBorderWidth = false;
		((XRControl)xrSerieNFe2).StylePriority.UseFont = false;
		((XRControl)xrSerieNFe2).StylePriority.UseTextAlignment = false;
		((XRControl)xrSerieNFe2).Text = "SÉRIE 1";
		((XRControl)xrSerieNFe2).TextAlignment = (TextAlignment)2;
		((XRControl)xrLabel114).BorderWidth = 0f;
		((XRControl)xrLabel114).LocationFloat = new PointFloat(225f, 47f);
		((XRControl)xrLabel114).Name = "xrLabel114";
		((XRControl)xrLabel114).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel114).SizeF = new SizeF(17f, 17f);
		((XRControl)xrLabel114).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel114).Text = "N.";
		((XRControl)xrNroNF2).BorderWidth = 0f;
		((XRControl)xrNroNF2).Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
		((XRControl)xrNroNF2).LocationFloat = new PointFloat(242f, 47f);
		((XRControl)xrNroNF2).Name = "xrNroNF2";
		((XRControl)xrNroNF2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrNroNF2).SizeF = new SizeF(77f, 17f);
		((XRControl)xrNroNF2).StylePriority.UseBorderWidth = false;
		((XRControl)xrNroNF2).StylePriority.UseFont = false;
		((XRControl)xrNroNF2).Text = "000.000.000";
		((XRControl)xrPanel13).BorderWidth = 1f;
		((XRControl)xrPanel13).Controls.AddRange((XRControl[])(object)new XRControl[3]
		{
			(XRControl)txNFe,
			(XRControl)xrLabel107,
			(XRControl)xrChaveAcesso2
		});
		((XRControl)xrPanel13).LocationFloat = new PointFloat(324f, 0f);
		((XRControl)xrPanel13).Name = "xrPanel13";
		((XRControl)xrPanel13).SizeF = new SizeF(400f, 129f);
		((XRControl)xrPanel13).StylePriority.UseBorderWidth = false;
		((XRControl)txNFe).Borders = (BorderSide)0;
		((XRControl)txNFe).LocationFloat = new PointFloat(10f, 100f);
		((XRControl)txNFe).Name = "txNFe";
		((XRControl)txNFe).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)txNFe).SizeF = new SizeF(383.0001f, 23f);
		((XRControl)txNFe).StylePriority.UseBorders = false;
		((XRControl)txNFe).StylePriority.UseTextAlignment = false;
		((XRControl)txNFe).Text = "txNFe";
		((XRControl)txNFe).TextAlignment = (TextAlignment)4;
		((XRControl)xrLabel107).BorderWidth = 0f;
		((XRControl)xrLabel107).Font = new Font("Times New Roman", 6f);
		((XRControl)xrLabel107).LocationFloat = new PointFloat(0f, 0f);
		((XRControl)xrLabel107).Name = "xrLabel107";
		((XRControl)xrLabel107).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel107).SizeF = new SizeF(103f, 12f);
		((XRControl)xrLabel107).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel107).StylePriority.UseFont = false;
		((XRControl)xrLabel107).Text = "CONTROLE DO FISCO";
		xrChaveAcesso2.AutoModule = true;
		((XRControl)xrChaveAcesso2).BorderWidth = 0f;
		((XRControl)xrChaveAcesso2).LocationFloat = new PointFloat(30f, 15f);
		((XRControl)xrChaveAcesso2).Name = "xrChaveAcesso2";
		((XRControl)xrChaveAcesso2).Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrChaveAcesso2.ShowText = false;
		((XRControl)xrChaveAcesso2).SizeF = new SizeF(344f, 80f);
		((XRControl)xrChaveAcesso2).StylePriority.UseBorderWidth = false;
		val.CharacterSet = (Code128Charset)105;
		xrChaveAcesso2.Symbology = (BarCodeGeneratorBase)(object)val;
		((XRControl)xrChaveAcesso2).Text = "0115550010000000180405822968";
		((XRControl)xrPanel12).BorderWidth = 1f;
		((XRControl)xrPanel12).Controls.AddRange((XRControl[])(object)new XRControl[6]
		{
			(XRControl)xrRazaoSocialEmitente2,
			(XRControl)xrEnderecoEmitente2,
			(XRControl)xrEnderecoEmitenteBairro2,
			(XRControl)xrEmitenteEnderecoCidade2,
			(XRControl)xrEmitenteTelefone2,
			(XRControl)xrLogo2
		});
		((XRControl)xrPanel12).LocationFloat = new PointFloat(0.9999911f, 0f);
		((XRControl)xrPanel12).Name = "xrPanel12";
		((XRControl)xrPanel12).SizeF = new SizeF(218.0833f, 129f);
		((XRControl)xrPanel12).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).BorderWidth = 0f;
		((XRControl)xrRazaoSocialEmitente2).Font = new Font("Times New Roman", 9f, FontStyle.Bold);
		((XRControl)xrRazaoSocialEmitente2).LocationFloat = new PointFloat(10f, 51f);
		xrRazaoSocialEmitente2.Multiline = true;
		((XRControl)xrRazaoSocialEmitente2).Name = "xrRazaoSocialEmitente2";
		((XRControl)xrRazaoSocialEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrRazaoSocialEmitente2).SizeF = new SizeF(196f, 15f);
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrRazaoSocialEmitente2).StylePriority.UseFont = false;
		((XRControl)xrRazaoSocialEmitente2).Text = "R.Castro Cia Ltda.";
		((XRControl)xrEnderecoEmitente2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitente2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitente2).LocationFloat = new PointFloat(9f, 68f);
		((XRControl)xrEnderecoEmitente2).Name = "xrEnderecoEmitente2";
		((XRControl)xrEnderecoEmitente2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitente2).SizeF = new SizeF(195f, 12f);
		((XRControl)xrEnderecoEmitente2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitente2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitente2).Text = "Avenida Ferraz Alvim, 622";
		((XRControl)xrEnderecoEmitenteBairro2).BorderWidth = 0f;
		((XRControl)xrEnderecoEmitenteBairro2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEnderecoEmitenteBairro2).LocationFloat = new PointFloat(9f, 82f);
		((XRControl)xrEnderecoEmitenteBairro2).Name = "xrEnderecoEmitenteBairro2";
		((XRControl)xrEnderecoEmitenteBairro2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEnderecoEmitenteBairro2).SizeF = new SizeF(195f, 12f);
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEnderecoEmitenteBairro2).StylePriority.UseFont = false;
		((XRControl)xrEnderecoEmitenteBairro2).Text = "Jardim Ruyce - CEP 09961-550";
		((XRControl)xrEmitenteEnderecoCidade2).BorderWidth = 0f;
		((XRControl)xrEmitenteEnderecoCidade2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteEnderecoCidade2).LocationFloat = new PointFloat(9f, 96f);
		((XRControl)xrEmitenteEnderecoCidade2).Name = "xrEmitenteEnderecoCidade2";
		((XRControl)xrEmitenteEnderecoCidade2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteEnderecoCidade2).SizeF = new SizeF(195f, 12f);
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteEnderecoCidade2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteEnderecoCidade2).Text = "Diadema - SP";
		((XRControl)xrEmitenteTelefone2).BorderWidth = 0f;
		((XRControl)xrEmitenteTelefone2).Font = new Font("Times New Roman", 8f);
		((XRControl)xrEmitenteTelefone2).LocationFloat = new PointFloat(9f, 110f);
		((XRControl)xrEmitenteTelefone2).Name = "xrEmitenteTelefone2";
		((XRControl)xrEmitenteTelefone2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrEmitenteTelefone2).SizeF = new SizeF(156f, 12f);
		((XRControl)xrEmitenteTelefone2).StylePriority.UseBorderWidth = false;
		((XRControl)xrEmitenteTelefone2).StylePriority.UseFont = false;
		((XRControl)xrEmitenteTelefone2).Text = "(11) 4067-1130";
		((XRControl)xrLogo2).BorderWidth = 0f;
		xrLogo2.Image = (Image)componentResourceManager.GetObject("xrLogo2.Image");
		((XRControl)xrLogo2).LocationFloat = new PointFloat(7f, 0f);
		((XRControl)xrLogo2).Name = "xrLogo2";
		((XRControl)xrLogo2).SizeF = new SizeF(112f, 50f);
		xrLogo2.Sizing = (ImageSizeMode)4;
		((XRControl)xrLogo2).StylePriority.UseBorderWidth = false;
		((XRControl)topMarginBand1).HeightF = 50f;
		((XRControl)topMarginBand1).Name = "topMarginBand1";
		((XRControl)bottomMarginBand1).HeightF = 50f;
		((XRControl)bottomMarginBand1).Name = "bottomMarginBand1";
		((XRControl)ReportFooter).Controls.AddRange((XRControl[])(object)new XRControl[2]
		{
			(XRControl)xrLabel3,
			(XRControl)xrLabel2
		});
		((XRControl)ReportFooter).HeightF = 163.5417f;
		((XRControl)ReportFooter).Name = "ReportFooter";
		ReportFooter.PrintAtBottom = true;
		((XRControl)xrLabel3).Font = new Font("Arial", 9.75f);
		((XRControl)xrLabel3).LocationFloat = new PointFloat(2.999878f, 64.91667f);
		xrLabel3.Multiline = true;
		((XRControl)xrLabel3).Name = "xrLabel3";
		((XRControl)xrLabel3).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel3).SizeF = new SizeF(724.0001f, 98.00002f);
		((XRControl)xrLabel3).StylePriority.UseFont = false;
		((XRControl)xrLabel3).Text = componentResourceManager.GetString("xrLabel3.Text");
		((XRControl)xrLabel2).BackColor = Color.LightGray;
		((XRControl)xrLabel2).Borders = (BorderSide)15;
		((XRControl)xrLabel2).BorderWidth = 1f;
		((XRControl)xrLabel2).Font = new Font("Arial", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((XRControl)xrLabel2).LocationFloat = new PointFloat(0f, 10.00001f);
		((XRControl)xrLabel2).Name = "xrLabel2";
		((XRControl)xrLabel2).Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		((XRControl)xrLabel2).SizeF = new SizeF(724.0001f, 40.70834f);
		((XRControl)xrLabel2).StylePriority.UseBackColor = false;
		((XRControl)xrLabel2).StylePriority.UseBorders = false;
		((XRControl)xrLabel2).StylePriority.UseBorderWidth = false;
		((XRControl)xrLabel2).StylePriority.UseFont = false;
		((XRControl)xrLabel2).StylePriority.UseTextAlignment = false;
		((XRControl)xrLabel2).Text = "Condição de Uso";
		((XRControl)xrLabel2).TextAlignment = (TextAlignment)32;
		((XtraReportBase)this).Bands.AddRange((Band[])(object)new Band[5]
		{
			(Band)Detail,
			(Band)ReportHeader,
			(Band)topMarginBand1,
			(Band)bottomMarginBand1,
			(Band)ReportFooter
		});
		((XRControl)this).BorderWidth = 0f;
		((XtraReport)this).DisplayName = "CartaCorrecao";
		((XtraReport)this).Margins = new Margins(50, 50, 50, 50);
		((XtraReport)this).PageHeight = 1169;
		((XtraReport)this).PageWidth = 827;
		((XtraReport)this).PaperKind = PaperKind.A4;
		((XtraReport)this).SnapGridSize = 5.208333f;
		((XtraReport)this).Version = "14.2";
		((XRControl)this).BeforePrint += rptCartaCorrecao_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
