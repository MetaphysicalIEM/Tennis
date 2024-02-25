# Tennis API REST

This API provides functionality related to tennis players. 

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET 8
- Visual Studio 2022
- PostgreSQL

## Getting Started

Clone the repository:

git clone https://github.com/your-username/tennis-api.git
Open with Visual Studio Code
Run the project Tennis API

## Not completed

Player Service
Database structure

## Migrations

dotnet ef migrations add {Migration_Name} --context TennisDbContext --project Tennis.DAL --startup-project Tennis.API --output-dir {Migrations_Folder}
dotnet ef database update --project Tennis.DAL --startup-project Tennis.API
dotnet ef migrations remove --context TennisDbContext --project Tennis.DAL --startup-project Tennis.API