FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /src
COPY backend/src/AgendaBackend.csproj ./src/
RUN dotnet restore "src/AgendaBackend.csproj"
COPY backend/src/ ./src/
WORKDIR /src
RUN dotnet build "src/AgendaBackend.csproj" -c Release -o /app/build
RUN dotnet publish "src/AgendaBackend.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-backend
WORKDIR /app
COPY --from=build-backend /app/publish .
EXPOSE 5000
ENTRYPOINT ["sh", "-c", "dotnet AgendaBackend.dll"]