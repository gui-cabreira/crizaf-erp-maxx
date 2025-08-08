using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialVendasPedidos
{
	public int id;

	public int codigoStatus;

	public DateTime dataCadastro;

	public DateTime dataAtualizacao;

	public int codigoEntidade;

	public int codigoEntidadeContato;

	public string referenciaPedido;

	public DateTime dataEntrega;

	public int codigoModoPagamento;

	public int codigoCondicaoPagamento;

	public int codigoTransportadora;

	public int codigoVendedor;

	public int codigoRepresentante;

	public int codigoEntidadeEntrega;

	public int codigoEntidadeFatura;

	public int codigoCfop;

	public int codigoMoeda;

	public string descricaoPedido;
}
