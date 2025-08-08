using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableSistemaUsuarios
{
	public int id;

	public string nomeLogon;

	public int codigoFuncionario;

	public string email;

	public int codigoEmpresa;

	public string senha;

	public string dicaSenha;
}
