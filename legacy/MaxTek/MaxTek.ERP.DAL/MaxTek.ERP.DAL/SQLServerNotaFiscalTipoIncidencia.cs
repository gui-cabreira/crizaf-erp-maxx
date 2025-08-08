using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalTipoIncidencia : INotaFiscalTipoIncidencia
{
	private MapTableNotaFiscalTipoIncidencia MapearClasse(DataRow row)
	{
		MapTableNotaFiscalTipoIncidencia result = default(MapTableNotaFiscalTipoIncidencia);
		if (row != null)
		{
			result.codigoTipoIncidencia = BaseDadosERP.ObterDbValor<int>(row["codigoTipoIncidencia"]);
			result.tipoIncidencia = BaseDadosERP.ObterDbValor<string>(row["tipoIncidencia"]);
			result.descricaoIncidencia = BaseDadosERP.ObterDbValor<string>(row["descricaoIncidencia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigoTipoIncidencia], ");
		stringBuilder.Append("[nm_incidencia] as [tipoIncidencia], ");
		stringBuilder.Append("[ds_incidencia] as [descricaoIncidencia]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidencia] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalTipoIncidencia> ObterTodosNotaFiscalTipoIncidencia()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalTipoIncidencia> list = new List<MapTableNotaFiscalTipoIncidencia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(int codigoTipoIncidencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigoTipoIncidencia));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidencia.codigoTipoIncidencia));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidencia] (");
		stringBuilder.Append("[id], ");
		stringBuilder.Append("[nm_incidencia], ");
		stringBuilder.Append("[ds_incidencia]) Values (@id, @nm_incidencia,@ds_incidencia) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidencia.codigoTipoIncidencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_incidencia", NotaFiscalTipoIncidencia.tipoIncidencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_incidencia", NotaFiscalTipoIncidencia.descricaoIncidencia));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidencia] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIncidencia", "nm_incidencia", NotaFiscalTipoIncidencia.tipoIncidencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoIncidencia", "ds_incidencia", NotaFiscalTipoIncidencia.descricaoIncidencia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidencia.codigoTipoIncidencia));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalTipoIncidencia(int codigoTipoIncidencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[TipoIncidencia] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigoTipoIncidencia));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
