FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8000 8001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/FinanceTracker/FinanceTracker.Api/FinanceTracker.Api.csproj", "FinanceTracker.Api/"]
COPY ["src/FinanceTracker/FinanceTracker.Domain/FinanceTracker.Domain.csproj", "FinanceTracker.Domain/"]
COPY ["src/FinanceTracker/FinanceTracker.Application/FinanceTracker.Application.csproj", "FinanceTracker.Application/"]
COPY ["src/FinanceTracker/FinanceTracker.Infrastructure/FinanceTracker.Infrastructure.csproj", "FinanceTracker.Infrastructure/"]

RUN dotnet restore "FinanceTracker.Api/FinanceTracker.Api.csproj"

COPY . .
WORKDIR "src/FinanceTracker/FinanceTracker.Api"
RUN dotnet build "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS="http://+:8000;https://+:8001"

ENTRYPOINT ["dotnet", "FinanceTracker.Api.dll"]
