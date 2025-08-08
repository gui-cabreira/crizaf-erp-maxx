using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MaxTek.Utils;

namespace MaxTek.DataBase;

public static class BaseDadosGPS
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

	private static readonly string _dataProvider = "Pervasive.Data.SqlClient";

	private static string _connectionString;

	private static string _nomeBaseDadosGPS = ((ConfigurationManager.AppSettings.Get("NomeDataBase") != null) ? ConfigurationManager.AppSettings.Get("NomeDataBase") : string.Empty);

	private static string _nomeServidorGPS = ((ConfigurationManager.AppSettings.Get("NomeServidor") != null) ? ConfigurationManager.AppSettings.Get("NomeServidor") : string.Empty);

	private static bool _logar = ConfigurationManager.AppSettings.Get("GerarLog") != null && bool.Parse(ConfigurationManager.AppSettings.Get("GerarLog"));

	private static string _nomeUsuario;

	private static string _nomeComputador;

	private static string DataProvider => _dataProvider;

	private static string ConnectionString
	{
		get
		{
			_connectionString = $"ServerDSN={NomeBaseDados}GPS;UID=Developer;PWD=maxdev;Server={NomeServidorGPS};Connection Retry Count=5;";
			return _connectionString;
		}
	}

	private static string ConnectionStringTeste
	{
		get
		{
			_connectionString = $"ServerDSN={NomeBaseDados}GPS;UID=Developer;PWD=maxdev;Server={NomeServidorGPS};";
			return _connectionString;
		}
	}

	public static string NomeBaseDados
	{
		get
		{
			return _nomeBaseDadosGPS;
		}
		set
		{
			if (_nomeBaseDadosGPS != value)
			{
				_nomeBaseDadosGPS = value;
			}
		}
	}

	public static string NomeServidorGPS
	{
		get
		{
			return _nomeServidorGPS;
		}
		set
		{
			if (_nomeServidorGPS != value)
			{
				_nomeServidorGPS = value;
			}
		}
	}

	public static string NomeUsuario
	{
		get
		{
			return _nomeUsuario ?? Environment.UserName;
		}
		set
		{
			if (_nomeUsuario != value)
			{
				_nomeUsuario = value;
			}
		}
	}

	public static string NomeComputador
	{
		get
		{
			return _nomeComputador ?? Environment.MachineName;
		}
		set
		{
			if (_nomeComputador != value)
			{
				_nomeComputador = value;
			}
		}
	}

	private static DbProviderFactory Factory => DbProviderFactories.GetFactory("Pervasive.Data.SqlClient");

	public static int Update(string sql)
	{
		return Update(sql, null);
	}

	public static int Update(string sql, IList<DbParameter> parametros)
	{
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		using DbConnection dbConnection = Factory.CreateConnection();
		string connectionString = ConnectionString;
		dbConnection.ConnectionString = connectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		dbCommand.CommandTimeout = 500;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				if (parametro != null)
				{
					dbCommand.Parameters.Add(parametro);
					if (parametro.Value != null)
					{
						stringBuilder.Append($"{parametro.ParameterName} = {parametro.Value}; ");
					}
					else
					{
						stringBuilder.Append($"{parametro.ParameterName} = null; ");
					}
				}
			}
		}
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		try
		{
			num = dbCommand.ExecuteNonQuery();
			try
			{
				GravarLog(sql, stringBuilder.ToString());
			}
			catch
			{
			}
		}
		catch (DbException ex)
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder2.Append($"      - Key: {datum.Key} - Valor: {datum.Value}\n");
				stringBuilder3.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder3, dbCommand.CommandText, stringBuilder, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, $"{NomeBaseDados} - Erros Sistema Update");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder2.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		return num;
	}

	public static int Insert(string sql, bool getId, IList<DbParameter> parametros)
	{
		using DbConnection dbConnection = Factory.CreateConnection();
		StringBuilder stringBuilder = new StringBuilder();
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
				stringBuilder.AppendFormat("{0} = {1}; ", parametro.ParameterName, (parametro.Value == null) ? "" : parametro.Value.ToString());
			}
		}
		dbConnection.Open();
		int num = -1;
		try
		{
			GravarLog(sql, stringBuilder.ToString());
		}
		catch
		{
		}
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
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder2.Append($"      - Key: {datum.Key} - Valor: {datum.Value}\n");
				stringBuilder3.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder3, dbCommand.CommandText, stringBuilder, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, $"{NomeBaseDados} - Erros Sistema Insert");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder2.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		return num;
	}

	public static void Insert(string sql)
	{
		Insert(sql, getId: false, null);
	}

	public static bool TestaParametrosUpdade(IList<DbParameter> lista)
	{
		bool result = false;
		foreach (DbParameter listum in lista)
		{
			if (listum != null)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static bool TestarConexao()
	{
		bool result = false;
		using (DbConnection dbConnection = Factory.CreateConnection())
		{
			dbConnection.ConnectionString = ConnectionStringTeste;
			int connectionTimeout = dbConnection.ConnectionTimeout;
			try
			{
				dbConnection.Open();
			}
			catch
			{
			}
			if (dbConnection.State == ConnectionState.Open)
			{
				result = true;
			}
			dbConnection.Close();
		}
		return result;
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
		dbCommand.CommandTimeout = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				dbCommand.Parameters.Add(parametro);
				if (parametro.Value != null)
				{
					stringBuilder.Append($"{parametro.ParameterName} = {parametro.Value}; ");
				}
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
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder2.Append($"      - Key: {datum.Key} - Valor: {datum.Value}\n");
				stringBuilder3.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder3, dbCommand.CommandText, stringBuilder, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, $"{NomeBaseDados} Erros Sistema - Select");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder2.ToString() + "SQL = " + dbCommand.CommandText);
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
		dbCommand.CommandTimeout = 0;
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
		if (dbType == DbType.Object && valor.GetType().BaseType.Name == "Image")
		{
			dbParameter = ObterParametroImagem((Image)valor, nomeParametro);
		}
		else
		{
			dbParameter.DbType = dbType;
			dbParameter.Direction = ParameterDirection.Input;
			dbParameter.ParameterName = nomeParametro;
			dbParameter.Value = valor;
		}
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

	public static string FormataDataNula(DateTime? data, string formato)
	{
		if (data.HasValue && data > DateTime.MinValue)
		{
			return data.Value.ToString(formato);
		}
		return string.Empty;
	}

	public static T ObterDbValor<T>(object valor)
	{
		object obj = null;
		TypeCode typeCode = Type.GetTypeCode(typeof(T));
		switch (typeCode)
		{
		case TypeCode.Int16:
		case TypeCode.Int32:
		case TypeCode.Int64:
			if (valor != null || !Convert.IsDBNull(valor))
			{
				obj = ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0));
				if (typeCode == TypeCode.Int32)
				{
					long num = Convert.ToInt64(obj);
					if (num > int.MaxValue)
					{
						obj = 0;
					}
				}
				if (obj.ToString() == "0" && GetObjectType(valor) == ObjectType.String && !string.IsNullOrWhiteSpace(valor.ToString()))
				{
					try
					{
						obj = Convert.ToInt32(valor.ToString());
					}
					catch
					{
					}
				}
			}
			else
			{
				obj = 0;
			}
			break;
		case TypeCode.Decimal:
			if (valor != null || !Convert.IsDBNull(valor))
			{
				if (GetObjectType(valor) == ObjectType.String)
				{
					obj = 0;
					if (decimal.TryParse(valor.ToString(), out var result))
					{
						obj = result;
					}
				}
				else
				{
					obj = ((!(valor.GetType() == typeof(double)) || (!((double)valor < -7.922816251426434E+28) && !((double)valor > 7.922816251426434E+28))) ? ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)) : ((object)0));
				}
			}
			else
			{
				obj = 0;
			}
			break;
		case TypeCode.Double:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.String:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? string.Empty : ((GetObjectType(valor) == ObjectType.String) ? valor : string.Empty));
			break;
		case TypeCode.DateTime:
			if (valor != null || !Convert.IsDBNull(valor))
			{
				try
				{
					obj = ((GetObjectType(valor) == ObjectType.DateTime) ? valor : ((object)DateTime.MinValue));
				}
				catch
				{
					obj = DateTime.MinValue;
				}
			}
			else
			{
				obj = DateTime.MinValue;
			}
			break;
		case TypeCode.Boolean:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)false) : ((GetObjectType(valor) != ObjectType.Boolean) ? ((GetObjectType(valor) != ObjectType.Numeric) ? ((object)false) : ((object)(int.Parse(valor.ToString()) == 1))) : valor));
			break;
		case TypeCode.Object:
			if (typeof(T).FullName == "System.Guid")
			{
				obj = (string.IsNullOrWhiteSpace(valor.ToString()) ? ((object)default(Guid)) : valor);
			}
			else if (typeof(T).FullName == "System.Byte[]")
			{
				obj = valor;
			}
			else
			{
				if (valor == DBNull.Value || !(typeof(T).ToString() == "System.Drawing.Image"))
				{
					break;
				}
				byte[] array = (byte[])valor;
				if (array.Length != 0)
				{
					MemoryStream stream = new MemoryStream(array);
					try
					{
						obj = Image.FromStream(stream);
					}
					catch
					{
					}
					return (T)obj;
				}
			}
			break;
		}
		try
		{
			return (T)Convert.ChangeType(obj, typeof(T));
		}
		catch
		{
			return (T)Convert.ChangeType(0, typeof(T));
		}
	}

	public static ObjectType GetObjectType(object val)
	{
		ObjectType result = ObjectType.Null;
		if (val != null)
		{
			string text = "";
			try
			{
				if (val.GetType().ToString().Contains("."))
				{
					text = val.GetType().ToString().Split('.')[1].ToLower(CultureInfo.InvariantCulture);
				}
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
			if ("+byte+sbyte+uint16+int16+uint32+int32+uint64+int64+single+double+decimal".IndexOf(text) > 0)
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
			if (builder.ToString().Contains("=") && propriedadModificada.Count >= 1)
			{
				builder.Append(",");
			}
			builder.Append(nomeCampo + " = ?");
		}
		return result;
	}

	private static void GravarLog(string sql, string textoParamentros)
	{
		if (!_logar)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		IList<DbParameter> list = new List<DbParameter>();
		stringBuilder2.Append($"Insert into {NomeBaseDados}AUX.LogSistema (");
		stringBuilder2.Append("dt_log, ");
		stringBuilder2.Append("nm_usuario, ");
		stringBuilder2.Append("nm_computador, ");
		stringBuilder2.Append("ds_log, ");
		stringBuilder2.Append("ds_parametros) Values (NOW(),?,?,?,?) ");
		list.Add(ObterNovoParametro("nm_usuario", NomeUsuario));
		list.Add(ObterNovoParametro("nm_computador", NomeComputador));
		list.Add(ObterNovoParametro("ds_log", sql));
		list.Add(ObterNovoParametro("ds_parametros", textoParamentros));
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = stringBuilder2.ToString();
		if (list != null)
		{
			foreach (DbParameter item in list)
			{
				if (item != null)
				{
					dbCommand.Parameters.Add(item);
					if (item.Value != null)
					{
						stringBuilder.Append($"{item.ParameterName} = {item.Value}; ");
					}
					else
					{
						stringBuilder.Append($"{item.ParameterName} = null; ");
					}
				}
			}
		}
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		try
		{
			dbCommand.ExecuteNonQuery();
		}
		catch (DbException ex)
		{
			StringBuilder stringBuilder3 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder3.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder3, dbCommand.CommandText, stringBuilder, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema");
			enviaEmail.EnviarThread();
		}
	}
}
