# Imagen base para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar el archivo .csproj
COPY ["PolimericosInventoryAPI.csproj", "./"]

# Restaurar dependencias (ruta corregida aquí)
RUN dotnet restore "PolimericosInventoryAPI.csproj"

# Copiar todo el código fuente
COPY . .

# Establecer el directorio donde se compila
WORKDIR "/src"

# Compilar el proyecto
RUN dotnet build "PolimericosInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PolimericosInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolimericosInventoryAPI.dll"]
