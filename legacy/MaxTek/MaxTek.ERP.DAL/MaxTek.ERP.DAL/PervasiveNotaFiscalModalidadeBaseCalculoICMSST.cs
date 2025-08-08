using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalModalidadeBaseCalculoICMSST : INotaFiscalModalidadeBaseCalculoICMSST
{
	private MapTableNotaFiscalModalidadeBaseCalculo MapearClasse(DataRow row)
	{
		MapTableNotaFiscalModalidadeBaseCalculo result = default(MapTableNotaFiscalModalidadeBaseCalculo);
		if (row != null)
		{
			result.codigoModalidade = BaseDadosERP.ObterDbValor<int>(row["codigoModalidade"]);
			result.descricaoModalidade = BaseDadosERP.ObterDbValor<string>(row["descricaoModalidade"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigoModalidade, ");
		stringBuilder.Append("ds_modalidade as descricaoModalidade");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.ModBaseCalculo ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalModalidadeBaseCalculo> ObterTodosNotaFiscalModalidadeBaseCalculoICMSST()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalModalidadeBaseCalculo> list = new List<MapTableNotaFiscalModalidadeBaseCalculo>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalModalidadeBaseCalculo ObterNotaFiscalModalidadeBaseCalculoICMSST(int codigoModalidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoModalidade));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalModalidadeBaseCalculo ObterNotaFiscalModalidadeBaseCalculoICMSST(MapTableNotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalModalidadeBaseCalculo.codigoModalidade));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalModalidadeBaseCalculoICMSST(MapTableNotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.ModBaseCalculo (");
		stringBuilder.Append("ds_modalidade) Values (?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("ds_modalidade", NotaFiscalModalidadeBaseCalculo.descricaoModalidade));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalModalidadeBaseCalculoICMSST(MapTableNotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculo, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.ModBaseCalculo Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoModalidade", "ds_modalidade", NotaFiscalModalidadeBaseCalculo.descricaoModalidade, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalModalidadeBaseCalculo.codigoModalidade));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalModalidadeBaseCalculoICMSST(int codigoModalidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.ModBaseCalculo ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoModalidade));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
