using System;

namespace MaxTek.Core;

[AttributeUsage(AttributeTargets.Field)]
public sealed class NotUndoableAttribute : Attribute
{
}
