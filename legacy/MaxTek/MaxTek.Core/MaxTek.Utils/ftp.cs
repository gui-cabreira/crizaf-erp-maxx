using System;
using System.IO;
using System.Net;
using System.Text;

namespace MaxTek.Utils;

public sealed class ftp : IDisposable
{
	private string host = null;

	private string user = null;

	private string pass = null;

	private FtpWebRequest ftpRequest = null;

	private FtpWebResponse ftpResponse = null;

	private Stream ftpStream = null;

	private const int bufferSize = 2048;

	public void Dispose()
	{
		if (ftpStream != null)
		{
			ftpStream.Dispose();
			ftpStream = null;
		}
	}

	public ftp(string hostIP, string userName, string password)
	{
		host = hostIP;
		user = userName;
		pass = password;
	}

	public void download(string remoteFile, string localFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{remoteFile}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "RETR";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Create);
			byte[] buffer = new byte[2048];
			int num = ftpStream.Read(buffer, 0, 2048);
			try
			{
				while (num > 0)
				{
					fileStream.Write(buffer, 0, num);
					num = ftpStream.Read(buffer, 0, 2048);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			fileStream.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
	}

	public void upload(string remoteFile, string localFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{remoteFile}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "STOR";
			ftpStream = ftpRequest.GetRequestStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Create);
			byte[] buffer = new byte[2048];
			int num = fileStream.Read(buffer, 0, 2048);
			try
			{
				while (num != 0)
				{
					ftpStream.Write(buffer, 0, num);
					num = fileStream.Read(buffer, 0, 2048);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			fileStream.Close();
			ftpStream.Close();
			ftpRequest = null;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
	}

	public string upload2()
	{
		ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://fibra.maxtek.com.br/nf3.pdf");
		ftpRequest.Method = "STOR";
		ftpRequest.Credentials = new NetworkCredential(user, pass);
		StreamReader streamReader = new StreamReader("C:\\Dados\\nf.pdf");
		byte[] bytes = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
		streamReader.Close();
		ftpRequest.ContentLength = bytes.Length;
		Stream requestStream = ftpRequest.GetRequestStream();
		requestStream.Write(bytes, 0, bytes.Length);
		requestStream.Close();
		FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpRequest.GetResponse();
		string result = $"Upload File Complete, status {ftpWebResponse.StatusDescription}";
		ftpWebResponse.Close();
		return result;
	}

	public void delete(string deleteFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{deleteFile}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "DELE";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public void rename(string currentFileNameAndPath, string newFileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{currentFileNameAndPath}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "RENAME";
			ftpRequest.RenameTo = newFileName;
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public void createDirectory(string newDirectory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{newDirectory}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "MKD";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public string getFileCreatedDateTime(string fileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{fileName}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "MDTM";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string result = null;
			try
			{
				result = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			return result;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
		return "";
	}

	public string getFileSize(string fileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{fileName}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "SIZE";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string result = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					result = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			return result;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
		return "";
	}

	public string[] directoryListSimple(string directory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{directory}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "NLST";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					text = text + streamReader.ReadLine() + "|";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			try
			{
				return text.Split("|".ToCharArray());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.ToString());
		}
		return new string[1] { "" };
	}

	public string[] directoryListDetailed(string directory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create($"{host}/{directory}");
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "LIST";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					text = text + streamReader.ReadLine() + "|";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			try
			{
				return text.Split("|".ToCharArray());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.ToString());
		}
		return new string[1] { "" };
	}
}
