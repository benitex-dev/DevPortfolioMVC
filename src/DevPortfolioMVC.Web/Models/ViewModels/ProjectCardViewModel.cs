namespace DevPortfolioMVC.Web.Models.ViewModels
{
    public class ProjectCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public List<string> Technologies { get; set; } = [];

        public string ImageUrl { get; set; } = string.Empty;

        public string ImageAltText { get; set; } = string.Empty;
    }
}
