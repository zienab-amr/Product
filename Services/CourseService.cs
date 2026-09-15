using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Services
{
    public class CourseService
    {
        private readonly ProductDbContext _db;

        public CourseService(ProductDbContext db)
        {
            _db = db;
        }

        public List<Course> ShowAll() =>
            _db.Courses
               .Include(c => c.Department)
               .ToList();

        public Course? Details(int Id) =>
            _db.Courses
               .Include(c => c.Department)
               .FirstOrDefault(c => c.Id == Id);

        public Course Add(Course c)
        {
            _db.Courses.Add(c);
            _db.SaveChanges();
            return c;
        }

        public Course? Edit(int Id,  Course c)
        {
            var course = _db.Courses.FirstOrDefault(ce =>  ce.Id == Id);

            if (course != null)
            {
                course.CourseHours = c.CourseHours;
                course.MinDegree = c.MinDegree;
                course.Degree = c.Degree;
                
                _db.SaveChanges(); 
                return course;
            }

            return null;
        }

        public Course? Delete(int Id)
        {
            var course = _db.Courses.FirstOrDefault(ce => ce.Id == Id);

            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();
                return course;
            }
            return null;
        }
    }
}