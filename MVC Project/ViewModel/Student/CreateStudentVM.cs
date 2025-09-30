namespace MVC_Project.ViewModel.Student
{
    public class CreateStudentVM
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public decimal Grade { get; set; }
        public int DepartmentId { get; set; }


    }
}
