using DevPortfolioMVC.Web.Models.ViewModels;

namespace DevPortfolioMVC.Web.Data
{
    public class HomeData
    {
        public static List<ProjectCardViewModel> GetFeaturedProjects()
        {
            return
            [
                new()
            {
                Title = "Administrador de Gastos",
                Description = "Proyecto Integrador de la Tecnicatura.",
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
                Description = "Sistema administrativo para comercios.",
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
                Description = "API REST desarrollada con Java.",
                Technologies =
                [
                    "Spring Boot",
                    "JPA",
                    "PostgreSQL"
                ]
            }
            ];
        }
    }
}
