#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WorkshopSchedule/WorkshopSchedule.csproj", "WorkshopSchedule/"]
COPY ["SharedResources/SharedResources.csproj", "SharedResources/"]
RUN dotnet restore "WorkshopSchedule/WorkshopSchedule.csproj"
COPY . .
WORKDIR "/src/WorkshopSchedule"
RUN dotnet build "WorkshopSchedule.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkshopSchedule.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkshopSchedule.dll"]
