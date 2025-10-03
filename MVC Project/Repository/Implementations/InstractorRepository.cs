namespace MVC_Project.Repository.Implementations
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly Context _context;

        public InstructorRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Instractor> GetAll()
        {
            return _context.Instractors
                           .Include(i => i.Department)
                           .Include(i => i.Course)
                           .AsNoTracking()
                           .ToList();
        }

        public Instractor? GetById(int id)
        {
            return _context.Instractors
                           .Include(i => i.Department)
                           .Include(i => i.Course)
                           .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Instractor> GetByDepartmentId(int deptId)
        {
            return _context.Instractors
                           .Where(i => i.DepartmentId == deptId)
                           .AsNoTracking()
                           .ToList();
        }

        public void Add(CreateInstructorVM instructor)
        {
            Instractor newInstructor = new Instractor
            {
                Name = instructor.Name,
                Address = instructor.Address,
                Salary = instructor.Salary,
                Image = instructor.Image,
                DepartmentId = instructor.DepartmentId,
                CourseId = instructor.CourseId
            };

            _context.Instractors.Add(newInstructor);
            _context.SaveChanges();
        }

        public void Update(EditInstructorVM instructor)
        {
            var existingInstructor = _context.Instractors.Find(instructor.Id);
            if (existingInstructor == null)
            {
                throw new Exception("Instructor not found");
            }

            existingInstructor.Name = instructor.Name;
            existingInstructor.Address = instructor.Address;
            existingInstructor.Salary = instructor.Salary;
            existingInstructor.Image = instructor.Image;
            existingInstructor.DepartmentId = instructor.DepartmentId;
            existingInstructor.CourseId = instructor.CourseId;

            _context.Instractors.Update(existingInstructor);
            _context.SaveChanges();
        }

        public void Delete(Instractor instructor)
        {
            _context.Instractors.Remove(instructor);
            _context.SaveChanges();
        }
    }
}