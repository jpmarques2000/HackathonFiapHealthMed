#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hackathon.HealthMed.API/Hackathon.HealthMed.API.csproj", "Hackathon.HealthMed.API/"]
COPY ["Hackathon.HealthMed.Services/Hackathon.HealthMed.Services.csproj", "Hackathon.HealthMed.Services/"]
COPY ["Hackathon.HealthMed.Domain/Hackathon.HealthMed.Domain.csproj", "Hackathon.HealthMed.Domain/"]
RUN dotnet restore "./Hackathon.HealthMed.API/Hackathon.HealthMed.API.csproj"
COPY . .
WORKDIR "/src/Hackathon.HealthMed.API"
RUN dotnet build "./Hackathon.HealthMed.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hackathon.HealthMed.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackathon.HealthMed.API.dll"]