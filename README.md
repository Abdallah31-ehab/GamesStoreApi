# GamesStoreApi 🎮

A RESTful Web API built using **ASP.NET Core Web API** and **Entity Framework Core** for managing games, genres, and publishers.

## 🚀 Technologies

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* LINQ
* Swagger / OpenAPI
* Dependency Injection
* DTO Pattern
* Async Programming

## 📌 Features

* Create, Read, Update, and Delete (CRUD) operations for Games
* Manage game relationships with Genres and Publishers
* Entity Framework Core database integration
* DTOs for separating API models from database entities
* Service Layer architecture
* Asynchronous database operations
* Swagger API documentation

## 🏗️ Project Structure

```
GamesStoreApi
│
├── Controllers
│   └── Handles HTTP requests and responses
│
├── Services
│   └── Contains business logic
│
├── DTOs
│   └── Data Transfer Objects
│
├── Models
│   └── Database entities
│
├── Data
│   └── Entity Framework Core DbContext
│
└── Program.cs
    └── Application configuration
```

## 🔗 API Endpoints

### Games

| Method | Endpoint          | Description       |
| ------ | ----------------- | ----------------- |
| GET    | `/api/games`      | Get all games     |
| GET    | `/api/games/{id}` | Get game by id    |
| POST   | `/api/games`      | Create a new game |
| PUT    | `/api/games/{id}` | Update a game     |
| DELETE | `/api/games/{id}` | Delete a game     |

## ⚙️ How to Run

1. Clone the repository

```bash
git clone <repository-url>
```

2. Update the connection string in:

```
appsettings.json
```

3. Apply database migrations:

```bash
dotnet ef database update
```

4. Run the application:

```bash
dotnet run
```

5. Open Swagger:

```
https://localhost:<port>/swagger
```

## 📚 Learning Goals

This project was built to practice backend development concepts including:

* Building RESTful APIs
* Working with databases using EF Core
* Applying Dependency Injection
* Designing a layered architecture
* Creating maintainable backend code
