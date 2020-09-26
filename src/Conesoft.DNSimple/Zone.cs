using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Conesoft.DNSimple
{
    public class Zone
    {
        readonly HttpClient client;
        readonly Zones.Zone zone;

        public Zone(HttpClient client, Zones.Zone zone)
        {
            this.client = client;
            this.zone = zone;
        }

        public string Name => zone.name;

        public async Task<IEnumerable<Record>> GetRecords() => (await client.GetJsonAsync<Records.Response>($"{zone.account_id}/zones/{zone.id}/records")).data.Select(record => new Record(client, zone, record));

        public async Task<Record> GetRecord(Func<Record, bool> predicate) => (await GetRecords()).FirstOrDefault(predicate);
        public Task<Record> GetRecord(RecordType type) => GetRecord(record => record.Type == type.Type);

        public async Task<Record> AddRecord(RecordType type, string name, string content, TimeSpan timeToLife)
        {
            var response = await client.PostJsonAsync($"{zone.account_id}/zones/{zone.id}/records", new
            {
                name,
                type = type.Type,
                content,
                ttl = (int)timeToLife.TotalSeconds
            });
            var record = (await response.Response<Records.SingleResponse>()).data;
            return new Record(client, zone, record);
        }
    }
}
