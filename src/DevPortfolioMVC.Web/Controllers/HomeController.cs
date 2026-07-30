using DevPortfolioMVC.Web.Data;
using DevPortfolioMVC.Web.Models;
using DevPortfolioMVC.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DevPortfolioMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .AsNoTracking()
                .Where(project => project.IsFeatured)
                .OrderBy(project => project.Title)
                .Select(project => new ProjectCardViewModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Summary = project.Summary,
                    ImageUrl = project.Images
                        .OrderByDescending(image => image.IsCover)
                        .ThenBy(image => image.SortOrder)
                        .Select(image => image.Url)
                        .FirstOrDefault() ?? project.ImageUrl,
                    ImageAltText = project.Images
                        .OrderByDescending(image => image.IsCover)
                        .ThenBy(image => image.SortOrder)
                        .Select(image => image.AltText)
                        .FirstOrDefault() ?? project.Title,
                    Technologies = project.Technologies
                        .OrderBy(technology => technology.Name)
                        .Select(technology => technology.Name)
                        .ToList()
                })
                .ToListAsync();

            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
