using DevPortfolioMVC.Web.Data;
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
           
            var project = ProjectData.GetAdministradorDeGastos();

            return View(project);
            
        }
    }
}
