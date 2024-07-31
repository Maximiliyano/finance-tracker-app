FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["FinanceTracker.Api/FinanceTracker.Api.csproj", "FinanceTracker.Api/"]
COPY ["FinanceTracker.Domain/FinanceTracker.Domain.csproj", "FinanceTracker.Domain/"]
COPY ["FinanceTracker.Application/FinanceTracker.Application.csproj", "FinanceTracker.Application/"]
COPY ["FinanceTracker.Infrastructure/FinanceTracker.Infrastructure.csproj", "FinanceTracker.Infrastructure/"]
RUN dotnet restore "FinanceTracker.Api/FinanceTracker.Api.csproj"
COPY . .
WORKDIR "/src/FinanceTracker.Api"
RUN dotnet build "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceTracker.Api.dll"]
