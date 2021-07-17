#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Customers.Service/Customers.Service.csproj", "Services/Customers.Service/"]
COPY ["Services/Customers.Data/Customers.Data.csproj", "Services/Customers.Data/"]
RUN dotnet restore "Services/Customers.Service/Customers.Service.csproj"
COPY . .
WORKDIR "/src/Services/Customers.Service"
RUN dotnet build "Customers.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Service.dll"]