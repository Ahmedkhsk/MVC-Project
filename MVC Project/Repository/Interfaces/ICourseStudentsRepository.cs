namespace MVC_Project.Repository.Interfaces
{
    public interface ICourseStudentsRepository
    {
        public IEnumerable<CourseStudents> GetAll();
        public CourseStudents GetById(int id);
        public void Add(CreateCourseStudentsVM createCourseStudentsVM);
        public void Update(EditCourseStudentsVM editCourseStudentsVM);
        public void Delete(int id);
    }
}
