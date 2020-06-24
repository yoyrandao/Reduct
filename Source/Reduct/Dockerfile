FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 80
EXPOSE 443

WORKDIR /app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster as build
WORKDIR /src
COPY ["Reduct/Reduct.csproj", "Reduct/"]
COPY ["Reduct.DataAccess/Reduct.DataAccess.csproj", "Reduct.DataAccess/"]
RUN dotnet restore "Reduct.DataAccess/Reduct.DataAccess.csproj"
RUN dotnet restore "Reduct/Reduct.csproj"
COPY . .
WORKDIR "/src/Reduct"
RUN dotnet build "Reduct.csproj" -o /app/build

FROM build as publish
RUN dotnet publish "Reduct.csproj" -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Reduct.dll"]