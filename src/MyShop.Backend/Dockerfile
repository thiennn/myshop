FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["MyShop.Backend/MyShop.Backend.csproj", "MyShop.Backend/"]
COPY ["MyShop.ViewModels/MyShop.ViewModels.csproj", "MyShop.ViewModels/"]
RUN dotnet restore "MyShop.Backend/MyShop.Backend.csproj"

COPY ["MyShop.Backend", "MyShop.Backend/"]
COPY ["MyShop.ViewModels", "MyShop.ViewModels/"]

WORKDIR /src/MyShop.Backend
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet publish --no-build -c Release -o ./publish

FROM base AS final
WORKDIR /app
COPY --from=publish ["/src/MyShop.Backend/publish", "."]
ENTRYPOINT ["dotnet", "MyShop.Backend.dll"]
