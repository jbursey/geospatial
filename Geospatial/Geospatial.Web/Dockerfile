FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Geospatial.Web/Geospatial.Web.csproj", "Geospatial.Web/"]
RUN dotnet restore "Geospatial.Web/Geospatial.Web.csproj"
COPY . .
WORKDIR "/src/Geospatial.Web"
RUN dotnet build "Geospatial.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Geospatial.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Geospatial.Web.dll"]