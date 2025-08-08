using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialFinanceiroModoPagamento : IComercialFinanceiroModoPagamento
{
	private MapTableComercialFinanceiroModoPagamento MapearClasse(DataRow row)
	{
		MapTableComercialFinanceiroModoPagamento result = default(MapTableComercialFinanceiroModoPagamento);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.sigla = BaseDadosGPS.ObterDbValor<string>(row["sigla"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.gerarBoleto = BaseDadosGPS.ObterDbValor<bool>(row["gerarBoleto"]);
			result.codigoContaContabil = BaseDadosGPS.ObterDbValor<int>(row["codigoContaContabil"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("nm_sigla as sigla, ");
		stringBuilder.Append("nm_modo_pagamento as nome, ");
		stringBuilder.Append("ic_gera_boleto as gerarBoleto, ");
		stringBuilder.Append("id_conta_contabil as codigoContaContabil");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ModoPagamento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFinanceiroModoPagamento> ObterTodosComercialFinanceiroModoPagamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFinanceiroModoPagamento> list = new List<MapTableComercialFinanceiroModoPagamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(int codigo)
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

	public MapTableComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFinanceiroModoPagamento.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ModoPagamento (");
		stringBuilder.Append("nm_sigla, ");
		stringBuilder.Append("nm_modo_pagamento, ");
		stringBuilder.Append("ic_gera_boleto, ");
		stringBuilder.Append("id_conta_contabil) Values (?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_sigla", ComercialFinanceiroModoPagamento.sigla));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_modo_pagamento", ComercialFinanceiroModoPagamento.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_gera_boleto", ComercialFinanceiroModoPagamento.gerarBoleto));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_conta_contabil", ComercialFinanceiroModoPagamento.codigoContaContabil));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ModoPagamento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Sigla", "nm_sigla", ComercialFinanceiroModoPagamento.sigla, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_modo_pagamento", ComercialFinanceiroModoPagamento.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "GerarBoleto", "ic_gera_boleto", ComercialFinanceiroModoPagamento.gerarBoleto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "id_conta_contabil", ComercialFinanceiroModoPagamento.codigoContaContabil, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFinanceiroModoPagamento.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFinanceiroModoPagamento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ModoPagamento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
