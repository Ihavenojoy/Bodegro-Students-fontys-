using DTO;

namespace Interfaces;

public interface IRequest
{
    public bool CreateRequest(RequestDTO requestDTO);
    public List<RequestDTO> GetRequests();
    public bool Update(RequestDTO requestDTO);
    public RequestDTO GetRequestById(int id);
}