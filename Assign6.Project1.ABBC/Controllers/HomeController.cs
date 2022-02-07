using Assign6.Project1.ABBC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assign6.Project1.ABBC.Controllers
{

    public class HomeController : Controller
    {
        private TaskContext blahContext { get; set; }

        public HomeController(TaskContext someName)
        {
            blahContext = someName;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Category = blahContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TaskResponse at)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(at);
                blahContext.SaveChanges();

                return View("Confirmation", at);
            }
            else //if invalid, send back to the form and see error messages
            {
                ViewBag.Category = blahContext.Categories.ToList();
                return View(at);
            }
        }

        public IActionResult ViewTasks()
        {
            var tasks = blahContext.Response
               .Include(x => x.Category)
               .OrderBy(i => i.Title)
               .ToList();

            return View(tasks);
        }
        
        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Category = blahContext.Categories.ToList();

            var task = blahContext.Response.Single(x => x.TaskID == taskid);

            return View("Tasks", task);
        }

        [HttpPost]
        public IActionResult EditTask(TaskResponse task)
        {
            blahContext.Update(task);
            blahContext.SaveChanges();

            return RedirectToAction("TaskList");
        }
        
        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var to_delete = blahContext.Response.Single(x => x.TaskID == taskid);

            return View(to_delete);
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskResponse tr)
        {
            blahContext.Response.Remove(tr);
            blahContext.SaveChanges();

            return RedirectToAction("TaskList");
        }
     
    }
}
