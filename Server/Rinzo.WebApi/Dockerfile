# ---------- Stage 1: build ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy only the project files first, then restore. Docker caches this layer, so a
# code-only change does not re-download packages.
COPY Server/Rinzo.sln Server/
COPY Server/Rinzo.Domain/Rinzo.Domain.csproj Server/Rinzo.Domain/
COPY Server/Rinzo.Application/Rinzo.Application.csproj Server/Rinzo.Application/
COPY Server/Rinzo.Infrastructure/Rinzo.Infrastructure.csproj Server/Rinzo.Infrastructure/
COPY Server/Rinzo.WebApi/Rinzo.WebApi.csproj Server/Rinzo.WebApi/
RUN dotnet restore Server/Rinzo.WebApi/Rinzo.WebApi.csproj

# Now copy the source code and publish
COPY Server/Rinzo.Domain/ Server/Rinzo.Domain/
COPY Server/Rinzo.Application/ Server/Rinzo.Application/
COPY Server/Rinzo.Infrastructure/ Server/Rinzo.Infrastructure/
COPY Server/Rinzo.WebApi/ Server/Rinzo.WebApi/
RUN dotnet publish Server/Rinzo.WebApi/Rinzo.WebApi.csproj -c Release -o /app/publish --no-restore /p:UseAppHost=false

# ---------- Stage 2: run ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
USER $APP_UID
EXPOSE 8080
ENTRYPOINT ["dotnet", "Rinzo.WebApi.dll"]
