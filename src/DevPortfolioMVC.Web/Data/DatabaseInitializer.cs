using DevPortfolioMVC.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevPortfolioMVC.Web.Data
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeAsync(
            ApplicationDbContext context,
            CancellationToken cancellationToken = default)
        {
            await context.Database.MigrateAsync(cancellationToken);

            var technologies = await context.Technologies
                .ToDictionaryAsync(
                    technology => technology.Name,
                    StringComparer.OrdinalIgnoreCase,
                    cancellationToken);

            var projects = await context.Projects
                .AsSplitQuery()
                .Include(project => project.Technologies)
                .Include(project => project.Learnings)
                .Include(project => project.FutureImprovements)
                .Include(project => project.Images)
                .ToListAsync(cancellationToken);

            foreach (var seed in ProjectSeedData.Projects)
            {
                var project = projects.FirstOrDefault(
                    project => project.Title.Equals(
                        seed.Title,
                        StringComparison.OrdinalIgnoreCase));

                if (project is not null && project.Id <= 0)
                {
                    context.Projects.Remove(project);
                    projects.Remove(project);
                    project = null;
                }

                if (project is null)
                {
                    project = new Project
                    {
                        Title = seed.Title
                    };

                    context.Projects.Add(project);
                    projects.Add(project);
                }

                SynchronizeProject(project, seed);

                AddImages(project, seed.Images);

                AddTechnologies(project, seed.Technologies, technologies, context);
                SynchronizeLearnings(project, seed.Learnings);
                SynchronizeFutureImprovements(project, seed.FutureImprovements);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        private static void SynchronizeProject(
            Project project,
            ProjectSeed seed)
        {
            project.Summary = seed.Summary;
            project.Category = seed.Category;
            project.Problem = seed.Problem;
            project.Development = seed.Development;
            project.ImageUrl = seed.Images
                .FirstOrDefault(image => image.IsCover)?.Url
                ?? seed.ImageUrl;
            project.RepositoryUrl = seed.RepositoryUrl;
            project.DemoUrl = seed.DemoUrl;
            project.IsFeatured = seed.IsFeatured;
        }

        private static void AddImages(
            Project project,
            IEnumerable<ProjectImageSeed> imageSeeds)
        {
            var sortOrder = 0;

            foreach (var imageSeed in imageSeeds)
            {
                var image = project.Images.FirstOrDefault(
                    image => image.Url.Equals(
                        imageSeed.Url,
                        StringComparison.OrdinalIgnoreCase));

                if (image is null)
                {
                    image = new ProjectImage { Url = imageSeed.Url };
                    project.Images.Add(image);
                }

                image.AltText = imageSeed.AltText;
                image.Caption = imageSeed.Caption;
                image.IsCover = imageSeed.IsCover;
                image.SortOrder = sortOrder;
                sortOrder++;
            }
        }

        private static void SynchronizeLearnings(
            Project project,
            IReadOnlyList<string> descriptions)
        {
            var currentDescriptions = project.Learnings
                .OrderBy(learning => learning.SortOrder)
                .Select(learning => learning.Description);

            if (currentDescriptions.SequenceEqual(descriptions))
            {
                return;
            }

            project.Learnings.Clear();
            project.Learnings = descriptions
                .Select((description, index) => new ProjectLearning
                {
                    Description = description,
                    SortOrder = index
                })
                .ToList();
        }

        private static void SynchronizeFutureImprovements(
            Project project,
            IReadOnlyList<string> descriptions)
        {
            var currentDescriptions = project.FutureImprovements
                .OrderBy(improvement => improvement.SortOrder)
                .Select(improvement => improvement.Description);

            if (currentDescriptions.SequenceEqual(descriptions))
            {
                return;
            }

            project.FutureImprovements.Clear();
            project.FutureImprovements = descriptions
                .Select((description, index) => new ProjectFutureImprovement
                {
                    Description = description,
                    SortOrder = index
                })
                .ToList();
        }

        private static void AddTechnologies(
            Project project,
            IEnumerable<string> technologyNames,
            IDictionary<string, Technology> technologies,
            ApplicationDbContext context)
        {
            foreach (var technologyName in technologyNames)
            {
                if (!technologies.TryGetValue(technologyName, out var technology))
                {
                    technology = new Technology { Name = technologyName };
                    technologies.Add(technologyName, technology);
                    context.Technologies.Add(technology);
                }

                if (project.Technologies.All(
                    projectTechnology => projectTechnology.Name != technologyName))
                {
                    project.Technologies.Add(technology);
                }
            }
        }
    }
}
