using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Data
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options){}
        public DbSet<Productt> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CourseResults)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseResults)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // =========================
            // Departments
            // =========================
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    Name = "Computer Science"
                },
                new Department
                {
                    DepartmentId = 2,
                    Name = "Information Systems"
                },
                new Department
                {
                    DepartmentId = 3,
                    Name = "Artificial Intelligence"
                }
            );


            // =========================
            // Trainees
            // =========================
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee
                {
                    TraineeId = 1,
                    Name = "Ahmed Hassan",
                    Image = "https://i.pravatar.cc/150?img=12",
                    DepartmentId = 1
                },
                new Trainee
                {
                    TraineeId = 2,
                    Name = "Zeinab Amr",
                    Image = "https://i.pravatar.cc/150?img=47",
                    DepartmentId = 1
                },
                new Trainee
                {
                    TraineeId = 3,
                    Name = "Omar Khaled",
                    Image = "https://i.pravatar.cc/150?img=33",
                    DepartmentId = 2
                },
                new Trainee
                {
                    TraineeId = 4,
                    Name = "Mariam Ali",
                    Image = "https://i.pravatar.cc/150?img=44",
                    DepartmentId = 2
                },
                new Trainee
                {
                    TraineeId = 5,
                    Name = "Youssef Mohamed",
                    Image = "https://i.pravatar.cc/150?img=13",
                    DepartmentId = 3
                },
                new Trainee
                {
                    TraineeId = 6,
                    Name = "Salma Ahmed",
                    Image = "https://i.pravatar.cc/150?img=32",
                    DepartmentId = 3
                }
            );


            // =========================
            // Instructors
            // =========================
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    InstructorId = 1,
                    Name = "Dr. Ahmed Hassan",
                    Image = "https://i.pravatar.cc/150?img=11",
                    Address = "Cairo, Egypt",
                    Email = "ahmed.hassan@example.com",
                    PhoneNumber = "01012345678",
                    Salary = 25000m,
                    DepartmentId = 1
                },
                new Instructor
                {
                    InstructorId = 2,
                    Name = "Dr. Sara Mohamed",
                    Image = "https://i.pravatar.cc/150?img=45",
                    Address = "Giza, Egypt",
                    Email = "sara.mohamed@example.com",
                    PhoneNumber = "01123456789",
                    Salary = 22000m,
                    DepartmentId = 1
                },
                new Instructor
                {
                    InstructorId = 3,
                    Name = "Dr. Omar Ali",
                    Image = "https://i.pravatar.cc/150?img=12",
                    Address = "Alexandria, Egypt",
                    Email = "omar.ali@example.com",
                    PhoneNumber = "01234567890",
                    Salary = 24000m,
                    DepartmentId = 2
                },
                new Instructor
                {
                    InstructorId = 4,
                    Name = "Dr. Menna Adel",
                    Image = "https://i.pravatar.cc/150?img=49",
                    Address = "Cairo, Egypt",
                    Email = "menna.adel@example.com",
                    PhoneNumber = "01098765432",
                    Salary = 27000m,
                    DepartmentId = 3
                }
            );


            // =========================
            // Courses
            // =========================
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "C# Programming",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 60,
                    DepartmentId = 1
                },
                new Course
                {
                    Id = 2,
                    Name = "Database Systems",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 45,
                    DepartmentId = 1
                },
                new Course
                {
                    Id = 3,
                    Name = "Web Development",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 60,
                    DepartmentId = 1
                },
                new Course
                {
                    Id = 4,
                    Name = "System Analysis",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 45,
                    DepartmentId = 2
                },
                new Course
                {
                    Id = 5,
                    Name = "Business Intelligence",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 50,
                    DepartmentId = 2
                },
                new Course
                {
                    Id = 6,
                    Name = "Machine Learning",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 60,
                    DepartmentId = 3
                },
                new Course
                {
                    Id = 7,
                    Name = "Deep Learning",
                    Degree = 100,
                    MinDegree = 50,
                    CourseHours = 60,
                    DepartmentId = 3
                }
            );


            // =========================
            // Course Results
            // =========================
            modelBuilder.Entity<CourseResult>().HasData(
                // Ahmed Hassan
                new CourseResult
                {
                    Id = 1,
                    Degree = 85,
                    CourseId = 1,
                    TraineeId = 1
                },
                new CourseResult
                {
                    Id = 2,
                    Degree = 78,
                    CourseId = 2,
                    TraineeId = 1
                },
                new CourseResult
                {
                    Id = 3,
                    Degree = 92,
                    CourseId = 3,
                    TraineeId = 1
                },

                // Zeinab Amr
                new CourseResult
                {
                    Id = 4,
                    Degree = 95,
                    CourseId = 1,
                    TraineeId = 2
                },
                new CourseResult
                {
                    Id = 5,
                    Degree = 88,
                    CourseId = 2,
                    TraineeId = 2
                },
                new CourseResult
                {
                    Id = 6,
                    Degree = 91,
                    CourseId = 3,
                    TraineeId = 2
                },

                // Omar Khaled
                new CourseResult
                {
                    Id = 7,
                    Degree = 82,
                    CourseId = 4,
                    TraineeId = 3
                },
                new CourseResult
                {
                    Id = 8,
                    Degree = 76,
                    CourseId = 5,
                    TraineeId = 3
                },

                // Mariam Ali
                new CourseResult
                {
                    Id = 9,
                    Degree = 90,
                    CourseId = 4,
                    TraineeId = 4
                },
                new CourseResult
                {
                    Id = 10,
                    Degree = 87,
                    CourseId = 5,
                    TraineeId = 4
                },

                // Youssef Mohamed
                new CourseResult
                {
                    Id = 11,
                    Degree = 94,
                    CourseId = 6,
                    TraineeId = 5
                },
                new CourseResult
                {
                    Id = 12,
                    Degree = 89,
                    CourseId = 7,
                    TraineeId = 5
                },

                // Salma Ahmed
                new CourseResult
                {
                    Id = 13,
                    Degree = 86,
                    CourseId = 6,
                    TraineeId = 6
                },
                new CourseResult
                {
                    Id = 14,
                    Degree = 93,
                    CourseId = 7,
                    TraineeId = 6
                }
            );
        }
    }
}
