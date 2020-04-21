using System;

namespace Conesoft.DNSimple
{
    namespace Domains
    {
        public class Domain
        {
            public int id { get; set; }
            public int account_id { get; set; }
            public int registrant_id { get; set; }
            public string name { get; set; }
            public string unicode_name { get; set; }
            public string state { get; set; }
            public bool auto_renew { get; set; }
            public bool private_whois { get; set; }
            public string expires_on { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
    }
}
