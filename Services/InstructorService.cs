using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Controllers
{
    public class InstructorService
    {
        private readonly ProductDbContext _db;

        public InstructorService(ProductDbContext db)
        {
            _db = db;
        }

        public List<Instructor> ShowAll()
        {
            return _db.Instructors
                .Include(i => i.Department)
                .ToList();
        }

        public Instructor? Details(int id)
        {
            return _db.Instructors
                .Include(i => i.Department)
                .FirstOrDefault(i => i.InstructorId == id);
        }

        public Instructor Add(Instructor instructor)
        {
            _db.Instructors.Add(instructor);
            _db.SaveChanges();
            return instructor;
        }

        public Instructor? Edit(int Id, Instructor i)
        {
            var instructor = _db.Instructors.FirstOrDefault(i => i.InstructorId == Id);

            if (instructor != null)
            {
                instructor.Salary = i.Salary;
                instructor.PhoneNumber = i.PhoneNumber;
                instructor.Address = i.Address;
                instructor.Name = i.Name;
                instructor.Email = i.Email;
                instructor.Image = i.Image;

                _db.SaveChanges();
                return instructor;
            }

            return null;
        }

        public Instructor? Delete(int Id)
        {
            var instructor = _db.Instructors.FirstOrDefault(i => i.InstructorId == Id);

            if (instructor != null)
            {
                _db.Instructors.Remove(instructor);
                _db.SaveChanges();
                return instructor;
            }
            return null;
        }

    }
}