public class Department
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = default!;

    [ForeignKey("Manager")]
    public int? ManagerId { get; set; }
    public Instractor? Manager { get; set; }
}
