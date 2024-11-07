using Domain.DTOConverter;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
