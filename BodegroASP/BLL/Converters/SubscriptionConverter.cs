
using DAL;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Modules;
using DTO;
using Microsoft.Extensions.Configuration;

namespace Domain.Converter
{
    public class SubscriptionConverter
    {
        IConfiguration _configuration;
        ProtocolConverter protocolConverter = new();
        ProtocolContainer protocolContainer;
        PatientConverter patientConverter = new();
        PatientContainer patientContainer;
        public SubscriptionConverter()
        {
            ProtocolDAL protocolDal = new(_configuration);
            StepDAL stepDal = new(_configuration);
            protocolContainer = new(protocolDal, stepDal);
            PatientDAL patientDal = new(_configuration);
            patientContainer = new(patientDal);
        }
        public List<Subscription> ListDTOToListObject(List<SubscriptionDTO> subscriptionsDTO)
        {
            List<Subscription> list = new List<Subscription>();
            foreach (SubscriptionDTO subscriptionDTO in subscriptionsDTO)
            {
                Subscription subscription = new Subscription(subscriptionDTO.ID, subscriptionDTO.StartDate, protocolContainer.GetProtocolbyid(subscriptionDTO.ProtocolID), patientContainer.GetPatient(subscriptionDTO.PatientID));
                list.Add(subscription);
            }
            return list;
        }

        public SubscriptionDTO ObjectToDTO(Subscription subscription)
        {
            SubscriptionDTO subscriptionDTO = new SubscriptionDTO
            {
                StartDate = subscription.StartDate,
                ProtocolID = protocolConverter.ObjectToDTO(subscription.Protocol).ID,
                PatientID = patientConverter.ObjectToDTO(subscription.Patient).ID
            };
            return subscriptionDTO;
        }

    }
}
