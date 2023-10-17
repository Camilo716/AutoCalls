using IntegrationTests.Helpers;
using AutoCallsApi.Models;
using AutoCallsApi.Helpers;

namespace IntegrationTests;

// "MasiveCall" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMasiveCall_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        HttpContent masiveCallHttpContent = MasiveCallUtilities.GetCallHttpContent(
            idsNumbersToCall: new int[] {31, 32, 33},
            audioId: 1
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", masiveCallHttpContent);
 
        response.EnsureSuccessStatusCode();
        MasiveCall masiveCall = await MasiveCallUtilities.GetMassiveCallsModelFromHttpResponseAsync(response);
        Assert.Equal(3, masiveCall.Calls.Count);
        Assert.StartsWith(
            CallResult.OK.ToString(),
            masiveCall.Calls.ElementAt(0).Result.ToString());
    }
}