using DAL;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.SubscriptionFile;
using Domain.Containers.UserFile;
using Domain.Modules;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetInactive
    {
        PatientContainer PatientContainer { get; set; }
        ProtocolContainer ProtocolContainer { get; set; }
        UserContainer UserContainer { get; set; }
        SubscriptionContainer SubscriptionContainer { get; set; }

        public GetInactive(IPatient patient, IProtocol protocol, IStep step, IUser user, ISubscription subscription)
        {
            PatientContainer = new(patient);
            ProtocolContainer = new(protocol, step);
            UserContainer = new(user);
            SubscriptionContainer = new(subscription);
        }
        public List<Patient> GetPatients()
        {
            List<Patient> result = PatientContainer.GetInactivePatients();
            return result;
        }
        public List<Protocol> GetProtocols()
        {
            List<Protocol> result = ProtocolContainer.GetInactiveProtocols();
            return result;
        }
        public List<Subscription> GetSubscriptions()
        {
            List<Subscription> result = SubscriptionContainer.GetInactiveSubscriptions();
            return result;
        }
        public List<User> GetUsers()
        {
            List<User> result = UserContainer.GetInactiveUsers();
            return result;
        }
    }
}
