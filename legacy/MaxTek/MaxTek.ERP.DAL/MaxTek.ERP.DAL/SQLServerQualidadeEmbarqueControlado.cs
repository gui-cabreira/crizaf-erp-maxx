using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerQualidadeEmbarqueControlado : IQualidadeEmbarqueControlado
{
	private MapTableQualidadeEmbarqueControlado MapearClasse(DataRow row)
	{
		MapTableQualidadeEmbarqueControlado result = default(MapTableQualidadeEmbarqueControlado);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoProduto = BaseDadosERP.ObterDbValor<string>(row["codigoProduto"]);
			result.codigoProdutoCliente = BaseDadosERP.ObterDbValor<string>(row["codigoProdutoCliente"]);
			result.dataInicioEmbarqueControlado = BaseDadosERP.ObterDbValor<DateTime>(row["dataInicioEmbarqueControlado"]);
			result.dataPrevisaoTerminoEmbarqueControlado = BaseDadosERP.ObterDbValor<DateTime>(row["dataPrevisaoTerminoEmbarqueControlado"]);
			result.nivelEmbarqueControlado = BaseDadosERP.ObterDbValor<int>(row["nivelEmbarqueControlado"]);
			result.descricaoDefeito = BaseDadosERP.ObterDbValor<string>(row["descricaoDefeito"]);
			result.isFechado = BaseDadosERP.ObterDbValor<bool>(row["isFechado"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_produto] as [codigoProduto], ");
		stringBuilder.Append("[cd_cliente] as [codigoProdutoCliente], ");
		stringBuilder.Append("[dt_inicio] as [dataInicioEmbarqueControlado], ");
		stringBuilder.Append("[dt_previsao_termino] as [dataPrevisaoTerminoEmbarqueControlado], ");
		stringBuilder.Append("[cd_nivel_embarque] as [nivelEmbarqueControlado], ");
		stringBuilder.Append("[ds_defeito] as [descricaoDefeito], ");
		stringBuilder.Append("[ic_fechado] as [isFechado]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[EmbarqueControlado] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableQualidadeEmbarqueControlado> ObterTodosQualidadeEmbarqueControlado()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(string produto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_produto] = @cd_produto and");
		stringBuilder.Append(" [ic_fechado] = @ic_fechado");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", produto));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_fechado", false));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", QualidadeEmbarqueControlado.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[EmbarqueControlado] (");
		stringBuilder.Append("[cd_produto], ");
		stringBuilder.Append("[cd_cliente], ");
		stringBuilder.Append("[dt_inicio], ");
		stringBuilder.Append("[dt_previsao_termino], ");
		stringBuilder.Append("[cd_nivel_embarque], ");
		stringBuilder.Append("[ds_defeito], ");
		stringBuilder.Append("[ic_fechado]) Values (@cd_produto,@cd_cliente,@dt_inicio,@dt_previsao_termino,@cd_nivel_embarque,@ds_defeito,@ic_fechado) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", QualidadeEmbarqueControlado.codigoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cliente", QualidadeEmbarqueControlado.codigoProdutoCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_inicio", QualidadeEmbarqueControlado.dataInicioEmbarqueControlado));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_previsao_termino", QualidadeEmbarqueControlado.dataPrevisaoTerminoEmbarqueControlado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nivel_embarque", QualidadeEmbarqueControlado.nivelEmbarqueControlado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_defeito", QualidadeEmbarqueControlado.descricaoDefeito));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_fechado", QualidadeEmbarqueControlado.isFechado));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[EmbarqueControlado] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", QualidadeEmbarqueControlado.codigoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProdutoCliente", "cd_cliente", QualidadeEmbarqueControlado.codigoProdutoCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataInicioEmbarqueControlado", "dt_inicio", QualidadeEmbarqueControlado.dataInicioEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataPrevisaoTerminoEmbarqueControlado", "dt_previsao_termino", QualidadeEmbarqueControlado.dataPrevisaoTerminoEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NivelEmbarqueControlado", "cd_nivel_embarque", QualidadeEmbarqueControlado.nivelEmbarqueControlado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoDefeito", "ds_defeito", QualidadeEmbarqueControlado.descricaoDefeito, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFechado", "ic_fechado", QualidadeEmbarqueControlado.isFechado, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", QualidadeEmbarqueControlado.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirQualidadeEmbarqueControlado(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Qualidade].[EmbarqueControlado] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
