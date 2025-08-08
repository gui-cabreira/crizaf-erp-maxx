using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaxTek.ERP.BLL.NotaFiscal;

public class CertificadoDigital
{
	public X509Certificate2 oCertificado { get; private set; }

	public bool lLocalizouCertificado { get; private set; }

	public DateTime dValidadeInicial { get; private set; }

	public DateTime dValidadeFinal { get; private set; }

	public string sSubject { get; private set; }

	public bool SelecionarCertificado(string chaveCertificado, out string novoCertificado)
	{
		novoCertificado = string.Empty;
		X509Store x509Store = new X509Store("MY", StoreLocation.CurrentUser);
		x509Store.Open(OpenFlags.OpenExistingOnly);
		X509Certificate2Collection certificates = x509Store.Certificates;
		Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		if (!string.IsNullOrEmpty(chaveCertificado))
		{
			X509Certificate2Enumerator enumerator = certificates.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current = enumerator.Current;
				if (chaveCertificado.ToLower() == current.SerialNumber.ToLower())
				{
					if (current.NotAfter > DateTime.Now)
					{
						oCertificado = current;
						if (current.NotAfter < DateTime.Today.AddMonths(1))
						{
							XtraMessageBox.Show($"O Certificado Digital irá vencer em : {current.NotAfter}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						return true;
					}
					break;
				}
			}
		}
		X509Certificate2Collection x509Certificate2Collection = certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, validOnly: false);
		X509Certificate2Collection certificates2 = certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, validOnly: false);
		X509Certificate2Collection x509Certificate2Collection2 = X509Certificate2UI.SelectFromCollection(certificates2, "Certificado(s) Digital(is) disponível(is)", "Selecione o certificado digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
		bool flag;
		if (x509Certificate2Collection2.Count == 0)
		{
			string text = "Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.";
			MessageBox.Show(text, "Advertência", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			flag = InstalarCertificado();
			if (flag)
			{
				flag = SelecionarCertificado(chaveCertificado, out novoCertificado);
			}
		}
		else
		{
			oCertificado = x509Certificate2Collection2[0];
			novoCertificado = oCertificado.SerialNumber;
			flag = true;
		}
		return flag;
	}

	public void ExibirCertSel()
	{
		if (oCertificado == null)
		{
			MessageBox.Show("Nenhum certificado foi selecionado.", "Advertência", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			X509Certificate2UI.DisplayCertificate(oCertificado);
		}
	}

	public void PrepInfCertificado(X509Certificate2 pCertificado)
	{
		string findValue = pCertificado.Subject.ToString();
		X509Certificate2 x509Certificate = new X509Certificate2();
		X509Store x509Store = new X509Store("MY", StoreLocation.CurrentUser);
		x509Store.Open(OpenFlags.OpenExistingOnly);
		X509Certificate2Collection certificates = x509Store.Certificates;
		X509Certificate2Collection x509Certificate2Collection = certificates.Find(X509FindType.FindBySubjectDistinguishedName, findValue, validOnly: false);
		if (x509Certificate2Collection.Count == 0)
		{
			lLocalizouCertificado = false;
			return;
		}
		x509Certificate = x509Certificate2Collection[0];
		sSubject = x509Certificate.Subject;
		dValidadeInicial = x509Certificate.NotBefore;
		dValidadeFinal = x509Certificate.NotAfter;
		lLocalizouCertificado = true;
	}

	public bool InstalarCertificado(string nomeCertificado, string senha)
	{
		bool result = true;
		X509Certificate2 x509Certificate = new X509Certificate2(nomeCertificado, senha);
		if (x509Certificate.NotAfter > DateTime.Now)
		{
			try
			{
				X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
				x509Store.Open(OpenFlags.ReadWrite);
				x509Store.Add(x509Certificate);
				x509Store.Close();
			}
			catch (Exception ex)
			{
				result = false;
				MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			MessageBox.Show("Certificado Vencido: " + x509Certificate.NotAfter.ToString(), "Advertência", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			result = false;
		}
		return result;
	}

	public bool InstalarCertificado()
	{
		return false;
	}
}
