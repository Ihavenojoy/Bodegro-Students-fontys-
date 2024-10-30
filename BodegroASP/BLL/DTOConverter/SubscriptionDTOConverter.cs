using BLL.Containers;
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
        ProtocolDTOConverter protocolDTOConverter;
        public List<SubscriptionDTO> ObjectToDTO(List<Subscription> subscriptions)
        {
            List<SubscriptionDTO> list = new List<SubscriptionDTO>();
            foreach (Subscription subscription in subscriptions)
            {
                SubscriptionDTO subscriptionDTO = new SubscriptionDTO(subscription.StartDate, protocolDTOConverter.ObjectToDTO(subscription.Protocol));
                list.Add(subscriptionDTO);
            }
            return list;
        }
    }
}
