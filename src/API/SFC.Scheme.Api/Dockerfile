#base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL service="SFC.Scheme.Api" author="Kryvoruk Andrii" email="krivorukandrey@gmail.com"
USER root
WORKDIR /app

#restore & build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV HUSKY=False
WORKDIR /source
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["src/API/SFC.Scheme.Api/SFC.Scheme.Api.csproj", "src/API/SFC.Scheme.Api/"]
COPY ["src/Core/SFC.Scheme.Application/SFC.Scheme.Application.csproj", "src/Core/SFC.Scheme.Application/"]
COPY ["src/Core/SFC.Scheme.Domain/SFC.Scheme.Domain.csproj", "src/Core/SFC.Scheme.Domain/"]
COPY ["src/Infrastructure/SFC.Scheme.Infrastructure/SFC.Scheme.Infrastructure.csproj", "src/Infrastructure/SFC.Scheme.Infrastructure/"]
COPY ["src/Infrastructure/SFC.Scheme.Infrastructure.Persistence/SFC.Scheme.Infrastructure.Persistence.csproj", "src/Infrastructure/SFC.Scheme.Infrastructure.Persistence/"]
COPY ["src/Contracts/SFC.Scheme.Contracts/SFC.Scheme.Contracts.csproj", "src/Contracts/SFC.Scheme.Contracts/"]
COPY ["src/Contracts/SFC.Scheme.Messages/SFC.Scheme.Messages.csproj", "src/Contracts/SFC.Scheme.Messages/"]
RUN dotnet restore "./src/API/SFC.Scheme.Api/SFC.Scheme.Api.csproj" --property:HUSKY=$HUSKY
COPY [".", "."]
WORKDIR "/source/src/API/SFC.Scheme.Api"
RUN dotnet build "./SFC.Scheme.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --output /app/build

#publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFC.Scheme.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --property:UseAppHost=false --output /app/publish

#final
FROM base AS final
ARG HTTP_PORT=8080
ARG HTTPS_PORT=8081
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT
ENTRYPOINT ["bash", "entrypoint.sh"]