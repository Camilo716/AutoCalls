using AutoCallsApi.Models;
using Test.Helpers;

namespace IntegrationTests;

// "Number" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task Post_NumberReturnSuccesAndRecordsInDbIncrease()
    {
        var client = _factory.CreateClient();
        HttpContent number = NumberUtilities.GetNumberHttpContent(321459789);
        int countBefore = await DbUtilities.GetRecordsCount<Number>(_context, "Numbers");

        HttpResponseMessage response = await client.PostAsync("/api/number", number);

        response.EnsureSuccessStatusCode();
        int countAfter = await DbUtilities.GetRecordsCount<Number>(_context, "Numbers");
        Assert.Equal(countBefore+1, countAfter);
    }
}