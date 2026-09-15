using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Services;

namespace Product.Controllers
{
    public class CourseResultController : Controller
    {
        private readonly CourseResultService _courseResultService;
        private readonly TraineeService _traineeService;
        private readonly CourseService _courseService;
        public CourseResultController(CourseResultService courseResultService, TraineeService traineeService, CourseService courseService)
        {
            _courseResultService = courseResultService;
            _traineeService = traineeService;
            _courseService = courseService;
        }
        public IActionResult ShowAll()
        {
            var courseResults = _courseResultService.ShowAll();
            return View(courseResults);
        }
        public IActionResult Details(int Id)
        {
            var courseResult = _courseResultService.Details(Id);
            if (courseResult == null) return NotFound();

            return View(courseResult);
        }

        public IActionResult Add()
        {
            var courses = _courseService.ShowAll();

            ViewBag.Courses = courses;

            var trainees = _traineeService.ShowAll();

            ViewBag.Trainees = trainees;

            return View();
        }
        public IActionResult SaveAdd(CourseResult courseResult)
        {
            _courseResultService.Add(courseResult);
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var courseResult = _courseResultService.Details(Id);

            if (courseResult == null)
                return NotFound();

            var courses = _courseService.ShowAll();
            ViewBag.Courses = courses;

            var trainees = _traineeService.ShowAll();
            ViewBag.Trainees = trainees;

            return View(courseResult);
        }

        [HttpPost]
        public IActionResult Edit(int Id, CourseResult c)
        {
            var courseResult = _courseResultService.Edit(Id, c);

            if (courseResult == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var courseResult = _courseResultService.Delete(Id);

            if (courseResult == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }
    }
}
