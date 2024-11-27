namespace BodegroASP.Models
{
    public class PatientProtocol
    {
            public int Id { get; set; }
            public int PatientId { get; set; }
            public int ProtocolId { get; set; }
            public DateTime StartDate { get; set; }
            public bool IsEndless { get; set; }

    }
}
