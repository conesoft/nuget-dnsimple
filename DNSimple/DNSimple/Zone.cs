using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace DNSimple
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
    }
}
