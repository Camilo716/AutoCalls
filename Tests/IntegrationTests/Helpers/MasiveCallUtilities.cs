using System.Text;
using AutoCallsApi.DTOs;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using AutoCallsApi.Models;

namespace IntegrationTests.Helpers;

internal static class MasiveCallUtilities
{
    internal static HttpContent GetCallHttpContent(ICollection<Number> numbersToCall, int audioId)
    {
        if (numbersToCall.IsNullOrEmpty())
            throw new ArgumentException($"{nameof(numbersToCall)} cannot be empty");

        MasiveCallCreationDTO call = new MasiveCallCreationDTO 
        {
            NumbersToCall = numbersToCall,
            AudioId = audioId 
        };

        string jsonContent = JsonConvert.SerializeObject(call);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");

        return httpContent;
    }

    internal static async Task<MasiveCall> GetMassiveCallsModelFromHttpResponseAsync(HttpResponseMessage response)
    {
        string massiveCallsJson = await response.Content.ReadAsStringAsync();
        MasiveCall massiveCallModel = JsonConvert.DeserializeObject<MasiveCall>(massiveCallsJson)!;
        return massiveCallModel;
    }
}