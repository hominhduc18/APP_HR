# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy solution and project files
COPY *.sln .
COPY src/ItoApp.Api/*.csproj src/ItoApp.Api/
COPY src/ItoApp.Application/*.csproj src/ItoApp.Application/
COPY src/ItoApp.Domain/*.csproj src/ItoApp.Domain/
COPY src/ItoApp.Infrastructure/*.csproj src/ItoApp.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy all source files
COPY . .

# Build and publish
WORKDIR /source/src/ItoApp.Api
RUN dotnet publish -c Release -o /app/out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port (Render uses PORT env variable, ASP.NET Core usually listens on 8080 by default in .NET 8)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ItoApp.Api.dll"]
