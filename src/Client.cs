using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Conesoft.DNSimple;

public class Client
{
    readonly HttpClient client;

    public Client(HttpClient client)
    {
        this.client = client;
        client.BaseAddress = new Uri(@"https://api.dnsimple.com/v2/");
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
    }

    public void UseToken(string token) => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    public async Task<IEnumerable<Account>> GetAccounts() => (await client.GetJsonAsync<Accounts.Response?>("accounts"))?.data.Select(account => new Account(client, account)) ?? Array.Empty<Account>();

    public async Task<Account?> GetAccount(string mail) => (await client.GetJsonAsync<Accounts.Response?>("accounts"))?.data.Where(a => a.email == mail).Select(account => new Account(client, account)).FirstOrDefault();
}