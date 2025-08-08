using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Base;
using DevExpress.XtraSpreadsheet;
using GuerrillaNtp;

namespace MaxTek.Utils;

public static class FuncoesUteis
{
	public static DateTime DecimalToTime(decimal horaDecimal)
	{
		int num = 0;
		int minute = 0;
		if (horaDecimal > 0m)
		{
			try
			{
				num = int.Parse(Math.Floor(horaDecimal).ToString());
				minute = int.Parse(Math.Round((horaDecimal - (decimal)num) * 100m).ToString());
			}
			catch
			{
			}
		}
		return new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, 1, num, minute, 0);
	}

	public static decimal TimeToDecimal(DateTime horaMinuto)
	{
		decimal num = default(decimal);
		bool flag = true;
		return decimal.Parse(((double)horaMinuto.Hour + (double)horaMinuto.Minute * 0.01).ToString());
	}

	public static DateTime GPSDateToDate(decimal datanumerica, bool weekData)
	{
		DateTime result = DateTime.MinValue;
		if (datanumerica.ToString().Length == 9)
		{
			decimal num = Math.Truncate(datanumerica / 65536m);
			decimal num2 = Math.Truncate(datanumerica - num * 65536m);
			decimal num3 = Math.Truncate(num2 / 256m);
			decimal num4 = Math.Truncate(num2 - num3 * 256m);
			result = ((!(num > 0m) || !(num < 9999m) || !(num3 > 0m) || !(num3 < 55m) || !(num4 > 0m) || !(num4 < 32m)) ? DateTime.MinValue : ConverteAnoSemanaDia((int)num, (int)num3, (int)num4));
		}
		else if (datanumerica.ToString().Length > 9)
		{
			decimal num2 = Math.Truncate(datanumerica / 4294967296m);
			decimal num = Math.Truncate(num2 / 65536m);
			num2 = Math.Truncate(num2 - num * 65536m);
			decimal num3 = Math.Truncate(num2 / 256m);
			decimal num4 = Math.Round(num2 - num3 * 256m, 0);
			result = ConverteAnoSemanaDia((int)num, (int)num3, (int)num4);
		}
		return result;
	}

	public static int DateToGPSDate(DateTime data)
	{
		int num = 0;
		num = data.Year * 65536;
		num += WeekOfYear(data) * 256;
		return (int)(num + data.DayOfWeek);
	}

	public static long DateToGPSDate18(DateTime data)
	{
		return DateToGPSDate(data) * 4294967296L;
	}

	public static TimeSpan HoraMinuto(decimal horaCentesimal)
	{
		TimeSpan timeSpan = default(TimeSpan);
		decimal num = Math.Truncate(horaCentesimal);
		decimal num2 = horaCentesimal - num;
		decimal num3 = Math.Truncate(num2 * 60m);
		decimal num4 = Math.Truncate((num2 * 60m - (decimal)(int)num3) * 60m);
		return new TimeSpan((int)num, (int)num3, (int)num4);
	}

	public static decimal HoraCentesimal(decimal horaMinuto)
	{
		int num = 0;
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		decimal num4 = default(decimal);
		decimal num5 = default(decimal);
		num = (int)horaMinuto;
		num2 = Math.Floor((horaMinuto - (decimal)num) * 100m);
		num3 = Math.Floor(((horaMinuto - (decimal)num) * 100m - num2) * 100m);
		if (num2 > 0m)
		{
			num4 = num2 / 60m;
		}
		if (num3 > 0m)
		{
			num4 += num3 / 3600m;
		}
		return (decimal)num + num4;
	}

	public static decimal HoraMinutoCentesimal(decimal horaCentesimal)
	{
		int num = 0;
		decimal num2 = default(decimal);
		num = (int)horaCentesimal;
		num2 = (horaCentesimal - (decimal)num) * 0.6m;
		return (decimal)num + num2;
	}

	public static decimal HoraCentesimal(TimeSpan horaMinuto)
	{
		int num = 0;
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		decimal num4 = default(decimal);
		decimal num5 = default(decimal);
		decimal num6 = default(decimal);
		num = horaMinuto.Hours + horaMinuto.Days * 24;
		num2 = horaMinuto.Minutes;
		num3 = num2 / 60m;
		num5 = horaMinuto.Seconds;
		num6 = num5 / 60m / 100m;
		return (decimal)num + num3 + num6;
	}

	public static int H_MIN(DateTime data)
	{
		decimal num = (decimal)data.Minute / 256m;
		decimal num2 = data.Hour;
		decimal num3 = num + num2;
		decimal num4 = num3 * 256m;
		return (int)num4;
	}

	public static TimeSpan ConverterDeH_MIN(int horaH_Min)
	{
		int hours = (int)Math.Floor((decimal)(horaH_Min / 256));
		int minutes = horaH_Min % 256;
		return new TimeSpan(hours, minutes, 0);
	}

	public static int S_CENT(DateTime data)
	{
		int num = data.Millisecond * 256;
		return data.Second * 16777216 + num;
	}

	public static DateTime ConverterDatasGPS(DateTime data, int H_MN, int Sec_Cent)
	{
		int hour = (int)Math.Floor((decimal)(H_MN / 256));
		int num = H_MN % 256;
		int second = Sec_Cent / 16777216;
		decimal num2 = Sec_Cent % 16777216;
		int millisecond = (int)Math.Floor(num2 / 256m);
		if (num == 60)
		{
			num = 59;
		}
		return new DateTime(data.Year, data.Month, data.Day, hour, num, second, millisecond);
	}

	public static int WeeksInYear(DateTime date)
	{
		GregorianCalendar gregorianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
		return gregorianCalendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}

	public static int WeekOfYear(DateTime date)
	{
		bool flag = false;
		int dayOfYear = date.DayOfYear;
		int num = (int)new DateTime(date.Year, 1, 1).DayOfWeek;
		int num2 = (int)new DateTime(date.Year, 12, 31).DayOfWeek;
		if (num == 0)
		{
			num = 7;
		}
		if (num2 == 0)
		{
			num2 = 7;
		}
		int num3 = 8 - num;
		int num4 = 8 - num2;
		if (num == 4 || num2 == 4)
		{
			flag = true;
		}
		int num5 = (int)Math.Ceiling((double)(dayOfYear - num3) / 7.0);
		int num6 = num5;
		if (num3 >= 4)
		{
			num6++;
		}
		if (num6 > 52 && !flag)
		{
			num6 = 1;
		}
		if (num6 == 0)
		{
			num6 = WeekOfYear(new DateTime(date.Year - 1, 12, 31));
		}
		return num6;
	}

	public static DateTime ConverteAnoSemanaDia(int ano, int semana, int dia)
	{
		DateTime dateTime = new DateTime(ano, 1, 1);
		int num = (int)(4 - dateTime.DayOfWeek);
		DateTime time = dateTime.AddDays(num);
		Calendar calendar = CultureInfo.CurrentCulture.Calendar;
		int weekOfYear = calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		int num2 = semana;
		if (weekOfYear <= 1)
		{
			num2--;
		}
		return time.AddDays(num2 * 7).AddDays(dia).AddDays(-4.0);
	}

	public static string PrimeiraLetraMaiuscula(string palavra)
	{
		if (string.IsNullOrEmpty(palavra))
		{
			return string.Empty;
		}
		string text = palavra[0].ToString().ToUpper();
		if (palavra.Length > 1)
		{
			text += palavra.Substring(1).ToLower();
		}
		return text;
	}

	public static string LimparNro(string valor)
	{
		string text = string.Empty;
		if (valor != null)
		{
			for (int i = 0; i < valor.Length; i++)
			{
				char c = valor[i];
				if (char.IsDigit(c))
				{
					text += c;
				}
			}
		}
		return text;
	}

	public static void SepararNumeroEndereco(string enderecoCompleto, out string endereco, out string numero)
	{
		numero = string.Empty;
		endereco = string.Empty;
		int num = enderecoCompleto.Length - 1;
		while (num >= 0 && char.IsDigit(enderecoCompleto[num]))
		{
			numero = enderecoCompleto[num] + numero;
			num--;
		}
		endereco = enderecoCompleto.Substring(0, enderecoCompleto.Length - numero.Length);
	}

	public static IList<string[]> LerArquivoTexto(string nomeArquivo)
	{
		using StreamReader streamReader = new StreamReader(nomeArquivo);
		IList<string[]> list = new List<string[]>();
		string text = null;
		while ((text = streamReader.ReadLine()) != null)
		{
			string[] item = text.Split(';');
			list.Add(item);
		}
		streamReader.Close();
		return list;
	}

	public static int ConverterDelaiParaDia(int delai)
	{
		int num = (int)Math.Round((decimal)delai / 256m, 0);
		return delai - num * 256 + num * 7;
	}

	public static int ConverterDiaparaDelai(int dias)
	{
		decimal num = dias / 7;
		decimal num2 = dias % 7;
		return (int)Math.Round(num * 256m + num2, 0);
	}

	public static int[] ConverterDelaiparaAnoSemanaDia(int delai)
	{
		int num = (int)Math.Floor((decimal)(delai / 65536));
		int num2 = delai % 65536;
		int num3 = (int)Math.Floor((decimal)(num2 / 256));
		int num4 = num2 % 256;
		return new int[3] { num, num3, num4 };
	}

	public static int ConverterAnoSemanaDiaparaDelai(int ano, int semana, int dia)
	{
		return ano * 65536 + semana * 256 + dia;
	}

	public static string ObterDescricaoEnum(Enum value)
	{
		FieldInfo field = value.GetType().GetField(value.ToString());
		string result = string.Empty;
		if (field != null)
		{
			DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
			result = ((array.Length != 0) ? array[0].Description : value.ToString());
		}
		return result;
	}

	public static string DecimalParaBinario(int numero, int noCaracteres)
	{
		string text = "";
		int num = Convert.ToInt32(numero);
		if (num == 0 || num == 1)
		{
			return InverterString(num.ToString(), noCaracteres);
		}
		while (num > 0)
		{
			text += Convert.ToString(num % 2);
			num /= 2;
		}
		return InverterString(text, noCaracteres);
	}

	public static int BinarioParaDecimal2(string valorBinario)
	{
		return Convert.ToInt32(valorBinario, 2);
	}

	private static string InverterString(string str, int noCaracteres)
	{
		int length = str.Length;
		char[] array = new char[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = str[length - 1 - i];
		}
		return new string(array).PadLeft(noCaracteres, '0');
	}

	public static byte[] GerarBinarioDeStream(Stream stream)
	{
		stream.Position = 0L;
		byte[] array = new byte[stream.Length];
		for (int i = 0; i < stream.Length; i += stream.Read(array, i, Convert.ToInt32(stream.Length) - i))
		{
		}
		return array;
	}

	public static Stream GerarStreamDeBinario(byte[] stream)
	{
		return new MemoryStream(stream);
	}

	public static string ConverterStringBinario(byte[] textoBinario)
	{
		string result = string.Empty;
		try
		{
			if (textoBinario != null)
			{
				result = Encoding.UTF8.GetString(textoBinario);
			}
		}
		catch
		{
		}
		return result;
	}

	public static byte[] ConverterStringBinario(string textoParaBinario)
	{
		return Encoding.UTF8.GetBytes(textoParaBinario);
	}

	public static TimeSpan DiferençaRelogioWebLocal()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		try
		{
			NtpClient val = new NtpClient(Dns.GetHostAddresses("br.pool.ntp.org")[0], 123);
			try
			{
				return val.GetCorrectionOffset();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception)
		{
			return TimeSpan.Zero;
		}
	}

	public static DataTable LerExcel()
	{
		return LerExcel(valor: false);
	}

	public static DataTable LerExcel(bool valor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		XtraOpenFileDialog val = new XtraOpenFileDialog();
		((FileDialogBase)val).Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
		((XtraCommonDialog)val).Title = "Escolha o arquivo";
		if (((CommonDialog)(object)val).ShowDialog() == DialogResult.OK)
		{
			string fileName = ((FileDialogBase)val).FileName;
			SpreadsheetControl val2 = new SpreadsheetControl();
			val2.LoadDocument(fileName);
			DataTable dataTable = ConvertExcelToDataTable(val2.ActiveWorksheet, _useFirstRowAsColumns: true, valor);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				return dataTable;
			}
		}
		return null;
	}

	public static DataTable LerExcel(bool valor, string nomePlanilha)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		XtraOpenFileDialog val = new XtraOpenFileDialog();
		((FileDialogBase)val).Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
		((XtraCommonDialog)val).Title = "Escolha o arquivo";
		if (((CommonDialog)(object)val).ShowDialog() == DialogResult.OK)
		{
			string fileName = ((FileDialogBase)val).FileName;
			SpreadsheetControl val2 = new SpreadsheetControl();
			val2.LoadDocument(fileName);
			try
			{
				Worksheet source = val2.Document.Worksheets[nomePlanilha];
				DataTable dataTable = ConvertExcelToDataTable(source, _useFirstRowAsColumns: true, valor);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					return dataTable;
				}
			}
			catch (Exception)
			{
			}
		}
		return null;
	}

	public static DataTable ConvertExcelToDataTable(Worksheet _source, bool _useFirstRowAsColumns)
	{
		return ConvertExcelToDataTable(_source, _useFirstRowAsColumns, valor: false);
	}

	public static DataTable ConvertExcelToDataTable(Worksheet _source, bool _useFirstRowAsColumns, bool valor)
	{
		DataTable dataTable = new DataTable();
		CellRange usedRange = _source.GetUsedRange();
		int num = 0;
		if (_useFirstRowAsColumns)
		{
			num = 1;
		}
		for (int i = 0; i < usedRange.ColumnCount; i++)
		{
			if (_useFirstRowAsColumns)
			{
				dataTable.Columns.Add(((CellRange)_source.Cells)[0, i].DisplayText.Trim());
			}
			else
			{
				dataTable.Columns.Add($"Column{i}");
			}
		}
		for (int j = num; j < usedRange.RowCount; j++)
		{
			DataRow dataRow = dataTable.NewRow();
			for (int k = 0; k < usedRange.ColumnCount; k++)
			{
				if (valor)
				{
					dataRow[k] = ((CellRange)((CellRange)_source.Cells)[j, k]).Value;
				}
				else
				{
					dataRow[k] = ((CellRange)_source.Cells)[j, k].DisplayText.Trim();
				}
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	public static DataTable ConvertExcelToDataTable(Worksheet _source, int _linhaNomeColuna)
	{
		return ConvertExcelToDataTable(_source, _linhaNomeColuna, valor: false);
	}

	public static DataTable ConvertExcelToDataTable(Worksheet _source, int _linhaNomeColuna, bool valor)
	{
		DataTable dataTable = new DataTable();
		CellRange usedRange = _source.GetUsedRange();
		int num = _linhaNomeColuna;
		for (int i = 0; i < usedRange.ColumnCount; i++)
		{
			dataTable.Columns.Add(((CellRange)_source.Cells)[num, i].DisplayText.Trim());
		}
		num++;
		for (int j = num; j < usedRange.RowCount; j++)
		{
			DataRow dataRow = dataTable.NewRow();
			for (int k = 0; k < usedRange.ColumnCount; k++)
			{
				if (valor)
				{
					dataRow[k] = ((CellRange)((CellRange)_source.Cells)[j, k]).Value;
				}
				else
				{
					dataRow[k] = ((CellRange)_source.Cells)[j, k].DisplayText.Trim();
				}
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}
}
