using Microsoft.AspNetCore.Mvc;
using Product.Helper;
using Product.Models;
using Product.ModelVM;
using Product.Services;

namespace Product.Controllers
{
    public class TraineeController : Controller
    {
        private readonly TraineeService _traineeService;
        private readonly DepartmentService _departmentService;

        public TraineeController(
            TraineeService traineeService,
            DepartmentService departmentService)
        {
            _traineeService = traineeService;
            _departmentService = departmentService;
        }

        public IActionResult ShowAll()
        {
            var trainees = _traineeService.ShowAll();

            return View(trainees);
        }

        public IActionResult Details(int id)
        {
            var trainee = _traineeService.Details(id);

            if (trainee == null)
                return NotFound();

            ViewData["Advertisement"] = "ITI .NET Training";
            ViewData["Color"] = "Blue";

            ViewBag.Branches = "Cairo - Alexandria";
            ViewBag.Temp = "25°C";

            var model = new TraineeAdvertisementColorBranchesTempViewModel
            {
                TraineeName = trainee.Name,
                TraineeImage = trainee.Image,
                DepartmentName = trainee.Department.Name
            };

            return View(model);
        }

        public IActionResult Add()
        {
            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public IActionResult SaveAdd(Trainee trainee, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                trainee.Image = ImageFile.UploadFile(imageFile, "Images");
            }

            _traineeService.Add(trainee);

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trainee = _traineeService.Details(id);

            if (trainee == null)
                return NotFound();

            var departments = _departmentService.ShowAll();

            ViewBag.Departments = departments;

            return View(trainee);
        }

        [HttpPost]
        public IActionResult Edit(int id, Trainee trainee, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                trainee.Image = ImageFile.UploadFile(imageFile, "Images");
            }

            var updatedTrainee = _traineeService.Edit(id, trainee);

            if (updatedTrainee == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var trainee = _traineeService.Delete(id);

            if (trainee == null)
                return NotFound();

            return RedirectToAction("ShowAll");
        }
    }
}