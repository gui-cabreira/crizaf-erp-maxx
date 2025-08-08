namespace MaxTek.Core;

public interface IDynamicAccessor
{
	object this[object target, string propertyName] { get; set; }

	object GetFieldValue(object target, string fieldName);

	object GetPropertyValue(object target, string propertyName);

	void SetFieldValue(object target, string fieldName, object value);

	void SetPropertyValue(object target, string propertyName, object value);
}
