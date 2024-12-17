using DotNetMvc.Data;
using DotNetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNetMvc.Controllers;

public class ItemsController(MyAppContext contex) : Controller
{
    private readonly MyAppContext _contex = contex;

    public async Task<IActionResult> Index()
    {
        var items = await _contex.Items.ToListAsync();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
    {
        if (ModelState.IsValid)
        {
            _contex.Items.Add(item);
            await _contex.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Edit(int id)
    {
        Item item = await _contex.Items.FirstOrDefaultAsync(x => x.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id, Name, Price")] Item item)
    {
        if (ModelState.IsValid)
        {
            _contex.Items.Update(item);
            await _contex.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return View(item);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Item item = await _contex.Items.FirstOrDefaultAsync(x => x.Id == id);
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Item item = await _contex.Items.FindAsync(id);

        if (item != null)
        {
            _contex.Items.Remove(item);
            await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(item);
    }
}
