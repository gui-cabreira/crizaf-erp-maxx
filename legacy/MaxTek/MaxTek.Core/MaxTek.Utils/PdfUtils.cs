using System;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MaxTek.Utils;

public class PdfUtils
{
	public static PdfDocument MergePDF(PdfDocument[] documentos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		PdfDocument val = new PdfDocument();
		try
		{
			foreach (PdfDocument val2 in documentos)
			{
				CopyPages(val2, val);
			}
			return val;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static void CopyPages(PdfDocument from, PdfDocument to)
	{
		for (int i = 0; i < from.PageCount; i++)
		{
			to.AddPage(from.Pages[i]);
		}
	}

	public static Stream MergePDF(Stream original, Stream[] Adicionais)
	{
		PdfDocument val = PdfReader.Open(original, (PdfDocumentOpenMode)1);
		foreach (Stream stream in Adicionais)
		{
			PdfDocument val2 = PdfReader.Open(stream, (PdfDocumentOpenMode)1);
			CopyPages(val2, val);
		}
		Stream stream2 = new MemoryStream();
		val.Save(stream2);
		return stream2;
	}

	public static Stream MergePDF(Stream original, Stream Adicionais)
	{
		PdfDocument val = PdfReader.Open(original, (PdfDocumentOpenMode)1);
		PdfDocument val2 = PdfReader.Open(Adicionais, (PdfDocumentOpenMode)1);
		CopyPages(val2, val);
		Stream stream = new MemoryStream();
		val.Save(stream);
		stream.Seek(0L, SeekOrigin.Begin);
		return stream;
	}
}
