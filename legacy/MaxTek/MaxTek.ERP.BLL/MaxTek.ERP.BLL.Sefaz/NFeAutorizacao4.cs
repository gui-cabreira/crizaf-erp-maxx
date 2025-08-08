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
[WebServiceBinding(Name = "NFeAutorizacao4Soap12", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
public class NFeAutorizacao4 : SoapHttpClientProtocol
{
	private SendOrPostCallback nfeAutorizacaoLoteOperationCompleted;

	private SendOrPostCallback nfeAutorizacaoLoteZipOperationCompleted;

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

	public event nfeAutorizacaoLoteCompletedEventHandler nfeAutorizacaoLoteCompleted;

	public event nfeAutorizacaoLoteZipCompletedEventHandler nfeAutorizacaoLoteZipCompleted;

	public NFeAutorizacao4()
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

	[SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLote", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
	[return: XmlElement("nfeResultMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
	public XmlNode nfeAutorizacaoLote([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")] XmlNode nfeDadosMsg)
	{
		object[] array = Invoke("nfeAutorizacaoLote", new object[1] { nfeDadosMsg });
		return (XmlNode)array[0];
	}

	public void nfeAutorizacaoLoteAsync(XmlNode nfeDadosMsg)
	{
		nfeAutorizacaoLoteAsync(nfeDadosMsg, null);
	}

	public void nfeAutorizacaoLoteAsync(XmlNode nfeDadosMsg, object userState)
	{
		if (nfeAutorizacaoLoteOperationCompleted == null)
		{
			nfeAutorizacaoLoteOperationCompleted = OnnfeAutorizacaoLoteOperationCompleted;
		}
		InvokeAsync("nfeAutorizacaoLote", new object[1] { nfeDadosMsg }, nfeAutorizacaoLoteOperationCompleted, userState);
	}

	private void OnnfeAutorizacaoLoteOperationCompleted(object arg)
	{
		if (this.nfeAutorizacaoLoteCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			this.nfeAutorizacaoLoteCompleted(this, new nfeAutorizacaoLoteCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
		}
	}

	[SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4/nfeAutorizacaoLoteZip", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
	[return: XmlElement("nfeResultMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")]
	public XmlNode nfeAutorizacaoLoteZip([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeAutorizacao4")] string nfeDadosMsgZip)
	{
		object[] array = Invoke("nfeAutorizacaoLoteZip", new object[1] { nfeDadosMsgZip });
		return (XmlNode)array[0];
	}

	public void nfeAutorizacaoLoteZipAsync(string nfeDadosMsgZip)
	{
		nfeAutorizacaoLoteZipAsync(nfeDadosMsgZip, null);
	}

	public void nfeAutorizacaoLoteZipAsync(string nfeDadosMsgZip, object userState)
	{
		if (nfeAutorizacaoLoteZipOperationCompleted == null)
		{
			nfeAutorizacaoLoteZipOperationCompleted = OnnfeAutorizacaoLoteZipOperationCompleted;
		}
		InvokeAsync("nfeAutorizacaoLoteZip", new object[1] { nfeDadosMsgZip }, nfeAutorizacaoLoteZipOperationCompleted, userState);
	}

	private void OnnfeAutorizacaoLoteZipOperationCompleted(object arg)
	{
		if (this.nfeAutorizacaoLoteZipCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			this.nfeAutorizacaoLoteZipCompleted(this, new nfeAutorizacaoLoteZipCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
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
