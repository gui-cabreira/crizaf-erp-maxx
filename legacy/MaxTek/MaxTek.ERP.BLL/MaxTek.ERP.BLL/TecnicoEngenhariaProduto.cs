using System;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProduto : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProduto _dados;

	private TecnicoEngenhariaProdutoFamilia _familia;

	private TecnicoEngenhariaProdutoAlmoxarifado _almoxarifado;

	private TecnicoEngenhariaProdutoTipo _tipo;

	public int Id
	{
		get
		{
			return _dados.id;
		}
		set
		{
			if (_dados.id != value)
			{
				_dados.id = value;
				PropertyHasChanged();
			}
		}
	}

	public string ReferenciaProduto
	{
		get
		{
			return _dados.referenciaProduto;
		}
		set
		{
			if (_dados.referenciaProduto != value)
			{
				_dados.referenciaProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoProduto
	{
		get
		{
			return _dados.codigoTipoProduto;
		}
		set
		{
			if (_dados.codigoTipoProduto != value)
			{
				_dados.codigoTipoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao01
	{
		get
		{
			return _dados.dimensao01;
		}
		set
		{
			if (_dados.dimensao01 != value)
			{
				_dados.dimensao01 = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao02
	{
		get
		{
			return _dados.dimensao02;
		}
		set
		{
			if (_dados.dimensao02 != value)
			{
				_dados.dimensao02 = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao03
	{
		get
		{
			return _dados.dimensao03;
		}
		set
		{
			if (_dados.dimensao03 != value)
			{
				_dados.dimensao03 = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao04
	{
		get
		{
			return _dados.dimensao04;
		}
		set
		{
			if (_dados.dimensao04 != value)
			{
				_dados.dimensao04 = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFabricado
	{
		get
		{
			return _dados.isFabricado;
		}
		set
		{
			if (_dados.isFabricado != value)
			{
				_dados.isFabricado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsComprado
	{
		get
		{
			return _dados.isComprado;
		}
		set
		{
			if (_dados.isComprado != value)
			{
				_dados.isComprado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsMateriaPrima
	{
		get
		{
			return _dados.isMateriaPrima;
		}
		set
		{
			if (_dados.isMateriaPrima != value)
			{
				_dados.isMateriaPrima = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoProduto
	{
		get
		{
			return _dados.descricaoProduto;
		}
		set
		{
			if (_dados.descricaoProduto != value)
			{
				_dados.descricaoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFamilia
	{
		get
		{
			return _dados.codigoFamilia;
		}
		set
		{
			if (_dados.codigoFamilia != value)
			{
				_dados.codigoFamilia = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSubfamilia
	{
		get
		{
			return _dados.codigoSubfamilia;
		}
		set
		{
			if (_dados.codigoSubfamilia != value)
			{
				_dados.codigoSubfamilia = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoAlmoxarifado
	{
		get
		{
			return _dados.codigoAlmoxarifado;
		}
		set
		{
			if (_dados.codigoAlmoxarifado != value)
			{
				_dados.codigoAlmoxarifado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCompartimento
	{
		get
		{
			return _dados.codigoCompartimento;
		}
		set
		{
			if (_dados.codigoCompartimento != value)
			{
				_dados.codigoCompartimento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoClassificacaoFiscal
	{
		get
		{
			return _dados.codigoClassificacaoFiscal;
		}
		set
		{
			if (_dados.codigoClassificacaoFiscal != value)
			{
				_dados.codigoClassificacaoFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public Image Imagem
	{
		get
		{
			return _dados.imagem;
		}
		set
		{
			if (_dados.imagem != value)
			{
				_dados.imagem = value;
				PropertyHasChanged();
			}
		}
	}

	public string Desenho
	{
		get
		{
			return _dados.desenho;
		}
		set
		{
			if (_dados.desenho != value)
			{
				_dados.desenho = value;
				PropertyHasChanged();
			}
		}
	}

	public string RevisaoDesenho
	{
		get
		{
			return _dados.revisaoDesenho;
		}
		set
		{
			if (_dados.revisaoDesenho != value)
			{
				_dados.revisaoDesenho = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoContaContabil
	{
		get
		{
			return _dados.codigoContaContabil;
		}
		set
		{
			if (_dados.codigoContaContabil != value)
			{
				_dados.codigoContaContabil = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsGerenciaLote
	{
		get
		{
			return _dados.isGerenciaLote;
		}
		set
		{
			if (_dados.isGerenciaLote != value)
			{
				_dados.isGerenciaLote = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeEstoque
	{
		get
		{
			return _dados.codigoUnidadeEstoque;
		}
		set
		{
			if (_dados.codigoUnidadeEstoque != value)
			{
				_dados.codigoUnidadeEstoque = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeCompra
	{
		get
		{
			return _dados.codigoUnidadeCompra;
		}
		set
		{
			if (_dados.codigoUnidadeCompra != value)
			{
				_dados.codigoUnidadeCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CoeficienteConversaoUnidades
	{
		get
		{
			return _dados.coeficienteConversaoUnidades;
		}
		set
		{
			if (_dados.coeficienteConversaoUnidades != value)
			{
				_dados.coeficienteConversaoUnidades = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Peso
	{
		get
		{
			return _dados.peso;
		}
		set
		{
			if (_dados.peso != value)
			{
				_dados.peso = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TamanhoPadrao
	{
		get
		{
			return _dados.tamanhoPadrao;
		}
		set
		{
			if (_dados.tamanhoPadrao != value)
			{
				_dados.tamanhoPadrao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeEstoque
	{
		get
		{
			return _dados.quantidadeEstoque;
		}
		set
		{
			if (_dados.quantidadeEstoque != value)
			{
				_dados.quantidadeEstoque = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeReservada
	{
		get
		{
			return _dados.quantidadeReservada;
		}
		set
		{
			if (_dados.quantidadeReservada != value)
			{
				_dados.quantidadeReservada = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeDisponivel
	{
		get
		{
			return _dados.quantidadeDisponivel;
		}
		set
		{
			if (_dados.quantidadeDisponivel != value)
			{
				_dados.quantidadeDisponivel = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeReabastecimento
	{
		get
		{
			return _dados.quantidadeReabastecimento;
		}
		set
		{
			if (_dados.quantidadeReabastecimento != value)
			{
				_dados.quantidadeReabastecimento = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal LoteEconomico
	{
		get
		{
			return _dados.loteEconomico;
		}
		set
		{
			if (_dados.loteEconomico != value)
			{
				_dados.loteEconomico = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal EstoqueMinimo
	{
		get
		{
			return _dados.estoqueMinimo;
		}
		set
		{
			if (_dados.estoqueMinimo != value)
			{
				_dados.estoqueMinimo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoBaseCompra
	{
		get
		{
			return _dados.precoBaseCompra;
		}
		set
		{
			if (_dados.precoBaseCompra != value)
			{
				_dados.precoBaseCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoBaseVenda
	{
		get
		{
			return _dados.precoBaseVenda;
		}
		set
		{
			if (_dados.precoBaseVenda != value)
			{
				_dados.precoBaseVenda = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoUnitarioUltimaCompra
	{
		get
		{
			return _dados.precoUnitarioUltimaCompra;
		}
		set
		{
			if (_dados.precoUnitarioUltimaCompra != value)
			{
				_dados.precoUnitarioUltimaCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataUltimaCompra
	{
		get
		{
			return _dados.dataUltimaCompra;
		}
		set
		{
			if (_dados.dataUltimaCompra != value)
			{
				_dados.dataUltimaCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoUnitarioUltimaVenda
	{
		get
		{
			return _dados.precoUnitarioUltimaVenda;
		}
		set
		{
			if (_dados.precoUnitarioUltimaVenda != value)
			{
				_dados.precoUnitarioUltimaVenda = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataUltimaVenda
	{
		get
		{
			return _dados.dataUltimaVenda;
		}
		set
		{
			if (_dados.dataUltimaVenda != value)
			{
				_dados.dataUltimaVenda = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoMedioCompra
	{
		get
		{
			return _dados.precoMedioCompra;
		}
		set
		{
			if (_dados.precoMedioCompra != value)
			{
				_dados.precoMedioCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PrecoMedioVenda
	{
		get
		{
			return _dados.precoMedioVenda;
		}
		set
		{
			if (_dados.precoMedioVenda != value)
			{
				_dados.precoMedioVenda = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoProcessoControle
	{
		get
		{
			return _dados.codigoProcessoControle;
		}
		set
		{
			if (_dados.codigoProcessoControle != value)
			{
				_dados.codigoProcessoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsControleRecebimento
	{
		get
		{
			return _dados.isControleRecebimento;
		}
		set
		{
			if (_dados.isControleRecebimento != value)
			{
				_dados.isControleRecebimento = value;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProdutoFamilia Familia
	{
		get
		{
			if (_dados.codigoFamilia > 0 && _familia == null)
			{
				_familia = ModuloTecnicoEngenhariaProduto.ObterTecnicoEngenhariaProdutoFamilia(_dados.codigoFamilia);
			}
			return _familia;
		}
		set
		{
			if (_familia != value)
			{
				_familia = value;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProdutoAlmoxarifado Almoxarifado
	{
		get
		{
			if (_dados.codigoAlmoxarifado > 0 && _almoxarifado == null)
			{
				_almoxarifado = ModuloTecnicoEngenhariaProduto.ObterTecnicoEngenhariaProdutoAlmoxarifado(_dados.codigoAlmoxarifado);
			}
			return _almoxarifado;
		}
		set
		{
			if (_almoxarifado != value)
			{
				_almoxarifado = value;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProdutoTipo Tipo
	{
		get
		{
			if (_dados.codigoTipoProduto > 0 && _tipo == null)
			{
				_tipo = ModuloTecnicoEngenhariaProduto.ObterTecnicoEngenhariaProdutoTipo(_dados.codigoTipoProduto);
			}
			return _tipo;
		}
		set
		{
			if (_tipo != value)
			{
				_tipo = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProduto);
		_familia = null;
		_almoxarifado = null;
		_tipo = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProduto()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProduto(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProduto)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
