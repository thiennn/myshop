FROM nginx:alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MyShop.BlazorFrontend/MyShop.BlazorFrontend.csproj", "src/MyShop.BlazorFrontend/"]
COPY ["MyShop.ViewModels/MyShop.ViewModels.csproj", "src/MyShop.ViewModels/"]
RUN dotnet restore "src/MyShop.BlazorFrontend/MyShop.BlazorFrontend.csproj"
COPY . .
WORKDIR /src/MyShop.BlazorFrontend
RUN dotnet build "MyShop.BlazorFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.BlazorFrontend.csproj" -c Release -o /app/publish

FROM base AS final

COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
COPY MyShop.BlazorFrontend/build/nginx.conf /etc/nginx/nginx.conf

ENTRYPOINT ["nginx", "-g", "daemon off;"]