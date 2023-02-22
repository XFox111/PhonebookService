FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY PhonebookService.Api/*.csproj PhonebookService.Api/
COPY PhonebookService.Domain/*.csproj PhonebookService.Domain/
COPY PhonebookService.Infrastructure/*.csproj PhonebookService.Infrastructure/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT [ "dotnet", "PhonebookService.Api.dll" ]

