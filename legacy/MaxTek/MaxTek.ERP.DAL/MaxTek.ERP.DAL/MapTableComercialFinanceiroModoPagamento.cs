using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialFinanceiroModoPagamento
{
	public int codigo;

	public string sigla;

	public string nome;

	public bool gerarBoleto;

	public int codigoContaContabil;
}
