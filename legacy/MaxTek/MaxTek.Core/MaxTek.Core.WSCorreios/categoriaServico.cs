using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/")]
public enum categoriaServico
{
	SEM_CATEGORIA,
	PAC,
	SEDEX,
	CARTA_REGISTRADA,
	SERVICO_COM_RESTRICAO,
	REVERSO,
	CARTA_CTR
}
