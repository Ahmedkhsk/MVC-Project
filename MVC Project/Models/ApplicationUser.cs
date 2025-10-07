namespace MVC_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = default!;
    }
}
