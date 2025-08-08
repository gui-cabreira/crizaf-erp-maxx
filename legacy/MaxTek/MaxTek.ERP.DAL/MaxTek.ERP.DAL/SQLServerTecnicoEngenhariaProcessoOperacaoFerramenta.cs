using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProcessoOperacaoFerramenta : ITecnicoEngenhariaProcessoOperacaoFerramenta
{
	private MapTableTecnicoEngenhariaProcessoOperacaoFerramenta MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoOperacaoFerramenta result = default(MapTableTecnicoEngenhariaProcessoOperacaoFerramenta);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.idProcessoOperacao = BaseDadosERP.ObterDbValor<int>(row["idProcessoOperacao"]);
			result.idFerramenta = BaseDadosERP.ObterDbValor<int>(row["idFerramenta"]);
			result.codigoTipoFerramenta = BaseDadosERP.ObterDbValor<int>(row["codigoTipoFerramenta"]);
			result.necessidade = BaseDadosERP.ObterDbValor<decimal>(row["necessidade"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[id_processo_operacao] as [idProcessoOperacao], ");
		stringBuilder.Append("[id_ferramenta] as [idFerramenta], ");
		stringBuilder.Append("[cd_tipo_ferramenta] as [codigoTipoFerramenta], ");
		stringBuilder.Append("[vl_necessidade] as [necessidade]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacaoFerramenta] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta> ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta> list = new List<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta> ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta(int idOperacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_operacao] = @id_operacao");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_operacao", idOperacao));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta> list2 = new List<MapTableTecnicoEngenhariaProcessoOperacaoFerramenta>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProcessoOperacaoFerramenta ObterTecnicoEngenhariaProcessoOperacaoFerramenta(int id)
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

	public MapTableTecnicoEngenhariaProcessoOperacaoFerramenta ObterTecnicoEngenhariaProcessoOperacaoFerramenta(MapTableTecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramenta)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoOperacaoFerramenta.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoOperacaoFerramenta(MapTableTecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramenta)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacaoFerramenta] (");
		stringBuilder.Append("[id_processo_operacao], ");
		stringBuilder.Append("[id_ferramenta], ");
		stringBuilder.Append("[cd_tipo_ferramenta], ");
		stringBuilder.Append("[vl_necessidade]) Values (@id_processo_operacao,@id_ferramenta,@cd_tipo_ferramenta,@vl_necessidade) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_processo_operacao", TecnicoEngenhariaProcessoOperacaoFerramenta.idProcessoOperacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_ferramenta", TecnicoEngenhariaProcessoOperacaoFerramenta.idFerramenta));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_ferramenta", TecnicoEngenhariaProcessoOperacaoFerramenta.codigoTipoFerramenta));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_necessidade", TecnicoEngenhariaProcessoOperacaoFerramenta.necessidade));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoOperacaoFerramenta(MapTableTecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramenta, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacaoFerramenta] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcessoOperacao", "id_processo_operacao", TecnicoEngenhariaProcessoOperacaoFerramenta.idProcessoOperacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdFerramenta", "id_ferramenta", TecnicoEngenhariaProcessoOperacaoFerramenta.idFerramenta, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoFerramenta", "cd_tipo_ferramenta", TecnicoEngenhariaProcessoOperacaoFerramenta.codigoTipoFerramenta, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Necessidade", "vl_necessidade", TecnicoEngenhariaProcessoOperacaoFerramenta.necessidade, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoOperacaoFerramenta.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoOperacaoFerramenta(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacaoFerramenta] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
