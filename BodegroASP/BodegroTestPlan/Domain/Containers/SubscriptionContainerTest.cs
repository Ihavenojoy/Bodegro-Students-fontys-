using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using DAL;
using Domain.Containers.SubscriptionFile;
using Microsoft.Extensions.Configuration;

namespace BodegroTestPlan.Domain.Containers
{
    [TestClass]
    public class SubscriptionContainerTest
    {
        SubscriptionContainer container;
        IConfiguration configuration;
        [TestInitialize]
        public void Initialize()
        {
            SubscriptionDAL subscriptionDAL = new(configuration);
            container = new(subscriptionDAL);
        }
    }
}
