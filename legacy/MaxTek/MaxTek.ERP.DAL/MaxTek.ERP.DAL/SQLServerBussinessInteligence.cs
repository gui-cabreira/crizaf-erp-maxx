using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

public class SQLServerBussinessInteligence : IBussinessInteligence
{
	public IList<MapTableDataQuantidadeValor> ObterBI_NF_Data_Quantidade_Valor(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Select ");
		stringBuilder.Append("nf.dt_emissao as data, ");
		stringBuilder.Append("sum(nfe.vl_quantidade) as quantidade, ");
		stringBuilder.Append("sum(nfe.vl_total_fatura) as valor ");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] nfe ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.AppendFormat(" inner join [{0}].[{1}].[NotaFiscal].[NotasFiscais] nf ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("on nfe.cd_nota_fiscal = nf.cd_nota_fiscal ");
		stringBuilder.Append("where nf.dt_emissao between @dt_emissao1 and @dt_emissao2 ");
		stringBuilder.Append(" and nfe.vl_total_fatura > 0 ");
		stringBuilder.Append(" and nf.ds_situacao_nfe in ('Sucesso','SucessoContingencia','SistemaLegado') ");
		stringBuilder.Append(" group by  nf.dt_emissao; ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_emissao1", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_emissao2", dataFim));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableDataQuantidadeValor> list2 = new List<MapTableDataQuantidadeValor>();
		foreach (DataRow row in dataTable.Rows)
		{
			if (row != null)
			{
				list2.Add(new MapTableDataQuantidadeValor
				{
					data = BaseDadosERP.ObterDbValor<DateTime>(row["data"]),
					quantidade = BaseDadosERP.ObterDbValor<int>(row["quantidade"]),
					valor = BaseDadosERP.ObterDbValor<decimal>(row["valor"])
				});
			}
		}
		return list2;
	}
}
