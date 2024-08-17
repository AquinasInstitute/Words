using System.Text.Json;
using Words;
using Words.Data_Sources;
using Words.Web;

public static class App
{
    public static LatinDictionary Instance;
    
    public static void Main(string[] args)
    {
        var config = JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json"));
        if (config is null) return;
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseWebSockets();

        app.MapRazorPages();
        app.MapControllers();

        var latinSettings = new LatinDictionarySettings { SkipUnlikelyInflections = true };
        
        Instance = config.UseDatabase ?
            new LatinDictionary(latinSettings, new DatabaseDataSource(config.ConnectionString)) :
            new LatinDictionary(latinSettings, new TextFileDataSource());

        app.Run();

    }
}