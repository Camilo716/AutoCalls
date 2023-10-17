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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<MasiveCall>()
            .HasMany(masiveC => masiveC.Calls);

        modelBuilder.Entity<MasiveCall>()          
            .HasOne(masiveC => masiveC.Audio)
            .WithOne()
            .HasForeignKey<MasiveCall>(masiveC => masiveC.AudioId);
        
        modelBuilder.Entity<Call>()
            .HasOne(call => call.Number)
            .WithOne()
            .HasForeignKey<Call>(call => call.NumberId);

        modelBuilder.Entity<Call>()
            .HasOne(call => call.Audio)
            .WithOne()
            .HasForeignKey<Call>(call => call.AudioId);
    }
}