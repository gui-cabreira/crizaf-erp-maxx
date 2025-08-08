namespace MaxTek.ERP.DAL;

public abstract class ProviderFactory
{
	public abstract IDesenvolvimentoClasse DesenvolvimentoClasseDAO { get; }

	public abstract IDesenvolvimentoClasseCampos DesenvolvimentoClasseCamposDAO { get; }

	public abstract IBussinessInteligence BussinessInteligenceDAO { get; }

	public abstract ICampos CamposDAO { get; }

	public abstract IClasse ClasseDAO { get; }

	public abstract ITabelas TabelasDAO { get; }

	public abstract ISistemaUsuarios SistemaUsuariosDAO { get; }

	public abstract IIndices IndicesDAO { get; }

	public abstract ICriarBaseDados SqlCriarBaseDadosDAO { get; }

	public abstract IComercialEntidade ComercialEntidadeDAO { get; }

	public abstract IComercialEntidadeContato ComercialEntidadeContatoDAO { get; }

	public abstract IComercialEntidadeEspecialidade ComercialEntidadeEspecialidadeDAO { get; }

	public abstract IComercialEntidadeEvento ComercialEntidadeEventoDAO { get; }

	public abstract IComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEnderecoDAO { get; }

	public abstract IComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimentoDAO { get; }

	public abstract IComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamentoDAO { get; }

	public abstract IComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamentoDAO { get; }

	public abstract IComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscalDAO { get; }

	public abstract IComercialFiscalContaContabil ComercialFiscalContaContabilDAO { get; }

	public abstract IComercialVendasPedidos ComercialVendasPedidosDAO { get; }

	public abstract IComercialVendasPedidosItens ComercialVendasPedidosItensDAO { get; }

	public abstract IComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadenciaDAO { get; }

	public abstract IComercialVendasCatalogos ComercialVendasCatalogosDAO { get; }

	public abstract IComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigosDAO { get; }

	public abstract IQualidadeCertificacao QualidadeCertificacaoDAO { get; }

	public abstract IQualidadeEmbarqueControlado QualidadeEmbarqueControladoDAO { get; }

	public abstract IRHFuncionario RHFuncionarioDAO { get; }

	public abstract ITecnicoEngenhariaProduto TecnicoEngenhariaProdutoDAO { get; }

	public abstract ITecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifadoDAO { get; }

	public abstract ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO { get; }

	public abstract ITecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamiliaDAO { get; }

	public abstract ITecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamiliaDAO { get; }

	public abstract ITecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipoDAO { get; }

	public abstract ITecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidadeDAO { get; }

	public abstract ITecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControleDAO { get; }

	public abstract ITecnicoEngenhariaProcesso TecnicoEngenhariaProcessoDAO { get; }

	public abstract ITecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateriaDAO { get; }

	public abstract ITecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacaoDAO { get; }

	public abstract ITecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramentaDAO { get; }

	public abstract ITecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisaoDAO { get; }

	public abstract ITecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisaoDAO { get; }

	public abstract ITecnicoProducaoApontamento TecnicoProducaoApontamentoDAO { get; }

	public abstract ITecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamentoDAO { get; }

	public abstract IWorkFlowTarefa WorkFlowTarefaDAO { get; }

	public abstract IFinanceiroTitulos FinanceiroTitulosDAO { get; }

	public abstract IFinanceiroBancos FinanceiroBancosDAO { get; }

	public abstract INotaFiscalFatura NotaFiscalFaturaDAO { get; }

	public abstract INotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederaisDAO { get; }

	public abstract INotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPIDAO { get; }

	public abstract INotaFiscalPaises NotaFiscalPaisesDAO { get; }

	public abstract INotaFiscalWebServices NotaFiscalWebServicesDAO { get; }

	public abstract INotaFiscalUF NotaFiscalUFDAO { get; }

	public abstract INotaFiscalCidades NotaFiscalCidadesDAO { get; }

	public abstract INotaFiscalSerie NotaFiscalSerieDAO { get; }

	public abstract INotaFiscalCFOPs NotaFiscalCFOPsDAO { get; }

	public abstract INotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculoDAO { get; }

	public abstract INotaFiscalModalidadeBaseCalculoICMSST NotaFiscalModalidadeBaseCalculoICMSSTDAO { get; }

	public abstract INotaFiscalNotasFiscais NotaFiscalNotasFiscaisDAO { get; }

	public abstract INotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItensDAO { get; }

	public abstract INotaFiscalTextosLegais NotaFiscalTextosLegaisDAO { get; }

	public abstract INotaFiscalTipoIncidencia NotaFiscalTipoIncidenciaDAO { get; }

	public abstract INotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImpostoDAO { get; }

	public abstract INotaFiscalOrigemProduto NotaFiscalOrigemProdutoDAO { get; }

	public abstract INotaFiscalFormasPagto NotaFiscalFormasPagtoDAO { get; }

	public abstract INotaFiscalResumoFaturamento NotaFiscalResumoFaturamentoDAO { get; }

	public abstract INotasFiscaisEventos NotasFiscaisEventosDAO { get; }

	public abstract INotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDIDAO { get; }

	public abstract INotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoesDAO { get; }

	public abstract INotaFiscalInutilizacao NotaFiscalInutilizacaoDAO { get; }

	public abstract INotaFiscalCest NotaFiscalCestDAO { get; }

	public abstract INotaFiscalNotaReferenciada NotaFiscalNotaReferenciadaDAO { get; }

	public abstract IParametrosSociedade ParametrosSociedadeDAO { get; }
}
