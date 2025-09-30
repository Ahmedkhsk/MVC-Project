namespace MVC_Project.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            return View("Index", _departmentRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Details", department);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CreateDepartmentVM createDepartmentVM = new CreateDepartmentVM();
            return View("Add", createDepartmentVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(CreateDepartmentVM createDepartmentVM)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(createDepartmentVM);
                return RedirectToAction("Index");
            }
            return View("Add", createDepartmentVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            EditDepartmentVM editDepartmentVM = new EditDepartmentVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return View("Edit", editDepartmentVM);
        }

        [HttpPost]
        public IActionResult Edit(EditDepartmentVM editDepartmentVM)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(editDepartmentVM);
                return RedirectToAction("Index");
            }
            return View("Edit", editDepartmentVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                _departmentRepository.Delete(department);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}