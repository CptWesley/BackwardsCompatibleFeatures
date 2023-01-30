[![NuGet](https://img.shields.io/nuget/v/BackwardsCompatibleFeatures.svg)](https://www.nuget.org/packages/BackwardsCompatibleFeatures/)  

<img src="https://raw.githubusercontent.com/CptWesley/BackwardsCompatibleFeatures/master/logo.png" width="128" height="128">

# BackwardsCompatibleFeatures
## What is it?
Simple compile-time dependency for allowing the use of `record`s and `init` and various compiler attributes in older .NET versions such as .NET Core 3.0, .NET Standard and .NET Framework 4.5.
If you follow the configuration instructions, this package will not be included when you publish your project.
Meaning that users of your application or consumers of your library won't even know that you used this and it won't interfere with their usage!

## What features are supported?
| Feature | Language Version | Description |
| - | - | - |
| [Records](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) | 9 | Immutable data objects. |
| [Record Structs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) | 10 | Immutable data objects. |
| [CallerArgumentExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute) | 10 | Implicitly passes argument name as seperate argument to a function. |
| [AllowNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.allownullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [DisallowNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.disallownullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [MaybeNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.maybenullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [NotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [MaybeNullWhenAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.maybenullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [NotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [NotNullIfNotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullifnotnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [MemberNotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.membernotnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [MemberNotNullWhenAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.membernotnullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [DoesNotReturnAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.doesnotreturnattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [DoesNotReturnIfAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.doesnotreturnifattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). |
| [TargetPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.targetplatformattribute) | N/A | Part of static platform support analysis. |
| [SupportedOSPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.supportedosplatformattribute) | N/A | Part of static platform support analysis. |
| [UnsupportedOSPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.unsupportedosplatformattribute) | N/A | Part of static platform support analysis. |
| [SupportedOSPlatformGuardAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.supportedosplatformguardattribute) | N/A | Part of static platform support analysis. |
| [UnsupportedOSPlatformGuardAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.unsupportedosplatformguardattribute) | N/A | Part of static platform support analysis. |
| ObsoletedInOSPlatformAttribute | N/A | Part of static platform support analysis. |
| [StringSyntaxAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.stringsyntaxattribute) | N/A | Provides a hint to IDEs to provide specific syntax highlighting for string parameters. |

## Where can I get it?
[NuGet](https://www.nuget.org/packages/BackwardsCompatibleFeatures/)

## How do I use it?
First we should add the [dependency](https://www.nuget.org/packages/BackwardsCompatibleFeatures/) to our project.
Next up we should also add the `<LangVersion>10</LangVersion>` tag to the body of the `<PropertyGroup>...</PropertyGroup>` in our `.csproj` file.

Now the slightly more complex part... We are going to set change the asset settings of the dependency to make sure consumers don't depend on this project.

We should change the package import which should look something like this:  
```xml
<PackageReference Include="BackwardsCompatibleFeatures" Version="2.0.0" />
```

To the following:
```xml
<PackageReference Include="BackwardsCompatibleFeatures" Version="2.0.0">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>compile</IncludeAssets>
</PackageReference>
```

A full example of a what our project could look like:
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <LangVersion>9</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BackwardsCompatibleFeatures" Version="2.0.0">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>compile</IncludeAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

If you are still struggling, you can take a look at the [example project](https://github.com/CptWesley/BackwardsCompatibleFeatures/tree/master/src/BackwardsCompatibleFeatures.Example).
