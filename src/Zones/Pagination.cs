namespace Conesoft.DNSimple.Zones;

public class Pagination
{
    public int current_page { get; set; }
    public int per_page { get; set; }
    public int total_entries { get; set; }
    public int total_pages { get; set; }
}