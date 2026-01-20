# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy solution
COPY *.sln .

# copy project files
COPY NetCoreJwtAuthApi/*.csproj NetCoreJwtAuthApi/
COPY NetCoreJwtAuthApi.Tests/*.csproj NetCoreJwtAuthApi.Tests/

# restore dependencies
RUN dotnet restore

# copy everything else
COPY . .

WORKDIR /app/NetCoreJwtAuthApi
RUN dotnet publish -c Release -o /out


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "NetCoreJwtAuthApi.dll"]


