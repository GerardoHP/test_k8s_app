namespace testK8sApp.Web.Dto;

public class AuthorPatch
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}