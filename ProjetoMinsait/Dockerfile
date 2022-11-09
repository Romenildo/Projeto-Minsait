FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjetoMinsait.csproj", "./"]
RUN dotnet restore "./ProjetoMinsait.csproj"
COPY . .
RUN dotnet build "ProjetoMinsait.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjetoMinsait.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjetoMinsait.dll"]