using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

namespace Conesoft.DNSimple
{
    public class Record
    {
        readonly HttpClient client;
        readonly Zones.Zone zone;
        readonly Records.Record record;

        public Record(HttpClient client, Zones.Zone zone, Records.Record record)
        {
            this.client = client;
            this.zone = zone;
            this.record = record;
        }

        public string Type => record.type;
        public string Content => record.content;

        public async Task UpdateContent(string content)
        {
            var patch = new StringContent(JsonSerializer.Serialize(new
            {
                content
            }));
            patch.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PatchAsync($"{zone.account_id}/zones/{zone.id}/records/{record.id}", patch);
        }
    }
}
