using Assign6.Project1.ABBC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
            ViewBag.Categories = blahContext.Categories.ToList();
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
            var tasks = blahContext.EffectiveTasks
               .Include(x => x.Category)
               .OrderBy(i => i.DueDate)
               .ToList();

            return View(tasks);
        }
        
        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            var stuff = blahContext.EffectiveTasks.Single(x => x.TaskId == taskid);

            return View("CreateTask", stuff);
        }

        [HttpPost]
        public IActionResult EditTask(TaskResponse taskStuff)
        {
            blahContext.Update(taskStuff);
            blahContext.SaveChanges();

            return RedirectToAction("ViewTasks");
        }

        [HttpPost]
        public IActionResult CompleteTask(int taskid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            var stuff = blahContext.EffectiveTasks.Single(x => x.TaskId == taskid);

            stuff.Completed = true;

            blahContext.Update(stuff);
            blahContext.SaveChanges();

            return RedirectToAction("ViewTasks");
        }


        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var to_delete = blahContext.EffectiveTasks.Single(x => x.TaskId == taskid);

            return View(to_delete);
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskResponse tr)
        {
            blahContext.EffectiveTasks.Remove(tr);
            blahContext.SaveChanges();

            return RedirectToAction("ViewTasks");
        }
     
    }
}
