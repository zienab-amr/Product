using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    public class Trainee
    {
        public int TraineeId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CourseResult> CourseResults { get; set; }

    }
}
