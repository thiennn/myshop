FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MyShop.Backend/MyShop.Backend.csproj", "src/MyShop.Backend/"]
COPY ["MyShop.ViewModels/MyShop.ViewModels.csproj", "src/MyShop.ViewModels/"]
RUN dotnet restore "src/MyShop.Backend/MyShop.Backend.csproj"
COPY . .
WORKDIR /src/MyShop.Backend
RUN dotnet build "MyShop.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyShop.Backend.dll"]
