FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Sheridan.Flyball.UI.Web/Sheridan.Flyball.UI.Web.csproj", "src/Sheridan.Flyball.UI.Web/"]
RUN dotnet restore "src/Sheridan.Flyball.UI.Web/Sheridan.Flyball.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/Sheridan.Flyball.UI.Web"
RUN dotnet build "Sheridan.Flyball.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sheridan.Flyball.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sheridan.Flyball.UI.Web.dll"]