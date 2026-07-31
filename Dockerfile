# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM ://microsoft.com AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# This stage is used to build the service project
FROM ://microsoft.com AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all project files explicitly
COPY ["CalculatorAPI/CalculatorApp.API.csproj", "CalculatorAPI/"]
COPY ["CalculatorApp.Service/CalculatorApp.Service.csproj", "CalculatorApp.Service/"]
COPY ["CalculatorMigrations/CalculatorApp.Migrationss.csproj", "CalculatorMigrations/"]
COPY ["CalculatorModel/CalculatorApp.Model.csproj", "CalculatorModel/"]

# Run restore directly on the project
RUN dotnet restore "CalculatorAPI/CalculatorApp.API.csproj"
COPY . .
WORKDIR "/src/CalculatorAPI"
RUN dotnet build "CalculatorApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CalculatorApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production
FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorApp.API.dll"]
