using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    public class StepMockDal : IStep
    {
        public bool succes = true;
        public object Mockobject;
        public List<StepDTO> MockDTOList;
        private List<StepDTO> DTOList;
        public StepMockDal() 
        {
            MockDTOList = new List<StepDTO>();
            DTOList = new List<StepDTO> 
            {
                new StepDTO() {ID = 6, Description = "Test", Interval = 6, Name = "Test", Order = 1, ProtocolID = 4, Test = "Test"},
                new StepDTO() {ID = 8, Description = "Test", Interval = 2, Name = "Test", Order = 3, ProtocolID = 9, Test = "Test"},
                new StepDTO() {ID = 9, Description = "Test", Interval = 7, Name = "Test", Order = 8, ProtocolID = 13, Test = "Test"}
            };
        }

        public bool CreateStep(StepDTO protocol)
        {
            MockDTOList.Add(protocol);
            return succes;
        }

        public List<StepDTO> GetStepsOfProtocol(int protocolID)
        {
            Mockobject = protocolID;
            MockDTOList = DTOList;
            return DTOList;
        }
    }
}
