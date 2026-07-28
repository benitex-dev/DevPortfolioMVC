namespace DevPortfolioMVC.Web.Models.ViewModels
{
    public class ProjectDetailViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public List<string> Technologies { get; set; } = [];

        public string Problem { get; set; } = string.Empty;

        public string Development { get; set; } = string.Empty;

        public List<string> Learnings { get; set; } = [];

        public List<string> FutureImprovements { get; set; } = [];
    }
}
