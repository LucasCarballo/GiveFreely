FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GiveFreely.WebAPI/GiveFreely.WebAPI.csproj", "GiveFreely.WebAPI/"]
RUN dotnet restore "GiveFreely.WebAPI/GiveFreely.WebAPI.csproj"
COPY . .
WORKDIR "/src/GiveFreely.WebAPI"
RUN dotnet build "GiveFreely.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GiveFreely.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "GiveFreely.WebAPI.dll" ]