using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProduto : ITecnicoEngenhariaProduto
{
	private MapTableTecnicoEngenhariaProduto MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProduto result = default(MapTableTecnicoEngenhariaProduto);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.referenciaProduto = BaseDadosERP.ObterDbValor<string>(row["referenciaProduto"]);
			result.codigoTipoProduto = BaseDadosERP.ObterDbValor<int>(row["codigoTipoProduto"]);
			result.dimensao01 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao01"]);
			result.dimensao02 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao02"]);
			result.dimensao03 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao03"]);
			result.dimensao04 = BaseDadosERP.ObterDbValor<decimal>(row["dimensao04"]);
			result.isFabricado = BaseDadosERP.ObterDbValor<bool>(row["isFabricado"]);
			result.isComprado = BaseDadosERP.ObterDbValor<bool>(row["isComprado"]);
			result.isMateriaPrima = BaseDadosERP.ObterDbValor<bool>(row["isMateriaPrima"]);
			result.descricaoProduto = BaseDadosERP.ObterDbValor<string>(row["descricaoProduto"]);
			result.codigoFamilia = BaseDadosERP.ObterDbValor<int>(row["codigoFamilia"]);
			result.codigoSubfamilia = BaseDadosERP.ObterDbValor<int>(row["codigoSubfamilia"]);
			result.codigoAlmoxarifado = BaseDadosERP.ObterDbValor<int>(row["codigoAlmoxarifado"]);
			result.codigoCompartimento = BaseDadosERP.ObterDbValor<int>(row["codigoCompartimento"]);
			result.codigoClassificacaoFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoClassificacaoFiscal"]);
			result.imagem = BaseDadosERP.ObterDbValor<Image>(row["imagem"]);
			result.desenho = BaseDadosERP.ObterDbValor<string>(row["desenho"]);
			result.revisaoDesenho = BaseDadosERP.ObterDbValor<string>(row["revisaoDesenho"]);
			result.codigoContaContabil = BaseDadosERP.ObterDbValor<int>(row["codigoContaContabil"]);
			result.isGerenciaLote = BaseDadosERP.ObterDbValor<bool>(row["isGerenciaLote"]);
			result.codigoUnidadeEstoque = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeEstoque"]);
			result.codigoUnidadeCompra = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeCompra"]);
			result.coeficienteConversaoUnidades = BaseDadosERP.ObterDbValor<decimal>(row["coeficienteConversaoUnidades"]);
			result.peso = BaseDadosERP.ObterDbValor<decimal>(row["peso"]);
			result.tamanhoPadrao = BaseDadosERP.ObterDbValor<decimal>(row["tamanhoPadrao"]);
			result.quantidadeEstoque = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeEstoque"]);
			result.quantidadeReservada = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeReservada"]);
			result.quantidadeDisponivel = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeDisponivel"]);
			result.quantidadeReabastecimento = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeReabastecimento"]);
			result.loteEconomico = BaseDadosERP.ObterDbValor<decimal>(row["loteEconomico"]);
			result.estoqueMinimo = BaseDadosERP.ObterDbValor<decimal>(row["estoqueMinimo"]);
			result.precoBaseCompra = BaseDadosERP.ObterDbValor<decimal>(row["precoBaseCompra"]);
			result.precoBaseVenda = BaseDadosERP.ObterDbValor<decimal>(row["precoBaseVenda"]);
			result.precoUnitarioUltimaCompra = BaseDadosERP.ObterDbValor<decimal>(row["precoUnitarioUltimaCompra"]);
			result.dataUltimaCompra = BaseDadosERP.ObterDbValor<DateTime>(row["dataUltimaCompra"]);
			result.precoUnitarioUltimaVenda = BaseDadosERP.ObterDbValor<decimal>(row["precoUnitarioUltimaVenda"]);
			result.dataUltimaVenda = BaseDadosERP.ObterDbValor<DateTime>(row["dataUltimaVenda"]);
			result.precoMedioCompra = BaseDadosERP.ObterDbValor<decimal>(row["precoMedioCompra"]);
			result.precoMedioVenda = BaseDadosERP.ObterDbValor<decimal>(row["precoMedioVenda"]);
			result.codigoProcessoControle = BaseDadosERP.ObterDbValor<int>(row["codigoProcessoControle"]);
			result.isControleRecebimento = BaseDadosERP.ObterDbValor<bool>(row["isControleRecebimento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_produto] as [referenciaProduto], ");
		stringBuilder.Append("[cd_tipo_produto] as [codigoTipoProduto], ");
		stringBuilder.Append("[vl_dimensao_01] as [dimensao01], ");
		stringBuilder.Append("[vl_dimensao_02] as [dimensao02], ");
		stringBuilder.Append("[vl_dimensao_03] as [dimensao03], ");
		stringBuilder.Append("[vl_dimensao_04] as [dimensao04], ");
		stringBuilder.Append("[ic_fabricado] as [isFabricado], ");
		stringBuilder.Append("[ic_comprado] as [isComprado], ");
		stringBuilder.Append("[ic_materia] as [isMateriaPrima], ");
		stringBuilder.Append("[nm_produto] as [descricaoProduto], ");
		stringBuilder.Append("[cd_familia] as [codigoFamilia], ");
		stringBuilder.Append("[cd_subfamilia] as [codigoSubfamilia], ");
		stringBuilder.Append("[cd_almoxarifado] as [codigoAlmoxarifado], ");
		stringBuilder.Append("[cd_compartimento] as [codigoCompartimento], ");
		stringBuilder.Append("[cd_classificacao_fiscal] as [codigoClassificacaoFiscal], ");
		stringBuilder.Append("[im_produto] as [imagem], ");
		stringBuilder.Append("[cd_desenho] as [desenho], ");
		stringBuilder.Append("[cd_revisao_desenho] as [revisaoDesenho], ");
		stringBuilder.Append("[cd_conta_contabil] as [codigoContaContabil], ");
		stringBuilder.Append("[ic_gestao_lote] as [isGerenciaLote], ");
		stringBuilder.Append("[cd_unidade_estoque] as [codigoUnidadeEstoque], ");
		stringBuilder.Append("[cd_unidade_compra] as [codigoUnidadeCompra], ");
		stringBuilder.Append("[vl_coeficiente_conversao] as [coeficienteConversaoUnidades], ");
		stringBuilder.Append("[vl_peso_produto] as [peso], ");
		stringBuilder.Append("[vl_comprimento_padrao] as [tamanhoPadrao], ");
		stringBuilder.Append("[vl_quantidade_estoque] as [quantidadeEstoque], ");
		stringBuilder.Append("[vl_quantidade_reservada] as [quantidadeReservada], ");
		stringBuilder.Append("[vl_quantidade_disponivel] as [quantidadeDisponivel], ");
		stringBuilder.Append("[vl_quantidade_reabastecimento] as [quantidadeReabastecimento], ");
		stringBuilder.Append("[vl_lote_economico] as [loteEconomico], ");
		stringBuilder.Append("[vl_estoque_minimo] as [estoqueMinimo], ");
		stringBuilder.Append("[vl_preco_base_compra] as [precoBaseCompra], ");
		stringBuilder.Append("[vl_preco_base_venda] as [precoBaseVenda], ");
		stringBuilder.Append("[vl_unitario_ultima_compra] as [precoUnitarioUltimaCompra], ");
		stringBuilder.Append("[dt_ultima_compra] as [dataUltimaCompra], ");
		stringBuilder.Append("[vl_unitario_ultima_venda] as [precoUnitarioUltimaVenda], ");
		stringBuilder.Append("[dt_ultima_venda] as [dataUltimaVenda], ");
		stringBuilder.Append("[vl_preco_medio_compra] as [precoMedioCompra], ");
		stringBuilder.Append("[vl_preco_medio_venda] as [precoMedioVenda], ");
		stringBuilder.Append("[cd_processo_controle] as [codigoProcessoControle], ");
		stringBuilder.Append("[ic_controle_recebimento] as [isControleRecebimento]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Produto] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProduto> ObterTodosTecnicoEngenhariaProduto()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProduto> list = new List<MapTableTecnicoEngenhariaProduto>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(int id)
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

	public MapTableTecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProduto.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Produto] (");
		stringBuilder.Append("[cd_produto], ");
		stringBuilder.Append("[cd_tipo_produto], ");
		stringBuilder.Append("[vl_dimensao_01], ");
		stringBuilder.Append("[vl_dimensao_02], ");
		stringBuilder.Append("[vl_dimensao_03], ");
		stringBuilder.Append("[vl_dimensao_04], ");
		stringBuilder.Append("[ic_fabricado], ");
		stringBuilder.Append("[ic_comprado], ");
		stringBuilder.Append("[ic_materia], ");
		stringBuilder.Append("[nm_produto], ");
		stringBuilder.Append("[cd_familia], ");
		stringBuilder.Append("[cd_subfamilia], ");
		stringBuilder.Append("[cd_almoxarifado], ");
		stringBuilder.Append("[cd_compartimento], ");
		stringBuilder.Append("[cd_classificacao_fiscal], ");
		stringBuilder.Append("[im_produto], ");
		stringBuilder.Append("[cd_desenho], ");
		stringBuilder.Append("[cd_revisao_desenho], ");
		stringBuilder.Append("[cd_conta_contabil], ");
		stringBuilder.Append("[ic_gestao_lote], ");
		stringBuilder.Append("[cd_unidade_estoque], ");
		stringBuilder.Append("[cd_unidade_compra], ");
		stringBuilder.Append("[vl_coeficiente_conversao], ");
		stringBuilder.Append("[vl_peso_produto], ");
		stringBuilder.Append("[vl_comprimento_padrao], ");
		stringBuilder.Append("[vl_quantidade_estoque], ");
		stringBuilder.Append("[vl_quantidade_reservada], ");
		stringBuilder.Append("[vl_quantidade_reabastecimento], ");
		stringBuilder.Append("[vl_lote_economico], ");
		stringBuilder.Append("[vl_estoque_minimo], ");
		stringBuilder.Append("[vl_preco_base_compra], ");
		stringBuilder.Append("[vl_preco_base_venda], ");
		stringBuilder.Append("[vl_unitario_ultima_compra], ");
		stringBuilder.Append("[dt_ultima_compra], ");
		stringBuilder.Append("[vl_unitario_ultima_venda], ");
		stringBuilder.Append("[dt_ultima_venda], ");
		stringBuilder.Append("[vl_preco_medio_compra], ");
		stringBuilder.Append("[vl_preco_medio_venda], ");
		stringBuilder.Append("[cd_processo_controle], ");
		stringBuilder.Append("[ic_controle_recebimento]) Values (@cd_produto,@cd_tipo_produto,@vl_dimensao_01,@vl_dimensao_02,@vl_dimensao_03,@vl_dimensao_04,@ic_fabricado,@ic_comprado,@ic_materia,@nm_produto,@cd_familia,@cd_subfamilia,@cd_almoxarifado,@cd_compartimento,@cd_classificacao_fiscal,@im_produto,@cd_desenho,@cd_revisao_desenho,@cd_conta_contabil,@ic_gestao_lote,@cd_unidade_estoque,@cd_unidade_compra,@vl_coeficiente_conversao,@vl_peso_produto,@vl_comprimento_padrao,@vl_quantidade_estoque,@vl_quantidade_reservada,@vl_quantidade_reabastecimento,@vl_lote_economico,@vl_estoque_minimo,@vl_preco_base_compra,@vl_preco_base_venda,@vl_unitario_ultima_compra,@dt_ultima_compra,@vl_unitario_ultima_venda,@dt_ultima_venda,@vl_preco_medio_compra,@vl_preco_medio_venda,@cd_processo_controle,@ic_controle_recebimento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", TecnicoEngenhariaProduto.referenciaProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_produto", TecnicoEngenhariaProduto.codigoTipoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_01", TecnicoEngenhariaProduto.dimensao01));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_02", TecnicoEngenhariaProduto.dimensao02));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_03", TecnicoEngenhariaProduto.dimensao03));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_04", TecnicoEngenhariaProduto.dimensao04));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_fabricado", TecnicoEngenhariaProduto.isFabricado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_comprado", TecnicoEngenhariaProduto.isComprado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_materia", TecnicoEngenhariaProduto.isMateriaPrima));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_produto", TecnicoEngenhariaProduto.descricaoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_familia", TecnicoEngenhariaProduto.codigoFamilia));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_subfamilia", TecnicoEngenhariaProduto.codigoSubfamilia));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_almoxarifado", TecnicoEngenhariaProduto.codigoAlmoxarifado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_compartimento", TecnicoEngenhariaProduto.codigoCompartimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_classificacao_fiscal", TecnicoEngenhariaProduto.codigoClassificacaoFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@im_produto", TecnicoEngenhariaProduto.imagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_desenho", TecnicoEngenhariaProduto.desenho));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_revisao_desenho", TecnicoEngenhariaProduto.revisaoDesenho));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_conta_contabil", TecnicoEngenhariaProduto.codigoContaContabil));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_gestao_lote", TecnicoEngenhariaProduto.isGerenciaLote));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_estoque", TecnicoEngenhariaProduto.codigoUnidadeEstoque));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_compra", TecnicoEngenhariaProduto.codigoUnidadeCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_coeficiente_conversao", TecnicoEngenhariaProduto.coeficienteConversaoUnidades));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_peso_produto", TecnicoEngenhariaProduto.peso));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_comprimento_padrao", TecnicoEngenhariaProduto.tamanhoPadrao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_estoque", TecnicoEngenhariaProduto.quantidadeEstoque));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_reservada", TecnicoEngenhariaProduto.quantidadeReservada));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_reabastecimento", TecnicoEngenhariaProduto.quantidadeReabastecimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_lote_economico", TecnicoEngenhariaProduto.loteEconomico));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_estoque_minimo", TecnicoEngenhariaProduto.estoqueMinimo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_preco_base_compra", TecnicoEngenhariaProduto.precoBaseCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_preco_base_venda", TecnicoEngenhariaProduto.precoBaseVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_unitario_ultima_compra", TecnicoEngenhariaProduto.precoUnitarioUltimaCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_ultima_compra", TecnicoEngenhariaProduto.dataUltimaCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_unitario_ultima_venda", TecnicoEngenhariaProduto.precoUnitarioUltimaVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_ultima_venda", TecnicoEngenhariaProduto.dataUltimaVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_preco_medio_compra", TecnicoEngenhariaProduto.precoMedioCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_preco_medio_venda", TecnicoEngenhariaProduto.precoMedioVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_processo_controle", TecnicoEngenhariaProduto.codigoProcessoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_controle_recebimento", TecnicoEngenhariaProduto.isControleRecebimento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Produto] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ReferenciaProduto", "cd_produto", TecnicoEngenhariaProduto.referenciaProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProduto", "cd_tipo_produto", TecnicoEngenhariaProduto.codigoTipoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao01", "vl_dimensao_01", TecnicoEngenhariaProduto.dimensao01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao02", "vl_dimensao_02", TecnicoEngenhariaProduto.dimensao02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao03", "vl_dimensao_03", TecnicoEngenhariaProduto.dimensao03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Dimensao04", "vl_dimensao_04", TecnicoEngenhariaProduto.dimensao04, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFabricado", "ic_fabricado", TecnicoEngenhariaProduto.isFabricado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsComprado", "ic_comprado", TecnicoEngenhariaProduto.isComprado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsMateriaPrima", "ic_materia", TecnicoEngenhariaProduto.isMateriaPrima, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoProduto", "nm_produto", TecnicoEngenhariaProduto.descricaoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFamilia", "cd_familia", TecnicoEngenhariaProduto.codigoFamilia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSubfamilia", "cd_subfamilia", TecnicoEngenhariaProduto.codigoSubfamilia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "cd_almoxarifado", TecnicoEngenhariaProduto.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCompartimento", "cd_compartimento", TecnicoEngenhariaProduto.codigoCompartimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoClassificacaoFiscal", "cd_classificacao_fiscal", TecnicoEngenhariaProduto.codigoClassificacaoFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_produto", TecnicoEngenhariaProduto.imagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Desenho", "cd_desenho", TecnicoEngenhariaProduto.desenho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RevisaoDesenho", "cd_revisao_desenho", TecnicoEngenhariaProduto.revisaoDesenho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "cd_conta_contabil", TecnicoEngenhariaProduto.codigoContaContabil, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsGerenciaLote", "ic_gestao_lote", TecnicoEngenhariaProduto.isGerenciaLote, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeEstoque", "cd_unidade_estoque", TecnicoEngenhariaProduto.codigoUnidadeEstoque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeCompra", "cd_unidade_compra", TecnicoEngenhariaProduto.codigoUnidadeCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CoeficienteConversaoUnidades", "vl_coeficiente_conversao", TecnicoEngenhariaProduto.coeficienteConversaoUnidades, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Peso", "vl_peso_produto", TecnicoEngenhariaProduto.peso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TamanhoPadrao", "vl_comprimento_padrao", TecnicoEngenhariaProduto.tamanhoPadrao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeEstoque", "vl_quantidade_estoque", TecnicoEngenhariaProduto.quantidadeEstoque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeReservada", "vl_quantidade_reservada", TecnicoEngenhariaProduto.quantidadeReservada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeDisponivel", "vl_quantidade_disponivel", TecnicoEngenhariaProduto.quantidadeDisponivel, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeReabastecimento", "vl_quantidade_reabastecimento", TecnicoEngenhariaProduto.quantidadeReabastecimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "LoteEconomico", "vl_lote_economico", TecnicoEngenhariaProduto.loteEconomico, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "EstoqueMinimo", "vl_estoque_minimo", TecnicoEngenhariaProduto.estoqueMinimo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoBaseCompra", "vl_preco_base_compra", TecnicoEngenhariaProduto.precoBaseCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoBaseVenda", "vl_preco_base_venda", TecnicoEngenhariaProduto.precoBaseVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoUnitarioUltimaCompra", "vl_unitario_ultima_compra", TecnicoEngenhariaProduto.precoUnitarioUltimaCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataUltimaCompra", "dt_ultima_compra", TecnicoEngenhariaProduto.dataUltimaCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoUnitarioUltimaVenda", "vl_unitario_ultima_venda", TecnicoEngenhariaProduto.precoUnitarioUltimaVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataUltimaVenda", "dt_ultima_venda", TecnicoEngenhariaProduto.dataUltimaVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoMedioCompra", "vl_preco_medio_compra", TecnicoEngenhariaProduto.precoMedioCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PrecoMedioVenda", "vl_preco_medio_venda", TecnicoEngenhariaProduto.precoMedioVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProcessoControle", "cd_processo_controle", TecnicoEngenhariaProduto.codigoProcessoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsControleRecebimento", "ic_controle_recebimento", TecnicoEngenhariaProduto.isControleRecebimento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProduto.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProduto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[Produto] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
