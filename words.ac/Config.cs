namespace Words.Web;

public record Config
{
    public bool UseDatabase { get; set; }
    public string ConnectionString { get; set; } = "Server=localhost;Database=testing;Uid=test;Pwd=test;";
}