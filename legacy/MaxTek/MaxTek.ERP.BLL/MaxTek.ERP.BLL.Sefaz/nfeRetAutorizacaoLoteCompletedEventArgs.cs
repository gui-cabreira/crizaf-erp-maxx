using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;

namespace MaxTek.ERP.BLL.Sefaz;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class nfeRetAutorizacaoLoteCompletedEventArgs : AsyncCompletedEventArgs
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

	internal nfeRetAutorizacaoLoteCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
