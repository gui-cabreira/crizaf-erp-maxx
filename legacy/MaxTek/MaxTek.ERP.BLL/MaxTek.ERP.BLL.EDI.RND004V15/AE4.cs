using System.Text;

namespace MaxTek.ERP.BLL.EDI.RND004V15;

public class AE4
{
	public StringBuilder Saida
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}", Seq01.PadRight(3), Seq02.ToString("F2").Replace(",", "").PadLeft(4, '0'), Seq03.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq04.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq05.ToString("F2").Replace(",", "").PadLeft(17, '0'), Seq06.PadRight(2), Seq07.PadRight(30), Seq08.PadRight(6), Seq09.PadRight(13), Seq10.PadRight(5), Seq11.PadRight(1), Seq12.ToString("F2").Replace(",", "").PadLeft(12, '0'), Seq13.PadRight(1)).AppendLine();
			int length = stringBuilder.Length;
			return stringBuilder;
		}
	}

	public string Seq01 { get; set; }

	public decimal Seq02 { get; set; }

	public decimal Seq03 { get; set; }

	public decimal Seq04 { get; set; }

	public decimal Seq05 { get; set; }

	public string Seq06 { get; set; }

	public string Seq07 { get; set; }

	public string Seq08 { get; set; }

	public string Seq09 { get; set; }

	public string Seq10 { get; set; }

	public string Seq11 { get; set; }

	public decimal Seq12 { get; set; }

	public string Seq13 { get; set; }

	public AE4(NotaFiscalNotasFiscaisItens NFItem)
	{
		Seq01 = "AE4";
		Seq02 = NFItem.AliquotaICMS;
		Seq03 = NFItem.ValorBaseICMS;
		Seq04 = NFItem.ValorICMS;
		Seq05 = NFItem.ValorIPI;
		Seq06 = NFItem.TipoIncidenciaIcms;
		Seq07 = "";
		Seq08 = "";
		Seq09 = "";
		Seq10 = NFItem.PesoLiquido.ToString("F0");
		Seq11 = "";
		Seq12 = NFItem.ValorTotal;
		Seq13 = NFItem.CodigoOrigemProduto;
	}
}
