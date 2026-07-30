using DevPortfolioMVC.Web.Data;
using DevPortfolioMVC.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevPortfolioMVC.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .AsNoTracking()
                .OrderByDescending(project => project.IsFeatured)
                .ThenBy(project => project.Title)
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

        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.Projects
                .AsNoTracking()
                .AsSplitQuery()
                .Where(project => project.Id == id)
                .Select(project => new ProjectDetailViewModel
                {
                    Title = project.Title,
                    Summary = project.Summary,
                    Category = project.Category,
                    Problem = project.Problem,
                    Development = project.Development,
                    Technologies = project.Technologies
                        .OrderBy(technology => technology.Name)
                        .Select(technology => technology.Name)
                        .ToList(),
                    Learnings = project.Learnings
                        .OrderBy(learning => learning.SortOrder)
                        .Select(learning => learning.Description)
                        .ToList(),
                    FutureImprovements = project.FutureImprovements
                        .OrderBy(improvement => improvement.SortOrder)
                        .Select(improvement => improvement.Description)
                        .ToList(),
                    RepositoryUrl = project.RepositoryUrl,
                    DemoUrl = project.DemoUrl,
                    Images = project.Images
                        .OrderByDescending(image => image.IsCover)
                        .ThenBy(image => image.SortOrder)
                        .Select(image => new ProjectImageViewModel
                        {
                            Url = image.Url,
                            AltText = image.AltText,
                            Caption = image.Caption,
                            IsCover = image.IsCover
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (project is null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}
