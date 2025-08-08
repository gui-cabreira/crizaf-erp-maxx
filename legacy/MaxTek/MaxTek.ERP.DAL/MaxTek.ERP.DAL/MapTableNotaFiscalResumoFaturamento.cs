using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalResumoFaturamento
{
	public int ano;

	public int mes;

	public string contaContabil;

	public string cfop;

	public int codigoEntidade;

	public decimal valorTotal;

	public decimal valorBaseICMS;

	public decimal valorIcms;

	public decimal valorIpi;

	public decimal valorPis;

	public decimal valorCofins;

	public decimal valorFrete;

	public decimal valorSeguro;

	public decimal valorFatura;

	public decimal valorRetencaoPis;

	public decimal valorRetencaoCofins;

	public decimal valorCsll;
}
