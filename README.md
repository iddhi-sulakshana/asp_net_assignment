# ASP.NET Core Web API – JWT Authentication & CRUD Assignment

- ✅ User registration & login with **ASP.NET Identity**
- ✅ JWT-based **authentication**
- ✅ Entity Framework Core with SQL Server

---

## 📁 Project Structure

```

asp_net_assignment/
│
├── Controllers/            # API endpoints (AuthController, DemoDataController)
├── Models/
│   ├── DTO/                # Data Transfer Objects (RegisterDTO, LoginDTO, etc.)
│   ├── Entities/           # EF Core models like RandomData
│   └── Data/               # DbContext (ApplicationDbContext.cs)
│
├── Interfaces/             # Interfaces for services (IAuthService, IDemoDataService)
├── Services/               # Business logic implementations (AuthService, DemoDataService)
├── Program.cs              # Startup configuration (DI, JWT, Swagger, etc.)
└── appsettings.json        # Configuration (JWT keys, connection strings)

```

---

## 🔐 Authentication & Authorization

### ✅ JWT Bearer Token
- On successful login, a JWT is generated and returned
- Token is expected in the `Authorization` header for protected routes:
  
```

Authorization: Bearer {your_token_here}

````

## 💡 Getting Started

### ⚙️ Setup

1. Clone the repo:

   ```bash
   git clone https://github.com/iddhi-sulakshana/asp_net_assignment
   ```

2. Update `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "your-sql-server-connection-string"
   },
   "Jwt": {
     "Key": "your-secret-key-here",
     "Issuer": "your-app-name",
     "Audience": "your-app-client"
   }
   ```

3. Run database migrations (if applicable):

   ```bash
   Update-Database
   ```

4. Run the project.

---

## 📘 Swagger API Docs

Once the app is running, navigate to:

```
https://localhost:{port}/swagger
```

Use Swagger to test the endpoints with JWT headers.

---

## 📌 Requirements

* [.NET 8.0 SDK](https://dotnet.microsoft.com/)
* SQL Server (or update to SQLite/MySQL/PostgreSQL as needed)
* Visual Studio or VS Code
