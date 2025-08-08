using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class Campos : BusinessObjectBase
{
	private MapTableCampos _dados;

	public int Id => _dados.id;

	public string NomeEsquema => _dados.nomeEsquema;

	public string NomeColuna => _dados.nomeColuna;

	public string TipoDadoBanco => _dados.tipoDado;

	public int QuantidadeCaracteres => _dados.quantidadeCaracteres;

	public string TipoDado
	{
		get
		{
			string result = "string";
			switch (_dados.tipoDado)
			{
			case "int":
				result = "int";
				break;
			case "double":
			case "decimal":
				result = "decimal";
				break;
			case "bit":
				result = "bool";
				break;
			case "datetime":
				result = "DateTime";
				break;
			case "nvarchar":
				result = "string";
				break;
			case "image":
				result = "Image";
				break;
			}
			return result;
		}
	}

	internal void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableCampos);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public Campos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public Campos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableCampos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
