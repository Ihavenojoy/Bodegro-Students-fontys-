using Domain.Modules;
using DTO;

namespace Domain.Converter;

public class RequestConverter
{
    public Request DTOToObject(RequestDTO requestDTO)
    {
        Request request = new Request(requestDTO.id, requestDTO.description, requestDTO.explanation, requestDTO.important, requestDTO.finished);
        return request;
    }

    public RequestDTO ObjectToDTO(Request request)
    {
        return new RequestDTO
        {
            id = request.id,
            description = request.description,
            explanation = request.explanation,
            important = request.important,
            finished = request.finished
        };
    }
}