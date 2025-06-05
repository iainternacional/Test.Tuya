# Test_Tuya – Clean Architecture (.NET 8)

> Ejemplo de solución **Clean Architecture** (Domain → Application → Infrastructure → Presentation) con ASP.NET Core 8, EF Core 8 y pruebas unitarias/integración.

---

## ✨ Características

| Capa               | Tecnología | Responsabilidad principal                                   |
|--------------------|------------|-------------------------------------------------------------|
| **Domain**         | C# 12 puro | Entidades de negocio (`Customer`, `Order`) + contratos (`ICustomerRepository`) |
| **Application**    | C# 12 puro | Casos de uso (`OrderService`) y DTOs                        |
| **Infrastructure** | EF Core 8  | Persistencia (SQL Server) + implementaciones de repositorios |
| **Presentation**   | ASP.NET Core 8 Web API | Controladores REST y modelos de vista                   |
| **Tests**          | xUnit, Moq | *Unit* (Domain / Application) + *Integration* (WebApplicationFactory) |

---

## 📁 Estructura de carpetas

El archivo **`Test_Tuya.sln`** en la carpeta raíz ya referencia todos estos proyectos.

---

## ⚙️ Prerequisitos

| Herramienta | Versión mínima | Cómo instalar |
|-------------|----------------|---------------|
| **.NET SDK** | 8.0 (LTS)      | <https://dotnet.microsoft.com/download> |
| **SQL Server Express / LocalDB** | 2019 | `winget install Microsoft.SQLServer.2019-Express` |
| **Visual Studio Community** | 17.9 | Workloads “ASP.NET y desarrollo web” + “.NET cross-platform” |

---

## 🚀 Puesta en marcha

```bash
git clone (https://github.com/iainternacional/Test.Tuya)
cd Test_Tuya
dotnet restore

// src/Test_Tuya.Api/appsettings.Development.json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=MyShopDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

Add-Migration Initial
Update-Database

dotnet ef database update --project src\MyShop.Infrastructure --startup-project src\MyShop.Api


> MIT © 2025 Andrés Felipe Puerta
