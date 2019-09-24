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

FROM node:8.16.1-alpine AS javascript
WORKDIR /src
COPY ./Geospatial.Web/ .
RUN ls -la
RUN npm install && npm run build
RUN ls -la

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=publish /src/census_shp_files ./census_shp_files
COPY --from=javascript /src/wwwroot/js ./wwwroot/js
RUN ls -la
ENTRYPOINT ["dotnet", "Geospatial.Web.dll"]