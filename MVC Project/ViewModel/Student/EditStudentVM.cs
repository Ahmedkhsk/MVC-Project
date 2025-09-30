namespace MVC_Project.ViewModel.Student
{
    public class EditStudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-50 characters")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = default!;

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public decimal Grade { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

    }
}
