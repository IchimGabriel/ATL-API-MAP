FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /app

ARG sln=ATLAPI.sln
ARG api=src/ATL.API
ARG configuration=Release
ARG feed='--source "https://api.nuget.org/v3/index.json"'


COPY ${sln} ./
COPY ./${api} ./${api}/

RUN dotnet restore /property:Configuration=${configuration} ${feed}

COPY . ./
RUN dotnet publish ${api} -c ${configuration} -o out ${feed}


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

ARG api=src/ATL.API

COPY --from=builder /app/${api}/out/ .

ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_ENVIRONMENT docker

EXPOSE 5002

ENTRYPOINT dotnet ATLAPI.dll