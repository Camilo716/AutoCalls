using System.Text;
using AutoCallsApi.DTOs;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using AutoCallsApi.Models;

namespace IntegrationTests.Helpers;

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

        string jsonContent = JsonConvert.SerializeObject(call);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");

        return httpContent;
    }
}