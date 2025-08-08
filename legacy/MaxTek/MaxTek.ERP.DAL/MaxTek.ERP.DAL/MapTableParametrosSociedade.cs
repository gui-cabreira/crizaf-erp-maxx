using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableParametrosSociedade
{
	public int id;

	public string cnpj;

	public string razaoSocial;

	public string nomeFantasia;

	public string endereco;

	public string bairro;

	public int codigoCidade;

	public int codigoEstado;

	public int codigoPais;

	public string codigoPostal;

	public string telefone;

	public string inscricaoEstadual;

	public string email;

	public string site;

	public Image logo;
}
