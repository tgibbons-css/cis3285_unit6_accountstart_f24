FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["cis3285_unit6_accountstart_f24/cis3285_unit6_accountstart_f24.csproj", "cis3285_unit6_accountstart_f24/"]
RUN dotnet restore "cis3285_unit6_accountstart_f24/cis3285_unit6_accountstart_f24.csproj"
COPY . .
WORKDIR "/src/cis3285_unit6_accountstart_f24"
RUN dotnet build "cis3285_unit6_accountstart_f24.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "cis3285_unit6_accountstart_f24.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cis3285_unit6_accountstart_f24.dll"]
