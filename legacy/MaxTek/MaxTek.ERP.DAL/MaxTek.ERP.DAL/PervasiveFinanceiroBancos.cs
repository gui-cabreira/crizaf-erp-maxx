using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveFinanceiroBancos : IFinanceiroBancos
{
	private MapTableFinanceiroBancos MapearClasse(DataRow row)
	{
		MapTableFinanceiroBancos result = default(MapTableFinanceiroBancos);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.banco = BaseDadosGPS.ObterDbValor<string>(row["banco"]);
			result.agencia = BaseDadosGPS.ObterDbValor<string>(row["agencia"]);
			result.contaCorrente = BaseDadosGPS.ObterDbValor<string>(row["contaCorrente"]);
			result.saldoInicial = BaseDadosGPS.ObterDbValor<decimal>(row["saldoInicial"]);
			result.dataSaldoInicial = BaseDadosGPS.ObterDbValor<DateTime>(row["dataSaldoInicial"]);
			result.limiteConta = BaseDadosGPS.ObterDbValor<decimal>(row["limiteConta"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_banco as banco, ");
		stringBuilder.Append("nm_agencia as agencia, ");
		stringBuilder.Append("nm_conta as contaCorrente, ");
		stringBuilder.Append("vl_saldo_inicial as saldoInicial, ");
		stringBuilder.Append("dt_saldo_inicial as dataSaldoInicial, ");
		stringBuilder.Append("vl_limite_conta as limiteConta");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.FinanceiroBancos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableFinanceiroBancos> ObterTodosFinanceiroBancos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableFinanceiroBancos ObterFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", FinanceiroBancos.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.FinanceiroBancos (");
		stringBuilder.Append("nm_banco, ");
		stringBuilder.Append("nm_agencia, ");
		stringBuilder.Append("nm_conta, ");
		stringBuilder.Append("vl_saldo_inicial, ");
		stringBuilder.Append("dt_saldo_inicial, ");
		stringBuilder.Append("vl_limite_conta) Values (?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_banco", FinanceiroBancos.banco));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_agencia", FinanceiroBancos.agencia));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_conta", FinanceiroBancos.contaCorrente));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_saldo_inicial", FinanceiroBancos.saldoInicial));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_saldo_inicial", FinanceiroBancos.dataSaldoInicial));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_limite_conta", FinanceiroBancos.limiteConta));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.FinanceiroBancos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Banco", "nm_banco", FinanceiroBancos.banco, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Agencia", "nm_agencia", FinanceiroBancos.agencia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ContaCorrente", "nm_conta", FinanceiroBancos.contaCorrente, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "SaldoInicial", "vl_saldo_inicial", FinanceiroBancos.saldoInicial, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataSaldoInicial", "dt_saldo_inicial", FinanceiroBancos.dataSaldoInicial, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "LimiteConta", "vl_limite_conta", FinanceiroBancos.limiteConta, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", FinanceiroBancos.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirFinanceiroBancos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.FinanceiroBancos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
