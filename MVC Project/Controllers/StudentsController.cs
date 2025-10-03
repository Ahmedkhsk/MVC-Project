namespace MVC_Project.Controllers
{
    [AuthorizeStudentFilter]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentsController(IStudentRepository studentRepository,IDepartmentRepository departmentRepository) {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View("Index", _studentRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id) {
            return View("Details", _studentRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            CreateStudentVM createStudentVM = new CreateStudentVM();
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View("Add",createStudentVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(CreateStudentVM createStudentVM)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(createStudentVM);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View("Add", createStudentVM);
        }

        public IActionResult Edit(int id) {
            
            Student student = _studentRepository.GetById(id)!;
            if (student == null)
            {
                return NotFound();
            }

            EditStudentVM editStudentVM = new EditStudentVM
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Grade = student.Grade,
                DepartmentId = student.DepartmentId
            };
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View(editStudentVM);
        }

        [HttpPost]
        public IActionResult Edit(EditStudentVM student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(student);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View("Edit", student);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                _studentRepository.Delete(student);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        
    }

}
