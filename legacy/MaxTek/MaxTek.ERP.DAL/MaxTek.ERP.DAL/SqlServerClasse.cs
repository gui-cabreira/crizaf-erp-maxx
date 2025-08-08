using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SqlServerClasse : IClasse
{
	private static MapTableClasse MapearClasses(DataRow row)
	{
		MapTableClasse result = default(MapTableClasse);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.bancoDados = BaseDadosERP.ObterDbValor<string>(row["bancoDados"]);
			result.nomeClasse = BaseDadosERP.ObterDbValor<string>(row["nomeClasse"]);
			result.nomeEsquema = BaseDadosERP.ObterDbValor<string>(row["nomeEsquema"]);
			result.nomeTabela = BaseDadosERP.ObterDbValor<string>(row["nomeTabela"]);
			result.nomeTabelaPervasive = BaseDadosERP.ObterDbValor<string>(row["nomeTabelaPervasive"]);
			result.nomeCampoDados = BaseDadosERP.ObterDbValor<string>(row["nomeCampoDados"]);
			result.nomeCampoDadosPervasive = BaseDadosERP.ObterDbValor<string>(row["nomeCampoDadosPervasive"]);
			result.tipoDadoBanco = BaseDadosERP.ObterDbValor<string>(row["tipoDadoBanco"]);
			result.quantidadeCaracteres = BaseDadosERP.ObterDbValor<int>(row["quantidadeCaracteres"]);
			result.tipoDado = BaseDadosERP.ObterDbValor<string>(row["tipoDado"]);
			result.nomeCampo = BaseDadosERP.ObterDbValor<string>(row["nomeCampo"]);
			result.nomePropriedade = BaseDadosERP.ObterDbValor<string>(row["nomePropriedade"]);
			result.isChavePrimaria = BaseDadosERP.ObterDbValor<bool>(row["isChavePrimaria"]);
			result.isDesconsidera = BaseDadosERP.ObterDbValor<bool>(row["isDesconsidera"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id], ");
		stringBuilder.Append("[nm_banco_dados] as [bancoDados], ");
		stringBuilder.Append("[nm_classe] as [nomeClasse], ");
		stringBuilder.Append("[nm_esquema] as [nomeEsquema], ");
		stringBuilder.Append("[nm_tabela] as [nomeTabela], ");
		stringBuilder.Append("[nm_tabela_pervasive] as [nomeTabelaPervasive], ");
		stringBuilder.Append("[nm_campo_dados] as [nomeCampoDados], ");
		stringBuilder.Append("[nm_campo_pervasive] as [nomeCampoDadosPervasive], ");
		stringBuilder.Append("[nm_tipo_dado_banco] as [tipoDadoBanco], ");
		stringBuilder.Append("[vl_casas] as [quantidadeCaracteres], ");
		stringBuilder.Append("[nm_tipo_dado] as [tipoDado], ");
		stringBuilder.Append("[nm_campo] as [nomeCampo], ");
		stringBuilder.Append("[nm_propriedade] as [nomePropriedade], ");
		stringBuilder.Append("[ic_pk] as [isChavePrimaria], ");
		stringBuilder.Append("[ic_desconsidera] as [isDesconsidera] ");
		stringBuilder.Append("from [SistemaClasse] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableClasse> ObterClasse(string nomeServidor, string bancoDados, string nomeEsquema, string nomeTabela)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [nm_banco_dados] = @nm_banco_dados");
		stringBuilder.Append(" and [nm_esquema] = @nm_esquema");
		stringBuilder.Append(" and [nm_tabela] = @nm_tabela");
		stringBuilder.Append(" order by [id]");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_banco_dados", bancoDados));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_esquema", nomeEsquema));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tabela", nomeTabela));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableClasse> list2 = new List<MapTableClasse>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasses(row));
		}
		return list2;
	}

	public int Alterar(MapTableClasse classe, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update SistemaClasse set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "BancoDados", "nm_banco_dados", classe.bancoDados, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeClasse", "nm_classe", classe.nomeClasse, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeEsquema", "nm_esquema", classe.nomeEsquema, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTabela", "nm_tabela", classe.nomeTabela, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeTabelaPervasive", "nm_tabela_pervasive", classe.nomeTabelaPervasive, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampoDados", "nm_campo_dados", classe.nomeCampoDados, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampoDadosPervasive", "nm_campo_pervasive", classe.nomeCampoDadosPervasive, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoDadoBanco", "nm_tipo_dado_banco", classe.tipoDadoBanco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeCaracteres", "vl_casas", classe.quantidadeCaracteres, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoDado", "nm_tipo_dado", classe.tipoDado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCampo", "nm_campo", classe.nomeCampo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomePropriedade", "nm_propriedade", classe.nomePropriedade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsChavePrimaria", "ic_pk", classe.isChavePrimaria, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsDesconsidera", "ic_desconsidera", classe.isDesconsidera, camposAlterados));
			stringBuilder.Append(" where [id] = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", classe.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int Inserir(MapTableClasse classe)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [SistemaClasse] (");
		stringBuilder.Append("[nm_banco_dados], ");
		stringBuilder.Append("[nm_classe], ");
		stringBuilder.Append("[nm_esquema], ");
		stringBuilder.Append("[nm_tabela], ");
		stringBuilder.Append("[nm_tabela_pervasive], ");
		stringBuilder.Append("[nm_campo_dados], ");
		stringBuilder.Append("[nm_campo_pervasive], ");
		stringBuilder.Append("[nm_tipo_dado_banco], ");
		stringBuilder.Append("[vl_casas], ");
		stringBuilder.Append("[nm_tipo_dado], ");
		stringBuilder.Append("[nm_campo], ");
		stringBuilder.Append("[nm_propriedade], ");
		stringBuilder.Append("[ic_pk], ");
		stringBuilder.Append("[ic_desconsidera]) ");
		stringBuilder.Append("values (@nm_banco_dados,@nm_classe,@nm_esquema,@nm_tabela,@nm_tabela_pervasive,@nm_campo_dados,@nm_campo_pervasive,@nm_tipo_dado_banco,@vl_casas,@nm_tipo_dado,@nm_campo,@nm_propriedade,@ic_pk,@ic_desconsidera) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_banco_dados", classe.bancoDados));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_classe", classe.nomeClasse));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_esquema", classe.nomeEsquema));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tabela", classe.nomeTabela));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tabela_pervasive", classe.nomeTabelaPervasive));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_campo_dados", classe.nomeCampoDados));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_campo_pervasive", classe.nomeCampoDadosPervasive));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_dado_banco", classe.tipoDadoBanco));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_casas", classe.quantidadeCaracteres));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_dado", classe.tipoDado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_campo", classe.nomeCampo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_propriedade", classe.nomePropriedade));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_pk", classe.isChavePrimaria));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_desconsidera", classe.isDesconsidera));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public void Excluir(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [SistemaClasse] ");
		stringBuilder.Append("where [nm_esquema] = " + BaseDadosERP.Escape(nomeEsquema));
		stringBuilder.Append(" and [nm_tabela] = " + BaseDadosERP.Escape(nomeTabela));
		BaseDadosERP.Insert(stringBuilder.ToString());
	}
}
