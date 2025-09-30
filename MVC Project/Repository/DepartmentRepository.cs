namespace MVC_Project.Repository
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
            return _context.Departments.AsNoTracking().ToList();
        }
    }
}
