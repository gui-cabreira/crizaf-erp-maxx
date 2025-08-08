using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/")]
public enum statusCartao
{
	Desconhecido,
	Normal,
	Suspenso,
	Cancelado,
	Irregular
}
