// Modified after: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Runtime/Versioning/PlatformAttributes.cs
// MIT licensed.

namespace System.Runtime.Versioning;

/// <summary>
/// Base type for all platform-specific API attributes.
/// </summary>
public abstract class OSPlatformAltAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OSPlatformAltAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    private protected OSPlatformAltAttribute(string platformName)
    {
        PlatformName = platformName;
    }

    /// <summary>
    /// Gets the targeted platform name.
    /// </summary>
    public string PlatformName { get; }
}

#if !NET5_0_OR_GREATER
/// <summary>
/// Records the platform that the project targeted.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
public sealed class TargetPlatformAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TargetPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public TargetPlatformAttribute(string platformName)
        : base(platformName)
    {
    }
}

/// <summary>
/// Records the operating system (and minimum version) that supports an API. Multiple attributes can be
/// applied to indicate support on multiple operating systems.
/// </summary>
/// <remarks>
/// Callers can apply a <see cref="SupportedOSPlatformAttribute " />
/// or use guards to prevent calls to APIs on unsupported operating systems.
///
/// A given platform should only be specified once.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Assembly |
    AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Enum |
    AttributeTargets.Event |
    AttributeTargets.Field |
    AttributeTargets.Interface |
    AttributeTargets.Method |
    AttributeTargets.Module |
    AttributeTargets.Property |
    AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = false)]
public sealed class SupportedOSPlatformAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SupportedOSPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public SupportedOSPlatformAttribute(string platformName)
        : base(platformName)
    {
    }
}

/// <summary>
/// Marks APIs that were removed in a given operating system version.
/// </summary>
/// <remarks>
/// Primarily used by OS bindings to indicate APIs that are only available in
/// earlier versions.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Assembly |
    AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Enum |
    AttributeTargets.Event |
    AttributeTargets.Field |
    AttributeTargets.Interface |
    AttributeTargets.Method |
    AttributeTargets.Module |
    AttributeTargets.Property |
    AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = false)]
public sealed class UnsupportedOSPlatformAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedOSPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public UnsupportedOSPlatformAttribute(string platformName)
        : base(platformName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedOSPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    /// <param name="message">The message.</param>
    public UnsupportedOSPlatformAttribute(string platformName, string? message)
        : base(platformName)
    {
        Message = message;
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string? Message { get; }
}
#endif

#if !NET6_0_OR_GREATER
/// <summary>
/// Annotates a custom guard field, property or method with a supported platform name and optional version.
/// Multiple attributes can be applied to indicate guard for multiple supported platforms.
/// </summary>
/// <remarks>
/// Callers can apply a <see cref="SupportedOSPlatformGuardAttribute " /> to a field, property or method
/// and use that field, property or method in a conditional or assert statements in order to safely call platform specific APIs.
///
/// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true,
    Inherited = false)]
public sealed class SupportedOSPlatformGuardAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SupportedOSPlatformGuardAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public SupportedOSPlatformGuardAttribute(string platformName)
        : base(platformName)
    {
    }
}

/// <summary>
/// Annotates the custom guard field, property or method with an unsupported platform name and optional version.
/// Multiple attributes can be applied to indicate guard for multiple unsupported platforms.
/// </summary>
/// <remarks>
/// Callers can apply a <see cref="UnsupportedOSPlatformGuardAttribute " /> to a field, property or method
/// and use that  field, property or method in a conditional or assert statements as a guard to safely call APIs unsupported on those platforms.
///
/// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true,
    Inherited = false)]
public sealed class UnsupportedOSPlatformGuardAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedOSPlatformGuardAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public UnsupportedOSPlatformGuardAttribute(string platformName)
        : base(platformName)
    {
    }
}
#endif

#if !NET7_0_OR_GREATER
/// <summary>
/// Marks APIs that were obsoleted in a given operating system version.
/// </summary>
/// <remarks>
/// Primarily used by OS bindings to indicate APIs that should not be used anymore.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Assembly |
    AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Enum |
    AttributeTargets.Event |
    AttributeTargets.Field |
    AttributeTargets.Interface |
    AttributeTargets.Method |
    AttributeTargets.Module |
    AttributeTargets.Property |
    AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = false)]
public sealed class ObsoletedInOSPlatformAttribute : OSPlatformAltAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObsoletedInOSPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    public ObsoletedInOSPlatformAttribute(string platformName)
        : base(platformName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ObsoletedInOSPlatformAttribute"/> class.
    /// </summary>
    /// <param name="platformName">The name of the targeted platform.</param>
    /// <param name="message">The message.</param>
    public ObsoletedInOSPlatformAttribute(string platformName, string? message)
        : base(platformName)
    {
        Message = message;
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string? Message { get; }

    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    public string? Url { get; set; }
}
#endif