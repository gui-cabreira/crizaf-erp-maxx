using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MaxTek.Core.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("MaxTek.Core.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap add2
	{
		get
		{
			object obj = ResourceManager.GetObject("add2", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap delete2
	{
		get
		{
			object obj = ResourceManager.GetObject("delete2", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap folder_edit
	{
		get
		{
			object obj = ResourceManager.GetObject("folder_edit", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap save_as
	{
		get
		{
			object obj = ResourceManager.GetObject("save_as", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap undo
	{
		get
		{
			object obj = ResourceManager.GetObject("undo", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal Resources()
	{
	}
}
