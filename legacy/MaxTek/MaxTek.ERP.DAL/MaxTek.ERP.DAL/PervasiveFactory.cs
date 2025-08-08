using System;

namespace MaxTek.ERP.DAL;

public class PervasiveFactory : ProviderFactory
{
	public override IDesenvolvimentoClasse DesenvolvimentoClasseDAO => new PervasiveDesenvolvimentoClasse();

	public override IDesenvolvimentoClasseCampos DesenvolvimentoClasseCamposDAO => new PervasiveDesenvolvimentoClasseCampos();

	public override ICampos CamposDAO
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public override IClasse ClasseDAO
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public override ITabelas TabelasDAO
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public override ISistemaUsuarios SistemaUsuariosDAO => new PervasiveSistemaUsuarios();

	public override IIndices IndicesDAO
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public override ICriarBaseDados SqlCriarBaseDadosDAO
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override IComercialEntidade ComercialEntidadeDAO => new PervasiveComercialEntidade();

	public override IComercialEntidadeContato ComercialEntidadeContatoDAO => new PervasiveComercialEntidadeContato();

	public override IComercialEntidadeEspecialidade ComercialEntidadeEspecialidadeDAO => new PervasiveComercialEntidadeEspecialidade();

	public override IComercialEntidadeEvento ComercialEntidadeEventoDAO => new PervasiveComercialEntidadeEvento();

	public override IComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEnderecoDAO => new PervasiveComercialEntidadeLigacaoEndereco();

	public override IComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimentoDAO => new PervasiveComercialEntidadeTipoAtendimento();

	public override IComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamentoDAO => new PervasiveComercialFinanceiroCondicaoPagamento();

	public override IComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamentoDAO => new PervasiveComercialFinanceiroModoPagamento();

	public override IComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscalDAO => new PervasiveComercialFiscalClassificacaoFiscal();

	public override IComercialFiscalContaContabil ComercialFiscalContaContabilDAO => new PervasiveComercialFiscalContaContabil();

	public override IComercialVendasPedidos ComercialVendasPedidosDAO => new PervasiveComercialVendasPedidos();

	public override IComercialVendasPedidosItens ComercialVendasPedidosItensDAO => new PervasiveComercialVendasPedidosItens();

	public override IComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadenciaDAO => new PervasiveComercialVendasPedidosItensCadencia();

	public override IComercialVendasCatalogos ComercialVendasCatalogosDAO => new PervasiveComercialVendasCatalogos();

	public override IComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigosDAO => new PervasiveComercialVendasCatalogosCodigos();

	public override IQualidadeCertificacao QualidadeCertificacaoDAO => new PervasiveQualidadeCertificacao();

	public override IQualidadeEmbarqueControlado QualidadeEmbarqueControladoDAO => new PervasiveQualidadeEmbarqueControlado();

	public override IRHFuncionario RHFuncionarioDAO => new PervasiveRHFuncionario();

	public override ITecnicoEngenhariaProduto TecnicoEngenhariaProdutoDAO => new PervasiveTecnicoEngenhariaProduto();

	public override ITecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifadoDAO => new PervasiveTecnicoEngenhariaProdutoAlmoxarifado();

	public override ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO => new PervasiveTecnicoEngenhariaProdutoAlmoxarifadoCompartimento();

	public override ITecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamiliaDAO => new PervasiveTecnicoEngenhariaProdutoFamilia();

	public override ITecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamiliaDAO => new PervasiveTecnicoEngenhariaProdutoSubfamilia();

	public override ITecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipoDAO => new PervasiveTecnicoEngenhariaProdutoTipo();

	public override ITecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidadeDAO => new PervasiveTecnicoEngenhariaProdutoUnidade();

	public override ITecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControleDAO => new PervasiveTecnicoEngenhariaProcessoControle();

	public override ITecnicoEngenhariaProcesso TecnicoEngenhariaProcessoDAO => new PervasiveTecnicoEngenhariaProcesso();

	public override ITecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateriaDAO => new PervasiveTecnicoEngenhariaProcessoMateria();

	public override ITecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacaoDAO => new PervasiveTecnicoEngenhariaProcessoOperacao();

	public override ITecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramentaDAO => new PervasiveTecnicoEngenhariaProcessoOperacaoFerramenta();

	public override ITecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisaoDAO => new PervasiveTecnicoEngenhariaProcessoOperacaoRevisao();

	public override ITecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisaoDAO => new PervasiveTecnicoEngenhariaProcessoRevisao();

	public override ITecnicoProducaoApontamento TecnicoProducaoApontamentoDAO => new PervasiveTecnicoProducaoApontamento();

	public override ITecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamentoDAO => new PervasiveTecnicoProducaoEstatisticasApontamento();

	public override IWorkFlowTarefa WorkFlowTarefaDAO => new PervasiveWorkFlowTarefa();

	public override IFinanceiroTitulos FinanceiroTitulosDAO => new PervasiveFinanceiroTitulos();

	public override IFinanceiroBancos FinanceiroBancosDAO => new PervasiveFinanceiroBancos();

	public override INotaFiscalCFOPs NotaFiscalCFOPsDAO => new PervasiveNotaFiscalCFOPs();

	public override INotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculoDAO => new PervasiveNotaFiscalModalidadeBaseCalculo();

	public override INotaFiscalModalidadeBaseCalculoICMSST NotaFiscalModalidadeBaseCalculoICMSSTDAO => new PervasiveNotaFiscalModalidadeBaseCalculoICMSST();

	public override INotaFiscalNotasFiscais NotaFiscalNotasFiscaisDAO => new PervasiveNotaFiscalNotasFiscais();

	public override INotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItensDAO => new PervasiveNotaFiscalNotasFiscaisItens();

	public override INotaFiscalTextosLegais NotaFiscalTextosLegaisDAO => new PervasiveNotaFiscalTextosLegais();

	public override INotaFiscalTipoIncidencia NotaFiscalTipoIncidenciaDAO => new PervasiveNotaFiscalTipoIncidencia();

	public override INotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImpostoDAO => new PervasiveNotaFiscalTipoRetencaoImposto();

	public override INotaFiscalOrigemProduto NotaFiscalOrigemProdutoDAO => new PervasiveNotaFiscalOrigemProduto();

	public override INotaFiscalFormasPagto NotaFiscalFormasPagtoDAO => new PervasiveNotaFiscalFormasPagto();

	public override INotaFiscalSerie NotaFiscalSerieDAO => new PervasiveNotaFiscalSerie();

	public override INotaFiscalUF NotaFiscalUFDAO => new PervasiveNotaFiscalUF();

	public override INotaFiscalCidades NotaFiscalCidadesDAO => new PervasiveNotaFiscalCidades();

	public override INotaFiscalWebServices NotaFiscalWebServicesDAO => new PervasiveNotaFiscalWebServices();

	public override INotaFiscalPaises NotaFiscalPaisesDAO => new PervasiveNotaFiscalPaises();

	public override INotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederaisDAO => new PervasiveNotaFiscalTipoIncidenciaImpostosFederais();

	public override INotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPIDAO => new PervasiveNotaFiscalTipoIncidenciaIPI();

	public override INotaFiscalFatura NotaFiscalFaturaDAO => new PervasiveNotaFiscalFatura();

	public override INotaFiscalResumoFaturamento NotaFiscalResumoFaturamentoDAO => new PervasiveNotaFiscalResumoFaturamento();

	public override INotasFiscaisEventos NotasFiscaisEventosDAO => new PervasiveNotasFiscaisEventos();

	public override INotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDIDAO => new PervasiveNotaFiscalNotasFiscaisItensDI();

	public override INotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoesDAO => new PervasiveNotaFiscalNotasFiscaisItensDIAdicoes();

	public override INotaFiscalInutilizacao NotaFiscalInutilizacaoDAO => new PervasiveNotaFiscalInutilizacao();

	public override INotaFiscalCest NotaFiscalCestDAO => new PervasiveNotaFiscalCest();

	public override INotaFiscalNotaReferenciada NotaFiscalNotaReferenciadaDAO => new PervasiveNotaFiscalNotaReferenciada();

	public override IParametrosSociedade ParametrosSociedadeDAO => new PervasiveParametrosSociedade();

	public override IBussinessInteligence BussinessInteligenceDAO
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}
