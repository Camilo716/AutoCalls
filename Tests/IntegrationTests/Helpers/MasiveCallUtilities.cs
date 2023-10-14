using System.Text;
using AutoCallsApi.DTOs;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using AutoCallsApi.Models;

namespace IntegrationTests.Helpers;

internal static class CallUtilities
{
    internal static HttpContent GetCallHttpContent(ICollection<int> numbersIds, int audioId)
    {
        if (numbersIds.IsNullOrEmpty())
            throw new ArgumentException($"{nameof(numbersIds)} cannot be empty");

        MasiveCallCreationDTO call = new MasiveCallCreationDTO 
        {
            NumbersIds = numbersIds,
            AudioId = audioId 
        };

        string jsonContent = JsonConvert.SerializeObject(call);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");

        return httpContent;
    }

    internal static async Task<MasiveCall> GetNumberModelFromHttpResponse(HttpResponseMessage response)
    {
        string numberJson = await response.Content.ReadAsStringAsync();
        MasiveCall numberModel = JsonConvert.DeserializeObject<MasiveCall>(numberJson)!;
        return numberModel;
    }
}