# Buseon CQRS

Base abstractions to build a framework for Event-Driven with CQRS and Event Sourcing.

## How to generate a nuget package for those two project

### Build the entire solution

```bash
dotnet build --no-restore -c Release
```

or execute
```bash
dotnet pack -c Release -o artifacts
```

This will generate .nupkg files inside the artifacts folder.

- Buseon.Infrastructure.0.1.0.nupkg
- Buseon.Infrastructure.CQRS.0.1.0.nupkg

This .nupkg is the NuGet package.

### Test the package locally

Create a local feed
```bash
mkdir ~/nuget-local
```

Copy the package
```bash
cp bin/Release/*.nupkg ~/nuget-local
```

Add the source
```bash
dotnet nuget add source ~/nuget-local -n local
```

Install package in another project
```bash
dotnet add package Buseon.Infrastructure.CQRS --source local
```

### Now publish/push the packages to Github using your API Key

```bash
dotnet nuget push artifacts/*.nupkg \
--source github \
--api-key <YOUR_GITHUB_TOKEN>
```

Look for the 'Packages' menu on your Github homepage.
