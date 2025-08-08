using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaxTek.Utils;

public class BuscaCnpjEntidade : XtraForm
{
	private ClasseBuscaCnpjEntidade _dados;

	private string cnpj;

	private string _texto;

	private bool _consulta;

	private IContainer components = null;

	private WebBrowser webBrowser1;

	private Button btnOk;

	private Button btnSair;

	public ClasseBuscaCnpjEntidade Dados
	{
		get
		{
			return _dados;
		}
		set
		{
			_dados = value;
		}
	}

	public string DadosTexto => _texto;

	public BuscaCnpjEntidade()
	{
		InitializeComponent();
		btnOk.Visible = false;
		btnSair.Visible = false;
		string uriString = $"http://servicos.receita.fazenda.gov.br/Servicos/cnpjreva/Cnpjreva_Solicitacao.asp?cnpj={cnpj}";
		Uri url = new Uri(uriString);
		webBrowser1.Url = url;
		webBrowser1.ScriptErrorsSuppressed = true;
	}

	public BuscaCnpjEntidade(string Cnpj, bool consulta)
		: this()
	{
		cnpj = Cnpj;
		_consulta = consulta;
	}

	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		btnOk.Enabled = false;
		HtmlDocument document = webBrowser1.Document;
		if (document.Url.AbsoluteUri == "http://servicos.receita.fazenda.gov.br/Servicos/cnpjreva/Cnpjreva_Comprovante.asp")
		{
			btnOk.Enabled = true;
			_dados = new ClasseBuscaCnpjEntidade();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (HtmlElement item in document.GetElementsByTagName("font"))
			{
				switch (item.InnerText)
				{
				case "NÚMERO DE INSCRIÇÃO ":
					_dados.CNPJ = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "NOME EMPRESARIAL ":
					_dados.NomeEmpresarial = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA) ":
					_dados.Fantasia = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "DATA DE ABERTURA ":
					_dados.DataAbertura = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "LOGRADOURO ":
					_dados.Logradouro = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "NÚMERO ":
					_dados.Numero = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "COMPLEMENTO ":
					_dados.Complemento = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "BAIRRO/DISTRITO ":
					_dados.Bairro = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "MUNICÍPIO ":
					_dados.Municipio = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "UF ":
					_dados.UF = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "CEP ":
					_dados.CEP = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL ":
					_dados.AtividadeEconomicaPrincipal = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "SITUAÇÃO CADASTRAL ":
					_dados.SituacaoCadastral = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "DATA DA SITUAÇÃO CADASTRAL ":
					_dados.DataSituacaoCadastral = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "MOTIVO DE SITUAÇÃO CADASTRAL ":
					_dados.MotivoSituacaoCadastral = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "ENTE FEDERATIVO RESPONSÁVEL (EFR) ":
					_dados.EnteFederativoResponsavel = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA ":
					_dados.NaturezaJuridica = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS ":
					_dados.AtividadesSecundarias = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "ENDEREÇO ELETRÔNICO ":
					_dados.Email = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "TELEFONE ":
					_dados.Telefone = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "SITUAÇÃO ESPECIAL ":
					_dados.SituacaoEspecial = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				case "DATA DA SITUAÇÃO ESPECIAL ":
					_dados.DataSituacaoEspecial = item.NextSibling.NextSibling.InnerText;
					stringBuilder.AppendLine($"{item.InnerText} - {item.NextSibling.NextSibling.InnerText}");
					break;
				}
			}
			_texto = stringBuilder.ToString();
			if (_consulta)
			{
				btnOk.Visible = true;
				btnSair.Visible = true;
			}
			else
			{
				((Form)this).DialogResult = DialogResult.OK;
			}
		}
		else if (document.Url.AbsoluteUri == "http://servicos.receita.fazenda.gov.br/Servicos/cnpjreva/Cnpjreva_solicitacao2.asp")
		{
			HtmlElement elementById = document.GetElementById("cnpj");
			elementById.InnerText = cnpj;
		}
	}

	private void btnSair_Click(object sender, EventArgs e)
	{
		((Form)this).DialogResult = DialogResult.Cancel;
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		((Form)this).DialogResult = DialogResult.OK;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((XtraForm)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		webBrowser1 = new WebBrowser();
		btnOk = new Button();
		btnSair = new Button();
		((XtraForm)this).SuspendLayout();
		webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		webBrowser1.Location = new Point(12, 12);
		webBrowser1.MinimumSize = new Size(20, 20);
		webBrowser1.Name = "webBrowser1";
		webBrowser1.ScriptErrorsSuppressed = true;
		webBrowser1.Size = new Size(704, 417);
		webBrowser1.TabIndex = 0;
		webBrowser1.Url = new Uri("", UriKind.Relative);
		webBrowser1.WebBrowserShortcutsEnabled = false;
		webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
		btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnOk.DialogResult = DialogResult.OK;
		btnOk.Location = new Point(12, 435);
		btnOk.Name = "btnOk";
		btnOk.Size = new Size(207, 36);
		btnOk.TabIndex = 1;
		btnOk.Text = "Importar Dados";
		btnOk.UseVisualStyleBackColor = true;
		btnOk.Visible = false;
		btnOk.Click += btnOk_Click;
		btnSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btnSair.DialogResult = DialogResult.Cancel;
		btnSair.Location = new Point(509, 435);
		btnSair.Name = "btnSair";
		btnSair.Size = new Size(207, 36);
		btnSair.TabIndex = 2;
		btnSair.Text = "Sair";
		btnSair.UseVisualStyleBackColor = true;
		btnSair.Click += btnSair_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Form)this).ClientSize = new Size(728, 478);
		((Control)this).Controls.Add(btnSair);
		((Control)this).Controls.Add(btnOk);
		((Control)this).Controls.Add(webBrowser1);
		((Control)this).Name = "BuscaCnpjEntidade";
		((Control)(object)this).Text = "Pesquisa de Dados por CNPJ | via Receita Federal";
		((Form)this).WindowState = FormWindowState.Maximized;
		((XtraForm)this).ResumeLayout(false);
	}
}
