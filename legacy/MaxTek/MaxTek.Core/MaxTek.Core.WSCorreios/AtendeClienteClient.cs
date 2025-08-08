using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace MaxTek.Core.WSCorreios;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class AtendeClienteClient : ClientBase<AtendeCliente>, AtendeCliente
{
	public AtendeClienteClient()
	{
	}

	public AtendeClienteClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public AtendeClienteClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AtendeClienteClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AtendeClienteClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaServicosAdicionaisAtivosResponse AtendeCliente.buscaServicosAdicionaisAtivos(buscaServicosAdicionaisAtivos request)
	{
		return base.Channel.buscaServicosAdicionaisAtivos(request);
	}

	public servicoAdicionalXML[] buscaServicosAdicionaisAtivos(string usuario, string senha)
	{
		buscaServicosAdicionaisAtivos buscaServicosAdicionaisAtivos2 = new buscaServicosAdicionaisAtivos();
		buscaServicosAdicionaisAtivos2.usuario = usuario;
		buscaServicosAdicionaisAtivos2.senha = senha;
		buscaServicosAdicionaisAtivosResponse buscaServicosAdicionaisAtivosResponse2 = ((AtendeCliente)this).buscaServicosAdicionaisAtivos(buscaServicosAdicionaisAtivos2);
		return buscaServicosAdicionaisAtivosResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaServicosAdicionaisAtivosResponse> AtendeCliente.buscaServicosAdicionaisAtivosAsync(buscaServicosAdicionaisAtivos request)
	{
		return base.Channel.buscaServicosAdicionaisAtivosAsync(request);
	}

	public Task<buscaServicosAdicionaisAtivosResponse> buscaServicosAdicionaisAtivosAsync(string usuario, string senha)
	{
		buscaServicosAdicionaisAtivos buscaServicosAdicionaisAtivos2 = new buscaServicosAdicionaisAtivos();
		buscaServicosAdicionaisAtivos2.usuario = usuario;
		buscaServicosAdicionaisAtivos2.senha = senha;
		return ((AtendeCliente)this).buscaServicosAdicionaisAtivosAsync(buscaServicosAdicionaisAtivos2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	fechaPlpResponse AtendeCliente.fechaPlp(fechaPlp request)
	{
		return base.Channel.fechaPlp(request);
	}

	public long fechaPlp(string xml, long idPlpCliente, string cartaoPostagem, string faixaEtiquetas, string usuario, string senha)
	{
		fechaPlp fechaPlp2 = new fechaPlp();
		fechaPlp2.xml = xml;
		fechaPlp2.idPlpCliente = idPlpCliente;
		fechaPlp2.cartaoPostagem = cartaoPostagem;
		fechaPlp2.faixaEtiquetas = faixaEtiquetas;
		fechaPlp2.usuario = usuario;
		fechaPlp2.senha = senha;
		fechaPlpResponse fechaPlpResponse2 = ((AtendeCliente)this).fechaPlp(fechaPlp2);
		return fechaPlpResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<fechaPlpResponse> AtendeCliente.fechaPlpAsync(fechaPlp request)
	{
		return base.Channel.fechaPlpAsync(request);
	}

	public Task<fechaPlpResponse> fechaPlpAsync(string xml, long idPlpCliente, string cartaoPostagem, string faixaEtiquetas, string usuario, string senha)
	{
		fechaPlp fechaPlp2 = new fechaPlp();
		fechaPlp2.xml = xml;
		fechaPlp2.idPlpCliente = idPlpCliente;
		fechaPlp2.cartaoPostagem = cartaoPostagem;
		fechaPlp2.faixaEtiquetas = faixaEtiquetas;
		fechaPlp2.usuario = usuario;
		fechaPlp2.senha = senha;
		return ((AtendeCliente)this).fechaPlpAsync(fechaPlp2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	consultaSROResponse AtendeCliente.consultaSRO(consultaSRO request)
	{
		return base.Channel.consultaSRO(request);
	}

	public string consultaSRO(string[] listaObjetos, string tipoConsulta, string tipoResultado, string usuarioSro, string senhaSro)
	{
		consultaSRO consultaSRO2 = new consultaSRO();
		consultaSRO2.listaObjetos = listaObjetos;
		consultaSRO2.tipoConsulta = tipoConsulta;
		consultaSRO2.tipoResultado = tipoResultado;
		consultaSRO2.usuarioSro = usuarioSro;
		consultaSRO2.senhaSro = senhaSro;
		consultaSROResponse consultaSROResponse2 = ((AtendeCliente)this).consultaSRO(consultaSRO2);
		return consultaSROResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<consultaSROResponse> AtendeCliente.consultaSROAsync(consultaSRO request)
	{
		return base.Channel.consultaSROAsync(request);
	}

	public Task<consultaSROResponse> consultaSROAsync(string[] listaObjetos, string tipoConsulta, string tipoResultado, string usuarioSro, string senhaSro)
	{
		consultaSRO consultaSRO2 = new consultaSRO();
		consultaSRO2.listaObjetos = listaObjetos;
		consultaSRO2.tipoConsulta = tipoConsulta;
		consultaSRO2.tipoResultado = tipoResultado;
		consultaSRO2.usuarioSro = usuarioSro;
		consultaSRO2.senhaSro = senhaSro;
		return ((AtendeCliente)this).consultaSROAsync(consultaSRO2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	calculaTarifaServicoResponse AtendeCliente.calculaTarifaServico(calculaTarifaServico request)
	{
		return base.Channel.calculaTarifaServico(request);
	}

	public string calculaTarifaServico(string codAdministrativo, string usuario, string senha, string codServico, string cepOrigem, string cepDestino, string peso, int codFormato, double comprimento, double altura, double largura, double diametro, string codMaoPropria, double valorDeclarado, string codAvisoRecebimento)
	{
		calculaTarifaServico calculaTarifaServico2 = new calculaTarifaServico();
		calculaTarifaServico2.codAdministrativo = codAdministrativo;
		calculaTarifaServico2.usuario = usuario;
		calculaTarifaServico2.senha = senha;
		calculaTarifaServico2.codServico = codServico;
		calculaTarifaServico2.cepOrigem = cepOrigem;
		calculaTarifaServico2.cepDestino = cepDestino;
		calculaTarifaServico2.peso = peso;
		calculaTarifaServico2.codFormato = codFormato;
		calculaTarifaServico2.comprimento = comprimento;
		calculaTarifaServico2.altura = altura;
		calculaTarifaServico2.largura = largura;
		calculaTarifaServico2.diametro = diametro;
		calculaTarifaServico2.codMaoPropria = codMaoPropria;
		calculaTarifaServico2.valorDeclarado = valorDeclarado;
		calculaTarifaServico2.codAvisoRecebimento = codAvisoRecebimento;
		calculaTarifaServicoResponse calculaTarifaServicoResponse2 = ((AtendeCliente)this).calculaTarifaServico(calculaTarifaServico2);
		return calculaTarifaServicoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<calculaTarifaServicoResponse> AtendeCliente.calculaTarifaServicoAsync(calculaTarifaServico request)
	{
		return base.Channel.calculaTarifaServicoAsync(request);
	}

	public Task<calculaTarifaServicoResponse> calculaTarifaServicoAsync(string codAdministrativo, string usuario, string senha, string codServico, string cepOrigem, string cepDestino, string peso, int codFormato, double comprimento, double altura, double largura, double diametro, string codMaoPropria, double valorDeclarado, string codAvisoRecebimento)
	{
		calculaTarifaServico calculaTarifaServico2 = new calculaTarifaServico();
		calculaTarifaServico2.codAdministrativo = codAdministrativo;
		calculaTarifaServico2.usuario = usuario;
		calculaTarifaServico2.senha = senha;
		calculaTarifaServico2.codServico = codServico;
		calculaTarifaServico2.cepOrigem = cepOrigem;
		calculaTarifaServico2.cepDestino = cepDestino;
		calculaTarifaServico2.peso = peso;
		calculaTarifaServico2.codFormato = codFormato;
		calculaTarifaServico2.comprimento = comprimento;
		calculaTarifaServico2.altura = altura;
		calculaTarifaServico2.largura = largura;
		calculaTarifaServico2.diametro = diametro;
		calculaTarifaServico2.codMaoPropria = codMaoPropria;
		calculaTarifaServico2.valorDeclarado = valorDeclarado;
		calculaTarifaServico2.codAvisoRecebimento = codAvisoRecebimento;
		return ((AtendeCliente)this).calculaTarifaServicoAsync(calculaTarifaServico2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	validaPlpResponse AtendeCliente.validaPlp(validaPlp request)
	{
		return base.Channel.validaPlp(request);
	}

	public bool validaPlp(long cliente, string numero, long diretoria, string cartao, string unidadePostagem, long servico, string[] servicosAdicionais, string usuario, string senha)
	{
		validaPlp validaPlp2 = new validaPlp();
		validaPlp2.cliente = cliente;
		validaPlp2.numero = numero;
		validaPlp2.diretoria = diretoria;
		validaPlp2.cartao = cartao;
		validaPlp2.unidadePostagem = unidadePostagem;
		validaPlp2.servico = servico;
		validaPlp2.servicosAdicionais = servicosAdicionais;
		validaPlp2.usuario = usuario;
		validaPlp2.senha = senha;
		validaPlpResponse validaPlpResponse2 = ((AtendeCliente)this).validaPlp(validaPlp2);
		return validaPlpResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<validaPlpResponse> AtendeCliente.validaPlpAsync(validaPlp request)
	{
		return base.Channel.validaPlpAsync(request);
	}

	public Task<validaPlpResponse> validaPlpAsync(long cliente, string numero, long diretoria, string cartao, string unidadePostagem, long servico, string[] servicosAdicionais, string usuario, string senha)
	{
		validaPlp validaPlp2 = new validaPlp();
		validaPlp2.cliente = cliente;
		validaPlp2.numero = numero;
		validaPlp2.diretoria = diretoria;
		validaPlp2.cartao = cartao;
		validaPlp2.unidadePostagem = unidadePostagem;
		validaPlp2.servico = servico;
		validaPlp2.servicosAdicionais = servicosAdicionais;
		validaPlp2.usuario = usuario;
		validaPlp2.senha = senha;
		return ((AtendeCliente)this).validaPlpAsync(validaPlp2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	VerificaSeTodosObjetosCanceladosResponse AtendeCliente.VerificaSeTodosObjetosCancelados(VerificaSeTodosObjetosCancelados request)
	{
		return base.Channel.VerificaSeTodosObjetosCancelados(request);
	}

	public bool VerificaSeTodosObjetosCancelados(objetoPostal[] arg0)
	{
		VerificaSeTodosObjetosCancelados verificaSeTodosObjetosCancelados = new VerificaSeTodosObjetosCancelados();
		verificaSeTodosObjetosCancelados.arg0 = arg0;
		VerificaSeTodosObjetosCanceladosResponse verificaSeTodosObjetosCanceladosResponse = ((AtendeCliente)this).VerificaSeTodosObjetosCancelados(verificaSeTodosObjetosCancelados);
		return verificaSeTodosObjetosCanceladosResponse.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<VerificaSeTodosObjetosCanceladosResponse> AtendeCliente.VerificaSeTodosObjetosCanceladosAsync(VerificaSeTodosObjetosCancelados request)
	{
		return base.Channel.VerificaSeTodosObjetosCanceladosAsync(request);
	}

	public Task<VerificaSeTodosObjetosCanceladosResponse> VerificaSeTodosObjetosCanceladosAsync(objetoPostal[] arg0)
	{
		VerificaSeTodosObjetosCancelados verificaSeTodosObjetosCancelados = new VerificaSeTodosObjetosCancelados();
		verificaSeTodosObjetosCancelados.arg0 = arg0;
		return ((AtendeCliente)this).VerificaSeTodosObjetosCanceladosAsync(verificaSeTodosObjetosCancelados);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	cancelarObjetoResponse AtendeCliente.cancelarObjeto(cancelarObjeto request)
	{
		return base.Channel.cancelarObjeto(request);
	}

	public bool cancelarObjeto(long idPlp, string numeroEtiqueta, string usuario, string senha)
	{
		cancelarObjeto cancelarObjeto2 = new cancelarObjeto();
		cancelarObjeto2.idPlp = idPlp;
		cancelarObjeto2.numeroEtiqueta = numeroEtiqueta;
		cancelarObjeto2.usuario = usuario;
		cancelarObjeto2.senha = senha;
		cancelarObjetoResponse cancelarObjetoResponse2 = ((AtendeCliente)this).cancelarObjeto(cancelarObjeto2);
		return cancelarObjetoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<cancelarObjetoResponse> AtendeCliente.cancelarObjetoAsync(cancelarObjeto request)
	{
		return base.Channel.cancelarObjetoAsync(request);
	}

	public Task<cancelarObjetoResponse> cancelarObjetoAsync(long idPlp, string numeroEtiqueta, string usuario, string senha)
	{
		cancelarObjeto cancelarObjeto2 = new cancelarObjeto();
		cancelarObjeto2.idPlp = idPlp;
		cancelarObjeto2.numeroEtiqueta = numeroEtiqueta;
		cancelarObjeto2.usuario = usuario;
		cancelarObjeto2.senha = senha;
		return ((AtendeCliente)this).cancelarObjetoAsync(cancelarObjeto2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	atualizaPagamentoNaEntregaResponse AtendeCliente.atualizaPagamentoNaEntrega(atualizaPagamentoNaEntrega request)
	{
		return base.Channel.atualizaPagamentoNaEntrega(request);
	}

	public string atualizaPagamentoNaEntrega(string usuario, string senha)
	{
		atualizaPagamentoNaEntrega atualizaPagamentoNaEntrega2 = new atualizaPagamentoNaEntrega();
		atualizaPagamentoNaEntrega2.usuario = usuario;
		atualizaPagamentoNaEntrega2.senha = senha;
		atualizaPagamentoNaEntregaResponse atualizaPagamentoNaEntregaResponse2 = ((AtendeCliente)this).atualizaPagamentoNaEntrega(atualizaPagamentoNaEntrega2);
		return atualizaPagamentoNaEntregaResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<atualizaPagamentoNaEntregaResponse> AtendeCliente.atualizaPagamentoNaEntregaAsync(atualizaPagamentoNaEntrega request)
	{
		return base.Channel.atualizaPagamentoNaEntregaAsync(request);
	}

	public Task<atualizaPagamentoNaEntregaResponse> atualizaPagamentoNaEntregaAsync(string usuario, string senha)
	{
		atualizaPagamentoNaEntrega atualizaPagamentoNaEntrega2 = new atualizaPagamentoNaEntrega();
		atualizaPagamentoNaEntrega2.usuario = usuario;
		atualizaPagamentoNaEntrega2.senha = senha;
		return ((AtendeCliente)this).atualizaPagamentoNaEntregaAsync(atualizaPagamentoNaEntrega2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	obterClienteAtualizacaoResponse AtendeCliente.obterClienteAtualizacao(obterClienteAtualizacao request)
	{
		return base.Channel.obterClienteAtualizacao(request);
	}

	public DateTime obterClienteAtualizacao(string cnpjCliente, string usuario, string senha)
	{
		obterClienteAtualizacao obterClienteAtualizacao2 = new obterClienteAtualizacao();
		obterClienteAtualizacao2.cnpjCliente = cnpjCliente;
		obterClienteAtualizacao2.usuario = usuario;
		obterClienteAtualizacao2.senha = senha;
		obterClienteAtualizacaoResponse obterClienteAtualizacaoResponse2 = ((AtendeCliente)this).obterClienteAtualizacao(obterClienteAtualizacao2);
		return obterClienteAtualizacaoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<obterClienteAtualizacaoResponse> AtendeCliente.obterClienteAtualizacaoAsync(obterClienteAtualizacao request)
	{
		return base.Channel.obterClienteAtualizacaoAsync(request);
	}

	public Task<obterClienteAtualizacaoResponse> obterClienteAtualizacaoAsync(string cnpjCliente, string usuario, string senha)
	{
		obterClienteAtualizacao obterClienteAtualizacao2 = new obterClienteAtualizacao();
		obterClienteAtualizacao2.cnpjCliente = cnpjCliente;
		obterClienteAtualizacao2.usuario = usuario;
		obterClienteAtualizacao2.senha = senha;
		return ((AtendeCliente)this).obterClienteAtualizacaoAsync(obterClienteAtualizacao2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	verificaDisponibilidadeServicoResponse AtendeCliente.verificaDisponibilidadeServico(verificaDisponibilidadeServico request)
	{
		return base.Channel.verificaDisponibilidadeServico(request);
	}

	public string verificaDisponibilidadeServico(int codAdministrativo, string numeroServico, string cepOrigem, string cepDestino, string usuario, string senha)
	{
		verificaDisponibilidadeServico verificaDisponibilidadeServico2 = new verificaDisponibilidadeServico();
		verificaDisponibilidadeServico2.codAdministrativo = codAdministrativo;
		verificaDisponibilidadeServico2.numeroServico = numeroServico;
		verificaDisponibilidadeServico2.cepOrigem = cepOrigem;
		verificaDisponibilidadeServico2.cepDestino = cepDestino;
		verificaDisponibilidadeServico2.usuario = usuario;
		verificaDisponibilidadeServico2.senha = senha;
		verificaDisponibilidadeServicoResponse verificaDisponibilidadeServicoResponse2 = ((AtendeCliente)this).verificaDisponibilidadeServico(verificaDisponibilidadeServico2);
		return verificaDisponibilidadeServicoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<verificaDisponibilidadeServicoResponse> AtendeCliente.verificaDisponibilidadeServicoAsync(verificaDisponibilidadeServico request)
	{
		return base.Channel.verificaDisponibilidadeServicoAsync(request);
	}

	public Task<verificaDisponibilidadeServicoResponse> verificaDisponibilidadeServicoAsync(int codAdministrativo, string numeroServico, string cepOrigem, string cepDestino, string usuario, string senha)
	{
		verificaDisponibilidadeServico verificaDisponibilidadeServico2 = new verificaDisponibilidadeServico();
		verificaDisponibilidadeServico2.codAdministrativo = codAdministrativo;
		verificaDisponibilidadeServico2.numeroServico = numeroServico;
		verificaDisponibilidadeServico2.cepOrigem = cepOrigem;
		verificaDisponibilidadeServico2.cepDestino = cepDestino;
		verificaDisponibilidadeServico2.usuario = usuario;
		verificaDisponibilidadeServico2.senha = senha;
		return ((AtendeCliente)this).verificaDisponibilidadeServicoAsync(verificaDisponibilidadeServico2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	fechaPlpVariosServicosResponse AtendeCliente.fechaPlpVariosServicos(fechaPlpVariosServicos request)
	{
		return base.Channel.fechaPlpVariosServicos(request);
	}

	public long fechaPlpVariosServicos(string xml, long idPlpCliente, string cartaoPostagem, string[] listaEtiquetas, string usuario, string senha)
	{
		fechaPlpVariosServicos fechaPlpVariosServicos2 = new fechaPlpVariosServicos();
		fechaPlpVariosServicos2.xml = xml;
		fechaPlpVariosServicos2.idPlpCliente = idPlpCliente;
		fechaPlpVariosServicos2.cartaoPostagem = cartaoPostagem;
		fechaPlpVariosServicos2.listaEtiquetas = listaEtiquetas;
		fechaPlpVariosServicos2.usuario = usuario;
		fechaPlpVariosServicos2.senha = senha;
		fechaPlpVariosServicosResponse fechaPlpVariosServicosResponse2 = ((AtendeCliente)this).fechaPlpVariosServicos(fechaPlpVariosServicos2);
		return fechaPlpVariosServicosResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<fechaPlpVariosServicosResponse> AtendeCliente.fechaPlpVariosServicosAsync(fechaPlpVariosServicos request)
	{
		return base.Channel.fechaPlpVariosServicosAsync(request);
	}

	public Task<fechaPlpVariosServicosResponse> fechaPlpVariosServicosAsync(string xml, long idPlpCliente, string cartaoPostagem, string[] listaEtiquetas, string usuario, string senha)
	{
		fechaPlpVariosServicos fechaPlpVariosServicos2 = new fechaPlpVariosServicos();
		fechaPlpVariosServicos2.xml = xml;
		fechaPlpVariosServicos2.idPlpCliente = idPlpCliente;
		fechaPlpVariosServicos2.cartaoPostagem = cartaoPostagem;
		fechaPlpVariosServicos2.listaEtiquetas = listaEtiquetas;
		fechaPlpVariosServicos2.usuario = usuario;
		fechaPlpVariosServicos2.senha = senha;
		return ((AtendeCliente)this).fechaPlpVariosServicosAsync(fechaPlpVariosServicos2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	geraDigitoVerificadorEtiquetasResponse AtendeCliente.geraDigitoVerificadorEtiquetas(geraDigitoVerificadorEtiquetas request)
	{
		return base.Channel.geraDigitoVerificadorEtiquetas(request);
	}

	public int[] geraDigitoVerificadorEtiquetas(string[] etiquetas, string usuario, string senha)
	{
		geraDigitoVerificadorEtiquetas geraDigitoVerificadorEtiquetas2 = new geraDigitoVerificadorEtiquetas();
		geraDigitoVerificadorEtiquetas2.etiquetas = etiquetas;
		geraDigitoVerificadorEtiquetas2.usuario = usuario;
		geraDigitoVerificadorEtiquetas2.senha = senha;
		geraDigitoVerificadorEtiquetasResponse geraDigitoVerificadorEtiquetasResponse2 = ((AtendeCliente)this).geraDigitoVerificadorEtiquetas(geraDigitoVerificadorEtiquetas2);
		return geraDigitoVerificadorEtiquetasResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<geraDigitoVerificadorEtiquetasResponse> AtendeCliente.geraDigitoVerificadorEtiquetasAsync(geraDigitoVerificadorEtiquetas request)
	{
		return base.Channel.geraDigitoVerificadorEtiquetasAsync(request);
	}

	public Task<geraDigitoVerificadorEtiquetasResponse> geraDigitoVerificadorEtiquetasAsync(string[] etiquetas, string usuario, string senha)
	{
		geraDigitoVerificadorEtiquetas geraDigitoVerificadorEtiquetas2 = new geraDigitoVerificadorEtiquetas();
		geraDigitoVerificadorEtiquetas2.etiquetas = etiquetas;
		geraDigitoVerificadorEtiquetas2.usuario = usuario;
		geraDigitoVerificadorEtiquetas2.senha = senha;
		return ((AtendeCliente)this).geraDigitoVerificadorEtiquetasAsync(geraDigitoVerificadorEtiquetas2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	obterEmbalagemLRSResponse AtendeCliente.obterEmbalagemLRS(obterEmbalagemLRS request)
	{
		return base.Channel.obterEmbalagemLRS(request);
	}

	public embalagemLRSMaster[] obterEmbalagemLRS()
	{
		obterEmbalagemLRS request = new obterEmbalagemLRS();
		obterEmbalagemLRSResponse obterEmbalagemLRSResponse2 = ((AtendeCliente)this).obterEmbalagemLRS(request);
		return obterEmbalagemLRSResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<obterEmbalagemLRSResponse> AtendeCliente.obterEmbalagemLRSAsync(obterEmbalagemLRS request)
	{
		return base.Channel.obterEmbalagemLRSAsync(request);
	}

	public Task<obterEmbalagemLRSResponse> obterEmbalagemLRSAsync()
	{
		obterEmbalagemLRS request = new obterEmbalagemLRS();
		return ((AtendeCliente)this).obterEmbalagemLRSAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	validaEtiquetaPLPResponse AtendeCliente.validaEtiquetaPLP(validaEtiquetaPLP request)
	{
		return base.Channel.validaEtiquetaPLP(request);
	}

	public bool validaEtiquetaPLP(string numeroEtiqueta, long idPlp, string usuario, string senha)
	{
		validaEtiquetaPLP validaEtiquetaPLP2 = new validaEtiquetaPLP();
		validaEtiquetaPLP2.numeroEtiqueta = numeroEtiqueta;
		validaEtiquetaPLP2.idPlp = idPlp;
		validaEtiquetaPLP2.usuario = usuario;
		validaEtiquetaPLP2.senha = senha;
		validaEtiquetaPLPResponse validaEtiquetaPLPResponse2 = ((AtendeCliente)this).validaEtiquetaPLP(validaEtiquetaPLP2);
		return validaEtiquetaPLPResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<validaEtiquetaPLPResponse> AtendeCliente.validaEtiquetaPLPAsync(validaEtiquetaPLP request)
	{
		return base.Channel.validaEtiquetaPLPAsync(request);
	}

	public Task<validaEtiquetaPLPResponse> validaEtiquetaPLPAsync(string numeroEtiqueta, long idPlp, string usuario, string senha)
	{
		validaEtiquetaPLP validaEtiquetaPLP2 = new validaEtiquetaPLP();
		validaEtiquetaPLP2.numeroEtiqueta = numeroEtiqueta;
		validaEtiquetaPLP2.idPlp = idPlp;
		validaEtiquetaPLP2.usuario = usuario;
		validaEtiquetaPLP2.senha = senha;
		return ((AtendeCliente)this).validaEtiquetaPLPAsync(validaEtiquetaPLP2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaServicosValorDeclaradoResponse AtendeCliente.buscaServicosValorDeclarado(buscaServicosValorDeclarado request)
	{
		return base.Channel.buscaServicosValorDeclarado(request);
	}

	public string[] buscaServicosValorDeclarado(string usuario, string senha)
	{
		buscaServicosValorDeclarado buscaServicosValorDeclarado2 = new buscaServicosValorDeclarado();
		buscaServicosValorDeclarado2.usuario = usuario;
		buscaServicosValorDeclarado2.senha = senha;
		buscaServicosValorDeclaradoResponse buscaServicosValorDeclaradoResponse2 = ((AtendeCliente)this).buscaServicosValorDeclarado(buscaServicosValorDeclarado2);
		return buscaServicosValorDeclaradoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaServicosValorDeclaradoResponse> AtendeCliente.buscaServicosValorDeclaradoAsync(buscaServicosValorDeclarado request)
	{
		return base.Channel.buscaServicosValorDeclaradoAsync(request);
	}

	public Task<buscaServicosValorDeclaradoResponse> buscaServicosValorDeclaradoAsync(string usuario, string senha)
	{
		buscaServicosValorDeclarado buscaServicosValorDeclarado2 = new buscaServicosValorDeclarado();
		buscaServicosValorDeclarado2.usuario = usuario;
		buscaServicosValorDeclarado2.senha = senha;
		return ((AtendeCliente)this).buscaServicosValorDeclaradoAsync(buscaServicosValorDeclarado2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	consultaCEPResponse AtendeCliente.consultaCEP(consultaCEP request)
	{
		return base.Channel.consultaCEP(request);
	}

	public enderecoERP consultaCEP(string cep)
	{
		consultaCEP consultaCEP2 = new consultaCEP();
		consultaCEP2.cep = cep;
		consultaCEPResponse consultaCEPResponse2 = ((AtendeCliente)this).consultaCEP(consultaCEP2);
		return consultaCEPResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<consultaCEPResponse> AtendeCliente.consultaCEPAsync(consultaCEP request)
	{
		return base.Channel.consultaCEPAsync(request);
	}

	public Task<consultaCEPResponse> consultaCEPAsync(string cep)
	{
		consultaCEP consultaCEP2 = new consultaCEP();
		consultaCEP2.cep = cep;
		return ((AtendeCliente)this).consultaCEPAsync(consultaCEP2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	integrarUsuarioScolResponse AtendeCliente.integrarUsuarioScol(integrarUsuarioScol request)
	{
		return base.Channel.integrarUsuarioScol(request);
	}

	public bool integrarUsuarioScol(int codAdministrativo, string usuario, string senha)
	{
		integrarUsuarioScol integrarUsuarioScol2 = new integrarUsuarioScol();
		integrarUsuarioScol2.codAdministrativo = codAdministrativo;
		integrarUsuarioScol2.usuario = usuario;
		integrarUsuarioScol2.senha = senha;
		integrarUsuarioScolResponse integrarUsuarioScolResponse2 = ((AtendeCliente)this).integrarUsuarioScol(integrarUsuarioScol2);
		return integrarUsuarioScolResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<integrarUsuarioScolResponse> AtendeCliente.integrarUsuarioScolAsync(integrarUsuarioScol request)
	{
		return base.Channel.integrarUsuarioScolAsync(request);
	}

	public Task<integrarUsuarioScolResponse> integrarUsuarioScolAsync(int codAdministrativo, string usuario, string senha)
	{
		integrarUsuarioScol integrarUsuarioScol2 = new integrarUsuarioScol();
		integrarUsuarioScol2.codAdministrativo = codAdministrativo;
		integrarUsuarioScol2.usuario = usuario;
		integrarUsuarioScol2.senha = senha;
		return ((AtendeCliente)this).integrarUsuarioScolAsync(integrarUsuarioScol2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	atualizaRemessaAgrupadaResponse AtendeCliente.atualizaRemessaAgrupada(atualizaRemessaAgrupada request)
	{
		return base.Channel.atualizaRemessaAgrupada(request);
	}

	public string atualizaRemessaAgrupada(string usuario, string senha)
	{
		atualizaRemessaAgrupada atualizaRemessaAgrupada2 = new atualizaRemessaAgrupada();
		atualizaRemessaAgrupada2.usuario = usuario;
		atualizaRemessaAgrupada2.senha = senha;
		atualizaRemessaAgrupadaResponse atualizaRemessaAgrupadaResponse2 = ((AtendeCliente)this).atualizaRemessaAgrupada(atualizaRemessaAgrupada2);
		return atualizaRemessaAgrupadaResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<atualizaRemessaAgrupadaResponse> AtendeCliente.atualizaRemessaAgrupadaAsync(atualizaRemessaAgrupada request)
	{
		return base.Channel.atualizaRemessaAgrupadaAsync(request);
	}

	public Task<atualizaRemessaAgrupadaResponse> atualizaRemessaAgrupadaAsync(string usuario, string senha)
	{
		atualizaRemessaAgrupada atualizaRemessaAgrupada2 = new atualizaRemessaAgrupada();
		atualizaRemessaAgrupada2.usuario = usuario;
		atualizaRemessaAgrupada2.senha = senha;
		return ((AtendeCliente)this).atualizaRemessaAgrupadaAsync(atualizaRemessaAgrupada2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	consultaSRO_NEWResponse AtendeCliente.consultaSRO_NEW(consultaSRO_NEW request)
	{
		return base.Channel.consultaSRO_NEW(request);
	}

	public string consultaSRO_NEW(string[] listaObjetos, string tipoResultado, string usuarioSro, string senhaSro)
	{
		consultaSRO_NEW consultaSRO_NEW2 = new consultaSRO_NEW();
		consultaSRO_NEW2.listaObjetos = listaObjetos;
		consultaSRO_NEW2.tipoResultado = tipoResultado;
		consultaSRO_NEW2.usuarioSro = usuarioSro;
		consultaSRO_NEW2.senhaSro = senhaSro;
		consultaSRO_NEWResponse consultaSRO_NEWResponse2 = ((AtendeCliente)this).consultaSRO_NEW(consultaSRO_NEW2);
		return consultaSRO_NEWResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<consultaSRO_NEWResponse> AtendeCliente.consultaSRO_NEWAsync(consultaSRO_NEW request)
	{
		return base.Channel.consultaSRO_NEWAsync(request);
	}

	public Task<consultaSRO_NEWResponse> consultaSRO_NEWAsync(string[] listaObjetos, string tipoResultado, string usuarioSro, string senhaSro)
	{
		consultaSRO_NEW consultaSRO_NEW2 = new consultaSRO_NEW();
		consultaSRO_NEW2.listaObjetos = listaObjetos;
		consultaSRO_NEW2.tipoResultado = tipoResultado;
		consultaSRO_NEW2.usuarioSro = usuarioSro;
		consultaSRO_NEW2.senhaSro = senhaSro;
		return ((AtendeCliente)this).consultaSRO_NEWAsync(consultaSRO_NEW2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	solicitaPLPResponse AtendeCliente.solicitaPLP(solicitaPLP request)
	{
		return base.Channel.solicitaPLP(request);
	}

	public string solicitaPLP(long idPlpMaster, string numEtiqueta, string usuario, string senha)
	{
		solicitaPLP solicitaPLP2 = new solicitaPLP();
		solicitaPLP2.idPlpMaster = idPlpMaster;
		solicitaPLP2.numEtiqueta = numEtiqueta;
		solicitaPLP2.usuario = usuario;
		solicitaPLP2.senha = senha;
		solicitaPLPResponse solicitaPLPResponse2 = ((AtendeCliente)this).solicitaPLP(solicitaPLP2);
		return solicitaPLPResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<solicitaPLPResponse> AtendeCliente.solicitaPLPAsync(solicitaPLP request)
	{
		return base.Channel.solicitaPLPAsync(request);
	}

	public Task<solicitaPLPResponse> solicitaPLPAsync(long idPlpMaster, string numEtiqueta, string usuario, string senha)
	{
		solicitaPLP solicitaPLP2 = new solicitaPLP();
		solicitaPLP2.idPlpMaster = idPlpMaster;
		solicitaPLP2.numEtiqueta = numEtiqueta;
		solicitaPLP2.usuario = usuario;
		solicitaPLP2.senha = senha;
		return ((AtendeCliente)this).solicitaPLPAsync(solicitaPLP2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getStatusCartaoPostagemResponse AtendeCliente.getStatusCartaoPostagem(getStatusCartaoPostagem request)
	{
		return base.Channel.getStatusCartaoPostagem(request);
	}

	public statusCartao getStatusCartaoPostagem(string numeroCartaoPostagem, string usuario, string senha)
	{
		getStatusCartaoPostagem getStatusCartaoPostagem2 = new getStatusCartaoPostagem();
		getStatusCartaoPostagem2.numeroCartaoPostagem = numeroCartaoPostagem;
		getStatusCartaoPostagem2.usuario = usuario;
		getStatusCartaoPostagem2.senha = senha;
		getStatusCartaoPostagemResponse statusCartaoPostagem = ((AtendeCliente)this).getStatusCartaoPostagem(getStatusCartaoPostagem2);
		return statusCartaoPostagem.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<getStatusCartaoPostagemResponse> AtendeCliente.getStatusCartaoPostagemAsync(getStatusCartaoPostagem request)
	{
		return base.Channel.getStatusCartaoPostagemAsync(request);
	}

	public Task<getStatusCartaoPostagemResponse> getStatusCartaoPostagemAsync(string numeroCartaoPostagem, string usuario, string senha)
	{
		getStatusCartaoPostagem getStatusCartaoPostagem2 = new getStatusCartaoPostagem();
		getStatusCartaoPostagem2.numeroCartaoPostagem = numeroCartaoPostagem;
		getStatusCartaoPostagem2.usuario = usuario;
		getStatusCartaoPostagem2.senha = senha;
		return ((AtendeCliente)this).getStatusCartaoPostagemAsync(getStatusCartaoPostagem2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaDataAtualResponse AtendeCliente.buscaDataAtual(buscaDataAtual request)
	{
		return base.Channel.buscaDataAtual(request);
	}

	public DateTime buscaDataAtual()
	{
		buscaDataAtual request = new buscaDataAtual();
		buscaDataAtualResponse buscaDataAtualResponse2 = ((AtendeCliente)this).buscaDataAtual(request);
		return buscaDataAtualResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaDataAtualResponse> AtendeCliente.buscaDataAtualAsync(buscaDataAtual request)
	{
		return base.Channel.buscaDataAtualAsync(request);
	}

	public Task<buscaDataAtualResponse> buscaDataAtualAsync()
	{
		buscaDataAtual request = new buscaDataAtual();
		return ((AtendeCliente)this).buscaDataAtualAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaTarifaValeResponse AtendeCliente.buscaTarifaVale(buscaTarifaVale request)
	{
		return base.Channel.buscaTarifaVale(request);
	}

	public valePostal buscaTarifaVale(string codAdministrativo, string usuario, string senha, string codServico, string cepOrigem, string cepDestino, string peso, int codFormato, double comprimento, double altura, double largura, double valorDeclarado, string servicoAdicional)
	{
		buscaTarifaVale buscaTarifaVale2 = new buscaTarifaVale();
		buscaTarifaVale2.codAdministrativo = codAdministrativo;
		buscaTarifaVale2.usuario = usuario;
		buscaTarifaVale2.senha = senha;
		buscaTarifaVale2.codServico = codServico;
		buscaTarifaVale2.cepOrigem = cepOrigem;
		buscaTarifaVale2.cepDestino = cepDestino;
		buscaTarifaVale2.peso = peso;
		buscaTarifaVale2.codFormato = codFormato;
		buscaTarifaVale2.comprimento = comprimento;
		buscaTarifaVale2.altura = altura;
		buscaTarifaVale2.largura = largura;
		buscaTarifaVale2.valorDeclarado = valorDeclarado;
		buscaTarifaVale2.servicoAdicional = servicoAdicional;
		buscaTarifaValeResponse buscaTarifaValeResponse2 = ((AtendeCliente)this).buscaTarifaVale(buscaTarifaVale2);
		return buscaTarifaValeResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaTarifaValeResponse> AtendeCliente.buscaTarifaValeAsync(buscaTarifaVale request)
	{
		return base.Channel.buscaTarifaValeAsync(request);
	}

	public Task<buscaTarifaValeResponse> buscaTarifaValeAsync(string codAdministrativo, string usuario, string senha, string codServico, string cepOrigem, string cepDestino, string peso, int codFormato, double comprimento, double altura, double largura, double valorDeclarado, string servicoAdicional)
	{
		buscaTarifaVale buscaTarifaVale2 = new buscaTarifaVale();
		buscaTarifaVale2.codAdministrativo = codAdministrativo;
		buscaTarifaVale2.usuario = usuario;
		buscaTarifaVale2.senha = senha;
		buscaTarifaVale2.codServico = codServico;
		buscaTarifaVale2.cepOrigem = cepOrigem;
		buscaTarifaVale2.cepDestino = cepDestino;
		buscaTarifaVale2.peso = peso;
		buscaTarifaVale2.codFormato = codFormato;
		buscaTarifaVale2.comprimento = comprimento;
		buscaTarifaVale2.altura = altura;
		buscaTarifaVale2.largura = largura;
		buscaTarifaVale2.valorDeclarado = valorDeclarado;
		buscaTarifaVale2.servicoAdicional = servicoAdicional;
		return ((AtendeCliente)this).buscaTarifaValeAsync(buscaTarifaVale2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	validarPostagemSimultaneaResponse AtendeCliente.validarPostagemSimultanea(validarPostagemSimultanea request)
	{
		return base.Channel.validarPostagemSimultanea(request);
	}

	public bool validarPostagemSimultanea(int codAdministrativo, int codigoServico, string idCartaoPostagem, string cepDestinatario, coletaSimultanea coleta, string usuario, string senha)
	{
		validarPostagemSimultanea validarPostagemSimultanea2 = new validarPostagemSimultanea();
		validarPostagemSimultanea2.codAdministrativo = codAdministrativo;
		validarPostagemSimultanea2.codigoServico = codigoServico;
		validarPostagemSimultanea2.idCartaoPostagem = idCartaoPostagem;
		validarPostagemSimultanea2.cepDestinatario = cepDestinatario;
		validarPostagemSimultanea2.coleta = coleta;
		validarPostagemSimultanea2.usuario = usuario;
		validarPostagemSimultanea2.senha = senha;
		validarPostagemSimultaneaResponse validarPostagemSimultaneaResponse2 = ((AtendeCliente)this).validarPostagemSimultanea(validarPostagemSimultanea2);
		return validarPostagemSimultaneaResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<validarPostagemSimultaneaResponse> AtendeCliente.validarPostagemSimultaneaAsync(validarPostagemSimultanea request)
	{
		return base.Channel.validarPostagemSimultaneaAsync(request);
	}

	public Task<validarPostagemSimultaneaResponse> validarPostagemSimultaneaAsync(int codAdministrativo, int codigoServico, string idCartaoPostagem, string cepDestinatario, coletaSimultanea coleta, string usuario, string senha)
	{
		validarPostagemSimultanea validarPostagemSimultanea2 = new validarPostagemSimultanea();
		validarPostagemSimultanea2.codAdministrativo = codAdministrativo;
		validarPostagemSimultanea2.codigoServico = codigoServico;
		validarPostagemSimultanea2.idCartaoPostagem = idCartaoPostagem;
		validarPostagemSimultanea2.cepDestinatario = cepDestinatario;
		validarPostagemSimultanea2.coleta = coleta;
		validarPostagemSimultanea2.usuario = usuario;
		validarPostagemSimultanea2.senha = senha;
		return ((AtendeCliente)this).validarPostagemSimultaneaAsync(validarPostagemSimultanea2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	getStatusPLPResponse AtendeCliente.getStatusPLP(getStatusPLP request)
	{
		return base.Channel.getStatusPLP(request);
	}

	public statusPlp getStatusPLP(objetoPostal[] arg0, string arg1)
	{
		getStatusPLP getStatusPLP2 = new getStatusPLP();
		getStatusPLP2.arg0 = arg0;
		getStatusPLP2.arg1 = arg1;
		getStatusPLPResponse statusPLP = ((AtendeCliente)this).getStatusPLP(getStatusPLP2);
		return statusPLP.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<getStatusPLPResponse> AtendeCliente.getStatusPLPAsync(getStatusPLP request)
	{
		return base.Channel.getStatusPLPAsync(request);
	}

	public Task<getStatusPLPResponse> getStatusPLPAsync(objetoPostal[] arg0, string arg1)
	{
		getStatusPLP getStatusPLP2 = new getStatusPLP();
		getStatusPLP2.arg0 = arg0;
		getStatusPLP2.arg1 = arg1;
		return ((AtendeCliente)this).getStatusPLPAsync(getStatusPLP2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaServicosXServicosAdicionaisResponse AtendeCliente.buscaServicosXServicosAdicionais(buscaServicosXServicosAdicionais request)
	{
		return base.Channel.buscaServicosXServicosAdicionais(request);
	}

	public string[] buscaServicosXServicosAdicionais(string usuario, string senha)
	{
		buscaServicosXServicosAdicionais buscaServicosXServicosAdicionais2 = new buscaServicosXServicosAdicionais();
		buscaServicosXServicosAdicionais2.usuario = usuario;
		buscaServicosXServicosAdicionais2.senha = senha;
		buscaServicosXServicosAdicionaisResponse buscaServicosXServicosAdicionaisResponse2 = ((AtendeCliente)this).buscaServicosXServicosAdicionais(buscaServicosXServicosAdicionais2);
		return buscaServicosXServicosAdicionaisResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaServicosXServicosAdicionaisResponse> AtendeCliente.buscaServicosXServicosAdicionaisAsync(buscaServicosXServicosAdicionais request)
	{
		return base.Channel.buscaServicosXServicosAdicionaisAsync(request);
	}

	public Task<buscaServicosXServicosAdicionaisResponse> buscaServicosXServicosAdicionaisAsync(string usuario, string senha)
	{
		buscaServicosXServicosAdicionais buscaServicosXServicosAdicionais2 = new buscaServicosXServicosAdicionais();
		buscaServicosXServicosAdicionais2.usuario = usuario;
		buscaServicosXServicosAdicionais2.senha = senha;
		return ((AtendeCliente)this).buscaServicosXServicosAdicionaisAsync(buscaServicosXServicosAdicionais2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	cancelarPedidoScolResponse AtendeCliente.cancelarPedidoScol(cancelarPedidoScol request)
	{
		return base.Channel.cancelarPedidoScol(request);
	}

	public retornoCancelamento cancelarPedidoScol(string codAdministrativo, string idPostagem, string tipo, string usuario, string senha)
	{
		cancelarPedidoScol cancelarPedidoScol2 = new cancelarPedidoScol();
		cancelarPedidoScol2.codAdministrativo = codAdministrativo;
		cancelarPedidoScol2.idPostagem = idPostagem;
		cancelarPedidoScol2.tipo = tipo;
		cancelarPedidoScol2.usuario = usuario;
		cancelarPedidoScol2.senha = senha;
		cancelarPedidoScolResponse cancelarPedidoScolResponse2 = ((AtendeCliente)this).cancelarPedidoScol(cancelarPedidoScol2);
		return cancelarPedidoScolResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<cancelarPedidoScolResponse> AtendeCliente.cancelarPedidoScolAsync(cancelarPedidoScol request)
	{
		return base.Channel.cancelarPedidoScolAsync(request);
	}

	public Task<cancelarPedidoScolResponse> cancelarPedidoScolAsync(string codAdministrativo, string idPostagem, string tipo, string usuario, string senha)
	{
		cancelarPedidoScol cancelarPedidoScol2 = new cancelarPedidoScol();
		cancelarPedidoScol2.codAdministrativo = codAdministrativo;
		cancelarPedidoScol2.idPostagem = idPostagem;
		cancelarPedidoScol2.tipo = tipo;
		cancelarPedidoScol2.usuario = usuario;
		cancelarPedidoScol2.senha = senha;
		return ((AtendeCliente)this).cancelarPedidoScolAsync(cancelarPedidoScol2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	bloquearObjetoResponse AtendeCliente.bloquearObjeto(bloquearObjeto request)
	{
		return base.Channel.bloquearObjeto(request);
	}

	public string bloquearObjeto(string numeroEtiqueta, long idPlp, tipoBloqueio tipoBloqueio, acao acao, string usuario, string senha)
	{
		bloquearObjeto bloquearObjeto2 = new bloquearObjeto();
		bloquearObjeto2.numeroEtiqueta = numeroEtiqueta;
		bloquearObjeto2.idPlp = idPlp;
		bloquearObjeto2.tipoBloqueio = tipoBloqueio;
		bloquearObjeto2.acao = acao;
		bloquearObjeto2.usuario = usuario;
		bloquearObjeto2.senha = senha;
		bloquearObjetoResponse bloquearObjetoResponse2 = ((AtendeCliente)this).bloquearObjeto(bloquearObjeto2);
		return bloquearObjetoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<bloquearObjetoResponse> AtendeCliente.bloquearObjetoAsync(bloquearObjeto request)
	{
		return base.Channel.bloquearObjetoAsync(request);
	}

	public Task<bloquearObjetoResponse> bloquearObjetoAsync(string numeroEtiqueta, long idPlp, tipoBloqueio tipoBloqueio, acao acao, string usuario, string senha)
	{
		bloquearObjeto bloquearObjeto2 = new bloquearObjeto();
		bloquearObjeto2.numeroEtiqueta = numeroEtiqueta;
		bloquearObjeto2.idPlp = idPlp;
		bloquearObjeto2.tipoBloqueio = tipoBloqueio;
		bloquearObjeto2.acao = acao;
		bloquearObjeto2.usuario = usuario;
		bloquearObjeto2.senha = senha;
		return ((AtendeCliente)this).bloquearObjetoAsync(bloquearObjeto2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaContratoResponse AtendeCliente.buscaContrato(buscaContrato request)
	{
		return base.Channel.buscaContrato(request);
	}

	public contratoERP buscaContrato(string numero, long diretoria, string usuario, string senha)
	{
		buscaContrato buscaContrato2 = new buscaContrato();
		buscaContrato2.numero = numero;
		buscaContrato2.diretoria = diretoria;
		buscaContrato2.usuario = usuario;
		buscaContrato2.senha = senha;
		buscaContratoResponse buscaContratoResponse2 = ((AtendeCliente)this).buscaContrato(buscaContrato2);
		return buscaContratoResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaContratoResponse> AtendeCliente.buscaContratoAsync(buscaContrato request)
	{
		return base.Channel.buscaContratoAsync(request);
	}

	public Task<buscaContratoResponse> buscaContratoAsync(string numero, long diretoria, string usuario, string senha)
	{
		buscaContrato buscaContrato2 = new buscaContrato();
		buscaContrato2.numero = numero;
		buscaContrato2.diretoria = diretoria;
		buscaContrato2.usuario = usuario;
		buscaContrato2.senha = senha;
		return ((AtendeCliente)this).buscaContratoAsync(buscaContrato2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	solicitaEtiquetasResponse AtendeCliente.solicitaEtiquetas(solicitaEtiquetas request)
	{
		return base.Channel.solicitaEtiquetas(request);
	}

	public string solicitaEtiquetas(string tipoDestinatario, string identificador, long idServico, int qtdEtiquetas, string usuario, string senha)
	{
		solicitaEtiquetas solicitaEtiquetas2 = new solicitaEtiquetas();
		solicitaEtiquetas2.tipoDestinatario = tipoDestinatario;
		solicitaEtiquetas2.identificador = identificador;
		solicitaEtiquetas2.idServico = idServico;
		solicitaEtiquetas2.qtdEtiquetas = qtdEtiquetas;
		solicitaEtiquetas2.usuario = usuario;
		solicitaEtiquetas2.senha = senha;
		solicitaEtiquetasResponse solicitaEtiquetasResponse2 = ((AtendeCliente)this).solicitaEtiquetas(solicitaEtiquetas2);
		return solicitaEtiquetasResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<solicitaEtiquetasResponse> AtendeCliente.solicitaEtiquetasAsync(solicitaEtiquetas request)
	{
		return base.Channel.solicitaEtiquetasAsync(request);
	}

	public Task<solicitaEtiquetasResponse> solicitaEtiquetasAsync(string tipoDestinatario, string identificador, long idServico, int qtdEtiquetas, string usuario, string senha)
	{
		solicitaEtiquetas solicitaEtiquetas2 = new solicitaEtiquetas();
		solicitaEtiquetas2.tipoDestinatario = tipoDestinatario;
		solicitaEtiquetas2.identificador = identificador;
		solicitaEtiquetas2.idServico = idServico;
		solicitaEtiquetas2.qtdEtiquetas = qtdEtiquetas;
		solicitaEtiquetas2.usuario = usuario;
		solicitaEtiquetas2.senha = senha;
		return ((AtendeCliente)this).solicitaEtiquetasAsync(solicitaEtiquetas2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	solicitaXmlPlpResponse AtendeCliente.solicitaXmlPlp(solicitaXmlPlp request)
	{
		return base.Channel.solicitaXmlPlp(request);
	}

	public string solicitaXmlPlp(long idPlpMaster, string usuario, string senha)
	{
		solicitaXmlPlp solicitaXmlPlp2 = new solicitaXmlPlp();
		solicitaXmlPlp2.idPlpMaster = idPlpMaster;
		solicitaXmlPlp2.usuario = usuario;
		solicitaXmlPlp2.senha = senha;
		solicitaXmlPlpResponse solicitaXmlPlpResponse2 = ((AtendeCliente)this).solicitaXmlPlp(solicitaXmlPlp2);
		return solicitaXmlPlpResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<solicitaXmlPlpResponse> AtendeCliente.solicitaXmlPlpAsync(solicitaXmlPlp request)
	{
		return base.Channel.solicitaXmlPlpAsync(request);
	}

	public Task<solicitaXmlPlpResponse> solicitaXmlPlpAsync(long idPlpMaster, string usuario, string senha)
	{
		solicitaXmlPlp solicitaXmlPlp2 = new solicitaXmlPlp();
		solicitaXmlPlp2.idPlpMaster = idPlpMaster;
		solicitaXmlPlp2.usuario = usuario;
		solicitaXmlPlp2.senha = senha;
		return ((AtendeCliente)this).solicitaXmlPlpAsync(solicitaXmlPlp2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	validarPostagemReversaResponse AtendeCliente.validarPostagemReversa(validarPostagemReversa request)
	{
		return base.Channel.validarPostagemReversa(request);
	}

	public bool validarPostagemReversa(string codAdministrativo, string codigoServico, string cepDestinatario, string idCartaoPostagem, coletaReversa coleta, string usuario, string senha)
	{
		validarPostagemReversa validarPostagemReversa2 = new validarPostagemReversa();
		validarPostagemReversa2.codAdministrativo = codAdministrativo;
		validarPostagemReversa2.codigoServico = codigoServico;
		validarPostagemReversa2.cepDestinatario = cepDestinatario;
		validarPostagemReversa2.idCartaoPostagem = idCartaoPostagem;
		validarPostagemReversa2.coleta = coleta;
		validarPostagemReversa2.usuario = usuario;
		validarPostagemReversa2.senha = senha;
		validarPostagemReversaResponse validarPostagemReversaResponse2 = ((AtendeCliente)this).validarPostagemReversa(validarPostagemReversa2);
		return validarPostagemReversaResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<validarPostagemReversaResponse> AtendeCliente.validarPostagemReversaAsync(validarPostagemReversa request)
	{
		return base.Channel.validarPostagemReversaAsync(request);
	}

	public Task<validarPostagemReversaResponse> validarPostagemReversaAsync(string codAdministrativo, string codigoServico, string cepDestinatario, string idCartaoPostagem, coletaReversa coleta, string usuario, string senha)
	{
		validarPostagemReversa validarPostagemReversa2 = new validarPostagemReversa();
		validarPostagemReversa2.codAdministrativo = codAdministrativo;
		validarPostagemReversa2.codigoServico = codigoServico;
		validarPostagemReversa2.cepDestinatario = cepDestinatario;
		validarPostagemReversa2.idCartaoPostagem = idCartaoPostagem;
		validarPostagemReversa2.coleta = coleta;
		validarPostagemReversa2.usuario = usuario;
		validarPostagemReversa2.senha = senha;
		return ((AtendeCliente)this).validarPostagemReversaAsync(validarPostagemReversa2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaClienteResponse AtendeCliente.buscaCliente(buscaCliente request)
	{
		return base.Channel.buscaCliente(request);
	}

	public clienteERP buscaCliente(string idContrato, string idCartaoPostagem, string usuario, string senha)
	{
		buscaCliente buscaCliente2 = new buscaCliente();
		buscaCliente2.idContrato = idContrato;
		buscaCliente2.idCartaoPostagem = idCartaoPostagem;
		buscaCliente2.usuario = usuario;
		buscaCliente2.senha = senha;
		buscaClienteResponse buscaClienteResponse2 = ((AtendeCliente)this).buscaCliente(buscaCliente2);
		return buscaClienteResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaClienteResponse> AtendeCliente.buscaClienteAsync(buscaCliente request)
	{
		return base.Channel.buscaClienteAsync(request);
	}

	public Task<buscaClienteResponse> buscaClienteAsync(string idContrato, string idCartaoPostagem, string usuario, string senha)
	{
		buscaCliente buscaCliente2 = new buscaCliente();
		buscaCliente2.idContrato = idContrato;
		buscaCliente2.idCartaoPostagem = idCartaoPostagem;
		buscaCliente2.usuario = usuario;
		buscaCliente2.senha = senha;
		return ((AtendeCliente)this).buscaClienteAsync(buscaCliente2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaPagamentoEntregaResponse AtendeCliente.buscaPagamentoEntrega(buscaPagamentoEntrega request)
	{
		return base.Channel.buscaPagamentoEntrega(request);
	}

	public string buscaPagamentoEntrega(string usuario, string senha, string contrato, string dataInicio, string dataFim, string etiqueta)
	{
		buscaPagamentoEntrega buscaPagamentoEntrega2 = new buscaPagamentoEntrega();
		buscaPagamentoEntrega2.usuario = usuario;
		buscaPagamentoEntrega2.senha = senha;
		buscaPagamentoEntrega2.contrato = contrato;
		buscaPagamentoEntrega2.dataInicio = dataInicio;
		buscaPagamentoEntrega2.dataFim = dataFim;
		buscaPagamentoEntrega2.etiqueta = etiqueta;
		buscaPagamentoEntregaResponse buscaPagamentoEntregaResponse2 = ((AtendeCliente)this).buscaPagamentoEntrega(buscaPagamentoEntrega2);
		return buscaPagamentoEntregaResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaPagamentoEntregaResponse> AtendeCliente.buscaPagamentoEntregaAsync(buscaPagamentoEntrega request)
	{
		return base.Channel.buscaPagamentoEntregaAsync(request);
	}

	public Task<buscaPagamentoEntregaResponse> buscaPagamentoEntregaAsync(string usuario, string senha, string contrato, string dataInicio, string dataFim, string etiqueta)
	{
		buscaPagamentoEntrega buscaPagamentoEntrega2 = new buscaPagamentoEntrega();
		buscaPagamentoEntrega2.usuario = usuario;
		buscaPagamentoEntrega2.senha = senha;
		buscaPagamentoEntrega2.contrato = contrato;
		buscaPagamentoEntrega2.dataInicio = dataInicio;
		buscaPagamentoEntrega2.dataFim = dataFim;
		buscaPagamentoEntrega2.etiqueta = etiqueta;
		return ((AtendeCliente)this).buscaPagamentoEntregaAsync(buscaPagamentoEntrega2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	solicitarPostagemScolResponse AtendeCliente.solicitarPostagemScol(solicitarPostagemScol request)
	{
		return base.Channel.solicitarPostagemScol(request);
	}

	public string solicitarPostagemScol(int codAdministrativo, string xml, string usuario, string senha)
	{
		solicitarPostagemScol solicitarPostagemScol2 = new solicitarPostagemScol();
		solicitarPostagemScol2.codAdministrativo = codAdministrativo;
		solicitarPostagemScol2.xml = xml;
		solicitarPostagemScol2.usuario = usuario;
		solicitarPostagemScol2.senha = senha;
		solicitarPostagemScolResponse solicitarPostagemScolResponse2 = ((AtendeCliente)this).solicitarPostagemScol(solicitarPostagemScol2);
		return solicitarPostagemScolResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<solicitarPostagemScolResponse> AtendeCliente.solicitarPostagemScolAsync(solicitarPostagemScol request)
	{
		return base.Channel.solicitarPostagemScolAsync(request);
	}

	public Task<solicitarPostagemScolResponse> solicitarPostagemScolAsync(int codAdministrativo, string xml, string usuario, string senha)
	{
		solicitarPostagemScol solicitarPostagemScol2 = new solicitarPostagemScol();
		solicitarPostagemScol2.codAdministrativo = codAdministrativo;
		solicitarPostagemScol2.xml = xml;
		solicitarPostagemScol2.usuario = usuario;
		solicitarPostagemScol2.senha = senha;
		return ((AtendeCliente)this).solicitarPostagemScolAsync(solicitarPostagemScol2);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	buscaServicosResponse AtendeCliente.buscaServicos(buscaServicos request)
	{
		return base.Channel.buscaServicos(request);
	}

	public servicoERP[] buscaServicos(string idContrato, string idCartaoPostagem, string usuario, string senha)
	{
		buscaServicos buscaServicos2 = new buscaServicos();
		buscaServicos2.idContrato = idContrato;
		buscaServicos2.idCartaoPostagem = idCartaoPostagem;
		buscaServicos2.usuario = usuario;
		buscaServicos2.senha = senha;
		buscaServicosResponse buscaServicosResponse2 = ((AtendeCliente)this).buscaServicos(buscaServicos2);
		return buscaServicosResponse2.@return;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<buscaServicosResponse> AtendeCliente.buscaServicosAsync(buscaServicos request)
	{
		return base.Channel.buscaServicosAsync(request);
	}

	public Task<buscaServicosResponse> buscaServicosAsync(string idContrato, string idCartaoPostagem, string usuario, string senha)
	{
		buscaServicos buscaServicos2 = new buscaServicos();
		buscaServicos2.idContrato = idContrato;
		buscaServicos2.idCartaoPostagem = idCartaoPostagem;
		buscaServicos2.usuario = usuario;
		buscaServicos2.senha = senha;
		return ((AtendeCliente)this).buscaServicosAsync(buscaServicos2);
	}
}
