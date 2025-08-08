using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalTipoIncidenciaImpostosFederais : INotaFiscalTipoIncidenciaImpostosFederais
{
	private MapTableNotaFiscalTipoIncidenciaImpostosFederais MapearClasse(DataRow row)
	{
		MapTableNotaFiscalTipoIncidenciaImpostosFederais result = default(MapTableNotaFiscalTipoIncidenciaImpostosFederais);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoIncidencia = BaseDadosERP.ObterDbValor<string>(row["codigoIncidencia"]);
			result.descricaoInicidencia = BaseDadosERP.ObterDbValor<string>(row["descricaoInicidencia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_incidencia] as [codigoIncidencia], ");
		stringBuilder.Append("[ds_incidencia] as [descricaoInicidencia]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidenciaImpostosFederais] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalTipoIncidenciaImpostosFederais> ObterTodosNotaFiscalTipoIncidenciaImpostosFederais()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalTipoIncidenciaImpostosFederais> list = new List<MapTableNotaFiscalTipoIncidenciaImpostosFederais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalTipoIncidenciaImpostosFederais ObterNotaFiscalTipoIncidenciaImpostosFederais(int id)
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

	public MapTableNotaFiscalTipoIncidenciaImpostosFederais ObterNotaFiscalTipoIncidenciaImpostosFederais(MapTableNotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidenciaImpostosFederais.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalTipoIncidenciaImpostosFederais(MapTableNotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidenciaImpostosFederais] (");
		stringBuilder.Append("[id], ");
		stringBuilder.Append("[nm_incidencia], ");
		stringBuilder.Append("[ds_incidencia]) Values (@id,@nm_incidencia,@ds_incidencia) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidenciaImpostosFederais.id));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_incidencia", NotaFiscalTipoIncidenciaImpostosFederais.codigoIncidencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_incidencia", NotaFiscalTipoIncidenciaImpostosFederais.descricaoInicidencia));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalTipoIncidenciaImpostosFederais(MapTableNotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederais, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidenciaImpostosFederais] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoIncidencia", "nm_incidencia", NotaFiscalTipoIncidenciaImpostosFederais.codigoIncidencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoInicidencia", "ds_incidencia", NotaFiscalTipoIncidenciaImpostosFederais.descricaoInicidencia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidenciaImpostosFederais.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalTipoIncidenciaImpostosFederais(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidenciaImpostosFederais] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
