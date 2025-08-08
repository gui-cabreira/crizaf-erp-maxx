using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableIndices
{
	public int object_id;

	public int index_id;

	public int column_id;

	public int key_ordinal;

	public int index_column_id;

	public string coluna;

	public string tipo;
}
