using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidadeTipoAtendimento : IComercialEntidadeTipoAtendimento
{
	private MapTableComercialEntidadeTipoAtendimento MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeTipoAtendimento result = default(MapTableComercialEntidadeTipoAtendimento);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.tipoAtendimento = BaseDadosGPS.ObterDbValor<string>(row["tipoAtendimento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("nm_tipo_atendimento as tipoAtendimento");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.TipoAtendimento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeTipoAtendimento> ObterTodosComercialEntidadeTipoAtendimento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeTipoAtendimento> list = new List<MapTableComercialEntidadeTipoAtendimento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidadeTipoAtendimento ObterComercialEntidadeTipoAtendimento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeTipoAtendimento ObterComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeTipoAtendimento.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.TipoAtendimento (");
		stringBuilder.Append("nm_tipo_atendimento) Values (?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_tipo_atendimento", ComercialEntidadeTipoAtendimento.tipoAtendimento));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.TipoAtendimento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TipoAtendimento", "nm_tipo_atendimento", ComercialEntidadeTipoAtendimento.tipoAtendimento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeTipoAtendimento.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}
}
