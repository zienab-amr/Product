using Microsoft.AspNetCore.Mvc;
using Product.Helper;
using Product.Models;
using Product.Services;

namespace Product.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorService _instructorService;
        private readonly DepartmentService _departmentService;

        public InstructorController(
            InstructorService instructorService,
            DepartmentService departmentService)
        {
            _instructorService = instructorService;
            _departmentService = departmentService;
        }

        public IActionResult ShowAll()
        {
            var instructors = _instructorService.ShowAll();

            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = _instructorService.Details(id);

            if (instructor == null)
                return NotFound();

            return View(instructor);
        }

        public IActionResult Add()
        {
            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public IActionResult SaveAdd(Instructor instructor, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                instructor.Image = ImageFile.UploadFile(imageFile, "Images");
            }

            _instructorService.Add(instructor);

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = _instructorService.Details(id);

            if (instructor == null)
                return NotFound();

            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Instructor instructor, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                instructor.Image = ImageFile.UploadFile(imageFile, "Images");
            }

            var updatedInstructor = _instructorService.Edit(id, instructor);

            if (updatedInstructor == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var instructor = _instructorService.Delete(id);

            if (instructor == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }
    }
}