using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialFiscalClassificacaoFiscal : IComercialFiscalClassificacaoFiscal
{
	private MapTableComercialFiscalClassificacaoFiscal MapearClasse(DataRow row)
	{
		MapTableComercialFiscalClassificacaoFiscal result = default(MapTableComercialFiscalClassificacaoFiscal);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.classificacaiFiscal = BaseDadosERP.ObterDbValor<string>(row["classificacaiFiscal"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.valorIpi = BaseDadosERP.ObterDbValor<decimal>(row["valorIpi"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_classificacao_fiscal] as [classificacaiFiscal], ");
		stringBuilder.Append("[ds_classificacao_fiscal] as [descricao], ");
		stringBuilder.Append("[vl_ipi] as [valorIpi]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalClassificacaoFiscal] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFiscalClassificacaoFiscal> ObterTodosComercialFiscalClassificacaoFiscal()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFiscalClassificacaoFiscal> list = new List<MapTableComercialFiscalClassificacaoFiscal>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFiscalClassificacaoFiscal ObterComercialFiscalClassificacaoFiscal(int id)
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

	public MapTableComercialFiscalClassificacaoFiscal ObterComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFiscalClassificacaoFiscal.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalClassificacaoFiscal] (");
		stringBuilder.Append("[nm_classificacao_fiscal], ");
		stringBuilder.Append("[ds_classificacao_fiscal], ");
		stringBuilder.Append("[vl_ipi]) Values (@nm_classificacao_fiscal,@ds_classificacao_fiscal,@vl_ipi) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_classificacao_fiscal", ComercialFiscalClassificacaoFiscal.classificacaiFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_classificacao_fiscal", ComercialFiscalClassificacaoFiscal.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ipi", ComercialFiscalClassificacaoFiscal.valorIpi));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalClassificacaoFiscal] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ClassificacaiFiscal", "nm_classificacao_fiscal", ComercialFiscalClassificacaoFiscal.classificacaiFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_classificacao_fiscal", ComercialFiscalClassificacaoFiscal.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIpi", "vl_ipi", ComercialFiscalClassificacaoFiscal.valorIpi, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFiscalClassificacaoFiscal.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFiscalClassificacaoFiscal(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalClassificacaoFiscal] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
