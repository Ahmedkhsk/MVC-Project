namespace MVC_Project.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;

        public InstructorsController(IInstructorRepository instructorRepository, IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            return View("Index", _instructorRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View("Details", instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name");
            CreateInstructorVM createInstructorVM = new CreateInstructorVM();
            return View("Add", createInstructorVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(CreateInstructorVM createInstructorVM)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(createInstructorVM);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name");
            return View("Add", createInstructorVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instractor instructor = _instructorRepository.GetById(id)!;
            if (instructor == null)
            {
                return NotFound();
            }

            EditInstructorVM editInstructorVM = new EditInstructorVM
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Address = instructor.Address,
                Salary = instructor.Salary,
                Image = instructor.Image,
                DepartmentId = instructor.DepartmentId,
                CourseId = instructor.CourseId
            };

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", instructor.DepartmentId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", instructor.CourseId);
            return View("Edit", editInstructorVM);
        }

        [HttpPost]
        public IActionResult Edit(EditInstructorVM editInstructorVM)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Update(editInstructorVM);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", editInstructorVM.DepartmentId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", editInstructorVM.CourseId);
            return View("Edit", editInstructorVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor != null)
            {
                _instructorRepository.Delete(instructor);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}