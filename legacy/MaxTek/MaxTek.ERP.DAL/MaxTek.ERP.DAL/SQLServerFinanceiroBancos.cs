using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerFinanceiroBancos : IFinanceiroBancos
{
	private MapTableFinanceiroBancos MapearClasse(DataRow row)
	{
		MapTableFinanceiroBancos result = default(MapTableFinanceiroBancos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.banco = BaseDadosERP.ObterDbValor<string>(row["banco"]);
			result.agencia = BaseDadosERP.ObterDbValor<string>(row["agencia"]);
			result.contaCorrente = BaseDadosERP.ObterDbValor<string>(row["contaCorrente"]);
			result.saldoInicial = BaseDadosERP.ObterDbValor<decimal>(row["saldoInicial"]);
			result.dataSaldoInicial = BaseDadosERP.ObterDbValor<DateTime>(row["dataSaldoInicial"]);
			result.limiteConta = BaseDadosERP.ObterDbValor<decimal>(row["limiteConta"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_banco] as [banco], ");
		stringBuilder.Append("[nm_agencia] as [agencia], ");
		stringBuilder.Append("[nm_conta] as [contaCorrente], ");
		stringBuilder.Append("[vl_saldo_inicial] as [saldoInicial], ");
		stringBuilder.Append("[dt_saldo_inicial] as [dataSaldoInicial], ");
		stringBuilder.Append("[vl_limite_conta] as [limiteConta]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Bancos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableFinanceiroBancos> ObterTodosFinanceiroBancos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableFinanceiroBancos> list = new List<MapTableFinanceiroBancos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableFinanceiroBancos ObterFinanceiroBancos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableFinanceiroBancos ObterFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", FinanceiroBancos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Bancos] (");
		stringBuilder.Append("[nm_banco], ");
		stringBuilder.Append("[nm_agencia], ");
		stringBuilder.Append("[nm_conta], ");
		stringBuilder.Append("[vl_saldo_inicial], ");
		stringBuilder.Append("[dt_saldo_inicial], ");
		stringBuilder.Append("[vl_limite_conta]) Values (@nm_banco,@nm_agencia,@nm_conta,@vl_saldo_inicial,@dt_saldo_inicial,@vl_limite_conta) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_banco", FinanceiroBancos.banco));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_agencia", FinanceiroBancos.agencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_conta", FinanceiroBancos.contaCorrente));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_saldo_inicial", FinanceiroBancos.saldoInicial));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_saldo_inicial", FinanceiroBancos.dataSaldoInicial));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_limite_conta", FinanceiroBancos.limiteConta));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Bancos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Banco", "nm_banco", FinanceiroBancos.banco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Agencia", "nm_agencia", FinanceiroBancos.agencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ContaCorrente", "nm_conta", FinanceiroBancos.contaCorrente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SaldoInicial", "vl_saldo_inicial", FinanceiroBancos.saldoInicial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataSaldoInicial", "dt_saldo_inicial", FinanceiroBancos.dataSaldoInicial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "LimiteConta", "vl_limite_conta", FinanceiroBancos.limiteConta, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", FinanceiroBancos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirFinanceiroBancos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Bancos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
