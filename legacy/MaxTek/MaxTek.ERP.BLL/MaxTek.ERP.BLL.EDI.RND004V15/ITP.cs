using System;
using System.Text;

namespace MaxTek.ERP.BLL.EDI.RND004V15;

[Serializable]
public class ITP
{
	private AE1 ae1;

	private FTP ftp;

	public string SaidaArquivo
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(Saida);
			stringBuilder.Append(Ae1.Saida);
			stringBuilder.AppendLine(Ftp.Saida);
			return stringBuilder.ToString();
		}
	}

	private string Saida
	{
		get
		{
			string text = string.Format("{0}{1}{2}{3}{4:yyMMddHHmmss}{5}{6}{7}{8}{9}{10}{11}", Seq01.PadRight(3), Seq02.ToString().PadLeft(3, '0'), Seq03.ToString().PadLeft(2, '0'), Seq04.ToString().PadLeft(5, '0'), Seq05, Seq06.ToString().PadLeft(14, '0'), Seq07.ToString().PadLeft(14, '0'), Seq08.PadRight(8), Seq09.PadRight(8), Seq10.PadRight(25), Seq11.PadRight(25), "".PadRight(9));
			int length = text.Length;
			return text;
		}
	}

	public string Seq01 { get; set; }

	public string Seq02 { get; set; }

	public int Seq03 { get; set; }

	public int Seq04 { get; set; }

	public DateTime Seq05 { get; set; }

	public string Seq06 { get; set; }

	public string Seq07 { get; set; }

	public string Seq08 { get; set; }

	public string Seq09 { get; set; }

	public string Seq10 { get; set; }

	public string Seq11 { get; set; }

	public string Seq12 { get; set; }

	public AE1 Ae1
	{
		get
		{
			return ae1;
		}
		set
		{
			ae1 = value;
		}
	}

	public FTP Ftp
	{
		get
		{
			return ftp;
		}
		set
		{
			ftp = value;
		}
	}

	public ITP(NotaFiscalNotasFiscais NotaFiscal)
	{
		Seq01 = "ITP";
		Seq02 = "004";
		Seq03 = 15;
		Seq04 = NotaFiscal.NumeroNotaFiscal;
		Seq05 = DateTime.Now;
		Seq06 = NotaFiscal.SociedadeRef.CNPJLimpo;
		Seq07 = NotaFiscal.Entidade.CNPJLimpo;
		Seq08 = NotaFiscal.Entidade.CodigoVendedorEDI;
		Seq09 = NotaFiscal.Entidade.CodigoCompradorEDI;
		Seq10 = NotaFiscal.SociedadeRef.RazaoSocial;
		if (Seq10.Length > 25)
		{
			Seq10 = Seq10.Substring(0, 25);
		}
		Seq11 = NotaFiscal.Entidade.RazaoSocialNF;
		if (Seq11.Length > 25)
		{
			Seq11 = Seq11.Substring(0, 25);
		}
		Seq12 = string.Empty;
		Ae1 = new AE1(NotaFiscal);
		int count = NotaFiscal.Itens.Count;
		int linhas = 4 + count * 2;
		ftp = new FTP(NotaFiscal, linhas);
	}
}
