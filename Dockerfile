FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY ./src/ATL.API/bin/docker .
ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5002
ENTRYPOINT dotnet ATLAPI.dll