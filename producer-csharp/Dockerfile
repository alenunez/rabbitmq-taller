# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Crear proyecto e instalar dependencia
RUN dotnet new console -n App --no-restore
WORKDIR /src/App

COPY Producer.cs .
RUN rm Program.cs
RUN dotnet add package RabbitMQ.Client --version 6.4.0

RUN dotnet build -c Release

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /src/App/bin/Release/net6.0 .

CMD ["dotnet", "App.dll"]
