namespace MaxTek.ERP.DAL;

public class SqlServerFactory : ProviderFactory
{
	public override IDesenvolvimentoClasse DesenvolvimentoClasseDAO => new SQLServerDesenvolvimentoClasse();

	public override IDesenvolvimentoClasseCampos DesenvolvimentoClasseCamposDAO => new SQLServerDesenvolvimentoClasseCampos();

	public override IBussinessInteligence BussinessInteligenceDAO => new SQLServerBussinessInteligence();

	public override ICampos CamposDAO => new SqlServerCampos();

	public override IClasse ClasseDAO => new SqlServerClasse();

	public override ITabelas TabelasDAO => new SqlServerTabelas();

	public override ISistemaUsuarios SistemaUsuariosDAO => new SQLServerSistemaUsuarios();

	public override IIndices IndicesDAO => new SqlServerIndices();

	public override ICriarBaseDados SqlCriarBaseDadosDAO => new SqlCriarBaseDados();

	public override IComercialEntidade ComercialEntidadeDAO => new SQLServerComercialEntidade();

	public override IComercialEntidadeContato ComercialEntidadeContatoDAO => new SQLServerComercialEntidadeContato();

	public override IComercialEntidadeEspecialidade ComercialEntidadeEspecialidadeDAO => new SQLServerComercialEntidadeEspecialidade();

	public override IComercialEntidadeEvento ComercialEntidadeEventoDAO => new SQLServerComercialEntidadeEvento();

	public override IComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEnderecoDAO => new SQLServerComercialEntidadeLigacaoEndereco();

	public override IComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimentoDAO => new SQLServerComercialEntidadeTipoAtendimento();

	public override IComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamentoDAO => new SQLServerComercialFinanceiroCondicaoPagamento();

	public override IComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamentoDAO => new SQLServerComercialFinanceiroModoPagamento();

	public override IComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscalDAO => new SQLServerComercialFiscalClassificacaoFiscal();

	public override IComercialFiscalContaContabil ComercialFiscalContaContabilDAO => new SQLServerComercialFiscalContaContabil();

	public override IComercialVendasPedidos ComercialVendasPedidosDAO => new SQLServerComercialVendasPedidos();

	public override IComercialVendasPedidosItens ComercialVendasPedidosItensDAO => new SQLServerComercialVendasPedidosItens();

	public override IComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadenciaDAO => new SQLServerComercialVendasPedidosItensCadencia();

	public override IComercialVendasCatalogos ComercialVendasCatalogosDAO => new SQLServerComercialVendasCatalogos();

	public override IComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigosDAO => new SQLServerComercialVendasCatalogosCodigos();

	public override IQualidadeCertificacao QualidadeCertificacaoDAO => new SQLServerQualidadeCertificacao();

	public override IQualidadeEmbarqueControlado QualidadeEmbarqueControladoDAO => new SQLServerQualidadeEmbarqueControlado();

	public override IRHFuncionario RHFuncionarioDAO => new SQLServerRHFuncionario();

	public override ITecnicoEngenhariaProduto TecnicoEngenhariaProdutoDAO => new SQLServerTecnicoEngenhariaProduto();

	public override ITecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifadoDAO => new SQLServerTecnicoEngenhariaProdutoAlmoxarifado();

	public override ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO => new SQLServerTecnicoEngenhariaProdutoAlmoxarifadoCompartimento();

	public override ITecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamiliaDAO => new SQLServerTecnicoEngenhariaProdutoFamilia();

	public override ITecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamiliaDAO => new SQLServerTecnicoEngenhariaProdutoSubfamilia();

	public override ITecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipoDAO => new SQLServerTecnicoEngenhariaProdutoTipo();

	public override ITecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidadeDAO => new SQLServerTecnicoEngenhariaProdutoUnidade();

	public override ITecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControleDAO => new SQLServerTecnicoEngenhariaProcessoControle();

	public override ITecnicoEngenhariaProcesso TecnicoEngenhariaProcessoDAO => new SQLServerTecnicoEngenhariaProcesso();

	public override ITecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateriaDAO => new SQLServerTecnicoEngenhariaProcessoMateria();

	public override ITecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacaoDAO => new SQLServerTecnicoEngenhariaProcessoOperacao();

	public override ITecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramentaDAO => new SQLServerTecnicoEngenhariaProcessoOperacaoFerramenta();

	public override ITecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisaoDAO => new SQLServerTecnicoEngenhariaProcessoOperacaoRevisao();

	public override ITecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisaoDAO => new SQLServerTecnicoEngenhariaProcessoRevisao();

	public override ITecnicoProducaoApontamento TecnicoProducaoApontamentoDAO => new SQLServerTecnicoProducaoApontamento();

	public override ITecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamentoDAO => new SQLServerTecnicoProducaoEstatisticasApontamento();

	public override IWorkFlowTarefa WorkFlowTarefaDAO => new SQLServerWorkFlowTarefa();

	public override IFinanceiroTitulos FinanceiroTitulosDAO => new SQLServerFinanceiroTitulos();

	public override IFinanceiroBancos FinanceiroBancosDAO => new SQLServerFinanceiroBancos();

	public override INotaFiscalCFOPs NotaFiscalCFOPsDAO => new SQLServerNotaFiscalCFOPs();

	public override INotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculoDAO => new SQLServerNotaFiscalModalidadeBaseCalculo();

	public override INotaFiscalModalidadeBaseCalculoICMSST NotaFiscalModalidadeBaseCalculoICMSSTDAO => new SQLServerNotaFiscalModalidadeBaseCalculoICMSST();

	public override INotaFiscalNotasFiscais NotaFiscalNotasFiscaisDAO => new SQLServerNotaFiscalNotasFiscais();

	public override INotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItensDAO => new SQLServerNotaFiscalNotasFiscaisItens();

	public override INotaFiscalTextosLegais NotaFiscalTextosLegaisDAO => new SQLServerNotaFiscalTextosLegais();

	public override INotaFiscalTipoIncidencia NotaFiscalTipoIncidenciaDAO => new SQLServerNotaFiscalTipoIncidencia();

	public override INotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImpostoDAO => new SQLServerNotaFiscalTipoRetencaoImposto();

	public override INotaFiscalOrigemProduto NotaFiscalOrigemProdutoDAO => new SQLServerNotaFiscalOrigemProduto();

	public override INotaFiscalFormasPagto NotaFiscalFormasPagtoDAO => new SQLServerNotaFiscalFormasPagto();

	public override INotaFiscalSerie NotaFiscalSerieDAO => new SQLServerNotaFiscalSerie();

	public override INotaFiscalCidades NotaFiscalCidadesDAO => new SQLServerNotaFiscalCidades();

	public override INotaFiscalUF NotaFiscalUFDAO => new SQLServerNotaFiscalUF();

	public override INotaFiscalWebServices NotaFiscalWebServicesDAO => new SQLServerNotaFiscalWebServices();

	public override INotaFiscalPaises NotaFiscalPaisesDAO => new SQLServerNotaFiscalPaises();

	public override INotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPIDAO => new SQLServerNotaFiscalTipoIncidenciaIPI();

	public override INotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederaisDAO => new SQLServerNotaFiscalTipoIncidenciaImpostosFederais();

	public override INotaFiscalFatura NotaFiscalFaturaDAO => new SQLServerNotaFiscalFatura();

	public override INotaFiscalResumoFaturamento NotaFiscalResumoFaturamentoDAO => new SQLServerNotaFiscalResumoFaturamento();

	public override INotasFiscaisEventos NotasFiscaisEventosDAO => new SQLServerNotasFiscaisEventos();

	public override INotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDIDAO => new SQLServerNotaFiscalNotasFiscaisItensDI();

	public override INotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoesDAO => new SQLServerNotaFiscalNotasFiscaisItensDIAdicoes();

	public override INotaFiscalInutilizacao NotaFiscalInutilizacaoDAO => new SQLServerNotaFiscalInutilizacao();

	public override INotaFiscalCest NotaFiscalCestDAO => new SQLServerNotaFiscalCest();

	public override INotaFiscalNotaReferenciada NotaFiscalNotaReferenciadaDAO => new SQLServerNotaFiscalNotaReferenciada();

	public override IParametrosSociedade ParametrosSociedadeDAO => new SQLServerParametrosSociedade();
}
