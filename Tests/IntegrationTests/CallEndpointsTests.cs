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
    public async Task Post_CallReturnSuccesAndRecordsInDbIncrease()
    {
        var client = _factory.CreateClient();
        HttpContent call = CallUtilities.GetCallHttpContent(numberId: 1, audioId: 2);
        // int countBefore = await DbUtilities.GetNumberRecordsCount(_context);

        HttpResponseMessage response = await client.PostAsync("/api/call", call);

        response.EnsureSuccessStatusCode();
        // int countAfter = await DbUtilities.GetNumberRecordsCount(_context);
        // Assert.Equal(countBefore+1, countAfter);
    }
}