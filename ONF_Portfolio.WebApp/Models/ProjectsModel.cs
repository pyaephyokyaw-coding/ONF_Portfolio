namespace ONF_Portfolio.WebApp.Models;

public class ProjectsModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string CreatedDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}
