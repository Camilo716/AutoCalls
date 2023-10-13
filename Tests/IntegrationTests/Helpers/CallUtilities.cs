using System.Text;
using AutoCallsApi.DTOs;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Xunit.Sdk;

namespace IntegrationTests.Helpers;

internal static class CallUtilities
{
    internal static HttpContent GetCallHttpContent(ICollection<int> numbersIds, int audioId)
    {
        if (numbersIds.IsNullOrEmpty())
            throw new ArgumentException($"{nameof(numbersIds)} cannot be empty");

        CallCreationDTO call = new CallCreationDTO 
        {
            NumbersIds = numbersIds,
            AudioId = audioId 
        };

        string jsonContent = JsonConvert.SerializeObject(call);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");

        return httpContent;
    }
}