FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Server/Rinzo.sln", "Server/"]
COPY ["Server/Rinzo.Core/Rinzo.Core.csproj", "Server/Rinzo.Core/"]
COPY ["Server/Rinzo.Infrastructure/Rinzo.Infrastructure.csproj", "Server/Rinzo.Infrastructure/"]
COPY ["Server/Rinzo.WebApi/Rinzo.WebApi.csproj", "Server/Rinzo.WebApi/"]
COPY ["Server/Rinzo.Tests/Rinzo.Tests.csproj", "Server/Rinzo.Tests/"]
RUN dotnet restore "Server/Rinzo.WebApi/Rinzo.WebApi.csproj"

COPY Server/Rinzo.Core/ Server/Rinzo.Core/
COPY Server/Rinzo.Infrastructure/ Server/Rinzo.Infrastructure/
COPY Server/Rinzo.WebApi/ Server/Rinzo.WebApi/

WORKDIR /src/Server/Rinzo.WebApi
RUN dotnet build "Rinzo.WebApi.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "Rinzo.WebApi.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="http://+:8080"
ENTRYPOINT ["dotnet", "Rinzo.WebApi.dll"]
