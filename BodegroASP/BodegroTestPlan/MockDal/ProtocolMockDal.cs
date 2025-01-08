using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    
    public class ProtocolMockDal : IProtocol
    {
        public bool succes = true;
        public object Mockobject;
        public List<ProtocolDTO> MockDTOList;
        private List<ProtocolDTO> DTOList;
        private List<StepDTO> steplist;
        public ProtocolMockDal() 
        { 
            MockDTOList = new List<ProtocolDTO>();
            steplist = new List<StepDTO>() { new StepDTO() { ID = 6, Description = "Test", Interval = 6, Name = "Test", Order = 5, ProtocolID = 4, Test = "Test" } };
            DTOList = new List<ProtocolDTO>()
            {
               new ProtocolDTO() {ID = 6, Description = "test" , Name = "Test", Steps = steplist, User_ID = 5 },
               new ProtocolDTO() {ID = 2, Description = "test" , Name = "Test", Steps = steplist, User_ID = 8 },
               new ProtocolDTO() {ID = 9, Description = "test" , Name = "Test", Steps = steplist, User_ID = 7 }
            };
        }
        public bool CreateProtocol(ProtocolDTO protocol)
        {
            MockDTOList.Add(protocol);
            return succes;
        }

        public List<ProtocolDTO> GetAllProtocols()
        {
            MockDTOList = DTOList;
            return DTOList;
        }

        public List<ProtocolDTO> GetInactive()
        {
            MockDTOList = DTOList;
            return DTOList;
        }

        public ProtocolDTO GetProtocol(string name)
        {
            Mockobject = name;
            MockDTOList.Add(DTOList[0]);
            return DTOList[0];
        }

        public ProtocolDTO GetProtocolbyid(int id)
        {
            Mockobject = id;
            MockDTOList.Add(DTOList[0]);
            return DTOList[0];
        }

        public bool SetActive(int id)
        {
            Mockobject = id;
            return succes;
        }
    }
}
