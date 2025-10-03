namespace MVC_Project.ViewModel.Course
{
    public class EditCourseStudentsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Student is required")]
        public int StudentId { get; set; }

        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
        public decimal Degree { get; set; }

    }
}
