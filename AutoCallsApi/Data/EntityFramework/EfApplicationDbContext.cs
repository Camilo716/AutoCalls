using Microsoft.EntityFrameworkCore;
using AutoCallsApi.Models;

namespace AutoCallsApi.Data.EntityFramework;

public class EfApplicationDbContext : DbContext
{
    public DbSet<Number> Numbers { get; set; }
    public DbSet<Audio> Audios { get; set; }
    public DbSet<MasiveCall> MasiveCalls { get; set; }
    public DbSet<Call> Calls { get; set; }

    public EfApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}