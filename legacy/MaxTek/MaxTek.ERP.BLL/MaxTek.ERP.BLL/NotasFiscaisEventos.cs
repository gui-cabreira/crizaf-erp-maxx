using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotasFiscaisEventos : BusinessObjectBase
{
	private MapTableNotasFiscaisEventos _dados;

	private NotaFiscalNotasFiscais _notaFiscal;

	public int CodigoEmpresa
	{
		get
		{
			return (_dados.codigoEmpresa == 0) ? 1 : _dados.codigoEmpresa;
		}
		set
		{
			if (_dados.codigoEmpresa != value)
			{
				_dados.codigoEmpresa = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoNotaFiscal
	{
		get
		{
			return _dados.codigoNotaFiscal;
		}
		set
		{
			if (_dados.codigoNotaFiscal != value)
			{
				_dados.codigoNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSerieNotaFiscal
	{
		get
		{
			return _dados.codigoSerieNotaFiscal;
		}
		set
		{
			if (_dados.codigoSerieNotaFiscal != value)
			{
				_dados.codigoSerieNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEvento
	{
		get
		{
			return _dados.codigoEvento;
		}
		set
		{
			if (_dados.codigoEvento != value)
			{
				_dados.codigoEvento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSequenciaEvento
	{
		get
		{
			return _dados.codigoSequenciaEvento;
		}
		set
		{
			if (_dados.codigoSequenciaEvento != value)
			{
				_dados.codigoSequenciaEvento = value;
				PropertyHasChanged();
			}
		}
	}

	public string Evento
	{
		get
		{
			return _dados.evento;
		}
		set
		{
			if (_dados.evento != value)
			{
				_dados.evento = value;
				PropertyHasChanged();
			}
		}
	}

	public string Descricao
	{
		get
		{
			return _dados.descricao;
		}
		set
		{
			if (_dados.descricao != value)
			{
				_dados.descricao = value;
				PropertyHasChanged();
			}
		}
	}

	public string Protocolo
	{
		get
		{
			return _dados.protocolo;
		}
		set
		{
			if (_dados.protocolo != value)
			{
				_dados.protocolo = value;
				PropertyHasChanged();
			}
		}
	}

	public string DataEvento
	{
		get
		{
			return _dados.dataEvento;
		}
		set
		{
			if (_dados.dataEvento != value)
			{
				_dados.dataEvento = value;
				PropertyHasChanged();
			}
		}
	}

	public NotaFiscalNotasFiscais NotaFiscalRef
	{
		get
		{
			if (_notaFiscal == null)
			{
				_notaFiscal = ModuloNotaFiscal.ObterNotaFiscalNotasFiscais(CodigoEmpresa, CodigoNotaFiscal, CodigoSerieNotaFiscal);
			}
			return _notaFiscal;
		}
	}

	public DateTime DataEventoCal
	{
		get
		{
			DateTime result = new DateTime(1900, 1, 1);
			try
			{
				int year = int.Parse(DataEvento.Substring(0, 4));
				int month = int.Parse(DataEvento.Substring(5, 2));
				int day = int.Parse(DataEvento.Substring(8, 2));
				result = new DateTime(year, month, day);
				return result;
			}
			catch
			{
			}
			return result;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotasFiscaisEventos);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotasFiscaisEventos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotasFiscaisEventos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotasFiscaisEventos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
