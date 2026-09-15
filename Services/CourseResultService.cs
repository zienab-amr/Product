using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Services
{
    public class CourseResultService
    {
        private readonly ProductDbContext _db;

        public CourseResultService(ProductDbContext db)
        {
            _db = db;
        }

        public List<CourseResult> ShowAll() =>
            _db.CourseResults
               .Include(cr => cr.Course)
               .Include(cr => cr.Trainee)
               .ToList();

        public CourseResult? Details(int Id) =>
            _db.CourseResults
               .Include(cr => cr.Course)
               .Include(cr => cr.Trainee)
               .FirstOrDefault(cr => cr.Id == Id);

        public CourseResult Add(CourseResult c)
        {
            _db.CourseResults.Add(c);
            _db.SaveChanges();
            return c;
        }

        public CourseResult? Edit(int Id,CourseResult c)
        {
            var courseResult = _db.CourseResults.FirstOrDefault(cr => Id == cr.Id);
            if (courseResult != null)
            {
                courseResult.Degree = c.Degree;
                courseResult.CourseId = c.CourseId;
                courseResult.TraineeId = c.TraineeId;

                _db.SaveChanges();
                return courseResult;
            }
            return null;
        }
        public CourseResult? Delete(int Id)
        {
            var courseResult = _db.CourseResults.FirstOrDefault(cr => Id == cr.Id);

            if (courseResult != null)
            {
                _db.CourseResults.Remove(courseResult);
                _db.SaveChanges();
                return courseResult;
            }

            return null;
        }
    }
}