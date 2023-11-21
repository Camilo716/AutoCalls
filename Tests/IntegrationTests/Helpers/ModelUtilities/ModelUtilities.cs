using Newtonsoft.Json;

namespace IntegrationTests.Helpers.ModelUtilities;

public class ModelUtilities
{
    internal static async Task<List<T>> GetModelListFromHttpResponsesAsync<T>(List<HttpResponseMessage> responses)
    {
        var modelList = new List<T>();

        foreach (var response in responses)
        {
            string json = await response.Content.ReadAsStringAsync();
            T model = JsonConvert.DeserializeObject<T>(json)!;
            modelList.Add(model);
        }

        return modelList;
    }
}