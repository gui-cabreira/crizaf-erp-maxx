using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidadeTipoAtendimento : IComercialEntidadeTipoAtendimento
{
	private MapTableComercialEntidadeTipoAtendimento MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeTipoAtendimento result = default(MapTableComercialEntidadeTipoAtendimento);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.tipoAtendimento = BaseDadosERP.ObterDbValor<string>(row["tipoAtendimento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_tipo_atendimento] as [tipoAtendimento]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeTipoAtendimento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeTipoAtendimento> ObterTodosComercialEntidadeTipoAtendimento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeTipoAtendimento ObterComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeTipoAtendimento.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeTipoAtendimento] (");
		stringBuilder.Append("nm_tipo_atendimento) Values (@nm_tipo_atendimento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_atendimento", ComercialEntidadeTipoAtendimento.tipoAtendimento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeTipoAtendimento(MapTableComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeTipoAtendimento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoAtendimento", "nm_tipo_atendimento", ComercialEntidadeTipoAtendimento.tipoAtendimento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeTipoAtendimento.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}
}
