namespace testK8sApp.Web;

public class Info
{
    public static string SectionName = nameof(Info);

    public string ContainerId { get; set; } = string.Empty;
    public string GrpcServiceUrl { get; set; } = string.Empty;
}