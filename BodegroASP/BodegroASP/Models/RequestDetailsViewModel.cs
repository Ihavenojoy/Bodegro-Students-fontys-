namespace BodegroASP.Models;

public class RequestDetailsViewModel
{
    public int id { get; set; }
    public string description { get; set; }
    public string explanation { get; set; }
    public bool important {  get; set; }
    public int? finished { get; set; }
}