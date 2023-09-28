using AutoCallsApi.Data.EntityFramework;
using AutoCallsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Helpers;

public static class DbUtilities
{
    public static async Task<int> GetNumberRecordsCount(EfApplicationDbContext db)
    {
        DbSet<Number> numbers = db.Numbers;
        int counter = await numbers.CountAsync();
        return counter;
    }

    public static async Task<int> GetAudioRecordsCount(EfApplicationDbContext db)
    {
        DbSet<Audio> audios = db.Audios;
        int counter = await audios.CountAsync();
        return counter;
    }

    public static void ReinitializeDbForTests(EfApplicationDbContext db)
    {
        // throw new Exception(db.ContextId.ToString());
        db.Numbers.RemoveRange(db.Numbers);
        InitializeDbForTests(db);
    }

    private static void InitializeDbForTests(EfApplicationDbContext db)
    {
        var seedNumbers = GetSeedingNumbers();
        db.Numbers.AddRange(seedNumbers);
        db.SaveChanges();
    }

    private static List<Number> GetSeedingNumbers()
    {
        return new List<Number>()
        {
            new Number(){ NumberValue= 324543256 },
            new Number(){ NumberValue= 315432166},
            new Number(){ NumberValue= 356782560},
        };
    }
}