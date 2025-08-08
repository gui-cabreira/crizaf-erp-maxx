namespace MaxTek.ERP.BLL.EDI.AvisoEmbarque.RND004V11;

public class FTP
{
	public string Saida
	{
		get
		{
			string text = string.Format("{0}{1}{2}{3}{4}{5}", Seq01.PadRight(3), Seq02.ToString("F0").Replace(",", "").PadLeft(5, '0'), Seq03.ToString("F0").Replace(",", "").PadLeft(9, '0'), Seq04.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq05.PadLeft(1), "".PadRight(93));
			int length = text.Length;
			return text;
		}
	}

	public string Seq01 { get; set; }

	public int Seq02 { get; set; }

	public int Seq03 { get; set; }

	public decimal Seq04 { get; set; }

	public string Seq05 { get; set; }

	public string Seq06 { get; set; }

	public FTP(NotaFiscalNotasFiscais NotaFiscal)
	{
		Seq01 = "AE2";
		Seq02 = NotaFiscal.NumeroNotaFiscal;
		Seq03 = 1;
		Seq04 = 0m;
		Seq05 = "";
		Seq06 = "";
	}
}
