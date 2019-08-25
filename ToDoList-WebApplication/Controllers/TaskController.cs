using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList_WebApplication.Models;
using Task = ToDoList_WebApplication.Models.Task;

namespace ToDoList_WebApplication.Controllers
{
    public class TaskController : Controller
    {
        // Data Access for tasks from objtask
        TaskDAL objtask = new TaskDAL();


        public IActionResult Index()
        {
            List<Task> lstTask = new List<Task>();
            lstTask = objtask.GetAllTasks().ToList();
            ViewBag.Checked = " ";
            
            return View(lstTask);
        }

        [HttpPost]
        public IActionResult Index(Task task)
        {
            
            ViewBag.Checked = "Toggle button checked";
            

            return View(task);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Task task)
        {
            if (ModelState.IsValid)
            {
                objtask.AddTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Task task = objtask.GetTaskData(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Task task)
        {
            if (id != task.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objtask.UpdateTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Task task = objtask.GetTaskData(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Task task = objtask.GetTaskData(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objtask.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}