using AutoCallsApi.DTOs;
using IntegrationTests.Helpers.ModelUtilities;

internal static class NumberUtilities
{
    internal static async Task<HttpContent> GetNumberHttpContent(string numberValue)
    {
        var number = new NumberCreationDTO { NumberValue = numberValue };
        return ModelUtilities.GetHttpContentFromModel(number);
    }
}