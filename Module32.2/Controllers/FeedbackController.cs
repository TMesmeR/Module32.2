using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Module32._2.Models;

namespace Module32._2.Controllers;

public class FeedbackController:Controller
{
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Feedback feedback)
    {
        return StatusCode(200, $"{feedback.Form}, спасибо за отзыв");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel() {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}