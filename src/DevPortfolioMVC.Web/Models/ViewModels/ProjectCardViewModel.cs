namespace DevPortfolioMVC.Web.Models.ViewModels
{
    public class ProjectCardViewModel
    {

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<string> Technologies { get; set; } = [];

        public string ImageUrl { get; set; } = string.Empty;

        public string ProjectUrl { get; set; } = "#";
    }
}
