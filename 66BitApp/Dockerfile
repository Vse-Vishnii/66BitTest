#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["66BitApp/66BitApp.csproj", "66BitApp/"]
RUN dotnet restore "66BitApp/66BitApp.csproj"
COPY . .
WORKDIR "/src/66BitApp"
RUN dotnet build "66BitApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "66BitApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "66BitApp.dll"]