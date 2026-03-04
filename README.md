# Advanced_dotNet_Web_API_Security_Permission_based_auth_JWT

[![Build](https://github.com/LucasKgarose/Advanced_dotNet_Web_API_Security_Permission_based_auth_JWT/actions/workflows/build.yml/badge.svg)](https://github.com/LucasKgarose/Advanced_dotNet_Web_API_Security_Permission_based_auth_JWT/actions/workflows/build.yml)

Starter solution layout for a layered .NET Web API. Currently includes the default ASP.NET Core Web API template plus placeholder class library projects for Application, Domain, Infrastructure, and Common.

## Requirements
- .NET SDK 10.0 (10.x)

## Project layout
- Application: application services (placeholder)
- Domain: domain models (placeholder)
- Infrastructure: infrastructure adapters (placeholder)
- Common: shared utilities (placeholder)
- WebApi: ASP.NET Core Web API host

## Build
```bash
dotnet restore ABCHR.slnx
dotnet build ABCHR.slnx --configuration Release
```

## Run
```bash
dotnet run --project WebApi/WebApi.csproj
```

## OpenAPI (Development)
When running in Development, the OpenAPI document is available at `/openapi/v1.json`.

## License
MIT. See LICENSE.