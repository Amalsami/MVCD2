using Microsoft.AspNetCore.Mvc;
using MVCD2.Models;
using System.Collections.Generic;

namespace MVCD2.Controllers
{
    public class employeeController : Controller
    {
        public IActionResult Index()
        {
            companyContext company=new companyContext();
            List <employee> employees = company.employees.ToList();

            return View("emp",employees);
        }
    }
}
