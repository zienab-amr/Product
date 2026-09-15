namespace Product.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public List<Trainee> Trainees { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }

    }
}
