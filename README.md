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

El archivo **`MyShop.sln`** en la carpeta raíz ya referencia todos estos proyectos.

---

## 1. Requisitos previos

1. **Visual Studio Community 2022 (17.9)+**  
   - Workload **“ASP.NET y Desarrollo Web”**  
   - Workload **“.NET Multiplataforma”** (opcional, facilita CLI y pruebas)
2. **SQL Server Express / LocalDB 2019+** (o el motor que prefieras)  
3. **.NET SDK 8.0 (LTS)** (se instala con VS, pero confírmalo: *Herramientas ➜ Opciones ➜ SDKs*).

---

## 2. Clonar y abrir la solución

```bash
git clone https://github.com/tu-usuario/MyShop.git
cd MyShop


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
git clone [https://github.com/tu-usuario/MyShop.git](https://github.com/iainternacional/Test.Tuya)
cd MyShop
dotnet restore

// src/MyShop.Api/appsettings.Development.json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=MyShopDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

Add-Migration Initial
Update-Database

dotnet ef database update --project src\MyShop.Infrastructure --startup-project src\MyShop.Api


> MIT © 2025 Andrés Felipe Puerta
