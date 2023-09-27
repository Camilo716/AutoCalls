using Test.Helpers;
using Tests.IntegrationTests.Helpers;

namespace Tests.IntegrationTests;

// "Number" enpoints tests
public partial class EnpointsTests
{
    [Fact]
    public async Task Post_AudioReturnSuccesAndRecordsInDbIncrease()
    {
        var client = _factory.CreateClient();
        HttpContent audio = AudioUtilities.GetAudioHttpContent("../../../Helpers/Audios/testing-audio.mp3");
        int countBefore = await DbUtilities.GetAudioRecordsCount(_context);

        HttpResponseMessage response = await client.PostAsync("/api/audio", audio);

        response.EnsureSuccessStatusCode();
        int countAfter = await DbUtilities.GetAudioRecordsCount(_context);
        Assert.Equal(countBefore+1, countAfter);
    }
}