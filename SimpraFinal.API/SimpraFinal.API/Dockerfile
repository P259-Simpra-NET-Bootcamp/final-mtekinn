FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpraFinal.API/SimpraFinal.API.csproj", "SimpraFinal.API/"]
RUN dotnet restore "SimpraFinal.API/SimpraFinal.API.csproj"
COPY . .
WORKDIR "/src/SimpraFinal.API"
RUN dotnet build "SimpraFinal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpraFinal.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpraFinal.API.dll"]
