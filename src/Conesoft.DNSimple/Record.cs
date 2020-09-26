using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        public int Id => record.id;
        public string Type => record.type;
        public string Name => record.name;
        public string Content => record.content;
        public TimeSpan TimeToLive => TimeSpan.FromSeconds(record.ttl);

        public async Task Update(string content)
        {
            await client.PatchJsonAsync($"{zone.account_id}/zones/{zone.id}/records/{record.id}", new
            {
                content
            });
        }

        public async Task Delete()
        {
            await client.DeleteAsync($"{zone.account_id}/zones/{zone.id}/records/{record.id}");
        }
    }
}
