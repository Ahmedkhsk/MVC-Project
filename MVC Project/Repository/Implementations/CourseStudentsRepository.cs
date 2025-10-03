namespace MVC_Project.Repository.Implementations
{
    public class CourseStudentsRepository : ICourseStudentsRepository
    {
        private readonly Context context;

        public CourseStudentsRepository(Context context)
        {
            this.context = context;
        }
        public void Add(CreateCourseStudentsVM createCourseStudentsVM)
        {
            var courseStudent = new CourseStudents
            {
                CourseId = createCourseStudentsVM.CourseId,
                StudentId = createCourseStudentsVM.StudentId,
                Degree = createCourseStudentsVM.Degree
            };
            context.CourseStudents.Add(courseStudent);
            context.SaveChanges();
        }
        public void Update(EditCourseStudentsVM editCourseStudentsVM)
        {
            var courseStudent = context.CourseStudents.FirstOrDefault(i => i.Id == editCourseStudentsVM.Id)!;
            if (courseStudent != null)
            {
                courseStudent.CourseId = editCourseStudentsVM.CourseId;
                courseStudent.StudentId = editCourseStudentsVM.StudentId;
                courseStudent.Degree = editCourseStudentsVM.Degree;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var courseStudent = context.CourseStudents.FirstOrDefault(i => i.Id == id)!;
            if (courseStudent != null)
            {
                context.CourseStudents.Remove(courseStudent);
                context.SaveChanges();
            }
        }
        public IEnumerable<CourseStudents> GetAll()
        {
            return context.CourseStudents.Include(s => s.Student)
                                         .Include(c => c.Course)
                                         .ToList();
        }
        public CourseStudents GetById(int id)
        {
            return context.CourseStudents.Include(s => s.Student)
                                         .Include(c => c.Course)
                                         .FirstOrDefault(i => i.Id == id)!;
        }

    }
}
