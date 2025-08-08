using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProdutoUnidade : ITecnicoEngenhariaProdutoUnidade
{
	private MapTableTecnicoEngenhariaProdutoUnidade MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoUnidade result = default(MapTableTecnicoEngenhariaProdutoUnidade);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.unidade = BaseDadosGPS.ObterDbValor<string>(row["unidade"]);
			result.grupo = BaseDadosGPS.ObterDbValor<int>(row["grupo"]);
			result.coeficienteGrupo = BaseDadosGPS.ObterDbValor<decimal>(row["coeficienteGrupo"]);
			result.sigla = BaseDadosGPS.ObterDbValor<string>(row["sigla"]);
			result.codigoGPS = BaseDadosGPS.ObterDbValor<int>(row["codigoGPS"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_unidade as unidade, ");
		stringBuilder.Append("cd_grupo as grupo, ");
		stringBuilder.Append("vl_multiplicador_gru as coeficienteGrupo, ");
		stringBuilder.Append("sg_unidade as sigla, ");
		stringBuilder.Append("cd_gps as codigoGPS");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoUnidade ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoUnidade> ObterTodosTecnicoEngenhariaProdutoUnidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProdutoUnidade ObterTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoUnidade.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoUnidade (");
		stringBuilder.Append("nm_unidade, ");
		stringBuilder.Append("cd_grupo, ");
		stringBuilder.Append("vl_multiplicador_gru, ");
		stringBuilder.Append("sg_unidade, ");
		stringBuilder.Append("cd_gps) Values (?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_unidade", TecnicoEngenhariaProdutoUnidade.unidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_grupo", TecnicoEngenhariaProdutoUnidade.grupo));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_multiplicador_gru", TecnicoEngenhariaProdutoUnidade.coeficienteGrupo));
		list.Add(BaseDadosGPS.ObterNovoParametro("sg_unidade", TecnicoEngenhariaProdutoUnidade.sigla));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_gps", TecnicoEngenhariaProdutoUnidade.codigoGPS));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoUnidade(MapTableTecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoUnidade Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Unidade", "nm_unidade", TecnicoEngenhariaProdutoUnidade.unidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Grupo", "cd_grupo", TecnicoEngenhariaProdutoUnidade.grupo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CoeficienteGrupo", "vl_multiplicador_gru", TecnicoEngenhariaProdutoUnidade.coeficienteGrupo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Sigla", "sg_unidade", TecnicoEngenhariaProdutoUnidade.sigla, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoGPS", "cd_gps", TecnicoEngenhariaProdutoUnidade.codigoGPS, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoUnidade.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoUnidade(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoUnidade ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
