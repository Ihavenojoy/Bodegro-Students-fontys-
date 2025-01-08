namespace DTO;

public class RequestDTO
{
    public int id { get; set; }
    public string description { get; set; }
    public string explanation { get; set; }
    public bool important { get; set; }
    public int? finished { get; set; }
}