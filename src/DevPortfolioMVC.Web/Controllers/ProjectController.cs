using Microsoft.AspNetCore.Mvc;

namespace DevPortfolioMVC.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        
        }
        public IActionResult Details()
        {
            ViewData["Title"] = "Administrador de Gastos";
            return View();
        }
    }
}
