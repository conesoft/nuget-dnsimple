using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace DNSimple
{
    static class JsonHelperMethods
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string requestUri)
        {
            var stream = await client.GetStreamAsync(requestUri);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
