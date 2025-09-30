namespace MVC_Project.ViewModel.Student
{
    public class EditStudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public decimal Grade { get; set; }
        public int DepartmentId { get; set; }
    }
}
