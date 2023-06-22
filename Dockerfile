#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image
FROM mysql:latest

# Set MySQL root password
ENV MYSQL_ROOT_PASSWORD=@dm1n@dm1n

# Create database and user
ENV MYSQL_DATABASE=NarutoDB
ENV MYSQL_USER=root
ENV MYSQL_PASSWORD=@dm1n@dm1n

# Copy SQL scripts
COPY init.sql /docker-entrypoint-initdb.d/

# Expose MySQL port
EXPOSE 3306

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAppNarutoDB.csproj", "."]
RUN dotnet restore "./WebAppNarutoDB.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAppNarutoDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppNarutoDB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppNarutoDB.dll"]