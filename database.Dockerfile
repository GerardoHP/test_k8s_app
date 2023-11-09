FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["testK8sApp.Web/testK8sApp.Web.csproj", "/src/testK8sApp.Web/"]
COPY ["testK8sApp.Data/testK8sApp.Data.csproj", "/src/testK8sApp.Data/"]
COPY ["testK8sApp.Domain/testK8sApp.Domain.csproj", "/src/testK8sApp.Domain/"]
RUN dotnet restore "testK8sApp.Web/testK8sApp.Web.csproj" && \
    dotnet restore "testK8sApp.Data/testK8sApp.Data.csproj"&& \
    dotnet restore "testK8sApp.Domain/testK8sApp.Domain.csproj"
COPY . /src/
WORKDIR "/src"
RUN dotnet tool install --global dotnet-ef 
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations script --output migration.sql --idempotent \
    --project testK8sApp.Data/testK8sApp.Data.csproj \
    --startup-project testK8sApp.Web/testK8sApp.Web.csproj 

FROM postgres:alpine3.18
COPY --from=build /src/migration.sql /docker-entrypoint-initdb.d/