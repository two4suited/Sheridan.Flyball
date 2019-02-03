FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Sheridan.Flyball.UI.Web.Api/Sheridan.Flyball.UI.Web.Api.csproj", "src/Sheridan.Flyball.UI.Web.Api/"]
RUN dotnet restore "src/Sheridan.Flyball.UI.Web.Api/Sheridan.Flyball.UI.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Sheridan.Flyball.UI.Web.Api"
RUN dotnet build "Sheridan.Flyball.UI.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sheridan.Flyball.UI.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sheridan.Flyball.UI.Web.Api.dll"]