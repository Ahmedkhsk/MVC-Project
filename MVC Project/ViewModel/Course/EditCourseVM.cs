namespace MVC_Project.ViewModel.Course
{
    public class EditCourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Degree { get; set; }
        public decimal MinimumDegree { get; set; }
        public int Hours { get; set; }
        public int DepartmentId { get; set; }
    }
}
