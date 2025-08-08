namespace MaxTek.Core.Design;

public class BindableProperty
{
	private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public BindableProperty()
	{
	}

	public BindableProperty(string name, string caption)
	{
		_name = name;
	}
}
