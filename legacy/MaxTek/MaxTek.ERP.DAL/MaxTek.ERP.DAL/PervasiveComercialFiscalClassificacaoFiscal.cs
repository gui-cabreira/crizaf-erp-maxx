using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialFiscalClassificacaoFiscal : IComercialFiscalClassificacaoFiscal
{
	private MapTableComercialFiscalClassificacaoFiscal MapearClasse(DataRow row)
	{
		MapTableComercialFiscalClassificacaoFiscal result = default(MapTableComercialFiscalClassificacaoFiscal);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.classificacaiFiscal = BaseDadosGPS.ObterDbValor<string>(row["classificacaiFiscal"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
			result.valorIpi = BaseDadosGPS.ObterDbValor<decimal>(row["valorIpi"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_classificacao_fis as classificacaiFiscal, ");
		stringBuilder.Append("ds_classificacao_fis as descricao, ");
		stringBuilder.Append("vl_ipi as valorIpi");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.lClassificacaoFiscal ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFiscalClassificacaoFiscal> ObterTodosComercialFiscalClassificacaoFiscal()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialFiscalClassificacaoFiscal ObterComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFiscalClassificacaoFiscal.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.lClassificacaoFiscal (");
		stringBuilder.Append("nm_classificacao_fis, ");
		stringBuilder.Append("ds_classificacao_fis, ");
		stringBuilder.Append("vl_ipi) Values (?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_classificacao_fis", ComercialFiscalClassificacaoFiscal.classificacaiFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_classificacao_fis", ComercialFiscalClassificacaoFiscal.descricao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ipi", ComercialFiscalClassificacaoFiscal.valorIpi));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFiscalClassificacaoFiscal(MapTableComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscal, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.lClassificacaoFiscal Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ClassificacaiFiscal", "nm_classificacao_fis", ComercialFiscalClassificacaoFiscal.classificacaiFiscal, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_classificacao_fis", ComercialFiscalClassificacaoFiscal.descricao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorIpi", "vl_ipi", ComercialFiscalClassificacaoFiscal.valorIpi, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFiscalClassificacaoFiscal.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFiscalClassificacaoFiscal(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.lClassificacaoFiscal ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
