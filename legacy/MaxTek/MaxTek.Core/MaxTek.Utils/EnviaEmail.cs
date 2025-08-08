using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using DevExpress.XtraRichEdit;

namespace MaxTek.Utils;

public class EnviaEmail
{
	private MailMessage _email = new MailMessage();

	private SmtpClient _cliente = new SmtpClient();

	private bool _isSSL;

	private bool _isHtml;

	private string _remetente;

	private string[] _destinatario;

	private string _assunto;

	private string _corpo;

	private string _smtp;

	private string _smtpUsuario;

	private string _smtpSenha;

	private string _anexo;

	private string[] _anexos;

	private Attachment _attachmet;

	private Attachment[] _attachmets;

	private int _porta;

	private string[] _responderPara;

	private RichEditControl _richEditControl;

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, int Porta, bool isSSL, string[] ResponderPara)
	{
		_isHtml = isHtml;
		_remetente = Remetente;
		_destinatario = Destinatario;
		_assunto = Assunto;
		_richEditControl = null;
		_corpo = Corpo;
		_smtp = Servidor;
		_smtpUsuario = Usuario;
		_smtpSenha = Senha;
		_porta = Porta;
		_isSSL = isSSL;
		_responderPara = ResponderPara;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, 587, isSSL, ResponderPara)
	{
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_anexo = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_anexos = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment[] Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_attachmets = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_attachmet = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_anexo = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_anexos = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment[] Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_attachmets = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, string Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_attachmet = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, int Porta, bool isSSL, string[] ResponderPara)
	{
		_isHtml = isHtml;
		_remetente = Remetente;
		_destinatario = Destinatario;
		_assunto = Assunto;
		_richEditControl = Corpo;
		_corpo = null;
		_smtp = Servidor;
		_smtpUsuario = Usuario;
		_smtpSenha = Senha;
		_porta = Porta;
		_isSSL = isSSL;
		_responderPara = ResponderPara;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, 587, isSSL, ResponderPara)
	{
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_anexo = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_anexos = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment[] Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_attachmets = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment Anexo, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, isSSL, ResponderPara)
	{
		_attachmet = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_anexo = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, string[] Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_anexos = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment[] Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_attachmets = Anexo;
	}

	public EnviaEmail(bool isHtml, string Remetente, string[] Destinatario, string Assunto, RichEditControl Corpo, string Servidor, string Usuario, string Senha, bool isSSL, Attachment Anexo, int Porta, string[] ResponderPara)
		: this(isHtml, Remetente, Destinatario, Assunto, Corpo, Servidor, Usuario, Senha, Porta, isSSL, ResponderPara)
	{
		_attachmet = Anexo;
	}

	public EnviaEmail(string texto, string titulo)
		: this(texto, titulo, null)
	{
	}

	public EnviaEmail(string texto, string titulo, string[] destinatarios)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<HTML>");
		stringBuilder.Append("<BODY>");
		stringBuilder.Append($"<H1>MAXGPS - {titulo}</H1>");
		stringBuilder.Append("<p>&nbsp;");
		stringBuilder.Append($"MAXGPS - {texto}");
		stringBuilder.Append("</BODY>");
		stringBuilder.Append("</HTML>");
		_isHtml = true;
		_remetente = "estudos@fernandolucio.com.br";
		_assunto = titulo;
		_corpo = stringBuilder.ToString();
		_smtp = "smtp.fernandolucio.com.br";
		_smtpUsuario = "estudos@fernandolucio.com.br";
		_smtpSenha = "MaxTek01";
		_porta = 587;
		string[] array = new string[1];
		if (destinatarios != null)
		{
			int length = destinatarios.GetLength(0);
			array = new string[length + 1];
			for (int i = 0; i < length; i++)
			{
				array[i + 1] = destinatarios[i];
			}
		}
		array[0] = "estudos@fernandolucio.com.br";
		_destinatario = array;
	}

	public void EnviarThread()
	{
		Thread thread = new Thread(EnviarEmailThread);
		thread.Start();
	}

	private void EnviarEmailThread()
	{
		Enviar();
	}

	public bool Enviar()
	{
		string mensagemErroEnvio;
		return Enviar(isErro: false, out mensagemErroEnvio);
	}

	public bool Enviar(bool isErro)
	{
		string mensagemErroEnvio;
		return Enviar(isErro, out mensagemErroEnvio);
	}

	public bool Enviar(bool isErro, out string mensagemErroEnvio)
	{
		bool result = false;
		mensagemErroEnvio = string.Empty;
		try
		{
			_email = new MailMessage();
			if (_smtpUsuario.Contains("@"))
			{
				_email.From = new MailAddress(_smtpUsuario);
			}
			else
			{
				_email.From = new MailAddress(_remetente);
			}
			string[] destinatario = _destinatario;
			foreach (string text in destinatario)
			{
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				string[] array = text.Split(';');
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (text2.Contains("@"))
					{
						MailAddress item = new MailAddress(text2);
						if (!_email.To.Contains(item))
						{
							_email.To.Add(item);
						}
					}
				}
			}
			if (_responderPara != null)
			{
				string[] responderPara = _responderPara;
				foreach (string text3 in responderPara)
				{
					if (string.IsNullOrWhiteSpace(text3))
					{
						continue;
					}
					string[] array3 = text3.Split(';');
					string[] array4 = array3;
					foreach (string text4 in array4)
					{
						if (text4.Contains("@"))
						{
							MailAddress item2 = new MailAddress(text4);
							if (!_email.ReplyToList.Contains(item2))
							{
								_email.ReplyToList.Add(item2);
							}
						}
					}
				}
			}
			if (_richEditControl != null)
			{
				RichEditMailMessageExporter richEditMailMessageExporter = new RichEditMailMessageExporter(_richEditControl, _email);
				richEditMailMessageExporter.Export();
			}
			else
			{
				_email.Body = _corpo;
				_email.Bcc.Add("estudos@fernandolucio.com.br");
			}
			_email.Subject = _assunto;
			_email.IsBodyHtml = _isHtml;
			_cliente = new SmtpClient(_smtp, _porta);
			if (_anexo != null)
			{
				_email.Attachments.Add(new Attachment(_anexo));
			}
			else if (_anexos != null)
			{
				string[] anexos = _anexos;
				foreach (string text5 in anexos)
				{
					if (!string.IsNullOrWhiteSpace(text5))
					{
						_email.Attachments.Add(new Attachment(text5));
					}
				}
			}
			else if (_attachmet != null)
			{
				_email.Attachments.Add(_attachmet);
			}
			else if (_attachmets != null)
			{
				Attachment[] attachmets = _attachmets;
				foreach (Attachment attachment in attachmets)
				{
					if (attachment != null)
					{
						_email.Attachments.Add(attachment);
					}
				}
			}
			if (_smtpUsuario.Length > 0 && _smtpSenha.Length > 0)
			{
				_cliente.Credentials = new NetworkCredential(_smtpUsuario, _smtpSenha);
			}
			if (_isSSL)
			{
				_cliente.EnableSsl = true;
			}
			try
			{
				_cliente.Send(_email);
				result = true;
			}
			catch (Exception ex)
			{
				if (!isErro)
				{
					mensagemErroEnvio = $"{ex.Message}\r\n{ex.InnerException}";
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("Erro no envio de email<br />");
					stringBuilder.AppendFormat("Assunto: {0}<br />", _assunto);
					stringBuilder.AppendFormat("Remetente: {0}<br />", _remetente);
					string[] destinatario2 = _destinatario;
					foreach (string text6 in destinatario2)
					{
						if (text6 != null)
						{
							stringBuilder.AppendFormat("Destinatário: {0}<br />", text6);
						}
					}
					stringBuilder.AppendFormat("Smtp: {0}<br />", _smtp);
					stringBuilder.AppendFormat("Usuário Smtp: {0}<br />", _smtpUsuario);
					stringBuilder.AppendFormat("Senha Smtp: {0}<br />", _smtpSenha);
					stringBuilder.AppendFormat("Porta Smtp: {0}<br />", _porta);
					stringBuilder.AppendFormat("Horario: {0}<br />", DateTime.Now);
					stringBuilder.AppendFormat("<br /><br />Mensagem Erro:<br />{0}", ex.Message);
					stringBuilder.AppendFormat("<br />Erro:<br />{0}", ex.InnerException);
					stringBuilder.AppendFormat("<br /><br />corpo: <br />{0}<br />", _corpo);
					EnviaEmail enviaEmail = new EnviaEmail(stringBuilder.ToString(), "Erro Envio Email");
					try
					{
						enviaEmail.Enviar(isErro: true);
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}
}
