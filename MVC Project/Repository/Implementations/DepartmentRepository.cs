namespace MVC_Project.Repository.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly Context _context;

        public DepartmentRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments
                           .AsNoTracking()
                           .ToList();
        }

        public Department? GetById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Add(CreateDepartmentVM department)
        {
            Department newDepartment = new Department
            {
                Name = department.Name
            };

            _context.Departments.Add(newDepartment);
            _context.SaveChanges();
        }

        public void Update(EditDepartmentVM department)
        {
            var existingDepartment = _context.Departments.Find(department.Id);
            if (existingDepartment == null)
            {
                throw new Exception("Department not found");
            }

            existingDepartment.Name = department.Name;

            _context.Departments.Update(existingDepartment);
            _context.SaveChanges();
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}