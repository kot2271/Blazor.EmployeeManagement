# Use a base image for .NET applications
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Use a build image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Blazor.EmployeeManagement.csproj", "."]
RUN dotnet restore "Blazor.EmployeeManagement.csproj"

# Copy the rest of the application files and build the application
COPY . .
RUN dotnet build "Blazor.EmployeeManagement.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Blazor.EmployeeManagement.csproj" -c Release -o /app/publish

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose both HTTP and HTTPS ports from launchSettings.json
EXPOSE 5112
EXPOSE 7090

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5112;https://+:7090

# Set the entry point to start the application
ENTRYPOINT ["dotnet", "Blazor.EmployeeManagement.dll"]