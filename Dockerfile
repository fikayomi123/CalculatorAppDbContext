# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
# CHANGED: Switched from Windows Nanoserver to standard Linux ASP.NET 10.0 runtime
FROM ://microsoft.com AS base
WORKDIR /app
# CHANGED: Render routes web traffic through port 10000 by default
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# This stage is used to build the service project
# CHANGED: Switched from Windows Nanoserver to standard Linux .NET 10.0 SDK
FROM ://microsoft.com AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CalculatorAPI/CalculatorApp.API.csproj", "CalculatorAPI/"]
COPY ["CalculatorApp.Service/CalculatorApp.Service.csproj", "CalculatorApp.Service/"]
COPY ["CalculatorMigrations/CalculatorApp.Migrationss.csproj", "CalculatorMigrations/"]
COPY ["CalculatorModel/CalculatorApp.Model.csproj", "CalculatorModel/"]
RUN dotnet restore "./CalculatorAPI/CalculatorApp.API.csproj"
COPY . .
WORKDIR "/src/CalculatorAPI"
# CHANGED: Replaced Windows %BUILD_CONFIGURATION% syntax with Linux $BUILD_CONFIGURATION syntax
RUN dotnet build "./CalculatorApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# CHANGED: Replaced Windows %BUILD_CONFIGURATION% syntax with Linux $BUILD_CONFIGURATION syntax
RUN dotnet publish "./CalculatorApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorApp.API.dll"]
