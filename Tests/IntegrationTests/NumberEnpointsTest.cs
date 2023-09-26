using AutoCallsApi.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc.Testing;
using Test.Helpers;
using Tests.IntegrationTests.Helpers;

namespace Tests.IntegrationTests;

public class BasicTests 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly EfApplicationDbContext _context;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = DbContextUtilities.GetDbContext(factory);
        DbUtilities.ReinitializeDbForTests(_context);
    }

    [Fact]
    public async Task Get_NumbersReturnSuccessAndCorrectContentType()
    {
        var client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync("/api/number");

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
        Assert.True(true);
    }

    [Fact]
    public async Task Post_NumberReturnSuccesAndRecordsInDbIncrease()
    {
        var client = _factory.CreateClient();
        HttpContent number = NumberUtilities.GetNumberHttpContent(321459789);
        int countBefore = await DbUtilities.GetNumberRecordsCount(_context);

        HttpResponseMessage response = await client.PostAsync("/api/number", number);

        response.EnsureSuccessStatusCode();
        int countAfter = await DbUtilities.GetNumberRecordsCount(_context);
        Assert.Equal(countBefore+1, countAfter);
    }
}