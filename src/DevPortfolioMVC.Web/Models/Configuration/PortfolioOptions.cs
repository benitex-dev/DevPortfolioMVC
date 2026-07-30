namespace DevPortfolioMVC.Web.Models.Configuration
{
    public class PortfolioOptions
    {
        public const string SectionName = "Portfolio";

        public string Email { get; set; } = string.Empty;

        public string GitHubUrl { get; set; } = string.Empty;

        public string LinkedInUrl { get; set; } = string.Empty;

        public string CvUrl { get; set; } = string.Empty;
    }
}
