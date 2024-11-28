using BodegroASP.Converters;
using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.ViewConverter
{
    public class SubscriptionConvertert
    {
        ProtocolConvertert protocolConverter = new();
        PatientConvertert PatientConvertert = new();
        public List<SubscriptionViewModel> ListObjectToView(List<Subscription> subscriptions)
        {
            List<SubscriptionViewModel> vieuws = new List<SubscriptionViewModel>();
            foreach (Subscription subscription in subscriptions)
            {
                SubscriptionViewModel viewModel = new SubscriptionViewModel()
                {
                    StartDate = subscription.StartDate,
                    Protocol = protocolConverter.ObjectToView(subscription.Protocol),
                    Patient = PatientConvertert.ObjectToVieuw(subscription.Patient),
                    StepsTaken = subscription.StepsTaken
                };
                vieuws.Add(viewModel);
            }
            return vieuws;
        }
    }
}
