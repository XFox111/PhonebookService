# PhonebookService
A small project I've done as job interview task

It is based on Domain-driven Design principles (aka Clean architecture) and uses Docker for containerization

## Build and run
1. Clone the repository
2. Open terminal in the root folder
3. Run `dotnet build` and `dotnet run`

> Make sure you have .NET 6 SDK installed

## Building a Docker image
1. Clone the repository
2. Open terminal in the root folder
3. Run `docker build -t phonebook-service .` to build the image
4. Run `docker run -p 8080:80 --name phonebook-service-container phonebook-service` to run the image
