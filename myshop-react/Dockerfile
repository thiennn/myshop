FROM nginx:alpine as base
EXPOSE 80

FROM node:14-alpine as build

ARG REACT_APP_BASE_URL
ARG REACT_APP_BACKEND_URL

WORKDIR /app

COPY package.json .
COPY package-lock.json .
RUN npm install

COPY . .
RUN npm run build

FROM base as final
COPY --from=build /app/build /usr/share/nginx/html
COPY build/nginx.conf /etc/nginx/nginx.conf

ENTRYPOINT ["nginx", "-g", "daemon off;"]
