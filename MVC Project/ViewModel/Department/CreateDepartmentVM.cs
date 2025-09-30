namespace MVC_Project.ViewModel.Department
{
    public class CreateDepartmentVM
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = default!;
    }
}
