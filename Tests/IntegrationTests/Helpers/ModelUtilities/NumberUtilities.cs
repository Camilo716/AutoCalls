using AutoCallsApi.DTOs;
using IntegrationTests.Helpers.ModelUtilities;

internal static class NumberUtilities
{
    internal static async Task<HttpContent> GetNumberHttpContent(string numberValue)
    {
        NumberCreationDTO number = new NumberCreationDTO { NumberValue = numberValue };
        return ModelUtilities.GetHttpContentFromModel<NumberCreationDTO>(number);
    }
}