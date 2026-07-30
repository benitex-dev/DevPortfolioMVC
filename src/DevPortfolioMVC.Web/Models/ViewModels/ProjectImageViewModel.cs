namespace DevPortfolioMVC.Web.Models.ViewModels
{
    public class ProjectImageViewModel
    {
        public string Url { get; set; } = string.Empty;

        public string AltText { get; set; } = string.Empty;

        public string Caption { get; set; } = string.Empty;

        public bool IsCover { get; set; }
    }
}
