# First and foremost

This project is a fork of this boilerplate: (https://github.com/yanpitangui/dotnet-api-boilerplate). Thank you Yan Pitangui for making my life easier.

# How to run

- Download the latest .Net SDK (https://dotnet.microsoft.com/download/dotnet/5.0) and Visual Studio or Visual Studio Code.

## Standalone

1. You have three choices when it comes to the database:

- Install SQL Express and run on an actual database server (https://go.microsoft.com/fwlink/?linkid=866658)
- If you want, you can change the DatabaseExtension.cs file to use UseInMemoryDatabase instead of MsSql.
- You can run just the DB on docker. For that, you have to change your connection string to "Server=127.0.0.1;Database=master;User=sa;Password=Yourpassword123” and
  run the following command: docker-compose up -d db-server. Doing that, the application will be able to reach de container of the db server. I am unsure if this works
  for reasons that will be mentioned later.

2. Go to the src/Boilerplate.Api folder and run `dotnet run`, or, in visual studio set the api project as startup and
   run as console or docker (not IIS).
3. Visit http://localhost:5000/api-docs or https://localhost:5001/api-docs to access the application's swagger.

## Docker

1. The boilerplate from which I forked this code supports docker-compose, but I was not able to make it run on my machine due to my hardware not supporting HyperV virtualization (I tried really hard I promise). Use at your own risk :)
2. Run `docker-compose up -d` in the root directory, or, in visual studio, set the docker-compose project as startup
   and run. This should start the application and DB.

- For docker-compose, you should run this command on the root
  folder: `dotnet dev-certs https -ep https/aspnetapp.pfx -p yourpassword`
  Replace "yourpassword" with something else in this command and the docker-compose.override.yml file. This creates
  the https certificate.

3. Visit http://localhost:5000/api-docs or https://localhost:5001/api-docs to access the application's swagger.

## Running tests

In the root folder, run `dotnet test`. This command will try to find all test projects associated with the sln file.

# This project contains:

- SwaggerUI
- EntityFramework
- AutoMapper
- Generic repository (to easily bootstrap a CRUD repository)
- Serilog with request logging and easily configurable sinks
- .Net Dependency Injection
- Resource filtering
- Response compression
- Response pagination
- CI (Github Actions)
- Unit tests
- Integration tests
- Container support with [docker](src/Boilerplate.Api/dockerfile) and [docker-compose](docker-compose.yml)

# Project Structure

1. Services

   - This folder stores your apis and any project that sends data to your users.

   1. Boilerplate.Api
      - This is the main api project. Here are all the controllers and initialization for the api that will be used.
   2. docker-compose
      - This project exists to allow you to run docker-compose with Visual Studio. It contains a reference to the
        docker-compose file and will build all the projects dependencies and run it.

2. Application
   - This folder stores all data transformations between your api and your domain layer. It also contains your business
     logic.
3. Domain

   - This folder contains your business models, enums and common interfaces.

   1. Boilerplate.Domain.Core
      - Contains the base entity for all other domain entities, as well as the interface for the repository
        implementation.
   1. Boilerplate.Domain
      - Contains business models and enums.

4. Infra

   - This folder contains all data access repositories, database contexts, anything that reaches for outside data.

   1. Boilerplate.Infrastructure
      - This project contains the dbcontext, an generic implementation of repository pattern and a Hero(domain class)
        repository.

# Migrations

1. To run migrations on this project, run the following command on the root folder:

   - `dotnet ef migrations add InitialCreate --startup-project .\src\Boilerplate.Api\ --project .\src\Boilerplate.Infrastructure\`

2. This command will set the entrypoint for the migration (the responsible to selecting the dbprovider { sqlserver,
   mysql, etc } and the connection string) and the project itself will be the infrastructure, which is where the
   dbcontext is.

# About

This boilerplate/template was developed by Yan Pitangui under [MIT license](LICENSE).
