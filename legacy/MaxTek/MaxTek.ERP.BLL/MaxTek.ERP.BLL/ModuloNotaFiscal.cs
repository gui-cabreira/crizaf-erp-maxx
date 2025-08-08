using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using MaxTek.Core;
using MaxTek.ERP.BLL.NotaFiscal.NFe;
using MaxTek.ERP.BLL.RPT.Etiquetas;
using MaxTek.ERP.DAL;
using MaxTek.ERP.RPT;
using MaxTek.GPS.BLL;
using MaxTek.MaxEditors.Windows.Forms;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloNotaFiscal
{
	private static short _qdeEtiquetas = 0;

	private static IList<NotaFiscalTipoIncidencia> _tipoIncidencia;

	private static INotaFiscalFatura _notaFiscalFaturaDao = AcessoDados.NotaFiscalFaturaDAO;

	private static INotaFiscalTipoIncidenciaImpostosFederais _notaFiscalTipoIncidenciaImpostosFederaisDao = AcessoDados.NotaFiscalTipoIncidenciaImpostosFederaisDAO;

	private static INotaFiscalTipoIncidenciaIPI _notaFiscalTipoIncidenciaIPIDao = AcessoDados.NotaFiscalTipoIncidenciaIPIDAO;

	private static INotaFiscalPaises _notaFiscalPaisesDao = AcessoDados.NotaFiscalPaisesDAO;

	private static INotaFiscalWebServices _notaFiscalWebServicesDao = AcessoDados.NotaFiscalWebServicesDAO;

	private static INotaFiscalCidades _notaFiscalCidadesDao = AcessoDados.NotaFiscalCidadesDAO;

	private static INotaFiscalUF _notaFiscalUFDao = AcessoDados.NotaFiscalUFDAO;

	private static INotaFiscalSerie _notaFiscalSerieDao = AcessoDados.NotaFiscalSerieDAO;

	private static INotaFiscalFormasPagto _notaFiscalFormasPagtoDao = AcessoDados.NotaFiscalFormasPagtoDAO;

	private static INotaFiscalNotasFiscais _notaFiscalNotasFiscaisDao = AcessoDados.NotaFiscalNotasFiscaisDAO;

	private static INotaFiscalNotasFiscaisItens _notaFiscalNotasFiscaisItensDao = AcessoDados.NotaFiscalNotasFiscaisItensDAO;

	private static INotaFiscalCFOPs _notaFiscalCFOPsDao = AcessoDados.NotaFiscalCFOPsDAO;

	private static INotaFiscalModalidadeBaseCalculo _notaFiscalModalidadeBaseCalculoDao = AcessoDados.NotaFiscalModalidadeBaseCalculoDAO;

	private static INotaFiscalModalidadeBaseCalculoICMSST _notaFiscalModalidadeBaseCalculoICMSSTDao = AcessoDados.NotaFiscalModalidadeBaseCalculoICMSSTDAO;

	private static INotaFiscalTextosLegais _notaFiscalTextosLegaisDao = AcessoDados.NotaFiscalTextosLegaisDAO;

	private static INotaFiscalTipoIncidencia _notaFiscalTipoIncidenciaDao = AcessoDados.NotaFiscalTipoIncidenciaDAO;

	private static INotaFiscalTipoRetencaoImposto _notaFiscalTipoRetencaoImpostoDao = AcessoDados.NotaFiscalTipoRetencaoImpostoDAO;

	private static INotaFiscalOrigemProduto _notaFiscalOrigemProdutoDao = AcessoDados.NotaFiscalOrigemProdutoDAO;

	private static INotaFiscalResumoFaturamento _notaFiscalResumoFaturamentoDao = AcessoDados.NotaFiscalResumoFaturamentoDAO;

	private static INotasFiscaisEventos _notasFiscaisEventosDao = AcessoDados.NotasFiscaisEventosDAO;

	private static INotaFiscalNotasFiscaisItensDI _notaFiscalNotasFiscaisItensDIDao = AcessoDados.NotaFiscalNotasFiscaisItensDIDAO;

	private static INotaFiscalNotasFiscaisItensDIAdicoes _notaFiscalNotasFiscaisItensDIAdicoesDao = AcessoDados.NotaFiscalNotasFiscaisItensDIAdicoesDAO;

	private static INotaFiscalInutilizacao _notaFiscalInutilizacaoDao = AcessoDados.NotaFiscalInutilizacaoDAO;

	private static INotaFiscalCest _notaFiscalCestDao = AcessoDados.NotaFiscalCestDAO;

	private static INotaFiscalNotaReferenciada _notaFiscalNotaReferenciadaDao = AcessoDados.NotaFiscalNotaReferenciadaDAO;

	internal static string DirDanfe => ConfigNFe.Instancia.DirDanfe;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalTipoIncidencia> ObterTodosNotaFiscalTipoIncidencia()
	{
		if (_tipoIncidencia == null)
		{
			IList<NotaFiscalTipoIncidencia> list = ObjectDataMapper.MapObjectList<NotaFiscalTipoIncidencia>((IList)_notaFiscalTipoIncidenciaDao.ObterTodosNotaFiscalTipoIncidencia());
			Sociedade sociedade = ModuloParametros.ObterSociedade(1);
			_tipoIncidencia = new List<NotaFiscalTipoIncidencia>();
			if (sociedade.RegimeTributacao == enumTipoRegimeTributario.RegimeNormal || sociedade.RegimeTributacao == enumTipoRegimeTributario.SimplesNacioonalExcessoSublimite)
			{
				foreach (NotaFiscalTipoIncidencia item in list)
				{
					int result = 0;
					int.TryParse(item.TipoIncidencia, out result);
					if (result < 100)
					{
						_tipoIncidencia.Add(item);
					}
				}
			}
			else
			{
				foreach (NotaFiscalTipoIncidencia item2 in list)
				{
					int result2 = 0;
					int.TryParse(item2.TipoIncidencia, out result2);
					if (result2 >= 100)
					{
						_tipoIncidencia.Add(item2);
					}
				}
			}
		}
		return _tipoIncidencia;
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(int codigoTipoIncidencia)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidencia>(_notaFiscalTipoIncidenciaDao.ObterNotaFiscalTipoIncidencia(codigoTipoIncidencia));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(NotaFiscalTipoIncidencia notaFiscalTipoIncidencia)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidencia>(_notaFiscalTipoIncidenciaDao.ObterNotaFiscalTipoIncidencia((MapTableNotaFiscalTipoIncidencia)notaFiscalTipoIncidencia.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalTipoIncidencia(NotaFiscalTipoIncidencia notaFiscalTipoIncidencia)
	{
		return _notaFiscalTipoIncidenciaDao.InserirNotaFiscalTipoIncidencia((MapTableNotaFiscalTipoIncidencia)notaFiscalTipoIncidencia.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalTipoIncidencia(NotaFiscalTipoIncidencia notaFiscalTipoIncidencia, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalTipoIncidenciaDao.AlterarNotaFiscalTipoIncidencia((MapTableNotaFiscalTipoIncidencia)notaFiscalTipoIncidencia.ObterDadosMapeados(), camposAlterados);
		notaFiscalTipoIncidencia.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalTipoIncidencia(int codigoTipoIncidencia)
	{
		return _notaFiscalTipoIncidenciaDao.ExcluirNotaFiscalTipoIncidencia(codigoTipoIncidencia);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalModalidadeBaseCalculo> ObterTodosNotaFiscalModalidadeBaseCalculo()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalModalidadeBaseCalculo>((IList)_notaFiscalModalidadeBaseCalculoDao.ObterTodosNotaFiscalModalidadeBaseCalculo());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalModalidadeBaseCalculo ObterNotaFiscalModalidadeBaseCalculo(int codigoModalidade)
	{
		return ObjectDataMapper.MapObject<NotaFiscalModalidadeBaseCalculo>(_notaFiscalModalidadeBaseCalculoDao.ObterNotaFiscalModalidadeBaseCalculo(codigoModalidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalModalidadeBaseCalculo ObterNotaFiscalModalidadeBaseCalculo(NotaFiscalModalidadeBaseCalculo notaFiscalModalidadeBaseCalculo)
	{
		return ObjectDataMapper.MapObject<NotaFiscalModalidadeBaseCalculo>(_notaFiscalModalidadeBaseCalculoDao.ObterNotaFiscalModalidadeBaseCalculo((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculo.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalModalidadeBaseCalculo(NotaFiscalModalidadeBaseCalculo notaFiscalModalidadeBaseCalculo)
	{
		return _notaFiscalModalidadeBaseCalculoDao.InserirNotaFiscalModalidadeBaseCalculo((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculo.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalModalidadeBaseCalculo(NotaFiscalModalidadeBaseCalculo notaFiscalModalidadeBaseCalculo, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalModalidadeBaseCalculoDao.AlterarNotaFiscalModalidadeBaseCalculo((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculo.ObterDadosMapeados(), camposAlterados);
		notaFiscalModalidadeBaseCalculo.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalModalidadeBaseCalculo(int codigoModalidade)
	{
		return _notaFiscalModalidadeBaseCalculoDao.ExcluirNotaFiscalModalidadeBaseCalculo(codigoModalidade);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalModalidadeBaseCalculoICMSST> ObterTodosNotaFiscalModalidadeBaseCalculoICMSST()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalModalidadeBaseCalculoICMSST>((IList)_notaFiscalModalidadeBaseCalculoICMSSTDao.ObterTodosNotaFiscalModalidadeBaseCalculoICMSST());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalModalidadeBaseCalculoICMSST ObterNotaFiscalModalidadeBaseCalculoICMSST(int codigoModalidade)
	{
		return ObjectDataMapper.MapObject<NotaFiscalModalidadeBaseCalculoICMSST>(_notaFiscalModalidadeBaseCalculoICMSSTDao.ObterNotaFiscalModalidadeBaseCalculoICMSST(codigoModalidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalModalidadeBaseCalculoICMSST ObterNotaFiscalModalidadeBaseCalculoICMSST(NotaFiscalModalidadeBaseCalculoICMSST notaFiscalModalidadeBaseCalculoICMSST)
	{
		return ObjectDataMapper.MapObject<NotaFiscalModalidadeBaseCalculoICMSST>(_notaFiscalModalidadeBaseCalculoICMSSTDao.ObterNotaFiscalModalidadeBaseCalculoICMSST((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculoICMSST.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalModalidadeBaseCalculoICMSST(NotaFiscalModalidadeBaseCalculoICMSST notaFiscalModalidadeBaseCalculoICMSST)
	{
		return _notaFiscalModalidadeBaseCalculoICMSSTDao.InserirNotaFiscalModalidadeBaseCalculoICMSST((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculoICMSST.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalModalidadeBaseCalculoICMSST(NotaFiscalModalidadeBaseCalculoICMSST notaFiscalModalidadeBaseCalculoICMSST, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalModalidadeBaseCalculoICMSSTDao.AlterarNotaFiscalModalidadeBaseCalculoICMSST((MapTableNotaFiscalModalidadeBaseCalculo)notaFiscalModalidadeBaseCalculoICMSST.ObterDadosMapeados(), camposAlterados);
		notaFiscalModalidadeBaseCalculoICMSST.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalModalidadeBaseCalculoICMSST(int codigoModalidade)
	{
		return _notaFiscalModalidadeBaseCalculoICMSSTDao.ExcluirNotaFiscalModalidadeBaseCalculoICMSST(codigoModalidade);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalFatura> ObterTodosNotaFiscalFatura()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalFatura>((IList)_notaFiscalFaturaDao.ObterTodosNotaFiscalFatura());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalFatura> ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalFatura>((IList)_notaFiscalFaturaDao.ObterNotaFiscalFatura(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalFatura ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		return ObjectDataMapper.MapObject<NotaFiscalFatura>(_notaFiscalFaturaDao.ObterNotaFiscalFatura(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, codigoFatura));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalFatura ObterNotaFiscalFatura(NotaFiscalFatura notaFiscalFatura)
	{
		return ObjectDataMapper.MapObject<NotaFiscalFatura>(_notaFiscalFaturaDao.ObterNotaFiscalFatura((MapTableNotaFiscalFatura)notaFiscalFatura.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalFatura(NotaFiscalFatura notaFiscalFatura)
	{
		return _notaFiscalFaturaDao.InserirNotaFiscalFatura((MapTableNotaFiscalFatura)notaFiscalFatura.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalFatura(NotaFiscalFatura notaFiscalFatura, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalFaturaDao.AlterarNotaFiscalFatura((MapTableNotaFiscalFatura)notaFiscalFatura.ObterDadosMapeados(), camposAlterados);
		notaFiscalFatura.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		return _notaFiscalFaturaDao.ExcluirNotaFiscalFatura(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, codigoFatura);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return _notaFiscalFaturaDao.ExcluirNotaFiscalFatura(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
	}

	public static IList<NotaFiscalFatura> CalcularCondicaoPagamento(CondicaoPagamentoGPS pagto, DateTime dataInicioCalulo, decimal valorAFaturar, int numeroNotaFiscal, int serieNotaFiscal)
	{
		return CalcularCondicaoPagamento(pagto, dataInicioCalulo, valorAFaturar, numeroNotaFiscal, serieNotaFiscal, 0m);
	}

	public static IList<NotaFiscalFatura> CalcularCondicaoPagamento(CondicaoPagamentoGPS pagto, DateTime dataInicioCalulo, decimal valorAFaturar, int numeroNotaFiscal, int serieNotaFiscal, decimal adicionarPrimeira)
	{
		if (pagto == null)
		{
			pagto = new CondicaoPagamentoGPS();
		}
		bool isCalcularDataPedido = pagto.IsCalcularDataPedido;
		IList<NotaFiscalFatura> list = new List<NotaFiscalFatura>();
		DateTime dateTime = dataInicioCalulo;
		DateTime dateTime2 = dataInicioCalulo;
		if (pagto != null)
		{
			if (pagto.Carencia != EnumCarencia.SemControle)
			{
				int num = 0;
				switch (pagto.Carencia)
				{
				case EnumCarencia.Semana:
					switch (dateTime2.DayOfWeek)
					{
					case DayOfWeek.Monday:
						dateTime2 = dateTime2.AddDays(7.0);
						break;
					case DayOfWeek.Tuesday:
						dateTime2 = dateTime2.AddDays(6.0);
						break;
					case DayOfWeek.Wednesday:
						dateTime2 = dateTime2.AddDays(5.0);
						break;
					case DayOfWeek.Thursday:
						dateTime2 = dateTime2.AddDays(4.0);
						break;
					case DayOfWeek.Friday:
						dateTime2 = dateTime2.AddDays(3.0);
						break;
					case DayOfWeek.Saturday:
						dateTime2 = dateTime2.AddDays(2.0);
						break;
					case DayOfWeek.Sunday:
						dateTime2 = dateTime2.AddDays(1.0);
						break;
					}
					break;
				case EnumCarencia.Dezena:
					num = dateTime2.Day;
					if (num < 10)
					{
						int num3 = 10 - num;
						dateTime2 = dateTime2.AddDays(num3);
					}
					else if (num > 11 && num < 20)
					{
						int num4 = 20 - num;
						dateTime2 = dateTime2.AddDays(num4);
					}
					else if (num > 20)
					{
						dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(1);
					}
					break;
				case EnumCarencia.Quinzena:
					num = dateTime2.Day;
					if (num < 15)
					{
						int num2 = 15 - num;
						dateTime2 = dateTime2.AddDays(num2);
					}
					else if (num > 11 && num < 20)
					{
						dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(1);
					}
					break;
				case EnumCarencia.Mês:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(1);
					break;
				case EnumCarencia.Bimestre:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(2);
					break;
				case EnumCarencia.Trimestre:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(3);
					break;
				case EnumCarencia.Quadrimestre:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(4);
					break;
				case EnumCarencia.Semestre:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(6);
					break;
				case EnumCarencia.Ano:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(12);
					break;
				case EnumCarencia.Biênio:
					num = dateTime2.Day;
					dateTime2 = dateTime2.AddDays(-num + 1).AddMonths(24);
					break;
				default:
					throw new Exception("Calculo ainda não desenvolvido. Checar data da Fatura!");
				}
			}
			dateTime = dateTime2.AddDays(pagto.PrimeiraParcela);
			int num5 = 1;
			if (pagto != null && pagto.QuantidadeVezes > 1)
			{
				num5 = Math.Max(pagto.QuantidadeVezes, 1);
			}
			decimal num6 = Math.Round(valorAFaturar - adicionarPrimeira, 2);
			decimal num7 = Math.Round(num6 / (decimal)num5, 2);
			decimal num8 = num7 + (num6 - num7 * (decimal)num5) + adicionarPrimeira;
			char c = 'A';
			for (int i = 0; i < num5; i++)
			{
				NotaFiscalFatura notaFiscalFatura = new NotaFiscalFatura();
				notaFiscalFatura.IsNaoGerarTitulo = isCalcularDataPedido;
				notaFiscalFatura.CodigoFatura = $"{numeroNotaFiscal:00000000}-{c}";
				notaFiscalFatura.ValorFatura = ((i == 0) ? num8 : num7);
				if (pagto.DiaSemanaPagamento != EnumDiasSemana.SemControle)
				{
					dateTime = AjustarVencimentoDiaSemana(pagto, dateTime);
				}
				else if (pagto.DiaMesPagamento > 0)
				{
					dateTime = AjustarVencimentoDia(pagto, dateTime);
				}
				notaFiscalFatura.Vencimento = dateTime;
				notaFiscalFatura.CodigoSerieNotaFiscal = serieNotaFiscal;
				list.Add(notaFiscalFatura);
				c = (char)(c + 1);
				if (pagto != null)
				{
					dateTime = dateTime.AddDays(pagto.PrazoDemaisParcelas);
				}
			}
		}
		return list;
	}

	private static DateTime AjustarVencimentoDiaSemana(CondicaoPagamentoGPS pagto, DateTime primeira)
	{
		bool flag = false;
		while (!flag)
		{
			if (primeira.DayOfWeek == (DayOfWeek)pagto.DiaSemanaPagamento)
			{
				flag = true;
			}
			else
			{
				primeira = primeira.AddDays(1.0);
			}
		}
		return primeira;
	}

	private static DateTime AjustarVencimentoDia(CondicaoPagamentoGPS pagto, DateTime primeira)
	{
		int num = pagto.DiaMesPagamento;
		if (pagto.DiaMesPagamento2 > 0 && pagto.DiaMesPagamento2 >= primeira.Day && pagto.DiaMesPagamento < primeira.Day)
		{
			num = pagto.DiaMesPagamento2;
		}
		else if (pagto.DiaMesPagamento3 > 0 && pagto.DiaMesPagamento3 >= primeira.Day && pagto.DiaMesPagamento2 < primeira.Day)
		{
			num = pagto.DiaMesPagamento3;
		}
		else if (pagto.DiaMesPagamento4 > 0 && pagto.DiaMesPagamento4 >= primeira.Day && pagto.DiaMesPagamento3 < primeira.Day)
		{
			num = pagto.DiaMesPagamento4;
		}
		bool flag = false;
		while (!flag)
		{
			if (primeira.Day == num)
			{
				flag = true;
			}
			else
			{
				primeira = primeira.AddDays(1.0);
			}
		}
		return primeira;
	}

	public static IList<NotaFiscalFatura> CalcularCondicaoPagamento(decimal valorAFaturar, int numeroNotaFiscal, int serieNotaFiscal)
	{
		IList<NotaFiscalFatura> list = new List<NotaFiscalFatura>();
		if (valorAFaturar > 0m)
		{
			DateTime today = DateTime.Today;
			decimal valorFatura = Math.Round(valorAFaturar, 2);
			NotaFiscalFatura notaFiscalFatura = new NotaFiscalFatura();
			notaFiscalFatura.CodigoFatura = $"{numeroNotaFiscal:00000000}-A";
			notaFiscalFatura.ValorFatura = valorFatura;
			notaFiscalFatura.Vencimento = today;
			notaFiscalFatura.CodigoSerieNotaFiscal = serieNotaFiscal;
			list.Add(notaFiscalFatura);
		}
		return list;
	}

	public static NotaFiscalNotasFiscais GerarNotaFiscal(FichaExpedicao fe)
	{
		NotaFiscalNotasFiscais result = new NotaFiscalNotasFiscais();
		try
		{
			NotaFiscalSerie serie = null;
			NotaFiscalCFOPs cfop = ObterNotaFiscalCFOPs(fe.Itens[0].CodigoCfopInterna);
			IList<NotaFiscalSerie> list = ObterTodosNotaFiscalSerie((fe.CodigoSociedade == 0) ? 1 : fe.CodigoSociedade);
			if (list != null && list.Count > 0)
			{
				serie = list[list.Count - 1];
			}
			result = GerarNotaFiscal(fe.Codigo, serie, cfop);
		}
		catch
		{
		}
		return result;
	}

	public static NotaFiscalNotasFiscais GerarNotaFiscal(FichaExpedicao fe, NotaFiscalSerie serie, NotaFiscalCFOPs cfop)
	{
		return GerarNotaFiscal(fe.Codigo, serie, cfop);
	}

	public static NotaFiscalNotasFiscais GerarNotaFiscal(PedidoCompra pedido, NotaFiscalSerie serie, NotaFiscalCFOPs cfop)
	{
		return GerarNotaFiscal(-pedido.Codigo, serie, cfop);
	}

	public static NotaFiscalNotasFiscais GerarNotaFiscal(int fe, NotaFiscalSerie serie, NotaFiscalCFOPs cfop)
	{
		NotaFiscalNotasFiscais notaFiscalNotasFiscais = new NotaFiscalNotasFiscais();
		notaFiscalNotasFiscais.DataEmissao = DateTime.Now;
		notaFiscalNotasFiscais.DataSaida = DateTime.Now;
		notaFiscalNotasFiscais.SituacaoNfe = SituacaoNFe.NaoEnviada.ToString();
		notaFiscalNotasFiscais.CodigoCFOP = cfop.Id;
		notaFiscalNotasFiscais.SerieNotaFiscal = serie.CodigoSerie.ToString();
		notaFiscalNotasFiscais.CodigoSerieNF = serie.CodigoSerie;
		notaFiscalNotasFiscais.CodigoFichaExpedicao = fe;
		return notaFiscalNotasFiscais;
	}

	public static bool SepararNotasPorCFOP(NotaFiscalNotasFiscais nota, bool EnviarSefaz)
	{
		bool result = false;
		try
		{
			if (nota.IsNovo)
			{
				InserirNotaFiscalNotasFiscais(nota);
			}
			bool flag = false;
			string nomeCfop = nota.Itens[0].NomeCfop;
			foreach (NotaFiscalNotasFiscaisItens iten in nota.Itens)
			{
				if (nomeCfop != iten.NomeCfop)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				AlterarNotaFiscalNotasFiscais(nota, nota.PropriedadesModificadas);
				if (EnviarSefaz)
				{
					EnviarNotas(nota);
				}
			}
			else
			{
				AlterarNotaFiscalNotasFiscais(nota, nota.PropriedadesModificadas);
				IDictionary<string, NotaFiscalNotasFiscais> dictionary = new Dictionary<string, NotaFiscalNotasFiscais>();
				int numeroNotaFiscal = nota.NumeroNotaFiscal;
				foreach (NotaFiscalNotasFiscaisItens iten2 in nota.Itens)
				{
					if (dictionary.ContainsKey(iten2.NomeCfop))
					{
						dictionary[iten2.NomeCfop].Itens.Add(iten2);
						continue;
					}
					nota.CodigoFichaExpedicao = 0;
					nota.FichaExpedicaoRef = null;
					NotaFiscalNotasFiscais notaFiscalNotasFiscais = MaxFormUtils.CopyObject(nota);
					notaFiscalNotasFiscais.NumeroNotaFiscal = 0;
					nota.Fatura = null;
					notaFiscalNotasFiscais.TextoLegal = string.Empty;
					notaFiscalNotasFiscais.NumeracaoCFOP = string.Empty;
					notaFiscalNotasFiscais.DescricaoCFOP = string.Empty;
					notaFiscalNotasFiscais.CFOP = null;
					if (iten2.CFOPRef != null)
					{
						notaFiscalNotasFiscais.CFOP = iten2.CFOPRef;
						notaFiscalNotasFiscais.DescricaoCFOP = iten2.CFOPRef.Nfe;
						notaFiscalNotasFiscais.NumeracaoCFOP = iten2.NomeCfop;
						notaFiscalNotasFiscais.Itens = new List<NotaFiscalNotasFiscaisItens>();
						notaFiscalNotasFiscais.Itens.Add(iten2);
						dictionary.Add(iten2.NomeCfop, notaFiscalNotasFiscais);
						continue;
					}
					MaxWaitDialog.FecharMensagem();
					MaxCaixaMensagem.ShowErroOK($"O item {iten2.Ordem} - {iten2.CodigoProduto} não possui impostos asssociados.\r\nCorrija antes de realizar essa operação.", "Erro separando notas por CFOP");
					return false;
				}
				foreach (KeyValuePair<string, NotaFiscalNotasFiscais> item in dictionary)
				{
					item.Value.NumeroNotaFiscal = numeroNotaFiscal;
					numeroNotaFiscal = 0;
					if (item.Value.NumeroNotaFiscal > 0)
					{
						ExcluirNotaFiscalNotasFiscais(item.Value.CodigoEmpresa, item.Value.NumeroNotaFiscal, item.Value.CodigoSerieNF);
					}
					item.Value.AcertaTotais();
					item.Value.AtualizaTotais();
					SalvarNotaFiscalEnviarSefaz(item.Value, EnviarSefaz);
				}
				result = true;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public static void SalvarNotaFiscalEnviarSefaz(NotaFiscalNotasFiscais nota, bool EnviarSefaz)
	{
		if (nota.CodigoEmpresa == 0)
		{
			nota.CodigoEmpresa = 1;
		}
		nota.Id = InserirNotaFiscalNotasFiscais(nota);
		if (nota.FichaExpedicaoRef != null)
		{
			ModuloExpedicao.AlterarFichaExpedicao(nota.FichaExpedicaoRef, nota.FichaExpedicaoRef.PropriedadesModificadas);
		}
		else
		{
			foreach (NotaFiscalNotasFiscaisItens iten in nota.Itens)
			{
				if (iten.FichaExpedicaoItemRef != null)
				{
					ModuloExpedicao.AlterarFichaExpedicaoItem(iten.FichaExpedicaoItemRef, iten.FichaExpedicaoItemRef.PropriedadesModificadas);
				}
			}
		}
		if (EnviarSefaz)
		{
			MaxWaitDialog.MostrarMensagem("Sefaz", "Enviando Nota para o Sefaz");
			GerarNFe4(nota);
			Thread.Sleep(3000);
		}
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscais());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscais(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscais(codigoEmpresa, dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoCliente)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscais(codigoCliente));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisSituacao(string situacao)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscaisSituacao(situacao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscais>(_notaFiscalNotasFiscaisDao.ObterNotaFiscalNotasFiscais(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscais ObterNotaFiscalNotasFiscaisNumeroNota(int codigoEmpresa, int NotaFiscal, int codigoNotaFiscal)
	{
		return ObterNotaFiscalNotasFiscais(codigoEmpresa, NotaFiscal, codigoNotaFiscal);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisNumeroNota(int codigoNota)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscaisCodigoNota(codigoNota));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int tipo, int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscais(tipo, codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoContrato(string codigoContrato)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscaisCodigoContrato(codigoContrato));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoProduto(string codigoProduto)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscaisCodigoProduto(codigoProduto));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoPedidoVenda(int codigoPedidoVenda)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalNotasFiscaisCodigoPedidoVenda(codigoPedidoVenda));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(NotaFiscalNotasFiscais notaFiscalNotasFiscais)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscais>(_notaFiscalNotasFiscaisDao.ObterNotaFiscalNotasFiscais((MapTableNotaFiscalNotasFiscais)notaFiscalNotasFiscais.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(string chave)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscais>(_notaFiscalNotasFiscaisDao.ObterNotaFiscalNotasFiscais(chave));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalServico(codigoEmpresa, dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscais>((IList)_notaFiscalNotasFiscaisDao.ObterTodosNotaFiscalServico(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		ExcluirNotaFiscalFatura(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
		ExcluirNotaFiscalNotasFiscaisItens(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
		ExcluirNotaFiscalNotaReferenciada(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
		ExcluirNotaFiscalNotasFiscaisItensDI(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal);
		ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal);
		return _notaFiscalNotasFiscaisDao.ExcluirNotaFiscalNotasFiscais(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalNotasFiscais(NotaFiscalNotasFiscais notaFiscalNotasFiscais)
	{
		if (notaFiscalNotasFiscais.NumeroNotaFiscal == 0)
		{
			NotaFiscalSerie notaFiscalSerie = ObterNotaFiscalSerie(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF);
			if (notaFiscalSerie == null && notaFiscalNotasFiscais.CodigoEmpresa > 1 && !ModuloParametros.IsMultiEmpresa)
			{
				notaFiscalNotasFiscais.CodigoEmpresa = 1;
				notaFiscalSerie = ObterNotaFiscalSerie(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF);
			}
			notaFiscalNotasFiscais.NumeroNotaFiscal = ProximoNumeroNotaFiscal(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF);
			if (notaFiscalNotasFiscais.NumeroNotaFiscal < 1 || notaFiscalSerie.ProximoNumero > notaFiscalNotasFiscais.NumeroNotaFiscal)
			{
				notaFiscalNotasFiscais.NumeroNotaFiscal = notaFiscalSerie.ProximoNumero;
			}
		}
		else
		{
			bool flag = false;
			if (EstaNotaJaExiste(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF, notaFiscalNotasFiscais.NumeroNotaFiscal))
			{
				notaFiscalNotasFiscais.NumeroNotaFiscal = ProximoNumeroNotaFiscal(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF);
			}
		}
		if (notaFiscalNotasFiscais.Entidade.RazaoSocialNF != null)
		{
			notaFiscalNotasFiscais.RazaoSocialDestinatario = notaFiscalNotasFiscais.Entidade.RazaoSocialNF;
		}
		notaFiscalNotasFiscais.Id = _notaFiscalNotasFiscaisDao.InserirNotaFiscalNotasFiscais((MapTableNotaFiscalNotasFiscais)notaFiscalNotasFiscais.ObterDadosMapeados());
		SalvarItensNotaFiscal(notaFiscalNotasFiscais);
		if (notaFiscalNotasFiscais.Fatura != null && notaFiscalNotasFiscais.Fatura.Count > 0)
		{
			_notaFiscalFaturaDao.ExcluirNotaFiscalFatura(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.NumeroNotaFiscal, notaFiscalNotasFiscais.CodigoSerieNF);
			char c = 'A';
			foreach (NotaFiscalFatura item in notaFiscalNotasFiscais.Fatura)
			{
				item.CodigoEmpresa = notaFiscalNotasFiscais.CodigoEmpresa;
				item.CodigoSerieNotaFiscal = notaFiscalNotasFiscais.CodigoSerieNF;
				if (item.CodigoFatura == null || item.CodigoFatura.StartsWith("00000000-"))
				{
					item.CodigoFatura = $"{notaFiscalNotasFiscais.NumeroNotaFiscal:00000000}-{c}";
				}
				item.CodigoNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
				InserirNotaFiscalFatura(item);
				c = (char)(c + 1);
			}
		}
		if (notaFiscalNotasFiscais.matsCli != null)
		{
			foreach (KeyValuePair<int, EstoqueLoteMaterailClienteControle> item2 in notaFiscalNotasFiscais.matsCli)
			{
				ModuloEngenharia.SalvarEstoqueLoteMaterailClienteControle(item2.Value);
			}
		}
		foreach (NotaFiscalNotaReferenciada chavesNotasReferenciada in notaFiscalNotasFiscais.ChavesNotasReferenciadas)
		{
			if (!string.IsNullOrWhiteSpace(chavesNotasReferenciada.NotaReferenciada) && chavesNotasReferenciada.NotaReferenciada.Trim().Length == 44)
			{
				chavesNotasReferenciada.CodigoEmpresa = notaFiscalNotasFiscais.CodigoEmpresa;
				chavesNotasReferenciada.CodigoSerieNF = notaFiscalNotasFiscais.CodigoSerieNF;
				chavesNotasReferenciada.NumeroNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
				SalvarNotaFiscalNotaReferenciada(chavesNotasReferenciada);
			}
		}
		return notaFiscalNotasFiscais.Id;
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalNotasFiscais(NotaFiscalNotasFiscais notaFiscalNotasFiscais, Hashtable camposAlterados)
	{
		if (notaFiscalNotasFiscais.Entidade.RazaoSocialNF != null)
		{
			notaFiscalNotasFiscais.RazaoSocialDestinatario = notaFiscalNotasFiscais.Entidade.RazaoSocialNF;
		}
		int result = _notaFiscalNotasFiscaisDao.AlterarNotaFiscalNotasFiscais((MapTableNotaFiscalNotasFiscais)notaFiscalNotasFiscais.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscais.MarcarExistente();
		SalvarItensNotaFiscal(notaFiscalNotasFiscais);
		if (notaFiscalNotasFiscais.Fatura != null && notaFiscalNotasFiscais.Fatura.Count > 0)
		{
			_notaFiscalFaturaDao.ExcluirNotaFiscalFatura(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.NumeroNotaFiscal, notaFiscalNotasFiscais.CodigoSerieNF);
			char c = 'A';
			foreach (NotaFiscalFatura item in notaFiscalNotasFiscais.Fatura)
			{
				if (!notaFiscalNotasFiscais.IsBloquearRecalculoFatura || string.IsNullOrWhiteSpace(item.CodigoFatura))
				{
					item.CodigoFatura = $"{notaFiscalNotasFiscais.NumeroNotaFiscal:00000000}-{c}";
				}
				item.CodigoNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
				item.CodigoSerieNotaFiscal = notaFiscalNotasFiscais.CodigoSerieNF;
				InserirNotaFiscalFatura(item);
				c = (char)(c + 1);
			}
		}
		foreach (NotaFiscalNotaReferenciada chavesNotasReferenciada in notaFiscalNotasFiscais.ChavesNotasReferenciadas)
		{
			if (!string.IsNullOrWhiteSpace(chavesNotasReferenciada.NotaReferenciada) && chavesNotasReferenciada.NotaReferenciada.Trim().Length == 44)
			{
				chavesNotasReferenciada.CodigoEmpresa = notaFiscalNotasFiscais.CodigoEmpresa;
				chavesNotasReferenciada.CodigoSerieNF = notaFiscalNotasFiscais.CodigoSerieNF;
				chavesNotasReferenciada.NumeroNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
				SalvarNotaFiscalNotaReferenciada(chavesNotasReferenciada);
			}
		}
		return result;
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalNotasFiscaisCabecalho(NotaFiscalNotasFiscais notaFiscalNotasFiscais, Hashtable camposAlterados)
	{
		if (notaFiscalNotasFiscais.Entidade.RazaoSocialNF != null)
		{
			notaFiscalNotasFiscais.RazaoSocialDestinatario = notaFiscalNotasFiscais.Entidade.RazaoSocialNF;
		}
		int result = _notaFiscalNotasFiscaisDao.AlterarNotaFiscalNotasFiscais((MapTableNotaFiscalNotasFiscais)notaFiscalNotasFiscais.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscais.MarcarExistente();
		return result;
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalNotasFiscais2(NotaFiscalNotasFiscais notaFiscalNotasFiscais, Hashtable camposAlterados)
	{
		int result = _notaFiscalNotasFiscaisDao.AlterarNotaFiscalNotasFiscais((MapTableNotaFiscalNotasFiscais)notaFiscalNotasFiscais.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscais.MarcarExistente();
		return result;
	}

	private static bool VerificarDanfeDisponivel(NotaFiscalNotasFiscais nf, SituacaoNFe situacao)
	{
		bool flag = false;
		switch (situacao)
		{
		case SituacaoNFe.AguardandoProcLote:
		case SituacaoNFe.EmErro:
		case SituacaoNFe.AguardandoProcLoteContingencia:
		case SituacaoNFe.EmErroContingencia:
		{
			List<RetornoLote> list = GerenciaNFe4.ConsultarLote(nf.CodigoLote, nf.CodigoEmpresa);
			if (list != null && list.Count > 0)
			{
				foreach (RetornoLote item in list)
				{
					if (!(item.Chave == nf.ChaveNfe))
					{
						continue;
					}
					nf.ProtocoloNfe = item.Protocolo ?? string.Empty;
					if (item.Codigo == 302)
					{
						nf.SituacaoNfe = SituacaoNFe.Denegada.ToString();
						flag = false;
					}
					else
					{
						flag = !string.IsNullOrEmpty(nf.ProtocoloNfe);
						if (situacao == SituacaoNFe.AguardandoProcLote || situacao == SituacaoNFe.EmErro)
						{
							nf.SituacaoNfe = (flag ? SituacaoNFe.Sucesso.ToString() : SituacaoNFe.EmErro.ToString());
						}
						else
						{
							nf.SituacaoNfe = (flag ? SituacaoNFe.SucessoContingencia.ToString() : SituacaoNFe.EmErroContingencia.ToString());
						}
					}
					AlterarNotaFiscalNotasFiscaisCabecalho(nf, nf.PropriedadesModificadas);
					if (!flag)
					{
						if (item.Codigo == 302)
						{
							nf.SituacaoNfe = SituacaoNFe.Denegada.ToString();
							AlterarNotaFiscalNotasFiscais(nf, nf.PropriedadesModificadas);
							MaxWaitDialog.FecharMensagem();
							XtraMessageBox.Show($"Nota Fiscal {item.Chave}\nErro:({item.Codigo}) {item.Motivo}", "Nota Fiscal Em Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else if (item.Codigo == 204)
						{
							nf.SituacaoNfe = SituacaoNFe.AguardandoProcLote.ToString();
							string codigoLote = item.Motivo.Substring(item.Motivo.Length - 16, 15);
							nf.CodigoLote = codigoLote;
							AlterarNotaFiscalNotasFiscais(nf, nf.PropriedadesModificadas);
							flag = VerificarDanfeDisponivel(nf, (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe));
						}
						else if (item.Codigo == 539)
						{
							nf.SituacaoNfe = SituacaoNFe.AguardandoProcLote.ToString();
							string chaveNfe = item.Motivo.Substring(item.Motivo.Length - 67, 44);
							string codigoLote2 = item.Motivo.Substring(item.Motivo.Length - 16, 15);
							nf.CodigoLote = codigoLote2;
							nf.ChaveNfe = chaveNfe;
							XtraMessageBox.Show(item.Motivo + "\r\nIremos tentar corrigir", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							AlterarNotaFiscalNotasFiscais(nf, nf.PropriedadesModificadas);
							GerarNFe4(nf);
						}
						else
						{
							MaxWaitDialog.FecharMensagem();
							XtraMessageBox.Show($"Nota Fiscal {item.Chave}\nErro:({item.Codigo}) {item.Motivo}", "Nota Fiscal Em Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						try
						{
							GerarTitulos(nf);
							AjustarControleNotaReajuste(nf);
							AtualizarPedidoVenda(nf);
						}
						catch
						{
							Sociedade emitente = nf.Emitente;
							EnviaEmail enviaEmail = new EnviaEmail(Destinatario: new string[1] { emitente.EmailControladoria }, isHtml: true, Remetente: emitente.Email, Assunto: "Erro ao Gerar Contas a Pagar NF:" + nf.NumeroNotaFiscal, Corpo: "NF" + nf.NumeroNotaFiscal, Servidor: emitente.Smtp, Usuario: emitente.SmtpUsuario, Senha: emitente.SmtpSenha, Porta: emitente.SmtpPorta, isSSL: emitente.IsSSL, ResponderPara: emitente.ReponderEmailPara);
							enviaEmail.EnviarThread();
						}
					}
				}
			}
			else
			{
				switch (situacao)
				{
				case SituacaoNFe.AguardandoProcLote:
					nf.SituacaoNfe = SituacaoNFe.EmErro.ToString();
					break;
				case SituacaoNFe.AguardandoProcLoteContingencia:
					nf.SituacaoNfe = SituacaoNFe.EmErroContingencia.ToString();
					break;
				}
				AlterarNotaFiscalNotasFiscais(nf, nf.PropriedadesModificadas);
				MaxWaitDialog.FecharMensagem();
				XtraMessageBox.Show("Nota Fiscal em Erro: Corrija o erro e envie novamento", "Nota Fiscal Em Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			break;
		}
		case SituacaoNFe.Sucesso:
		case SituacaoNFe.EmContingencia:
		case SituacaoNFe.SucessoContingencia:
			flag = true;
			break;
		case SituacaoNFe.Denegada:
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("NFe Denegada, sem valor fiscal", "NFe Denegada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			break;
		case SituacaoNFe.SistemaLegado:
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("NFe Sistema Legado, sem valor fiscal", "NFe Sistema Legado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			break;
		default:
			XtraMessageBox.Show("NFe não liberada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			break;
		}
		situacao = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
		return flag;
	}

	private static void AtualizarPedidoVenda(NotaFiscalNotasFiscais nf)
	{
		bool flag = false;
		IList<FichaExpedicao> list = ModuloExpedicao.ObterTodosFichaExpedicao(nf.NumeroNotaFiscal);
		if (list != null)
		{
			foreach (FichaExpedicao item in list)
			{
				if (!item.IsReagruparFaturamento)
				{
					continue;
				}
				flag = true;
				foreach (FichaExpedicaoItem itemFe in item.Itens)
				{
					itemFe.QuantidadeFaturada = itemFe.QuantidadeEntregue;
					ModuloExpedicao.SalvarFichaExpedicaoItem(itemFe);
					if (itemFe.PedidoVendaItemRef == null)
					{
						continue;
					}
					PedidoVendaItemGPS pedidoVendaItemRef = itemFe.PedidoVendaItemRef;
					pedidoVendaItemRef.QuantidadeFaturada += (int)itemFe.QuantidadeEntregue;
					if (pedidoVendaItemRef.Cadencias != null)
					{
						int num = (int)itemFe.QuantidadeEntregue;
						if (itemFe.CodigoCadencia > 0)
						{
							PedidoVendaItemCadenciaGPS pedidoVendaItemCadenciaGPS = pedidoVendaItemRef.Cadencias.Where((PedidoVendaItemCadenciaGPS c) => c.Id == itemFe.CodigoCadencia).FirstOrDefault();
							if (pedidoVendaItemCadenciaGPS != null)
							{
								num = AjustarCadencia(num, pedidoVendaItemCadenciaGPS);
							}
						}
						if (num > 0)
						{
							List<PedidoVendaItemCadenciaGPS> list2 = (from c in pedidoVendaItemRef.Cadencias
								where c.QuantidadeFaltaFaturar > 0 && c.QuantidadeEntregue > 0 && c.QuantidadeFaturada < c.QuantidadeEntregue
								orderby c.DataEntrega
								select c).ToList();
							foreach (PedidoVendaItemCadenciaGPS item2 in list2)
							{
								num = AjustarCadencia(num, item2);
							}
						}
					}
					ModuloVendasGPS.SalvarPedidoVendaItem(pedidoVendaItemRef);
				}
				PedidoVendaGPS pedidoVenda = ModuloVendasGPS.ObterPedidoVenda(item.CodigoProjeto);
				ModuloVendasGPS.SalvarPedidoVenda(pedidoVenda);
			}
		}
		if (flag)
		{
			return;
		}
		foreach (NotaFiscalNotasFiscaisItens iten in nf.Itens)
		{
			if (iten.CodigoFichaExpedicao <= 0 || iten.FichaExpedicaoItemRef == null)
			{
				continue;
			}
			FichaExpedicaoItem itemFe2 = iten.FichaExpedicaoItemRef;
			itemFe2.QuantidadeFaturada = itemFe2.QuantidadeEntregue;
			ModuloExpedicao.SalvarFichaExpedicaoItem(itemFe2);
			if (itemFe2.PedidoVendaItemRef == null)
			{
				continue;
			}
			PedidoVendaItemGPS pedidoVendaItemRef2 = itemFe2.PedidoVendaItemRef;
			pedidoVendaItemRef2.QuantidadeFaturada += (int)itemFe2.QuantidadeEntregue;
			if (pedidoVendaItemRef2.Cadencias != null)
			{
				int num2 = (int)itemFe2.QuantidadeEntregue;
				if (itemFe2.CodigoCadencia > 0)
				{
					PedidoVendaItemCadenciaGPS pedidoVendaItemCadenciaGPS2 = pedidoVendaItemRef2.Cadencias.Where((PedidoVendaItemCadenciaGPS c) => c.Id == itemFe2.CodigoCadencia).FirstOrDefault();
					if (pedidoVendaItemCadenciaGPS2 != null)
					{
						num2 = AjustarCadencia(iten, num2, pedidoVendaItemCadenciaGPS2);
					}
				}
				if (num2 > 0)
				{
					List<PedidoVendaItemCadenciaGPS> list3 = (from c in pedidoVendaItemRef2.Cadencias
						where c.QuantidadeFaltaFaturar > 0 && c.QuantidadeEntregue > 0 && c.QuantidadeFaturada < c.QuantidadeEntregue
						orderby c.DataEntrega
						select c).ToList();
					foreach (PedidoVendaItemCadenciaGPS item3 in list3)
					{
						num2 = AjustarCadencia(iten, num2, item3);
					}
				}
			}
			ModuloVendasGPS.SalvarPedidoVendaItem(pedidoVendaItemRef2);
			PedidoVendaGPS pedidoVenda2 = ModuloVendasGPS.ObterPedidoVenda(pedidoVendaItemRef2.CodigoPedido);
			ModuloVendasGPS.SalvarPedidoVenda(pedidoVenda2);
		}
	}

	private static int AjustarCadencia(NotaFiscalNotasFiscaisItens item, int qde, PedidoVendaItemCadenciaGPS itemCad)
	{
		if (itemCad.QuantidadeFaturada < itemCad.QuantidadeEntregue && (itemCad.CodigoFichaExpedicao == 0 || (itemCad.CodigoFichaExpedicao == item.CodigoFichaExpedicao && itemCad.CodigoFichaExpedicaoItem == item.CodigoFichaExpedicaoItem)) && qde > 0)
		{
			int num = itemCad.QuantidadeEntregue - itemCad.QuantidadeFaturada;
			if (num <= qde)
			{
				itemCad.QuantidadeFaturada = itemCad.QuantidadeEntregue;
				qde -= num;
			}
			else
			{
				itemCad.QuantidadeFaturada += num;
				qde = 0;
			}
		}
		return qde;
	}

	private static int AjustarCadencia(int qde, PedidoVendaItemCadenciaGPS itemCad)
	{
		if (itemCad.QuantidadeFaturada < itemCad.QuantidadeEntregue && qde > 0)
		{
			int num = itemCad.QuantidadeEntregue - itemCad.QuantidadeFaturada;
			if (num <= qde)
			{
				itemCad.QuantidadeFaturada = itemCad.QuantidadeEntregue;
				qde -= num;
			}
			else
			{
				itemCad.QuantidadeFaturada += num;
				qde = 0;
			}
		}
		return qde;
	}

	private static void AjustarControleNotaReajuste(NotaFiscalNotasFiscais nf)
	{
		if (nf.CodigoControleReajuste <= 0)
		{
			return;
		}
		foreach (NotaFiscalNotasFiscaisItens iten in nf.Itens)
		{
			NotaFiscalRetroativaControle notaFiscalRetroativaControle = ModuloNFiscal.ObterNotaFiscalRetroativaControle(iten.CodigoControleReajuste);
			if (notaFiscalRetroativaControle != null)
			{
				notaFiscalRetroativaControle.ChaveNotaFiscalComplementar = nf.ChaveNfe;
				notaFiscalRetroativaControle.DataAprovacaoSefaz = nf.DataEnvioNFE;
				notaFiscalRetroativaControle.Status = nf.SituacaoNfe;
				if (notaFiscalRetroativaControle.ValorDiferencaUnitario != iten.ValorUnitario)
				{
					notaFiscalRetroativaControle.ValorDiferencaUnitario = iten.ValorUnitario;
					notaFiscalRetroativaControle.ValorAtual = notaFiscalRetroativaControle.ValorOriginal + notaFiscalRetroativaControle.ValorDiferencaUnitario;
				}
				ModuloNFiscal.SalvarNotaFiscalRetroativaControle(notaFiscalRetroativaControle);
			}
		}
	}

	public static void ExcluirControleNotaReajuste(NotaFiscalNotasFiscais nf)
	{
		if (nf.CodigoControleReajuste <= 0)
		{
			return;
		}
		try
		{
			if (nf.TipoNotaEnum != EnumFinalidadeNotaFiscal.Complementar)
			{
				return;
			}
			IList<NotaFiscalRetroativaControle> list = ModuloNFiscal.ObterTodosNotaFiscalRetroativaControle(nf.CodigoControleReajuste);
			foreach (NotaFiscalRetroativaControle item in list)
			{
				item.IsExcluir = true;
				ModuloNFiscal.SalvarNotaFiscalRetroativaControle(item);
			}
			NotaFiscalNotasFiscais notaFiscalNotasFiscais = ObterNotaFiscalNotasFiscais(nf.NotaReferenciada);
			if (notaFiscalNotasFiscais != null && notaFiscalNotasFiscais.CodigoControleReajuste > 0)
			{
				notaFiscalNotasFiscais.CodigoControleReajuste = 0;
				AlterarNotaFiscalNotasFiscais2(notaFiscalNotasFiscais, notaFiscalNotasFiscais.PropriedadesModificadas);
			}
			if (nf != null && nf.CodigoControleReajuste > 0)
			{
				nf.CodigoControleReajuste = 0;
				AlterarNotaFiscalNotasFiscais2(nf, nf.PropriedadesModificadas);
			}
		}
		catch
		{
		}
	}

	public static bool EstaNotaJaExiste(int codigoEmpresa, int serie, int numeroNotaFiscal)
	{
		return _notaFiscalNotasFiscaisDao.ChecarSeNotaExiste(codigoEmpresa, numeroNotaFiscal, serie);
	}

	public static int ProximoNumeroNotaFiscal(int codigoEmpresa, int serie)
	{
		return _notaFiscalNotasFiscaisDao.ObterUltimaNota(codigoEmpresa, serie) + 1;
	}

	public static void GerarNFe4(NotaFiscalNotasFiscais nf)
	{
		MaxWaitDialog.MostrarMensagem("Informação", "Enviando Nota para o Sefaz!!!!");
		switch ((SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe))
		{
		case SituacaoNFe.NaoEnviada:
		case SituacaoNFe.EmErro:
		case SituacaoNFe.EmContingencia:
		case SituacaoNFe.EmErroContingencia:
			try
			{
				SubstituirTagsTextoLegal(nf);
				if (nf.Entidade != null && nf.Entidade.IsBloqueado)
				{
					MaxCaixaMensagem.ShowErroOK("Este cliente encontra-se bloqueado, operação não permitida.");
					return;
				}
				if (nf.Entidade.ValorDisponivelCredito < nf.ValorTotalFatura)
				{
					MaxCaixaMensagem.ShowErroOK("Este cliente não possui limite de crédito disponível.");
					return;
				}
				RetornoNFe retornoNFe = GerenciaNFe4.GerarNFe(ref nf);
				if (nf.SituacaoNfe == "Sucesso" || nf.SituacaoNfe == "SucessoContingencia")
				{
					IDictionary<int, string> dictionary = new Dictionary<int, string>();
					foreach (NotaFiscalNotasFiscaisItens iten in nf.Itens)
					{
						if (iten.CodigoFichaExpedicao > 0 && !dictionary.ContainsKey(iten.CodigoFichaExpedicao))
						{
							dictionary.Add(iten.CodigoFichaExpedicao, null);
						}
					}
					foreach (KeyValuePair<int, string> item in dictionary)
					{
						FichaExpedicao fichaExpedicao = ModuloExpedicao.ObterFichaExpedicao(item.Key);
						if (fichaExpedicao == null)
						{
							continue;
						}
						bool flag = true;
						foreach (FichaExpedicaoItem iten2 in fichaExpedicao.Itens)
						{
							if (iten2.CodigoNotaFiscal <= 0)
							{
								flag = false;
							}
						}
						if (flag)
						{
							fichaExpedicao.StatusFichaExpedicao = EnumStatusFichaExpedicao.Faturado;
							ModuloExpedicao.SalvarFichaExpedicao(fichaExpedicao);
						}
					}
				}
				MaxWaitDialog.FecharMensagem();
				if (nf.SituacaoNfe == "Sucesso" || nf.SituacaoNfe == "AguardandoProcLote" || nf.SituacaoNfe == "SucessoContingencia" || nf.SituacaoNfe == "AguardandoProcLoteContingencia")
				{
					MaxWaitDialog.MostrarMensagem("Consultando o Sefaz");
					Thread.Sleep(3000);
					if (ImprimirDanfe3(nf))
					{
						EnviarNotas(nf);
					}
				}
			}
			catch (Exception ex)
			{
				MaxWaitDialog.FecharMensagem();
				if (ex.Message == "Falha na solicitação com status HTTP 403: Forbidden.")
				{
					XtraMessageBox.Show("Houve uma falha com o certificado digital\r\nO Certificado Definido no Sistema não é capaz de validar a comunicação com o Sefaz.", "Erro de Certificado Digital", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					XtraMessageBox.Show(ex.Message, "Erro no envio da NFe", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			break;
		case SituacaoNFe.EmDuplicidade:
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("Contate o Administrador do Sistema", "Nota Em Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			break;
		case SituacaoNFe.SistemaLegado:
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("Contate o Administrador do Sistema", "Nota Sistema Legado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			break;
		}
		MaxWaitDialog.FecharMensagem();
	}

	public static SituacaoServicoNFe VerificarSituacaoSefaz(int CodigoEmpresa)
	{
		return GerenciaNFe4.VerificarSituacaoSefaz(CodigoEmpresa);
	}

	public static bool ImprimirDanfe3(NotaFiscalNotasFiscais nf)
	{
		XtraReport val = ImprimirDanfeReport3(nf);
		if (val != null)
		{
			XtraReportPreviewExtensions.ShowPreview((IReport)(object)val);
			return true;
		}
		return false;
	}

	public static XtraReport ImprimirDanfeReport(NotaFiscalNotasFiscais nf)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		XtraReport val = new XtraReport();
		MaxWaitDialog.MostrarMensagem("Informação", "Gerando DANFE!!!!");
		SituacaoNFe situacao = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
		bool flag = false;
		if (VerificarDanfeDisponivel(nf, situacao))
		{
			SubstituirTagsTextoLegal(nf);
			rptDanfe rptDanfe3 = new rptDanfe(nf);
			if (Directory.Exists("Relatorios"))
			{
				string text = $"Relatorios\\{((XtraReport)rptDanfe3).DisplayName}.repx";
				if (File.Exists(text))
				{
					object dataSource = ((XtraReportBase)rptDanfe3).DataSource;
					((XtraReport)rptDanfe3).LoadLayout(text);
					((XtraReportBase)rptDanfe3).DataSource = dataSource;
					((XtraReportBase)rptDanfe3).FillDataSource();
				}
			}
			try
			{
				if (!Directory.Exists(DirDanfe))
				{
					Directory.CreateDirectory(DirDanfe);
				}
				string text2 = $"{DirDanfe}\\{nf.ChaveNfe}.pdf";
				((XtraReport)rptDanfe3).ExportToPdf(text2);
			}
			finally
			{
				MaxWaitDialog.FecharMensagem();
				val = (XtraReport)(object)rptDanfe3;
			}
		}
		else
		{
			val = null;
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("DANFE ainda não disponível!", "DANFE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return val;
	}

	public static XtraReport ImprimirDanfeReport3(NotaFiscalNotasFiscais nf)
	{
		return ImprimirDanfeReport3(nf, visualizar: false);
	}

	public static XtraReport ImprimirDanfeReport3(NotaFiscalNotasFiscais nf, bool visualizar)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		XtraReport val = new XtraReport();
		MaxWaitDialog.MostrarMensagem("Informação", "Verificando Status da Nota Fiscal");
		SituacaoNFe situacao = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
		bool flag = false;
		if (!visualizar)
		{
			flag = VerificarDanfeDisponivel(nf, situacao);
		}
		if (flag)
		{
			MaxWaitDialog.MostrarMensagem("Informação", "Gerando DANFE!!!!");
			SubstituirTagsTextoLegal(nf);
			XtraReport val2 = ProcessoImpressaoDanfe(nf);
			val = val2;
		}
		else if (visualizar)
		{
			MaxWaitDialog.MostrarMensagem("Informação", "Pré Visualização da DANFE!!!!");
			XtraReport val3 = ProcessoVisualizacaoDanfe(nf);
			val = val3;
		}
		else
		{
			val = null;
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("DANFE ainda não disponível!", "DANFE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return val;
	}

	public static XtraReport ImprimirDanfeContingencia(NotaFiscalNotasFiscais nf)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		if (nf.SituacaoNfe == "SistemaLegado")
		{
			return null;
		}
		if (nf.Entidade != null && nf.Entidade.IsBloqueado)
		{
			MaxCaixaMensagem.ShowErroOK("Este cliente encontra-se bloqueado, operação não permitida.");
			return null;
		}
		MaxWaitDialog.MostrarMensagem("Informação", "Gerando DANFE CONTINGÊNCIA!!!!");
		XtraReport val = new XtraReport();
		SituacaoNFe situacaoNFe = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
		if (situacaoNFe == SituacaoNFe.AguardandoProcLote || situacaoNFe == SituacaoNFe.EmErro || situacaoNFe == SituacaoNFe.AguardandoProcLoteContingencia || situacaoNFe == SituacaoNFe.EmErroContingencia)
		{
			VerificarDanfeDisponivel(nf, situacaoNFe);
		}
		if (situacaoNFe == SituacaoNFe.Sucesso || situacaoNFe == SituacaoNFe.SucessoContingencia)
		{
			SubstituirTagsTextoLegal(nf);
			val = ImprimirDanfeReport3(nf);
			MaxWaitDialog.FecharMensagem();
		}
		else if (situacaoNFe != SituacaoNFe.Cancelada && situacaoNFe != SituacaoNFe.Sucesso)
		{
			nf.SituacaoNfe = SituacaoNFe.EmContingencia.ToString();
			nf.ProtocoloNfe = "Em Contigência";
			nf.ChaveNfe = GerenciaNFe4.GerarChaveNFe(nf, TipoEmissao.Normal);
			AlterarNotaFiscalNotasFiscais(nf, nf.PropriedadesModificadas);
			XtraReport val2 = ProcessoImpressaoDanfe(nf);
			val = val2;
		}
		else
		{
			val = null;
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("DANFE CANCELADA - Impossível imprimir DANFE", "DANFE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return val;
	}

	private static XtraReport ProcessoImpressaoDanfe(NotaFiscalNotasFiscais nf)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		SubstituirTagsTextoLegal(nf);
		int num = 0;
		XtraReport val = new XtraReport();
		try
		{
			Parametros parametros = ModuloParametros.ObterParametros("Faturamento", "DanfePaisagem");
			num = parametros.Valor;
		}
		catch
		{
		}
		switch (num)
		{
		case 0:
			val = (XtraReport)(object)new rptDanfe2(nf);
			break;
		case 1:
			val = (XtraReport)(object)new rptDanfePaisagem(nf);
			break;
		}
		if (Directory.Exists("Relatorios"))
		{
			string text = $"Relatorios\\{val.DisplayName}.repx";
			if (File.Exists(text))
			{
				val.LoadLayout(text);
			}
		}
		try
		{
			if (!Directory.Exists(DirDanfe))
			{
				Directory.CreateDirectory(DirDanfe);
			}
			string text2 = $"{DirDanfe}\\{nf.ChaveNfe}.pdf";
			val.ExportToPdf(text2);
		}
		finally
		{
			MaxWaitDialog.FecharMensagem();
		}
		return val;
	}

	private static XtraReport ProcessoVisualizacaoDanfe(NotaFiscalNotasFiscais nf)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		SubstituirTagsTextoLegal(nf);
		int num = 0;
		XtraReport val = new XtraReport();
		try
		{
			Parametros parametros = ModuloParametros.ObterParametros("Faturamento", "DanfePaisagem");
			num = parametros.Valor;
		}
		catch
		{
		}
		switch (num)
		{
		case 0:
			val = (XtraReport)(object)new rptDanfe2(nf, Visualizar: true);
			break;
		case 1:
			val = (XtraReport)(object)new rptDanfePaisagem(nf, Visualizar: true);
			break;
		}
		if (Directory.Exists("Relatorios"))
		{
			string text = $"Relatorios\\{val.DisplayName}.repx";
			if (File.Exists(text))
			{
				val.LoadLayout(text);
			}
		}
		MaxWaitDialog.FecharMensagem();
		return val;
	}

	public static void SalvarNotas(IList<NotaFiscalNotasFiscais> nfs, string path)
	{
		bool flag = true;
		foreach (NotaFiscalNotasFiscais nf in nfs)
		{
			MaxWaitDialog.MostrarMensagem("Informação", "Salvando DANFE e XML !!!!");
			SituacaoNFe situacaoNFe = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
			bool flag2 = false;
			SituacaoNFe situacaoNFe2 = situacaoNFe;
			SituacaoNFe situacaoNFe3 = situacaoNFe2;
			if (situacaoNFe3 == SituacaoNFe.Sucesso || situacaoNFe3 == SituacaoNFe.EmContingencia || situacaoNFe3 == SituacaoNFe.SucessoContingencia)
			{
				flag2 = true;
			}
			else
			{
				MaxWaitDialog.FecharMensagem();
				XtraMessageBox.Show("NFe ainda não disponível!", "NFe não enviada", MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
			if (flag2)
			{
				string text = $"{DirDanfe}\\{nf.ChaveNfe}.pdf";
				string text2 = string.Format("{0}\\{1}\\{2}-nfe.xml", ConfigNFe.Instancia.DirNFeAutorizadasSemDirData, nf.DataEnvioNFE.ToString("yyyyMMdd"), nf.ChaveNfe);
				if (!File.Exists(text2))
				{
					text2 = $"{ConfigNFe.Instancia.DirNFeAutorizadasSemDirData}\\{nf.ChaveNfe}-nfe.xml";
				}
				if (File.Exists(text))
				{
					File.Copy(text, $"{path}\\{nf.ChaveNfe}.pdf");
				}
				else
				{
					flag = false;
				}
				if (File.Exists(text2))
				{
					File.Copy(text2, $"{path}\\{nf.ChaveNfe}-nfe.xml");
				}
				else
				{
					flag = false;
				}
			}
		}
		MaxWaitDialog.FecharMensagem();
		if (flag)
		{
			XtraMessageBox.Show("Arquivos Salvo", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			XtraMessageBox.Show("Alguns arquivos não foram encontrados !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	public static void EnviarNotas(NotaFiscalNotasFiscais nf)
	{
		if (nf.Entidade != null && nf.Entidade.IsBloqueado)
		{
			MaxCaixaMensagem.ShowErroOK("Este cliente encontra-se bloqueado, operação não permitida.");
			return;
		}
		MaxWaitDialog.MostrarMensagem("Informação", "Enviando DANFE e XML por Email !!!!");
		SituacaoNFe situacaoNFe = (SituacaoNFe)Enum.Parse(typeof(SituacaoNFe), nf.SituacaoNfe);
		bool flag = false;
		SituacaoNFe situacaoNFe2 = situacaoNFe;
		SituacaoNFe situacaoNFe3 = situacaoNFe2;
		if (situacaoNFe3 == SituacaoNFe.Sucesso || situacaoNFe3 == SituacaoNFe.EmContingencia || situacaoNFe3 == SituacaoNFe.SucessoContingencia)
		{
			flag = true;
		}
		else
		{
			MaxWaitDialog.FecharMensagem();
			XtraMessageBox.Show("NFe ainda não disponível!", "NFe não enviada", MessageBoxButtons.OK, MessageBoxIcon.Question);
		}
		if (flag)
		{
			string text = $"{DirDanfe}\\{nf.ChaveNfe}.pdf";
			string text2 = string.Format("{0}\\{1}\\{2}-nfe.xml", ConfigNFe.Instancia.DirNFeAutorizadasSemDirData, nf.DataEnvioNFE.ToString("yyyyMMdd"), nf.ChaveNfe);
			if (!File.Exists(text2))
			{
				text2 = $"{ConfigNFe.Instancia.DirNFeAutorizadasSemDirData}\\{nf.ChaveNfe}-nfe.xml";
			}
			string email = nf.Entidade.Email;
			string[] array = new string[5];
			Sociedade emitente = nf.Emitente;
			string empty = string.Empty;
			empty = (string.IsNullOrEmpty(nf.Entidade.EmailNotaFiscal) ? nf.Entidade.Email : nf.Entidade.EmailNotaFiscal);
			array[0] = empty;
			array[1] = emitente.EmailNfe;
			if (nf.Fatura != null && nf.Fatura.Count > 0)
			{
				array[2] = emitente.EmailFinanceiro;
			}
			else
			{
				array[2] = string.Empty;
			}
			array[3] = emitente.EmailContabilidade;
			if (nf.Transportadora != null && !string.IsNullOrWhiteSpace(nf.Transportadora.EmailNF))
			{
				array[4] = nf.Transportadora.EmailNF;
			}
			string[] array2 = new string[20];
			try
			{
				array2[0] = text;
			}
			catch
			{
			}
			try
			{
				array2[1] = text2;
			}
			catch
			{
			}
			try
			{
				string[] array3 = ModuloParametros.GerarAnexosDocumentoPadrao(EnumDocumentosPadrao.NotaFiscal);
				if (array3 != null && array3.Length != 0)
				{
					int num = 2;
					string[] array4 = array3;
					foreach (string text3 in array4)
					{
						array2[num] = text3;
						num++;
					}
				}
			}
			catch
			{
			}
			string texto = $"Nota Fiscal: {nf.NumeroNotaFiscal} - {nf.Emitente.RazaoSocial}";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Prezado Cliente: ").AppendLine();
			stringBuilder.AppendLine(" ");
			stringBuilder.AppendLine("Através deste email você está recebendo em anexo a Danfe e o Arquivo XML").AppendLine();
			stringBuilder.AppendLine("Emitente: ");
			stringBuilder.AppendLine(nf.Emitente.RazaoSocial);
			stringBuilder.AppendLine("Destinatário: ");
			stringBuilder.AppendLine(nf.Entidade.RazaoSocial);
			stringBuilder.AppendLine("Nota Fiscal No.: ");
			stringBuilder.AppendLine(nf.NumeroNotaFiscal.ToString());
			stringBuilder.AppendLine("Chave Eletronica: ");
			stringBuilder.AppendLine(nf.ChaveNfe).AppendLine().AppendLine()
				.AppendLine();
			if (nf.Transportadora != null)
			{
				stringBuilder.AppendLine("Transportadora: ");
				stringBuilder.AppendLine(nf.Transportadora.RazaoSocial);
			}
			string texto2 = stringBuilder.ToString();
			Emails emails = ModuloParametros.ObterEmailsFuncaoSistema(EnumFuncoesSistemaEmail.EnvioNotaFiscal);
			if (emails != null && emails.Email.Length > 0)
			{
				texto = emails.TituloEmail;
				texto2 = emails.Email;
			}
			texto2 = SubstituirTagsNotaFiscal(texto2, nf);
			texto = SubstituirTagsNotaFiscal(texto, nf);
			if (ConfigNFe.Ambiente == TipoAmbiente.Homologacao)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.AppendLine();
				stringBuilder2.AppendLine("Nota Emitida sobre o site de Homologação. Sem valor fiscal!!!");
				texto2 += stringBuilder2.ToString();
				array[0] = string.Empty;
				array[1] = string.Empty;
				array[2] = string.Empty;
				array[3] = string.Empty;
				array[4] = string.Empty;
			}
			EnviaEmail enviaEmail = new EnviaEmail(isHtml: false, emitente.EmailNfe, array, texto, texto2.ToString(), emitente.Smtp, emitente.SmtpUsuario, emitente.SmtpSenha, emitente.IsSSL, array2, emitente.SmtpPorta, emitente.ReponderEmailPara);
			try
			{
				MaxWaitDialog.FecharMensagem();
				enviaEmail.EnviarThread();
				XtraMessageBox.Show("Email enviado com sucesso!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
				MaxWaitDialog.FecharMensagem();
				XtraMessageBox.Show("Não foi possível enviar o email", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		MaxWaitDialog.FecharMensagem();
	}

	public static void EnviarCancelamentoNotas(NotaFiscalNotasFiscais nf)
	{
		MaxWaitDialog.MostrarMensagem("Informação", "Enviando Cancelamento por Email !!!!");
		string email = nf.Entidade.Email;
		string[] array = new string[4];
		Sociedade emitente = nf.Emitente;
		array[0] = nf.Entidade.EmailNotaFiscal;
		array[1] = emitente.EmailNfe;
		array[2] = emitente.EmailFinanceiro;
		array[3] = emitente.EmailContabilidade;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Prezado Cliente: ").AppendLine();
		stringBuilder.AppendLine(" ");
		stringBuilder.AppendLine("Através deste email você está recebendo AVISO DE CANCELAMENTO DE NOTA").AppendLine();
		stringBuilder.AppendLine("Emitente: ");
		stringBuilder.AppendLine(nf.Emitente.RazaoSocial);
		stringBuilder.AppendLine("Destinatário: ");
		stringBuilder.AppendLine(nf.Entidade.RazaoSocial);
		stringBuilder.AppendLine("Nota Fiscal No.: ");
		stringBuilder.AppendLine(nf.NumeroNotaFiscal.ToString());
		stringBuilder.AppendLine("Chave Eletronica: ");
		stringBuilder.AppendLine(nf.ChaveNfe);
		if (ConfigNFe.Ambiente == TipoAmbiente.Homologacao)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Nota Emitida sobre o site de Homologação. Sem valor fiscal!!!");
			array[0] = "fcesar@maxtek.com.br";
			array[1] = string.Empty;
			array[2] = string.Empty;
			array[3] = string.Empty;
		}
		string assunto = "CANCELAMENTO DA NOTA FISCAL: " + nf.NumeroNotaFiscal + " - " + nf.Emitente.RazaoSocial;
		EnviaEmail enviaEmail = new EnviaEmail(isHtml: false, emitente.EmailNfe, array, assunto, stringBuilder.ToString(), emitente.Smtp, emitente.SmtpUsuario, emitente.SmtpSenha, emitente.SmtpPorta, emitente.IsSSL, emitente.ReponderEmailPara);
		MaxWaitDialog.FecharMensagem();
		try
		{
			enviaEmail.EnviarThread();
			XtraMessageBox.Show("Email enviado com sucesso!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch
		{
			XtraMessageBox.Show("Não foi possível enviar o email", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	public static void EnviarCartaCorrecao(NotaFiscalNotasFiscais nf, NotasFiscaisEventos evento, string nomeArquivoXml)
	{
		MaxWaitDialog.MostrarMensagem("Informação", "Enviando Carta de Correção por Email !!!!");
		string email = nf.Entidade.Email;
		string[] array = new string[4];
		Sociedade emitente = nf.Emitente;
		array[0] = nf.Entidade.EmailNotaFiscal;
		array[1] = emitente.EmailNfe;
		array[2] = emitente.EmailFinanceiro;
		array[3] = emitente.EmailContabilidade;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Prezado Cliente: ").AppendLine();
		stringBuilder.AppendLine(" ");
		stringBuilder.AppendLine("Através deste email você está recebendo CARTA DE CORREÇÃO").AppendLine();
		stringBuilder.AppendLine("Emitente: ");
		stringBuilder.AppendLine(nf.Emitente.RazaoSocial);
		stringBuilder.AppendLine("Destinatário: ");
		stringBuilder.AppendLine(nf.Entidade.RazaoSocial);
		stringBuilder.AppendLine("Nota Fiscal No.: ");
		stringBuilder.AppendLine(nf.NumeroNotaFiscal.ToString());
		stringBuilder.AppendLine("Chave Eletronica: ");
		stringBuilder.AppendLine(nf.ChaveNfe);
		stringBuilder.AppendLine(" ");
		stringBuilder.AppendLine("Correção: ");
		stringBuilder.AppendLine(evento.Descricao);
		stringBuilder.AppendLine(" ");
		stringBuilder.AppendLine("Condição de Uso: ");
		stringBuilder.AppendLine("A Carta de Correção é disciplinada pelo § 1º-A do art. 7º do Convênio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularização de erro ocorrido na emissão de documento fiscal, desde que o erro não esteja relacionado com: I - as variáveis que determinam o valor do imposto tais como: base de cálculo, alíquota, diferença de preço, quantidade, valor da operação ou da prestação; II - a correção de dados cadastrais que implique mudança do remetente ou do destinatário; III - a data de emissão ou de saída.");
		if (ConfigNFe.Ambiente == TipoAmbiente.Homologacao)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Nota Emitida sobre o site de Homologação. Sem valor fiscal!!!");
			array[0] = "estudos@maxtek.com.br";
			array[1] = string.Empty;
			array[2] = string.Empty;
			array[3] = string.Empty;
		}
		string assunto = "CARTA DE CORREÇÃO DA NOTA FISCAL: " + nf.NumeroNotaFiscal + " - " + nf.Emitente.RazaoSocial;
		XtraReport val = (XtraReport)(object)new rptCartaCorrecao(evento);
		Stream stream = new MemoryStream();
		val.ExportToPdf(stream);
		stream.Seek(0L, SeekOrigin.Begin);
		Attachment attachment = new Attachment(stream, "Carta de Correção NF:" + nf.NumeroNotaFiscal, "application/pdf");
		Attachment attachment2 = new Attachment(nomeArquivoXml);
		EnviaEmail enviaEmail = new EnviaEmail(Anexo: new Attachment[2] { attachment, attachment2 }, isHtml: false, Remetente: emitente.EmailNfe, Destinatario: array, Assunto: assunto, Corpo: stringBuilder.ToString(), Servidor: emitente.Smtp, Usuario: emitente.SmtpUsuario, Senha: emitente.SmtpSenha, isSSL: emitente.IsSSL, Porta: emitente.SmtpPorta, ResponderPara: emitente.ReponderEmailPara);
		MaxWaitDialog.FecharMensagem();
		try
		{
			enviaEmail.EnviarThread();
			XtraMessageBox.Show("Email enviado com sucesso!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch
		{
			XtraMessageBox.Show("Não foi possível enviar o email", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	public static void ImprimirEtiquetas(NotaFiscalNotasFiscais nf)
	{
		ImprimirEtiquetas(nf, 0);
	}

	public static void ImprimirEtiquetas(NotaFiscalNotasFiscais nf, int tipoEtiqueta)
	{
		ImprimirEtiquetas(nf, 0, string.Empty);
	}

	public static void ImprimirEtiquetas(NotaFiscalNotasFiscais nf, int tipoEtiqueta, string nomeImpressora)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		bool flag = true;
		Sociedade emitente = nf.Emitente;
		EntidadeGPS entidade = nf.Entidade;
		IList<ClasseEtiquetaDispofix> list = new List<ClasseEtiquetaDispofix>();
		try
		{
			tipoEtiqueta = ModuloParametros.ObterParametros("Faturamento", "CodigoEtiquetaFaturamento").Valor;
			flag = ModuloParametros.ObterParametros("Faturamento", "DesabilitaEtiquetaSeparacao").Valor <= 0;
		}
		catch
		{
		}
		if (nf.Entidade.TipoEtiquetaFaturamento > 0)
		{
			tipoEtiqueta = nf.Entidade.TipoEtiquetaFaturamento;
		}
		switch (tipoEtiqueta)
		{
		case 100:
		{
			rptEtiqueta100NF rptEtiqueta100NF2 = new rptEtiqueta100NF();
			rptEtiqueta100NF2.NotaFiscal = nf;
			_qdeEtiquetas = (short)nf.QuantidadeVolumes;
			((XtraReport)rptEtiqueta100NF2).PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
			((XtraReport)(object)rptEtiqueta100NF2).ImprimirEtiqueta(nomeImpressora);
			break;
		}
		case 102:
		{
			int quantidadeVolumes = nf.QuantidadeVolumes;
			for (int i = 0; i < quantidadeVolumes; i++)
			{
				ClasseEtiquetaDispofix classeEtiquetaDispofix = new ClasseEtiquetaDispofix();
				classeEtiquetaDispofix.Cliente = nf.Entidade.RazaoSocial;
				classeEtiquetaDispofix.Emissão = nf.DataEnvioNFE.ToShortDateString();
				classeEtiquetaDispofix.NotaFiscal = nf.NumeroNotaFiscal.ToString();
				classeEtiquetaDispofix.NomeTransportadora = nf.Transportadora.RazaoSocial;
				if (nf.EntidadeEntrega != null)
				{
					classeEtiquetaDispofix.EndereçoEntrega = nf.EntidadeEntrega.EnderecoImpressao;
				}
				else
				{
					classeEtiquetaDispofix.EndereçoEntrega = nf.Entidade.EnderecoImpressao;
				}
				list.Add(classeEtiquetaDispofix);
			}
			break;
		}
		}
		foreach (NotaFiscalNotasFiscaisItens iten in nf.Itens)
		{
			ImprimirEtiquetasItem(iten, tipoEtiqueta, nomeImpressora);
			int num = 0;
			bool flag2 = false;
			if (iten.FichaExpedicaoItemRef != null && flag)
			{
				rptEtiquetaSeparacao value = new rptEtiquetaSeparacao();
				((XtraReport)(object)value).ImprimirEtiqueta(nomeImpressora);
			}
		}
	}

	public static void ImprimirEtiquetasItem(NotaFiscalNotasFiscaisItens nfi, int tipoEtiqueta, string nomeImpressora)
	{
		bool flag = true;
		Sociedade emitente = nfi.NotaFiscalRef.Emitente;
		EntidadeGPS entidade = nfi.NotaFiscalRef.Entidade;
		IList<ClasseEtiquetaDispofix> list = new List<ClasseEtiquetaDispofix>();
		try
		{
			tipoEtiqueta = ModuloParametros.ObterParametros("Faturamento", "CodigoEtiquetaFaturamento").Valor;
		}
		catch
		{
		}
		if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null && nfi.FichaExpedicaoItemRef.Tarifa.CodigoEtiqueta > 0)
		{
			tipoEtiqueta = nfi.FichaExpedicaoItemRef.Tarifa.CodigoEtiqueta;
		}
		else if (entidade.TipoEtiquetaFaturamento > 0)
		{
			tipoEtiqueta = entidade.TipoEtiquetaFaturamento;
		}
		int num = 0;
		bool flag2 = false;
		if (nfi.FichaExpedicaoItemRef == null)
		{
			return;
		}
		switch (tipoEtiqueta)
		{
		case 0:
		{
			rptEtiqueta rptEtiqueta335 = new rptEtiqueta();
			rptEtiqueta335.ItemNotaFiscal = nfi;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			rptEtiqueta335.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiqueta335).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiqueta rptEtiqueta336 = new rptEtiqueta();
				rptEtiqueta336.ItemNotaFiscal = nfi;
				rptEtiqueta336.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiqueta336).ImprimirEtiqueta(nomeImpressora, 1);
				_qdeEtiquetas = 1;
			}
			break;
		}
		case 1:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag8 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int num20 = 0; num20 < num; num20++)
			{
				rptEtiquetaAllevard rptEtiquetaAllevard2 = new rptEtiquetaAllevard();
				if (flag8 && num20 == 0)
				{
					rptEtiquetaAllevard2.Quantidade = (int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				}
				else
				{
					rptEtiquetaAllevard2.Quantidade = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				}
				rptEtiquetaAllevard2.QuandidadeEmbalagem = num;
				rptEtiquetaAllevard2.ItemNotaFiscal = nfi;
				rptEtiquetaAllevard2.SequenciaEmbalagem = num20 + 1;
				((XtraReport)rptEtiquetaAllevard2).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaAllevard2).ImprimirEtiqueta(nomeImpressora);
				((Component)(object)rptEtiquetaAllevard2).Dispose();
			}
			break;
		}
		case 2:
		{
			rptEtiquetaTRW rptEtiquetaTRW2 = new rptEtiquetaTRW();
			rptEtiquetaTRW2.ItemNotaFiscal = nfi;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			rptEtiquetaTRW2.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiquetaTRW2).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiquetaTRW rptEtiquetaTRW3 = new rptEtiquetaTRW();
				rptEtiquetaTRW3.ItemNotaFiscal = nfi;
				rptEtiquetaTRW3.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiquetaTRW3).ImprimirEtiqueta(nomeImpressora);
			}
			break;
		}
		case 3:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag6 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int num13 = 0; num13 < num; num13++)
			{
				rptEtiquetaQuadrant rptEtiquetaQuadrant2 = new rptEtiquetaQuadrant();
				if (flag6 && num13 == 0)
				{
					rptEtiquetaQuadrant2.Quantidade = (int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				}
				else
				{
					rptEtiquetaQuadrant2.Quantidade = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				}
				rptEtiquetaQuadrant2.QuandidadeEmbalagem = num;
				rptEtiquetaQuadrant2.ItemNotaFiscal = nfi;
				rptEtiquetaQuadrant2.SequenciaEmbalagem = num13 + 1;
				((XtraReport)(object)rptEtiquetaQuadrant2).ImprimirEtiqueta(nomeImpressora);
				((Component)(object)rptEtiquetaQuadrant2).Dispose();
			}
			break;
		}
		case 4:
		case 11:
		{
			if (tipoEtiqueta == 11 && nfi != null && nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.EmbalagemRef != null && nfi.FichaExpedicaoItemRef.EmbalagemRef.QuantidadePecasContainer > 0)
			{
				int quantidadePecasContainer = nfi.FichaExpedicaoItemRef.EmbalagemRef.QuantidadePecasContainer;
				int num10 = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem / quantidadePecasContainer;
				int quantidadePorEmbalagem = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				bool flag5 = true;
				if (num10 * quantidadePecasContainer == nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem)
				{
					flag5 = false;
				}
				rptEtiquetaFordMasterLabel rptEtiquetaFordMasterLabel2 = new rptEtiquetaFordMasterLabel();
				rptEtiquetaFordMasterLabel2.ItemNotaFiscal = nfi;
				rptEtiquetaFordMasterLabel2.QuantidadePecas = quantidadePecasContainer * quantidadePorEmbalagem;
				if (num10 > 0)
				{
					((XtraReport)(object)rptEtiquetaFordMasterLabel2).ImprimirEtiqueta(nomeImpressora, num10);
				}
				if (flag5)
				{
					rptEtiquetaFordMasterLabel rptEtiquetaFordMasterLabel3 = new rptEtiquetaFordMasterLabel();
					rptEtiquetaFordMasterLabel3.ItemNotaFiscal = nfi;
					rptEtiquetaFordMasterLabel3.QuantidadePecas = nfi.FichaExpedicaoItemRef.QuantidadeEntregue - (decimal)(num10 * quantidadePecasContainer * quantidadePorEmbalagem);
					((XtraReport)(object)rptEtiquetaFordMasterLabel3).ImprimirEtiqueta(nomeImpressora, 1);
				}
			}
			rptEtiquetaFord rptEtiquetaFord2 = new rptEtiquetaFord();
			rptEtiquetaFord2.ItemNotaFiscal = nfi;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			rptEtiquetaFord2.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiquetaFord2).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiquetaFord rptEtiquetaFord3 = new rptEtiquetaFord();
				rptEtiquetaFord3.ItemNotaFiscal = nfi;
				rptEtiquetaFord3.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiquetaFord3).ImprimirEtiqueta(nomeImpressora);
			}
			break;
		}
		case 5:
		{
			int num25 = 0;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			for (int num26 = 0; num26 < num; num26++)
			{
				num25++;
				rptEtiquetaIsringhausen rptEtiquetaIsringhausen2 = new rptEtiquetaIsringhausen();
				rptEtiquetaIsringhausen2.ItemNotaFiscal = nfi;
				rptEtiquetaIsringhausen2.IsQdeQuebrada = false;
				rptEtiquetaIsringhausen2.nroEtiq = num25 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiquetaIsringhausen2).ImprimirEtiqueta(nomeImpressora, 1);
			}
			if (flag2)
			{
				num25++;
				rptEtiquetaIsringhausen rptEtiquetaIsringhausen3 = new rptEtiquetaIsringhausen();
				rptEtiquetaIsringhausen3.ItemNotaFiscal = nfi;
				rptEtiquetaIsringhausen3.IsQdeQuebrada = true;
				rptEtiquetaIsringhausen3.nroEtiq = num25 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiquetaIsringhausen3).ImprimirEtiqueta(nomeImpressora, 1);
				_qdeEtiquetas = 1;
			}
			break;
		}
		case 6:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag4 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int j = 0; j < num; j++)
			{
				rptEtiquetaAllevardDatamatrix rptEtiquetaAllevardDatamatrix2 = new rptEtiquetaAllevardDatamatrix();
				if (flag4 && j == 0)
				{
					rptEtiquetaAllevardDatamatrix2.Quantidade = (int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				}
				else
				{
					rptEtiquetaAllevardDatamatrix2.Quantidade = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				}
				rptEtiquetaAllevardDatamatrix2.QuandidadeEmbalagem = num;
				rptEtiquetaAllevardDatamatrix2.ItemNotaFiscal = nfi;
				rptEtiquetaAllevardDatamatrix2.SequenciaEmbalagem = j + 1;
				((XtraReport)rptEtiquetaAllevardDatamatrix2).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaAllevardDatamatrix2).ImprimirEtiqueta(nomeImpressora);
				((Component)(object)rptEtiquetaAllevardDatamatrix2).Dispose();
			}
			break;
		}
		case 7:
		{
			int num8 = 0;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			for (int l = 0; l < num; l++)
			{
				num8++;
				rptEtiquetaNakayone rptEtiquetaNakayone2 = new rptEtiquetaNakayone();
				rptEtiquetaNakayone2.ItemNotaFiscal = nfi;
				rptEtiquetaNakayone2.IsQdeQuebrada = false;
				rptEtiquetaNakayone2.nroEtiq = num8 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiquetaNakayone2).ImprimirEtiqueta(nomeImpressora, 1);
			}
			if (flag2)
			{
				num8++;
				rptEtiquetaNakayone rptEtiquetaNakayone3 = new rptEtiquetaNakayone();
				rptEtiquetaNakayone3.ItemNotaFiscal = nfi;
				rptEtiquetaNakayone3.IsQdeQuebrada = true;
				rptEtiquetaNakayone3.nroEtiq = num8 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiquetaNakayone3).ImprimirEtiqueta(nomeImpressora, 1);
				_qdeEtiquetas = 1;
			}
			break;
		}
		case 8:
		{
			EntidadeGPS entidadeGPS = ModuloEntidadesGPS.ObterEntidadeGPS(nfi.NotaFiscalRef.CodigoEntidade, nfi.NotaFiscalRef.TipoEntidade);
			int num14 = entidadeGPS.ContadorEtiqueta;
			int num15 = 0;
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				flag2 = false;
			}
			else
			{
				num15 = (int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				flag2 = true;
			}
			if (nfi.FichaExpedicaoItemRef == null || nfi.FichaExpedicaoItemRef.Tarifa == null)
			{
				break;
			}
			for (int num16 = 0; num16 < num; num16++)
			{
				rptEtiquetaMWM rptEtiquetaMWM = new rptEtiquetaMWM();
				rptEtiquetaMWM.CodigoPeca = nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
				rptEtiquetaMWM.DescricaoPeca = nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
				rptEtiquetaMWM.CodigoNomeFornecedor = $"{nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI}    {nfi.NotaFiscalRef.Entidade.NomeFantasia}";
				rptEtiquetaMWM.Data = nfi.NotaFiscalRef.DataEmissao.ToShortDateString();
				rptEtiquetaMWM.CodigoLote = nfi.FichaExpedicaoItemRef.Lotes[0].NumeroLote;
				rptEtiquetaMWM.CodigoID = string.Format("{0}{1}{2}", nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI.PadLeft(6, '0'), nfi.NotaFiscalRef.DataEmissao.ToString("yyMMdd"), num14.ToString().PadLeft(6, '0'));
				if (flag2 && num16 == 0)
				{
					rptEtiquetaMWM.Quantidade = num15.ToString();
				}
				else
				{
					rptEtiquetaMWM.Quantidade = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem.ToString();
				}
				((XtraReport)(object)rptEtiquetaMWM).ImprimirEtiqueta(nomeImpressora);
				num14++;
			}
			entidadeGPS.ContadorEtiqueta = num14;
			ModuloEntidadesGPS.AlterarEntidadeGPS(entidadeGPS, entidadeGPS.PropriedadesModificadas);
			break;
		}
		case 9:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag3 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int k = 0; k < num; k++)
			{
				rptEtiquetaScania rptEtiquetaScania = new rptEtiquetaScania();
				rptEtiquetaScania.Data = nfi.NotaFiscalRef.DataEmissao.ToString("dd/MM/yyyy");
				rptEtiquetaScania.Caixas = $"{k + 1} / {num}";
				rptEtiquetaScania.CodigoNomeFornecedor = emitente.RazaoSocial;
				if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null)
				{
					rptEtiquetaScania.CodigoPeca = nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
					rptEtiquetaScania.DescricaoPeca = nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
				}
				else
				{
					rptEtiquetaScania.CodigoPeca = nfi.CodigoExterno;
					rptEtiquetaScania.DescricaoPeca = nfi.DescricaoProduto;
				}
				int num7 = 0;
				num7 = ((!flag3 || k != 0) ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : ((int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1)));
				rptEtiquetaScania.Quantidade = num7.ToString("F0");
				rptEtiquetaScania.Peso = (nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num7).ToString();
				((XtraReport)rptEtiquetaScania).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaScania).ImprimirEtiqueta(nomeImpressora, 2);
				((Component)(object)rptEtiquetaScania).Dispose();
			}
			break;
		}
		case 10:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag3 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int n = 0; n < num; n++)
			{
				rptEtiquetaMBenzKLT rptEtiquetaMBenzKLT = new rptEtiquetaMBenzKLT();
				rptEtiquetaMBenzKLT.capacidadeEmbalagem = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				rptEtiquetaMBenzKLT.codigoFornecedor = nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI;
				rptEtiquetaMBenzKLT.dataChamada = nfi.NotaFiscalRef.DataEmissao;
				rptEtiquetaMBenzKLT.codigoEmbalagem = nfi.FichaExpedicaoItemRef.CodigoEmbalagem;
				rptEtiquetaMBenzKLT.localDescarga = nfi.NotaFiscalRef.PortaoEntrega;
				rptEtiquetaMBenzKLT.numeroChamada = nfi.ContratoCliente;
				rptEtiquetaMBenzKLT.volumesTotal = num;
				rptEtiquetaMBenzKLT.volume = n + 1;
				rptEtiquetaMBenzKLT.nomeFornecedor = emitente.NomeFantasia;
				rptEtiquetaMBenzKLT.plantaDestino = nfi.NotaFiscalRef.Entidade.CodigoContaDeposito;
				rptEtiquetaMBenzKLT.sequencia = "1";
				if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null)
				{
					rptEtiquetaMBenzKLT.codigoProduto = nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
					rptEtiquetaMBenzKLT.descricaoItem = nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
				}
				else
				{
					rptEtiquetaMBenzKLT.codigoProduto = nfi.CodigoExterno;
					rptEtiquetaMBenzKLT.descricaoItem = nfi.DescricaoProduto;
				}
				int num11 = 0;
				num11 = (rptEtiquetaMBenzKLT.quantidade = ((!flag3 || n != 0) ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : ((int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1))));
				rptEtiquetaMBenzKLT.pesoLiquido = nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num11;
				if (nfi.FichaExpedicaoItemRef.EmbalagemRef != null)
				{
					rptEtiquetaMBenzKLT.pesoBruto = rptEtiquetaMBenzKLT.pesoLiquido + nfi.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem;
				}
				else
				{
					rptEtiquetaMBenzKLT.pesoBruto = rptEtiquetaMBenzKLT.pesoLiquido;
				}
				((XtraReport)rptEtiquetaMBenzKLT).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaMBenzKLT).ImprimirEtiqueta(nomeImpressora, 1);
				((Component)(object)rptEtiquetaMBenzKLT).Dispose();
			}
			break;
		}
		case 12:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag3 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int i = 0; i < num; i++)
			{
				rptEtiquetaMBenzGLT rptEtiquetaMBenzGLT = new rptEtiquetaMBenzGLT();
				rptEtiquetaMBenzGLT.capacidadeEmbalagem = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				rptEtiquetaMBenzGLT.codigoFornecedor = nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI;
				rptEtiquetaMBenzGLT.dataChamada = nfi.NotaFiscalRef.DataEmissao;
				rptEtiquetaMBenzGLT.codigoEmbalagem = nfi.FichaExpedicaoItemRef.CodigoEmbalagem;
				rptEtiquetaMBenzGLT.localDescarga = nfi.NotaFiscalRef.PortaoEntrega;
				rptEtiquetaMBenzGLT.numeroChamada = nfi.ContratoCliente;
				rptEtiquetaMBenzGLT.volumesTotal = num;
				rptEtiquetaMBenzGLT.volume = i + 1;
				rptEtiquetaMBenzGLT.nomeFornecedor = emitente.NomeFantasia;
				rptEtiquetaMBenzGLT.plantaDestino = nfi.NotaFiscalRef.Entidade.CodigoContaDeposito;
				rptEtiquetaMBenzGLT.sequencia = "1";
				if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null)
				{
					rptEtiquetaMBenzGLT.codigoProduto = nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
					rptEtiquetaMBenzGLT.descricaoItem = nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
				}
				else
				{
					rptEtiquetaMBenzGLT.codigoProduto = nfi.CodigoExterno;
					rptEtiquetaMBenzGLT.descricaoItem = nfi.DescricaoProduto;
				}
				int num5 = 0;
				num5 = (rptEtiquetaMBenzGLT.quantidade = ((!flag3 || i != 0) ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : ((int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1))));
				rptEtiquetaMBenzGLT.pesoLiquido = nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num5;
				if (nfi.FichaExpedicaoItemRef.EmbalagemRef != null)
				{
					rptEtiquetaMBenzGLT.pesoBruto = rptEtiquetaMBenzGLT.pesoLiquido + nfi.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem;
				}
				else
				{
					rptEtiquetaMBenzGLT.pesoBruto = rptEtiquetaMBenzGLT.pesoLiquido;
				}
				((XtraReport)rptEtiquetaMBenzGLT).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaMBenzGLT).ImprimirEtiqueta("", 1);
				((Component)(object)rptEtiquetaMBenzGLT).Dispose();
			}
			break;
		}
		case 13:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag3 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int num22 = 0; num22 < num; num22 += 2)
			{
				rptEtiquetaMBenzGLTA4 rptEtiquetaMBenzGLTA = new rptEtiquetaMBenzGLTA4();
				rptEtiquetaMBenzGLTA.capacidadeEmbalagem = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				rptEtiquetaMBenzGLTA.codigoFornecedor = nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI;
				rptEtiquetaMBenzGLTA.dataChamada = nfi.NotaFiscalRef.DataEmissao;
				rptEtiquetaMBenzGLTA.codigoEmbalagem = nfi.FichaExpedicaoItemRef.CodigoEmbalagem;
				rptEtiquetaMBenzGLTA.localDescarga = nfi.NotaFiscalRef.PortaoEntrega;
				rptEtiquetaMBenzGLTA.numeroChamada = nfi.ContratoCliente;
				rptEtiquetaMBenzGLTA.volumesTotal = num;
				rptEtiquetaMBenzGLTA.volume = num22 + 1;
				rptEtiquetaMBenzGLTA.nomeFornecedor = emitente.NomeFantasia;
				rptEtiquetaMBenzGLTA.plantaDestino = nfi.NotaFiscalRef.Entidade.CodigoContaDeposito;
				rptEtiquetaMBenzGLTA.sequencia = "1";
				if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null)
				{
					rptEtiquetaMBenzGLTA.codigoProduto = nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade;
					rptEtiquetaMBenzGLTA.descricaoItem = nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade;
				}
				else
				{
					rptEtiquetaMBenzGLTA.codigoProduto = nfi.CodigoExterno;
					rptEtiquetaMBenzGLTA.descricaoItem = nfi.DescricaoProduto;
				}
				int num23 = 0;
				num23 = (rptEtiquetaMBenzGLTA.quantidade = ((!flag3 || num22 != 0) ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : ((int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1))));
				rptEtiquetaMBenzGLTA.pesoLiquido = nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num23;
				if (nfi.FichaExpedicaoItemRef.EmbalagemRef != null)
				{
					rptEtiquetaMBenzGLTA.pesoBruto = rptEtiquetaMBenzGLTA.pesoLiquido + nfi.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem;
				}
				else
				{
					rptEtiquetaMBenzGLTA.pesoBruto = rptEtiquetaMBenzGLTA.pesoLiquido;
				}
				bool flag10 = num22 + 2 <= num;
				rptEtiquetaMBenzGLTA.capacidadeEmbalagem2 = (flag10 ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : 0);
				rptEtiquetaMBenzGLTA.codigoFornecedor2 = (flag10 ? nfi.NotaFiscalRef.Entidade.CodigoVendedorEDI : string.Empty);
				rptEtiquetaMBenzGLTA.dataChamada2 = nfi.NotaFiscalRef.DataEmissao;
				rptEtiquetaMBenzGLTA.codigoEmbalagem2 = (flag10 ? nfi.FichaExpedicaoItemRef.CodigoEmbalagem : string.Empty);
				rptEtiquetaMBenzGLTA.localDescarga2 = (flag10 ? nfi.NotaFiscalRef.PortaoEntrega : string.Empty);
				rptEtiquetaMBenzGLTA.numeroChamada2 = (flag10 ? nfi.ContratoCliente : string.Empty);
				rptEtiquetaMBenzGLTA.volumesTotal2 = (flag10 ? num : 0);
				rptEtiquetaMBenzGLTA.volume2 = (flag10 ? (num22 + 2) : 0);
				rptEtiquetaMBenzGLTA.nomeFornecedor2 = (flag10 ? emitente.NomeFantasia : string.Empty);
				rptEtiquetaMBenzGLTA.plantaDestino2 = (flag10 ? nfi.NotaFiscalRef.Entidade.CodigoContaDeposito : string.Empty);
				rptEtiquetaMBenzGLTA.sequencia2 = "1";
				if (nfi.FichaExpedicaoItemRef != null && nfi.FichaExpedicaoItemRef.Tarifa != null)
				{
					rptEtiquetaMBenzGLTA.codigoProduto2 = (flag10 ? nfi.FichaExpedicaoItemRef.Tarifa.CodigoProdutoEntidade : string.Empty);
					rptEtiquetaMBenzGLTA.descricaoItem2 = (flag10 ? nfi.FichaExpedicaoItemRef.Tarifa.DescricaoProdutoEntidade : string.Empty);
				}
				else
				{
					rptEtiquetaMBenzGLTA.codigoProduto2 = (flag10 ? nfi.CodigoExterno : string.Empty);
					rptEtiquetaMBenzGLTA.descricaoItem2 = (flag10 ? nfi.DescricaoProduto : string.Empty);
				}
				num23 = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				rptEtiquetaMBenzGLTA.quantidade2 = (flag10 ? num23 : 0);
				rptEtiquetaMBenzGLTA.pesoLiquido2 = (flag10 ? (nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num23) : 0m);
				if (nfi.FichaExpedicaoItemRef.EmbalagemRef != null)
				{
					rptEtiquetaMBenzGLTA.pesoBruto2 = (flag10 ? (rptEtiquetaMBenzGLTA.pesoLiquido2 + nfi.FichaExpedicaoItemRef.EmbalagemRef.PesoEmbalagem) : 0m);
				}
				else
				{
					rptEtiquetaMBenzGLTA.pesoBruto2 = (flag10 ? rptEtiquetaMBenzGLTA.pesoLiquido2 : 0m);
				}
				((XtraReport)rptEtiquetaMBenzGLTA).ShowPrintMarginsWarning = false;
				XtraReportPreviewExtensions.Print((IReport)(object)rptEtiquetaMBenzGLTA);
				((Component)(object)rptEtiquetaMBenzGLTA).Dispose();
			}
			break;
		}
		case 80:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag3 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int num17 = 0; num17 < num; num17++)
			{
				rptEtiquetaFlexGrd rptEtiquetaFlexGrd = new rptEtiquetaFlexGrd();
				int num18 = 0;
				num18 = ((!flag3 || num17 != 0) ? nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem : ((int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1)));
				rptEtiquetaFlexGrd.empresaRemetente = nfi.NotaFiscalRef.SociedadeRef.NomeFantasia;
				rptEtiquetaFlexGrd.enderecoRemetente = $"{nfi.NotaFiscalRef.SociedadeRef.Endereco},{nfi.NotaFiscalRef.SociedadeRef.Numero}";
				rptEtiquetaFlexGrd.cidadeRemetente = $"{nfi.NotaFiscalRef.SociedadeRef.Cidade} - {nfi.NotaFiscalRef.SociedadeRef.Estado} - {nfi.NotaFiscalRef.SociedadeRef.CodigoPostal}";
				rptEtiquetaFlexGrd.empresaDestinatario = nfi.NotaFiscalRef.Entidade.NomeFantasia;
				rptEtiquetaFlexGrd.enderecoDestinatario = nfi.NotaFiscalRef.Entidade.Endereco;
				rptEtiquetaFlexGrd.cidadeDestinatario = $"{nfi.NotaFiscalRef.Entidade.Cidade} - {nfi.NotaFiscalRef.Entidade.UF}";
				rptEtiquetaFlexGrd.peso = nfi.FichaExpedicaoItemRef.EstoqueRef.PesoProduto * (decimal)num18;
				rptEtiquetaFlexGrd.Quantidade = num18;
				rptEtiquetaFlexGrd.notaFiscal = nfi.NotaFiscalRef.NumeroNotaFiscal.ToString();
				rptEtiquetaFlexGrd.pedidoVendas = nfi.ContratoCliente;
				rptEtiquetaFlexGrd.ProdutoAcabado = nfi.CodigoExterno;
				rptEtiquetaFlexGrd.caixaTotal = num;
				rptEtiquetaFlexGrd.caixa = num17 + 1;
				rptEtiquetaFlexGrd.data = nfi.NotaFiscalRef.DataEmissao;
				((XtraReport)rptEtiquetaFlexGrd).ShowPrintMarginsWarning = false;
				((XtraReport)(object)rptEtiquetaFlexGrd).ImprimirEtiqueta(nomeImpressora, 1);
				((Component)(object)rptEtiquetaFlexGrd).Dispose();
			}
			break;
		}
		case 100:
		{
			rptEtiqueta100 rptEtiqueta332 = new rptEtiqueta100();
			rptEtiqueta332.ItemNotaFiscal = nfi;
			int num27 = 0;
			int num28 = 0;
			decimal num29 = nfi.Quantidade;
			if (nfi.PecasPorEtiqueta > 0)
			{
				num27 = nfi.PecasPorEtiqueta;
				num28 = (int)Math.Ceiling(nfi.Quantidade / (decimal)num27);
			}
			else
			{
				num27 = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				num28 = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				if (num27 == 0 && nfi.FichaExpedicaoItemRef.PedidoVendaItemRef != null && nfi.FichaExpedicaoItemRef.PedidoVendaItemRef.ItensPorEmbalagem > 0)
				{
					num29 = nfi.FichaExpedicaoItemRef.QuantidadeEntregue;
					num27 = nfi.FichaExpedicaoItemRef.PedidoVendaItemRef.ItensPorEmbalagem;
					if (num27 > 0)
					{
						num28 = (int)Math.Ceiling(num29 / (decimal)num27);
					}
				}
			}
			if ((decimal)(num27 * num28) == num29)
			{
				num = num28;
				flag2 = false;
			}
			else
			{
				num = num28 - 1;
				flag2 = true;
			}
			rptEtiqueta332.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiqueta332).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiqueta332 = new rptEtiqueta100();
				rptEtiqueta332.ItemNotaFiscal = nfi;
				rptEtiqueta332.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiqueta332).ImprimirEtiqueta(nomeImpressora);
			}
			break;
		}
		case 101:
		{
			num = nfi.QuantidadeEmbalagem;
			bool flag9 = !((decimal)(nfi.PecasPorEtiqueta * nfi.QuantidadeEmbalagem) == nfi.Quantidade);
			for (int num21 = 0; num21 < num; num21++)
			{
				rptEtiquetaRontec rptEtiquetaRontec2 = new rptEtiquetaRontec();
				if (flag9 && num21 == 0)
				{
					rptEtiquetaRontec2.Quantidade = (int)nfi.Quantidade - nfi.PecasPorEtiqueta * (nfi.QuantidadeEmbalagem - 1);
				}
				else
				{
					rptEtiquetaRontec2.Quantidade = nfi.PecasPorEtiqueta;
				}
				rptEtiquetaRontec2.QuandidadeEmbalagem = num;
				rptEtiquetaRontec2.ItemNotaFiscal = nfi;
				rptEtiquetaRontec2.SequenciaEmbalagem = num21 + 1;
				((XtraReport)(object)rptEtiquetaRontec2).ImprimirEtiqueta(nomeImpressora);
				((Component)(object)rptEtiquetaRontec2).Dispose();
			}
			break;
		}
		case 102:
		{
			if (nfi.PecasPorEtiqueta == 0)
			{
				nfi.PecasPorEtiqueta = 1;
			}
			ClasseEtiquetaDispofix classeEtiquetaDispofix = new ClasseEtiquetaDispofix();
			int num9 = (int)Math.Ceiling(nfi.Quantidade / (decimal)nfi.PecasPorEtiqueta);
			for (int m = 0; m < num9 - 1; m++)
			{
				classeEtiquetaDispofix = new ClasseEtiquetaDispofix();
				classeEtiquetaDispofix.Cliente = entidade.RazaoSocial;
				classeEtiquetaDispofix.Emissão = nfi.NotaFiscalRef.DataEnvioNFE.ToShortDateString();
				classeEtiquetaDispofix.NotaFiscal = $"{nfi.NotaFiscalRef.NumeroNotaFiscal}/{nfi.Ordem}";
				classeEtiquetaDispofix.CodigoPeca = nfi.CodigoProduto;
				classeEtiquetaDispofix.Descrição = nfi.DescricaoProduto;
				classeEtiquetaDispofix.Pedido = nfi.CodigoPedidoVenda.ToString();
				classeEtiquetaDispofix.PedidoCliente = nfi.ContratoCliente;
				classeEtiquetaDispofix.Quantidade = nfi.PecasPorEtiqueta.ToString();
				classeEtiquetaDispofix.Embalagem = true;
				list.Add(classeEtiquetaDispofix);
			}
			classeEtiquetaDispofix = new ClasseEtiquetaDispofix();
			classeEtiquetaDispofix.Cliente = entidade.RazaoSocial;
			classeEtiquetaDispofix.Emissão = nfi.NotaFiscalRef.DataEnvioNFE.ToShortDateString();
			classeEtiquetaDispofix.NotaFiscal = $"{nfi.NotaFiscalRef.NumeroNotaFiscal}/{nfi.Ordem}";
			classeEtiquetaDispofix.CodigoPeca = nfi.CodigoProduto;
			classeEtiquetaDispofix.Descrição = nfi.DescricaoProduto;
			classeEtiquetaDispofix.Pedido = nfi.CodigoPedidoVenda.ToString();
			classeEtiquetaDispofix.PedidoCliente = nfi.ContratoCliente;
			if (nfi.Quantidade % (decimal)nfi.PecasPorEtiqueta > 0m)
			{
				classeEtiquetaDispofix.Quantidade = (nfi.Quantidade % (decimal)nfi.PecasPorEtiqueta).ToString();
			}
			else
			{
				classeEtiquetaDispofix.Quantidade = nfi.PecasPorEtiqueta.ToString();
			}
			classeEtiquetaDispofix.Embalagem = true;
			list.Add(classeEtiquetaDispofix);
			rptEtiquetaDispofix rptEtiquetaDispofix2 = new rptEtiquetaDispofix(list);
			XtraReportPreviewExtensions.ShowRibbonPreview((IReport)(object)rptEtiquetaDispofix2);
			break;
		}
		case 309:
		{
			int num30 = 0;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			for (int num31 = 0; num31 < num; num31++)
			{
				num30++;
				rptEtiqueta309 rptEtiqueta333 = new rptEtiqueta309();
				rptEtiqueta333.ItemNotaFiscal = nfi;
				rptEtiqueta333.IsQdeQuebrada = false;
				rptEtiqueta333.nroEtiq = num30 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiqueta333).ImprimirEtiqueta(nomeImpressora, 1);
			}
			if (flag2)
			{
				num30++;
				rptEtiqueta309 rptEtiqueta334 = new rptEtiqueta309();
				rptEtiqueta334.ItemNotaFiscal = nfi;
				rptEtiqueta334.IsQdeQuebrada = true;
				rptEtiqueta334.nroEtiq = num30 + "/" + nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				((XtraReport)(object)rptEtiqueta334).ImprimirEtiqueta(nomeImpressora, 1);
				_qdeEtiquetas = 1;
			}
			break;
		}
		case 329:
		{
			rptEtiqueta329 rptEtiqueta330 = new rptEtiqueta329();
			rptEtiqueta330.ItemNotaFiscal = nfi;
			if ((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue)
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				flag2 = false;
			}
			else
			{
				num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1;
				flag2 = true;
			}
			rptEtiqueta330.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiqueta330).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiqueta329 rptEtiqueta331 = new rptEtiqueta329();
				rptEtiqueta331.ItemNotaFiscal = nfi;
				rptEtiqueta331.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiqueta331).ImprimirEtiqueta(nomeImpressora, 1);
				_qdeEtiquetas = 1;
			}
			break;
		}
		case 334:
		{
			num = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
			bool flag7 = !((decimal)(nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem) == nfi.FichaExpedicaoItemRef.QuantidadeEntregue);
			for (int num19 = 0; num19 < num; num19++)
			{
				rptEtiquetaSavTec334 rptEtiquetaSavTec335 = new rptEtiquetaSavTec334();
				if (flag7 && num19 == 0)
				{
					rptEtiquetaSavTec335.Quantidade = (int)nfi.FichaExpedicaoItemRef.QuantidadeEntregue - nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem * (nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem - 1);
				}
				else
				{
					rptEtiquetaSavTec335.Quantidade = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				}
				rptEtiquetaSavTec335.QuandidadeEmbalagem = num;
				rptEtiquetaSavTec335.ItemNotaFiscal = nfi;
				rptEtiquetaSavTec335.SequenciaEmbalagem = num19 + 1;
				((XtraReport)(object)rptEtiquetaSavTec335).ImprimirEtiqueta(nomeImpressora);
				((Component)(object)rptEtiquetaSavTec335).Dispose();
			}
			break;
		}
		case 400:
		{
			rptEtiqueta400NF rptEtiqueta400NF2 = new rptEtiqueta400NF();
			rptEtiqueta400NF2.ItemNotaFiscal = nfi;
			int num2 = 0;
			int num3 = 0;
			decimal num4 = nfi.Quantidade;
			if (nfi.PecasPorEtiqueta > 0)
			{
				num2 = nfi.PecasPorEtiqueta;
				num3 = (int)Math.Ceiling(nfi.Quantidade / (decimal)num2);
			}
			else
			{
				num2 = nfi.FichaExpedicaoItemRef.QuantidadePorEmbalagem;
				num3 = nfi.FichaExpedicaoItemRef.QuantidadeEmbalagem;
				if (num2 == 0 && nfi.FichaExpedicaoItemRef.PedidoVendaItemRef != null && nfi.FichaExpedicaoItemRef.PedidoVendaItemRef.ItensPorEmbalagem > 0)
				{
					num4 = nfi.FichaExpedicaoItemRef.QuantidadeEntregue;
					num2 = nfi.FichaExpedicaoItemRef.PedidoVendaItemRef.ItensPorEmbalagem;
					if (num2 > 0)
					{
						num3 = (int)Math.Ceiling(num4 / (decimal)num2);
					}
				}
			}
			if ((decimal)(num2 * num3) == num4)
			{
				num = num3;
				flag2 = false;
			}
			else
			{
				num = num3 - 1;
				flag2 = true;
			}
			rptEtiqueta400NF2.IsQdeQuebrada = false;
			((XtraReport)(object)rptEtiqueta400NF2).ImprimirEtiqueta(nomeImpressora, num);
			if (flag2)
			{
				rptEtiqueta400NF2 = new rptEtiqueta400NF();
				rptEtiqueta400NF2.ItemNotaFiscal = nfi;
				rptEtiqueta400NF2.IsQdeQuebrada = true;
				((XtraReport)(object)rptEtiqueta400NF2).ImprimirEtiqueta(nomeImpressora);
			}
			break;
		}
		default:
			ImprimirEtiquetasItem(nfi, 0, nomeImpressora);
			break;
		}
	}

	private static void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
	{
		e.PrintDocument.PrinterSettings.Copies = _qdeEtiquetas;
	}

	public static void GerarTitulos(NotaFiscalNotasFiscais notaFiscalEmitida)
	{
		if (notaFiscalEmitida.Fatura == null || notaFiscalEmitida.Fatura.Count <= 0)
		{
			return;
		}
		int num = 1;
		foreach (NotaFiscalFatura item in notaFiscalEmitida.Fatura)
		{
			if (item.IsNaoGerarTitulo)
			{
				continue;
			}
			FinanceiroTitulos financeiroTitulos = new FinanceiroTitulos();
			financeiroTitulos.CodigoSociedade = notaFiscalEmitida.CodigoEmpresa;
			financeiroTitulos.ChaveNfe = notaFiscalEmitida.ChaveNfe;
			financeiroTitulos.Cnpj = notaFiscalEmitida.Entidade.CNPJLimpo;
			financeiroTitulos.CodigoBanco = 0;
			financeiroTitulos.CodigoCentroCustos = 0;
			int codigoContaContabil = 0;
			if (notaFiscalEmitida.CodigoContaContabil > 0)
			{
				codigoContaContabil = notaFiscalEmitida.CodigoContaContabil;
			}
			else if (notaFiscalEmitida.Entidade.CodigoContaGeral > 0)
			{
				codigoContaContabil = notaFiscalEmitida.Entidade.CodigoContaGeral;
			}
			else if (notaFiscalEmitida.Itens != null && notaFiscalEmitida.Itens.Count > 0)
			{
				try
				{
					if (notaFiscalEmitida.Itens[0].ContaContabilAnalitica != null)
					{
						codigoContaContabil = ModuloFiscal.ObterPlanoContaEstatico(notaFiscalEmitida.Itens[0].ContaContabilAnalitica).Id;
					}
				}
				catch
				{
				}
			}
			financeiroTitulos.CodigoContaContabil = codigoContaContabil;
			financeiroTitulos.CodigoDocumentoOrigem = notaFiscalEmitida.NumeroNotaFiscal;
			financeiroTitulos.CodigoTipoDocumentoOrigem = 1;
			financeiroTitulos.CodigoDocumentoOrigemItem = 0;
			financeiroTitulos.CodigoEntidade = notaFiscalEmitida.CodigoEntidade;
			financeiroTitulos.CodigoFuncionarioAtualizacao = 0;
			financeiroTitulos.CodigoFuncionarioCadastramento = 0;
			financeiroTitulos.CodigoMeioPagamento = 0;
			financeiroTitulos.CodigoOrigem = 0;
			financeiroTitulos.CodigoSubCentroCustos = 0;
			financeiroTitulos.CodigoTipo = EnumTipoTitulo.Receber;
			financeiroTitulos.CodigoTipoEntidade = notaFiscalEmitida.TipoEntidade;
			financeiroTitulos.Comentario = "Titulo gerado pelo MaxGPS";
			financeiroTitulos.Competencia = notaFiscalEmitida.DataEnvioNFE.ToString("MM/yyyy");
			financeiroTitulos.DataAtualizacao = DateTime.Now;
			financeiroTitulos.DataCadastramento = DateTime.Now;
			financeiroTitulos.DataEmissao = notaFiscalEmitida.DataEnvioNFE;
			financeiroTitulos.DataMovimento = notaFiscalEmitida.DataEmissao;
			financeiroTitulos.DataVencimento = item.Vencimento;
			financeiroTitulos.DataVencimentoNegociado = item.Vencimento;
			financeiroTitulos.DescricaoTitulo = "Titulo gerado sobre a NF: " + notaFiscalEmitida.NumeroNotaFiscal;
			financeiroTitulos.Documento = item.CodigoFatura;
			financeiroTitulos.NaturezaOperacao = notaFiscalEmitida.DescricaoCFOP;
			financeiroTitulos.RazaoSocial = notaFiscalEmitida.Entidade.RazaoSocial;
			financeiroTitulos.SequenciaAte = notaFiscalEmitida.Fatura.Count;
			financeiroTitulos.SequenciaDe = num;
			financeiroTitulos.ValorDocumentoOrigem = notaFiscalEmitida.ValorTotalFatura;
			financeiroTitulos.ValorTitulo = item.ValorFatura;
			financeiroTitulos.ValorTituloNegociado = item.ValorFatura;
			if (notaFiscalEmitida.FichaExpedicaoRef != null && notaFiscalEmitida.FichaExpedicaoRef.PedidoVenda != null)
			{
				financeiroTitulos.CodigoMeioPagamento = notaFiscalEmitida.FichaExpedicaoRef.PedidoVenda.TipoPagamento;
			}
			num++;
			ModuloFinanceiro.SalvarFinanceiroTitulos(financeiroTitulos);
		}
	}

	public static void SubstituirTagsTextoLegal(NotaFiscalNotasFiscais notaFiscalEmitida)
	{
		GerenciaNFe4.SubstituirTagsTextoLegal(notaFiscalEmitida);
	}

	public static void SalvarItensNotaFiscal(NotaFiscalNotasFiscais notaFiscalNotasFiscais)
	{
		if (notaFiscalNotasFiscais.Itens.Count <= 0)
		{
			return;
		}
		foreach (NotaFiscalNotasFiscaisItens iten in notaFiscalNotasFiscais.Itens)
		{
			if (iten.NotaFiscalItensDIRef != null && iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes != null && iten.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes.Count <= 0)
			{
			}
		}
		int num = 1;
		ExcluirNotaFiscalNotasFiscaisItens(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.NumeroNotaFiscal, notaFiscalNotasFiscais.CodigoSerieNF);
		ExcluirNotaFiscalNotasFiscaisItensDI(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF, notaFiscalNotasFiscais.NumeroNotaFiscal);
		ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscais.CodigoEmpresa, notaFiscalNotasFiscais.CodigoSerieNF, notaFiscalNotasFiscais.NumeroNotaFiscal);
		IDictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (NotaFiscalNotasFiscaisItens iten2 in notaFiscalNotasFiscais.Itens)
		{
			iten2.CodigoEmpresa = notaFiscalNotasFiscais.CodigoEmpresa;
			iten2.CodigoNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
			iten2.CodigoSerieNotaFiscal = notaFiscalNotasFiscais.CodigoSerieNF;
			iten2.Ordem = num++;
			if (iten2.CodigoFichaExpedicao > 0 && iten2.CodigoFichaExpedicaoItem > 0)
			{
				FichaExpedicaoItem fichaExpedicaoItem = ModuloExpedicao.ObterFichaExpedicaoItem(iten2.CodigoFichaExpedicao, iten2.CodigoFichaExpedicaoItem);
				if (fichaExpedicaoItem != null)
				{
					fichaExpedicaoItem.CodigoNotaFiscal = iten2.CodigoNotaFiscal;
					fichaExpedicaoItem.ItemNotaFiscal = iten2.Ordem;
					ModuloExpedicao.AlterarFichaExpedicaoItem(fichaExpedicaoItem, fichaExpedicaoItem.PropriedadesModificadas);
					if (!dictionary.ContainsKey(iten2.CodigoFichaExpedicao))
					{
						dictionary.Add(iten2.CodigoFichaExpedicao, 0);
					}
					if (iten2.QuantidadeEmPecas == 0m)
					{
						iten2.QuantidadeEmPecas = fichaExpedicaoItem.QuantidadeEntregue;
					}
				}
				fichaExpedicaoItem = null;
			}
			if (iten2.QuantidadeEmPecas == 0m)
			{
				iten2.QuantidadeEmPecas = iten2.Quantidade;
			}
			InserirNotaFiscalNotasFiscaisItens(iten2);
			if (iten2.NotaFiscalItensDIRef != null)
			{
				iten2.NotaFiscalItensDIRef.CodigoEmpresa = iten2.CodigoEmpresa;
				iten2.NotaFiscalItensDIRef.CodigoNotaFiscal = iten2.CodigoNotaFiscal;
				iten2.NotaFiscalItensDIRef.CodigoSerieNotaFiscal = iten2.CodigoSerieNotaFiscal;
				iten2.NotaFiscalItensDIRef.Ordem = iten2.Ordem;
				InserirNotaFiscalNotasFiscaisItensDI(iten2.NotaFiscalItensDIRef);
				if (iten2.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes != null)
				{
					foreach (NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdico in iten2.NotaFiscalItensDIRef.NotaFiscalNotasFiscaisItensDIAdicoes)
					{
						notaFiscalNotasFiscaisItensDIAdico.CodigoEmpresa = iten2.CodigoEmpresa;
						notaFiscalNotasFiscaisItensDIAdico.CodigoNotaFiscal = iten2.CodigoNotaFiscal;
						notaFiscalNotasFiscaisItensDIAdico.CodigoSerieNotaFiscal = iten2.CodigoSerieNotaFiscal;
						notaFiscalNotasFiscaisItensDIAdico.NumeroDI = iten2.NotaFiscalItensDIRef.NumeroDI;
						InserirNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscaisItensDIAdico);
					}
				}
			}
			if (iten2.EstoqueConsignadoRef != null && iten2.EstoqueConsignadoRef.IsNovo)
			{
				EstoqueConsignado estoqueConsignado = ModuloVendasGPS.ObterEstoqueConsignado(iten2.EstoqueConsignadoRef);
				if (estoqueConsignado == null)
				{
					ModuloVendasGPS.InserirEstoqueConsignado(iten2.EstoqueConsignadoRef);
				}
				iten2.EstoqueConsignadoRef.MarcarExistente();
			}
			if (iten2.EstoqueConsignadoLoteRef != null && iten2.EstoqueConsignadoLoteRef.IsNovo)
			{
				EstoqueConsignadoLote estoqueConsignadoLote = ModuloVendasGPS.ObterEstoqueConsignadoLote(iten2.EstoqueConsignadoLoteRef);
				if (estoqueConsignadoLote == null)
				{
					iten2.EstoqueConsignadoLoteRef.Lote = notaFiscalNotasFiscais.NumeroNotaFiscal;
					if (iten2.FichaExpedicaoItemRef != null)
					{
						iten2.EstoqueConsignadoLoteRef.PrecoUnitario = iten2.FichaExpedicaoItemRef.ValorVendaUnitario;
					}
					iten2.ConsignadoMovimentoRef.Lote = iten2.EstoqueConsignadoLoteRef.Lote;
					iten2.ConsignadoMovimentoRef.Data = DateTime.Now;
					ModuloVendasGPS.InserirEstoqueConsignadoLote(iten2.EstoqueConsignadoLoteRef);
					iten2.EstoqueConsignadoLoteRef.MarcarExistente();
					ModuloVendasGPS.InserirEstoqueConsignadoMovimento(iten2.ConsignadoMovimentoRef);
					iten2.ConsignadoMovimentoRef.MarcarExistente();
				}
				iten2.EstoqueConsignadoLoteRef.MarcarExistente();
				iten2.ConsignadoMovimentoRef.MarcarExistente();
			}
			else if (iten2.EstoqueConsignadoLoteRef != null && iten2.ConsignadoMovimentoRef.IsNovo)
			{
				ModuloVendasGPS.InserirEstoqueConsignadoMovimento(iten2.ConsignadoMovimentoRef);
				iten2.ConsignadoMovimentoRef.MarcarExistente();
				ModuloVendasGPS.AlterarEstoqueConsignadoLote(iten2.ConsignadoMovimentoRef.EstoqueConsignadoLoteRef, iten2.ConsignadoMovimentoRef.EstoqueConsignadoLoteRef.PropriedadesModificadas);
				iten2.EstoqueConsignadoLoteRef.MarcarExistente();
			}
			iten2.MarcarExistente();
		}
		foreach (KeyValuePair<int, int> item in dictionary)
		{
			FichaExpedicao fichaExpedicao = ModuloExpedicao.ObterFichaExpedicao(item.Key);
			if (fichaExpedicao.CodigoNotaFiscal == 0)
			{
				fichaExpedicao.CodigoNotaFiscal = notaFiscalNotasFiscais.NumeroNotaFiscal;
			}
			bool flag = true;
			foreach (FichaExpedicaoItem iten3 in fichaExpedicao.Itens)
			{
				if (iten3.CodigoNotaFiscal == 0)
				{
					flag = false;
				}
			}
			if (flag)
			{
				fichaExpedicao.StatusFichaExpedicao = EnumStatusFichaExpedicao.Faturado;
			}
			ModuloExpedicao.AlterarFichaExpedicao(fichaExpedicao, fichaExpedicao.PropriedadesModificadas);
		}
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterTodosNotaFiscalNotasFiscaisItens());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens(DateTime DataPeriodoInicial, DateTime DataPeriodoFinal)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterTodosNotaFiscalNotasFiscaisItens(DataPeriodoInicial, DataPeriodoFinal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItens(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItens(NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItens>(_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItens((MapTableNotaFiscalNotasFiscaisItens)notaFiscalNotasFiscaisItens.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int ordem, int codigoSerieNotaFiscal)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItens>(_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItens(codigoEmpresa, codigoNotaFiscal, ordem, codigoSerieNotaFiscal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensFE(codigoFichaExpedicao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao, int codigoFichaExpedicaoItem)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItens>(_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensFE(codigoFichaExpedicao, codigoFichaExpedicaoItem));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensPedidoCompra(codigoPedidoCompra));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra, int codigoPedidoCompraItem)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItens>(_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensPedidoCompra(codigoPedidoCompra, codigoPedidoCompraItem));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensPedidoVenda(codigoPedidoVenda));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensPedidoVenda(codigoPedidoVenda, codigoPedidoVendaItem));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem, int codigoNotaCorte)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensPedidoVenda(codigoPedidoVenda, codigoPedidoVendaItem, codigoNotaCorte));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(int codigoRecebimentoMaterialCliente)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(codigoRecebimentoMaterialCliente));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(string codigoMaterialCliente)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItens>((IList)_notaFiscalNotasFiscaisItensDao.ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(codigoMaterialCliente));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalNotasFiscaisItens(NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens)
	{
		return _notaFiscalNotasFiscaisItensDao.InserirNotaFiscalNotasFiscaisItens((MapTableNotaFiscalNotasFiscaisItens)notaFiscalNotasFiscaisItens.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalNotasFiscaisItens(NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalNotasFiscaisItensDao.AlterarNotaFiscalNotasFiscaisItens((MapTableNotaFiscalNotasFiscaisItens)notaFiscalNotasFiscaisItens.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscaisItens.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return _notaFiscalNotasFiscaisItensDao.ExcluirNotaFiscalNotasFiscaisItens(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int ordem)
	{
		return _notaFiscalNotasFiscaisItensDao.ExcluirNotaFiscalNotasFiscaisItens(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, ordem);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamentoItem> ObterRelatorioFaturamento(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamentoItem>((IList)_notaFiscalNotasFiscaisDao.ObterRelatorioFaturamento(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCFOPs>((IList)_notaFiscalCFOPsDao.ObterTodosNotaFiscalCFOPs());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs(bool Prefeitura)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCFOPs>((IList)_notaFiscalCFOPsDao.ObterTodosNotaFiscalCFOPs(Prefeitura));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsDevolucaoMaterialCliente()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCFOPs>((IList)_notaFiscalCFOPsDao.ObterTodosNotaFiscalCFOPsDevolucaoMaterialCliente());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsAtivos()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCFOPs>((IList)_notaFiscalCFOPsDao.ObterTodosNotaFiscalCFOPsAtivos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCFOPs ObterNotaFiscalCFOPs(int codigoCFOP)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCFOPs>(_notaFiscalCFOPsDao.ObterNotaFiscalCFOPs(codigoCFOP));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCFOPs ObterNotaFiscalCFOPs(NotaFiscalCFOPs notaFiscalCFOPs)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCFOPs>(_notaFiscalCFOPsDao.ObterNotaFiscalCFOPs((MapTableNotaFiscalCFOPs)notaFiscalCFOPs.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalCFOPs(NotaFiscalCFOPs notaFiscalCFOPs)
	{
		notaFiscalCFOPs.Id = _notaFiscalCFOPsDao.InserirNotaFiscalCFOPs((MapTableNotaFiscalCFOPs)notaFiscalCFOPs.ObterDadosMapeados());
		notaFiscalCFOPs.MarcarExistente();
		return notaFiscalCFOPs.Id;
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalCFOPs(NotaFiscalCFOPs notaFiscalCFOPs, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalCFOPsDao.AlterarNotaFiscalCFOPs((MapTableNotaFiscalCFOPs)notaFiscalCFOPs.ObterDadosMapeados(), camposAlterados);
		notaFiscalCFOPs.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalCFOPs(int codigoCFOP)
	{
		return _notaFiscalCFOPsDao.ExcluirNotaFiscalCFOPs(codigoCFOP);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalTextosLegais> ObterTodosNotaFiscalTextosLegais()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalTextosLegais>((IList)_notaFiscalTextosLegaisDao.ObterTodosNotaFiscalTextosLegais());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTextosLegais ObterNotaFiscalTextosLegais(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTextosLegais>(_notaFiscalTextosLegaisDao.ObterNotaFiscalTextosLegais(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTextosLegais ObterNotaFiscalTextosLegais(NotaFiscalTextosLegais notaFiscalTextosLegais)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTextosLegais>(_notaFiscalTextosLegaisDao.ObterNotaFiscalTextosLegais((MapTableNotaFiscalTextosLegais)notaFiscalTextosLegais.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalTextosLegais(NotaFiscalTextosLegais notaFiscalTextosLegais)
	{
		return _notaFiscalTextosLegaisDao.InserirNotaFiscalTextosLegais((MapTableNotaFiscalTextosLegais)notaFiscalTextosLegais.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalTextosLegais(NotaFiscalTextosLegais notaFiscalTextosLegais, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalTextosLegaisDao.AlterarNotaFiscalTextosLegais((MapTableNotaFiscalTextosLegais)notaFiscalTextosLegais.ObterDadosMapeados(), camposAlterados);
		notaFiscalTextosLegais.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalTextosLegais(int id)
	{
		return _notaFiscalTextosLegaisDao.ExcluirNotaFiscalTextosLegais(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalTipoRetencaoImposto> ObterTodosNotaFiscalTipoRetencaoImposto()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalTipoRetencaoImposto>((IList)_notaFiscalTipoRetencaoImpostoDao.ObterTodosNotaFiscalTipoRetencaoImposto());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoRetencaoImposto ObterNotaFiscalTipoRetencaoImposto(int codigoRetencao)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoRetencaoImposto>(_notaFiscalTipoRetencaoImpostoDao.ObterNotaFiscalTipoRetencaoImposto(codigoRetencao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoRetencaoImposto ObterNotaFiscalTipoRetencaoImposto(NotaFiscalTipoRetencaoImposto notaFiscalTipoRetencaoImposto)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoRetencaoImposto>(_notaFiscalTipoRetencaoImpostoDao.ObterNotaFiscalTipoRetencaoImposto((MapTableNotaFiscalTipoRetencaoImposto)notaFiscalTipoRetencaoImposto.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalTipoRetencaoImposto(NotaFiscalTipoRetencaoImposto notaFiscalTipoRetencaoImposto)
	{
		return _notaFiscalTipoRetencaoImpostoDao.InserirNotaFiscalTipoRetencaoImposto((MapTableNotaFiscalTipoRetencaoImposto)notaFiscalTipoRetencaoImposto.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalTipoRetencaoImposto(NotaFiscalTipoRetencaoImposto notaFiscalTipoRetencaoImposto, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalTipoRetencaoImpostoDao.AlterarNotaFiscalTipoRetencaoImposto((MapTableNotaFiscalTipoRetencaoImposto)notaFiscalTipoRetencaoImposto.ObterDadosMapeados(), camposAlterados);
		notaFiscalTipoRetencaoImposto.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalTipoRetencaoImposto(int codigoRetencao)
	{
		return _notaFiscalTipoRetencaoImpostoDao.ExcluirNotaFiscalTipoRetencaoImposto(codigoRetencao);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalOrigemProduto> ObterTodosNotaFiscalOrigemProduto()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalOrigemProduto>((IList)_notaFiscalOrigemProdutoDao.ObterTodosNotaFiscalOrigemProduto());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalOrigemProduto>(_notaFiscalOrigemProdutoDao.ObterNotaFiscalOrigemProduto(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(NotaFiscalOrigemProduto notaFiscalOrigemProduto)
	{
		return ObjectDataMapper.MapObject<NotaFiscalOrigemProduto>(_notaFiscalOrigemProdutoDao.ObterNotaFiscalOrigemProduto((MapTableNotaFiscalOrigemProduto)notaFiscalOrigemProduto.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalOrigemProduto(NotaFiscalOrigemProduto notaFiscalOrigemProduto)
	{
		return _notaFiscalOrigemProdutoDao.InserirNotaFiscalOrigemProduto((MapTableNotaFiscalOrigemProduto)notaFiscalOrigemProduto.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalOrigemProduto(NotaFiscalOrigemProduto notaFiscalOrigemProduto, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalOrigemProdutoDao.AlterarNotaFiscalOrigemProduto((MapTableNotaFiscalOrigemProduto)notaFiscalOrigemProduto.ObterDadosMapeados(), camposAlterados);
		notaFiscalOrigemProduto.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalOrigemProduto(int id)
	{
		return _notaFiscalOrigemProdutoDao.ExcluirNotaFiscalOrigemProduto(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalFormasPagto> ObterTodosNotaFiscalFormasPagto()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalFormasPagto>((IList)_notaFiscalFormasPagtoDao.ObterTodosNotaFiscalFormasPagto());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalFormasPagto ObterNotaFiscalFormasPagto(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalFormasPagto>(_notaFiscalFormasPagtoDao.ObterNotaFiscalFormasPagto(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalFormasPagto ObterNotaFiscalFormasPagto(NotaFiscalFormasPagto notaFiscalFormasPagto)
	{
		return ObjectDataMapper.MapObject<NotaFiscalFormasPagto>(_notaFiscalFormasPagtoDao.ObterNotaFiscalFormasPagto((MapTableNotaFiscalFormasPagto)notaFiscalFormasPagto.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalFormasPagto(NotaFiscalFormasPagto notaFiscalFormasPagto)
	{
		return _notaFiscalFormasPagtoDao.InserirNotaFiscalFormasPagto((MapTableNotaFiscalFormasPagto)notaFiscalFormasPagto.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalFormasPagto(NotaFiscalFormasPagto notaFiscalFormasPagto, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalFormasPagtoDao.AlterarNotaFiscalFormasPagto((MapTableNotaFiscalFormasPagto)notaFiscalFormasPagto.ObterDadosMapeados(), camposAlterados);
		notaFiscalFormasPagto.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalFormasPagto(int id)
	{
		return _notaFiscalFormasPagtoDao.ExcluirNotaFiscalFormasPagto(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalSerie> ObterTodosNotaFiscalSerie()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalSerie>((IList)_notaFiscalSerieDao.ObterTodosNotaFiscalSerie());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalSerie> ObterTodosNotaFiscalSerie(int codigoEmpresa)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalSerie>((IList)_notaFiscalSerieDao.ObterTodosNotaFiscalSerie(codigoEmpresa));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa)
	{
		return ObjectDataMapper.MapObject<NotaFiscalSerie>(_notaFiscalSerieDao.ObterNotaFiscalSerie(codigoEmpresa));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa, int codigoSerie)
	{
		return ObjectDataMapper.MapObject<NotaFiscalSerie>(_notaFiscalSerieDao.ObterNotaFiscalSerie(codigoEmpresa, codigoSerie));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalSerie ObterNotaFiscalSerie(NotaFiscalSerie notaFiscalSerie)
	{
		return ObjectDataMapper.MapObject<NotaFiscalSerie>(_notaFiscalSerieDao.ObterNotaFiscalSerie((MapTableNotaFiscalSerie)notaFiscalSerie.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalSerie(NotaFiscalSerie notaFiscalSerie)
	{
		int num = 0;
		num = ((!notaFiscalSerie.IsNovo) ? AlterarNotaFiscalSerie(notaFiscalSerie, notaFiscalSerie.PropriedadesModificadas) : InserirNotaFiscalSerie(notaFiscalSerie));
		notaFiscalSerie.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalSerie(NotaFiscalSerie notaFiscalSerie)
	{
		notaFiscalSerie.Id = _notaFiscalSerieDao.InserirNotaFiscalSerie((MapTableNotaFiscalSerie)notaFiscalSerie.ObterDadosMapeados());
		notaFiscalSerie.MarcarExistente();
		return notaFiscalSerie.Id;
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalSerie(NotaFiscalSerie notaFiscalSerie, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalSerieDao.AlterarNotaFiscalSerie((MapTableNotaFiscalSerie)notaFiscalSerie.ObterDadosMapeados(), camposAlterados);
		notaFiscalSerie.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalSerie(int id)
	{
		return _notaFiscalSerieDao.ExcluirNotaFiscalSerie(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalUF> ObterTodosNotaFiscalUF()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalUF>((IList)_notaFiscalUFDao.ObterTodosNotaFiscalUF());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalUF ObterNotaFiscalUF(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalUF>(_notaFiscalUFDao.ObterNotaFiscalUF(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalUF ObterNotaFiscalUF(string uf)
	{
		return ObjectDataMapper.MapObject<NotaFiscalUF>(_notaFiscalUFDao.ObterNotaFiscalUF(uf));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalUF ObterNotaFiscalUF(NotaFiscalUF notaFiscalUF)
	{
		return ObjectDataMapper.MapObject<NotaFiscalUF>(_notaFiscalUFDao.ObterNotaFiscalUF((MapTableNotaFiscalUF)notaFiscalUF.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalUF(NotaFiscalUF notaFiscalUF)
	{
		return _notaFiscalUFDao.InserirNotaFiscalUF((MapTableNotaFiscalUF)notaFiscalUF.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalUF(NotaFiscalUF notaFiscalUF, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalUFDao.AlterarNotaFiscalUF((MapTableNotaFiscalUF)notaFiscalUF.ObterDadosMapeados(), camposAlterados);
		notaFiscalUF.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalUF(int id)
	{
		return _notaFiscalUFDao.ExcluirNotaFiscalUF(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCidades> ObterTodosNotaFiscalCidades()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCidades>((IList)_notaFiscalCidadesDao.ObterTodosNotaFiscalCidades());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCidades ObterNotaFiscalCidades(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCidades>(_notaFiscalCidadesDao.ObterNotaFiscalCidades(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCidades ObterNotaFiscalCidades(string cidade)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCidades>(_notaFiscalCidadesDao.ObterNotaFiscalCidades(cidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCidades ObterNotaFiscalCidades(int codigoUF, string cidade)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCidades>(_notaFiscalCidadesDao.ObterNotaFiscalCidades(codigoUF, FuncoesUteis.PrimeiraLetraMaiuscula(cidade)));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCidades> ObterNotaFiscalCidadesEstado(int codigoEstado)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCidades>((IList)_notaFiscalCidadesDao.ObterNotaFiscalCidadesEstado(codigoEstado));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCidades ObterNotaFiscalCidades(NotaFiscalCidades notaFiscalCidades)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCidades>(_notaFiscalCidadesDao.ObterNotaFiscalCidades((MapTableNotaFiscalCidades)notaFiscalCidades.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalCidades(NotaFiscalCidades notaFiscalCidades)
	{
		return _notaFiscalCidadesDao.InserirNotaFiscalCidades((MapTableNotaFiscalCidades)notaFiscalCidades.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalCidades(NotaFiscalCidades notaFiscalCidades, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalCidadesDao.AlterarNotaFiscalCidades((MapTableNotaFiscalCidades)notaFiscalCidades.ObterDadosMapeados(), camposAlterados);
		notaFiscalCidades.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalCidades(int id)
	{
		return _notaFiscalCidadesDao.ExcluirNotaFiscalCidades(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalWebServices> ObterTodosNotaFiscalWebServices()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalWebServices>((IList)_notaFiscalWebServicesDao.ObterTodosNotaFiscalWebServices());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalWebServices ObterNotaFiscalWebServices(string uf, string ambiente, string servico)
	{
		return ObjectDataMapper.MapObject<NotaFiscalWebServices>(_notaFiscalWebServicesDao.ObterNotaFiscalWebServices(uf, ambiente, servico));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalWebServices ObterNotaFiscalWebServices(NotaFiscalWebServices notaFiscalWebServices)
	{
		return ObjectDataMapper.MapObject<NotaFiscalWebServices>(_notaFiscalWebServicesDao.ObterNotaFiscalWebServices((MapTableNotaFiscalWebServices)notaFiscalWebServices.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalWebServices(NotaFiscalWebServices notaFiscalWebServices)
	{
		return _notaFiscalWebServicesDao.InserirNotaFiscalWebServices((MapTableNotaFiscalWebServices)notaFiscalWebServices.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalWebServices(NotaFiscalWebServices notaFiscalWebServices, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalWebServicesDao.AlterarNotaFiscalWebServices((MapTableNotaFiscalWebServices)notaFiscalWebServices.ObterDadosMapeados(), camposAlterados);
		notaFiscalWebServices.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalWebServices(string uf, string ambiente, string servico)
	{
		return _notaFiscalWebServicesDao.ExcluirNotaFiscalWebServices(uf, ambiente, servico);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalPaises> ObterTodosNotaFiscalPaises()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalPaises>((IList)_notaFiscalPaisesDao.ObterTodosNotaFiscalPaises());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalPaises ObterNotaFiscalPaises(string pais)
	{
		if (string.IsNullOrEmpty(pais))
		{
			pais = "Brasil";
		}
		return ObjectDataMapper.MapObject<NotaFiscalPaises>(_notaFiscalPaisesDao.ObterNotaFiscalPaises(pais));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalPaises ObterNotaFiscalPaises(int codigoPais)
	{
		return ObjectDataMapper.MapObject<NotaFiscalPaises>(_notaFiscalPaisesDao.ObterNotaFiscalPaises(codigoPais));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalPaises ObterNotaFiscalPaises(NotaFiscalPaises notaFiscalPaises)
	{
		return ObjectDataMapper.MapObject<NotaFiscalPaises>(_notaFiscalPaisesDao.ObterNotaFiscalPaises((MapTableNotaFiscalPaises)notaFiscalPaises.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalPaises(NotaFiscalPaises notaFiscalPaises)
	{
		return _notaFiscalPaisesDao.InserirNotaFiscalPaises((MapTableNotaFiscalPaises)notaFiscalPaises.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalPaises(NotaFiscalPaises notaFiscalPaises, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalPaisesDao.AlterarNotaFiscalPaises((MapTableNotaFiscalPaises)notaFiscalPaises.ObterDadosMapeados(), camposAlterados);
		notaFiscalPaises.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalPaises(string pais)
	{
		return _notaFiscalPaisesDao.ExcluirNotaFiscalPaises(FuncoesUteis.PrimeiraLetraMaiuscula(pais));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalTipoIncidenciaIPI> ObterTodosNotaFiscalTipoIncidenciaIPI()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalTipoIncidenciaIPI>((IList)_notaFiscalTipoIncidenciaIPIDao.ObterTodosNotaFiscalTipoIncidenciaIPI());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidenciaIPI>(_notaFiscalTipoIncidenciaIPIDao.ObterNotaFiscalTipoIncidenciaIPI(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(NotaFiscalTipoIncidenciaIPI notaFiscalTipoIncidenciaIPI)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidenciaIPI>(_notaFiscalTipoIncidenciaIPIDao.ObterNotaFiscalTipoIncidenciaIPI((MapTableNotaFiscalTipoIncidenciaIPI)notaFiscalTipoIncidenciaIPI.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalTipoIncidenciaIPI(NotaFiscalTipoIncidenciaIPI notaFiscalTipoIncidenciaIPI)
	{
		return _notaFiscalTipoIncidenciaIPIDao.InserirNotaFiscalTipoIncidenciaIPI((MapTableNotaFiscalTipoIncidenciaIPI)notaFiscalTipoIncidenciaIPI.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalTipoIncidenciaIPI(NotaFiscalTipoIncidenciaIPI notaFiscalTipoIncidenciaIPI, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalTipoIncidenciaIPIDao.AlterarNotaFiscalTipoIncidenciaIPI((MapTableNotaFiscalTipoIncidenciaIPI)notaFiscalTipoIncidenciaIPI.ObterDadosMapeados(), camposAlterados);
		notaFiscalTipoIncidenciaIPI.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalTipoIncidenciaIPI(int id)
	{
		return _notaFiscalTipoIncidenciaIPIDao.ExcluirNotaFiscalTipoIncidenciaIPI(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalTipoIncidenciaImpostosFederais> ObterTodosNotaFiscalTipoIncidenciaImpostosFederais()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalTipoIncidenciaImpostosFederais>((IList)_notaFiscalTipoIncidenciaImpostosFederaisDao.ObterTodosNotaFiscalTipoIncidenciaImpostosFederais());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidenciaImpostosFederais ObterNotaFiscalTipoIncidenciaImpostosFederais(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidenciaImpostosFederais>(_notaFiscalTipoIncidenciaImpostosFederaisDao.ObterNotaFiscalTipoIncidenciaImpostosFederais(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalTipoIncidenciaImpostosFederais ObterNotaFiscalTipoIncidenciaImpostosFederais(NotaFiscalTipoIncidenciaImpostosFederais notaFiscalTipoIncidenciaImpostosFederais)
	{
		return ObjectDataMapper.MapObject<NotaFiscalTipoIncidenciaImpostosFederais>(_notaFiscalTipoIncidenciaImpostosFederaisDao.ObterNotaFiscalTipoIncidenciaImpostosFederais((MapTableNotaFiscalTipoIncidenciaImpostosFederais)notaFiscalTipoIncidenciaImpostosFederais.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirNotaFiscalTipoIncidenciaImpostosFederais(NotaFiscalTipoIncidenciaImpostosFederais notaFiscalTipoIncidenciaImpostosFederais)
	{
		return _notaFiscalTipoIncidenciaImpostosFederaisDao.InserirNotaFiscalTipoIncidenciaImpostosFederais((MapTableNotaFiscalTipoIncidenciaImpostosFederais)notaFiscalTipoIncidenciaImpostosFederais.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarNotaFiscalTipoIncidenciaImpostosFederais(NotaFiscalTipoIncidenciaImpostosFederais notaFiscalTipoIncidenciaImpostosFederais, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalTipoIncidenciaImpostosFederaisDao.AlterarNotaFiscalTipoIncidenciaImpostosFederais((MapTableNotaFiscalTipoIncidenciaImpostosFederais)notaFiscalTipoIncidenciaImpostosFederais.ObterDadosMapeados(), camposAlterados);
		notaFiscalTipoIncidenciaImpostosFederais.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalTipoIncidenciaImpostosFederais(int id)
	{
		return _notaFiscalTipoIncidenciaImpostosFederaisDao.ExcluirNotaFiscalTipoIncidenciaImpostosFederais(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento(ano));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento(ano, mes));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento(ano, mes, contaContabil));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento(ano, mes, contaContabil, cfop));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop, int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamento(ano, mes, contaContabil, cfop, codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int mes, int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoEntidade(ano, mes, codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoEntidade(ano, codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoEntidade(codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, int mes, string contaContabil)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoContaContabil(ano, mes, contaContabil));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, string contaContabil)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoContaContabil(ano, contaContabil));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(string contaContabil)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoContaContabil(contaContabil));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, int mes, string cfop)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoCfop(ano, mes, cfop));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, string cfop)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoCfop(ano, cfop));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(string cfop)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalResumoFaturamento>((IList)_notaFiscalResumoFaturamentoDao.ObterTodosNotaFiscalResumoFaturamentoCfop(cfop));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotasFiscaisEventos> ObterTodosNotasFiscaisEventos()
	{
		return ObjectDataMapper.MapObjectList<NotasFiscaisEventos>((IList)_notasFiscaisEventosDao.ObterTodosNotasFiscaisEventos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		return ObjectDataMapper.MapObjectList<NotasFiscaisEventos>((IList)_notasFiscaisEventosDao.ObterTodosNotasFiscaisEventos(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento)
	{
		return ObjectDataMapper.MapObjectList<NotasFiscaisEventos>((IList)_notasFiscaisEventosDao.ObterTodosNotasFiscaisEventos(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, codigoEvento));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotasFiscaisEventos ObterNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		return ObjectDataMapper.MapObject<NotasFiscaisEventos>(_notasFiscaisEventosDao.ObterNotasFiscaisEventos(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, codigoEvento, codigoSequenciaEvento));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotasFiscaisEventos ObterNotasFiscaisEventos(NotasFiscaisEventos notasFiscaisEventos)
	{
		return ObjectDataMapper.MapObject<NotasFiscaisEventos>(_notasFiscaisEventosDao.ObterNotasFiscaisEventos((MapTableNotasFiscaisEventos)notasFiscaisEventos.ObterDadosMapeados()));
	}

	public static int SalvarNotasFiscaisEventos(NotasFiscaisEventos notasFiscaisEventos)
	{
		int num = 0;
		num = ((!notasFiscaisEventos.IsNovo) ? AlterarNotasFiscaisEventos(notasFiscaisEventos, notasFiscaisEventos.PropriedadesModificadas) : InserirNotasFiscaisEventos(notasFiscaisEventos));
		notasFiscaisEventos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotasFiscaisEventos(NotasFiscaisEventos notasFiscaisEventos)
	{
		return _notasFiscaisEventosDao.InserirNotasFiscaisEventos((MapTableNotasFiscaisEventos)notasFiscaisEventos.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotasFiscaisEventos(NotasFiscaisEventos notasFiscaisEventos, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notasFiscaisEventosDao.AlterarNotasFiscaisEventos((MapTableNotasFiscaisEventos)notasFiscaisEventos.ObterDadosMapeados(), camposAlterados);
		notasFiscaisEventos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		return _notasFiscaisEventosDao.ExcluirNotasFiscaisEventos(codigoEmpresa, codigoNotaFiscal, codigoSerieNotaFiscal, codigoEvento, codigoSequenciaEvento);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItensDI> ObterTodosNotaFiscalNotasFiscaisItensDI()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItensDI>((IList)_notaFiscalNotasFiscaisItensDIDao.ObterTodosNotaFiscalNotasFiscaisItensDI());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItensDI>(_notaFiscalNotasFiscaisItensDIDao.ObterNotaFiscalNotasFiscaisItensDI(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem, numeroDI));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItensDI>(_notaFiscalNotasFiscaisItensDIDao.ObterNotaFiscalNotasFiscaisItensDI(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(NotaFiscalNotasFiscaisItensDI notaFiscalNotasFiscaisItensDI)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItensDI>(_notaFiscalNotasFiscaisItensDIDao.ObterNotaFiscalNotasFiscaisItensDI((MapTableNotaFiscalNotasFiscaisItensDI)notaFiscalNotasFiscaisItensDI.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalNotasFiscaisItensDI(NotaFiscalNotasFiscaisItensDI notaFiscalNotasFiscaisItensDI)
	{
		int result = 0;
		if (!notaFiscalNotasFiscaisItensDI.IsExcluir)
		{
			result = ((!notaFiscalNotasFiscaisItensDI.IsNovo) ? AlterarNotaFiscalNotasFiscaisItensDI(notaFiscalNotasFiscaisItensDI, notaFiscalNotasFiscaisItensDI.PropriedadesModificadas) : InserirNotaFiscalNotasFiscaisItensDI(notaFiscalNotasFiscaisItensDI));
		}
		else
		{
			ExcluirNotaFiscalNotasFiscaisItensDI(notaFiscalNotasFiscaisItensDI.CodigoEmpresa, notaFiscalNotasFiscaisItensDI.CodigoSerieNotaFiscal, notaFiscalNotasFiscaisItensDI.CodigoNotaFiscal, notaFiscalNotasFiscaisItensDI.Ordem, notaFiscalNotasFiscaisItensDI.NumeroDI);
			foreach (NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdico in notaFiscalNotasFiscaisItensDI.NotaFiscalNotasFiscaisItensDIAdicoes)
			{
				notaFiscalNotasFiscaisItensDIAdico.IsExcluir = true;
			}
		}
		foreach (NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdico2 in notaFiscalNotasFiscaisItensDI.NotaFiscalNotasFiscaisItensDIAdicoes)
		{
			notaFiscalNotasFiscaisItensDIAdico2.CodigoEmpresa = notaFiscalNotasFiscaisItensDI.CodigoEmpresa;
			notaFiscalNotasFiscaisItensDIAdico2.CodigoNotaFiscal = notaFiscalNotasFiscaisItensDI.CodigoNotaFiscal;
			notaFiscalNotasFiscaisItensDIAdico2.CodigoSerieNotaFiscal = notaFiscalNotasFiscaisItensDI.CodigoSerieNotaFiscal;
			notaFiscalNotasFiscaisItensDIAdico2.NumeroDI = notaFiscalNotasFiscaisItensDI.NumeroDI;
			notaFiscalNotasFiscaisItensDIAdico2.Ordem = notaFiscalNotasFiscaisItensDI.Ordem;
			SalvarNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscaisItensDIAdico2);
		}
		notaFiscalNotasFiscaisItensDI.MarcarExistente();
		return result;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalNotasFiscaisItensDI(NotaFiscalNotasFiscaisItensDI notaFiscalNotasFiscaisItensDI)
	{
		return _notaFiscalNotasFiscaisItensDIDao.InserirNotaFiscalNotasFiscaisItensDI((MapTableNotaFiscalNotasFiscaisItensDI)notaFiscalNotasFiscaisItensDI.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalNotasFiscaisItensDI(NotaFiscalNotasFiscaisItensDI notaFiscalNotasFiscaisItensDI, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalNotasFiscaisItensDIDao.AlterarNotaFiscalNotasFiscaisItensDI((MapTableNotaFiscalNotasFiscaisItensDI)notaFiscalNotasFiscaisItensDI.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscaisItensDI.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		return _notaFiscalNotasFiscaisItensDIDao.ExcluirNotaFiscalNotasFiscaisItensDI(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem, numeroDI);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		return _notaFiscalNotasFiscaisItensDIDao.ExcluirNotaFiscalNotasFiscaisItensDI(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItensDIAdicoes>((IList)_notaFiscalNotasFiscaisItensDIAdicoesDao.ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotasFiscaisItensDIAdicoes>((IList)_notaFiscalNotasFiscaisItensDIAdicoesDao.ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem, numeroDI));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItensDIAdicoes>(_notaFiscalNotasFiscaisItensDIAdicoesDao.ObterNotaFiscalNotasFiscaisItensDIAdicoes(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem, numeroDI, numeroAdicao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdicoes)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotasFiscaisItensDIAdicoes>(_notaFiscalNotasFiscaisItensDIAdicoesDao.ObterNotaFiscalNotasFiscaisItensDIAdicoes((MapTableNotaFiscalNotasFiscaisItensDIAdicoes)notaFiscalNotasFiscaisItensDIAdicoes.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalNotasFiscaisItensDIAdicoes(NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdicoes)
	{
		int result = 0;
		if (!notaFiscalNotasFiscaisItensDIAdicoes.IsExcluir)
		{
			result = ((!notaFiscalNotasFiscaisItensDIAdicoes.IsNovo) ? AlterarNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscaisItensDIAdicoes, notaFiscalNotasFiscaisItensDIAdicoes.PropriedadesModificadas) : InserirNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscaisItensDIAdicoes));
		}
		else
		{
			ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(notaFiscalNotasFiscaisItensDIAdicoes.CodigoEmpresa, notaFiscalNotasFiscaisItensDIAdicoes.CodigoSerieNotaFiscal, notaFiscalNotasFiscaisItensDIAdicoes.CodigoNotaFiscal, notaFiscalNotasFiscaisItensDIAdicoes.Ordem, notaFiscalNotasFiscaisItensDIAdicoes.NumeroDI, notaFiscalNotasFiscaisItensDIAdicoes.NumeroSequenciaAdicao);
		}
		notaFiscalNotasFiscaisItensDIAdicoes.MarcarExistente();
		return result;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalNotasFiscaisItensDIAdicoes(NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdicoes)
	{
		return _notaFiscalNotasFiscaisItensDIAdicoesDao.InserirNotaFiscalNotasFiscaisItensDIAdicoes((MapTableNotaFiscalNotasFiscaisItensDIAdicoes)notaFiscalNotasFiscaisItensDIAdicoes.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalNotasFiscaisItensDIAdicoes(NotaFiscalNotasFiscaisItensDIAdicoes notaFiscalNotasFiscaisItensDIAdicoes, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalNotasFiscaisItensDIAdicoesDao.AlterarNotaFiscalNotasFiscaisItensDIAdicoes((MapTableNotaFiscalNotasFiscaisItensDIAdicoes)notaFiscalNotasFiscaisItensDIAdicoes.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotasFiscaisItensDIAdicoes.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		return _notaFiscalNotasFiscaisItensDIAdicoesDao.ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal, ordem, numeroDI, numeroAdicao);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		return _notaFiscalNotasFiscaisItensDIAdicoesDao.ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(codigoEmpresa, codigoSerieNotaFiscal, codigoNotaFiscal);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalInutilizacao>((IList)_notaFiscalInutilizacaoDao.ObterTodosNotaFiscalInutilizacao());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao(int codigoEmpresa)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalInutilizacao>((IList)_notaFiscalInutilizacaoDao.ObterTodosNotaFiscalInutilizacao(codigoEmpresa));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalInutilizacao ObterNotaFiscalInutilizacao(int id)
	{
		return ObjectDataMapper.MapObject<NotaFiscalInutilizacao>(_notaFiscalInutilizacaoDao.ObterNotaFiscalInutilizacao(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalInutilizacao ObterNotaFiscalInutilizacao(NotaFiscalInutilizacao notaFiscalInutilizacao)
	{
		return ObjectDataMapper.MapObject<NotaFiscalInutilizacao>(_notaFiscalInutilizacaoDao.ObterNotaFiscalInutilizacao((MapTableNotaFiscalInutilizacao)notaFiscalInutilizacao.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalInutilizacao(NotaFiscalInutilizacao notaFiscalInutilizacao)
	{
		int num = 0;
		num = ((!notaFiscalInutilizacao.IsNovo && notaFiscalInutilizacao.Id != 0) ? AlterarNotaFiscalInutilizacao(notaFiscalInutilizacao, notaFiscalInutilizacao.PropriedadesModificadas) : (notaFiscalInutilizacao.Id = InserirNotaFiscalInutilizacao(notaFiscalInutilizacao)));
		notaFiscalInutilizacao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalInutilizacao(NotaFiscalInutilizacao notaFiscalInutilizacao)
	{
		return _notaFiscalInutilizacaoDao.InserirNotaFiscalInutilizacao((MapTableNotaFiscalInutilizacao)notaFiscalInutilizacao.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalInutilizacao(NotaFiscalInutilizacao notaFiscalInutilizacao, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalInutilizacaoDao.AlterarNotaFiscalInutilizacao((MapTableNotaFiscalInutilizacao)notaFiscalInutilizacao.ObterDadosMapeados(), camposAlterados);
		notaFiscalInutilizacao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalInutilizacao(int id)
	{
		return _notaFiscalInutilizacaoDao.ExcluirNotaFiscalInutilizacao(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalCest> ObterTodosNotaFiscalCest()
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalCest>((IList)_notaFiscalCestDao.ObterTodosNotaFiscalCest());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCest ObterNotaFiscalCest(string codigoCest, string ncm, int codigoEstado)
	{
		NotaFiscalCest notaFiscalCest = ObjectDataMapper.MapObject<NotaFiscalCest>(_notaFiscalCestDao.ObterNotaFiscalCest(codigoCest, ncm, codigoEstado));
		if (notaFiscalCest == null)
		{
			notaFiscalCest = ObjectDataMapper.MapObject<NotaFiscalCest>(_notaFiscalCestDao.ObterNotaFiscalCest(codigoCest, codigoEstado));
		}
		return notaFiscalCest;
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalCest ObterNotaFiscalCest(NotaFiscalCest notaFiscalCest)
	{
		return ObjectDataMapper.MapObject<NotaFiscalCest>(_notaFiscalCestDao.ObterNotaFiscalCest((MapTableNotaFiscalCest)notaFiscalCest.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalCest(NotaFiscalCest notaFiscalCest)
	{
		int num = 0;
		num = ((!notaFiscalCest.IsNovo) ? AlterarNotaFiscalCest(notaFiscalCest, notaFiscalCest.PropriedadesModificadas) : InserirNotaFiscalCest(notaFiscalCest));
		notaFiscalCest.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalCest(NotaFiscalCest notaFiscalCest)
	{
		int num = 0;
		return notaFiscalCest.Id = _notaFiscalCestDao.InserirNotaFiscalCest((MapTableNotaFiscalCest)notaFiscalCest.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalCest(NotaFiscalCest notaFiscalCest, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalCestDao.AlterarNotaFiscalCest((MapTableNotaFiscalCest)notaFiscalCest.ObterDadosMapeados(), camposAlterados);
		notaFiscalCest.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalCest(int id)
	{
		return _notaFiscalCestDao.ExcluirNotaFiscalCest(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<NotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF)
	{
		return ObjectDataMapper.MapObjectList<NotaFiscalNotaReferenciada>((IList)_notaFiscalNotaReferenciadaDao.ObterTodosNotaFiscalNotaReferenciada(codigoEmpresa, numeroNotaFiscal, codigoSerieNF));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotaReferenciada>(_notaFiscalNotaReferenciadaDao.ObterNotaFiscalNotaReferenciada(codigoEmpresa, numeroNotaFiscal, codigoSerieNF, notaReferenciada));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static NotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(NotaFiscalNotaReferenciada notaFiscalNotaReferenciada)
	{
		return ObjectDataMapper.MapObject<NotaFiscalNotaReferenciada>(_notaFiscalNotaReferenciadaDao.ObterNotaFiscalNotaReferenciada((MapTableNotaFiscalNotaReferenciada)notaFiscalNotaReferenciada.ObterDadosMapeados()));
	}

	public static int SalvarNotaFiscalNotaReferenciada(NotaFiscalNotaReferenciada notaFiscalNotaReferenciada)
	{
		int num = 0;
		num = (notaFiscalNotaReferenciada.IsExcluir ? ExcluirNotaFiscalNotaReferenciada(notaFiscalNotaReferenciada.CodigoEmpresa, notaFiscalNotaReferenciada.NumeroNotaFiscal, notaFiscalNotaReferenciada.CodigoSerieNF, notaFiscalNotaReferenciada.NotaReferenciada) : ((!notaFiscalNotaReferenciada.IsNovo) ? AlterarNotaFiscalNotaReferenciada(notaFiscalNotaReferenciada, notaFiscalNotaReferenciada.PropriedadesModificadas) : InserirNotaFiscalNotaReferenciada(notaFiscalNotaReferenciada)));
		notaFiscalNotaReferenciada.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	private static int InserirNotaFiscalNotaReferenciada(NotaFiscalNotaReferenciada notaFiscalNotaReferenciada)
	{
		return _notaFiscalNotaReferenciadaDao.InserirNotaFiscalNotaReferenciada((MapTableNotaFiscalNotaReferenciada)notaFiscalNotaReferenciada.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	private static int AlterarNotaFiscalNotaReferenciada(NotaFiscalNotaReferenciada notaFiscalNotaReferenciada, Hashtable camposAlterados)
	{
		int num = 0;
		num = _notaFiscalNotaReferenciadaDao.AlterarNotaFiscalNotaReferenciada((MapTableNotaFiscalNotaReferenciada)notaFiscalNotaReferenciada.ObterDadosMapeados(), camposAlterados);
		notaFiscalNotaReferenciada.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada)
	{
		return _notaFiscalNotaReferenciadaDao.ExcluirNotaFiscalNotaReferenciada(codigoEmpresa, numeroNotaFiscal, codigoSerieNF, notaReferenciada);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF)
	{
		return _notaFiscalNotaReferenciadaDao.ExcluirNotaFiscalNotaReferenciada(codigoEmpresa, numeroNotaFiscal, codigoSerieNF);
	}

	public static string SubstituirTagsNotaFiscal(string texto, NotaFiscalNotasFiscais NotaFiscal)
	{
		if (NotaFiscal != null && !string.IsNullOrEmpty(texto))
		{
			if (texto.Contains("[RazaoSocialEmitente]"))
			{
				texto = texto.Replace("[RazaoSocialEmitente]", NotaFiscal.Emitente.RazaoSocial);
			}
			if (texto.Contains("[RazaoSocialDestinatario]"))
			{
				texto = texto.Replace("[RazaoSocialDestinatario]", NotaFiscal.Entidade.RazaoSocial);
			}
			if (texto.Contains("[NumeroNotaFiscal]"))
			{
				texto = texto.Replace("[NumeroNotaFiscal]", NotaFiscal.NumeroNotaFiscal.ToString());
			}
			if (texto.Contains("[ChaveEletronica]"))
			{
				texto = texto.Replace("[ChaveEletronica]", NotaFiscal.ChaveNfe);
			}
			if (texto.Contains("[ProtocoloSefaz]"))
			{
				texto = texto.Replace("[ProtocoloSefaz]", NotaFiscal.ProtocoloNfe);
			}
			if (texto.Contains("[FATURA]"))
			{
				texto = texto.Replace("[FATURA]", NotaFiscal.ValorTotalFatura.ToString("N2"));
			}
			if (texto.Contains("[PORTAO]"))
			{
				texto = texto.Replace("[PORTAO]", NotaFiscal.PortaoEntrega);
			}
			if (texto.Contains("[CREDITOICMS]"))
			{
				texto = texto.Replace("[CREDITOICMS]", NotaFiscal.ValorCreditoIcms.ToString("N2"));
			}
			if (texto.Contains("[PERCENTUALCREDITOICMS]"))
			{
				texto = texto.Replace("[PERCENTUALCREDITOICMS]", NotaFiscal.PercentualCreditoIcms.ToString("N2"));
			}
			if (texto.Contains("[TOTALAPROXIMADOIMPOSTOS]"))
			{
				texto = texto.Replace("[TOTALAPROXIMADOIMPOSTOS]", NotaFiscal.ValorTotalAproximadoImpostos.ToString("N2"));
			}
			if (texto.Contains("[CODIGOVENDEDOREDI]"))
			{
				texto = texto.Replace("[CODIGOVENDEDOREDI]", NotaFiscal.Entidade.CodigoVendedorEDI);
			}
			if (texto.Contains("[CODIGOCOMPRADOREDI]"))
			{
				texto = texto.Replace("[CODIGOCOMPRADOREDI]", NotaFiscal.Entidade.CodigoCompradorEDI);
			}
			if (texto.Contains("[IDENTIFICADORFABRICA]"))
			{
				texto = texto.Replace("[IDENTIFICADORFABRICA]", NotaFiscal.Entidade.CodigoContaDeposito);
			}
			if (texto.Contains("[NOMECOMPRADOR]"))
			{
				texto = ((NotaFiscal.FichaExpedicaoRef == null || NotaFiscal.FichaExpedicaoRef.PedidoVenda == null || string.IsNullOrWhiteSpace(NotaFiscal.FichaExpedicaoRef.PedidoVenda.NomeContato)) ? texto.Replace("[NOMECOMPRADOR]", "") : texto.Replace("[NOMECOMPRADOR]", NotaFiscal.Entidade.CodigoContaDeposito));
			}
			if (texto.Contains("[RETENCAOPIS]"))
			{
				texto.Replace("[RETENCAOPIS]", NotaFiscal.ValorPISRetido.ToString("N2"));
			}
			if (texto.Contains("[RETENCAOCOFINS]"))
			{
				texto.Replace("[RETENCAOCOFINS]", NotaFiscal.ValorCofinsRetido.ToString("N2"));
			}
			if (texto.Contains("[VALORICMS]"))
			{
				texto.Replace("[VALORICMS]", NotaFiscal.ValorICMS.ToString("N2"));
			}
			if (texto.Contains("[VALORICMSST]"))
			{
				texto.Replace("[VALORICMSST]", NotaFiscal.ValorICMSSubstituto.ToString("N2"));
			}
			if (texto.Contains("[VALORIPI]"))
			{
				texto.Replace("[VALORIPI]", NotaFiscal.ValorIPI.ToString("N2"));
			}
			if (texto.Contains("[VALORCOFINS]"))
			{
				texto.Replace("[VALORCOFINS]", NotaFiscal.ValorCofins.ToString("N2"));
			}
			if (texto.Contains("[VALORPIS]"))
			{
				texto.Replace("[VALORPIS]", NotaFiscal.ValorPIS.ToString("N2"));
			}
			if (texto.Contains("[SUFRAMA]"))
			{
				texto.Replace("[SUFRAMA]", NotaFiscal.Entidade.CodigoSuframa);
			}
			if (texto.Contains("[RETENCAOTOTALPISCOFINS]"))
			{
				texto = texto.Replace("[RETENCAOTOTALPISCOFINS]", (NotaFiscal.ValorCofinsRetido + NotaFiscal.ValorPISRetido).ToString("N2"));
			}
		}
		return texto;
	}

	public static bool GerarNotasPedidosAgrupados(bool SomenteExpedir, bool EnviarSefaz, EntidadeGPS transportadora, IList<PedidoVendaItemGPS> itensPedidoVenda)
	{
		MaxWaitDialog.MostrarMensagem("Informação", "Criando Notas Fiscais");
		if (transportadora != null)
		{
			IDictionary<string, List<FichaExpedicao>> dictionary = new Dictionary<string, List<FichaExpedicao>>();
			IList<int> list = new List<int>();
			foreach (PedidoVendaItemGPS itensPedidoVendum in itensPedidoVenda)
			{
				if (!(itensPedidoVendum.QuantidadeFaturar > 0m))
				{
					continue;
				}
				if (itensPedidoVendum.TarifaRef.CodigoCfopInterna == 0)
				{
					XtraMessageBox.Show($"Item: {itensPedidoVendum.CodigoProduto} Sem CFOP associada!");
					return false;
				}
				if (itensPedidoVendum.TarifaRef.IsBloqueadoFaturamento)
				{
					XtraMessageBox.Show($"Item: {itensPedidoVendum.CodigoProduto} bloqueado para faturamento!");
					return false;
				}
				if (!list.Contains(itensPedidoVendum.CodigoPedido))
				{
					if (itensPedidoVendum.PedidoVenda != null && itensPedidoVendum.PedidoVenda.EntidadeRef != null && itensPedidoVendum.PedidoVenda.EntidadeRef.IsBloqueado)
					{
						XtraMessageBox.Show($"Cliente: {itensPedidoVendum.PedidoVenda.EntidadeRef.CodigoNomeFantasia} bloqueado para faturamento!");
						return false;
					}
					list.Add(itensPedidoVendum.CodigoPedido);
				}
			}
			IList<PedidoVendaGPS> list2 = new List<PedidoVendaGPS>();
			foreach (int item in list)
			{
				PedidoVendaGPS pedidoVendaGPS = ModuloVendasGPS.ObterPedidoVenda(item);
				MaxWaitDialog.FecharMensagem();
				MaxWaitDialog.MostrarMensagem("Ficha Expedição", "Pedido: " + pedidoVendaGPS.CodigoPedidoVenda);
				IList<PedidoVendaItemGPS> list3 = new List<PedidoVendaItemGPS>();
				foreach (PedidoVendaItemGPS itensPedidoVendum2 in itensPedidoVenda)
				{
					if (itensPedidoVendum2.CodigoPedido == item && itensPedidoVendum2.QuantidadeFaturar > 0m && itensPedidoVendum2.TarifaRef.CodigoCfopInterna > 0)
					{
						list3.Add(itensPedidoVendum2);
					}
				}
				pedidoVendaGPS.ItensAFaturar = list3;
				pedidoVendaGPS.Transportadora = transportadora;
				FichaExpedicao fichaExpedicao = ModuloExpedicao.CriarFichaExpedicao(pedidoVendaGPS);
				string text = fichaExpedicao.CodigoEntidade.ToString();
				if (!string.IsNullOrWhiteSpace(fichaExpedicao.PedidoVenda.DocaEntrega))
				{
					text = text + "_" + fichaExpedicao.PedidoVenda.DocaEntrega.ToUpper();
				}
				if (!dictionary.ContainsKey(text))
				{
					dictionary.Add(text, new List<FichaExpedicao>());
				}
				dictionary[text].Add(fichaExpedicao);
			}
			MaxWaitDialog.FecharMensagem();
			if (!SomenteExpedir)
			{
				IList<NotaFiscalNotasFiscais> list4 = new List<NotaFiscalNotasFiscais>();
				int num = 1;
				foreach (List<FichaExpedicao> value in dictionary.Values)
				{
					MaxWaitDialog.MostrarMensagem("Aguarde", $"Gerando Nota {num++} de {dictionary.Count}");
					try
					{
						NotaFiscalNotasFiscais notaFiscalNotasFiscais = new NotaFiscalNotasFiscais();
						foreach (FichaExpedicao item2 in value)
						{
							notaFiscalNotasFiscais.InsereFichaExpedicao(item2.Codigo);
						}
						if (notaFiscalNotasFiscais.Entidade.IsSeparaCFOP)
						{
							bool flag = false;
							string nomeCfop = notaFiscalNotasFiscais.Itens[0].NomeCfop;
							foreach (NotaFiscalNotasFiscaisItens iten in notaFiscalNotasFiscais.Itens)
							{
								if (nomeCfop != iten.NomeCfop)
								{
									flag = true;
								}
							}
							if (!flag)
							{
								list4.Add(notaFiscalNotasFiscais);
								continue;
							}
							IDictionary<string, NotaFiscalNotasFiscais> dictionary2 = new Dictionary<string, NotaFiscalNotasFiscais>();
							foreach (NotaFiscalNotasFiscaisItens iten2 in notaFiscalNotasFiscais.Itens)
							{
								if (dictionary2.ContainsKey(iten2.NomeCfop))
								{
									dictionary2[iten2.NomeCfop].Itens.Add(iten2);
									continue;
								}
								notaFiscalNotasFiscais.FichaExpedicaoRef = null;
								NotaFiscalNotasFiscais notaFiscalNotasFiscais2 = MaxFormUtils.CopyObject(notaFiscalNotasFiscais);
								notaFiscalNotasFiscais.Fatura = null;
								notaFiscalNotasFiscais2.TextoLegal = string.Empty;
								notaFiscalNotasFiscais2.CFOP = iten2.CFOPRef;
								notaFiscalNotasFiscais2.Itens = new List<NotaFiscalNotasFiscaisItens>();
								notaFiscalNotasFiscais2.Itens.Add(iten2);
								dictionary2.Add(iten2.NomeCfop, notaFiscalNotasFiscais2);
							}
							foreach (KeyValuePair<string, NotaFiscalNotasFiscais> item3 in dictionary2)
							{
								item3.Value.AcertaTotais();
								item3.Value.AtualizaTotais();
								list4.Add(item3.Value);
							}
						}
						else
						{
							list4.Add(notaFiscalNotasFiscais);
						}
					}
					catch (Exception ex)
					{
						MaxWaitDialog.FecharMensagem();
						XtraMessageBox.Show(ex.Message, "Erro ao gerar Nota FIscal", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				foreach (NotaFiscalNotasFiscais item4 in list4)
				{
					SalvarNotaFiscalEnviarSefaz(item4, EnviarSefaz);
				}
			}
		}
		else
		{
			XtraMessageBox.Show("Obtrigatório escolher uma transportadora");
		}
		MaxWaitDialog.FecharMensagem();
		XtraMessageBox.Show("Notas Geradas com Sucesso!!!!", "Informação");
		return true;
	}

	public static bool GerarNotasPedidosSeparados(bool SomenteExpedir, bool EnviarSefaz, EntidadeGPS transportadora, IList<PedidoVendaItemGPS> itensPedidoVenda)
	{
		MaxWaitDialog.MostrarMensagem("Informação", "Criando Notas Fiscais");
		itensPedidoVenda = (from c in itensPedidoVenda
			where c.QuantidadeFaturar > 0m
			orderby c.CodigoPedido
			select c).ToList();
		IList<int> list = new List<int>();
		foreach (PedidoVendaItemGPS itensPedidoVendum in itensPedidoVenda)
		{
			if (!(itensPedidoVendum.QuantidadeFaturar > 0m))
			{
				continue;
			}
			if (itensPedidoVendum.TarifaRef != null && itensPedidoVendum.TarifaRef.CodigoCfopInterna == 0 && itensPedidoVendum.CodigoImpostoVenda == 0)
			{
				MaxCaixaMensagem.ShowAtencaoOK($"Item: {itensPedidoVendum.CodigoProduto} Sem CFOP associada!");
				return false;
			}
			if (itensPedidoVendum.TarifaRef != null && itensPedidoVendum.TarifaRef.IsBloqueadoFaturamento)
			{
				MaxCaixaMensagem.ShowAtencaoOK($"Item: {itensPedidoVendum.CodigoProduto} bloqueado para faturamento!");
				return false;
			}
			if (!list.Contains(itensPedidoVendum.CodigoPedido))
			{
				if (itensPedidoVendum.PedidoVenda != null && itensPedidoVendum.PedidoVenda.EntidadeRef != null && itensPedidoVendum.PedidoVenda.EntidadeRef.IsBloqueado)
				{
					MaxCaixaMensagem.ShowAtencaoOK($"Cliente: {itensPedidoVendum.PedidoVenda.EntidadeRef.CodigoNomeFantasia} bloqueado para faturamento!");
					return false;
				}
				list.Add(itensPedidoVendum.CodigoPedido);
			}
		}
		IList<PedidoVendaGPS> list2 = new List<PedidoVendaGPS>();
		foreach (int item in list)
		{
			PedidoVendaGPS pedidoVendaGPS = ModuloVendasGPS.ObterPedidoVenda(item);
			MaxWaitDialog.FecharMensagem();
			MaxWaitDialog.MostrarMensagem("Ficha Expedição", "Pedido: " + pedidoVendaGPS.CodigoPedidoVenda);
			IList<PedidoVendaItemGPS> list3 = new List<PedidoVendaItemGPS>();
			foreach (PedidoVendaItemGPS itensPedidoVendum2 in itensPedidoVenda)
			{
				if (itensPedidoVendum2.CodigoPedido == item && itensPedidoVendum2.QuantidadeFaturar > 0m)
				{
					list3.Add(itensPedidoVendum2);
				}
			}
			pedidoVendaGPS.ItensAFaturar = list3;
			if (transportadora != null)
			{
				pedidoVendaGPS.Transportadora = transportadora;
			}
			else if (pedidoVendaGPS.Transportadora == null && pedidoVendaGPS.EntidadeRef.CodigoTransportadora > 0)
			{
				pedidoVendaGPS.CodigoTransportador = pedidoVendaGPS.EntidadeRef.CodigoTransportadora;
			}
			FichaExpedicao fichaExpedicao = ModuloExpedicao.CriarFichaExpedicao(pedidoVendaGPS);
			MaxWaitDialog.FecharMensagem();
			if (!SomenteExpedir)
			{
				MaxWaitDialog.MostrarMensagem("Nota Fiscal", "Pedido: " + pedidoVendaGPS.CodigoPedidoVenda);
				NotaFiscalNotasFiscais notaFiscalNotasFiscais = new NotaFiscalNotasFiscais();
				notaFiscalNotasFiscais.InsereFichaExpedicao(fichaExpedicao.Codigo);
				if (pedidoVendaGPS.EntidadeRef.IsSeparaCFOP && notaFiscalNotasFiscais.Itens != null && notaFiscalNotasFiscais.Itens.Count > 1)
				{
					SepararNotasPorCFOP(notaFiscalNotasFiscais, EnviarSefaz);
				}
				else
				{
					SalvarNotaFiscalEnviarSefaz(notaFiscalNotasFiscais, EnviarSefaz);
				}
			}
		}
		MaxWaitDialog.FecharMensagem();
		XtraMessageBox.Show("Notas Geradas com Sucesso!!!!", "Informação");
		return true;
	}
}
