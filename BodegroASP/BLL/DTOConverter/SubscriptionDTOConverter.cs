using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class SubscriptionDTOConverter
    {
        ProtocolDTOConverter protocolDTOConverter = new();
        PatientDTOConverter patientDTOConverter = new();
        public SubscriptionDTO ObjectToDTO(Subscription subscription)
        {
            SubscriptionDTO subscriptionDTO = new SubscriptionDTO
            {
                StartDate = subscription.StartDate,
                Protocol = protocolDTOConverter.ObjectToDTO(subscription.Protocol),
                Patient = patientDTOConverter.ObjectToDTO(subscription.Patient)
            };
            return subscriptionDTO;
        }
    }
}
