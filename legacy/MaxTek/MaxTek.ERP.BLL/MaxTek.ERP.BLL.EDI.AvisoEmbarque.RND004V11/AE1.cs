using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxTek.ERP.BLL.EDI.AvisoEmbarque.RND004V11;

[Serializable]
public class AE1
{
	private NF2 nf2;

	private IList<NF3> nf3s = new List<NF3>();

	private IList<AE2> ae2s = new List<AE2>();

	private IList<AE3> ae3s = new List<AE3>();

	private IList<TE1> te1s = new List<TE1>();

	public StringBuilder Saida
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}", Seq01.PadRight(3), Seq02.ToString().PadLeft(6, '0'), Seq03.PadRight(4), Seq04.ToString("yyMMdd"), Seq05.ToString().PadLeft(3, '0'), Seq06.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq07.ToString().PadLeft(1, '0'), Seq08.PadLeft(3, '0'), Seq09.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq10.ToString("yyMMdd"), Seq11.ToString().PadLeft(2, '0'), Seq12.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq13.PadRight(3), Seq14.ToString("yyMMdd"), Seq15.PadRight(4), Seq16.PadRight(20), "".PadRight(6), "".PadRight(4));
			int length = stringBuilder.Length;
			bool flag = true;
			stringBuilder.Append(Nf2.Saida);
			foreach (NF3 nf in nf3s)
			{
				stringBuilder.Append(nf.Saida);
			}
			foreach (AE2 ae in ae2s)
			{
				stringBuilder.Append(ae.Saida);
			}
			foreach (AE3 ae2 in ae3s)
			{
				stringBuilder.Append(ae2.Saida);
			}
			foreach (TE1 te in te1s)
			{
				stringBuilder.Append(te.Saida);
			}
			return stringBuilder;
		}
	}

	public string Seq01 { get; set; }

	public int Seq02 { get; set; }

	public string Seq03 { get; set; }

	public DateTime Seq04 { get; set; }

	public int Seq05 { get; set; }

	public decimal Seq06 { get; set; }

	public int Seq07 { get; set; }

	public string Seq08 { get; set; }

	public decimal Seq09 { get; set; }

	public DateTime Seq10 { get; set; }

	public int Seq11 { get; set; }

	public decimal Seq12 { get; set; }

	public string Seq13 { get; set; }

	public DateTime Seq14 { get; set; }

	public string Seq15 { get; set; }

	public string Seq16 { get; set; }

	public DateTime Seq17 { get; set; }

	public NF2 Nf2 => nf2;

	public IList<NF3> Nf3s => nf3s;

	private IList<AE2> Ae2s => ae2s;

	private IList<AE3> Ae3s => ae3s;

	private IList<TE1> Te1s => te1s;

	public AE1(NotaFiscalNotasFiscais NotaFiscal)
	{
		Seq01 = "AE1";
		Seq02 = NotaFiscal.NumeroNotaFiscal;
		Seq03 = NotaFiscal.CodigoSerieNF.ToString();
		Seq04 = NotaFiscal.DataEmissao;
		Seq05 = NotaFiscal.Itens.Count();
		Seq06 = NotaFiscal.ValorTotalNotaFiscal;
		Seq07 = 2;
		Seq08 = "";
		Seq09 = NotaFiscal.ValorICMS;
		Seq10 = DateTime.Now;
		Seq11 = 0;
		Seq12 = NotaFiscal.ValorIPI;
		Seq13 = "";
		Seq14 = NotaFiscal.DataEnvioNFE;
		Seq15 = "0000";
		Seq16 = "";
		Seq17 = DateTime.Now;
		nf2 = new NF2(NotaFiscal);
	}
}
