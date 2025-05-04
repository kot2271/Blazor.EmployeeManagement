# Blazor Employee Management System

A web-based employee management system built with Blazor, featuring employee CRUD operations and a modern user interface.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) (if running locally)
- [SQL Server](https://www.microsoft.com/sql-server) (if running locally)
- [Docker](https://www.docker.com/products/docker-desktop) (if running with containers)

## Running the Application

### Option 1: Running Locally

1. Ensure SQL Server is running locally with the following connection:
   ```
   Server=localhost,1433
   Database=master
   Initial Catalog=Galaktika.Systems
   User Id=sa
   Password=YourStrong@Passw0rd
   ```

2. Navigate to the project directory:
   ```bash
   cd Blazor.EmployeeManagement
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Access the application:
   - HTTP: http://localhost:5112
   - HTTPS: https://localhost:7090

### Option 2: Running with Docker

1. Navigate to the project directory:
   ```bash
   cd Blazor.EmployeeManagement
   ```

2. Build and start the containers:
   ```bash
   docker-compose up --build
   ```

3. Access the application at http://localhost:5112

The Docker setup includes:
- Web application container
- SQL Server container with persistent volume
- Automatic database initialization

## Project Structure

- `/Pages` - Blazor pages including Employee Table and Details
- `/Components` - Reusable Blazor components
- `/Services` - Business logic and data access
- `/Models` - Data models and DTOs
- `/Areas` - Identity and authentication related pages

## Features

- Employee listing
- Employee details view
- Add new employees
- Delete employees
- Responsive design
- Authentication and authorization

## Development

For development, the application runs in Development mode with detailed error messages and debugging capabilities. You can use either Visual Studio or VS Code for development.

## Database

The application uses SQL Server for data storage. The connection string can be modified in:
- `appsettings.json` for local development
- `docker-compose.yml` for containerized environment