FROM node:16 AS build-frontend
WORKDIR /app
COPY package*.json .
COPY ../.env ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:alpine AS runtime-frontend
COPY --from=build-frontend /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
