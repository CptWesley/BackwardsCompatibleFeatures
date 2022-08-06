[![NuGet](https://img.shields.io/nuget/v/BackwardsCompatibleFeatures.svg)](https://www.nuget.org/packages/BackwardsCompatibleFeatures/)  

<img src="https://raw.githubusercontent.com/CptWesley/BackwardsCompatibleFeatures/master/logo.png" width="128" height="128">

# BackwardsCompatibleFeatures
## What is it?
Simple compile-time dependency for allowing the use of `record`s and `init` and various compiler attributes in older .NET versions such as .NET Core 3.0, .NET Standard and .NET Framework 4.5.
If you follow the configuration instructions, this package will not be included if your publish your project.
Meaning that users of your application or consumers of your library, don't even know that you used this and it can't interfere with their usage!

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
