using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

namespace MaxTek.ERP.BLL.Sefaz;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "CadConsultaCadastro4Soap12", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4")]
public class CadConsultaCadastro4 : SoapHttpClientProtocol
{
	private SendOrPostCallback consultaCadastroOperationCompleted;

	private bool useDefaultCredentialsSetExplicitly;

	public new string Url
	{
		get
		{
			return base.Url;
		}
		set
		{
			if (IsLocalFileSystemWebService(base.Url) && !useDefaultCredentialsSetExplicitly && !IsLocalFileSystemWebService(value))
			{
				base.UseDefaultCredentials = false;
			}
			base.Url = value;
		}
	}

	public new bool UseDefaultCredentials
	{
		get
		{
			return base.UseDefaultCredentials;
		}
		set
		{
			base.UseDefaultCredentials = value;
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	public event consultaCadastroCompletedEventHandler consultaCadastroCompleted;

	public CadConsultaCadastro4()
	{
		base.SoapVersion = SoapProtocolVersion.Soap12;
		if (IsLocalFileSystemWebService(Url))
		{
			UseDefaultCredentials = true;
			useDefaultCredentialsSetExplicitly = false;
		}
		else
		{
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4/consultaCadastro", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
	[return: XmlElement("nfeResultMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4")]
	public XmlNode consultaCadastro([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro4")] XmlNode nfeDadosMsg)
	{
		object[] array = Invoke("consultaCadastro", new object[1] { nfeDadosMsg });
		return (XmlNode)array[0];
	}

	public void consultaCadastroAsync(XmlNode nfeDadosMsg)
	{
		consultaCadastroAsync(nfeDadosMsg, null);
	}

	public void consultaCadastroAsync(XmlNode nfeDadosMsg, object userState)
	{
		if (consultaCadastroOperationCompleted == null)
		{
			consultaCadastroOperationCompleted = OnconsultaCadastroOperationCompleted;
		}
		InvokeAsync("consultaCadastro", new object[1] { nfeDadosMsg }, consultaCadastroOperationCompleted, userState);
	}

	private void OnconsultaCadastroOperationCompleted(object arg)
	{
		if (this.consultaCadastroCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			this.consultaCadastroCompleted(this, new consultaCadastroCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
		}
	}

	public new void CancelAsync(object userState)
	{
		base.CancelAsync(userState);
	}

	private bool IsLocalFileSystemWebService(string url)
	{
		if (url == null || url == string.Empty)
		{
			return false;
		}
		Uri uri = new Uri(url);
		if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		return false;
	}
}
