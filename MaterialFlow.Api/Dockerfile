FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MaterialFlow.Api/MaterialFlow.Api.csproj", "MaterialFlow.Api/"]
COPY ["MaterialFlow.Infrastructure/MaterialFlow.Infrastructure.csproj", "MaterialFlow.Infrastructure/"]
COPY ["MaterialFlow.Application/MaterialFlow.Application.csproj", "MaterialFlow.Application/"]
COPY ["MaterialFlow.Domain/MaterialFlow.Domain.csproj", "MaterialFlow.Domain/"]
COPY ["MaterialFlow.Presentation/MaterialFlow.Presentation.csproj", "MaterialFlow.Presentation/"]
RUN dotnet restore "./MaterialFlow.Api/MaterialFlow.Api.csproj"
COPY . .
WORKDIR "/src/MaterialFlow.Api"
RUN dotnet build "./MaterialFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MaterialFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/MaterialFlow.Infrastructure/Migrations ./MaterialFlow.Infrastructure/Migrations
ENTRYPOINT ["dotnet", "MaterialFlow.Api.dll"]