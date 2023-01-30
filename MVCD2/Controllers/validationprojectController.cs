using Microsoft.AspNetCore.Mvc;
using MVCD2.Models;

namespace MVCD2.Controllers
{
    public class validationprojectController : Controller
    {

      companyContext context = new companyContext();
        public IActionResult Index()
        {
            List<project> projects = context.projects.ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Add(project project)
        {

            if (ModelState.IsValid)
            {
                project project1 = new project()
                {
                    Name = project.Name,
                    Location = project.Location,
                };

                context.projects.Add(project1);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
