FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build

COPY . ./
WORKDIR /src/ATL.API
RUN dotnet build ATLAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ATLAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5000
ENTRYPOINT ["dotnet", "ATLAPI.dll"]