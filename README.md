[![NuGet](https://img.shields.io/nuget/v/BackwardsCompatibleRecords.svg)](https://www.nuget.org/packages/BackwardsCompatibleRecords/)  

<img src="https://raw.githubusercontent.com/CptWesley/BackwardsCompatibleRecords/master/logo.png" width="128" height="128">

# BackwardsCompatibleRecords
## What is it?
Simple compile-time dependency for allowing the use of `record`s and `init` in .NET Core 3.0, .NET Standard and .NET Framework 4.5.
If you follow the configuration instructions, this package will not be included if your publish your project.
Meaning that users of your application or consumers of your library, don't even know that you used this and it can't interfere with their usage!

## Where can I get it?
[NuGet](https://www.nuget.org/packages/BackwardsCompatibleRecords/)

## How do I use it?
First we should add the [dependency](https://www.nuget.org/packages/BackwardsCompatibleRecords/) to our project.
Next up we should also add the `<LangVersion>9</LangVersion>` tag to the body of the `<PropertyGroup>...</PropertyGroup>` in our `.csproj` file.

Now the slightly more complex part... We are going to set change the asset settings of the dependency to make sure consumers don't depend on this project.

We should change the package import which should look something like this:  
```xml
<PackageReference Include="BackwardsCompatibleRecords" Version="1.0.0" />
```

To the following:
```xml
<PackageReference Include="BackwardsCompatibleRecords" Version="1.0.0">
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
    <PackageReference Include="BackwardsCompatibleRecords" Version="1.0.0">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>compile</IncludeAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

If you are still struggling, you can take a look at the [example project](https://github.com/CptWesley/BackwardsCompatibleRecords/tree/master/src/BackwardsCompatibleRecords.Example).
