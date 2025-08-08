using System;
using System.Text;

namespace MaxTek.ERP.BLL.EDI.AvisoEmbarque.RND004V11;

[Serializable]
public class NF2
{
	public StringBuilder Saida
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}", Seq01.PadRight(3), Seq02.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq03.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq05.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq06.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq07.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq08.PadRight(23));
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

	public string Seq08 { get; set; }

	public NF2(NotaFiscalNotasFiscais NotaFiscal)
	{
		Seq01 = "NF2";
		Seq02 = 0m;
		Seq03 = NotaFiscal.ValorFrete;
		Seq04 = NotaFiscal.ValorSeguro;
		Seq05 = 0m;
		Seq06 = NotaFiscal.ValorBaseICMS;
		Seq07 = 0m;
		Seq08 = string.Empty;
	}
}
