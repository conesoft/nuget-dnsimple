using System;

namespace Conesoft.DNSimple
{
    namespace Zones
    {
        public class Zone
        {
            public int id { get; set; }
            public int account_id { get; set; }
            public string name { get; set; }
            public bool reverse { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
    }
}
