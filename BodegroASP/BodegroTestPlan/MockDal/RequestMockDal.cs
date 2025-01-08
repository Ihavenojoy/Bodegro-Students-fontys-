using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    public class RequestMockDal : IRequest
    {
        public bool succes = true;
        public object Mockobject;
        public List<RequestDTO> MockDTOList;
        private List<RequestDTO> DTOList;
        public RequestMockDal() 
        {
            MockDTOList = new List<RequestDTO>();
            DTOList = new List<RequestDTO>()
            {
                new RequestDTO {id = 6, description = "Test", explanation = "Test", important = false, finished = 0 },
                new RequestDTO {id = 9, description = "Test", explanation = "Test", important = true, finished = 1 },
                new RequestDTO {id = 12, description = "Test", explanation = "Test", important = false, finished = 1 },
            };
        }

        public bool CreateRequest(RequestDTO requestDTO)
        {
            MockDTOList.Add(requestDTO);
            return succes;
        }

        public RequestDTO GetRequestById(int id)
        {
            Mockobject = id;
            MockDTOList.Add(DTOList[0]);
            return DTOList[0];
        }

        public List<RequestDTO> GetRequests()
        {
            MockDTOList = DTOList;
            return DTOList;
        }

        public bool Update(RequestDTO requestDTO)
        {
            MockDTOList.Add(requestDTO);
            return succes;
        }
    }
}
