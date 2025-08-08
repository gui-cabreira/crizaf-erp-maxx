using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using DevExpress.Office.Export;
using DevExpress.Office.Services;
using DevExpress.Office.Utils;
using DevExpress.Utils;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Export;

namespace MaxTek.Utils;

public class RichEditMailMessageExporter : IUriProvider
{
	private readonly RichEditControl control;

	private readonly MailMessage message;

	private List<AttachementInfo> attachments;

	private int imageId;

	public RichEditMailMessageExporter(RichEditControl control, MailMessage message)
	{
		Guard.ArgumentNotNull((object)control, "control");
		Guard.ArgumentNotNull((object)message, "message");
		this.control = control;
		this.message = message;
	}

	public virtual void Export()
	{
		attachments = new List<AttachementInfo>();
		AlternateView item = CreateHtmlView();
		message.AlternateViews.Add(item);
		message.IsBodyHtml = true;
	}

	protected internal virtual AlternateView CreateHtmlView()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		control.BeforeExport += new BeforeExportEventHandler(OnBeforeExport);
		string htmlText = ((SubDocument)control.Document).GetHtmlText(((SubDocument)control.Document).Range, (IUriProvider)(object)this);
		AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
		control.BeforeExport -= new BeforeExportEventHandler(OnBeforeExport);
		int count = attachments.Count;
		for (int i = 0; i < count; i++)
		{
			AttachementInfo attachementInfo = attachments[i];
			LinkedResource linkedResource = new LinkedResource(attachementInfo.Stream, attachementInfo.MimeType);
			linkedResource.ContentId = attachementInfo.ContentId;
			alternateView.LinkedResources.Add(linkedResource);
		}
		return alternateView;
	}

	private void OnBeforeExport(object sender, BeforeExportEventArgs e)
	{
		IExporterOptions options = e.Options;
		HtmlDocumentExporterOptions val = (HtmlDocumentExporterOptions)(object)((options is HtmlDocumentExporterOptions) ? options : null);
		if (val != null)
		{
			val.Encoding = Encoding.UTF8;
		}
	}

	public string CreateCssUri(string rootUri, string styleText, string relativeUri)
	{
		return string.Empty;
	}

	public string CreateImageUri(string rootUri, OfficeImage image, string relativeUri)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		string text = $"image{imageId}";
		imageId++;
		OfficeImageFormat actualImageFormat = GetActualImageFormat(image.RawFormat);
		Stream stream = new MemoryStream(image.GetImageBytes(actualImageFormat));
		string contentType = OfficeImage.GetContentType(actualImageFormat);
		AttachementInfo item = new AttachementInfo(stream, contentType, text);
		attachments.Add(item);
		return "cid:" + text;
	}

	private OfficeImageFormat GetActualImageFormat(OfficeImageFormat _officeImageFormat)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if ((int)_officeImageFormat == 3 || (int)_officeImageFormat == 7)
		{
			return (OfficeImageFormat)8;
		}
		return _officeImageFormat;
	}
}
