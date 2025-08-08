using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProcessoMateria : ITecnicoEngenhariaProcessoMateria
{
	private MapTableTecnicoEngenhariaProcessoMateria MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoMateria result = default(MapTableTecnicoEngenhariaProcessoMateria);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.idProcesso = BaseDadosERP.ObterDbValor<int>(row["idProcesso"]);
			result.idProcessoOperacao = BaseDadosERP.ObterDbValor<int>(row["idProcessoOperacao"]);
			result.idMateriaPrima = BaseDadosERP.ObterDbValor<int>(row["idMateriaPrima"]);
			result.nomeMateriaPrima = BaseDadosERP.ObterDbValor<string>(row["nomeMateriaPrima"]);
			result.codigoTipoMateriaPrima = BaseDadosERP.ObterDbValor<int>(row["codigoTipoMateriaPrima"]);
			result.dimensao01 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao01"]);
			result.dimensao02 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao02"]);
			result.dimensao03 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao03"]);
			result.valorQuantidadeNecessaria = BaseDadosERP.ObterDbValor<int>(row["valorQuantidadeNecessaria"]);
			result.valorTamanhoNecessidade = BaseDadosERP.ObterDbValor<decimal>(row["valorTamanhoNecessidade"]);
			result.isLoteada = BaseDadosERP.ObterDbValor<bool>(row["isLoteada"]);
			result.percentualPerda = BaseDadosERP.ObterDbValor<decimal>(row["percentualPerda"]);
			result.indiceMateria = BaseDadosERP.ObterDbValor<int>(row["indiceMateria"]);
			result.posicaoDesenho = BaseDadosERP.ObterDbValor<string>(row["posicaoDesenho"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("id_processo as idProcesso, ");
		stringBuilder.Append("id_processo_operacao as idProcessoOperacao, ");
		stringBuilder.Append("id_materia_prima as idMateriaPrima, ");
		stringBuilder.Append("nm_materia_prima as nomeMateriaPrima, ");
		stringBuilder.Append("cd_tipo_materia_prim as codigoTipoMateriaPrima, ");
		stringBuilder.Append("vl_dim_01 as dimensao01, ");
		stringBuilder.Append("vl_dim_02 as dimensao02, ");
		stringBuilder.Append("vl_dim_03 as dimensao03, ");
		stringBuilder.Append("vl_necessidade as valorQuantidadeNecessaria, ");
		stringBuilder.Append("vl_tamanho as valorTamanhoNecessidade, ");
		stringBuilder.Append("ic_loteada as isLoteada, ");
		stringBuilder.Append("pc_perda as percentualPerda, ");
		stringBuilder.Append("cd_indice_materia as indiceMateria, ");
		stringBuilder.Append("cd_posicao_desenho as posicaoDesenho");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "ERP.ProcessoMateria ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoMateria> ObterTodosTecnicoEngenhariaProcessoMateria()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoMateria> list = new List<MapTableTecnicoEngenhariaProcessoMateria>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProcessoMateria> ObterTodosTecnicoEngenhariaProcessoMateria(int idProcesso)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_processo = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id_processo", idProcesso));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProcessoMateria> list2 = new List<MapTableTecnicoEngenhariaProcessoMateria>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProcessoMateria ObterTecnicoEngenhariaProcessoMateria(int id)
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

	public MapTableTecnicoEngenhariaProcessoMateria ObterTecnicoEngenhariaProcessoMateria(MapTableTecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateria)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoEngenhariaProcessoMateria.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoMateria(MapTableTecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateria)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "ERP.ProcessoMateria (");
		stringBuilder.Append("id_processo, ");
		stringBuilder.Append("id_processo_operacao, ");
		stringBuilder.Append("id_materia_prima, ");
		stringBuilder.Append("nm_materia_prima, ");
		stringBuilder.Append("cd_tipo_materia_prim, ");
		stringBuilder.Append("vl_dim_01, ");
		stringBuilder.Append("vl_dim_02, ");
		stringBuilder.Append("vl_dim_03, ");
		stringBuilder.Append("vl_necessidade, ");
		stringBuilder.Append("vl_tamanho, ");
		stringBuilder.Append("ic_loteada, ");
		stringBuilder.Append("pc_perda, ");
		stringBuilder.Append("cd_indice_materia, ");
		stringBuilder.Append("cd_posicao_desenho) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("id_processo", TecnicoEngenhariaProcessoMateria.idProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("id_processo_operacao", TecnicoEngenhariaProcessoMateria.idProcessoOperacao));
		list.Add(BaseDadosERP.ObterNovoParametro("id_materia_prima", TecnicoEngenhariaProcessoMateria.idMateriaPrima));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_materia_prima", TecnicoEngenhariaProcessoMateria.nomeMateriaPrima));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_tipo_materia_prim", TecnicoEngenhariaProcessoMateria.codigoTipoMateriaPrima));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_dim_01", TecnicoEngenhariaProcessoMateria.dimensao01));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_dim_02", TecnicoEngenhariaProcessoMateria.dimensao02));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_dim_03", TecnicoEngenhariaProcessoMateria.dimensao03));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_necessidade", TecnicoEngenhariaProcessoMateria.valorQuantidadeNecessaria));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_tamanho", TecnicoEngenhariaProcessoMateria.valorTamanhoNecessidade));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_loteada", TecnicoEngenhariaProcessoMateria.isLoteada));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_perda", TecnicoEngenhariaProcessoMateria.percentualPerda));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_indice_materia", TecnicoEngenhariaProcessoMateria.indiceMateria));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_posicao_desenho", TecnicoEngenhariaProcessoMateria.posicaoDesenho));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoMateria(MapTableTecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateria, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "ERP.ProcessoMateria Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcesso", "id_processo", TecnicoEngenhariaProcessoMateria.idProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcessoOperacao", "id_processo_operacao", TecnicoEngenhariaProcessoMateria.idProcessoOperacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdMateriaPrima", "id_materia_prima", TecnicoEngenhariaProcessoMateria.idMateriaPrima, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeMateriaPrima", "nm_materia_prima", TecnicoEngenhariaProcessoMateria.nomeMateriaPrima, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoMateriaPrima", "cd_tipo_materia_prim", TecnicoEngenhariaProcessoMateria.codigoTipoMateriaPrima, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao01", "vl_dim_01", TecnicoEngenhariaProcessoMateria.dimensao01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao02", "vl_dim_02", TecnicoEngenhariaProcessoMateria.dimensao02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao03", "vl_dim_03", TecnicoEngenhariaProcessoMateria.dimensao03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorQuantidadeNecessaria", "vl_necessidade", TecnicoEngenhariaProcessoMateria.valorQuantidadeNecessaria, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTamanhoNecessidade", "vl_tamanho", TecnicoEngenhariaProcessoMateria.valorTamanhoNecessidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsLoteada", "ic_loteada", TecnicoEngenhariaProcessoMateria.isLoteada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualPerda", "pc_perda", TecnicoEngenhariaProcessoMateria.percentualPerda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IndiceMateria", "cd_indice_materia", TecnicoEngenhariaProcessoMateria.indiceMateria, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PosicaoDesenho", "cd_posicao_desenho", TecnicoEngenhariaProcessoMateria.posicaoDesenho, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoEngenhariaProcessoMateria.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoMateria(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "ERP.ProcessoMateria ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
