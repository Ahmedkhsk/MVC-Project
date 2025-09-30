namespace MVC_Project.Repository
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public Department? GetById(int id);
        public void Add(CreateDepartmentVM department);
        public void Update(EditDepartmentVM department);
        public void Delete(Department department);
    }
}
