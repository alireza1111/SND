FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PostgresWeb/PostgresWeb/PostgresWeb.csproj", "PostgresWeb/PostgresWeb/"]
RUN dotnet restore "PostgresWeb/PostgresWeb/PostgresWeb.csproj"
COPY . .
WORKDIR "/src/PostgresWeb/PostgresWeb"
RUN dotnet build "PostgresWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PostgresWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostgresWeb.dll"]