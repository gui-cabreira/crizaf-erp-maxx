using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalTipoIncidenciaIPI : INotaFiscalTipoIncidenciaIPI
{
	private MapTableNotaFiscalTipoIncidenciaIPI MapearClasse(DataRow row)
	{
		MapTableNotaFiscalTipoIncidenciaIPI result = default(MapTableNotaFiscalTipoIncidenciaIPI);
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
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[TipoIncidenciaIPI] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalTipoIncidenciaIPI> ObterTodosNotaFiscalTipoIncidenciaIPI()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("order by [nm_incidencia] ");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalTipoIncidenciaIPI> list = new List<MapTableNotaFiscalTipoIncidenciaIPI>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(int id)
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

	public MapTableNotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidenciaIPI.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Insert into [{0}].[{1}].[NotaFiscal].[TipoIncidenciaIPI] (", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("[nm_incidencia], ");
		stringBuilder.Append("[ds_incidencia]) Values (@nm_incidencia,@ds_incidencia) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_incidencia", NotaFiscalTipoIncidenciaIPI.codigoIncidencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_incidencia", NotaFiscalTipoIncidenciaIPI.descricaoInicidencia));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Update [{0}].[{1}].[NotaFiscal].[TipoIncidenciaIPI] Set ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoIncidencia", "nm_incidencia", NotaFiscalTipoIncidenciaIPI.codigoIncidencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoInicidencia", "ds_incidencia", NotaFiscalTipoIncidenciaIPI.descricaoInicidencia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalTipoIncidenciaIPI.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalTipoIncidenciaIPI(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[TipoIncidenciaIPI] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
