using System.Text;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers;

internal static class CallUtilities
{
    internal static HttpContent GetCallHttpContent(int numberId, int audioId)
    {
        CallCreationDTO call = new CallCreationDTO 
        {
            NumberId = numberId,
            AudioId = audioId 
        };
        string jsonContent = JsonConvert.SerializeObject(call);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }
}