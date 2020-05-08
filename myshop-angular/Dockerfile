FROM nginx:alpine as base

EXPOSE 80

FROM node:14-alpine as build

WORKDIR /app

COPY package.json .
COPY package-lock.json .
RUN npm install

COPY . .
RUN npm run build

FROM base as final
COPY --from=build /app/dist /usr/share/nginx/html
COPY build/nginx.conf /etc/nginx/nginx.conf

ENTRYPOINT ["nginx", "-g", "daemon off;"]
