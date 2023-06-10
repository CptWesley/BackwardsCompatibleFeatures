#if !NET40_OR_GREATER && !NETSTANDARD2_0_OR_GREATER && !NETCOREAPP1_0_OR_GREATER

namespace System.Diagnostics.Contracts;

/// <summary>
/// Indicates that a type or method is pure, that is, it does not make any visible
/// state changes.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
[Conditional("CONTRACTS_FULL")]
public sealed class PureAttribute : Attribute
{
}
#endif
