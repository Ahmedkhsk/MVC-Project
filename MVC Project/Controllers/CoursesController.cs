

namespace MVC_Project.Controllers
{
    [Authorize(Roles = "Admin,HR,Instructor,Student")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CoursesController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            var selectedCourseId = HttpContext.Session.GetInt32("SelectedCourseId");
            ViewBag.SelectedCourseId = selectedCourseId;
            return View("Index", courses);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Details", course);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            CreateCourseVM createCourseVM = new CreateCourseVM();
            return View("Add", createCourseVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(CreateCourseVM createCourseVM)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(createCourseVM);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View("Add", createCourseVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course? course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            EditCourseVM editCourseVM = new EditCourseVM
            {
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinimumDegree = course.MinimumDegree,
                Hours = course.Hours,
                DepartmentId = course.DepartmentId
            };
            

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", editCourseVM.DepartmentId);
            return View("Edit", editCourseVM);
        }

        [HttpPost]
        public IActionResult Edit(EditCourseVM editCourseVM)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(editCourseVM);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", editCourseVM.DepartmentId);
            return View("Edit", editCourseVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course != null)
            {
                _courseRepository.Delete(course);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Join(int courseId)
        {
            HttpContext.Session.SetInt32("SelectedCourseId", courseId);
            return RedirectToAction("Index");
        }


    }
}