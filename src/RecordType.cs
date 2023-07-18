namespace Conesoft.DNSimple;

public class RecordType
{
    public static RecordType A { get; } = new RecordType("A");
    public static RecordType TXT { get; } = new RecordType("TXT");


    readonly string type;
    public string Type => type;

    public RecordType(string type)
    {
        this.type = type;
    }
}