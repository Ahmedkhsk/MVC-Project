namespace MVC_Project.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;
        public StudentRepository(Context context)
        {
            _context = context;
        }
        public void Add(CreateStudentVM student)
        {
            Student newStudent = new Student
            {
                Name = student.Name,
                Address = student.Address,
                Grade = student.Grade,
                DepartmentId = student.DepartmentId
            };

            _context.Students.Add(newStudent);
            _context.SaveChanges();
        }
        public void Update(EditStudentVM student)
        {
            var existingStudent = _context.Students.Find(student.Id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }
            existingStudent.Name = student.Name;
            existingStudent.Address = student.Address;
            existingStudent.Grade = student.Grade;
            existingStudent.DepartmentId = student.DepartmentId;

            _context.Students.Update(existingStudent);
            _context.SaveChanges();
        }
        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public Student? GetById(int id)
        {
            return _context.Students.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(d => d.Department)
                                    .AsNoTracking()
                                    .ToList();
        }
    }
}
