﻿using BLL.Containers;
using BLL.DTOConverter;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
{
    public class SubscriptionConverter
    {
        ProtocolConverter protocolConverter;
        public List<Subscription> DTOToObject(List<SubscriptionDTO> subscriptionsDTO)
        {
            List<Subscription> list = new List<Subscription>();
            foreach (SubscriptionDTO subscriptionDTO in subscriptionsDTO)
            {
                Subscription subscription = new Subscription(subscriptionDTO.StartDate, protocolConverter.DTOToObject(subscriptionDTO.Protocol));
                list.Add(subscription);
            }
            return list;
        }
    }
}
