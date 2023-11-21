using AutoCallsApi.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationTests.Helpers.ModelUtilities;

internal static class MasiveCallUtilities
{
    internal static HttpContent GetCallHttpContent(int[] idsNumbersToCall, int audioId)
    {
        if (idsNumbersToCall.IsNullOrEmpty())
            throw new ArgumentException($"{nameof(idsNumbersToCall)} cannot be empty");

        MasiveCallCreationDTO call = new MasiveCallCreationDTO 
        {
            IdsNumbersToCall = idsNumbersToCall,
            AudioId = audioId 
        };
        return ModelUtilities.GetHttpContentFromModel<MasiveCallCreationDTO>(call);
    }
}