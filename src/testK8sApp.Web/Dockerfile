FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["testK8sApp.Web/testK8sApp.Web.csproj", "/src/testK8sApp.Web/"]
COPY ["testK8sApp.Data/testK8sApp.Data.csproj", "/src/testK8sApp.Data/"]
COPY ["testK8sApp.Domain/testK8sApp.Domain.csproj", "/src/testK8sApp.Domain/"]
RUN dotnet restore "testK8sApp.Web/testK8sApp.Web.csproj" && \
    dotnet restore "testK8sApp.Data/testK8sApp.Data.csproj" && \
    dotnet restore "testK8sApp.Domain/testK8sApp.Domain.csproj"
COPY . /src/
WORKDIR "/src/testK8sApp.Web"
RUN dotnet build "testK8sApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testK8sApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testK8sApp.Web.dll"]
