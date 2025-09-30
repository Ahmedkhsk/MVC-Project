namespace MVC_Project.ViewModel.Instructor
{
    public class EditInstructorVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public decimal Salary { get; set; }
        public string Image { get; set; } = default!;
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
    }
}
