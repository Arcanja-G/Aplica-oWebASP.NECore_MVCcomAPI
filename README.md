

Solução ASP.NET Core desenvolvida em .NET 9, composta por uma aplicação
web MVC e uma API REST, com ligação a base de dados SQL Server via
Entity Framework Core.

## Projetos incluídos

- **helloword_projeto** — Aplicação web MVC com vistas Razor
- **helloworld_api** — API REST com Swagger/OpenAPI

## Funcionalidades

- CRUD de Produtos e Clientes
- Interface web com Bootstrap
- API documentada via Swagger
- Migrações de base de dados com Entity Framework Core

## Tecnologias

- C# / .NET 9
- ASP.NET Core MVC + Web API
- Entity Framework Core + SQL Server
- Bootstrap 5, jQuery
- Visual Studio

## Configuração

1. Clona o repositório
2. Configura a connection string em `appsettings.json`
3. Executa as migrações: `dotnet ef database update`
4. Corre o projeto: `dotnet run`

## Contexto

Projeto desenvolvido no âmbito da formação no IEFP.
