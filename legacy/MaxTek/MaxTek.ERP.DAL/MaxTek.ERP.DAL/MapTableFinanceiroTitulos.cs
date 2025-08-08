using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableFinanceiroTitulos
{
	public int id;

	public DateTime dataMovimento;

	public DateTime dataEmissao;

	public int codigoTipo;

	public bool isPrevisao;

	public string descricaoTitulo;

	public int codigoEntidade;

	public string documento;

	public int sequenciaDe;

	public int sequenciaAte;

	public DateTime dataVencimento;

	public DateTime dataVencimentoNegociado;

	public decimal valorTitulo;

	public decimal valorTituloNegociado;

	public string competencia;

	public string naturezaOperacao;

	public int codigoContaContabil;

	public int codigoBanco;

	public decimal percentualJuros;

	public decimal percentualDesconto;

	public decimal valorJuros;

	public decimal valorDesconto;

	public decimal valorPago;

	public DateTime dataPagamento;

	public bool isPago;

	public int codigoMeioPagamento;

	public decimal percentualPisCofins;

	public decimal valorPisCofins;

	public DateTime dataCadastramento;

	public DateTime dataAtualizacao;

	public int codigoFuncionarioCadastramento;

	public int codigoFuncionarioAtualizacao;

	public int codigoTipoEntidade;

	public int codigoOrigem;

	public int codigoCentroCustos;

	public int codigoSubCentroCustos;

	public string comentario;

	public int codigoTipoDocumentoOrigem;

	public int codigoDocumentoOrigem;

	public int codigoDocumentoOrigemItem;

	public string razaoSocial;

	public string cnpj;

	public decimal valorDocumentoOrigem;
}
