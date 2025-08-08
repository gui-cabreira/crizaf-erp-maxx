using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProduto
{
	public int id;

	public string referenciaProduto;

	public int codigoTipoProduto;

	public decimal dimensao01;

	public decimal dimensao02;

	public decimal dimensao03;

	public decimal dimensao04;

	public bool isFabricado;

	public bool isComprado;

	public bool isMateriaPrima;

	public string descricaoProduto;

	public int codigoFamilia;

	public int codigoSubfamilia;

	public int codigoAlmoxarifado;

	public int codigoCompartimento;

	public int codigoClassificacaoFiscal;

	public Image imagem;

	public string desenho;

	public string revisaoDesenho;

	public int codigoContaContabil;

	public bool isGerenciaLote;

	public int codigoUnidadeEstoque;

	public int codigoUnidadeCompra;

	public decimal coeficienteConversaoUnidades;

	public decimal peso;

	public decimal tamanhoPadrao;

	public decimal quantidadeEstoque;

	public decimal quantidadeReservada;

	public decimal quantidadeDisponivel;

	public decimal quantidadeReabastecimento;

	public decimal loteEconomico;

	public decimal estoqueMinimo;

	public decimal precoBaseCompra;

	public decimal precoBaseVenda;

	public decimal precoUnitarioUltimaCompra;

	public DateTime dataUltimaCompra;

	public decimal precoUnitarioUltimaVenda;

	public DateTime dataUltimaVenda;

	public decimal precoMedioCompra;

	public decimal precoMedioVenda;

	public int codigoProcessoControle;

	public bool isControleRecebimento;
}
