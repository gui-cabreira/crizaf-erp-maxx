using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveParametrosSociedade : IParametrosSociedade
{
	private MapTableParametrosSociedade MapearClasse(DataRow row)
	{
		MapTableParametrosSociedade result = default(MapTableParametrosSociedade);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.cnpj = BaseDadosERP.ObterDbValor<string>(row["cnpj"]);
			result.razaoSocial = BaseDadosERP.ObterDbValor<string>(row["razaoSocial"]);
			result.nomeFantasia = BaseDadosERP.ObterDbValor<string>(row["nomeFantasia"]);
			result.endereco = BaseDadosERP.ObterDbValor<string>(row["endereco"]);
			result.bairro = BaseDadosERP.ObterDbValor<string>(row["bairro"]);
			result.codigoCidade = BaseDadosERP.ObterDbValor<int>(row["codigoCidade"]);
			result.codigoEstado = BaseDadosERP.ObterDbValor<int>(row["codigoEstado"]);
			result.codigoPais = BaseDadosERP.ObterDbValor<int>(row["codigoPais"]);
			result.codigoPostal = BaseDadosERP.ObterDbValor<string>(row["codigoPostal"]);
			result.telefone = BaseDadosERP.ObterDbValor<string>(row["telefone"]);
			result.inscricaoEstadual = BaseDadosERP.ObterDbValor<string>(row["inscricaoEstadual"]);
			result.email = BaseDadosERP.ObterDbValor<string>(row["email"]);
			result.site = BaseDadosERP.ObterDbValor<string>(row["site"]);
			result.logo = BaseDadosERP.ObterDbValor<Image>(row["logo"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_cnpj as cnpj, ");
		stringBuilder.Append("nm_razao_social as razaoSocial, ");
		stringBuilder.Append("nm_fantasia as nomeFantasia, ");
		stringBuilder.Append("nm_endereco as endereco, ");
		stringBuilder.Append("nm_bairro as bairro, ");
		stringBuilder.Append("id_cidade as codigoCidade, ");
		stringBuilder.Append("id_estado as codigoEstado, ");
		stringBuilder.Append("id_pais as codigoPais, ");
		stringBuilder.Append("cd_postal as codigoPostal, ");
		stringBuilder.Append("nm_telefone as telefone, ");
		stringBuilder.Append("cd_inscricao_estadua as inscricaoEstadual, ");
		stringBuilder.Append("nm_email as email, ");
		stringBuilder.Append("nm_site as site, ");
		stringBuilder.Append("im_logo as logo");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "ERP.ParametrosSociedade ");
		return stringBuilder.ToString();
	}

	public IList<MapTableParametrosSociedade> ObterTodosParametrosSociedade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableParametrosSociedade> list = new List<MapTableParametrosSociedade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableParametrosSociedade ObterParametrosSociedade(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableParametrosSociedade ObterParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", ParametrosSociedade.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "ERP.ParametrosSociedade (");
		stringBuilder.Append("cd_cnpj, ");
		stringBuilder.Append("nm_razao_social, ");
		stringBuilder.Append("nm_fantasia, ");
		stringBuilder.Append("nm_endereco, ");
		stringBuilder.Append("nm_bairro, ");
		stringBuilder.Append("id_cidade, ");
		stringBuilder.Append("id_estado, ");
		stringBuilder.Append("id_pais, ");
		stringBuilder.Append("cd_postal, ");
		stringBuilder.Append("nm_telefone, ");
		stringBuilder.Append("cd_inscricao_estadua, ");
		stringBuilder.Append("nm_email, ");
		stringBuilder.Append("nm_site, ");
		stringBuilder.Append("im_logo) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cnpj", ParametrosSociedade.cnpj));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_razao_social", ParametrosSociedade.razaoSocial));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_fantasia", ParametrosSociedade.nomeFantasia));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_endereco", ParametrosSociedade.endereco));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_bairro", ParametrosSociedade.bairro));
		list.Add(BaseDadosERP.ObterNovoParametro("id_cidade", ParametrosSociedade.codigoCidade));
		list.Add(BaseDadosERP.ObterNovoParametro("id_estado", ParametrosSociedade.codigoEstado));
		list.Add(BaseDadosERP.ObterNovoParametro("id_pais", ParametrosSociedade.codigoPais));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_postal", ParametrosSociedade.codigoPostal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_telefone", ParametrosSociedade.telefone));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_inscricao_estadua", ParametrosSociedade.inscricaoEstadual));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_email", ParametrosSociedade.email));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_site", ParametrosSociedade.site));
		list.Add(BaseDadosERP.ObterNovoParametro("im_logo", ParametrosSociedade.logo));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "ERP.ParametrosSociedade Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cnpj", "cd_cnpj", ParametrosSociedade.cnpj, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RazaoSocial", "nm_razao_social", ParametrosSociedade.razaoSocial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeFantasia", "nm_fantasia", ParametrosSociedade.nomeFantasia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Endereco", "nm_endereco", ParametrosSociedade.endereco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Bairro", "nm_bairro", ParametrosSociedade.bairro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCidade", "id_cidade", ParametrosSociedade.codigoCidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEstado", "id_estado", ParametrosSociedade.codigoEstado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPais", "id_pais", ParametrosSociedade.codigoPais, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPostal", "cd_postal", ParametrosSociedade.codigoPostal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Telefone", "nm_telefone", ParametrosSociedade.telefone, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "InscricaoEstadual", "cd_inscricao_estadua", ParametrosSociedade.inscricaoEstadual, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", ParametrosSociedade.email, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Site", "nm_site", ParametrosSociedade.site, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Logo", "im_logo", ParametrosSociedade.logo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", ParametrosSociedade.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirParametrosSociedade(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "ERP.ParametrosSociedade ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
