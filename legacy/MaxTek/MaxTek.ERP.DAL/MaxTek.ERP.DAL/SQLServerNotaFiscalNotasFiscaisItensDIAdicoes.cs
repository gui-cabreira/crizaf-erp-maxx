using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalNotasFiscaisItensDIAdicoes : INotaFiscalNotasFiscaisItensDIAdicoes
{
	private MapTableNotaFiscalNotasFiscaisItensDIAdicoes MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItensDIAdicoes result = default(MapTableNotaFiscalNotasFiscaisItensDIAdicoes);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoSerieNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosERP.ObterDbValor<int>(row["ordem"]);
			result.numeroDI = BaseDadosERP.ObterDbValor<string>(row["numeroDI"]);
			result.numeroAdicao = BaseDadosERP.ObterDbValor<int>(row["numeroAdicao"]);
			result.numeroSequenciaAdicao = BaseDadosERP.ObterDbValor<int>(row["numeroSequenciaAdicao"]);
			result.codigoFabricante = BaseDadosERP.ObterDbValor<string>(row["codigoFabricante"]);
			result.valorDescontoDI = BaseDadosERP.ObterDbValor<decimal>(row["valorDescontoDI"]);
			result.codigoDrawBack = BaseDadosERP.ObterDbValor<string>(row["codigoDrawBack"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_serie_nf] as [codigoSerieNotaFiscal], ");
		stringBuilder.Append("[cd_nota_fiscal] as [codigoNotaFiscal], ");
		stringBuilder.Append("[vl_ordem] as [ordem], ");
		stringBuilder.Append("[nDi] as [numeroDI], ");
		stringBuilder.Append("[nAdicao] as [numeroAdicao], ");
		stringBuilder.Append("[nSeqAdic] as [numeroSequenciaAdicao], ");
		stringBuilder.Append("[cFabricante] as [codigoFabricante], ");
		stringBuilder.Append("[vDescDI] as [valorDescontoDI], ");
		stringBuilder.Append("[nDraw] as [codigoDrawBack]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisItensDIAdicoes] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> list = new List<MapTableNotaFiscalNotasFiscaisItensDIAdicoes>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", numeroDI));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> list2 = new List<MapTableNotaFiscalNotasFiscaisItensDIAdicoes>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi and");
		stringBuilder.Append(" [nAdicao] = @nAdicao");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", numeroDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@nAdicao", numeroAdicao));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi and");
		stringBuilder.Append(" [nAdicao] = @nAdicao");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDIAdicoes.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Insert into [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDIAdicoes] (", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_serie_nf], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[vl_ordem], ");
		stringBuilder.Append("[nDi], ");
		stringBuilder.Append("[nAdicao], ");
		stringBuilder.Append("[nSeqAdic], ");
		stringBuilder.Append("[cFabricante], ");
		stringBuilder.Append("[vDescDI], ");
		stringBuilder.Append("[nDraw]) Values (@cd_empresa,@cd_serie_nf,@cd_nota_fiscal,@vl_ordem,@nDi,@nAdicao,@nSeqAdic,@cFabricante,@vDescDI,@nDraw) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDIAdicoes.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nSeqAdic", NotaFiscalNotasFiscaisItensDIAdicoes.numeroSequenciaAdicao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cFabricante", NotaFiscalNotasFiscaisItensDIAdicoes.codigoFabricante));
		list.Add(BaseDadosERP.ObterNovoParametro("@vDescDI", NotaFiscalNotasFiscaisItensDIAdicoes.valorDescontoDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDraw", NotaFiscalNotasFiscaisItensDIAdicoes.codigoDrawBack));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Update [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDIAdicoes] Set ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroSequenciaAdicao", "nSeqAdic", NotaFiscalNotasFiscaisItensDIAdicoes.numeroSequenciaAdicao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFabricante", "cFabricante", NotaFiscalNotasFiscaisItensDIAdicoes.codigoFabricante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDescontoDI", "vDescDI", NotaFiscalNotasFiscaisItensDIAdicoes.valorDescontoDI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDrawBack", "nDraw", NotaFiscalNotasFiscaisItensDIAdicoes.codigoDrawBack, camposAlterados));
			bool flag = false;
			foreach (DbParameter item in list)
			{
				if (item != null && item.Value != null)
				{
					flag = true;
				}
			}
			if (flag)
			{
				stringBuilder.Append(" Where ");
				stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
				stringBuilder.Append("cd_serie_nf = @cd_serie_nf and ");
				stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
				stringBuilder.Append("vl_ordem = @vl_ordem and ");
				stringBuilder.Append("nDi = @nDi and ");
				stringBuilder.Append("nAdicao = @nAdicao");
				list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDIAdicoes.codigoEmpresa));
				list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
				list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
				list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
				list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
				list.Add(BaseDadosERP.ObterNovoParametro("@nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
			}
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDIAdicoes] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi and");
		stringBuilder.Append(" [nAdicao] = @nAdicao");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", numeroDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@nAdicao", numeroAdicao));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDIAdicoes] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
