using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper.Configuration.Conventions;
using Test.Helpers;
using IntegrationTests.Helpers;
using AutoCallsApi.Models;
using System.Collections;
using Azure;

namespace IntegrationTests;

// "MasiveCall" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMasiveCall_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        ICollection<Number> _numbersToCall = await GetNumbersToCallAsync(client);
        HttpContent call = MasiveCallUtilities.GetCallHttpContent
        (
            numbersToCall: _numbersToCall,
            audioId: 1
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", call);
 
        response.EnsureSuccessStatusCode();
        MasiveCall masiveCall = await MasiveCallUtilities.GetMassiveCallsModelFromHttpResponseAsync(response);
        Assert.Equal(3, masiveCall.Calls.Count);
    }

    private async Task<ICollection<Number>> GetNumbersToCallAsync(HttpClient client)
    {
        HttpResponseMessage response = await client.GetAsync("/api/Number");
        ICollection<Number> numbers = await NumberUtilities.GetNumbersCollectionFromHttpResponse(response);
        return numbers;
    }
}