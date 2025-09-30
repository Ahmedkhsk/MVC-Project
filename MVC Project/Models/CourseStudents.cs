namespace MVC_Project.Models
{
    public class CourseStudents
    {
        public int Id { get; set; }

        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
        public decimal Degree { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
    }
}
