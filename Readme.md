# SourceLinkExample

An sample embedding repo and commit sha for Github.

## Setup
The project needs to be inside a github folder and these lines included in the .csproj file:
```
    <PropertyGroup>
        <PublishRepositoryUrl>true</PublishRepositoryUrl>
    </PropertyGroup>
    <ItemGroup>
      <PackageReference Include="Microsoft.SourceLink.GitHub" Version="1.1.1" />
    </ItemGroup>
```

## Execution
The output of the sample is:

```
Repository: https://github.com/tonyredondo/sourcelinktest.git
Commit: {current commit sha}
```