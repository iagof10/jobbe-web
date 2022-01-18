#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["jobbe-web/jobbe-web.csproj", "jobbe-web/"]
RUN dotnet restore "jobbe-web/jobbe-web.csproj"
COPY . .
WORKDIR "/src/jobbe-web"
RUN dotnet build "jobbe-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "jobbe-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "jobbe-web.dll"]