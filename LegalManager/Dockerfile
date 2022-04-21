FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LegalManager/LegalManager.csproj", "LegalManager/"]
RUN dotnet restore "LegalManager/LegalManager.csproj"
COPY . .
WORKDIR "/src/LegalManager"
RUN dotnet build "LegalManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LegalManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LegalManager.dll"]
