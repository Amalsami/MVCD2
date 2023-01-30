using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCD2.Models;

namespace MVCD2.Controllers
{
    public class DependentController : Controller
    {
        companyContext Context = new companyContext();
        //public IActionResult Index()
        //{
        //    List<dependent> dep = Context.dependents.Where(e => e.ESSN == HttpContext.Session.GetInt32("SSN")).ToList();
        //    return View(dep);
        //}

        //public IActionResult Add(int id)
        //{
        //    //employee emp = db.Employees.Where(e => e.SSN == id).Single();
        //    return View("Add");
        //}
        //public IActionResult Adddep(dependent dep)
        //{
        //    Context.dependents.Add(dep);
        //    Context.SaveChanges();
        //    TempData["msg"] = "You Add one Dependent";
        //    return RedirectToAction("index");
        //}


        //public IActionResult Edit(int id)
        //{
        //    dependent dep = Context.dependents.Where(e => e.id == id).Single();
        //    return View("edit", dep);
        //}
        //public IActionResult Delete(int id)
        //{
        //    dependent dep = Context.dependents.Where(e => e.id == id).Single();
        //    Context.dependents.Remove(dep);
        //    Context.SaveChanges();
        //    TempData["msg"] = "You Delete one Dependent";
        //    return RedirectToAction("index");
        //}
        //public IActionResult Update(dependent dep)
        //{
        //    var Olddep = Context.dependents.SingleOrDefault(e => e.id == dep.id);
        //    Olddep.Name = dep.Name;
        //    Olddep.BirthDate = dep.BirthDate;
        //    Olddep.Relationship = dep.Relationship;
        //    Olddep.ESSN = (int)HttpContext.Session.GetInt32("SSN");
        //    Context.SaveChanges();
        //    TempData["msg"] = "You Update one Dependent";
        //    return RedirectToAction("index");

        //}
        //// -----
  
    public IActionResult Index()
    {
        List<dependent> dependents = Context.dependents.ToList();
        return View(dependents);
    }

    public IActionResult GetById(int id)

    {
        // List<Dependent> dependents = dbContext.dependents.Where(e => e.ESSN == HttpContext.Session.GetInt32("SSN")).ToList();
        //  return View("GetById", dependents);
        //{
        dependent? dependent = Context.dependents.SingleOrDefault(e => e.ESSN == HttpContext.Session.GetInt32("SSN"));
        if (dependent == null)
        {
            return View("Error");
        }
        return View(dependent);



    }

    public IActionResult Add()
    {
        List<dependent> dependents = Context.dependents.ToList();

        return View(dependents);
    }

    public IActionResult AddemployeeDb(dependent dependent)
    {
        Context.dependents.Add(dependent);
        Context.SaveChanges();

        List<dependent> dependents = Context.dependents.ToList();
        return View("index", dependents);
    }

    public IActionResult Edit(int id)
    {
        dependent dependent = Context.dependents.SingleOrDefault(e => e.id == id);
        List<dependent> dependents = Context.dependents.ToList();
        ViewBag.ins = dependents;
        return View(dependent);
    }

    public IActionResult EditempoloyeeDb(dependent dependent)
    {
        dependent dependent1 = Context.dependents.SingleOrDefault(e => e.id == dependent.id);
        dependent1.Name = dependent.Name;
        dependent1.Sex = dependent.Sex;
        dependent1.BirthDate = dependent.BirthDate;
        dependent1.Relationship = dependent.Relationship;

        //  employee1.BirthDate = employee1.BirthDate;
        Context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        dependent dependent = Context.dependents.SingleOrDefault(e => e.id == id);
        Context.dependents.Remove(dependent);
        Context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
}


                
   

