namespace MVC_Project.ViewModel.Department
{
    public class EditDepartmentVM
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;
    }
}
