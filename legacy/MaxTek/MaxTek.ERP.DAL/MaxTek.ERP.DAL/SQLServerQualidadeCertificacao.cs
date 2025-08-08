using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerQualidadeCertificacao : IQualidadeCertificacao
{
	private MapTableQualidadeCertificacao MapearClasse(DataRow row)
	{
		MapTableQualidadeCertificacao result = default(MapTableQualidadeCertificacao);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.versao = BaseDadosERP.ObterDbValor<string>(row["versao"]);
			result.notaSistema = BaseDadosERP.ObterDbValor<int>(row["notaSistema"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_certificacao] as [nome], ");
		stringBuilder.Append("[nm_versao_certificacao] as [versao], ");
		stringBuilder.Append("[vl_nota_sistema] as [notaSistema]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[Certificacao] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableQualidadeCertificacao> ObterTodosQualidadeCertificacao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableQualidadeCertificacao> list = new List<MapTableQualidadeCertificacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableQualidadeCertificacao ObterQualidadeCertificacao(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableQualidadeCertificacao ObterQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", QualidadeCertificacao.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[Certificacao] (");
		stringBuilder.Append("nm_certificacao, ");
		stringBuilder.Append("nm_versao_certificacao, ");
		stringBuilder.Append("vl_nota_sistema) Values (@nm_certificacao,@nm_versao_certificacao,@vl_nota_sistema) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_certificacao", QualidadeCertificacao.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_versao_certificacao", QualidadeCertificacao.versao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_nota_sistema", QualidadeCertificacao.notaSistema));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[Certificacao] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_certificacao", QualidadeCertificacao.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Versao", "nm_versao_certificacao", QualidadeCertificacao.versao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NotaSistema", "vl_nota_sistema", QualidadeCertificacao.notaSistema, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", QualidadeCertificacao.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirQualidadeCertificacao(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[Certificacao] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
