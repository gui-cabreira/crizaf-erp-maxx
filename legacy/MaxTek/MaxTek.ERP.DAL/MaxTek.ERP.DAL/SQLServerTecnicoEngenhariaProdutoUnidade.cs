using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProdutoUnidade : ITecnicoEngenhariaProdutoUnidade
{
	private MapTableTecnicoEngenhariaProdutoUnidade MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoUnidade result = default(MapTableTecnicoEngenhariaProdutoUnidade);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.unidade = BaseDadosERP.ObterDbValor<string>(row["unidade"]);
			result.grupo = BaseDadosERP.ObterDbValor<int>(row["grupo"]);
			result.coeficienteGrupo = BaseDadosERP.ObterDbValor<decimal>(row["coeficienteGrupo"]);
			result.sigla = BaseDadosERP.ObterDbValor<string>(row["sigla"]);
			result.codigoGPS = BaseDadosERP.ObterDbValor<int>(row["codigoGPS"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_unidade] as [unidade], ");
		stringBuilder.Append("[cd_grupo] as [grupo], ");
		stringBuilder.Append("[vl_multiplicador_grupo] as [coeficienteGrupo], ");
		stringBuilder.Append("[sg_unidade] as [sigla], ");
		stringBuilder.Append("[cd_gps] as [codigoGPS]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoUnidade] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoUnidade> ObterTodosTecnicoEngenhariaProdutoUnidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoUnidade> list = new List<MapTableTecnicoEngenhariaProdutoUnidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProdutoUnidade ObterTecnicoEngenhariaProdutoUnidade(int id)
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

	public MapTableTecnicoEngenhariaProdutoUnidade ObterTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoUnidade.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoUnidade] (");
		stringBuilder.Append("[nm_unidade], ");
		stringBuilder.Append("[cd_grupo], ");
		stringBuilder.Append("[vl_multiplicador_grupo], ");
		stringBuilder.Append("[sg_unidade], ");
		stringBuilder.Append("[cd_gps]) Values (@nm_unidade,@cd_grupo,@vl_multiplicador_grupo,@sg_unidade,@cd_gps) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_unidade", TecnicoEngenhariaProdutoUnidade.unidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_grupo", TecnicoEngenhariaProdutoUnidade.grupo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_multiplicador_grupo", TecnicoEngenhariaProdutoUnidade.coeficienteGrupo));
		list.Add(BaseDadosERP.ObterNovoParametro("@sg_unidade", TecnicoEngenhariaProdutoUnidade.sigla));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_gps", TecnicoEngenhariaProdutoUnidade.codigoGPS));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoUnidade] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Unidade", "nm_unidade", TecnicoEngenhariaProdutoUnidade.unidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Grupo", "cd_grupo", TecnicoEngenhariaProdutoUnidade.grupo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CoeficienteGrupo", "vl_multiplicador_grupo", TecnicoEngenhariaProdutoUnidade.coeficienteGrupo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Sigla", "sg_unidade", TecnicoEngenhariaProdutoUnidade.sigla, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoGPS", "cd_gps", TecnicoEngenhariaProdutoUnidade.codigoGPS, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoUnidade.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoUnidade(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoUnidade] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
