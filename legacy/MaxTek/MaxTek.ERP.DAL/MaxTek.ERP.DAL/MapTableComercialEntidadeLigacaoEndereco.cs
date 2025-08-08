using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialEntidadeLigacaoEndereco
{
	public int codigoEntidade;

	public int codigoEntidadeEndereco;

	public string descricao;

	public bool isEnderecoEntrega;

	public bool isEnderecoCobranca;

	public bool isEnderecoFaturamente;
}
