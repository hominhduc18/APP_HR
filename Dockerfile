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
# Thêm các service khác nếu cần thiết (vì bạn có cấu trúc microservices)
COPY src/ItoApp.IdentityService/*.csproj ./src/ItoApp.IdentityService/
COPY src/ItoApp.ApiGateway/*.csproj ./src/ItoApp.ApiGateway/

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

# Render sẽ cung cấp Port qua biến môi trường PORT. 
# Mặc định .NET 8 chạy trên 8080 nếu không cấu hình, 
# nhưng chúng ta sẽ để Render tự quyết định.
ENTRYPOINT ["dotnet", "ItoApp.Api.dll"]
