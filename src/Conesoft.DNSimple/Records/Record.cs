using System;

namespace Conesoft.DNSimple
{
    namespace Records
    {
        public class Record
        {
            public int id { get; set; }
            public string zone_id { get; set; }
            public object parent_id { get; set; }
            public string name { get; set; }
            public string content { get; set; }
            public int ttl { get; set; }
            public object priority { get; set; }
            public string type { get; set; }
            public string[] regions { get; set; }
            public bool system_record { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
    }
}
