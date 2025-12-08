FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/JobLeet.WebApi/JobLeet.WebApi.sln", "./"]
COPY ["Server/JobLeet.WebApi/JobLeet.WebApi.csproj", "JobLeet.WebApi/"]
WORKDIR /src/JobLeet.WebApi
RUN dotnet restore "JobLeet.WebApi.csproj"
COPY ./Server/JobLeet.WebApi/. .
RUN dotnet build "JobLeet.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobLeet.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="http://+:8080"
CMD ["dotnet", "JobLeet.WebApi.dll"]