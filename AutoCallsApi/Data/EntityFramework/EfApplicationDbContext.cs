using Microsoft.EntityFrameworkCore;
using AutoCallsApi.Models;

namespace AutoCallsApi.Data.EntityFramework;

public class EfApplicationDbContext : DbContext
{
    public DbSet<Number> numbers { get; set; }

    public EfApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}