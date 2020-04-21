using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace DNSimple
{
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

        public async Task<IEnumerable<Account>> GetAccounts() => (await client.GetJsonAsync<Accounts.Response>("accounts")).data.Select(account => new Account(client, account));
    }
}
