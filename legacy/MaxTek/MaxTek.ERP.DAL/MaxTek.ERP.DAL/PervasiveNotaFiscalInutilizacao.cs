using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalInutilizacao : INotaFiscalInutilizacao
{
	private MapTableNotaFiscalInutilizacao MapearClasse(DataRow row)
	{
		MapTableNotaFiscalInutilizacao result = default(MapTableNotaFiscalInutilizacao);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoModelo = BaseDadosGPS.ObterDbValor<int>(row["codigoModelo"]);
			result.codigoSerie = BaseDadosGPS.ObterDbValor<int>(row["codigoSerie"]);
			result.ano = BaseDadosGPS.ObterDbValor<int>(row["ano"]);
			result.notaInicial = BaseDadosGPS.ObterDbValor<int>(row["notaInicial"]);
			result.notaFinal = BaseDadosGPS.ObterDbValor<int>(row["notaFinal"]);
			result.codigoStatus = BaseDadosGPS.ObterDbValor<int>(row["codigoStatus"]);
			result.status = BaseDadosGPS.ObterDbValor<string>(row["status"]);
			result.dataRecibo = BaseDadosGPS.ObterDbValor<DateTime>(row["dataRecibo"]);
			result.protocolo = BaseDadosGPS.ObterDbValor<string>(row["protocolo"]);
			result.usuario = BaseDadosGPS.ObterDbValor<string>(row["usuario"]);
			result.justificativa = BaseDadosGPS.ObterDbValor<string>(row["justificativa"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("Id as id, ");
		stringBuilder.Append("cd_modelo as codigoModelo, ");
		stringBuilder.Append("cd_serie as codigoSerie, ");
		stringBuilder.Append("ano as ano, ");
		stringBuilder.Append("cd_nota_inicial as notaInicial, ");
		stringBuilder.Append("cd_nota_final as notaFinal, ");
		stringBuilder.Append("cd_status as codigoStatus, ");
		stringBuilder.Append("ds_status as status, ");
		stringBuilder.Append("dt_recibo as dataRecibo, ");
		stringBuilder.Append("nm_protocolo as protocolo, ");
		stringBuilder.Append("nm_usuario as usuario, ");
		stringBuilder.Append("ds_justificativa as justificativa");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NFInutilizacao ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalInutilizacao> list = new List<MapTableNotaFiscalInutilizacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" Id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("Id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" Id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("Id", NotaFiscalInutilizacao.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NFInutilizacao (");
		stringBuilder.Append("Id, ");
		stringBuilder.Append("cd_modelo, ");
		stringBuilder.Append("cd_serie, ");
		stringBuilder.Append("ano, ");
		stringBuilder.Append("cd_nota_inicial, ");
		stringBuilder.Append("cd_nota_final, ");
		stringBuilder.Append("cd_status, ");
		stringBuilder.Append("ds_status, ");
		stringBuilder.Append("dt_recibo, ");
		stringBuilder.Append("nm_protocolo, ");
		stringBuilder.Append("nm_usuario, ");
		stringBuilder.Append("ds_justificativa) Values (?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("Id", NotaFiscalInutilizacao.id));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_modelo", NotaFiscalInutilizacao.codigoModelo));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", NotaFiscalInutilizacao.codigoSerie));
		list.Add(BaseDadosGPS.ObterNovoParametro("ano", NotaFiscalInutilizacao.ano));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_inicial", NotaFiscalInutilizacao.notaInicial));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_final", NotaFiscalInutilizacao.notaFinal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_status", NotaFiscalInutilizacao.codigoStatus));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_status", NotaFiscalInutilizacao.status));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_recibo", NotaFiscalInutilizacao.dataRecibo));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_protocolo", NotaFiscalInutilizacao.protocolo));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_usuario", NotaFiscalInutilizacao.usuario));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_justificativa", NotaFiscalInutilizacao.justificativa));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NFInutilizacao Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoModelo", "cd_modelo", NotaFiscalInutilizacao.codigoModelo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoSerie", "cd_serie", NotaFiscalInutilizacao.codigoSerie, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Ano", "ano", NotaFiscalInutilizacao.ano, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NotaInicial", "cd_nota_inicial", NotaFiscalInutilizacao.notaInicial, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NotaFinal", "cd_nota_final", NotaFiscalInutilizacao.notaFinal, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoStatus", "cd_status", NotaFiscalInutilizacao.codigoStatus, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Status", "ds_status", NotaFiscalInutilizacao.status, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataRecibo", "dt_recibo", NotaFiscalInutilizacao.dataRecibo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Protocolo", "nm_protocolo", NotaFiscalInutilizacao.protocolo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Usuario", "nm_usuario", NotaFiscalInutilizacao.usuario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Justificativa", "ds_justificativa", NotaFiscalInutilizacao.justificativa, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("Id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("Id", NotaFiscalInutilizacao.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalInutilizacao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NFInutilizacao ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" Id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("Id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao(int codigoEmpresa)
	{
		throw new NotImplementedException();
	}
}
