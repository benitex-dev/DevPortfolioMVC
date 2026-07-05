
# 03 - Arquitectura

**Proyecto:** DevPortfolioMVC

**Versión:** 1.0

**Estado:** ✅ Aprobado

**Sprint:** Sprint 0

**Última actualización:** 27/06/2026

---

# Objetivo

Este documento describe la arquitectura general del sistema, la organización de la solución y los principios que guiarán el desarrollo del proyecto.

La justificación de las decisiones arquitectónicas se encuentra documentada en los correspondientes ADR (Architecture Decision Records).

---

# Arquitectura General

DevPortfolioMVC será una aplicación web desarrollada utilizando **ASP.NET Core MVC (.NET 9)**.

Durante la primera versión del proyecto se utilizará una arquitectura MVC clásica organizada mediante separación por responsabilidades.

La aplicación estará compuesta inicialmente por un único proyecto ASP.NET Core MVC.

---

# Arquitectura lógica

```
                    Usuario
                       │
                       ▼
                Controllers
                       │
          ┌────────────┴────────────┐
          ▼                         ▼
      Services                ViewModels
          │
          ▼
    Repositories
          │
          ▼
   Entity Framework Core
          │
          ▼
       SQL Server
```

---

# Organización de la solución

La solución estará organizada de la siguiente manera:

```
DevPortfolioMVC
│
├── docs
├── src
│   └── DevPortfolioMVC.Web
├── tests
├── database
└── docker
```

---

# Organización del proyecto MVC

```
DevPortfolioMVC.Web
│
├── Areas
│   └── Admin
│
├── Controllers
├── Data
├── Extensions
├── Middleware
├── Models
├── Repositories
├── Services
├── ViewModels
├── Views
├── wwwroot
│
├── Program.cs
└── appsettings.json
```

---

# Responsabilidad de cada carpeta

## Controllers

Reciben las solicitudes HTTP y coordinan la ejecución de la lógica de negocio.

No deberán contener lógica de negocio.

---

## Services

Implementan la lógica funcional del sistema.

Representan la capa de negocio.

---

## Repositories

Centralizan el acceso a la base de datos mediante Entity Framework Core.

---

## Models

Representan las entidades persistidas en la base de datos.

---

## ViewModels

Modelos específicos para las vistas.

Permiten desacoplar las entidades de la interfaz de usuario.

---

## Data

Configuración de Entity Framework Core.

DbContext.

Migraciones.

Seed inicial.

---

## Middleware

Componentes personalizados del pipeline HTTP.

---

## Extensions

Métodos de extensión utilizados para registrar servicios y configuraciones.

---

## Views

Interfaz de usuario desarrollada con Razor Views.

---

## Areas

Separación lógica de módulos.

Inicialmente contendrá únicamente el área **Admin**.

---

## wwwroot

Recursos estáticos:

* CSS
* JavaScript
* imágenes
* fuentes

---

# Principios de diseño

Durante el desarrollo del proyecto se seguirán los siguientes principios.

* Separación de responsabilidades.
* Código limpio.
* Alta cohesión.
* Bajo acoplamiento.
* Inyección de dependencias.
* Reutilización de componentes.
* Simplicidad.
* Escalabilidad.

---

# Patrones de diseño

Los siguientes patrones formarán parte de la arquitectura.

* MVC
* Repository Pattern
* Service Layer
* Dependency Injection

Otros patrones podrán incorporarse si aportan valor al proyecto.

---

# Dependencias principales

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Bootstrap 5

---

# Escalabilidad

La arquitectura deberá permitir incorporar nuevos módulos sin afectar el funcionamiento existente.

Entre ellos:

* Blog
* Certificaciones
* Experiencia laboral
* Publicaciones
* Panel administrativo
* Dashboard
* Estadísticas

---

# Relación con otros documentos

Este documento complementa:

* 01 - Visión
* 02 - Requerimientos
* ADR-001 - Selección de la arquitectura principal

---

# Estado del documento

| Campo       | Valor            |
| ----------- | ---------------- |
| Estado      | ✅ Aprobado       |
| Versión     | 1.0              |
| Sprint      | Sprint 0         |
| Responsable | Ezequiel Benítez |

