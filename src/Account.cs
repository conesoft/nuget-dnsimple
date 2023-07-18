using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Conesoft.DNSimple;

public class Account
{
    readonly HttpClient client;
    readonly Accounts.Account account;

    public Account(HttpClient client, Accounts.Account account)
    {
        this.client = client;
        this.account = account;
    }

    public async Task<Domains.Domain[]> GetDomains() => (await client.GetJsonAsync<Domains.Response>($"{account.id}/domains")).data;

    public async Task<IEnumerable<Zone>> GetZones() => (await client.GetJsonAsync<Zones.Response>($"{account.id}/zones")).data.Select(zone => new Zone(client, zone));

    public async Task<Zone?> GetZone(Func<Zone, bool> predicate) => (await GetZones()).FirstOrDefault(predicate);

    public async Task<Zone?> GetZone(string name) => (await GetZones()).FirstOrDefault(zone => zone.Name == name);
}
