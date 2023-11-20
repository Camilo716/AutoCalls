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
        int[] idsNumbersToCall = _context.Numbers.Select(n => n.Id).ToArray();
        int idAudioToReproduce = _context.Audios.Select(n => n.Id).FirstOrDefault();
        var client = _factory.CreateClient();
        HttpContent masiveCallHttpContent = MasiveCallUtilities.GetCallHttpContent(
            idsNumbersToCall: idsNumbersToCall,
            audioId: idAudioToReproduce
        );

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", masiveCallHttpContent);
 
        response.EnsureSuccessStatusCode();
        MasiveCall masiveCall = await MasiveCallUtilities.GetMassiveCallsModelFromHttpResponseAsync(response);
        // Made all calls
        Assert.Equal(idsNumbersToCall.Length, masiveCall.Calls.Count);
        // Calls succeed 
        Assert.StartsWith(
            CallResult.OK.ToString(),
            masiveCall.Calls.ElementAt(0).Result.ToString());
        // Called correct numbers
        Assert.Contains(
            _context.Numbers.FirstOrDefault(n => n.Id == idsNumbersToCall[0])!.NumberValue,
            masiveCall.Calls.ElementAt(0).Number.NumberValue.ToString());
    }
}