using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProcessoControle : ITecnicoEngenhariaProcessoControle
{
	private MapTableTecnicoEngenhariaProcessoControle MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoControle result = default(MapTableTecnicoEngenhariaProcessoControle);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoProcessoControle = BaseDadosERP.ObterDbValor<string>(row["codigoProcessoControle"]);
			result.descricaoProcessoControle = BaseDadosERP.ObterDbValor<string>(row["descricaoProcessoControle"]);
			result.desenho = BaseDadosERP.ObterDbValor<string>(row["desenho"]);
			result.revisao = BaseDadosERP.ObterDbValor<string>(row["revisao"]);
			result.imagem = BaseDadosERP.ObterDbValor<Image>(row["imagem"]);
			result.dataCadastro = BaseDadosERP.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoUsuario = BaseDadosERP.ObterDbValor<int>(row["codigoUsuario"]);
			result.comentario = BaseDadosERP.ObterDbValor<string>(row["comentario"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_processo_controle] as [codigoProcessoControle], ");
		stringBuilder.Append("[ds_processo_controle] as [descricaoProcessoControle], ");
		stringBuilder.Append("[cd_desenho] as [desenho], ");
		stringBuilder.Append("[cd_revisao_desenho] as [revisao], ");
		stringBuilder.Append("[im_processo_controle] as [imagem], ");
		stringBuilder.Append("[dt_cadastro] as [dataCadastro], ");
		stringBuilder.Append("[dt_atualizacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_usuario] as [codigoUsuario], ");
		stringBuilder.Append("[ds_comentario] as [comentario]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoControle] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoControle> ObterTodosTecnicoEngenhariaProcessoControle()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProcessoControle ObterTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoControle.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoControle] (");
		stringBuilder.Append("[cd_processo_controle], ");
		stringBuilder.Append("[ds_processo_controle], ");
		stringBuilder.Append("[cd_desenho], ");
		stringBuilder.Append("[cd_revisao_desenho], ");
		stringBuilder.Append("[im_processo_controle], ");
		stringBuilder.Append("[dt_cadastro], ");
		stringBuilder.Append("[dt_atualizacao], ");
		stringBuilder.Append("[cd_usuario], ");
		stringBuilder.Append("[ds_comentario]) Values (@cd_processo_controle,@ds_processo_controle,@cd_desenho,@cd_revisao_desenho,@im_processo_controle,@dt_cadastro,@dt_atualizacao,@cd_usuario,@ds_comentario) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_processo_controle", TecnicoEngenhariaProcessoControle.codigoProcessoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_processo_controle", TecnicoEngenhariaProcessoControle.descricaoProcessoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_desenho", TecnicoEngenhariaProcessoControle.desenho));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_revisao_desenho", TecnicoEngenhariaProcessoControle.revisao));
		list.Add(BaseDadosERP.ObterNovoParametro("@im_processo_controle", TecnicoEngenhariaProcessoControle.imagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cadastro", TecnicoEngenhariaProcessoControle.dataCadastro));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao", TecnicoEngenhariaProcessoControle.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_usuario", TecnicoEngenhariaProcessoControle.codigoUsuario));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario", TecnicoEngenhariaProcessoControle.comentario));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoControle(MapTableTecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControle, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoControle] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProcessoControle", "cd_processo_controle", TecnicoEngenhariaProcessoControle.codigoProcessoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoProcessoControle", "ds_processo_controle", TecnicoEngenhariaProcessoControle.descricaoProcessoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Desenho", "cd_desenho", TecnicoEngenhariaProcessoControle.desenho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Revisao", "cd_revisao_desenho", TecnicoEngenhariaProcessoControle.revisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_processo_controle", TecnicoEngenhariaProcessoControle.imagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", TecnicoEngenhariaProcessoControle.dataCadastro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", TecnicoEngenhariaProcessoControle.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUsuario", "cd_usuario", TecnicoEngenhariaProcessoControle.codigoUsuario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Comentario", "ds_comentario", TecnicoEngenhariaProcessoControle.comentario, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoControle.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoControle(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoControle] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
