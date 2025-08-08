using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveQualidadeCertificacao : IQualidadeCertificacao
{
	private MapTableQualidadeCertificacao MapearClasse(DataRow row)
	{
		MapTableQualidadeCertificacao result = default(MapTableQualidadeCertificacao);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.versao = BaseDadosGPS.ObterDbValor<string>(row["versao"]);
			result.notaSistema = BaseDadosGPS.ObterDbValor<int>(row["notaSistema"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("nm_certificacao as nome, ");
		stringBuilder.Append("nm_versao as versao, ");
		stringBuilder.Append("vl_nota_sistema as notaSistema");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.CertificacaoQualid ");
		return stringBuilder.ToString();
	}

	public IList<MapTableQualidadeCertificacao> ObterTodosQualidadeCertificacao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableQualidadeCertificacao ObterQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", QualidadeCertificacao.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.CertificacaoQualid (");
		stringBuilder.Append("nm_certificacao, ");
		stringBuilder.Append("nm_versao, ");
		stringBuilder.Append("vl_nota_sistema) Values (?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_certificacao", QualidadeCertificacao.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_versao", QualidadeCertificacao.versao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_nota_sistema", QualidadeCertificacao.notaSistema));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.CertificacaoQualid Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_certificacao", QualidadeCertificacao.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Versao", "nm_versao", QualidadeCertificacao.versao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NotaSistema", "vl_nota_sistema", QualidadeCertificacao.notaSistema, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", QualidadeCertificacao.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirQualidadeCertificacao(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.CertificacaoQualid ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
