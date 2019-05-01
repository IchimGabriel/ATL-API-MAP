FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /app

COPY . .
RUN dotnet publish src/ATL.API -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

COPY --from=builder /app/src/ATL.API/out/ .

ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_ENVIRONMENT docker

EXPOSE 5002

ENTRYPOINT dotnet ATLAPI.dll