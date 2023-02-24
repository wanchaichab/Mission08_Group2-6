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
            return View();
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

                return View("Index");
            }

            else // Go back to the add task page
            {
                ViewBag.Category = taskContext.Categories.ToList();
                return View();
            }
            
        }

        public IActionResult Quadrant()
        {
            var tasks = taskContext.Entries
                .Include(x => x.Category)
                .ToList();

            return View(tasks);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

