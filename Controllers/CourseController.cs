using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Services;

namespace Product.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;

        public CourseController(CourseService courseService, DepartmentService departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }
        public IActionResult ShowAll()
        {
            var courses = _courseService.ShowAll();
            return View(courses);
        }
        public IActionResult Details(int Id)
        {
            var course = _courseService.Details(Id);
            if (course == null) return NotFound();

            return View(course);
        }

        public IActionResult Add()
        {
            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View();
        }
        public IActionResult SaveAdd(Course course)
        {
            _courseService.Add(course);
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var course = _courseService.Details(Id);

            if (course == null) return NotFound();

            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Course c)
        {
            var course = _courseService.Edit(Id, c);
            if (course == null) return NotFound();

            return RedirectToAction("ShowAll");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var course = _courseService.Delete(Id);

            if (course == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }
    }
}
