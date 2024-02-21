# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the solution and project files
COPY Src Src

# TODO
#RUN dotnet test src/Test || exit 1

# Publish the application
RUN dotnet publish Src/BigData.HorseRaces.Api/BigData.HorseRaces.Api.csproj -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Set the environment variable for the URL and port
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

# Set the entry point
ENTRYPOINT ["dotnet", "BigData.HorseRaces.Api.dll"]
