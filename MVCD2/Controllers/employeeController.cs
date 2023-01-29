using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCD2.Models;
using System.Collections.Generic;

namespace MVCD2.Controllers
{
    public class employeeController : Controller
    {
        companyContext Context = new companyContext();
        public IActionResult Index()
        {
            companyContext company=new companyContext();
            List <employee> employees = company.employees.ToList();

            return View("emp",employees);
        }
        public IActionResult login()
        {
            return View();
        }

        //public IActionResult savelogin(employee emp)
        //{
        //    HttpContext.Session.SetString("name",emp.FirstName);
        //    HttpContext.Session.SetString("ssn", emp.SSN.ToString());
        //    return View("emp");
        //}
        public IActionResult savelogin(employee emp)
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
            return View( emp);

        }
        //public IActionResult add()
        //{
        //    Context.employees.Add(emp)
        //}
    }
}
