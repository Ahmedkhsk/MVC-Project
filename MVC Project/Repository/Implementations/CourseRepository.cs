namespace MVC_Project.Repository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses
                           .Include(d => d.Department)
                           .AsNoTracking()
                           .ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Include(d => d.Department).FirstOrDefault(c => c.Id == id);
        }

        public void Add(CreateCourseVM course)
        {
            Course newCourse = new Course
            {
                Name = course.Name,
                Degree = course.Degree,
                MinimumDegree = course.MinimumDegree,
                Hours = course.Hours,
                DepartmentId = course.DepartmentId
            };

            _context.Courses.Add(newCourse);
            _context.SaveChanges();
        }

        public void Update(EditCourseVM course)
        {
            var existingCourse = _context.Courses.Find(course.Id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
            }

            existingCourse.Name = course.Name;
            existingCourse.Degree = course.Degree;
            existingCourse.MinimumDegree = course.MinimumDegree;
            existingCourse.Hours = course.Hours;
            existingCourse.DepartmentId = course.DepartmentId;

            _context.Courses.Update(existingCourse);
            _context.SaveChanges();
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}