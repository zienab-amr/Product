using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Services;

namespace Product.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult ShowAll()
        {
            var departments = _departmentService.ShowAll();

            return View(departments);
        }

        public IActionResult Details(int Id)
        {
            var department = _departmentService.Details(Id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAdd(Department department)
        {
            _departmentService.Add(department);

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var department = _departmentService.Details(Id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Department d)
        {
            var department = _departmentService.Edit(Id, d);

            if (department == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var department = _departmentService.Delete(Id);

            if (department == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }
    }
}