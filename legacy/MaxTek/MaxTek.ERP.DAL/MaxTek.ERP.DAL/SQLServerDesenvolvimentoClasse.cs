using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerDesenvolvimentoClasse : IDesenvolvimentoClasse
{
	private MapTableDesenvolvimentoClasse MapearClasse(DataRow row)
	{
		MapTableDesenvolvimentoClasse result = default(MapTableDesenvolvimentoClasse);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.nomeBaseDados = BaseDadosERP.ObterDbValor<string>(row["nomeBaseDados"]);
			result.nomeEsquema = BaseDadosERP.ObterDbValor<string>(row["nomeEsquema"]);
			result.idEsquema = BaseDadosERP.ObterDbValor<int>(row["idEsquema"]);
			result.nomeClasse = BaseDadosERP.ObterDbValor<string>(row["nomeClasse"]);
			result.idTabela = BaseDadosERP.ObterDbValor<int>(row["idTabela"]);
			result.nomeTabela = BaseDadosERP.ObterDbValor<string>(row["nomeTabela"]);
			result.nomeTabelaPervasive = BaseDadosERP.ObterDbValor<string>(row["nomeTabelaPervasive"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_base_dados] as [nomeBaseDados], ");
		stringBuilder.Append("[nm_esquema] as [nomeEsquema], ");
		stringBuilder.Append("[id_schema] as [idEsquema], ");
		stringBuilder.Append("[nm_classe] as [nomeClasse], ");
		stringBuilder.Append("[id_tabela] as [idTabela], ");
		stringBuilder.Append("[nm_tabela] as [nomeTabela], ");
		stringBuilder.Append("[nm_tabela_pervasive] as [nomeTabelaPervasive]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[Classe] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableDesenvolvimentoClasse> ObterTodosDesenvolvimentoClasse()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableDesenvolvimentoClasse> list = new List<MapTableDesenvolvimentoClasse>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableDesenvolvimentoClasse ObterDesenvolvimentoClasse(int id)
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

	public MapTableDesenvolvimentoClasse ObterDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", DesenvolvimentoClasse.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[Classe] (");
		stringBuilder.Append("[nm_base_dados], ");
		stringBuilder.Append("[nm_esquema], ");
		stringBuilder.Append("[id_schema], ");
		stringBuilder.Append("[nm_classe], ");
		stringBuilder.Append("[id_tabela], ");
		stringBuilder.Append("[nm_tabela], ");
		stringBuilder.Append("[nm_tabela_pervasive]) Values (@nm_base_dados,@nm_esquema,@id_schema,@nm_classe,@id_tabela,@nm_tabela,@nm_tabela_pervasive) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_base_dados", DesenvolvimentoClasse.nomeBaseDados));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_esquema", DesenvolvimentoClasse.nomeEsquema));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_schema", DesenvolvimentoClasse.idEsquema));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_classe", DesenvolvimentoClasse.nomeClasse));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_tabela", DesenvolvimentoClasse.idTabela));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tabela", DesenvolvimentoClasse.nomeTabela));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tabela_pervasive", DesenvolvimentoClasse.nomeTabelaPervasive));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[Classe] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeBaseDados", "nm_base_dados", DesenvolvimentoClasse.nomeBaseDados, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeEsquema", "nm_esquema", DesenvolvimentoClasse.nomeEsquema, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdEsquema", "id_schema", DesenvolvimentoClasse.idEsquema, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeClasse", "nm_classe", DesenvolvimentoClasse.nomeClasse, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdTabela", "id_tabela", DesenvolvimentoClasse.idTabela, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTabela", "nm_tabela", DesenvolvimentoClasse.nomeTabela, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTabelaPervasive", "nm_tabela_pervasive", DesenvolvimentoClasse.nomeTabelaPervasive, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", DesenvolvimentoClasse.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirDesenvolvimentoClasse(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[Classe] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
