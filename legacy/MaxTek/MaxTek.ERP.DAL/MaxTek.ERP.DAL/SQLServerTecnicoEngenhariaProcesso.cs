using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProcesso : ITecnicoEngenhariaProcesso
{
	private MapTableTecnicoEngenhariaProcesso MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcesso result = default(MapTableTecnicoEngenhariaProcesso);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.isAtivo = BaseDadosERP.ObterDbValor<bool>(row["isAtivo"]);
			result.codigoTipoProcesso = BaseDadosERP.ObterDbValor<int>(row["codigoTipoProcesso"]);
			result.codigoProcesso = BaseDadosERP.ObterDbValor<string>(row["codigoProcesso"]);
			result.codigoProcessoRevisao = BaseDadosERP.ObterDbValor<int>(row["codigoProcessoRevisao"]);
			result.codigoDesenho = BaseDadosERP.ObterDbValor<string>(row["codigoDesenho"]);
			result.codigoDesenhoRevisao = BaseDadosERP.ObterDbValor<string>(row["codigoDesenhoRevisao"]);
			result.dataDesenho = BaseDadosERP.ObterDbValor<DateTime>(row["dataDesenho"]);
			result.codigoFamilia = BaseDadosERP.ObterDbValor<int>(row["codigoFamilia"]);
			result.codigoSubFamilia = BaseDadosERP.ObterDbValor<int>(row["codigoSubFamilia"]);
			result.imagem = BaseDadosERP.ObterDbValor<Image>(row["imagem"]);
			result.dataCriacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataCriacao"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoFuncionarioCriacao = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioCriacao"]);
			result.codigoFuncionarioModificacao = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioModificacao"]);
			result.codigoFuncionarioAprovacao = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioAprovacao"]);
			result.dataAprovacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAprovacao"]);
			result.isAprovado = BaseDadosERP.ObterDbValor<bool>(row["isAprovado"]);
			result.isPpap = BaseDadosERP.ObterDbValor<bool>(row["isPpap"]);
			result.dataAprocacaoPpap = BaseDadosERP.ObterDbValor<DateTime>(row["dataAprocacaoPpap"]);
			result.codigoPpap = BaseDadosERP.ObterDbValor<int>(row["codigoPpap"]);
			result.nomeCliente = BaseDadosERP.ObterDbValor<string>(row["nomeCliente"]);
			result.nomeUsuárioConectado = BaseDadosERP.ObterDbValor<string>(row["nomeUsuárioConectado"]);
			result.comentario = BaseDadosERP.ObterDbValor<string>(row["comentario"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[ic_ativo] as [isAtivo], ");
		stringBuilder.Append("[cd_tipo_processo] as [codigoTipoProcesso], ");
		stringBuilder.Append("[cd_processo] as [codigoProcesso], ");
		stringBuilder.Append("[cd_processo_revisao] as [codigoProcessoRevisao], ");
		stringBuilder.Append("[cd_desenho] as [codigoDesenho], ");
		stringBuilder.Append("[cd_desenho_revisao] as [codigoDesenhoRevisao], ");
		stringBuilder.Append("[dt_desenho] as [dataDesenho], ");
		stringBuilder.Append("[cd_familia] as [codigoFamilia], ");
		stringBuilder.Append("[cd_sub_familia] as [codigoSubFamilia], ");
		stringBuilder.Append("[im_desenho] as [imagem], ");
		stringBuilder.Append("[dt_criacao] as [dataCriacao], ");
		stringBuilder.Append("[dt_atualizacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_funcionario_criacao] as [codigoFuncionarioCriacao], ");
		stringBuilder.Append("[cd_funcionario_modificacao] as [codigoFuncionarioModificacao], ");
		stringBuilder.Append("[cd_funcionario_aprovacao] as [codigoFuncionarioAprovacao], ");
		stringBuilder.Append("[dt_aprovacao] as [dataAprovacao], ");
		stringBuilder.Append("[ic_aprovado] as [isAprovado], ");
		stringBuilder.Append("[ic_ppap] as [isPpap], ");
		stringBuilder.Append("[dt_aprovacao_ppap] as [dataAprocacaoPpap], ");
		stringBuilder.Append("[cd_ppap] as [codigoPpap], ");
		stringBuilder.Append("[nm_cliente] as [nomeCliente], ");
		stringBuilder.Append("[nm_usuario_conectado] as [nomeUsuárioConectado], ");
		stringBuilder.Append("[ds_comentario] as [comentario]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Processo] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcesso> ObterTodosTecnicoEngenhariaProcesso()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcesso> list = new List<MapTableTecnicoEngenhariaProcesso>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(int id)
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

	public MapTableTecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcesso.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Processo] (");
		stringBuilder.Append("[ic_ativo], ");
		stringBuilder.Append("[cd_tipo_processo], ");
		stringBuilder.Append("[cd_processo], ");
		stringBuilder.Append("[cd_processo_revisao], ");
		stringBuilder.Append("[cd_desenho], ");
		stringBuilder.Append("[cd_desenho_revisao], ");
		stringBuilder.Append("[dt_desenho], ");
		stringBuilder.Append("[cd_familia], ");
		stringBuilder.Append("[cd_sub_familia], ");
		stringBuilder.Append("[im_desenho], ");
		stringBuilder.Append("[dt_criacao], ");
		stringBuilder.Append("[dt_atualizacao], ");
		stringBuilder.Append("[cd_funcionario_criacao], ");
		stringBuilder.Append("[cd_funcionario_modificacao], ");
		stringBuilder.Append("[cd_funcionario_aprovacao], ");
		stringBuilder.Append("[dt_aprovacao], ");
		stringBuilder.Append("[ic_aprovado], ");
		stringBuilder.Append("[ic_ppap], ");
		stringBuilder.Append("[dt_aprovacao_ppap], ");
		stringBuilder.Append("[cd_ppap], ");
		stringBuilder.Append("[nm_cliente], ");
		stringBuilder.Append("[nm_usuario_conectado], ");
		stringBuilder.Append("[ds_comentario]) Values (@ic_ativo,@cd_tipo_processo,@cd_processo,@cd_processo_revisao,@cd_desenho,@cd_desenho_revisao,@dt_desenho,@cd_familia,@cd_sub_familia,@im_desenho,@dt_criacao,@dt_atualizacao,@cd_funcionario_criacao,@cd_funcionario_modificacao,@cd_funcionario_aprovacao,@dt_aprovacao,@ic_aprovado,@ic_ppap,@dt_aprovacao_ppap,@cd_ppap,@nm_cliente,@nm_usuario_conectado,@ds_comentario) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ativo", TecnicoEngenhariaProcesso.isAtivo));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_processo", TecnicoEngenhariaProcesso.codigoTipoProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_processo", TecnicoEngenhariaProcesso.codigoProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_processo_revisao", TecnicoEngenhariaProcesso.codigoProcessoRevisao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_desenho", TecnicoEngenhariaProcesso.codigoDesenho));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_desenho_revisao", TecnicoEngenhariaProcesso.codigoDesenhoRevisao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_desenho", TecnicoEngenhariaProcesso.dataDesenho));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_familia", TecnicoEngenhariaProcesso.codigoFamilia));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_sub_familia", TecnicoEngenhariaProcesso.codigoSubFamilia));
		list.Add(BaseDadosERP.ObterNovoParametro("@im_desenho", TecnicoEngenhariaProcesso.imagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_criacao", TecnicoEngenhariaProcesso.dataCriacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao", TecnicoEngenhariaProcesso.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_criacao", TecnicoEngenhariaProcesso.codigoFuncionarioCriacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_modificacao", TecnicoEngenhariaProcesso.codigoFuncionarioModificacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_aprovacao", TecnicoEngenhariaProcesso.codigoFuncionarioAprovacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_aprovacao", TecnicoEngenhariaProcesso.dataAprovacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_aprovado", TecnicoEngenhariaProcesso.isAprovado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ppap", TecnicoEngenhariaProcesso.isPpap));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_aprovacao_ppap", TecnicoEngenhariaProcesso.dataAprocacaoPpap));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ppap", TecnicoEngenhariaProcesso.codigoPpap));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cliente", TecnicoEngenhariaProcesso.nomeCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario_conectado", TecnicoEngenhariaProcesso.nomeUsuárioConectado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario", TecnicoEngenhariaProcesso.comentario));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Processo] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsAtivo", "ic_ativo", TecnicoEngenhariaProcesso.isAtivo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProcesso", "cd_tipo_processo", TecnicoEngenhariaProcesso.codigoTipoProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProcesso", "cd_processo", TecnicoEngenhariaProcesso.codigoProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProcessoRevisao", "cd_processo_revisao", TecnicoEngenhariaProcesso.codigoProcessoRevisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDesenho", "cd_desenho", TecnicoEngenhariaProcesso.codigoDesenho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDesenhoRevisao", "cd_desenho_revisao", TecnicoEngenhariaProcesso.codigoDesenhoRevisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataDesenho", "dt_desenho", TecnicoEngenhariaProcesso.dataDesenho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFamilia", "cd_familia", TecnicoEngenhariaProcesso.codigoFamilia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSubFamilia", "cd_sub_familia", TecnicoEngenhariaProcesso.codigoSubFamilia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_desenho", TecnicoEngenhariaProcesso.imagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCriacao", "dt_criacao", TecnicoEngenhariaProcesso.dataCriacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", TecnicoEngenhariaProcesso.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioCriacao", "cd_funcionario_criacao", TecnicoEngenhariaProcesso.codigoFuncionarioCriacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioModificacao", "cd_funcionario_modificacao", TecnicoEngenhariaProcesso.codigoFuncionarioModificacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioAprovacao", "cd_funcionario_aprovacao", TecnicoEngenhariaProcesso.codigoFuncionarioAprovacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAprovacao", "dt_aprovacao", TecnicoEngenhariaProcesso.dataAprovacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsAprovado", "ic_aprovado", TecnicoEngenhariaProcesso.isAprovado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPpap", "ic_ppap", TecnicoEngenhariaProcesso.isPpap, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAprocacaoPpap", "dt_aprovacao_ppap", TecnicoEngenhariaProcesso.dataAprocacaoPpap, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPpap", "cd_ppap", TecnicoEngenhariaProcesso.codigoPpap, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCliente", "nm_cliente", TecnicoEngenhariaProcesso.nomeCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUsuárioConectado", "nm_usuario_conectado", TecnicoEngenhariaProcesso.nomeUsuárioConectado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Comentario", "ds_comentario", TecnicoEngenhariaProcesso.comentario, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcesso.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcesso(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Processo] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
