using System;

namespace MaxTek.ERP.BLL;

[Serializable]
internal class ClasseEtiquetaDispofix
{
	public string Cliente { get; set; }

	public string Emissão { get; set; }

	public string NotaFiscal { get; set; }

	public string EndereçoEntrega { get; set; }

	public string NomeTransportadora { get; set; }

	public string CodigoPeca { get; set; }

	public string Descrição { get; set; }

	public string Quantidade { get; set; }

	public string Pedido { get; set; }

	public string PedidoCliente { get; set; }

	public bool Embalagem { get; set; }
}
