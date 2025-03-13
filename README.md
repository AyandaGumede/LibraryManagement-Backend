# **Library Management System - Backend**  
🚀 A RESTful API built with **ASP.NET Core Web API** and **SQL Server** to manage a library system efficiently.  

## 📌 **Overview**  
This backend powers the **Library Management System**, providing endpoints to manage books, users, and library operations. It handles book additions, deletions, and categorization, storing data in **SQL Server**.

## 🛠 **Tech Stack**  
- **Backend:** ASP.NET Core Web API  
- **Database:** SQL Server  
- **ORM:** Entity Framework Core  
- **Authentication:** (Specify if using JWT, Identity, etc.)  
- **API Client:** Postman / Swagger for testing  

## 🎯 **Features**  
✅ **CRUD Operations** – Add, update, delete, and retrieve books  
✅ **RESTful API** – Well-structured API with HTTP methods  
✅ **Database Integration** – Uses SQL Server with Entity Framework Core  
✅ **Error Handling & Logging** – Structured error responses and logs  
✅ **Authentication & Authorization** – (If applicable, e.g., JWT-based authentication)  

## 📂 **Project Structure**  
```bash
LibraryManagement-Backend/
│── LibraryManagement.API/
│   ├── Controllers/       # API controllers (BooksController, etc.)
│   ├── Models/            # Database models (Book, User, etc.)
│   ├── Services/          # Business logic services
│   ├── Repositories/      # Data access layer using Repository Pattern
│   ├── Data/              # Database context (AppDbContext)
│   ├── Program.cs         # Application entry point
│   ├── appsettings.json   # Configuration file (DB connection, etc.)
│── LibraryManagement.sln  # Solution file
│── README.md
```

## 🚀 **Getting Started**  

### **1. Clone the Repository**  
```sh
git clone https://github.com/AyandaGumede/LibraryManagement-Backend.git
cd LibraryManagement-Backend
```

### **2. Set Up the Database**  
Ensure **SQL Server** is installed and running. Update the **connection string** in `appsettings.json`:  
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### **3. Run Database Migrations**  
Apply migrations to set up the database schema:  
```sh
dotnet ef database update
```

### **4. Run the API**  
Start the ASP.NET Core Web API:  
```sh
dotnet run
```
The API will be available at **http://localhost:5000/api**.

## 🛠 **Testing the API**  
- Use **Postman** or **Swagger** (`/swagger`) to test the endpoints.  
- Ensure your **frontend** (React) communicates with the correct API base URL.  
