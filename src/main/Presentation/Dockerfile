#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/main/Presentation/Presentation.csproj", "src/main/Presentation/"]
COPY ["src/main/Infrastructure/Infrastructure.csproj", "src/main/Infrastructure/"]
COPY ["src/main/Domain/Domain.csproj", "src/main/Domain/"]
COPY ["src/main/Application/Application.csproj", "src/main/Application/"]
RUN dotnet restore "src/main/Presentation/Presentation.csproj"
COPY . .
WORKDIR "/src/src/main/Presentation"
RUN dotnet build "Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]