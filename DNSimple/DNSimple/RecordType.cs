namespace DNSimple
{
    public class RecordType
    {
        public static RecordType A { get; } = new RecordType("A");


        readonly string type;
        public string Type => type;

        public RecordType(string type)
        {
            this.type = type;
        }
    }
}
