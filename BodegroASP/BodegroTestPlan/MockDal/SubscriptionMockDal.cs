using Domain.Modules;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    public class SubscriptionMockDal : ISubscription
    {
        public bool succes = true;
        public object Mockobject;
        public List<SubscriptionDTO> MockDTOList;
        private List<SubscriptionDTO> DTOList;
        public SubscriptionMockDal() 
        {
            MockDTOList = new List<SubscriptionDTO>();
            DTOList = new List<SubscriptionDTO>()
            {
                new SubscriptionDTO {ID = 6, PatientID = 8, ProtocolID = 4, StartDate = DateTime.Now, StepsTaken = 6 },
                new SubscriptionDTO {ID = 9, PatientID = 10, ProtocolID = 42, StartDate = DateTime.Now, StepsTaken = 56 },
                new SubscriptionDTO {ID = 2, PatientID = 89, ProtocolID = 44, StartDate = DateTime.Now, StepsTaken = 90 }
            };
        }

        public Task<List<SubscriptionDTO>> AsyncGetAll()
        {
            MockDTOList = DTOList;
            return Task.FromResult(DTOList);
        }

        public bool CreateSubscription(SubscriptionDTO subscriptionDTO)
        {
            Mockobject = subscriptionDTO;
            return succes;
        }

        public List<SubscriptionDTO> GetAll()
        {
            MockDTOList = DTOList;
            return DTOList;
        }

        public List<SubscriptionDTO> GetInactive()
        {
            MockDTOList = DTOList;
            return DTOList;
        }

        public List<SubscriptionDTO> GetSubscriptionsOfPatiënt(int PatiëntID)
        {
            Mockobject = PatiëntID;
            MockDTOList = DTOList;
            return DTOList;
        }

        public bool SetActive(int id)
        {
            Mockobject = id;
            return succes;
        }

        public bool SoftDeleteSubscription(int id)
        {
            Mockobject = id;
            return succes;
        }
    }
}
