using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialEntidadeEvento
{
	public int codigo;

	public DateTime dataCadastro;

	public int codigoFuncionario;

	public int codigoEntidade;

	public int codigoContato;

	public int codigoTipoAtendimento;

	public string assunto;

	public string solicitacao;

	public string comentario;

	public int codigoStatusAtendimento;

	public bool isAcompanhar;

	public DateTime dataAcompanhamento;
}
