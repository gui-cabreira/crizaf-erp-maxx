using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProcessoControle : ITecnicoEngenhariaProcessoControle
{
	private MapTableTecnicoEngenhariaProcessoControle MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoControle result = default(MapTableTecnicoEngenhariaProcessoControle);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoProcessoControle = BaseDadosGPS.ObterDbValor<string>(row["codigoProcessoControle"]);
			result.descricaoProcessoControle = BaseDadosGPS.ObterDbValor<string>(row["descricaoProcessoControle"]);
			result.desenho = BaseDadosGPS.ObterDbValor<string>(row["desenho"]);
			result.revisao = BaseDadosGPS.ObterDbValor<string>(row["revisao"]);
			result.imagem = BaseDadosGPS.ObterDbValor<Image>(row["imagem"]);
			result.dataCadastro = BaseDadosGPS.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoUsuario = BaseDadosGPS.ObterDbValor<int>(row["codigoUsuario"]);
			result.comentario = BaseDadosGPS.ObterDbValor<string>(row["comentario"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_processo_controle as codigoProcessoControle, ");
		stringBuilder.Append("ds_processo_controle as descricaoProcessoControle, ");
		stringBuilder.Append("cd_desenho as desenho, ");
		stringBuilder.Append("cd_revisao_desenho as revisao, ");
		stringBuilder.Append("im_processo_controle as imagem, ");
		stringBuilder.Append("dt_cadastro as dataCadastro, ");
		stringBuilder.Append("dt_atualizacao as dataAtualizacao, ");
		stringBuilder.Append("cd_usuario as codigoUsuario, ");
		stringBuilder.Append("ds_comentario as comentario");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProcessoControle ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoControle> ObterTodosTecnicoEngenhariaProcessoControle()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoControle> list = new List<MapTableTecnicoEngenhariaProcessoControle>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProcessoControle ObterTecnicoEngenhariaProcessoControle(int id)
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

	public MapTableTecnicoEngenhariaProcessoControle ObterTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProcessoControle.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProcessoControle (");
		stringBuilder.Append("cd_processo_controle, ");
		stringBuilder.Append("ds_processo_controle, ");
		stringBuilder.Append("cd_desenho, ");
		stringBuilder.Append("cd_revisao_desenho, ");
		stringBuilder.Append("im_processo_controle, ");
		stringBuilder.Append("dt_cadastro, ");
		stringBuilder.Append("dt_atualizacao, ");
		stringBuilder.Append("cd_usuario, ");
		stringBuilder.Append("ds_comentario) Values (?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_processo_controle", TecnicoEngenhariaProcessoControle.codigoProcessoControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_processo_controle", TecnicoEngenhariaProcessoControle.descricaoProcessoControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_desenho", TecnicoEngenhariaProcessoControle.desenho));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_revisao_desenho", TecnicoEngenhariaProcessoControle.revisao));
		list.Add(BaseDadosGPS.ObterNovoParametro("im_processo_controle", TecnicoEngenhariaProcessoControle.imagem));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_cadastro", TecnicoEngenhariaProcessoControle.dataCadastro));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_atualizacao", TecnicoEngenhariaProcessoControle.dataAtualizacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_usuario", TecnicoEngenhariaProcessoControle.codigoUsuario));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_comentario", TecnicoEngenhariaProcessoControle.comentario));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProcessoControle Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProcessoControle", "cd_processo_controle", TecnicoEngenhariaProcessoControle.codigoProcessoControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoProcessoControle", "ds_processo_controle", TecnicoEngenhariaProcessoControle.descricaoProcessoControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Desenho", "cd_desenho", TecnicoEngenhariaProcessoControle.desenho, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Revisao", "cd_revisao_desenho", TecnicoEngenhariaProcessoControle.revisao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_processo_controle", TecnicoEngenhariaProcessoControle.imagem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", TecnicoEngenhariaProcessoControle.dataCadastro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", TecnicoEngenhariaProcessoControle.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoUsuario", "cd_usuario", TecnicoEngenhariaProcessoControle.codigoUsuario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Comentario", "ds_comentario", TecnicoEngenhariaProcessoControle.comentario, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProcessoControle.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoControle(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProcessoControle ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
