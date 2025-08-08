using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidadeLigacaoEndereco : IComercialEntidadeLigacaoEndereco
{
	private MapTableComercialEntidadeLigacaoEndereco MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeLigacaoEndereco result = default(MapTableComercialEntidadeLigacaoEndereco);
		if (row != null)
		{
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoEntidadeEndereco = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidadeEndereco"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
			result.isEnderecoEntrega = BaseDadosGPS.ObterDbValor<bool>(row["isEnderecoEntrega"]);
			result.isEnderecoCobranca = BaseDadosGPS.ObterDbValor<bool>(row["isEnderecoCobranca"]);
			result.isEnderecoFaturamente = BaseDadosGPS.ObterDbValor<bool>(row["isEnderecoFaturamente"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id_entidade_principa as codigoEntidade, ");
		stringBuilder.Append("id_entidade_derivada as codigoEntidadeEndereco, ");
		stringBuilder.Append("nm_ligacao as descricao, ");
		stringBuilder.Append("ic_entrega as isEnderecoEntrega, ");
		stringBuilder.Append("ic_cobranca as isEnderecoCobranca, ");
		stringBuilder.Append("ic_faturamento as isEnderecoFaturamente");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeLigacaoEndereco> ObterTodosComercialEntidadeLigacaoEndereco()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where id_entidade_principa = " + codigoEntidadePrincipal);
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id_entidade_principa = ? and");
		stringBuilder.Append(" id_entidade_derivada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", codigoEntidadeEndereco));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeLigacaoEndereco ObterComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_principa = ? and");
		stringBuilder.Append(" id_entidade_derivada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", ComercialEntidadeLigacaoEndereco.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco (");
		stringBuilder.Append("id_entidade_principa, ");
		stringBuilder.Append("id_entidade_derivada, ");
		stringBuilder.Append("nm_ligacao, ");
		stringBuilder.Append("ic_entrega, ");
		stringBuilder.Append("ic_cobranca, ");
		stringBuilder.Append("ic_faturamento) Values (?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", ComercialEntidadeLigacaoEndereco.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_ligacao", ComercialEntidadeLigacaoEndereco.descricao));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_entrega", ComercialEntidadeLigacaoEndereco.isEnderecoEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_cobranca", ComercialEntidadeLigacaoEndereco.isEnderecoCobranca));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_faturamento", ComercialEntidadeLigacaoEndereco.isEnderecoFaturamente));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarComercialEntidadeLigacaoEndereco(MapTableComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEndereco, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "nm_ligacao", ComercialEntidadeLigacaoEndereco.descricao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsEnderecoEntrega", "ic_entrega", ComercialEntidadeLigacaoEndereco.isEnderecoEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsEnderecoCobranca", "ic_cobranca", ComercialEntidadeLigacaoEndereco.isEnderecoCobranca, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsEnderecoFaturamente", "ic_faturamento", ComercialEntidadeLigacaoEndereco.isEnderecoFaturamente, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id_entidade_principa = ? and ");
			stringBuilder.Append("id_entidade_derivada = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", ComercialEntidadeLigacaoEndereco.codigoEntidade));
			list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", ComercialEntidadeLigacaoEndereco.codigoEntidadeEndereco));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeLigacaoEndereco(int codigoEntidade, int codigoEntidadeEndereco)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_principa = ? and");
		stringBuilder.Append(" id_entidade_derivada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", codigoEntidadeEndereco));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosComercialEntidadeLigacaoEndereco(int codigoEntidade)
	{
		int num = 0;
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_principa = ? ");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_principa", codigoEntidade));
		num = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		list = new List<DbParameter>();
		stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.LigacaoEndereco ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_entidade_derivada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade_derivada", codigoEntidade));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
