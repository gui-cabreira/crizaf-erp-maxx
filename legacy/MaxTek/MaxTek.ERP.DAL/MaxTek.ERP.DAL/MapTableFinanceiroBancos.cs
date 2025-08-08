using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableFinanceiroBancos
{
	public int id;

	public string banco;

	public string agencia;

	public string contaCorrente;

	public decimal saldoInicial;

	public DateTime dataSaldoInicial;

	public decimal limiteConta;
}
