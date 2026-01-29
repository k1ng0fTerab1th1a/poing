FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

COPY ./Poing.sln .
COPY --parents ./*/*.csproj .

RUN dotnet restore

COPY . .

ENTRYPOINT ["dotnet", "run", "--no-launch-profile", "--project", "./WebApi/WebApi.csproj"]