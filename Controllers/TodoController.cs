using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApp01.Models;

namespace TodoApp01.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> todos = new List<Todo>();

        public IActionResult Index()
        {
            return View(todos);
        }

        [HttpPost]
        public IActionResult AddTodo(string title)
        {
            var todo = new Todo { Title = title };
            todos.Add(todo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleDone(int id)
        {
            var todo = todos.Find(t => t.Id == id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
            }
            return RedirectToAction("Index");
        }
    }

}
