using DotNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMvc.Controllers;

// [Route("[controller]")]
public class ItemsController : Controller
{
    // private readonly ILogger<ItemsController> _logger;

    // public ItemsController(ILogger<ItemsController> logger)
    // {
    //     _logger = logger;
    // }

    // overview route
    public IActionResult Overview()
    {
        Item i = new() { Id = 1, Name = "Keyboard" };
        return View(i);
    }

    public IActionResult Edit(int itemId)
    {
        return Content($"id={itemId}");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
