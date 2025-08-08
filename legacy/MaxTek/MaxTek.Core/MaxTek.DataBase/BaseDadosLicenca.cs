using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MaxTek.DataBase;

public static class BaseDadosLicenca
{
	public enum ObjectType
	{
		String,
		Numeric,
		Decimal,
		Boolean,
		DateTime,
		Null
	}

	private static readonly string _dataProvider = "MySql.Data.MySqlClient";

	private static string _connectionString;

	private static string DataProvider => _dataProvider;

	private static string ConnectionString
	{
		get
		{
			_connectionString = "Server=mysql01.fernandolucio.com.br;Database=fernandolucio;Uid=fernandolucio;Pwd=MaxTek;";
			return _connectionString;
		}
	}

	private static DbProviderFactory Factory => DbProviderFactories.GetFactory(DataProvider);

	public static int Update(string sql)
	{
		return Update(sql, null);
	}

	public static int Update(string sql, IList<DbParameter> parametros)
	{
		using DbConnection dbConnection = Factory.CreateConnection();
		string connectionString = ConnectionString;
		dbConnection.ConnectionString = connectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				if (parametro != null)
				{
					dbCommand.Parameters.Add(parametro);
				}
			}
		}
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		return dbCommand.ExecuteNonQuery();
	}

	public static int Insert(string sql, bool getId, IList<DbParameter> parametros)
	{
		using DbConnection dbConnection = Factory.CreateConnection();
		string connectionString = ConnectionString;
		dbConnection.ConnectionString = connectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				dbCommand.Parameters.Add(parametro);
			}
		}
		dbConnection.Open();
		int num = -1;
		try
		{
			num = dbCommand.ExecuteNonQuery();
			if (getId)
			{
				dbCommand.CommandText = DataProvider switch
				{
					"System.Data.OleDb" => "SELECT @@IDENTITY", 
					"System.Data.SqlClient" => "SELECT SCOPE_IDENTITY()", 
					"System.Data.OracleClient" => "SELECT MySequence.NEXTVAL FROM DUAL", 
					"Pervasive.Data.SqlClient" => "SELECT @@IDENTITY", 
					_ => "SELECT @@IDENTITY", 
				};
				try
				{
					num = int.Parse(dbCommand.ExecuteScalar().ToString());
				}
				catch
				{
					num = 0;
				}
			}
		}
		catch (DbException ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder.Append("      - Key: " + datum.Key.ToString() + " - Valor: " + datum.Value.ToString() + "\n");
			}
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		return num;
	}

	public static void Insert(string sql)
	{
		Insert(sql, getId: false, null);
	}

	public static DataSet ObterDataSet(string sql)
	{
		return ObterDataSet(sql, null);
	}

	public static DataSet ObterDataSet(string sql, IList<DbParameter> parametros)
	{
		using DbConnection dbConnection = Factory.CreateConnection();
		string connectionString = ConnectionString;
		dbConnection.ConnectionString = connectionString;
		dbConnection.Open();
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandType = CommandType.Text;
		dbCommand.CommandText = sql;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				dbCommand.Parameters.Add(parametro);
			}
		}
		using DbDataAdapter dbDataAdapter = Factory.CreateDataAdapter();
		dbDataAdapter.SelectCommand = dbCommand;
		DataSet dataSet = new DataSet();
		try
		{
			dbDataAdapter.Fill(dataSet);
		}
		catch (DbException ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder.Append("      - Key: " + datum.Key.ToString() + " - Valor: " + datum.Value.ToString() + "\n");
			}
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		return dataSet;
	}

	public static DataTable ObterDataTable(string sql)
	{
		return ObterDataSet(sql).Tables[0];
	}

	public static DataTable ObterDataTable(string sql, IList<DbParameter> parametros)
	{
		return ObterDataSet(sql, parametros).Tables[0];
	}

	public static DataRow ObterDataRow(string sql)
	{
		return ObterDataRow(sql, null);
	}

	public static DataRow ObterDataRow(string sql, IList<DbParameter> parametros)
	{
		DataRow result = null;
		DataTable dataTable = ((parametros == null) ? ObterDataTable(sql) : ObterDataTable(sql, parametros));
		if (dataTable.Rows.Count > 0)
		{
			result = dataTable.Rows[0];
		}
		return result;
	}

	public static object ObterScalar(string sql)
	{
		return ObterScalar(sql, null);
	}

	public static object ObterScalar(string sql, IList<DbParameter> parametros)
	{
		using DbConnection dbConnection = Factory.CreateConnection();
		string connectionString = ConnectionString;
		dbConnection.ConnectionString = connectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				dbCommand.Parameters.Add(parametro);
			}
		}
		dbConnection.Open();
		return dbCommand.ExecuteScalar();
	}

	public static DbParameter InstanciarParametro()
	{
		return Factory.CreateParameter();
	}

	public static DbParameter ObterParametroImagem(Image imagem, string nomeParametro)
	{
		MemoryStream memoryStream = new MemoryStream();
		imagem?.Save(memoryStream, ImageFormat.Jpeg);
		DbParameter dbParameter = InstanciarParametro();
		dbParameter.ParameterName = nomeParametro;
		dbParameter.DbType = DbType.SByte;
		dbParameter.Direction = ParameterDirection.Input;
		dbParameter.Value = ((imagem != null) ? memoryStream.GetBuffer() : null);
		return dbParameter;
	}

	public static DbParameter ObterNovoParametro(string nomeParametro, object valor)
	{
		DbParameter dbParameter = InstanciarParametro();
		DbType dbType;
		if (valor != null)
		{
			switch (Type.GetTypeCode(valor.GetType()))
			{
			case TypeCode.Empty:
				throw new SystemException("Invalid data type");
			case TypeCode.Object:
				dbType = DbType.Object;
				break;
			case TypeCode.DBNull:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
				throw new SystemException("Invalid data type");
			case TypeCode.Boolean:
				dbType = DbType.Boolean;
				break;
			case TypeCode.Byte:
				dbType = DbType.Byte;
				break;
			case TypeCode.Int16:
				dbType = DbType.Int16;
				break;
			case TypeCode.Int32:
				dbType = DbType.Int32;
				break;
			case TypeCode.Int64:
				dbType = DbType.Int64;
				break;
			case TypeCode.Single:
				dbType = DbType.Single;
				break;
			case TypeCode.Double:
				dbType = DbType.Double;
				break;
			case TypeCode.Decimal:
				dbType = DbType.Decimal;
				break;
			case TypeCode.DateTime:
				dbType = DbType.DateTime;
				break;
			case TypeCode.String:
				dbType = DbType.String;
				break;
			default:
				throw new SystemException("Valor de tipo desconhecido");
			}
		}
		else
		{
			dbType = DbType.String;
		}
		dbParameter.DbType = dbType;
		dbParameter.Direction = ParameterDirection.Input;
		dbParameter.ParameterName = nomeParametro;
		dbParameter.Value = valor;
		return dbParameter;
	}

	public static string Escape(string s, bool canBeNull)
	{
		if (string.IsNullOrEmpty(s) && canBeNull)
		{
			return "NULL";
		}
		return "'" + s.Trim().Replace("'", "''") + "'";
	}

	public static string Escape(string s)
	{
		return Escape(s, canBeNull: true);
	}

	public static T ObterDbValor<T>(object valor)
	{
		object value = null;
		switch (Type.GetTypeCode(typeof(T)))
		{
		case TypeCode.Int16:
		case TypeCode.Int32:
			value = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.Decimal:
			value = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.Double:
			value = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.String:
			value = ((valor == null && Convert.IsDBNull(valor)) ? string.Empty : ((GetObjectType(valor) == ObjectType.String) ? valor : string.Empty));
			break;
		case TypeCode.DateTime:
			value = ((valor == null && Convert.IsDBNull(valor)) ? ((object)DateTime.MinValue) : ((GetObjectType(valor) == ObjectType.DateTime) ? valor : ((object)DateTime.MinValue)));
			break;
		case TypeCode.Boolean:
			value = ((valor == null && Convert.IsDBNull(valor)) ? ((object)false) : ((GetObjectType(valor) != ObjectType.Boolean) ? ((GetObjectType(valor) != ObjectType.Numeric) ? ((object)false) : ((object)(int.Parse(valor.ToString()) == 1))) : valor));
			break;
		}
		return (T)Convert.ChangeType(value, typeof(T));
	}

	public static ObjectType GetObjectType(object val)
	{
		ObjectType result = ObjectType.Null;
		if (val != null)
		{
			string text = "";
			try
			{
				text = val.GetType().ToString().Split('.')[1].ToLower(CultureInfo.InvariantCulture);
			}
			catch
			{
			}
			if (text == "boolean")
			{
				return ObjectType.Boolean;
			}
			if (text == "datetime")
			{
				return ObjectType.DateTime;
			}
			if ("+byte+sbyte+uint16+int16+uint32+int32+int64+single+double+decimal".IndexOf(text) > 0)
			{
				return ObjectType.Numeric;
			}
			result = ObjectType.String;
		}
		return result;
	}

	public static DbParameter AddSQLSmartUpdate(StringBuilder builder, string nomePropriedade, string nomeCampo, object valor, Hashtable propriedadModificada)
	{
		DbParameter result = null;
		if (propriedadModificada.ContainsKey(nomePropriedade))
		{
			result = ObterNovoParametro(nomeCampo, valor);
			if (builder.ToString().Contains("=") && propriedadModificada.Count > 1)
			{
				builder.Append(",");
			}
			builder.Append(nomeCampo + " = ?");
		}
		return result;
	}
}
