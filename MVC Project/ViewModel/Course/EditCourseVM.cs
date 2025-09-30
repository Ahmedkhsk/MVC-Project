namespace MVC_Project.ViewModel.Course
{
    public class EditCourseVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(100, ErrorMessage = "Course Name cannot exceed 100 characters")]
        public string Name { get; set; } = default!;

        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
        public decimal Degree { get; set; }

        [Range(0, 100, ErrorMessage = "Minimum Degree must be between 0 and 100")]
        public decimal MinimumDegree { get; set; }

        [Range(1, 10, ErrorMessage = "Hours must be between 1 and 10")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

    }
}
