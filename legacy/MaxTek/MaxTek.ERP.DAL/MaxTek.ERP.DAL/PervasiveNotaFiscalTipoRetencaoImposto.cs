using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalTipoRetencaoImposto : INotaFiscalTipoRetencaoImposto
{
	private MapTableNotaFiscalTipoRetencaoImposto MapearClasse(DataRow row)
	{
		MapTableNotaFiscalTipoRetencaoImposto result = default(MapTableNotaFiscalTipoRetencaoImposto);
		if (row != null)
		{
			result.codigoRetencao = BaseDadosERP.ObterDbValor<int>(row["codigoRetencao"]);
			result.descricaoRetencao = BaseDadosERP.ObterDbValor<string>(row["descricaoRetencao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigoRetencao, ");
		stringBuilder.Append("ds_retencao_imposto as descricaoRetencao");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NFTipoRetImposto ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalTipoRetencaoImposto> ObterTodosNotaFiscalTipoRetencaoImposto()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalTipoRetencaoImposto> list = new List<MapTableNotaFiscalTipoRetencaoImposto>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalTipoRetencaoImposto ObterNotaFiscalTipoRetencaoImposto(int codigoRetencao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoRetencao));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalTipoRetencaoImposto ObterNotaFiscalTipoRetencaoImposto(MapTableNotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImposto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalTipoRetencaoImposto.codigoRetencao));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalTipoRetencaoImposto(MapTableNotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImposto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NFTipoRetImposto (");
		stringBuilder.Append("ds_retencao_imposto) Values (?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("ds_retencao_imposto", NotaFiscalTipoRetencaoImposto.descricaoRetencao));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalTipoRetencaoImposto(MapTableNotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImposto, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NFTipoRetImposto Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoRetencao", "ds_retencao_imposto", NotaFiscalTipoRetencaoImposto.descricaoRetencao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalTipoRetencaoImposto.codigoRetencao));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalTipoRetencaoImposto(int codigoRetencao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NFTipoRetImposto ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoRetencao));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
