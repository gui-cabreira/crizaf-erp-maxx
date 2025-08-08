using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveQualidadeEmbarqueControlado : IQualidadeEmbarqueControlado
{
	private MapTableQualidadeEmbarqueControlado MapearClasse(DataRow row)
	{
		MapTableQualidadeEmbarqueControlado result = default(MapTableQualidadeEmbarqueControlado);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoProduto = BaseDadosGPS.ObterDbValor<string>(row["codigoProduto"]);
			result.codigoProdutoCliente = BaseDadosGPS.ObterDbValor<string>(row["codigoProdutoCliente"]);
			result.dataInicioEmbarqueControlado = BaseDadosGPS.ObterDbValor<DateTime>(row["dataInicioEmbarqueControlado"]);
			result.dataPrevisaoTerminoEmbarqueControlado = BaseDadosGPS.ObterDbValor<DateTime>(row["dataPrevisaoTerminoEmbarqueControlado"]);
			result.nivelEmbarqueControlado = BaseDadosGPS.ObterDbValor<int>(row["nivelEmbarqueControlado"]);
			result.descricaoDefeito = BaseDadosGPS.ObterDbValor<string>(row["descricaoDefeito"]);
			result.isFechado = BaseDadosGPS.ObterDbValor<bool>(row["isFechado"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_produto as codigoProduto, ");
		stringBuilder.Append("cd_cliente as codigoProdutoCliente, ");
		stringBuilder.Append("dt_inicio as dataInicioEmbarqueControlado, ");
		stringBuilder.Append("dt_previsao_termino as dataPrevisaoTerminoEmbarqueControlado, ");
		stringBuilder.Append("cd_nivel_embarque as nivelEmbarqueControlado, ");
		stringBuilder.Append("ds_defeito as descricaoDefeito, ");
		stringBuilder.Append("ic_fechado as isFechado");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "Erp.EmbarqueControlado ");
		return stringBuilder.ToString();
	}

	public IList<MapTableQualidadeEmbarqueControlado> ObterTodosQualidadeEmbarqueControlado()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableQualidadeEmbarqueControlado> list = new List<MapTableQualidadeEmbarqueControlado>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(int id)
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

	public MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(string produto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_produto = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_produto", produto));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", QualidadeEmbarqueControlado.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "Erp.EmbarqueControlado (");
		stringBuilder.Append("cd_produto, ");
		stringBuilder.Append("cd_cliente, ");
		stringBuilder.Append("dt_inicio, ");
		stringBuilder.Append("dt_previsao_termino, ");
		stringBuilder.Append("cd_nivel_embarque, ");
		stringBuilder.Append("ds_defeito, ");
		stringBuilder.Append("ic_fechado) Values (?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_produto", QualidadeEmbarqueControlado.codigoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cliente", QualidadeEmbarqueControlado.codigoProdutoCliente));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_inicio", QualidadeEmbarqueControlado.dataInicioEmbarqueControlado));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_previsao_termino", QualidadeEmbarqueControlado.dataPrevisaoTerminoEmbarqueControlado));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nivel_embarque", QualidadeEmbarqueControlado.nivelEmbarqueControlado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_defeito", QualidadeEmbarqueControlado.descricaoDefeito));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_fechado", QualidadeEmbarqueControlado.isFechado));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "Erp.EmbarqueControlado Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", QualidadeEmbarqueControlado.codigoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProdutoCliente", "cd_cliente", QualidadeEmbarqueControlado.codigoProdutoCliente, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataInicioEmbarqueControlado", "dt_inicio", QualidadeEmbarqueControlado.dataInicioEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataPrevisaoTerminoEmbarqueControlado", "dt_previsao_termino", QualidadeEmbarqueControlado.dataPrevisaoTerminoEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NivelEmbarqueControlado", "cd_nivel_embarque", QualidadeEmbarqueControlado.nivelEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoDefeito", "ds_defeito", QualidadeEmbarqueControlado.descricaoDefeito, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsFechado", "ic_fechado", QualidadeEmbarqueControlado.isFechado, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", QualidadeEmbarqueControlado.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirQualidadeEmbarqueControlado(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "Erp.EmbarqueControlado ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
