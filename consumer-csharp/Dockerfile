# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Crear nuevo proyecto consola sin restaurar aún
RUN dotnet new console -n App --no-restore

# Entrar al proyecto y copiar el código
WORKDIR /src/App
COPY Consumer.cs .

# Remover el Program.cs generado automáticamente
RUN rm Program.cs

# Agregar paquete RabbitMQ.Client versión 6.4.0
RUN dotnet add package RabbitMQ.Client --version 6.4.0

# Compilar en modo Release
RUN dotnet build -c Release

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app

# Copiar binario desde la etapa anterior
COPY --from=build /src/App/bin/Release/net6.0/ ./

# Comando de ejecución
ENTRYPOINT ["dotnet", "App.dll"]
