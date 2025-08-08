using System.Configuration;

namespace MaxTek.ERP.DAL;

public static class AcessoDados
{
	private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProviderERP");

	private static readonly ProviderFactory factory = ProviderFactories.ObterFactory(dataProvider);

	public static IDesenvolvimentoClasse DesenvolvimentoClasseDAO => factory.DesenvolvimentoClasseDAO;

	public static IDesenvolvimentoClasseCampos DesenvolvimentoClasseCamposDAO => factory.DesenvolvimentoClasseCamposDAO;

	public static IBussinessInteligence BussinessInteligenceDAO => factory.BussinessInteligenceDAO;

	public static ICampos CamposDAO => factory.CamposDAO;

	public static IClasse ClasseDAO => factory.ClasseDAO;

	public static ITabelas TabelasDAO => factory.TabelasDAO;

	public static ISistemaUsuarios SistemaUsuariosDAO => factory.SistemaUsuariosDAO;

	public static IIndices IndicesDAO => factory.IndicesDAO;

	public static ICriarBaseDados SqlCriarBaseDadadosDAO => factory.SqlCriarBaseDadosDAO;

	public static IComercialEntidade ComercialEntidadeDAO => factory.ComercialEntidadeDAO;

	public static IComercialEntidadeContato ComercialEntidadeContatoDAO => factory.ComercialEntidadeContatoDAO;

	public static IComercialEntidadeEspecialidade ComercialEntidadeEspecialidadeDAO => factory.ComercialEntidadeEspecialidadeDAO;

	public static IComercialEntidadeEvento ComercialEntidadeEventoDAO => factory.ComercialEntidadeEventoDAO;

	public static IComercialEntidadeLigacaoEndereco ComercialEntidadeLigacaoEnderecoDAO => factory.ComercialEntidadeLigacaoEnderecoDAO;

	public static IComercialEntidadeTipoAtendimento ComercialEntidadeTipoAtendimentoDAO => factory.ComercialEntidadeTipoAtendimentoDAO;

	public static IComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamentoDAO => factory.ComercialFinanceiroCondicaoPagamentoDAO;

	public static IComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamentoDAO => factory.ComercialFinanceiroModoPagamentoDAO;

	public static IComercialFiscalClassificacaoFiscal ComercialFiscalClassificacaoFiscalDAO => factory.ComercialFiscalClassificacaoFiscalDAO;

	public static IComercialFiscalContaContabil ComercialFiscalContaContabilDAO => factory.ComercialFiscalContaContabilDAO;

	public static IComercialVendasPedidos ComercialVendasPedidosDAO => factory.ComercialVendasPedidosDAO;

	public static IComercialVendasPedidosItens ComercialVendasPedidosItensDAO => factory.ComercialVendasPedidosItensDAO;

	public static IComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadenciaDAO => factory.ComercialVendasPedidosItensCadenciaDAO;

	public static IComercialVendasCatalogos ComercialVendasCatalogosDAO => factory.ComercialVendasCatalogosDAO;

	public static IComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigosDAO => factory.ComercialVendasCatalogosCodigosDAO;

	public static IQualidadeCertificacao QualidadeCertificacaoDAO => factory.QualidadeCertificacaoDAO;

	public static IQualidadeEmbarqueControlado QualidadeEmbarqueControladoDAO => factory.QualidadeEmbarqueControladoDAO;

	public static IRHFuncionario RHFuncionarioDAO => factory.RHFuncionarioDAO;

	public static ITecnicoEngenhariaProduto TecnicoEngenhariaProdutoDAO => factory.TecnicoEngenhariaProdutoDAO;

	public static ITecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifadoDAO => factory.TecnicoEngenhariaProdutoAlmoxarifadoDAO;

	public static ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO => factory.TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO;

	public static ITecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamiliaDAO => factory.TecnicoEngenhariaProdutoFamiliaDAO;

	public static ITecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamiliaDAO => factory.TecnicoEngenhariaProdutoSubfamiliaDAO;

	public static ITecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipoDAO => factory.TecnicoEngenhariaProdutoTipoDAO;

	public static ITecnicoEngenhariaProdutoUnidade TecnicoEngenhariaProdutoUnidadeDAO => factory.TecnicoEngenhariaProdutoUnidadeDAO;

	public static ITecnicoEngenhariaProcessoControle TecnicoEngenhariaProcessoControleDAO => factory.TecnicoEngenhariaProcessoControleDAO;

	public static ITecnicoEngenhariaProcesso TecnicoEngenhariaProcessoDAO => factory.TecnicoEngenhariaProcessoDAO;

	public static ITecnicoEngenhariaProcessoMateria TecnicoEngenhariaProcessoMateriaDAO => factory.TecnicoEngenhariaProcessoMateriaDAO;

	public static ITecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacaoDAO => factory.TecnicoEngenhariaProcessoOperacaoDAO;

	public static ITecnicoEngenhariaProcessoOperacaoFerramenta TecnicoEngenhariaProcessoOperacaoFerramentaDAO => factory.TecnicoEngenhariaProcessoOperacaoFerramentaDAO;

	public static ITecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisaoDAO => factory.TecnicoEngenhariaProcessoOperacaoRevisaoDAO;

	public static ITecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisaoDAO => factory.TecnicoEngenhariaProcessoRevisaoDAO;

	public static ITecnicoProducaoApontamento TecnicoProducaoApontamentoDAO => factory.TecnicoProducaoApontamentoDAO;

	public static ITecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamentoDAO => factory.TecnicoProducaoEstatisticasApontamentoDAO;

	public static IWorkFlowTarefa WorkFlowTarefaDAO => factory.WorkFlowTarefaDAO;

	public static IFinanceiroTitulos FinanceiroTitulosDAO => factory.FinanceiroTitulosDAO;

	public static IFinanceiroBancos FinanceiroBancosDAO => factory.FinanceiroBancosDAO;

	public static INotaFiscalCFOPs NotaFiscalCFOPsDAO => factory.NotaFiscalCFOPsDAO;

	public static INotaFiscalModalidadeBaseCalculo NotaFiscalModalidadeBaseCalculoDAO => factory.NotaFiscalModalidadeBaseCalculoDAO;

	public static INotaFiscalModalidadeBaseCalculoICMSST NotaFiscalModalidadeBaseCalculoICMSSTDAO => factory.NotaFiscalModalidadeBaseCalculoICMSSTDAO;

	public static INotaFiscalNotasFiscais NotaFiscalNotasFiscaisDAO => factory.NotaFiscalNotasFiscaisDAO;

	public static INotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItensDAO => factory.NotaFiscalNotasFiscaisItensDAO;

	public static INotaFiscalTextosLegais NotaFiscalTextosLegaisDAO => factory.NotaFiscalTextosLegaisDAO;

	public static INotaFiscalTipoIncidencia NotaFiscalTipoIncidenciaDAO => factory.NotaFiscalTipoIncidenciaDAO;

	public static INotaFiscalTipoRetencaoImposto NotaFiscalTipoRetencaoImpostoDAO => factory.NotaFiscalTipoRetencaoImpostoDAO;

	public static INotaFiscalOrigemProduto NotaFiscalOrigemProdutoDAO => factory.NotaFiscalOrigemProdutoDAO;

	public static INotaFiscalFormasPagto NotaFiscalFormasPagtoDAO => factory.NotaFiscalFormasPagtoDAO;

	public static INotaFiscalSerie NotaFiscalSerieDAO => factory.NotaFiscalSerieDAO;

	public static INotaFiscalCidades NotaFiscalCidadesDAO => factory.NotaFiscalCidadesDAO;

	public static INotaFiscalUF NotaFiscalUFDAO => factory.NotaFiscalUFDAO;

	public static INotaFiscalWebServices NotaFiscalWebServicesDAO => factory.NotaFiscalWebServicesDAO;

	public static INotaFiscalPaises NotaFiscalPaisesDAO => factory.NotaFiscalPaisesDAO;

	public static INotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPIDAO => factory.NotaFiscalTipoIncidenciaIPIDAO;

	public static INotaFiscalTipoIncidenciaImpostosFederais NotaFiscalTipoIncidenciaImpostosFederaisDAO => factory.NotaFiscalTipoIncidenciaImpostosFederaisDAO;

	public static INotaFiscalFatura NotaFiscalFaturaDAO => factory.NotaFiscalFaturaDAO;

	public static INotaFiscalResumoFaturamento NotaFiscalResumoFaturamentoDAO => factory.NotaFiscalResumoFaturamentoDAO;

	public static INotasFiscaisEventos NotasFiscaisEventosDAO => factory.NotasFiscaisEventosDAO;

	public static INotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDIDAO => factory.NotaFiscalNotasFiscaisItensDIDAO;

	public static INotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoesDAO => factory.NotaFiscalNotasFiscaisItensDIAdicoesDAO;

	public static INotaFiscalInutilizacao NotaFiscalInutilizacaoDAO => factory.NotaFiscalInutilizacaoDAO;

	public static INotaFiscalCest NotaFiscalCestDAO => factory.NotaFiscalCestDAO;

	public static INotaFiscalNotaReferenciada NotaFiscalNotaReferenciadaDAO => factory.NotaFiscalNotaReferenciadaDAO;

	public static IParametrosSociedade ParametrosSociedadeDAO => factory.ParametrosSociedadeDAO;
}
