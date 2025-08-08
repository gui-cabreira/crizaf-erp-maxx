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
[WebServiceBinding(Name = "NFeInutilizacao4Soap12", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4")]
public class NFeInutilizacao4 : SoapHttpClientProtocol
{
	private SendOrPostCallback nfeInutilizacaoNFOperationCompleted;

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

	public event nfeInutilizacaoNFCompletedEventHandler nfeInutilizacaoNFCompleted;

	public NFeInutilizacao4()
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

	[SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4/nfeInutilizacaoNF", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
	[return: XmlElement("nfeResultMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4")]
	public XmlNode nfeInutilizacaoNF([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeInutilizacao4")] XmlNode nfeDadosMsg)
	{
		object[] array = Invoke("nfeInutilizacaoNF", new object[1] { nfeDadosMsg });
		return (XmlNode)array[0];
	}

	public void nfeInutilizacaoNFAsync(XmlNode nfeDadosMsg)
	{
		nfeInutilizacaoNFAsync(nfeDadosMsg, null);
	}

	public void nfeInutilizacaoNFAsync(XmlNode nfeDadosMsg, object userState)
	{
		if (nfeInutilizacaoNFOperationCompleted == null)
		{
			nfeInutilizacaoNFOperationCompleted = OnnfeInutilizacaoNFOperationCompleted;
		}
		InvokeAsync("nfeInutilizacaoNF", new object[1] { nfeDadosMsg }, nfeInutilizacaoNFOperationCompleted, userState);
	}

	private void OnnfeInutilizacaoNFOperationCompleted(object arg)
	{
		if (this.nfeInutilizacaoNFCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			this.nfeInutilizacaoNFCompleted(this, new nfeInutilizacaoNFCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
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
