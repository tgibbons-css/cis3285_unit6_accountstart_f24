FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["cis3285_unit6_accountstart_f24/cis3285_unit6_accountstart_f24.csproj", "cis3285_unit6_accountstart_f24/"]
RUN dotnet restore "cis3285_unit6_accountstart_f24/cis3285_unit6_accountstart_f24.csproj"

COPY . .
WORKDIR "/src/cis3285_unit6_accountstart_f24"
RUN dotnet build "cis3285_unit6_accountstart_f24.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "cis3285_unit6_accountstart_f24.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cis3285_unit6_accountstart_f24.dll"]
