// Modified after: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Runtime/CompilerServices/CallerArgumentExpressionAttribute.cs
// MIT licensed.

namespace System.Runtime.CompilerServices;

#if !NETCOREAPP3_0_OR_GREATER
/// <summary>
/// Attribute used to indicate that an argument will receive a stringified version
/// of a different argument to the function.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class CallerArgumentExpressionAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute"/> class.
    /// </summary>
    /// <param name="parameterName">The name of the parameter whose argument will be stringified.</param>
    public CallerArgumentExpressionAttribute(string parameterName)
    {
        ParameterName = parameterName;
    }

    /// <summary>
    /// Gets the name of the parameter whose stringified version to obtain.
    /// </summary>
    public string ParameterName { get; }
}
#endif
