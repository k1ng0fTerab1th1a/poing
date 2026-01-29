FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build_stage
WORKDIR /app

COPY --parents ./src/Poing.sln .
COPY --parents ./src/*/*.csproj .
WORKDIR /app/src
RUN dotnet restore

COPY ./src/ .
RUN dotnet publish ./WebApi/WebApi.csproj -c Release -o ../publish/ --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build_stage /app/publish .

ENTRYPOINT ["dotnet", "WebApi.dll"]
