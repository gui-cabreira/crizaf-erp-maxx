namespace MaxTek.ERP.BLL.Sefaz;

public static class SefazUrl
{
	public static string url(EnumServicosSefaz tipoServico, Estado UF, TipoAmbiente tipoAmbiente)
	{
		string result = string.Empty;
		switch (tipoAmbiente)
		{
		case TipoAmbiente.Homologacao:
			switch (UF)
			{
			case Estado.AM:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/NfeConsulta4";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/NfeRetAutorizacao4";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/NfeStatusServico4";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://homnfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4";
					break;
				}
				break;
			case Estado.MG:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4";
					break;
				}
				break;
			case Estado.SP:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferetautorizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx";
					break;
				}
				break;
			}
			break;
		case TipoAmbiente.Producao:
			switch (UF)
			{
			case Estado.AM:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://nfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://nfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://nfe.sefaz.am.gov.br/services2/services/NfeRetAutorizacao4";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://nfe.sefaz.am.gov.br/services2/services/NfeStatusServico4";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://nfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4";
					break;
				}
				break;
			case Estado.MG:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4";
					break;
				}
				break;
			case Estado.SP:
				switch (tipoServico)
				{
				case EnumServicosSefaz.NFeAutorizacao:
					result = "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeConsultaCadastro:
					result = "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx";
					break;
				case EnumServicosSefaz.NFeConsultaProtocolo:
					result = "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx";
					break;
				case EnumServicosSefaz.NFeInutilizacao:
					result = "https://nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeRetornoAutorizacao:
					result = "https://nfe.fazenda.sp.gov.br/ws/nferetautorizacao4.asmx";
					break;
				case EnumServicosSefaz.NFeStatusServico:
					result = "https://nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx";
					break;
				case EnumServicosSefaz.NFeRecepcaoEvento:
					result = "https://nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx";
					break;
				}
				break;
			}
			break;
		}
		return result;
	}
}
