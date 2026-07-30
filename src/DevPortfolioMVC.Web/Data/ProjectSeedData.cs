namespace DevPortfolioMVC.Web.Data
{
    internal static class ProjectSeedData
    {
        internal static IReadOnlyList<ProjectSeed> Projects { get; } =
        [
            new(
                Title: "Administrador de Gastos",
                Summary: "Aplicación web colaborativa para administrar ingresos, gastos, presupuestos, metas de ahorro, préstamos y finanzas del hogar.",
                Category: "Proyecto Integrador",
                Problem: "La información financiera personal y compartida suele quedar dispersa entre anotaciones, mensajes y planillas. El proyecto centraliza los movimientos, presupuestos, objetivos de ahorro y deudas para ofrecer una visión clara del dinero disponible y de los compromisos de cada integrante.",
                Development: "Desarrollé la aplicación con .NET Framework 4.8, ASP.NET Web Forms, C# y SQL Server. Modelé un dominio financiero de 21 entidades e implementé registro de movimientos, pagos en cuotas, presupuestos por categoría, metas de ahorro, préstamos y hogares compartidos. La interfaz responsive incluye paneles de resumen, filtros y gráficos para facilitar el seguimiento de la información.",
                Technologies:
                [
                    "ASP.NET Web Forms",
                    "C#",
                    "SQL Server",
                    "Bootstrap"
                ],
                Learnings:
                [
                    "Modelado de un dominio financiero amplio con entidades y relaciones en SQL Server.",
                    "Implementación de reglas para cuotas, presupuestos, ahorros, préstamos y gastos compartidos.",
                    "Organización de una aplicación multiusuario con ASP.NET Web Forms y C#.",
                    "Diseño de formularios, validaciones, filtros, paneles y navegación responsive."
                ],
                FutureImprovements:
                [
                    "Incorporar pruebas automatizadas para las reglas financieras principales.",
                    "Agregar exportación de reportes en PDF y Excel.",
                    "Enviar alertas por vencimientos y límites de presupuesto.",
                    "Migrar gradualmente la solución a ASP.NET Core."
                ],
                Images:
                [
                    new(
                        Url: "/images/projects/administrador-gastos/dashboard.webp",
                        AltText: "Dashboard de GastApp con saldos, movimientos recientes y gráfico de gastos por categoría.",
                        Caption: "Dashboard financiero y resumen mensual.",
                        IsCover: true),
                    new(
                        Url: "/images/projects/administrador-gastos/registro-gasto.webp",
                        AltText: "Formulario de GastApp para registrar un gasto en cuotas.",
                        Caption: "Registro de gastos con categorías, monedas, medios y formas de pago.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-gastos/historial-movimientos.webp",
                        AltText: "Historial de movimientos de GastApp con filtros por período, operación, categoría y medio de pago.",
                        Caption: "Historial de movimientos con filtros combinables.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-gastos/metas-ahorro.webp",
                        AltText: "Pantalla de metas de ahorro de GastApp con progreso y fecha objetivo.",
                        Caption: "Metas de ahorro con aportes y seguimiento de progreso.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-gastos/gestion-hogar.webp",
                        AltText: "Panel de hogar compartido de GastApp con integrantes, aportes y distribución de gastos.",
                        Caption: "Gestión de gastos compartidos entre integrantes de un hogar.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-gastos/dinero-prestado.webp",
                        AltText: "Detalle de una deuda en GastApp con cuotas cobradas y pendientes.",
                        Caption: "Seguimiento de dinero prestado y cobro por cuotas.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-gastos/presupuesto-mensual.webp",
                        AltText: "Presupuesto mensual de GastApp organizado por categoría.",
                        Caption: "Presupuestos mensuales configurables por categoría.",
                        IsCover: false)
                ],
                ImageUrl: "/images/projects/administrador-gastos/dashboard.webp",
                RepositoryUrl: "https://github.com/benitex-dev/TPFinalIntegrador",
                DemoUrl: null,
                IsFeatured: true),
            new(
                Title: "Administrador de Usuarios",
                Summary: "API REST securizada para gestionar usuarios, roles, permisos, profesores, estudiantes y cursos de una plataforma educativa.",
                Category: "Backend · API REST",
                Problem: "Una plataforma educativa necesita centralizar su información académica y controlar qué operaciones puede realizar cada tipo de usuario. El proyecto resuelve ese problema mediante un modelo de permisos granular que separa las responsabilidades de administradores, profesores y estudiantes.",
                Development: "Desarrollé la API con Java 17, Spring Boot 3.5 y Spring Security. Implementé autenticación mediante JWT, autorización basada en roles y permisos, persistencia con Spring Data JPA y PostgreSQL, y documentación interactiva con Swagger. También migré la base desde MySQL, resolví diferencias de tipos y zona horaria, y preparé un entorno reproducible con Docker Compose y volúmenes persistentes.",
                Technologies:
                [
                    "Java 17",
                    "Spring Boot",
                    "Spring Security",
                    "JWT",
                    "PostgreSQL",
                    "Docker",
                    "Swagger"
                ],
                Learnings:
                [
                    "Diseño de seguridad RBAC con relaciones entre usuarios, roles y permisos.",
                    "Implementación de autenticación y autorización mediante Spring Security y JWT.",
                    "Migración de MySQL a PostgreSQL y resolución de diferencias entre motores.",
                    "Contenerización de la API y la base de datos con Docker Compose."
                ],
                FutureImprovements:
                [
                    "Completar la edición de cursos propios para el rol profesor.",
                    "Incorporar inicio de sesión social con Google y GitHub.",
                    "Agregar pruebas automatizadas de seguridad y reglas de negocio.",
                    "Configurar integración y despliegue continuos."
                ],
                Images:
                [
                    new(
                        Url: "/images/projects/administrador-usuarios/swagger-api.png",
                        AltText: "Swagger UI de la API del portal de cursos con autenticación JWT, botón Authorize y endpoints protegidos.",
                        Caption: "Documentación OpenAPI con autenticación JWT y endpoints protegidos.",
                        IsCover: true),
                    new(
                        Url: "/images/projects/administrador-usuarios/swagger-usuarios-profesores.png",
                        AltText: "Swagger UI con endpoints protegidos para administrar usuarios y profesores.",
                        Caption: "Endpoints protegidos para la gestión de usuarios y profesores.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-usuarios/swagger-permisos-estudiantes.png",
                        AltText: "Swagger UI con endpoints protegidos para administrar permisos y estudiantes.",
                        Caption: "Endpoints protegidos para la gestión de permisos y estudiantes.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-usuarios/modelo-academico.png",
                        AltText: "Diagrama entidad-relación del módulo académico con estudiantes, profesores, cursos y sus relaciones.",
                        Caption: "Modelo académico: profesores, cursos, estudiantes y relación de inscripciones.",
                        IsCover: false),
                    new(
                        Url: "/images/projects/administrador-usuarios/modelo-seguridad.png",
                        AltText: "Diagrama entidad-relación del módulo de seguridad con usuarios, roles, permisos y sus tablas intermedias.",
                        Caption: "Modelo de seguridad RBAC: usuarios, roles y permisos.",
                        IsCover: false)
                ],
                ImageUrl: "/images/projects/administrador-usuarios/swagger-api.png",
                RepositoryUrl: "https://github.com/benitex-dev/administrador-usuarios",
                DemoUrl: null,
                IsFeatured: true)
        ];
    }

    internal sealed record ProjectSeed(
        string Title,
        string Summary,
        string Category,
        string Problem,
        string Development,
        IReadOnlyList<string> Technologies,
        IReadOnlyList<string> Learnings,
        IReadOnlyList<string> FutureImprovements,
        IReadOnlyList<ProjectImageSeed> Images,
        string ImageUrl,
        string? RepositoryUrl,
        string? DemoUrl,
        bool IsFeatured);

    internal sealed record ProjectImageSeed(
        string Url,
        string AltText,
        string Caption,
        bool IsCover);
}
