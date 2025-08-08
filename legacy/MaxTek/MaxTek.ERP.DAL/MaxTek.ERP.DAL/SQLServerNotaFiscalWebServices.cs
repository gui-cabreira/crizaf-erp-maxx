using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalWebServices : INotaFiscalWebServices
{
	private MapTableNotaFiscalWebServices MapearClasse(DataRow row)
	{
		MapTableNotaFiscalWebServices result = default(MapTableNotaFiscalWebServices);
		if (row != null)
		{
			result.uf = BaseDadosERP.ObterDbValor<string>(row["uf"]);
			result.ambiente = BaseDadosERP.ObterDbValor<string>(row["ambiente"]);
			result.servico = BaseDadosERP.ObterDbValor<string>(row["servico"]);
			result.webservice = BaseDadosERP.ObterDbValor<string>(row["webservice"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[nm_uf] as [uf], ");
		stringBuilder.Append("[nm_ambiente] as [ambiente], ");
		stringBuilder.Append("[nm_servico] as [servico], ");
		stringBuilder.Append("[nm_webservice] as [webservice]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[WebServices] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalWebServices> ObterTodosNotaFiscalWebServices()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalWebServices> list = new List<MapTableNotaFiscalWebServices>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalWebServices ObterNotaFiscalWebServices(string uf, string ambiente, string servico)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_uf] = @nm_uf and");
		stringBuilder.Append(" [nm_ambiente] = @nm_ambiente and");
		stringBuilder.Append(" [nm_servico] = @nm_servico");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", uf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_ambiente", ambiente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_servico", servico));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalWebServices ObterNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_uf] = @nm_uf and");
		stringBuilder.Append(" [nm_ambiente] = @nm_ambiente and");
		stringBuilder.Append(" [nm_servico] = @nm_servico");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", NotaFiscalWebServices.uf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_ambiente", NotaFiscalWebServices.ambiente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_servico", NotaFiscalWebServices.servico));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[WebServices] (");
		stringBuilder.Append("[nm_uf], ");
		stringBuilder.Append("[nm_ambiente], ");
		stringBuilder.Append("[nm_servico], ");
		stringBuilder.Append("[nm_webservice]) Values (@nm_uf,@nm_ambiente,@nm_servico,@nm_webservice) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", NotaFiscalWebServices.uf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_ambiente", NotaFiscalWebServices.ambiente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_servico", NotaFiscalWebServices.servico));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_webservice", NotaFiscalWebServices.webservice));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[WebServices] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Webservice", "nm_webservice", NotaFiscalWebServices.webservice, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("nm_uf = @nm_uf and ");
			stringBuilder.Append("nm_ambiente = @nm_ambiente and ");
			stringBuilder.Append("nm_servico = @nm_servico");
			list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", NotaFiscalWebServices.uf));
			list.Add(BaseDadosERP.ObterNovoParametro("@nm_ambiente", NotaFiscalWebServices.ambiente));
			list.Add(BaseDadosERP.ObterNovoParametro("@nm_servico", NotaFiscalWebServices.servico));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalWebServices(string uf, string ambiente, string servico)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[WebServices] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_uf] = @nm_uf and");
		stringBuilder.Append(" [nm_ambiente] = @nm_ambiente and");
		stringBuilder.Append(" [nm_servico] = @nm_servico");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", uf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_ambiente", ambiente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_servico", servico));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
