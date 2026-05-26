# ─────────────────────────────────────────────
# STAGE 1: Build
# Usamos a imagem SDK para compilar o projeto
# ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos apenas o .csproj primeiro para aproveitar o cache do Docker
# (Se as dependências não mudarem, o restore não roda de novo)
COPY AutoPrime.API/AutoPrime.API.csproj AutoPrime.API/
RUN dotnet restore AutoPrime.API/AutoPrime.API.csproj

# Agora copiamos o restante do código
COPY . .

# Publicamos a aplicação em modo Release
RUN dotnet publish AutoPrime.API/AutoPrime.API.csproj \
    -c Release \
    -o /app/publish

# ─────────────────────────────────────────────
# STAGE 2: Runtime
# Imagem menor, apenas para executar
# ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Variáveis de ambiente padrão para o container
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

# Copiamos apenas os artefatos compilados
COPY --from=build /app/publish .

EXPOSE 5000

ENTRYPOINT ["dotnet", "AutoPrime.API.dll"]
