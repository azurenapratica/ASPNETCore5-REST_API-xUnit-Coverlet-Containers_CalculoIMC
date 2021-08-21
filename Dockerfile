FROM mcr.microsoft.com/dotnet/sdk:5.0.400 AS build-env
WORKDIR /app

# Copiar arquivos .csproj e restaurar dependencias
COPY Calculos.Common/Calculos.Common.csproj ./Calculos.Common/
COPY APICalculoIMC/APICalculoIMC.csproj ./APICalculoIMC/
RUN dotnet restore APICalculoIMC/APICalculoIMC.csproj

# Build da aplicacao
COPY . ./
RUN dotnet publish APICalculoIMC/APICalculoIMC.csproj -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0.9
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "APICalculoIMC.dll"]