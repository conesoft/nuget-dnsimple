using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Conesoft.DNSimple;

static class JsonHelperMethods
{
    public static async Task<T?> GetJsonAsync<T>(this HttpClient client, string requestUri)
    {
        var stream = await client.GetStreamAsync(requestUri);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    public static async Task<HttpResponse> PostJsonAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var messageWithHeaders = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return new HttpResponse(await client.PostAsync(requestUri, messageWithHeaders));
    }

    public static async Task PatchJsonAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var messageWithHeaders = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        await client.PatchAsync(requestUri, messageWithHeaders);
    }

    public class HttpResponse
    {
        private readonly HttpResponseMessage httpResponseMessage;

        public HttpResponse(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public async Task<T?> Response<T>()
        {
            var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}