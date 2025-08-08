using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialFiscalContaContabil : IComercialFiscalContaContabil
{
	private MapTableComercialFiscalContaContabil MapearClasse(DataRow row)
	{
		MapTableComercialFiscalContaContabil result = default(MapTableComercialFiscalContaContabil);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
			result.classe = BaseDadosGPS.ObterDbValor<int>(row["classe"]);
			result.subClasse = BaseDadosGPS.ObterDbValor<int>(row["subClasse"]);
			result.contaAnalitica = BaseDadosGPS.ObterDbValor<string>(row["contaAnalitica"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_conta as descricao, ");
		stringBuilder.Append("classe as classe, ");
		stringBuilder.Append("subclasse as subClasse, ");
		stringBuilder.Append("cd_conta_analitica as contaAnalitica");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.FiscalContaContabil ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFiscalContaContabil> ObterTodosComercialFiscalContaContabil()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFiscalContaContabil> list = new List<MapTableComercialFiscalContaContabil>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFiscalContaContabil ObterComercialFiscalContaContabil(int id)
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

	public MapTableComercialFiscalContaContabil ObterComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFiscalContaContabil.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.FiscalContaContabil (");
		stringBuilder.Append("nm_conta, ");
		stringBuilder.Append("classe, ");
		stringBuilder.Append("subclasse, ");
		stringBuilder.Append("cd_conta_analitica) Values (?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_conta", ComercialFiscalContaContabil.descricao));
		list.Add(BaseDadosGPS.ObterNovoParametro("classe", ComercialFiscalContaContabil.classe));
		list.Add(BaseDadosGPS.ObterNovoParametro("subclasse", ComercialFiscalContaContabil.subClasse));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_conta_analitica", ComercialFiscalContaContabil.contaAnalitica));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.FiscalContaContabil Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "nm_conta", ComercialFiscalContaContabil.descricao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Classe", "classe", ComercialFiscalContaContabil.classe, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "SubClasse", "subclasse", ComercialFiscalContaContabil.subClasse, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ContaAnalitica", "cd_conta_analitica", ComercialFiscalContaContabil.contaAnalitica, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFiscalContaContabil.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFiscalContaContabil(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.FiscalContaContabil ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
