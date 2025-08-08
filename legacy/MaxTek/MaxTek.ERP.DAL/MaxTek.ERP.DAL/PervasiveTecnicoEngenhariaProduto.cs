using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProduto : ITecnicoEngenhariaProduto
{
	private MapTableTecnicoEngenhariaProduto MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProduto result = default(MapTableTecnicoEngenhariaProduto);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.referenciaProduto = BaseDadosGPS.ObterDbValor<string>(row["referenciaProduto"]);
			result.codigoTipoProduto = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoProduto"]);
			result.dimensao01 = BaseDadosGPS.ObterDbValor<decimal>(row["dimensao01"]);
			result.dimensao02 = BaseDadosGPS.ObterDbValor<decimal>(row["dimensao02"]);
			result.dimensao03 = BaseDadosGPS.ObterDbValor<decimal>(row["dimensao03"]);
			result.dimensao04 = BaseDadosGPS.ObterDbValor<decimal>(row["dimensao04"]);
			result.isFabricado = BaseDadosGPS.ObterDbValor<bool>(row["isFabricado"]);
			result.isComprado = BaseDadosGPS.ObterDbValor<bool>(row["isComprado"]);
			result.isMateriaPrima = BaseDadosGPS.ObterDbValor<bool>(row["isMateriaPrima"]);
			result.descricaoProduto = BaseDadosGPS.ObterDbValor<string>(row["descricaoProduto"]);
			result.codigoFamilia = BaseDadosGPS.ObterDbValor<int>(row["codigoFamilia"]);
			result.codigoSubfamilia = BaseDadosGPS.ObterDbValor<int>(row["codigoSubfamilia"]);
			result.codigoAlmoxarifado = BaseDadosGPS.ObterDbValor<int>(row["codigoAlmoxarifado"]);
			result.codigoCompartimento = BaseDadosGPS.ObterDbValor<int>(row["codigoCompartimento"]);
			result.codigoClassificacaoFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoClassificacaoFiscal"]);
			result.imagem = BaseDadosGPS.ObterDbValor<Image>(row["imagem"]);
			result.desenho = BaseDadosGPS.ObterDbValor<string>(row["desenho"]);
			result.revisaoDesenho = BaseDadosGPS.ObterDbValor<string>(row["revisaoDesenho"]);
			result.codigoContaContabil = BaseDadosGPS.ObterDbValor<int>(row["codigoContaContabil"]);
			result.isGerenciaLote = BaseDadosGPS.ObterDbValor<bool>(row["isGerenciaLote"]);
			result.codigoUnidadeEstoque = BaseDadosGPS.ObterDbValor<int>(row["codigoUnidadeEstoque"]);
			result.codigoUnidadeCompra = BaseDadosGPS.ObterDbValor<int>(row["codigoUnidadeCompra"]);
			result.coeficienteConversaoUnidades = BaseDadosGPS.ObterDbValor<decimal>(row["coeficienteConversaoUnidades"]);
			result.peso = BaseDadosGPS.ObterDbValor<decimal>(row["peso"]);
			result.tamanhoPadrao = BaseDadosGPS.ObterDbValor<decimal>(row["tamanhoPadrao"]);
			result.quantidadeEstoque = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeEstoque"]);
			result.quantidadeReservada = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeReservada"]);
			result.quantidadeDisponivel = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeDisponivel"]);
			result.quantidadeReabastecimento = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeReabastecimento"]);
			result.loteEconomico = BaseDadosGPS.ObterDbValor<decimal>(row["loteEconomico"]);
			result.estoqueMinimo = BaseDadosGPS.ObterDbValor<decimal>(row["estoqueMinimo"]);
			result.precoBaseCompra = BaseDadosGPS.ObterDbValor<decimal>(row["precoBaseCompra"]);
			result.precoBaseVenda = BaseDadosGPS.ObterDbValor<decimal>(row["precoBaseVenda"]);
			result.precoUnitarioUltimaCompra = BaseDadosGPS.ObterDbValor<decimal>(row["precoUnitarioUltimaCompra"]);
			result.dataUltimaCompra = BaseDadosGPS.ObterDbValor<DateTime>(row["dataUltimaCompra"]);
			result.precoUnitarioUltimaVenda = BaseDadosGPS.ObterDbValor<decimal>(row["precoUnitarioUltimaVenda"]);
			result.dataUltimaVenda = BaseDadosGPS.ObterDbValor<DateTime>(row["dataUltimaVenda"]);
			result.precoMedioCompra = BaseDadosGPS.ObterDbValor<decimal>(row["precoMedioCompra"]);
			result.precoMedioVenda = BaseDadosGPS.ObterDbValor<decimal>(row["precoMedioVenda"]);
			result.codigoProcessoControle = BaseDadosGPS.ObterDbValor<int>(row["codigoProcessoControle"]);
			result.isControleRecebimento = BaseDadosGPS.ObterDbValor<bool>(row["isControleRecebimento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_produto as referenciaProduto, ");
		stringBuilder.Append("cd_tipo_produto as codigoTipoProduto, ");
		stringBuilder.Append("vl_dimensao_01 as dimensao01, ");
		stringBuilder.Append("vl_dimensao_02 as dimensao02, ");
		stringBuilder.Append("vl_dimensao_03 as dimensao03, ");
		stringBuilder.Append("vl_dimensao_04 as dimensao04, ");
		stringBuilder.Append("ic_fabricado as isFabricado, ");
		stringBuilder.Append("ic_comprado as isComprado, ");
		stringBuilder.Append("ic_materia as isMateriaPrima, ");
		stringBuilder.Append("nm_produto as descricaoProduto, ");
		stringBuilder.Append("cd_familia as codigoFamilia, ");
		stringBuilder.Append("cd_subfamilia as codigoSubfamilia, ");
		stringBuilder.Append("cd_almoxarifado as codigoAlmoxarifado, ");
		stringBuilder.Append("cd_compartimento as codigoCompartimento, ");
		stringBuilder.Append("cd_classificacao_fis as codigoClassificacaoFiscal, ");
		stringBuilder.Append("im_produto as imagem, ");
		stringBuilder.Append("cd_desenho as desenho, ");
		stringBuilder.Append("cd_revisao_desenho as revisaoDesenho, ");
		stringBuilder.Append("cd_conta_contabil as codigoContaContabil, ");
		stringBuilder.Append("ic_gestao_lote as isGerenciaLote, ");
		stringBuilder.Append("cd_unidade_estoque as codigoUnidadeEstoque, ");
		stringBuilder.Append("cd_unidade_compra as codigoUnidadeCompra, ");
		stringBuilder.Append("vl_coeficiente_conve as coeficienteConversaoUnidades, ");
		stringBuilder.Append("vl_peso_produto as peso, ");
		stringBuilder.Append("vl_comprimento_padra as tamanhoPadrao, ");
		stringBuilder.Append("vl_quantidade_estoqu as quantidadeEstoque, ");
		stringBuilder.Append("vl_quantidade_reserv as quantidadeReservada, ");
		stringBuilder.Append("vl_quantidade_dispon as quantidadeDisponivel, ");
		stringBuilder.Append("vl_quantidade_reabas as quantidadeReabastecimento, ");
		stringBuilder.Append("vl_lote_economico as loteEconomico, ");
		stringBuilder.Append("vl_estoque_minimo as estoqueMinimo, ");
		stringBuilder.Append("vl_preco_base_compra as precoBaseCompra, ");
		stringBuilder.Append("vl_preco_base_venda as precoBaseVenda, ");
		stringBuilder.Append("vl_unitario_ultima_c as precoUnitarioUltimaCompra, ");
		stringBuilder.Append("dt_ultima_compra as dataUltimaCompra, ");
		stringBuilder.Append("vl_unitario_ultima_v as precoUnitarioUltimaVenda, ");
		stringBuilder.Append("dt_ultima_venda as dataUltimaVenda, ");
		stringBuilder.Append("vl_preco_medio_compr as precoMedioCompra, ");
		stringBuilder.Append("vl_preco_medio_venda as precoMedioVenda, ");
		stringBuilder.Append("cd_processo_controle as codigoProcessoControle, ");
		stringBuilder.Append("ic_controle_recebime as isControleRecebimento");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.EngenhariaProduto ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProduto> ObterTodosTecnicoEngenhariaProduto()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProduto.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.EngenhariaProduto (");
		stringBuilder.Append("cd_produto, ");
		stringBuilder.Append("cd_tipo_produto, ");
		stringBuilder.Append("vl_dimensao_01, ");
		stringBuilder.Append("vl_dimensao_02, ");
		stringBuilder.Append("vl_dimensao_03, ");
		stringBuilder.Append("vl_dimensao_04, ");
		stringBuilder.Append("ic_fabricado, ");
		stringBuilder.Append("ic_comprado, ");
		stringBuilder.Append("ic_materia, ");
		stringBuilder.Append("nm_produto, ");
		stringBuilder.Append("cd_familia, ");
		stringBuilder.Append("cd_subfamilia, ");
		stringBuilder.Append("cd_almoxarifado, ");
		stringBuilder.Append("cd_compartimento, ");
		stringBuilder.Append("cd_classificacao_fis, ");
		stringBuilder.Append("im_produto, ");
		stringBuilder.Append("cd_desenho, ");
		stringBuilder.Append("cd_revisao_desenho, ");
		stringBuilder.Append("cd_conta_contabil, ");
		stringBuilder.Append("ic_gestao_lote, ");
		stringBuilder.Append("cd_unidade_estoque, ");
		stringBuilder.Append("cd_unidade_compra, ");
		stringBuilder.Append("vl_coeficiente_conve, ");
		stringBuilder.Append("vl_peso_produto, ");
		stringBuilder.Append("vl_comprimento_padra, ");
		stringBuilder.Append("vl_quantidade_estoqu, ");
		stringBuilder.Append("vl_quantidade_reserv, ");
		stringBuilder.Append("vl_quantidade_dispon, ");
		stringBuilder.Append("vl_quantidade_reabas, ");
		stringBuilder.Append("vl_lote_economico, ");
		stringBuilder.Append("vl_estoque_minimo, ");
		stringBuilder.Append("vl_preco_base_compra, ");
		stringBuilder.Append("vl_preco_base_venda, ");
		stringBuilder.Append("vl_unitario_ultima_c, ");
		stringBuilder.Append("dt_ultima_compra, ");
		stringBuilder.Append("vl_unitario_ultima_v, ");
		stringBuilder.Append("dt_ultima_venda, ");
		stringBuilder.Append("vl_preco_medio_compr, ");
		stringBuilder.Append("vl_preco_medio_venda, ");
		stringBuilder.Append("cd_processo_controle, ");
		stringBuilder.Append("ic_controle_recebime) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_produto", TecnicoEngenhariaProduto.referenciaProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_tipo_produto", TecnicoEngenhariaProduto.codigoTipoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dimensao_01", TecnicoEngenhariaProduto.dimensao01));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dimensao_02", TecnicoEngenhariaProduto.dimensao02));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dimensao_03", TecnicoEngenhariaProduto.dimensao03));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dimensao_04", TecnicoEngenhariaProduto.dimensao04));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_fabricado", TecnicoEngenhariaProduto.isFabricado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_comprado", TecnicoEngenhariaProduto.isComprado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_materia", TecnicoEngenhariaProduto.isMateriaPrima));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_produto", TecnicoEngenhariaProduto.descricaoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_familia", TecnicoEngenhariaProduto.codigoFamilia));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_subfamilia", TecnicoEngenhariaProduto.codigoSubfamilia));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_almoxarifado", TecnicoEngenhariaProduto.codigoAlmoxarifado));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_compartimento", TecnicoEngenhariaProduto.codigoCompartimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_classificacao_fis", TecnicoEngenhariaProduto.codigoClassificacaoFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("im_produto", TecnicoEngenhariaProduto.imagem));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_desenho", TecnicoEngenhariaProduto.desenho));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_revisao_desenho", TecnicoEngenhariaProduto.revisaoDesenho));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_conta_contabil", TecnicoEngenhariaProduto.codigoContaContabil));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_gestao_lote", TecnicoEngenhariaProduto.isGerenciaLote));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_unidade_estoque", TecnicoEngenhariaProduto.codigoUnidadeEstoque));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_unidade_compra", TecnicoEngenhariaProduto.codigoUnidadeCompra));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_coeficiente_conve", TecnicoEngenhariaProduto.coeficienteConversaoUnidades));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_peso_produto", TecnicoEngenhariaProduto.peso));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_comprimento_padra", TecnicoEngenhariaProduto.tamanhoPadrao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_estoqu", TecnicoEngenhariaProduto.quantidadeEstoque));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_reserv", TecnicoEngenhariaProduto.quantidadeReservada));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_dispon", TecnicoEngenhariaProduto.quantidadeDisponivel));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_reabas", TecnicoEngenhariaProduto.quantidadeReabastecimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_lote_economico", TecnicoEngenhariaProduto.loteEconomico));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_estoque_minimo", TecnicoEngenhariaProduto.estoqueMinimo));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_preco_base_compra", TecnicoEngenhariaProduto.precoBaseCompra));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_preco_base_venda", TecnicoEngenhariaProduto.precoBaseVenda));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_unitario_ultima_c", TecnicoEngenhariaProduto.precoUnitarioUltimaCompra));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_ultima_compra", TecnicoEngenhariaProduto.dataUltimaCompra));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_unitario_ultima_v", TecnicoEngenhariaProduto.precoUnitarioUltimaVenda));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_ultima_venda", TecnicoEngenhariaProduto.dataUltimaVenda));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_preco_medio_compr", TecnicoEngenhariaProduto.precoMedioCompra));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_preco_medio_venda", TecnicoEngenhariaProduto.precoMedioVenda));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_processo_controle", TecnicoEngenhariaProduto.codigoProcessoControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_controle_recebime", TecnicoEngenhariaProduto.isControleRecebimento));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto TecnicoEngenhariaProduto, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.EngenhariaProduto Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ReferenciaProduto", "cd_produto", TecnicoEngenhariaProduto.referenciaProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProduto", "cd_tipo_produto", TecnicoEngenhariaProduto.codigoTipoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Dimensao01", "vl_dimensao_01", TecnicoEngenhariaProduto.dimensao01, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Dimensao02", "vl_dimensao_02", TecnicoEngenhariaProduto.dimensao02, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Dimensao03", "vl_dimensao_03", TecnicoEngenhariaProduto.dimensao03, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Dimensao04", "vl_dimensao_04", TecnicoEngenhariaProduto.dimensao04, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsFabricado", "ic_fabricado", TecnicoEngenhariaProduto.isFabricado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsComprado", "ic_comprado", TecnicoEngenhariaProduto.isComprado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsMateriaPrima", "ic_materia", TecnicoEngenhariaProduto.isMateriaPrima, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoProduto", "nm_produto", TecnicoEngenhariaProduto.descricaoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFamilia", "cd_familia", TecnicoEngenhariaProduto.codigoFamilia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoSubfamilia", "cd_subfamilia", TecnicoEngenhariaProduto.codigoSubfamilia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "cd_almoxarifado", TecnicoEngenhariaProduto.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCompartimento", "cd_compartimento", TecnicoEngenhariaProduto.codigoCompartimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoClassificacaoFiscal", "cd_classificacao_fis", TecnicoEngenhariaProduto.codigoClassificacaoFiscal, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_produto", TecnicoEngenhariaProduto.imagem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Desenho", "cd_desenho", TecnicoEngenhariaProduto.desenho, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "RevisaoDesenho", "cd_revisao_desenho", TecnicoEngenhariaProduto.revisaoDesenho, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "cd_conta_contabil", TecnicoEngenhariaProduto.codigoContaContabil, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsGerenciaLote", "ic_gestao_lote", TecnicoEngenhariaProduto.isGerenciaLote, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeEstoque", "cd_unidade_estoque", TecnicoEngenhariaProduto.codigoUnidadeEstoque, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeCompra", "cd_unidade_compra", TecnicoEngenhariaProduto.codigoUnidadeCompra, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CoeficienteConversaoUnidades", "vl_coeficiente_conve", TecnicoEngenhariaProduto.coeficienteConversaoUnidades, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Peso", "vl_peso_produto", TecnicoEngenhariaProduto.peso, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TamanhoPadrao", "vl_comprimento_padra", TecnicoEngenhariaProduto.tamanhoPadrao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeEstoque", "vl_quantidade_estoqu", TecnicoEngenhariaProduto.quantidadeEstoque, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeReservada", "vl_quantidade_reserv", TecnicoEngenhariaProduto.quantidadeReservada, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeDisponivel", "vl_quantidade_dispon", TecnicoEngenhariaProduto.quantidadeDisponivel, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeReabastecimento", "vl_quantidade_reabas", TecnicoEngenhariaProduto.quantidadeReabastecimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "LoteEconomico", "vl_lote_economico", TecnicoEngenhariaProduto.loteEconomico, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "EstoqueMinimo", "vl_estoque_minimo", TecnicoEngenhariaProduto.estoqueMinimo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoBaseCompra", "vl_preco_base_compra", TecnicoEngenhariaProduto.precoBaseCompra, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoBaseVenda", "vl_preco_base_venda", TecnicoEngenhariaProduto.precoBaseVenda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoUnitarioUltimaCompra", "vl_unitario_ultima_c", TecnicoEngenhariaProduto.precoUnitarioUltimaCompra, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataUltimaCompra", "dt_ultima_compra", TecnicoEngenhariaProduto.dataUltimaCompra, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoUnitarioUltimaVenda", "vl_unitario_ultima_v", TecnicoEngenhariaProduto.precoUnitarioUltimaVenda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataUltimaVenda", "dt_ultima_venda", TecnicoEngenhariaProduto.dataUltimaVenda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoMedioCompra", "vl_preco_medio_compr", TecnicoEngenhariaProduto.precoMedioCompra, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PrecoMedioVenda", "vl_preco_medio_venda", TecnicoEngenhariaProduto.precoMedioVenda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProcessoControle", "cd_processo_controle", TecnicoEngenhariaProduto.codigoProcessoControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsControleRecebimento", "ic_controle_recebime", TecnicoEngenhariaProduto.isControleRecebimento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProduto.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProduto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.EngenhariaProduto ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
