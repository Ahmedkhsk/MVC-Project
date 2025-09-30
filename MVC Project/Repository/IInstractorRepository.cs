namespace MVC_Project.Repository
{
    public interface IInstructorRepository
    {
        public IEnumerable<Instractor> GetAll();
        public Instractor? GetById(int id);
        public void Add(CreateInstructorVM instructor);
        public void Update(EditInstructorVM instructor);
        public void Delete(Instractor instructor);
        public IEnumerable<Instractor> GetByDepartmentId(int deptId);
    }
}