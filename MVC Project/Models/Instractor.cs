namespace MVC_Project.Models
{
    public class Instractor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-50 characters")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = default!;

        [Range(3000, 20000, ErrorMessage = "Salary must be between 3000 and 20000")]
        public decimal Salary { get; set; }

        public string Image { get; set; } = default!;

        [Required]
        public int DepartmentId { get; set; }
        

        [Required]
        public int CourseId { get; set; }

        public Department Department { get; set; } = default!;
        public Course Course { get; set; } = default!;
    }
}
