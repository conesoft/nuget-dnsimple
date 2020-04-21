using System;

namespace DNSimple.Accounts
{
    public class Account
    {
        public int id { get; set; }
        public string email { get; set; }
        public string plan_identifier { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
