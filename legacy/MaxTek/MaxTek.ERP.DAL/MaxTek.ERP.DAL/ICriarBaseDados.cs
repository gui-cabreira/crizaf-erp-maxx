namespace MaxTek.ERP.DAL;

public interface ICriarBaseDados
{
	bool ChecarSeBaseAtualizada();

	int VersaoBaseDados();

	bool CriarBaseDadosSQL(string path);

	int NumeroUltimaVersaoBaseDados();

	bool TestarConexao();

	bool TestarConexaoMaster();
}
