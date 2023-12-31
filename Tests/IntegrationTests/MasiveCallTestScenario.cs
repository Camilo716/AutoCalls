using AutoCallsApi.Models;
using AutoCallsApi.Helpers;
using IntegrationTests.Helpers.ModelUtilities;

namespace IntegrationTests;

// "MassiveCall" tests scenario
public partial class EnpointsTests
{
    [Fact]
    public async Task ClientMakeAMassiveCallTest()
    {
        HttpClient client = _factory.CreateClient();
        Audio audio = await ClientSaveAudioToPlay(client);
        List<Number> numbers = await ClientSaveSomeNumbersToCall(client);
        HttpContent masiveCall = ClientPrepareMassiveCall(audio, numbers);

        HttpResponseMessage response = await client.PostAsync("/api/MasiveCall", masiveCall);

        response.EnsureSuccessStatusCode();
        AssertMadeAllCalls(expectedCalls: numbers.Count, response);
        AssertAllCallSucceed(response);
        AssertCalledCorrectNumbers(numbers, response);
    }

    private async Task<Audio> ClientSaveAudioToPlay(HttpClient client)
    {
        HttpContent audio = AudioUtilities.GetAudioHttpContent("../../../Helpers/Audios/ValidFiles/testing-audio.wav", "testing-audio.wav");
        HttpResponseMessage responses = await client.PostAsync("/api/audio", audio);
        return await ModelUtilities.GetModelFromHttpResponseAsync<Audio>(responses);
    }

    private async Task<List<Number>> ClientSaveSomeNumbersToCall(HttpClient client)
    {
        HttpContent number1 = await NumberUtilities.GetNumberHttpContent("321459789");
        HttpContent number2 = await NumberUtilities.GetNumberHttpContent("320645942");
        HttpContent number3 = await NumberUtilities.GetNumberHttpContent("319123413");

        var responses = new List<HttpResponseMessage>
        {
            await client.PostAsync("/api/number", number1),
            await client.PostAsync("/api/number", number2),
            await client.PostAsync("/api/number", number3)
        };

        return await ModelUtilities.GetModelListFromHttpResponsesAsync<Number>(responses);
    }
    
    private HttpContent ClientPrepareMassiveCall(Audio audio, List<Number> numbers)
    {
        return MasiveCallUtilities.GetCallHttpContent(
            idsNumbersToCall: new int[]{
                numbers[0].Id,
                numbers[1].Id,
                numbers[2].Id 
            },
            audioId: audio.Id 
        );
    }

    private async void AssertMadeAllCalls(int expectedCalls, HttpResponseMessage response)
    {
        MasiveCall masiveCall = await ModelUtilities.GetModelFromHttpResponseAsync<MasiveCall>(response);
        Assert.Equal(expectedCalls, masiveCall.Calls.Count);
    }

    private async void AssertAllCallSucceed(HttpResponseMessage response)
    {
        MasiveCall masiveCall = await ModelUtilities.GetModelFromHttpResponseAsync<MasiveCall>(response);

        foreach(Call call in masiveCall.Calls)
        {
            Assert.Equal(CallResult.OK.ToString(), call.Result);
        }
    }

    private async void AssertCalledCorrectNumbers(IEnumerable<Number> expectedNumbers, HttpResponseMessage response)
    {
        MasiveCall masiveCall = await ModelUtilities.GetModelFromHttpResponseAsync<MasiveCall>(response);
        IEnumerable<string> numberValuesCalled = masiveCall.Calls.Select(c => c.Number.NumberValue);

        foreach (string expectedNumberValue in expectedNumbers.Select(n => n.NumberValue))
        {
            Assert.Contains(expectedNumberValue, numberValuesCalled);
        }
    }
}