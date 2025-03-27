namespace Portfolio.RESTAPI.Models;

public class ProjectItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? TechStack { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public string? VersionControlUrl { get; set; }
    public string? LiveUrl { get; set; }
}
