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

public static class BaseDadosHD
{
	public enum ObjectType
	{
		String,
		Numeric,
		Decimal,
		Boolean,
		DateTime,
		Null,
		Image
	}

	public static readonly bool _IsLogar = ConfigurationManager.AppSettings.Get("GerarLog").ToUpper() == "TRUE";

	private static string _dataProvider;

	private static string _connectionString;

	private static string _nomeBaseDados;

	private static string _nomeServidor;

	private static string _nomeUsuario;

	private static string _nomeComputador;

	private static bool _testeConexao;

	private static string _nomeServidorHd;

	private static string _nomeBasedadosHd;

	public static string DataProvider
	{
		get
		{
			return _dataProvider;
		}
		set
		{
			if (_dataProvider != value)
			{
				_dataProvider = value;
			}
		}
	}

	private static string ConnectionString
	{
		get
		{
			switch (DataProvider)
			{
			case "System.Data.SqlClient":
				_connectionString = "Data Source=" + NomeServidor + ";";
				_connectionString = _connectionString + "Initial Catalog=" + NomeBaseDados + ";";
				_connectionString += "User Id=MaxDev;";
				_connectionString += "Password=MaxTek2011;";
				break;
			case "Pervasive.Data.SqlClient":
				_connectionString = "ServerDSN=" + NomeBaseDados + "ERP;";
				_connectionString += "UID=Developer;PWD=maxdev;";
				_connectionString = _connectionString + "Server=" + NomeServidor + ";";
				break;
			}
			return _connectionString;
		}
	}

	public static string NomeBaseDados
	{
		get
		{
			return _nomeBaseDados;
		}
		set
		{
			if (_nomeBaseDados != value)
			{
				_nomeBaseDados = value;
			}
		}
	}

	public static string NomeServidor
	{
		get
		{
			return _nomeServidor;
		}
		set
		{
			if (_nomeServidor != value)
			{
				_nomeServidor = value;
			}
		}
	}

	public static string NomeUsuario
	{
		get
		{
			return _nomeUsuario;
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
			return _nomeComputador;
		}
		set
		{
			if (_nomeComputador != value)
			{
				_nomeComputador = value;
			}
		}
	}

	private static DbProviderFactory Factory => DbProviderFactories.GetFactory(DataProvider);

	public static string NomeBaseDadosHD
	{
		get
		{
			return _nomeBasedadosHd;
		}
		set
		{
			if (_nomeBasedadosHd != value)
			{
				_nomeBasedadosHd = value;
			}
		}
	}

	public static string NomeServidorHd
	{
		get
		{
			return _nomeServidorHd;
		}
		set
		{
			if (_nomeServidorHd != value)
			{
				_nomeServidorHd = value;
			}
		}
	}

	public static int Update(string sql)
	{
		return Update(sql, null);
	}

	public static int Update(string sql, IList<DbParameter> parametros)
	{
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
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
					stringBuilder.Append(parametro.ParameterName + " = " + parametro.Value.ToString() + "; ");
				}
			}
		}
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		GravarLog(sql, stringBuilder.ToString());
		try
		{
			return dbCommand.ExecuteNonQuery();
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
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder2.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
	}

	public static int Insert(string sql, bool getId, IList<DbParameter> parametros)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		if (parametros != null)
		{
			foreach (DbParameter parametro in parametros)
			{
				dbCommand.Parameters.Add(parametro);
				stringBuilder.Append($"{parametro.ParameterName} = {parametro.Value}; ");
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
					"System.Data.SqlClient" => "SELECT @@IDENTITY", 
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
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetTyp{0}e: <br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder3, dbCommand.CommandText, stringBuilder, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema");
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

	public static int AtualizarBD(IList<string> sql)
	{
		int result = 0;
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		DbTransaction dbTransaction = (dbCommand.Transaction = dbConnection.BeginTransaction());
		try
		{
			foreach (string item in sql)
			{
				dbCommand.CommandText = item;
				result = dbCommand.ExecuteNonQuery();
			}
			dbTransaction.Commit();
		}
		catch (DbException ex)
		{
			dbTransaction.Rollback();
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder.Append($"      - Key: {datum.Key} - Valor: {datum.Value}\n");
				stringBuilder2.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder2, dbCommand.CommandText, null, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		dbConnection.Close();
		return result;
	}

	public static int AtualizarBD(string sql)
	{
		int num = 0;
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = sql;
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		DbTransaction dbTransaction = (dbCommand.Transaction = dbConnection.BeginTransaction());
		try
		{
			num = dbCommand.ExecuteNonQuery();
			dbTransaction.Commit();
		}
		catch (DbException ex)
		{
			dbTransaction.Rollback();
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (DictionaryEntry datum in ex.Data)
			{
				stringBuilder.Append($"      - Key: {datum.Key} - Valor: {datum.Value}\n");
				stringBuilder2.Append($"- Key: {datum.Key} - Valor: {datum.Value}</br>");
			}
			string texto = string.Format("<p>Usuário: {7}<br>Estação: {8}<br><hr></p><p>DbException.GetType: {0}<br>DbException.Source: {1}<br>DbException.ErrorCode: {2}<br>DbException.Message: {3}<br><HR>DbException.Data: {4}<br>SQL : {5}<br>Parametros: {6}</p>", ex.GetType(), ex.Source, ex.ErrorCode, ex.Message, stringBuilder2, dbCommand.CommandText, null, _nomeUsuario, _nomeComputador);
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema");
			enviaEmail.EnviarThread();
			MessageBox.Show("DbException.GetType: " + ex.GetType().ToString() + "\nDbException.Source: " + ex.Source.ToString() + "\nDbException.ErrorCode: " + ex.ErrorCode + "\nDbException.Message: " + ex.Message + "\nDbException.Data: \n" + stringBuilder.ToString() + "SQL = " + dbCommand.CommandText);
			throw ex;
		}
		dbConnection.Close();
		return num;
	}

	public static bool TestarConexao()
	{
		bool result = false;
		using (DbConnection dbConnection = Factory.CreateConnection())
		{
			dbConnection.ConnectionString = ConnectionString;
			try
			{
				dbConnection.Open();
			}
			catch (Exception ex)
			{
				string message = ex.Message;
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
		dbConnection.ConnectionString = ConnectionString;
		dbConnection.Open();
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandType = CommandType.Text;
		dbCommand.CommandText = sql;
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
			EnviaEmail enviaEmail = new EnviaEmail(texto, "Erros Sistema - Select");
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
		dbConnection.ConnectionString = ConnectionString;
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
		dbParameter.DbType = DbType.Binary;
		dbParameter.Direction = ParameterDirection.Input;
		dbParameter.Value = ((imagem != null) ? memoryStream.GetBuffer() : null);
		return dbParameter;
	}

	public static DbParameter ObterNovoParametro(string nomeParametro, object valor)
	{
		DbParameter dbParameter = InstanciarParametro();
		DbType dbType = DbType.String;
		if (valor != null)
		{
			switch (Type.GetTypeCode(valor.GetType()))
			{
			case TypeCode.Empty:
				throw new SystemException("Invalid data type");
			case TypeCode.Object:
				if (valor.GetType().ToString() == "System.Drawing.Bitmap")
				{
					dbType = DbType.Binary;
					MemoryStream memoryStream = new MemoryStream();
					Image image = (Image)valor;
					image?.Save(memoryStream, ImageFormat.Jpeg);
					valor = ((image != null) ? memoryStream.GetBuffer() : null);
				}
				else
				{
					dbType = DbType.Object;
				}
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
				if ((DateTime)valor == DateTime.MinValue)
				{
					valor = DateTime.MinValue.AddYears(1899);
				}
				break;
			case TypeCode.String:
				dbType = DbType.String;
				break;
			default:
				throw new SystemException("Valor de tipo desconhecido");
			}
		}
		else if (nomeParametro.Substring(0, 3) == "@im")
		{
			byte[] array = new byte[0];
			dbType = DbType.Binary;
			MemoryStream memoryStream2 = new MemoryStream();
			Image image2 = (Image)valor;
			image2?.Save(memoryStream2, ImageFormat.Jpeg);
			valor = ((image2 != null) ? memoryStream2.GetBuffer() : array);
		}
		else
		{
			valor = string.Empty;
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
		switch (Type.GetTypeCode(typeof(T)))
		{
		case TypeCode.Int16:
		case TypeCode.Int32:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.Decimal:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.Double:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)0) : ((GetObjectType(valor) == ObjectType.Numeric) ? valor : ((object)0)));
			break;
		case TypeCode.String:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? string.Empty : ((GetObjectType(valor) == ObjectType.String) ? valor : string.Empty));
			break;
		case TypeCode.DateTime:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)DateTime.MinValue) : ((GetObjectType(valor) == ObjectType.DateTime) ? valor : ((object)DateTime.MinValue)));
			break;
		case TypeCode.Boolean:
			obj = ((valor == null && Convert.IsDBNull(valor)) ? ((object)false) : ((GetObjectType(valor) != ObjectType.Boolean) ? ((GetObjectType(valor) != ObjectType.Numeric) ? ((object)false) : ((object)(int.Parse(valor.ToString()) == 1))) : valor));
			break;
		case TypeCode.Object:
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
			}
			return (T)obj;
		}
		}
		return (T)Convert.ChangeType(obj, typeof(T));
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
			if (text == "byte[]")
			{
				return ObjectType.Image;
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
			switch (DataProvider)
			{
			case "Pervasive.Data.SqlClient":
				result = ObterNovoParametro(nomeCampo, valor);
				if (builder.ToString().Contains("=") && propriedadModificada.Count > 1)
				{
					builder.Append(",");
				}
				builder.Append(nomeCampo + " = ?");
				break;
			default:
				result = ObterNovoParametro("@" + nomeCampo, valor);
				if (builder.ToString().Contains("=") && propriedadModificada.Count > 1)
				{
					builder.Append(",");
				}
				builder.Append(nomeCampo + " = @" + nomeCampo);
				break;
			}
		}
		return result;
	}

	private static void GravarLog(string sql, string textoParamentros)
	{
		if (!_IsLogar)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		IList<DbParameter> list = new List<DbParameter>();
		stringBuilder.AppendFormat("Insert into [{0}].[{1}].[Sistema].[LogSistema] (", NomeServidor, NomeBaseDados);
		stringBuilder.Append("[dt_log], ");
		stringBuilder.Append("[nm_usuario], ");
		stringBuilder.Append("[nm_computador], ");
		stringBuilder.Append("[ds_log], ");
		stringBuilder.Append("[ds_parametros]) Values (@dt_log,@nm_usuario,@nm_computador,@ds_log,@ds_parametros) ");
		list.Add(ObterNovoParametro("@dt_log", DateTime.Now));
		list.Add(ObterNovoParametro("@nm_usuario", NomeUsuario));
		list.Add(ObterNovoParametro("@nm_computador", NomeComputador));
		list.Add(ObterNovoParametro("@ds_log", sql));
		list.Add(ObterNovoParametro("@ds_parametros", textoParamentros));
		using DbConnection dbConnection = Factory.CreateConnection();
		dbConnection.ConnectionString = ConnectionString;
		using DbCommand dbCommand = Factory.CreateCommand();
		dbCommand.Connection = dbConnection;
		dbCommand.CommandText = stringBuilder.ToString();
		if (list != null)
		{
			foreach (DbParameter item in list)
			{
				if (item != null)
				{
					dbCommand.Parameters.Add(item);
				}
			}
		}
		if (dbConnection.State != ConnectionState.Open)
		{
			dbConnection.Open();
		}
		dbCommand.ExecuteNonQuery();
	}
}
