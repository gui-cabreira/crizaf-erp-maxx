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
[WebServiceBinding(Name = "NFeRecepcaoEvento4Soap12", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")]
public class NFeRecepcaoEvento4 : SoapHttpClientProtocol
{
	private SendOrPostCallback nfeRecepcaoEventoOperationCompleted;

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

	public event nfeRecepcaoEventoCompletedEventHandler nfeRecepcaoEventoCompleted;

	public NFeRecepcaoEvento4()
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

	[SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEvento", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
	[return: XmlElement("nfeResultMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")]
	public XmlNode nfeRecepcaoEvento([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4")] XmlNode nfeDadosMsg)
	{
		object[] array = Invoke("nfeRecepcaoEvento", new object[1] { nfeDadosMsg });
		return (XmlNode)array[0];
	}

	public void nfeRecepcaoEventoAsync(XmlNode nfeDadosMsg)
	{
		nfeRecepcaoEventoAsync(nfeDadosMsg, null);
	}

	public void nfeRecepcaoEventoAsync(XmlNode nfeDadosMsg, object userState)
	{
		if (nfeRecepcaoEventoOperationCompleted == null)
		{
			nfeRecepcaoEventoOperationCompleted = OnnfeRecepcaoEventoOperationCompleted;
		}
		InvokeAsync("nfeRecepcaoEvento", new object[1] { nfeDadosMsg }, nfeRecepcaoEventoOperationCompleted, userState);
	}

	private void OnnfeRecepcaoEventoOperationCompleted(object arg)
	{
		if (this.nfeRecepcaoEventoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			this.nfeRecepcaoEventoCompleted(this, new nfeRecepcaoEventoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
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
