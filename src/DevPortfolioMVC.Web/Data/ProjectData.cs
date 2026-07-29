using DevPortfolioMVC.Web.Models.ViewModels;

namespace DevPortfolioMVC.Web.Data
{
    public class ProjectData
    {
        public static List<ProjectCardViewModel> GetFeaturedProjects()
        {
            return
            [
                new()
            {
                Title = "Administrador de Gastos",
                Summary = "Proyecto Integrador de la Tecnicatura.",
                Technologies =
                [
                    "ASP.NET Web Forms",
                    "SQL Server",
                    "Bootstrap"
                ],
                ProjectUrl = "/Project/Details/administrador-de-gastos"
            },

            new()
            {
                Title = "Back Office Comercial",
                Summary = "Sistema administrativo para comercios.",
                Technologies =
                [
                    "ASP.NET Core MVC",
                    "Entity Framework Core",
                    "SQL Server"
                ]
            },

            new()
            {
                Title = "API REST Spring Boot",
                Summary = "API REST desarrollada con Java.",
                Technologies =
                [
                    "Spring Boot",
                    "JPA",
                    "PostgreSQL"
                ]
            }
            ];
        }
        public static ProjectDetailViewModel GetAdministradorDeGastos()
        {
            return new ProjectDetailViewModel
            {
                Title = "Administrador de Gastos",

                Summary = "Sistema desarrollado como proyecto final de la carrera para administrar ingresos, gastos, categorías, medios de pago y reportes financieros.",

                Category = "Proyecto Integrador",

                Technologies =
                [
                    "ASP.NET Web Forms",
                "SQL Server",
                "Bootstrap",
                "C#"
                ],

                Problem = "El objetivo del proyecto fue crear una aplicación web que permita registrar, organizar y consultar movimientos financieros personales de forma simple.",

                Development = "Implementé una aplicación web utilizando ASP.NET Web Forms, C# y SQL Server. La solución incluye formularios para registrar ingresos y gastos, gestión de categorías y medios de pago, y una estructura pensada para facilitar el seguimiento de los movimientos.",

                Learnings =
                [
                    "Organización de una aplicación web con ASP.NET.",
                "Diseño de tablas y relaciones en SQL Server.",
                "Separación básica de responsabilidades.",
                "Manejo de formularios, validaciones y navegación."
                ],

                FutureImprovements =
                [
                    "Agregar gráficos de gastos por categoría.",
                "Mejorar el diseño responsive.",
                "Implementar autenticación más robusta.",
                "Agregar exportación de reportes."
                ]
            };
        }
    }
}
