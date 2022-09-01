# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
# EXPOSE 5001
# EXPOSE 5000
# copy csproj and restore as distinct layers
COPY *.sln .
COPY MicroserviceSquare/*.csproj ./MicroserviceSquare/
RUN dotnet restore 
# copy everything else and build app
COPY MicroserviceSquare/. ./MicroserviceSquare/
WORKDIR /app/MicroserviceSquare
RUN dotnet publish -c release -o /src --no-restore
# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /src
COPY --from=build /src ./
ENTRYPOINT ["dotnet", "MicroserviceSquare.dll"]
