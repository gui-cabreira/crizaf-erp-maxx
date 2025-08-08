using System.IO;

namespace MaxTek.Utils;

public class AttachementInfo
{
	private Stream stream;

	private string mimeType;

	private string contentId;

	public Stream Stream => stream;

	public string MimeType => mimeType;

	public string ContentId => contentId;

	public AttachementInfo(Stream stream, string mimeType, string contentId)
	{
		this.stream = stream;
		this.mimeType = mimeType;
		this.contentId = contentId;
	}
}
