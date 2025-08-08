using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloComercialVendas
{
	private static IComercialVendasPedidos _comercialVendasPedidosDao = AcessoDados.ComercialVendasPedidosDAO;

	private static IComercialVendasPedidosItens _comercialVendasPedidosItensDao = AcessoDados.ComercialVendasPedidosItensDAO;

	private static IComercialVendasPedidosItensCadencia _comercialVendasPedidosItensCadenciaDao = AcessoDados.ComercialVendasPedidosItensCadenciaDAO;

	private static IComercialVendasCatalogos _comercialVendasCatalogosDao = AcessoDados.ComercialVendasCatalogosDAO;

	private static IComercialVendasCatalogosCodigos _comercialVendasCatalogosCodigosDao = AcessoDados.ComercialVendasCatalogosCodigosDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidos> ObterTodosComercialVendasPedidos()
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidos>((IList)_comercialVendasPedidosDao.ObterTodosComercialVendasPedidos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidos> ObterTodosComercialVendasPedidosPorDataCadastro(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidos>((IList)_comercialVendasPedidosDao.ObterTodosComercialVendasPedidosPorDataCadastro(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidos ObterComercialVendasPedidos(int id)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidos>(_comercialVendasPedidosDao.ObterComercialVendasPedidos(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidos ObterComercialVendasPedidos(ComercialVendasPedidos comercialVendasPedidos)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidos>(_comercialVendasPedidosDao.ObterComercialVendasPedidos((MapTableComercialVendasPedidos)comercialVendasPedidos.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialVendasPedidos(ComercialVendasPedidos comercialVendasPedidos)
	{
		return _comercialVendasPedidosDao.InserirComercialVendasPedidos((MapTableComercialVendasPedidos)comercialVendasPedidos.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialVendasPedidos(ComercialVendasPedidos comercialVendasPedidos, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialVendasPedidosDao.AlterarComercialVendasPedidos((MapTableComercialVendasPedidos)comercialVendasPedidos.ObterDadosMapeados(), camposAlterados);
		comercialVendasPedidos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialVendasPedidos(int id)
	{
		return _comercialVendasPedidosDao.ExcluirComercialVendasPedidos(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens()
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidosItens>((IList)_comercialVendasPedidosItensDao.ObterTodosComercialVendasPedidosItens());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens(int codigoPedido)
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidosItens>((IList)_comercialVendasPedidosItensDao.ObterTodosComercialVendasPedidosItens(codigoPedido));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidosItens ObterComercialVendasPedidosItens(int id)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidosItens>(_comercialVendasPedidosItensDao.ObterComercialVendasPedidosItens(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidosItens ObterComercialVendasPedidosItens(ComercialVendasPedidosItens comercialVendasPedidosItens)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidosItens>(_comercialVendasPedidosItensDao.ObterComercialVendasPedidosItens((MapTableComercialVendasPedidosItens)comercialVendasPedidosItens.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialVendasPedidosItens(ComercialVendasPedidosItens comercialVendasPedidosItens)
	{
		return _comercialVendasPedidosItensDao.InserirComercialVendasPedidosItens((MapTableComercialVendasPedidosItens)comercialVendasPedidosItens.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialVendasPedidosItens(ComercialVendasPedidosItens comercialVendasPedidosItens, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialVendasPedidosItensDao.AlterarComercialVendasPedidosItens((MapTableComercialVendasPedidosItens)comercialVendasPedidosItens.ObterDadosMapeados(), camposAlterados);
		comercialVendasPedidosItens.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialVendasPedidosItens(int id)
	{
		return _comercialVendasPedidosItensDao.ExcluirComercialVendasPedidosItens(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidosItensCadencia> ObterTodosComercialVendasPedidosItensCadencia()
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidosItensCadencia>((IList)_comercialVendasPedidosItensCadenciaDao.ObterTodosComercialVendasPedidosItensCadencia());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasPedidosItensCadencia> ObterTodosComercialVendasPedidosItensCadencia(int codigoPedidoItem)
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasPedidosItensCadencia>((IList)_comercialVendasPedidosItensCadenciaDao.ObterTodosComercialVendasPedidosItensCadencia(codigoPedidoItem));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidosItensCadencia ObterComercialVendasPedidosItensCadencia(int id)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidosItensCadencia>(_comercialVendasPedidosItensCadenciaDao.ObterComercialVendasPedidosItensCadencia(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasPedidosItensCadencia ObterComercialVendasPedidosItensCadencia(ComercialVendasPedidosItensCadencia comercialVendasPedidosItensCadencia)
	{
		return ObjectDataMapper.MapObject<ComercialVendasPedidosItensCadencia>(_comercialVendasPedidosItensCadenciaDao.ObterComercialVendasPedidosItensCadencia((MapTableComercialVendasPedidosItensCadencia)comercialVendasPedidosItensCadencia.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialVendasPedidosItensCadencia(ComercialVendasPedidosItensCadencia comercialVendasPedidosItensCadencia)
	{
		return _comercialVendasPedidosItensCadenciaDao.InserirComercialVendasPedidosItensCadencia((MapTableComercialVendasPedidosItensCadencia)comercialVendasPedidosItensCadencia.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialVendasPedidosItensCadencia(ComercialVendasPedidosItensCadencia comercialVendasPedidosItensCadencia, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialVendasPedidosItensCadenciaDao.AlterarComercialVendasPedidosItensCadencia((MapTableComercialVendasPedidosItensCadencia)comercialVendasPedidosItensCadencia.ObterDadosMapeados(), camposAlterados);
		comercialVendasPedidosItensCadencia.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialVendasPedidosItensCadencia(int id)
	{
		return _comercialVendasPedidosItensCadenciaDao.ExcluirComercialVendasPedidosItensCadencia(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasCatalogos> ObterTodosComercialVendasCatalogos()
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasCatalogos>((IList)_comercialVendasCatalogosDao.ObterTodosComercialVendasCatalogos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasCatalogos ObterComercialVendasCatalogos(int id)
	{
		return ObjectDataMapper.MapObject<ComercialVendasCatalogos>(_comercialVendasCatalogosDao.ObterComercialVendasCatalogos(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasCatalogos ObterComercialVendasCatalogos(ComercialVendasCatalogos comercialVendasCatalogos)
	{
		return ObjectDataMapper.MapObject<ComercialVendasCatalogos>(_comercialVendasCatalogosDao.ObterComercialVendasCatalogos((MapTableComercialVendasCatalogos)comercialVendasCatalogos.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialVendasCatalogos(ComercialVendasCatalogos comercialVendasCatalogos)
	{
		return _comercialVendasCatalogosDao.InserirComercialVendasCatalogos((MapTableComercialVendasCatalogos)comercialVendasCatalogos.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialVendasCatalogos(ComercialVendasCatalogos comercialVendasCatalogos, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialVendasCatalogosDao.AlterarComercialVendasCatalogos((MapTableComercialVendasCatalogos)comercialVendasCatalogos.ObterDadosMapeados(), camposAlterados);
		comercialVendasCatalogos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialVendasCatalogos(int id)
	{
		return _comercialVendasCatalogosDao.ExcluirComercialVendasCatalogos(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasCatalogosCodigos> ObterTodosComercialVendasCatalogosCodigos()
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasCatalogosCodigos>((IList)_comercialVendasCatalogosCodigosDao.ObterTodosComercialVendasCatalogosCodigos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialVendasCatalogosCodigos> ObterTodosComercialVendasCatalogosCodigos(int codigoCatalogo)
	{
		return ObjectDataMapper.MapObjectList<ComercialVendasCatalogosCodigos>((IList)_comercialVendasCatalogosCodigosDao.ObterTodosComercialVendasCatalogosCodigos(codigoCatalogo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasCatalogosCodigos ObterComercialVendasCatalogosCodigos(int id)
	{
		return ObjectDataMapper.MapObject<ComercialVendasCatalogosCodigos>(_comercialVendasCatalogosCodigosDao.ObterComercialVendasCatalogosCodigos(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialVendasCatalogosCodigos ObterComercialVendasCatalogosCodigos(ComercialVendasCatalogosCodigos comercialVendasCatalogosCodigos)
	{
		return ObjectDataMapper.MapObject<ComercialVendasCatalogosCodigos>(_comercialVendasCatalogosCodigosDao.ObterComercialVendasCatalogosCodigos((MapTableComercialVendasCatalogosCodigos)comercialVendasCatalogosCodigos.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialVendasCatalogosCodigos(ComercialVendasCatalogosCodigos comercialVendasCatalogosCodigos)
	{
		return _comercialVendasCatalogosCodigosDao.InserirComercialVendasCatalogosCodigos((MapTableComercialVendasCatalogosCodigos)comercialVendasCatalogosCodigos.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialVendasCatalogosCodigos(ComercialVendasCatalogosCodigos comercialVendasCatalogosCodigos, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialVendasCatalogosCodigosDao.AlterarComercialVendasCatalogosCodigos((MapTableComercialVendasCatalogosCodigos)comercialVendasCatalogosCodigos.ObterDadosMapeados(), camposAlterados);
		comercialVendasCatalogosCodigos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialVendasCatalogosCodigos(int id)
	{
		return _comercialVendasCatalogosCodigosDao.ExcluirComercialVendasCatalogosCodigos(id);
	}
}
