using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidadeLigacaoEndereco : IComercialEntidadeLigacaoEndereco
{
	private MapTableComercialEntidadeLigacaoEndereco MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeLigacaoEndereco result = default(MapTableComercialEntidadeLigacaoEndereco);
		if (row != null)
		{
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoEntidadeEndereco = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeEndereco"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.isEnderecoEntrega = BaseDadosERP.ObterDbValor<bool>(row["isEnderecoEntrega"]);
			result.isEnderecoCobranca = BaseDadosERP.ObterDbValor<bool>(row["isEnderecoCobranca"]);
			result.isEnderecoFaturamente = BaseDadosERP.ObterDbValor<bool>(row["isEnderecoFaturamente"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id_entidade_principal] as [codigoEntidade], ");
		stringBuilder.Append("[id_entidade_derivada] as [codigoEntidadeEndereco], ");
		stringBuilder.Append("[nm_ligacao] as [descricao], ");
		stringBuilder.Append("[ic_entrega] as [isEnderecoEntrega], ");
		stringBuilder.Append("[ic_cobranca] as [isEnderecoCobranca], ");
		stringBuilder.Append("[ic_faturamento] as [isEnderecoFaturamente]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeLigacaoEndereco> ObterTodosComercialEntidadeLigacaoEndereco()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeLigacaoEndereco> list = new List<MapTableComercialEntidadeLigacaoEndereco>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeLigacaoEndereco> ObterTodosComercialEntidadeLigacaoEndereco(int codigoEntidadePrincipal)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [id_entidade_principal] = " + codigoEntidadePrincipal);
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeLigacaoEndereco> list = new List<MapTableComercialEntidadeLigacaoEndereco>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidadeLigacaoEndereco ObterComercialEntidadeLigacaoEndereco(int codigoEntidade, int codigoEntidadeEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_principal = @id_entidade_principal and");
		stringBuilder.Append(" id_entidade_derivada = @id_entidade_derivada");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", codigoEntidadeEndereco));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeLigacaoEndereco ObterComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_principal = @id_entidade_principal and");
		stringBuilder.Append(" id_entidade_derivada = @id_entidade_derivada");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", ComercialEntidadeLigacaoEndereco.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] (");
		stringBuilder.Append("id_entidade_principal, ");
		stringBuilder.Append("id_entidade_derivada, ");
		stringBuilder.Append("nm_ligacao, ");
		stringBuilder.Append("ic_entrega, ");
		stringBuilder.Append("ic_cobranca, ");
		stringBuilder.Append("ic_faturamento) Values (@id_entidade_principal,@id_entidade_derivada,@nm_ligacao,@ic_entrega,@ic_cobranca,@ic_faturamento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", ComercialEntidadeLigacaoEndereco.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_ligacao", ComercialEntidadeLigacaoEndereco.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_entrega", ComercialEntidadeLigacaoEndereco.isEnderecoEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_cobranca", ComercialEntidadeLigacaoEndereco.isEnderecoCobranca));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_faturamento", ComercialEntidadeLigacaoEndereco.isEnderecoFaturamente));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "nm_ligacao", ComercialEntidadeLigacaoEndereco.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEnderecoEntrega", "ic_entrega", ComercialEntidadeLigacaoEndereco.isEnderecoEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEnderecoCobranca", "ic_cobranca", ComercialEntidadeLigacaoEndereco.isEnderecoCobranca, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEnderecoFaturamente", "ic_faturamento", ComercialEntidadeLigacaoEndereco.isEnderecoFaturamente, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id_entidade_principal = @id_entidade_principal and ");
			stringBuilder.Append("id_entidade_derivada = @id_entidade_derivada");
			list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", ComercialEntidadeLigacaoEndereco.codigoEntidade));
			list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeLigacaoEndereco(int codigoEntidade, int codigoEntidadeEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_entidade_principal] = @id_entidade_principal and");
		stringBuilder.Append(" [id_entidade_derivada] = @id_entidade_derivada");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", codigoEntidadeEndereco));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosComercialEntidadeLigacaoEndereco(int codigoEntidade)
	{
		int num = 0;
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_entidade_principal] = @id_entidade_principal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_principal", codigoEntidade));
		num = BaseDadosERP.Update(stringBuilder.ToString(), list);
		list = new List<DbParameter>();
		stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeLigacaoEndereco] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_entidade_derivada] = @id_entidade_derivada");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade_derivada", codigoEntidade));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
