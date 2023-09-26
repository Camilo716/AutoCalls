using AutoCallsApi.Data.EntityFramework;
using AutoCallsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Helpers;

public static class DbUtilities
{
    public static async Task<int> GetNumberRecordsCount(EfApplicationDbContext db)
    {
        var actors = db.numbers;
        int counter = await actors.CountAsync();
        return counter;
    }

    public static void ReinitializeDbForTests(EfApplicationDbContext db)
    {
        // throw new Exception(db.ContextId.ToString());
        db.numbers.RemoveRange(db.numbers);
        InitializeDbForTests(db);
    }

    private static void InitializeDbForTests(EfApplicationDbContext db)
    {
        var seedNumbers = GetSeedingNumbers();
        db.numbers.AddRange(seedNumbers);
        db.SaveChanges();
    }

    private static List<Number> GetSeedingNumbers()
    {
        return new List<Number>()
        {
            new Number(){ },
            new Number(){ },
            new Number(){ },
        };
    }
}