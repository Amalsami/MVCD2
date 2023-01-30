using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCD2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCD2.Controllers
{
    public class employeeController : Controller
    {
        companyContext Context = new companyContext();
        public IActionResult Index()
        {
            companyContext company = new companyContext();
            List<employee> employees = company.employees.ToList();

            return View("emp", employees);
        }
        //public IActionResult login()
        //{
        //    return View();
        //}

        ////public IActionResult savelogin(employee emp)
        ////{
        ////    HttpContext.Session.SetString("name",emp.FirstName);
        ////    HttpContext.Session.SetString("ssn", emp.SSN.ToString());
        ////    return View("emp");
        ////}
        //public IActionResult savelogin(employee emp)
        //{
        //    employee e = Context.employees.Where(e => e.SSN == emp.SSN && e.FirstName == emp.FirstName).Single();
        //    if (e != null)
        //    {
        //        HttpContext.Session.SetInt32("SSN", e.SSN);

        //    }
        //    return RedirectToAction("Profile");
        //}
        //public IActionResult Profile()
        //{
        //    employee emp = Context.employees.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).Single();
        //    return View( emp);

        //}
        ////public IActionResult add()
        ////{
        ////    Context.employees.Add(emp)
        ////}
        ///////------
        public IActionResult GetById(int id)
        {
            employee? employee = Context.employees.SingleOrDefault(e => e.SSN == id);
            if (employee == null)
            {
                return View("Error"); // view : Error , model = null
            }
            return View(employee);  // view : GetById , model = course


            //return View();    // view : GetById , model = null
            //return View("GetOne", course);  // view : GetOne , model = Course
        }

        public IActionResult Add()
        {
            List<employee> employees = Context.employees.ToList();
            return View(employees);
        }

        public IActionResult AddemployeeDb(employee employee)
        {
            Context.employees.Add(employee);
            Context.SaveChanges();

            List<employee> employees = Context.employees.ToList();
            return View("index", employees);
        }

        public IActionResult Edit(int id)
        {
            employee employee = Context.employees.SingleOrDefault(e => e.SSN == id);
            List<employee> employees = Context.employees.ToList();
            ViewBag.ins = employees;
            return View(employee);
        }

        public IActionResult EditempoloyeeDb(employee employee)
        {
            employee employeee = Context.employees.SingleOrDefault(e => e.SSN == employee.SSN);
            employeee.FirstName = employee.FirstName;
            employeee.MiddleName = employee.MiddleName;
            employeee.LastName = employee.LastName;
            employeee.Salary = employee.Salary;

            //  employee1.BirthDate = employee1.BirthDate;
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            employee employee = Context.employees.SingleOrDefault(e => e.SSN == id);
            Context.employees.Remove(employee);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("Login");

        }
        public IActionResult Check(employee emp)
        {
            employee e = Context.employees.Where(e => e.SSN == emp.SSN && e.FirstName == emp.FirstName).Single();
            if (e != null)
            {
                HttpContext.Session.SetInt32("SSN", e.SSN);
            }

            return RedirectToAction("Profile");
        }
        public IActionResult Profile()
        {
            employee emp = Context.employees.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).Single();
            return View("Profile", emp);

        }

    }
}
