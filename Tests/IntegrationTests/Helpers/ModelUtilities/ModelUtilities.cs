using System.Text;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers.ModelUtilities;

public class ModelUtilities
{
    internal static async Task<List<T>> GetModelListFromHttpResponsesAsync<T>(List<HttpResponseMessage> responses)
    {
        var modelList = new List<T>();

        foreach (var response in responses)
        {
            T model = await GetModelFromHttpResponseAsync<T>(response);
            modelList.Add(model);
        }

        return modelList;
    }

    internal static async Task<T> GetModelFromHttpResponseAsync<T>(HttpResponseMessage response)
    {
        string json = await response.Content.ReadAsStringAsync();
        T model = JsonConvert.DeserializeObject<T>(json)!;
        return model;
    } 

    internal static HttpContent GetHttpContentFromModel<T>(T model)
    {
        string jsonContent = JsonConvert.SerializeObject(model);
        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }
}