namespace MVC_Project.Controllers
{
    public class CourseStudentsController : Controller
    {
        private readonly ICourseStudentsRepository courseStudentsRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;

        public CourseStudentsController(ICourseStudentsRepository courseStudentsRepository,
            IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.courseStudentsRepository = courseStudentsRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            return View("Index", courseStudentsRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            var courseStudent = courseStudentsRepository.GetById(id);
            if (courseStudent == null)
                return NotFound();

            return View("Details", courseStudent);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Courses = new SelectList(courseRepository.GetAll(), "Id", "Name");
            ViewBag.Students = new SelectList(studentRepository.GetAll(), "Id", "Name");
            CreateCourseStudentsVM createCourseStudentsVM = new CreateCourseStudentsVM();
            return View("Add", createCourseStudentsVM);
        }

        [HttpPost]
        public IActionResult Add(CreateCourseStudentsVM createCourseStudentsVM)
        {
            if (ModelState.IsValid)
            {
                courseStudentsRepository.Add(createCourseStudentsVM);
                return RedirectToAction("Index");
            }

            ViewBag.Courses = new SelectList(courseRepository.GetAll(), "Id", "Name", createCourseStudentsVM.CourseId);
            ViewBag.Students = new SelectList(studentRepository.GetAll(), "Id", "Name", createCourseStudentsVM.StudentId);
            return View("Add", createCourseStudentsVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var courseStudent = courseStudentsRepository.GetById(id);
            if (courseStudent == null)
                return NotFound();

            EditCourseStudentsVM editCourseStudentsVM = new EditCourseStudentsVM
            {
                Id = courseStudent.Id,
                CourseId = courseStudent.CourseId,
                StudentId = courseStudent.StudentId,
                Degree = courseStudent.Degree
            };

            ViewBag.Courses = new SelectList(courseRepository.GetAll(), "Id", "Name", editCourseStudentsVM.CourseId);
            ViewBag.Students = new SelectList(studentRepository.GetAll(), "Id", "Name", editCourseStudentsVM.StudentId);

            return View("Edit", editCourseStudentsVM);
        }

        [HttpPost]
        public IActionResult Edit(EditCourseStudentsVM editCourseStudentsVM)
        {
            if (ModelState.IsValid)
            {
                courseStudentsRepository.Update(editCourseStudentsVM);
                return RedirectToAction("Index");
            }

            ViewBag.Courses = new SelectList(courseRepository.GetAll(), "Id", "Name", editCourseStudentsVM.CourseId);
            ViewBag.Students = new SelectList(studentRepository.GetAll(), "Id", "Name", editCourseStudentsVM.StudentId);

            return View("Edit", editCourseStudentsVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var courseStudent = courseStudentsRepository.GetById(id);
            if (courseStudent == null)
                return NotFound();

            courseStudentsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
