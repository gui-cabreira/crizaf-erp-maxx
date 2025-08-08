using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialEntidade
{
	public int codigo;

	public int codigoGpsCliente;

	public int CodigoGpsFornecedor;

	public bool IsCliente;

	public bool isFornecedor;

	public bool isRepresentante;

	public bool isSubContratado;

	public bool isTransportadora;

	public string nomeFantasia;

	public string razaoSocial;

	public string cnpj;

	public string inscricaoEstadual;

	public string inscricaoMunicipal;

	public int codigoEspecialidade;

	public string endereco;

	public string complemento;

	public string bairro;

	public string cep;

	public string cidade;

	public string pais;

	public string uf;

	public string telefone;

	public string fax;

	public string site;

	public string email;

	public bool isProspecto;

	public int codigoCertificacao;

	public DateTime dataValidadeCertificacao;

	public DateTime dataCadastro;

	public DateTime dataAtualizacao;

	public int codigoRepresentante;

	public int codigoFuncionario;

	public int codigoTipoPagamento;

	public int codigoModoPagamento;

	public decimal valorCredito;

	public bool isBloqueado;

	public bool IsQualificado;

	public string notaIqf;

	public int codigoCfopPadrao;

	public Image logo;
}
