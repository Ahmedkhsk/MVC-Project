
using Microsoft.AspNetCore.Identity;

namespace MVC_Project.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }
        public async Task Add(RegisterVM registerVM)
        {
            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Name = registerVM.FullName,
                    Email = registerVM.Email,
                    UserName = registerVM.Email,
                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                else
                {
                    throw new Exception("Failed to create user");
                }
            }
            else
            {
                throw new Exception("User already exists");
            }
        }

        public async Task<List<string>> getRoles()
        {
            return await _roleManager.Roles
                        .Where(r => r.Name != "HR" && r.Name != "Admin")
                        .Select(r => r.Name)
                        .ToListAsync();
        }

        public Task<List<string>> GetUserRoles(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task LoginUser(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, isPersistent: false, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    throw new Exception("Invalid login attempt.");
                }
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
