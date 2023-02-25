using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_Group2_6.Models;

namespace Mission08_Group2_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TaskEntryContext taskContext { get; set; }

        public HomeController(TaskEntryContext x)
        {
            taskContext = x;
        }

        public IActionResult Index()
        {
            var tasks = taskContext.Entries
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Category = taskContext.Categories.ToList(); // load categories

            return View();
        }

        [HttpPost]
        public IActionResult Task(TaskEntry te)
        {
            if (ModelState.IsValid) // Validate data
            {
                taskContext.Add(te);  // add data to database
                taskContext.SaveChanges(); // save data to database

                return View("Index", te);
            }

            else // Go back to the add task page
            {
                ViewBag.Category = taskContext.Categories.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Category = taskContext.Categories.ToList();

            var task = taskContext.Entries.Single(x => x.TaskId == taskid);

            return View("Task", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskEntry te)
        {
            taskContext.Update(te);
            taskContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = taskContext.Entries.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskEntry te)
        {
            taskContext.Remove(te);
            taskContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

