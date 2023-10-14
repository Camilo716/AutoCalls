using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper.Configuration.Conventions;
using Test.Helpers;
using IntegrationTests.Helpers;
using AutoCallsApi.Models;

namespace IntegrationTests;

// "MasiveCall" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMasiveCall_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        HttpContent call = CallUtilities.GetCallHttpContent
        (
            numbersIds: new int[]{1, 2, 3},
            audioId: 1
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", call);
 
        response.EnsureSuccessStatusCode();
    }
}