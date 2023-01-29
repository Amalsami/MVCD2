using Microsoft.AspNetCore.Mvc;
using MVCD2.Models;

namespace MVCD2.Controllers
{
    public class DependanceController : Controller
    {
        companyContext Context = new companyContext();
        public IActionResult Index()
        {
            List<dependents> dep = Context.dependents.Where(e => e.ESSN == HttpContext.Session.GetInt32("SSN")).ToList();
            return View(dep);
        }

        public IActionResult Add(int id)
        {
            //employee emp = db.Employees.Where(e => e.SSN == id).Single();
            return View("Add");
        }
           public IActionResult Adddep(dependents dep)
           {
              Context.dependents.Add(dep);
              Context.SaveChanges();
            TempData["msg"] = "You Add one Dependent";
            return RedirectToAction("index");
           }
                        

            public IActionResult Edit(int id)
            {
                dependents dep = Context.dependents.Where(e => e.id == id).Single();
                return View("edit", dep);
            }
            public IActionResult Delete(int id)
            {
                dependents dep = Context.dependents.Where(e => e.id == id).Single();
                Context.dependents.Remove(dep);
                Context.SaveChanges();
                TempData["msg"] = "You Delete one Dependent";
                return RedirectToAction("index");
            }
            public IActionResult Update(dependents dep)
            {
                var Olddep = Context.dependents.SingleOrDefault(e => e.id == dep.id);
                Olddep.Name = dep.Name;
                Olddep.BirthDate = dep.BirthDate;
                Olddep.Relationship = dep.Relationship;
                Olddep.ESSN = (int)HttpContext.Session.GetInt32("SSN");
                Context.SaveChanges();
                TempData["msg"] = "You Update one Dependent";
                return RedirectToAction("index");
            }

    }
}

