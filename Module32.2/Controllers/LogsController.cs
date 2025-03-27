using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Module32._2.Repocitorys;


namespace Module32._2.Controllers;

public class LogsController: Controller
{
    private readonly ILoggingDbRepository _repository;
    public LogsController(ILoggingDbRepository repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> Index()
    {
        var requests = await _repository.GetAllRequests();
        return View(requests);
    }
}