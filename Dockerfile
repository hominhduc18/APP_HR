# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution file
COPY src/ItoApp.sln ./src/

# Copy all csproj files to preserve folder structure for restore
COPY src/ItoApp.Api/*.csproj ./src/ItoApp.Api/
COPY src/ItoApp.Application/*.csproj ./src/ItoApp.Application/
COPY src/ItoApp.Domain/*.csproj ./src/ItoApp.Domain/
COPY src/ItoApp.Infrastructure/*.csproj ./src/ItoApp.Infrastructure/
COPY src/ItoApp.Test/*.csproj ./src/ItoApp.Test/
COPY src/ItoApp.IdentityService/*.csproj ./src/ItoApp.IdentityService/
COPY src/ItoApp.ApiGateway/*.csproj ./src/ItoApp.ApiGateway/
COPY src/microservices/ItoApp.ApiGateway/*.csproj ./src/microservices/ItoApp.ApiGateway/
COPY src/microservices/ItoApp.Shared/*.csproj ./src/microservices/ItoApp.Shared/

# Restore dependencies
RUN dotnet restore src/ItoApp.sln

# Copy the rest of the source code
COPY . .

# Build and publish the main API project
WORKDIR /app/src/ItoApp.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ItoApp.Api.dll"]
