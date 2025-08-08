namespace MaxTek.Core;

public interface IUndoableObject
{
	void CopyState();

	void UndoChanges();

	void AcceptChanges();
}
