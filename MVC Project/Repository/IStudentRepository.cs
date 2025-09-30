namespace MVC_Project.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public void Add(CreateStudentVM student);
        public void Update(EditStudentVM student);
        public void Delete(Student student);
        public Student? GetById(int id);
    }
}
