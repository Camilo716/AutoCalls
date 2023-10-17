using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper.Configuration.Conventions;
using Test.Helpers;
using IntegrationTests.Helpers;
using AutoCallsApi.Models;
using System.Collections;
using Azure;
using AutoCallsApi.Helpers;

namespace IntegrationTests;

// "MasiveCall" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMasiveCall_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        HttpContent call = MasiveCallUtilities.GetCallHttpContent
        (
            idsNumbersToCall: new int[] {1, 2, 3},
            audioId: 1
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", call);
 
        response.EnsureSuccessStatusCode();
        MasiveCall masiveCall = await MasiveCallUtilities.GetMassiveCallsModelFromHttpResponseAsync(response);
        Assert.Equal(3, masiveCall.Calls.Count);
        Assert.StartsWith(
            CallResult.OK.ToString(),
            masiveCall.Calls.ElementAt(0).Result.ToString());
    }
}