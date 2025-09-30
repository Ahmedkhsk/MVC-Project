namespace MVC_Project.Repository
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAll();
        public void Add(CreateCourseVM course);
        public void Update(EditCourseVM course);
        public void Delete(Course course);
        public Course? GetById(int id);
    }
}