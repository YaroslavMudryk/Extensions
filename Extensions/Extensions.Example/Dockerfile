#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Extensions.Example/Extensions.Example.csproj", "Extensions.Example/"]
RUN dotnet restore "Extensions.Example/Extensions.Example.csproj"
COPY . .
WORKDIR "/src/Extensions.Example"
RUN dotnet build "Extensions.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Extensions.Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Extensions.Example.dll"]