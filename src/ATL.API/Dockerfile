FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ATLAPI/ATLAPI.csproj", "ATLAPI/"]
RUN dotnet restore "ATLAPI/ATLAPI.csproj"
COPY . .
WORKDIR "/src/ATLAPI"
RUN dotnet build "ATLAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ATLAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ATLAPI.dll"]