using System.Reflection;
using AutoCallsApi.Data.EntityFramework;
using AutoCallsApi.Models;
using IntegrationTests.Helpers.Database;
using Microsoft.EntityFrameworkCore;

namespace Test.Helpers.Database;

public static class DbUtilities
{
    public static async Task<int> GetRecordsCount<TEntity>(EfApplicationDbContext db, string attributeName) where TEntity: class
    {
        PropertyInfo propertyInfo = typeof(EfApplicationDbContext).GetProperty(attributeName)!;
        DbSet<TEntity> records = (DbSet<TEntity>) propertyInfo.GetValue(db)!;
        int counter = await records.CountAsync();
        return counter;
    }

    public static SeedDataIds ReinitializeDbForTests(EfApplicationDbContext db)
    {
        // throw new Exception(db.ContextId.ToString());
        db.MasiveCalls.RemoveRange(db.MasiveCalls);
        db.Calls.RemoveRange(db.Calls);
        db.Numbers.RemoveRange(db.Numbers);
        db.Audios.RemoveRange(db.Audios);
        return InitializeDbForTests(db);
    }

    private static SeedDataIds InitializeDbForTests(EfApplicationDbContext db)
    {
        var seedNumbers = GetSeedingNumbers();
        var seedAudios = GetSeedingAudios();
        db.Numbers.AddRange(seedNumbers);
        db.Audios.AddRange(seedAudios);
        db.SaveChanges();

        List<int> seedNumbersIds = seedNumbers.Select(n => n.Id).ToList();
        List<int> seedAudiosIds = seedAudios.Select(a => a.Id).ToList();
        return new SeedDataIds(seedNumbersIds, seedAudiosIds);
    }

    private static List<Number> GetSeedingNumbers()
    {
        return new List<Number>()
        {
            new Number(){ NumberValue= "324543256"},
            new Number(){ NumberValue= "315432166"},
            new Number(){ NumberValue= "356782560"},
        };
    }

    private static List<Audio> GetSeedingAudios()
    {
        return new List<Audio>()
        {
            new Audio(){ AudioData = File.ReadAllBytes("../../../Helpers/Audios/testing-audio.mp3") }
        };
    }
}