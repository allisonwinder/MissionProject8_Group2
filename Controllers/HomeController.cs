using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MatrixInfoContext DbContext { get; set; }

        public HomeController(MatrixInfoContext someName)
        {
            DbContext = someName;
        }

        public IActionResult Index()
        {
            var tasks = DbContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult TaskManager()
        {
            ViewBag.Categories = DbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskManager(MatrixResponse tr)
        {
            if (ModelState.IsValid)
            {
                DbContext.Add(tr);
                DbContext.SaveChanges();
                return View("Confirmation", tr);
            }
            else
            {
                ViewBag.Categories = DbContext.Categories.ToList();
                return View(tr);
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = DbContext.Categories.ToList();
            var task = DbContext.responses.Single(x => x.MatrixId == taskid);
            return View("TaskManager", task);
        }

        [HttpPost]
        public IActionResult Edit(MatrixResponse blah)
        {
            DbContext.Update(blah);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = DbContext.responses.Single(x => x.MatrixId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(MatrixResponse tr)
        {
            DbContext.responses.Remove(tr);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
