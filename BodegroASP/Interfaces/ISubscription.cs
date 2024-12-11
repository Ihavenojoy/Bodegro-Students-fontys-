using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISubscription
    {
        public bool CreateSubscription(SubscriptionDTO subscriptionDTO);
        public List<SubscriptionDTO> GetSubscriptionsOfPatiënt(int PatiëntID);
        public bool SoftDeleteSubscription(int id);
        public Task<List<SubscriptionDTO>> AsyncGetAll();
        public List<SubscriptionDTO> GetAll();
    }
}
