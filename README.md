# Buseon CQRS

Base abstractions to built a framework for Event-Driven with CQRS and Event Sourcing.

## How to generate a nuget package for those two project

### Build the entire solution

``` bash
dotnet build --no-restore -c Release
```

or execute
``` bash
dotnet pack -c Release
```

This will generate .nupkg files inside the bin folder of each project.

- Buseon.Infrastructure.0.1.0.nupkg
- Buseon.Infrastructure.CQRS.0.1.0.nupkg

This .nupkg is the NuGet package.

### Now publish to Github using your ApiKey

