using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpGet("/items/{id}")]
    public ActionResult Details(int id)
    {
      Item item = Item.Find(id);
      return View(item);
    }

    [HttpPost("/items/{id}")]
    public ActionResult Det(int id)
    {
      Item newItem = new Item(Request.Form["new-item"]);
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

  }
}
