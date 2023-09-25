public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Startup startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        
        startup.ConfigureMiddlewares(app ,app.Environment);

        app.Run();
    }
}