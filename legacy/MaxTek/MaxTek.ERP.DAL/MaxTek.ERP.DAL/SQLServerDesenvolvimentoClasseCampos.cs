using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerDesenvolvimentoClasseCampos : IDesenvolvimentoClasseCampos
{
	private MapTableDesenvolvimentoClasseCampos MapearClasse(DataRow row)
	{
		MapTableDesenvolvimentoClasseCampos result = default(MapTableDesenvolvimentoClasseCampos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.idClasse = BaseDadosERP.ObterDbValor<int>(row["idClasse"]);
			result.idCampo = BaseDadosERP.ObterDbValor<int>(row["idCampo"]);
			result.nomeCampo = BaseDadosERP.ObterDbValor<string>(row["nomeCampo"]);
			result.nomeCampoPervasive = BaseDadosERP.ObterDbValor<string>(row["nomeCampoPervasive"]);
			result.idTipoDado = BaseDadosERP.ObterDbValor<int>(row["idTipoDado"]);
			result.nomeTipoDado = BaseDadosERP.ObterDbValor<string>(row["nomeTipoDado"]);
			result.numeroCasas = BaseDadosERP.ObterDbValor<int>(row["numeroCasas"]);
			result.nomeTipoCampo = BaseDadosERP.ObterDbValor<string>(row["nomeTipoCampo"]);
			result.nomeCampoClasse = BaseDadosERP.ObterDbValor<string>(row["nomeCampoClasse"]);
			result.nomePropriedade = BaseDadosERP.ObterDbValor<string>(row["nomePropriedade"]);
			result.isPk = BaseDadosERP.ObterDbValor<bool>(row["isPk"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[id_classe] as [idClasse], ");
		stringBuilder.Append("[id_campo] as [idCampo], ");
		stringBuilder.Append("[nm_campo] as [nomeCampo], ");
		stringBuilder.Append("[nm_campo_pervasive] as [nomeCampoPervasive], ");
		stringBuilder.Append("[id_tipo_dado] as [idTipoDado], ");
		stringBuilder.Append("[nm_tipo_dado] as [nomeTipoDado], ");
		stringBuilder.Append("[vl_casas] as [numeroCasas], ");
		stringBuilder.Append("[nm_tipo_dado_classe] as [nomeTipoCampo], ");
		stringBuilder.Append("[nm_classe_campo] as [nomeCampoClasse], ");
		stringBuilder.Append("[nm_classe_propriedade] as [nomePropriedade], ");
		stringBuilder.Append("[ic_pk] as [isPk]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[ClasseCampos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableDesenvolvimentoClasseCampos> ObterTodosDesenvolvimentoClasseCampos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableDesenvolvimentoClasseCampos> list = new List<MapTableDesenvolvimentoClasseCampos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableDesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(int id)
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

	public MapTableDesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", DesenvolvimentoClasseCampos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[ClasseCampos] (");
		stringBuilder.Append("[id_classe], ");
		stringBuilder.Append("[id_campo], ");
		stringBuilder.Append("[nm_campo], ");
		stringBuilder.Append("[nm_campo_pervasive], ");
		stringBuilder.Append("[id_tipo_dado], ");
		stringBuilder.Append("[nm_tipo_dado], ");
		stringBuilder.Append("[vl_casas], ");
		stringBuilder.Append("[nm_tipo_dado_classe], ");
		stringBuilder.Append("[nm_classe_campo], ");
		stringBuilder.Append("[nm_classe_propriedade], ");
		stringBuilder.Append("[ic_pk]) Values (@id_classe,@id_campo,@nm_campo,@nm_campo_pervasive,@id_tipo_dado,@nm_tipo_dado,@vl_casas,@nm_tipo_dado_classe,@nm_classe_campo,@nm_classe_propriedade,@ic_pk) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_classe", DesenvolvimentoClasseCampos.idClasse));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_campo", DesenvolvimentoClasseCampos.idCampo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_campo", DesenvolvimentoClasseCampos.nomeCampo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_campo_pervasive", DesenvolvimentoClasseCampos.nomeCampoPervasive));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_tipo_dado", DesenvolvimentoClasseCampos.idTipoDado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_dado", DesenvolvimentoClasseCampos.nomeTipoDado));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_casas", DesenvolvimentoClasseCampos.numeroCasas));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_dado_classe", DesenvolvimentoClasseCampos.nomeTipoCampo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_classe_campo", DesenvolvimentoClasseCampos.nomeCampoClasse));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_classe_propriedade", DesenvolvimentoClasseCampos.nomePropriedade));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_pk", DesenvolvimentoClasseCampos.isPk));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[ClasseCampos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdClasse", "id_classe", DesenvolvimentoClasseCampos.idClasse, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdCampo", "id_campo", DesenvolvimentoClasseCampos.idCampo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampo", "nm_campo", DesenvolvimentoClasseCampos.nomeCampo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampoPervasive", "nm_campo_pervasive", DesenvolvimentoClasseCampos.nomeCampoPervasive, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdTipoDado", "id_tipo_dado", DesenvolvimentoClasseCampos.idTipoDado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTipoDado", "nm_tipo_dado", DesenvolvimentoClasseCampos.nomeTipoDado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroCasas", "vl_casas", DesenvolvimentoClasseCampos.numeroCasas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTipoCampo", "nm_tipo_dado_classe", DesenvolvimentoClasseCampos.nomeTipoCampo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampoClasse", "nm_classe_campo", DesenvolvimentoClasseCampos.nomeCampoClasse, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomePropriedade", "nm_classe_propriedade", DesenvolvimentoClasseCampos.nomePropriedade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPk", "ic_pk", DesenvolvimentoClasseCampos.isPk, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", DesenvolvimentoClasseCampos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirDesenvolvimentoClasseCampos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Desenvolvimento].[ClasseCampos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
