using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.IntegrationTests;

public class BasicTests 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_NumbersReturnSuccessAndCorrectContentType()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/number");

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
        Assert.True(true);
    }
}