using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IQualidadeCertificacao
{
	IList<MapTableQualidadeCertificacao> ObterTodosQualidadeCertificacao();

	MapTableQualidadeCertificacao ObterQualidadeCertificacao(int codigo);

	MapTableQualidadeCertificacao ObterQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao);

	int InserirQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao);

	int AlterarQualidadeCertificacao(MapTableQualidadeCertificacao QualidadeCertificacao, Hashtable camposAlterados);

	int ExcluirQualidadeCertificacao(int codigo);
}
