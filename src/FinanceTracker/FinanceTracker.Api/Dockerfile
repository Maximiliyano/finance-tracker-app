FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY --from=clevercloud/clever-tools /bin/clever /usr/local/bin/clever
COPY ["src/FinanceTracker/FinanceTracker.Api/FinanceTracker.Api.csproj", "FinanceTracker.Api/"]
COPY ["src/FinanceTracker/FinanceTracker.Domain/FinanceTracker.Domain.csproj", "FinanceTracker.Domain/"]
COPY ["src/FinanceTracker/FinanceTracker.Application/FinanceTracker.Application.csproj", "FinanceTracker.Application/"]
COPY ["src/FinanceTracker/FinanceTracker.Infrastructure/FinanceTracker.Infrastructure.csproj", "FinanceTracker.Infrastructure/"]
RUN dotnet restore "FinanceTracker.Api/FinanceTracker.Api.csproj"
COPY . .
WORKDIR "src/FinanceTracker/FinanceTracker.Api"
RUN dotnet build "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

ENV ASPNETCORE_URLS http://+:8080
ENV ASPNETCORE_ENVIRONMENT Production

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceTracker.Api.dll"]