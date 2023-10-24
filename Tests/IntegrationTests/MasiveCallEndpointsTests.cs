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
            idsNumbersToCall: new int[] {
                _seedDataIds.NumbersIds[0],
                _seedDataIds.NumbersIds[1],
                _seedDataIds.NumbersIds[2],
                },
            audioId: _seedDataIds.AudiosIds[0]
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", masiveCallHttpContent);
 
        response.EnsureSuccessStatusCode();
        MasiveCall masiveCall = await MasiveCallUtilities.GetMassiveCallsModelFromHttpResponseAsync(response);
        Assert.Equal(3, masiveCall.Calls.Count);
        Assert.StartsWith(
            CallResult.OK.ToString(),
            masiveCall.Calls.ElementAt(0).Result.ToString());
        Assert.Contains(
            "324543256",
            masiveCall.Calls.ElementAt(0).Number.NumberValue.ToString());
    }
}