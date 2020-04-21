namespace DNSimple
{
    namespace Domains
    {
        public class Response
        {
            public Domain[] data { get; set; }
            public Pagination pagination { get; set; }
        }
    }
}
