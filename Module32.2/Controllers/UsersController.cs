using Microsoft.AspNetCore.Mvc;
using Module32._2.Models;
using Module32._2.Repocitorys;

namespace Module32._2.Controllers;

public class UsersController: Controller
{
    private readonly IBlogDbRepository _repo;
    public UsersController(IBlogDbRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<IActionResult> Index()
    {
        var authors = await _repo.GetUsers();
        return View(authors);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
          await _repo.Register(user);
          return View(user);
    }
}