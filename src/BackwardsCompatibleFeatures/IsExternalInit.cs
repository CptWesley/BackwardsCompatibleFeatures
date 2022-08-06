using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Provides support for features like records and init in target platforms not officially supporting C# 9.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class IsExternalInit
{
}
