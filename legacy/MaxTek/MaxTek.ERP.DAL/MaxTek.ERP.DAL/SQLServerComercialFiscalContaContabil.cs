using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialFiscalContaContabil : IComercialFiscalContaContabil
{
	private MapTableComercialFiscalContaContabil MapearClasse(DataRow row)
	{
		MapTableComercialFiscalContaContabil result = default(MapTableComercialFiscalContaContabil);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.classe = BaseDadosERP.ObterDbValor<int>(row["classe"]);
			result.subClasse = BaseDadosERP.ObterDbValor<int>(row["subClasse"]);
			result.contaAnalitica = BaseDadosERP.ObterDbValor<string>(row["contaAnalitica"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_conta] as [descricao], ");
		stringBuilder.Append("[classe] as [classe], ");
		stringBuilder.Append("[subclasse] as [subClasse], ");
		stringBuilder.Append("[cd_conta_analitica] as [contaAnalitica]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalContaContabil] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFiscalContaContabil> ObterTodosComercialFiscalContaContabil()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFiscalContaContabil> list = new List<MapTableComercialFiscalContaContabil>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFiscalContaContabil ObterComercialFiscalContaContabil(int id)
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

	public MapTableComercialFiscalContaContabil ObterComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFiscalContaContabil.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalContaContabil] (");
		stringBuilder.Append("[nm_conta], ");
		stringBuilder.Append("[classe], ");
		stringBuilder.Append("[subclasse], ");
		stringBuilder.Append("[cd_conta_analitica]) Values (@nm_conta,@classe,@subclasse,@cd_conta_analitica) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_conta", ComercialFiscalContaContabil.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@classe", ComercialFiscalContaContabil.classe));
		list.Add(BaseDadosERP.ObterNovoParametro("@subclasse", ComercialFiscalContaContabil.subClasse));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_conta_analitica", ComercialFiscalContaContabil.contaAnalitica));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFiscalContaContabil(MapTableComercialFiscalContaContabil ComercialFiscalContaContabil, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalContaContabil] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "nm_conta", ComercialFiscalContaContabil.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Classe", "classe", ComercialFiscalContaContabil.classe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SubClasse", "subclasse", ComercialFiscalContaContabil.subClasse, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ContaAnalitica", "cd_conta_analitica", ComercialFiscalContaContabil.contaAnalitica, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFiscalContaContabil.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFiscalContaContabil(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FiscalContaContabil] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
