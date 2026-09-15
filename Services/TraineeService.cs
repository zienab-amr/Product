using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Services
{
    public class TraineeService
    {
        private readonly ProductDbContext _db;
        public TraineeService(ProductDbContext db)
        {
            _db = db;
        }
        public List<Trainee> ShowAll() => _db.Trainees.Include(t => t.Department).ToList();

        public Trainee? Details(int Id) => _db.Trainees.Include(t => t.Department).FirstOrDefault(t => t.TraineeId == Id);

        public Trainee Add(Trainee trainee)
        {
            _db.Trainees.Add(trainee);
            _db.SaveChanges();
            return trainee;
        }

        public Trainee? Edit(int Id, Trainee t)
        {
            var trainee = _db.Trainees.FirstOrDefault(ce => ce.TraineeId == Id);

            if (trainee != null)
            {
                trainee.Name = t.Name;
                trainee.Image = t.Image;

                _db.SaveChanges();
                return trainee;
            }

            return null;
        }

        public Trainee? Delete(int Id)
        {
            var trainee = _db.Trainees.FirstOrDefault(ce => ce.TraineeId == Id);

            if (trainee != null)
            {
                _db.Trainees.Remove(trainee);
                _db.SaveChanges();
                return trainee;
            }
            return null;
        }
    }
}
