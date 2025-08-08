using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;

namespace MaxTek.ERP.BLL.Sefaz;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class nfeInutilizacaoNFCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public XmlNode Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (XmlNode)results[0];
		}
	}

	internal nfeInutilizacaoNFCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
