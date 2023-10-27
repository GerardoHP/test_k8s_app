FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./testK8sApp.Web.csproj", "/src/Web/"]
RUN dotnet restore "Web/testK8sApp.Web.csproj"
COPY . /src/Web
WORKDIR "/src/Web"
RUN dotnet build "testK8sApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testK8sApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testK8sApp.Web.dll"]
