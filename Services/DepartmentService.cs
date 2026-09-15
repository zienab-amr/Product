using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Services
{
    public class DepartmentService
    {
        private readonly ProductDbContext _db;
        public DepartmentService(ProductDbContext db)
        {
            _db = db;
        }
        public List<Department> ShowAll() => _db.Departments.Include(t => t.Trainees).ToList();

        public Department? Details(int Id) => _db.Departments.Include(t => t.Trainees).FirstOrDefault(d => d.DepartmentId == Id);

        public Department Add(Department d)
        {
            _db.Departments.Add(d);
            _db.SaveChanges();
            return d;
        }

        public Department? Edit(int Id, Department d)
        {
            var department = _db.Departments.FirstOrDefault(d => d.DepartmentId == Id);

            if (department != null)
            {
                department.Name = d.Name;

                _db.SaveChanges();
                return department;
            }

            return null;
        }

        public Department? Delete(int Id)
        {
            var department = _db.Departments.FirstOrDefault(d => d.DepartmentId == Id);

            if (department != null)
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
                return department;
            }
            return null;
        }
    }
}
