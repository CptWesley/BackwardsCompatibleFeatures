[![NuGet](https://img.shields.io/nuget/v/BackwardsCompatibleFeatures.svg)](https://www.nuget.org/packages/BackwardsCompatibleFeatures/)  

<img src="https://raw.githubusercontent.com/CptWesley/BackwardsCompatibleFeatures/master/logo.png" width="128" height="128">

# BackwardsCompatibleFeatures
## What is it?
Simple compile-time dependency for allowing the use of `record`s and `init` and various compiler attributes in older .NET versions such as .NET Core 3.0, .NET Standard and .NET Framework 4.5.
If you follow the configuration instructions, this package will not be included when you publish your project.
Meaning that users of your application or consumers of your library won't even know that you used this and it won't interfere with their usage!

## What features are supported?
| Feature | Language Version | Description | Added In |
| - | - | - | - |
| [Records](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) | 9 | Immutable data objects. | 1.0.0 |
| [Record Structs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) | 10 | Immutable data objects. | 1.0.0 |
| [CallerArgumentExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute) | 10 | Implicitly passes argument name as seperate argument to a function. | 2.0.0 |
| [AllowNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.allownullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [DisallowNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.disallownullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [MaybeNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.maybenullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [NotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [MaybeNullWhenAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.maybenullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [NotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [NotNullIfNotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullifnotnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [MemberNotNullAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.membernotnullattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [MemberNotNullWhenAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.membernotnullwhenattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [DoesNotReturnAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.doesnotreturnattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [DoesNotReturnIfAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.doesnotreturnifattribute) | N/A | Part of [static nullable analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis). | 2.0.0 |
| [TargetPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.targetplatformattribute) | N/A | Part of static platform support analysis. | 2.0.0 |
| [SupportedOSPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.supportedosplatformattribute) | N/A | Part of static platform support analysis. | 2.0.0 |
| [UnsupportedOSPlatformAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.unsupportedosplatformattribute) | N/A | Part of static platform support analysis. | 2.0.0 |
| [SupportedOSPlatformGuardAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.supportedosplatformguardattribute) | N/A | Part of static platform support analysis. | 2.0.0 |
| [UnsupportedOSPlatformGuardAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.versioning.unsupportedosplatformguardattribute) | N/A | Part of static platform support analysis. | 2.0.0 |
| ObsoletedInOSPlatformAttribute | N/A | Part of static platform support analysis. | 2.0.0 |
| [StringSyntaxAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.stringsyntaxattribute) | N/A | Provides a hint to IDEs to provide specific syntax highlighting for string parameters. | 2.1.0 |
| [required modifier](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required) | 11 | Enforces initialisation of properties with `init` during construction. | 2.2.0 |
| [SetsRequiredMembersAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.setsrequiredmembersattribute) | N/A | Marks constructor as setting all `required` properties. | 2.2.0 |
| [PureAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.contracts.pureattribute) | N/A | Marks method as pure (no observable side-effects). | 2.3.0 |

## Where can I get it?
[NuGet](https://www.nuget.org/packages/BackwardsCompatibleFeatures/)

## How do I use it?
First we should add the [dependency](https://www.nuget.org/packages/BackwardsCompatibleFeatures/) to our project.
Next up we should also add the `<LangVersion>10</LangVersion>` tag to the body of the `<PropertyGroup>...</PropertyGroup>` in our `.csproj` file.

Now the slightly more complex part... We are going to set change the asset settings of the dependency to make sure consumers don't depend on this project.

We should change the package import which should look something like this:  
```xml
<PackageReference Include="BackwardsCompatibleFeatures" Version="2.2.0" />
```

To the following:
```xml
<PackageReference Include="BackwardsCompatibleFeatures" Version="2.2.0">
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
    <LangVersion>11</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BackwardsCompatibleFeatures" Version="2.2.0">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>compile</IncludeAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

If you are still struggling, you can take a look at the [example project](https://github.com/CptWesley/BackwardsCompatibleFeatures/tree/master/src/BackwardsCompatibleFeatures.Example).
