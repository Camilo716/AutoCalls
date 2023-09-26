

using System.Text;
using AutoCallsApi.Models;
using Newtonsoft.Json;

internal static class NumberUtilities
{
    internal static HttpContent GetNumberHttpContent(int numberValue)
    {
        Number number = new Number { NumberValue = numberValue };
        string jsonContent = JsonConvert.SerializeObject(number);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }

    internal static async Task<Number> GetNumberModelFromHttpResponse(HttpResponseMessage response)
    {
        string numberJson = await response.Content.ReadAsStringAsync();
        Number numberModel = JsonConvert.DeserializeObject<Number>(numberJson)!;
        return numberModel;
    }
}