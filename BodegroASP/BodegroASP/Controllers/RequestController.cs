using Domain.Containers;
using Interfaces;
using Domain.Modules;
using Microsoft.AspNetCore.Mvc;
using BodegroASP.Models;

namespace BodegroASP.Controllers;

public class RequestController : Controller
{
    private RequestContainer _container;
    private IRequest DAL;
    
    public RequestController(IRequest dal)
    {
        DAL = dal;
        _container = new RequestContainer(DAL);
    }

    public IActionResult Index()
    {
        List<Request> requests = _container.GetRequests();
        List<RequestViewModel> listModels = new List<RequestViewModel>();

        foreach (Request request in requests)
        {
            RequestViewModel model = new RequestViewModel()
            {
                id = request.id,
                important = request.important,
                finished = request.finished,
            };
            listModels.Add(model);
        }
        return View(listModels);
    }

    public IActionResult CreateRequest()
    {
        var model = new CreateRequestModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult CreateRequestForReal(CreateRequestModel request)
    {
        Request newRequest = new Request()
        {
            description = request.Description,
            explanation = request.Explanation,
            important = request.Important
        };

        bool created = _container!.CreateRequest(newRequest);
        if (created)
        {
            return RedirectToAction("Index", "Home");
        }
        return RedirectToAction("CreateRequest", "Request");
    }

    public IActionResult UpdateRequest(int id, int accepted)
    {
        Request request = _container.GetRequestById(id);
        request.finished = accepted;
        bool updated = _container.Update(request);

        if(updated)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public IActionResult GetRequest(int id)
    {

        Request request = _container.GetRequestById(id);

        RequestDetailsViewModel detailsViewModel = new RequestDetailsViewModel()
        {
            id = request.id,
            description = request.description,
            explanation = request.explanation,
            important = request.important,
            finished = request.finished,
        };

        return View("GetRequestView", detailsViewModel);
    }
}