#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
EXPOSE 443
COPY ["WorkshopSchedule/bin/Release/net6.0/publish/","app/"]
WORKDIR /app
ENTRYPOINT ["dotnet", "WorkshopSchedule.dll"]