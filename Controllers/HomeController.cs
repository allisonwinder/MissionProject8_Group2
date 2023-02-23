using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Group2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group2.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext dbContext { get; set; }

        public HomeController(TaskContext someName)
        {
            dbContext = someName;
        }

        public IActionResult Index()
        {
            new tasks = dbContext.Responses
                .Include(x => x.Categories)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult TaskManager()
        {
            ViewBag.Categories = dbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskManager(TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(tr);
                dbContext.SaveChanges();
                return View("Index", tr);
            }
            else
            {
                ViewBag.Categories = dbContext.Categories.ToList();
                return View(tr);
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = dbContext.Categories.ToList();
            var task = dbContext.Responses.Single(x => x.TaskId == taskid);
            return View("TaskManager", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse blah)
        {
            dbContext.Update(blah);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = dbContext.Responses.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            dbContext.Responses.Remove(tr);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
