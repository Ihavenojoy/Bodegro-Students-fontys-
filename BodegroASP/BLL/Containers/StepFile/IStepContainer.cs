using Domain.Modules;

namespace Domain.Containers.StepFile
{
    public interface IStepContainer
    {
        bool AddStep(Step step);
        List<Step> GetStepsOfProtocol(Protocol protocol);
    }
}