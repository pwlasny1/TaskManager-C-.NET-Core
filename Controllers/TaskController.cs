using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;


namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
        {

        };
        // GET: Task
        public ActionResult Index()
        {
            return View(tasks.Where(x=> !x.Done));
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskId = tasks.Count + 1;   
            tasks.Add(taskModel);

                return RedirectToAction(nameof(Index));              
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x=> x.TaskId == id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;

                return RedirectToAction(nameof(Index));
            
         
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x=> x.TaskId == id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(task);
            return RedirectToAction(nameof(Index));
            
      
        }
        //GET: Task/Done/5
        public ActionResult Done (int id)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Done = true;
            

            return RedirectToAction(nameof(Index));
        }
    }
}
