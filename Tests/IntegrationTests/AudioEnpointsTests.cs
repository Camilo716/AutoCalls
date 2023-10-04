using System.Net;
using System.Runtime.CompilerServices;
using AutoMapper.Configuration.Conventions;
using Test.Helpers;
using IntegrationTests.Helpers;
using AutoCallsApi.Models;

namespace IntegrationTests;

// "Audio" enpoints tests
public partial class EnpointsTests
{
    [Theory]
    [InlineData("../../../Helpers/Audios/testing-audio.mp3", "testing-audio.mp3")]
    public async Task Post_AudioReturnSuccesAndRecordsInDbIncrease(string fileRoute, string fileName)
    {
        var client = _factory.CreateClient();
        HttpContent audio = AudioUtilities.GetAudioHttpContent(fileRoute, fileName);
        int countBefore = await DbUtilities.GetRecordsCount<Audio>(_context, "Audios");

        HttpResponseMessage response = await client.PostAsync("/api/audio", audio);

        response.EnsureSuccessStatusCode();
        int countAfter = await DbUtilities.GetRecordsCount<Audio>(_context, "Audios");
        Assert.Equal(countBefore+1, countAfter);
    }

    [Theory]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.jpg", "invalidExtension.jpg")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.jpeg", "invalidExtension.jpeg")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.png", "invalidExtension.png")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.txt", "invalidExtension.txt")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.pdf", "invalidExtension.pdf")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.doc", "invalidExtension.doc")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.zip", "invalidExtension.zip")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.rar", "invalidExtension.rar")]
    [InlineData("../../../Helpers/Audios/InvalidFiles/invalidExtension.exe", "invalidExtension.exe")]
    public async Task Post_InvalidFileReturnBadRequest(string fileRoute, string fileName)
    {
        var client = _factory.CreateClient();
        HttpContent audio = AudioUtilities.GetAudioHttpContent(fileRoute, fileName);
        
        HttpResponseMessage response = await client.PostAsync("/api/audio", audio);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}