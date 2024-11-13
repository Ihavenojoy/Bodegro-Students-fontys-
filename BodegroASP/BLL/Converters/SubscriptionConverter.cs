
using Domain.Modules;
using DTO;

namespace Domain.ObjectConverter
{
    public class SubscriptionConverter
    {
        ProtocolConverter protocolConverter = new();
        PatientConverter patientConverter = new();
        public List<Subscription> ListDTOToListObject(List<SubscriptionDTO> subscriptionsDTO)
        {
            List<Subscription> list = new List<Subscription>();
            foreach (SubscriptionDTO subscriptionDTO in subscriptionsDTO)
            {
                Subscription subscription = new Subscription(subscriptionDTO.StartDate, protocolConverter.DTOToObject(subscriptionDTO.Protocol), patientConverter.DTOToObject(subscriptionDTO.Patient));
                list.Add(subscription);
            }
            return list;
        }

        public SubscriptionDTO ObjectToDTO(Subscription subscription)
        {
            SubscriptionDTO subscriptionDTO = new SubscriptionDTO
            {
                StartDate = subscription.StartDate,
                Protocol = protocolConverter.ObjectToDTO(subscription.Protocol),
                Patient = patientConverter.ObjectToDTO(subscription.Patient)
            };
            return subscriptionDTO;
        }

    }
}
