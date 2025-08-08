using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalTextosLegais : INotaFiscalTextosLegais
{
	private MapTableNotaFiscalTextosLegais MapearClasse(DataRow row)
	{
		MapTableNotaFiscalTextosLegais result = default(MapTableNotaFiscalTextosLegais);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.textoLegal = BaseDadosERP.ObterDbValor<string>(row["textoLegal"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[ds_texto_legal] as [textoLegal]");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[TextosLegais] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalTextosLegais> ObterTodosNotaFiscalTextosLegais()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalTextosLegais> list = new List<MapTableNotaFiscalTextosLegais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalTextosLegais ObterNotaFiscalTextosLegais(int id)
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

	public MapTableNotaFiscalTextosLegais ObterNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTextosLegais.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Insert into [{0}].[{1}].[NotaFiscal].[TextosLegais] (", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("[ds_texto_legal]) Values (@ds_texto_legal) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_texto_legal", NotaFiscalTextosLegais.textoLegal));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Update [{0}].[{1}].[NotaFiscal].[TextosLegais] Set ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TextoLegal", "ds_texto_legal", NotaFiscalTextosLegais.textoLegal, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTextosLegais.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalTextosLegais(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[TextosLegais] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
