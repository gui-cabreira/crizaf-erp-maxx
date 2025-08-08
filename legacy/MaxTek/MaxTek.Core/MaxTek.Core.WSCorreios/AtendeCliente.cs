using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MaxTek.Core.WSCorreios;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", ConfigurationName = "WSCorreios.AtendeCliente")]
public interface AtendeCliente
{
	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaServicosAdicionaisAtivosResponse buscaServicosAdicionaisAtivos(buscaServicosAdicionaisAtivos request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaServicosAdicionaisAtivosResponse> buscaServicosAdicionaisAtivosAsync(buscaServicosAdicionaisAtivos request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	fechaPlpResponse fechaPlp(fechaPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<fechaPlpResponse> fechaPlpAsync(fechaPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	consultaSROResponse consultaSRO(consultaSRO request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<consultaSROResponse> consultaSROAsync(consultaSRO request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[FaultContract(typeof(Exception), Action = "", Name = "Exception")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	calculaTarifaServicoResponse calculaTarifaServico(calculaTarifaServico request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<calculaTarifaServicoResponse> calculaTarifaServicoAsync(calculaTarifaServico request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	validaPlpResponse validaPlp(validaPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<validaPlpResponse> validaPlpAsync(validaPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	VerificaSeTodosObjetosCanceladosResponse VerificaSeTodosObjetosCancelados(VerificaSeTodosObjetosCancelados request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<VerificaSeTodosObjetosCanceladosResponse> VerificaSeTodosObjetosCanceladosAsync(VerificaSeTodosObjetosCancelados request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[FaultContract(typeof(Exception), Action = "", Name = "Exception")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	cancelarObjetoResponse cancelarObjeto(cancelarObjeto request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<cancelarObjetoResponse> cancelarObjetoAsync(cancelarObjeto request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	atualizaPagamentoNaEntregaResponse atualizaPagamentoNaEntrega(atualizaPagamentoNaEntrega request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<atualizaPagamentoNaEntregaResponse> atualizaPagamentoNaEntregaAsync(atualizaPagamentoNaEntrega request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	obterClienteAtualizacaoResponse obterClienteAtualizacao(obterClienteAtualizacao request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<obterClienteAtualizacaoResponse> obterClienteAtualizacaoAsync(obterClienteAtualizacao request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	verificaDisponibilidadeServicoResponse verificaDisponibilidadeServico(verificaDisponibilidadeServico request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<verificaDisponibilidadeServicoResponse> verificaDisponibilidadeServicoAsync(verificaDisponibilidadeServico request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	fechaPlpVariosServicosResponse fechaPlpVariosServicos(fechaPlpVariosServicos request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<fechaPlpVariosServicosResponse> fechaPlpVariosServicosAsync(fechaPlpVariosServicos request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	geraDigitoVerificadorEtiquetasResponse geraDigitoVerificadorEtiquetas(geraDigitoVerificadorEtiquetas request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<geraDigitoVerificadorEtiquetasResponse> geraDigitoVerificadorEtiquetasAsync(geraDigitoVerificadorEtiquetas request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	obterEmbalagemLRSResponse obterEmbalagemLRS(obterEmbalagemLRS request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<obterEmbalagemLRSResponse> obterEmbalagemLRSAsync(obterEmbalagemLRS request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	validaEtiquetaPLPResponse validaEtiquetaPLP(validaEtiquetaPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<validaEtiquetaPLPResponse> validaEtiquetaPLPAsync(validaEtiquetaPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaServicosValorDeclaradoResponse buscaServicosValorDeclarado(buscaServicosValorDeclarado request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaServicosValorDeclaradoResponse> buscaServicosValorDeclaradoAsync(buscaServicosValorDeclarado request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	consultaCEPResponse consultaCEP(consultaCEP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<consultaCEPResponse> consultaCEPAsync(consultaCEP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	integrarUsuarioScolResponse integrarUsuarioScol(integrarUsuarioScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<integrarUsuarioScolResponse> integrarUsuarioScolAsync(integrarUsuarioScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	atualizaRemessaAgrupadaResponse atualizaRemessaAgrupada(atualizaRemessaAgrupada request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<atualizaRemessaAgrupadaResponse> atualizaRemessaAgrupadaAsync(atualizaRemessaAgrupada request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	consultaSRO_NEWResponse consultaSRO_NEW(consultaSRO_NEW request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<consultaSRO_NEWResponse> consultaSRO_NEWAsync(consultaSRO_NEW request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	solicitaPLPResponse solicitaPLP(solicitaPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<solicitaPLPResponse> solicitaPLPAsync(solicitaPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	getStatusCartaoPostagemResponse getStatusCartaoPostagem(getStatusCartaoPostagem request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<getStatusCartaoPostagemResponse> getStatusCartaoPostagemAsync(getStatusCartaoPostagem request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaDataAtualResponse buscaDataAtual(buscaDataAtual request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaDataAtualResponse> buscaDataAtualAsync(buscaDataAtual request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[FaultContract(typeof(Exception), Action = "", Name = "Exception")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaTarifaValeResponse buscaTarifaVale(buscaTarifaVale request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaTarifaValeResponse> buscaTarifaValeAsync(buscaTarifaVale request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	validarPostagemSimultaneaResponse validarPostagemSimultanea(validarPostagemSimultanea request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<validarPostagemSimultaneaResponse> validarPostagemSimultaneaAsync(validarPostagemSimultanea request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	getStatusPLPResponse getStatusPLP(getStatusPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<getStatusPLPResponse> getStatusPLPAsync(getStatusPLP request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(SQLException), Action = "", Name = "SQLException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaServicosXServicosAdicionaisResponse buscaServicosXServicosAdicionais(buscaServicosXServicosAdicionais request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaServicosXServicosAdicionaisResponse> buscaServicosXServicosAdicionaisAsync(buscaServicosXServicosAdicionais request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	cancelarPedidoScolResponse cancelarPedidoScol(cancelarPedidoScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<cancelarPedidoScolResponse> cancelarPedidoScolAsync(cancelarPedidoScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	bloquearObjetoResponse bloquearObjeto(bloquearObjeto request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<bloquearObjetoResponse> bloquearObjetoAsync(bloquearObjeto request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaContratoResponse buscaContrato(buscaContrato request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaContratoResponse> buscaContratoAsync(buscaContrato request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	solicitaEtiquetasResponse solicitaEtiquetas(solicitaEtiquetas request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<solicitaEtiquetasResponse> solicitaEtiquetasAsync(solicitaEtiquetas request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	solicitaXmlPlpResponse solicitaXmlPlp(solicitaXmlPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<solicitaXmlPlpResponse> solicitaXmlPlpAsync(solicitaXmlPlp request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	validarPostagemReversaResponse validarPostagemReversa(validarPostagemReversa request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<validarPostagemReversaResponse> validarPostagemReversaAsync(validarPostagemReversa request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaClienteResponse buscaCliente(buscaCliente request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaClienteResponse> buscaClienteAsync(buscaCliente request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(ErroMontagemRelatorio), Action = "", Name = "ErroMontagemRelatorio")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaPagamentoEntregaResponse buscaPagamentoEntrega(buscaPagamentoEntrega request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaPagamentoEntregaResponse> buscaPagamentoEntregaAsync(buscaPagamentoEntrega request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	solicitarPostagemScolResponse solicitarPostagemScol(solicitarPostagemScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<solicitarPostagemScolResponse> solicitarPostagemScolAsync(solicitarPostagemScol request);

	[OperationContract(Action = "", ReplyAction = "*")]
	[FaultContract(typeof(string), Action = "", Name = "AutenticacaoException")]
	[FaultContract(typeof(string), Action = "", Name = "SigepClienteException")]
	[XmlSerializerFormat(SupportFaults = true)]
	[return: MessageParameter(Name = "return")]
	buscaServicosResponse buscaServicos(buscaServicos request);

	[OperationContract(Action = "", ReplyAction = "*")]
	Task<buscaServicosResponse> buscaServicosAsync(buscaServicos request);
}
