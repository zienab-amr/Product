namespace Product.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int CourseHours { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CourseResult> CourseResults { get; set; }


    }
}
