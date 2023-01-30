using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCD2.Controllers;
using MVCD2.Models;

namespace MVCD2.Controllers
{
    public class projectController : Controller
    {
        companyContext db = new companyContext();
        public IActionResult Index()
        {
            var projects = db.projects.ToList();
            return View(projects);
        }
        public IActionResult addProjectForm()
        {
            var depts = new SelectList(db.departments.ToList(), "Number", "Name");
            ViewBag.depts = depts;
            return View();
        }
        public IActionResult addProject(project p)
        {
            db.projects.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult updateForm(int id)
        {
            var proj = db.projects.SingleOrDefault(d => d.Number == id);
            var departList = new SelectList(db.departments.ToList(), " Number", "Name");
            ViewBag.list = departList;
            return View(proj);
        }
        public IActionResult updateProject(project proj)
        {
            var old = db.projects.SingleOrDefault(d => d.Number == proj.Number);
            old.Name = proj.Name;
            old.Location = proj.Location;
            old.DeptNum = proj.DeptNum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult deleteProject(int id)
        {
            var proj = db.projects.SingleOrDefault(d => d.Number == id);
            db.projects.Remove(proj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
