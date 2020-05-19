FROM nginx:alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["MyShop.BlazorFrontend/MyShop.BlazorFrontend.csproj", "MyShop.BlazorFrontend/"]
COPY ["MyShop.ViewModels/MyShop.ViewModels.csproj", "MyShop.ViewModels/"]
RUN dotnet restore "MyShop.BlazorFrontend/MyShop.BlazorFrontend.csproj"

COPY ["MyShop.BlazorFrontend", "MyShop.BlazorFrontend/"]
COPY ["MyShop.ViewModels", "MyShop.ViewModels/"]

WORKDIR /src/MyShop.BlazorFrontend
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet publish -c Release -o ./publish

FROM base AS final

COPY --from=publish ["/src/MyShop.BlazorFrontend/publish/wwwroot", "/usr/share/nginx/html"]
COPY ["MyShop.BlazorFrontend/build/nginx.conf", "/etc/nginx/nginx.conf"]

ENTRYPOINT ["nginx", "-g", "daemon off;"]