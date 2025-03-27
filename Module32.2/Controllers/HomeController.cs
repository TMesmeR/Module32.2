using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Module32._2.Models;
using Module32._2.Repocitorys;

namespace Module32._2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogDbRepository _blogDbRepository;
    public HomeController(ILogger<HomeController> logger, IBlogDbRepository blogDbRepository)
    {
        _blogDbRepository = blogDbRepository;
        _logger = logger;
    }
    public  async Task <IActionResult> Index()
    {

        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}