namespace MVC_Project.Models
{
    public class Context : DbContext
    {
        public DbSet<Course> Courses { set; get;}
        public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Instractor> Instractors { set; get; }
        public DbSet<CourseStudents> CourseStudents { set; get; }

        public Context(DbContextOptions<Context> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(c => c.Degree)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Course>()
                .Property(c => c.MinimumDegree)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CourseStudents>()
                .Property(cs => cs.Degree)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Instractor>()
                .Property(i => i.Salary)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Student>()
                .Property(s => s.Grade)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", ManagerId = null },
                new Department { Id = 2, Name = "Mathematics", ManagerId = null }
            );

            modelBuilder.Entity<Instractor>().HasData(
                new Instractor { Id = 1, Name = "Dr. Ahmed", Address = "Cairo", Salary = 15000, Image = "ahmed.jpg", DepartmentId = 1, CourseId = 1 },
                new Instractor { Id = 2, Name = "Dr. Mona", Address = "Alex", Salary = 12000, Image = "mona.jpg", DepartmentId = 2, CourseId = 2 }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Algorithms", Degree = 100, MinimumDegree = 50, Hours = 3, DepartmentId = 1 },
                new Course { Id = 2, Name = "Linear Algebra", Degree = 100, MinimumDegree = 50, Hours = 3, DepartmentId = 2 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ali", Address = "Giza", Grade = 85, DepartmentId = 1 },
                new Student { Id = 2, Name = "Sara", Address = "Cairo", Grade = 90, DepartmentId = 2 }
            );

            modelBuilder.Entity<CourseStudents>().HasData(
                new CourseStudents { Id = 1, Degree = 80, CourseId = 1, StudentId = 1 },
                new CourseStudents { Id = 2, Degree = 95, CourseId = 2, StudentId = 2 }
            );
        }


    }
}
