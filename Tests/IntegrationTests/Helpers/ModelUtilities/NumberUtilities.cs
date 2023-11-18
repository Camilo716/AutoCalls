using System.Text;
using AutoCallsApi.DTOs;
using AutoCallsApi.Models;
using Newtonsoft.Json;

internal static class NumberUtilities
{
    internal static HttpContent GetNumberHttpContent(string numberValue)
    {
        NumberCreationDTO number = new NumberCreationDTO { NumberValue = numberValue };
        string jsonContent = JsonConvert.SerializeObject(number);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }

    internal static async Task<ICollection<Number>> GetNumbersCollectionFromHttpResponse(HttpResponseMessage response)
    {
        string numberJson = await response.Content.ReadAsStringAsync();
        ICollection<Number> numbersModel = JsonConvert.DeserializeObject<ICollection<Number>>(numberJson)!;
        return numbersModel;
    }
}