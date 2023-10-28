FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Web/testK8sApp.Web.csproj", "/src/Web/"]
COPY ["testk8sApp.Data/testk8sApp.Data.csproj", "/src/testk8sApp.Data/"]
RUN dotnet restore "Web/testK8sApp.Web.csproj" && \
    dotnet restore "testk8sApp.Data/testk8sApp.Data.csproj"
COPY . /src/
WORKDIR "/src"
RUN dotnet tool install --global dotnet-ef 
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations script --output migration.sql --idempotent \
    --project testk8sApp.Data/testk8sApp.Data.csproj \
    --startup-project Web/testK8sApp.Web.csproj 

FROM postgres:alpine3.18
COPY --from=build /src/migration.sql /docker-entrypoint-initdb.d/