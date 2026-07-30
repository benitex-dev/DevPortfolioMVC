FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY ["src/DevPortfolioMVC.Web/DevPortfolioMVC.Web.csproj", "src/DevPortfolioMVC.Web/"]
RUN dotnet restore "src/DevPortfolioMVC.Web/DevPortfolioMVC.Web.csproj"

COPY . .
RUN dotnet publish "src/DevPortfolioMVC.Web/DevPortfolioMVC.Web.csproj" \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_HTTP_PORTS=8080 \
    DOTNET_EnableDiagnostics=0

EXPOSE 8080

COPY --from=build /app/publish .

USER $APP_UID

ENTRYPOINT ["dotnet", "DevPortfolioMVC.Web.dll"]
