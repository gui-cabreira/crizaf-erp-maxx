using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalCidades : INotaFiscalCidades
{
	private MapTableNotaFiscalCidades MapearClasse(DataRow row)
	{
		MapTableNotaFiscalCidades result = default(MapTableNotaFiscalCidades);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoUF = BaseDadosERP.ObterDbValor<int>(row["codigoUF"]);
			result.nomeCidade = BaseDadosERP.ObterDbValor<string>(row["nomeCidade"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_uf as codigoUF, ");
		stringBuilder.Append("ds_cidade as nomeCidade");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCidades ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalCidades> ObterTodosNotaFiscalCidades()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalCidades> list = new List<MapTableNotaFiscalCidades>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalCidades ObterNotaFiscalCidades(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCidades ObterNotaFiscalCidades(string cidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" ds_cidade = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("ds_cidade", cidade));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalCidades> ObterNotaFiscalCidadesEstado(int codigoEstado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_uf = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_uf", codigoEstado));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalCidades> list2 = new List<MapTableNotaFiscalCidades>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalCidades ObterNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalCidades.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCidades (");
		stringBuilder.Append("cd_uf, ");
		stringBuilder.Append("ds_cidade) Values (?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_uf", NotaFiscalCidades.codigoUF));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_cidade", NotaFiscalCidades.nomeCidade));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCidades Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUF", "cd_uf", NotaFiscalCidades.codigoUF, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCidade", "ds_cidade", NotaFiscalCidades.nomeCidade, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalCidades.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalCidades(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCidades ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public MapTableNotaFiscalCidades ObterNotaFiscalCidades(int codigoEstado, string cidade)
	{
		throw new NotImplementedException();
	}
}
