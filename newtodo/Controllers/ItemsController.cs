using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Index()
        {   Item testItem = new Item("Mow the lawn");
            testItem.save();
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/items")]
        public ActionResult Create()
        {
          Item newItem = new Item (Request.Form["new-item"]);

          List<Item> allItems = Item.GetAll();
          return View("Index", allItems);
        }
        [HttpGet("/delete")]
        public ActionResult Delete()
        {
            Item.DeleteAll();
            return View("index");
        }


    }
}
