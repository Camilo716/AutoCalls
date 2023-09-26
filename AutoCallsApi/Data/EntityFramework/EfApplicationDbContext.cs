using Microsoft.EntityFrameworkCore;
using AutoCallsApi.Models;

namespace AutoCallsApi.Data.EntityFramework;

public class EfApplicationDbContext : DbContext
{
    public DbSet<Number> Numbers { get; set; }

    public EfApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}