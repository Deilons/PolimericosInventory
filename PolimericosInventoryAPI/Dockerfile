# This Dockerfile is used to build and run the PolimericosInventoryAPI application.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# this stage is used to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PolimericosInventoryAPI/PolimericosInventoryAPI.csproj", "PolimericosInventoryAPI/"]
RUN dotnet restore "PolimericosInventoryAPI/PolimericosInventoryAPI.csproj"
COPY . .
WORKDIR "/src/PolimericosInventoryAPI"
RUN dotnet build "PolimericosInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# this stage is used to publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PolimericosInventoryAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# this stage is used to copy the build output to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolimericosInventoryAPI.dll"]
