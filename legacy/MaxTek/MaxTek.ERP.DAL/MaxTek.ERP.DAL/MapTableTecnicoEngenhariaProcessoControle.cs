using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoControle
{
	public int id;

	public string codigoProcessoControle;

	public string descricaoProcessoControle;

	public string desenho;

	public string revisao;

	public Image imagem;

	public DateTime dataCadastro;

	public DateTime dataAtualizacao;

	public int codigoUsuario;

	public string comentario;
}
