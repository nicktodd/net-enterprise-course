FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64162
EXPOSE 44376

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NetCoreWeb/NetCoreWeb.csproj NetCoreWeb/
RUN dotnet restore NetCoreWeb/NetCoreWeb.csproj
COPY . .
WORKDIR /src/NetCoreWeb
RUN dotnet build NetCoreWeb.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NetCoreWeb.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreWeb.dll"]
