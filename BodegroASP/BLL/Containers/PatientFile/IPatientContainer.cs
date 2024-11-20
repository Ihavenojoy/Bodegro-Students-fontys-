using Domain.Modules;

namespace Domain.Containers.PatientFile
{
    public interface IPatientContainer
    {
        List<Patient> GetPatientsOfUser(User User);
    }
}