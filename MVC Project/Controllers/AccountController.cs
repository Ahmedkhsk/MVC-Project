namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountRepository accountRepository, SignInManager<ApplicationUser> signInManager)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {   
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.AvailableRoles = await _accountRepository.getRoles();
            return View("Register", new RegisterVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountRepository.Add(registerVM);
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.AvailableRoles = await _accountRepository.getRoles();
            return View(registerVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("Login", new LoginVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountRepository.LoginUser(loginVM);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
     
            await _signInManager.SignOutAsync();

 
            Response.Cookies.Delete(".AspNetCore.Identity.Application");


            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View("~/Views/Shared/AccessDenied.cshtml");
        }
    }
}
