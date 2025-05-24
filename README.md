# BackProducts
# 🚀 Product Management App

Este repositorio contiene dos proyectos:

1. **Backend**: Web API en .NET 8 para CRUD de productos, usando EF Core y SQL Server LocalDB.  
2. **Frontend**: SPA en Angular 18 + Angular Material que consume la API de productos.

---

## 📖 Contenidos

- [Backend](#-backend-net-8-web-api)  
- [Frontend](#-frontend-angular-18--angular-material)  
- [Build y despliegue](#-build-y-despliegue)  
- [Notas](#-notas)  

---

## 🛠️ Backend (.NET 8 Web API)

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- SQL Server LocalDB (incluido con Visual Studio)  

### 1. Configurar la base de datos

Conéctate en SSMS a `(localdb)\MSSQLLocalDB` usando Windows Authentication y ejecuta:

```sql
-- 1) Crear base si no existe
IF DB_ID('DevTestDB') IS NULL
  CREATE DATABASE DevTestDB;
GO

USE DevTestDB;
GO

-- 2) (Re)crear tabla Products
IF OBJECT_ID('dbo.Products','U') IS NOT NULL
  DROP TABLE dbo.Products;
GO

CREATE TABLE dbo.Products (
  Id          INT           IDENTITY(1,1) PRIMARY KEY,
  Name        NVARCHAR(100) NOT NULL,
  Description NVARCHAR(MAX) NULL,
  Price       DECIMAL(18,2) NOT NULL,
  CreatedAt   DATETIME2     NOT NULL DEFAULT SYSUTCDATETIME()
);
GO
