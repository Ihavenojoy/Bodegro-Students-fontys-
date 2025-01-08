using Domain.Converter;
using Domain.Modules;
using Interfaces;
using DTO;

namespace Domain.Containers;

public class RequestContainer
{
    IRequest _request;
    RequestConverter requestConverter = new();
    
    public RequestContainer(IRequest request)
    {
        _request = request;
    }
    
    public bool CreateRequest(Request request)
    {
        try
        {
            bool sucess = _request.CreateRequest(requestConverter.ObjectToDTO(request));
            return sucess;
        }
        catch (Exception e)
        {
            throw new Exception("Failed to create user.");
        }
    }

    public List<Request> GetRequests()
    {
        try
        {
            List<RequestDTO> DTOs = _request.GetRequests();
            return DTOs.Select(r => requestConverter.DTOToObject(r)).ToList();
        }
        catch
        {
            throw new Exception("Failed to get all requests");
        }
    }

    public bool Update(Request request)
    {
        return _request.Update(requestConverter.ObjectToDTO(request));
    }

    public Request GetRequestById(int id)
    {
        RequestDTO requestDTO = _request.GetRequestById(id);
        return requestConverter.DTOToObject(requestDTO);
    }
}