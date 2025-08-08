using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloSistema
{
	private static ICampos _CamposDao = AcessoDados.CamposDAO;

	private static IClasse _ClasseDao = AcessoDados.ClasseDAO;

	private static ITabelas _TabelasDao = AcessoDados.TabelasDAO;

	private static ISistemaUsuarios _sistemaUsuariosDao = AcessoDados.SistemaUsuariosDAO;

	private static IIndices _indicesDao = AcessoDados.IndicesDAO;

	private static ICriarBaseDados _criarBaseDados = AcessoDados.SqlCriarBaseDadadosDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<Tabelas> ObterTabelas(string nomeServidor, string nomeBaseDados)
	{
		return ObjectDataMapper.MapObjectList<Tabelas>((IList)_TabelasDao.ObterTabelas(nomeServidor, nomeBaseDados));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<Campos> ObterCampos(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela)
	{
		return ObjectDataMapper.MapObjectList<Campos>((IList)_CamposDao.ObterCampos(nomeServidor, nomeBaseDados, nomeEsquema, nomeTabela));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<Classe> ObterClasse(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela)
	{
		return ObjectDataMapper.MapObjectList<Classe>((IList)_ClasseDao.ObterClasse(nomeServidor, nomeBaseDados, nomeEsquema, nomeTabela));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int IncluirClasse(Classe Classe)
	{
		return _ClasseDao.Inserir((MapTableClasse)Classe.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarClasse(Classe Classe, Hashtable camposAlterados)
	{
		int num = 0;
		num = _ClasseDao.Alterar((MapTableClasse)Classe.ObterDadosMapeados(), camposAlterados);
		Classe.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<SistemaUsuarios> ObterTodosSistemaUsuarios()
	{
		return ObjectDataMapper.MapObjectList<SistemaUsuarios>((IList)_sistemaUsuariosDao.ObterTodosSistemaUsuarios());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static SistemaUsuarios ObterSistemaUsuarios(string nomeLogon)
	{
		return ObjectDataMapper.MapObject<SistemaUsuarios>(_sistemaUsuariosDao.ObterSistemaUsuarios(nomeLogon));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static SistemaUsuarios ObterSistemaUsuarios(SistemaUsuarios sistemaUsuarios)
	{
		return ObjectDataMapper.MapObject<SistemaUsuarios>(_sistemaUsuariosDao.ObterSistemaUsuarios((MapTableSistemaUsuarios)sistemaUsuarios.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirSistemaUsuarios(SistemaUsuarios sistemaUsuarios)
	{
		return _sistemaUsuariosDao.InserirSistemaUsuarios((MapTableSistemaUsuarios)sistemaUsuarios.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarSistemaUsuarios(SistemaUsuarios sistemaUsuarios, Hashtable camposAlterados)
	{
		int num = 0;
		num = _sistemaUsuariosDao.AlterarSistemaUsuarios((MapTableSistemaUsuarios)sistemaUsuarios.ObterDadosMapeados(), camposAlterados);
		sistemaUsuarios.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirSistemaUsuarios(string nomeLogon)
	{
		return _sistemaUsuariosDao.ExcluirSistemaUsuarios(nomeLogon);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirSistemaUsuarios(int id)
	{
		return _sistemaUsuariosDao.ExcluirSistemaUsuarios(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ListaIndices> ObterListaIndices(string schema, string tabela)
	{
		return ObjectDataMapper.MapObjectList<ListaIndices>((IList)_indicesDao.ObterListaIndices(schema, tabela));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<Indices> ObterIndices(int objectId, int indexId)
	{
		return ObjectDataMapper.MapObjectList<Indices>((IList)_indicesDao.ObterIndices(objectId, indexId));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static bool ChecarSeBaseERPEstaAtualizada()
	{
		return _criarBaseDados.ChecarSeBaseAtualizada();
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static int VersaoBaseDadosERP()
	{
		return _criarBaseDados.VersaoBaseDados();
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static bool CriarBaseDadosSQL(string path)
	{
		return _criarBaseDados.CriarBaseDadosSQL(path);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static int NumeroUltimaVersaoBaseDados()
	{
		return _criarBaseDados.NumeroUltimaVersaoBaseDados();
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static bool TestarConexao()
	{
		return _criarBaseDados.TestarConexao();
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static bool TestarConexaoMaster()
	{
		return _criarBaseDados.TestarConexaoMaster();
	}
}
