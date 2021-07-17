#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Orders.Service/Orders.Service.csproj", "Services/Orders.Service/"]
COPY ["Services/Orders.Data/Orders.Data.csproj", "Services/Orders.Data/"]
RUN dotnet restore "Services/Orders.Service/Orders.Service.csproj"
COPY . .
WORKDIR "/src/Services/Orders.Service"
RUN dotnet build "Orders.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.Service.dll"]