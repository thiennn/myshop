FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MyShop.Frontend/MyShop.Frontend.csproj", "src/MyShop.Frontend/"]
COPY ["MyShop.ViewModels/MyShop.ViewModels.csproj", "src/MyShop.ViewModels/"]
RUN dotnet restore "src/MyShop.Frontend/MyShop.Frontend.csproj"
COPY . .
WORKDIR /src/MyShop.Frontend
RUN dotnet build "MyShop.Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.Frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyShop.Frontend.dll"]
