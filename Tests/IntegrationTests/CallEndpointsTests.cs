using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper.Configuration.Conventions;
using Test.Helpers;
using IntegrationTests.Helpers;

namespace IntegrationTests;

// "Call" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMasiveCall_ReturnSuccessTest()
    {
        var client = _factory.CreateClient();
        HttpContent call = CallUtilities.GetCallHttpContent(numberId: 1, audioId: 1);

        HttpResponseMessage response = await client.PostAsync("/api/call", call);

        response.EnsureSuccessStatusCode();
    }
}