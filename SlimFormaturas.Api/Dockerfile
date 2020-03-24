#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SlimFormaturas.Api/SlimFormaturas.Api.csproj", "SlimFormaturas.Api/"]
COPY ["SlimFormaturas.Domain/SlimFormaturas.Domain.csproj", "SlimFormaturas.Domain/"]
COPY ["SlimFormaturas.Service/SlimFormaturas.Service.csproj", "SlimFormaturas.Service/"]
COPY ["SlimFormaturas.Infra.Data/SlimFormaturas.Infra.Data.csproj", "SlimFormaturas.Infra.Data/"]
COPY ["SlimFormaturas.Infra.CrossCutting/SlimFormaturas.Infra.CrossCutting.Identity.csproj", "SlimFormaturas.Infra.CrossCutting/"]
COPY ["SlimFormaturas.Infra.CrossCutting.IoC/SlimFormaturas.Infra.CrossCutting.IoC.csproj", "SlimFormaturas.Infra.CrossCutting.IoC/"]
RUN dotnet restore "SlimFormaturas.Api/SlimFormaturas.Api.csproj"
COPY . .
WORKDIR "/src/SlimFormaturas.Api"
RUN dotnet build "SlimFormaturas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SlimFormaturas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=https://*:$PORT dotnet SlimFormaturas.Api.dll
#ENTRYPOINT ["dotnet", "SlimFormaturas.Api.dll"]