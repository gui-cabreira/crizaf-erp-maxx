using System;
using System.Text;

namespace MaxTek.ERP.BLL.EDI.RND004V15;

[Serializable]
public class NF2
{
	public StringBuilder Saida
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}", Seq01.PadRight(3), Seq02.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq03.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq04.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq05.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq06.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq07.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq08.ToString().PadLeft(6, '0'), Seq09.ToString("yyMMdd"), Seq10.PadRight(4), Seq11.PadRight(3), Seq12.ToString().PadLeft(5, '0'), "".PadRight(29)).AppendLine();
			int length = stringBuilder.Length;
			return stringBuilder;
		}
	}

	public string Seq01 { get; set; }

	public decimal Seq02 { get; set; }

	public decimal Seq03 { get; set; }

	public decimal Seq04 { get; set; }

	public decimal Seq05 { get; set; }

	public decimal Seq06 { get; set; }

	public decimal Seq07 { get; set; }

	public int Seq08 { get; set; }

	public DateTime Seq09 { get; set; }

	public string Seq10 { get; set; }

	public string Seq11 { get; set; }

	public string Seq12 { get; set; }

	public string Seq13 { get; set; }

	public NF2(NotaFiscalNotasFiscais NotaFiscal)
	{
		Seq01 = "NF2";
		Seq02 = 0m;
		Seq03 = NotaFiscal.ValorFrete;
		Seq04 = NotaFiscal.ValorSeguro;
		Seq05 = 0m;
		Seq06 = NotaFiscal.ValorBaseICMS;
		Seq07 = 0m;
		Seq08 = NotaFiscal.NumeroNotaFiscal;
		Seq09 = NotaFiscal.DataEmissao;
		Seq10 = NotaFiscal.SerieNotaFiscal;
		Seq11 = "";
		Seq12 = NotaFiscal.NumeracaoCFOP.Replace(".", "");
	}
}
