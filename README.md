# Portfolio de Ezequiel Benítez

Portfolio profesional desarrollado con ASP.NET Core MVC para presentar mi
perfil como desarrollador backend, documentar proyectos y facilitar el contacto
con reclutadores y equipos de desarrollo.

## Funcionalidades

- Presentación profesional y sección sobre mí.
- Catálogo de proyectos destacados.
- Detalle técnico con problema, desarrollo, aprendizajes y próximas mejoras.
- Galerías de capturas y diagramas.
- Enlaces a GitHub, LinkedIn, correo electrónico y descarga del CV.
- Diseño responsive y navegación accesible.
- Health check de aplicación y PostgreSQL.
- Migraciones y datos iniciales idempotentes durante el arranque.

## Tecnologías

- ASP.NET Core MVC y .NET 9
- Entity Framework Core
- PostgreSQL
- Razor Views
- Bootstrap 5
- Docker

## Estructura principal

```text
DevPortfolioMVC/
├── docs/
├── src/
│   └── DevPortfolioMVC.Web/
├── Dockerfile
├── docker-compose.yml
└── render.yaml
```

## Ejecución local

### 1. Iniciar PostgreSQL

Con Docker instalado:

```bash
docker compose up -d postgres
```

La configuración de desarrollo utiliza:

```text
Host=localhost;Port=5432;Database=devportfolio_db;Username=postgres;Password=postgres
```

### 2. Ejecutar la aplicación

```bash
dotnet run --project src/DevPortfolioMVC.Web
```

En el primer arranque, la aplicación aplica las migraciones pendientes y carga
los proyectos iniciales sin duplicarlos.

## Configuración de producción

La cadena de conexión no se guarda en el repositorio. La plataforma debe
proporcionarla mediante esta variable:

```text
ConnectionStrings__DefaultConnection
```

El contenedor utiliza el puerto `8080` de forma predeterminada y también acepta
la variable `PORT` proporcionada por plataformas de alojamiento.

El endpoint `/health` comprueba la disponibilidad de PostgreSQL y puede
utilizarse como health check de despliegue.

La guía completa se encuentra en
[docs/09-Despliegue.md](docs/09-Despliegue.md).

## Proyectos presentados

- Administrador de Gastos: aplicación colaborativa de finanzas personales.
- Administrador de Usuarios: API REST educativa con JWT, roles y permisos.

## Autor

**Ezequiel Benítez**

Backend Developer · Técnico Universitario en Programación

- [GitHub](https://github.com/benitex-dev)
- [LinkedIn](https://www.linkedin.com/in/eze-benitez)
- [Correo electrónico](mailto:ezequielpiki23@gmail.com)
