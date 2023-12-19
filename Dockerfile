#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UMBIT.UsersBlogs.API/UMBIT.UsersBlogs.API.csproj", "UMBIT.UsersBlogs.API/"]
COPY ["Building Blocks/core/UMBIT.Prototico.Core.API/UMBIT.Prototico.Core.API.csproj", "Building Blocks/core/UMBIT.Prototico.Core.API/"]
COPY ["Building Blocks/core/UMBIT.Prototico.Core/UMBIT.Prototico.Core.csproj", "Building Blocks/core/UMBIT.Prototico.Core/"]
COPY ["UMBIT.UsersBlogs.API.Mappers/UMBIT.UsersBlogs.API.Mappers.csproj", "UMBIT.UsersBlogs.API.Mappers/"]
COPY ["UMBIT.UsersBlogs.API.Contracts/UMBIT.UsersBlogs.API.Contracts.csproj", "UMBIT.UsersBlogs.API.Contracts/"]
COPY ["UMBIT.UsersBlogs.Dominio/UMBIT.UsersBlogs.Dominio.csproj", "UMBIT.UsersBlogs.Dominio/"]
COPY ["UMBIT.UsersBlogs.Infra/UMBIT.UsersBlogs.Infra.csproj", "UMBIT.UsersBlogs.Infra/"]
RUN dotnet restore "./UMBIT.UsersBlogs.API/./UMBIT.UsersBlogs.API.csproj"
COPY . .
WORKDIR "/src/UMBIT.UsersBlogs.API"
RUN dotnet build "./UMBIT.UsersBlogs.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UMBIT.UsersBlogs.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UMBIT.UsersBlogs.API.dll"]