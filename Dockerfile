FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /Marketplace

COPY . .

RUN dotnet restore ./backend/MarketPlace.API/MarketPlace.API.csproj

RUN dotnet add ./backend/MarketPlace.API/MarketPlace.API.csproj package Npgsql

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

CMD ["dotnet", "run", "--project", "./backend/MarketPlace.API/MarketPlace.API.csproj", "--urls", "http://0.0.0.0:5000"]