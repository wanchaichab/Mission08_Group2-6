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
            var model = new Dictionary<int, List<TaskEntry>>();
            for (int i = 1; i <= 4; i++) {
                var data = taskContext.Entries
                    .Include(x => x.Category)
                    .Where(x => x.Completed == false)
                    .Where(x => x.Quadrant == i)
                    .ToList();
                model.Add(i, data);
            }
            return View(model);
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

                return RedirectToAction("Index");
            }

            else // Go back to the add task page
            {
                ViewBag.Category = taskContext.Categories.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            ViewBag.Category = taskContext.Categories.ToList(); // load categories

            var task = taskContext.Entries.Single(x => x.TaskId == TaskID);

            return View("Task", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskEntry response)
        {
            taskContext.Update(response);
            taskContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int TaskID)
        {
            var task = taskContext.Entries.Single(x => x.TaskId == TaskID);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskEntry response)
        {
            taskContext.Entries.Remove(response);
            taskContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finish(int TaskID)
        {
            var task = taskContext.Entries.Single(x => x.TaskId == TaskID);
            task.Completed = true;
            taskContext.Entries.Update(task);
            taskContext.SaveChanges();
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

