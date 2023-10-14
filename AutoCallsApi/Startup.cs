using AutoCallsApi.Data;
using AutoCallsApi.Data.EntityFramework;
using AutoCallsApi.Models;
using AutoCallsApi.Services;
using EventSocketLibrary.ClientESL;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration configuration)
    {
        _config = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));
        services.AddControllers();

        services.AddDbContext<EfApplicationDbContext>(
            opt => opt.UseNpgsql(_config.GetConnectionString("postgres-connection"))
        );
        services.AddScoped<IRepository<Number>, EfRepository<Number>>();
        services.AddScoped<NumberService>();
        services.AddScoped<IRepository<Audio>, EfRepository<Audio>>();
        services.AddScoped<AudioService>();
        services.AddScoped<IRepository<MasiveCall>, EfRepository<MasiveCall>>();
        services.AddScoped<MasiveCallService>();
        
        services.AddSingleton<IClientESL>(
            new ClientESL(
                _config["FreeSwitchHost"]!,
                Convert.ToInt32(_config["FreeSwitchPort"])
            )
        );

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void ConfigureMiddlewares(IApplicationBuilder app, IWebHostEnvironment webHostEnv)
    {
        if (webHostEnv.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoint => 
        {
            endpoint.MapControllers();
        });
    }
}