using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialFinanceiroCondicaoPagamento
{
	public int codigo;

	public string nome;

	public int numeroDiasPrimeiraParcela;

	public int numeroDiasDemaisParcelas;

	public int numeroParcelas;

	public bool calculoManualData;
}
