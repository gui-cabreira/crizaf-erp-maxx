using System;
using System.Collections.Generic;
using System.Text;

namespace MaxTek.ERP.BLL.EDI.AvisoEmbarque.RND004V11;

[Serializable]
public class AE2
{
	private AE4 ae4;

	private IList<AE5> ae5s = new List<AE5>();

	private AE7 ae7 = new AE7();

	public StringBuilder Saida
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}", Seq01.PadRight(3), Seq02.ToString().PadLeft(3, '0'), Seq03.PadRight(12), Seq04.PadRight(30), Seq05.ToString().PadLeft(9, '0'), Seq06.PadRight(2), Seq07.PadRight(10), Seq08.ToString("F2").Replace(",", "").PadLeft(4, '0'), Seq09.ToString("F5").Replace(",", "").PadLeft(12, '0'), Seq10.ToString().PadLeft(9, '0'), Seq11.PadRight(2), Seq12.ToString().PadLeft(9, '0'), Seq13.PadRight(2), Seq14.PadRight(10), Seq15.ToString("F2").Replace(",", "").PadLeft(4, '0'), Seq16.ToString("F2").Replace(",", "").PadLeft(11, '0'), Seq17.PadRight(4), Seq18.PadRight(1));
			int length = stringBuilder.Length;
			stringBuilder.Append(Ae4);
			foreach (AE5 ae in Ae5s)
			{
				stringBuilder.Append(ae);
			}
			stringBuilder.Append(Ae7);
			return stringBuilder;
		}
	}

	public string Seq01 { get; set; }

	public int Seq02 { get; set; }

	public string Seq03 { get; set; }

	public string Seq04 { get; set; }

	public int Seq05 { get; set; }

	public string Seq06 { get; set; }

	public string Seq07 { get; set; }

	public decimal Seq08 { get; set; }

	public decimal Seq09 { get; set; }

	public int Seq10 { get; set; }

	public string Seq11 { get; set; }

	public int Seq12 { get; set; }

	public string Seq13 { get; set; }

	public string Seq14 { get; set; }

	public decimal Seq15 { get; set; }

	public decimal Seq16 { get; set; }

	public string Seq17 { get; set; }

	public string Seq18 { get; set; }

	public AE4 Ae4 => ae4;

	private IList<AE5> Ae5s => ae5s;

	public AE7 Ae7 => ae7;

	public AE2(NotaFiscalNotasFiscaisItens NFItem)
	{
		Seq01 = "AE2";
		Seq02 = NFItem.Ordem;
		Seq03 = NFItem.ContratoCliente;
		Seq04 = NFItem.CodigoExterno;
		Seq05 = (int)NFItem.Quantidade;
		Seq06 = NFItem.SiglaUnidadeFaturamento;
		Seq07 = NFItem.CodigoClassificacaoFiscal;
		Seq08 = NFItem.AliquotaIPI;
		Seq09 = NFItem.ValorUnitario;
		Seq10 = (int)NFItem.Quantidade;
		Seq11 = NFItem.SiglaUnidadeFaturamento;
		Seq12 = (int)NFItem.Quantidade;
		Seq13 = NFItem.SiglaUnidadeFaturamento;
		Seq14 = "";
		Seq15 = 0m;
		Seq16 = 0m;
		Seq17 = "";
		Seq18 = "";
		ae4 = new AE4(NFItem);
	}
}
