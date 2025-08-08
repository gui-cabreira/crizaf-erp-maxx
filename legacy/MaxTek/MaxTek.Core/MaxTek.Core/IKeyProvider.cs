namespace MaxTek.Core;

public interface IKeyProvider<T>
{
	T Key { get; }
}
