namespace Domain.Modules;

public class Request
{
    public int id { get; set; }
    public string description { get; set; }
    public string explanation { get; set; }
    public bool important { get; set; }
    public int? finished { get; set; }

    public Request(int id, string description, string explanation, bool important, int? finished)
    {
        this.id = id;
        this.description = description;
        this.explanation = explanation;
        this.important = important;
        this.finished = finished;
    }
    
    public Request(string description, string explanation, bool important, int? finished)
    {
        this.description = description;
        this.explanation = explanation;
        this.important = important;
    }
    public Request()
    {
        
    }

}