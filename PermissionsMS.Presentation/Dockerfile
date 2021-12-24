#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PermissionsMS.Presentation/PermissionsMS.Presentation.csproj", "PermissionsMS.Presentation/"]
RUN dotnet restore "PermissionsMS.Presentation/PermissionsMS.Presentation.csproj"
COPY . .
WORKDIR "/src/PermissionsMS.Presentation"
RUN dotnet build "PermissionsMS.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PermissionsMS.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PermissionsMS.Presentation.dll"]