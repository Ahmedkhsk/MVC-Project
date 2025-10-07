namespace MVC_Project.Repository.Interfaces
{
    public interface IAccountRepository
    {
        public Task Add(RegisterVM registerVM);
        public Task<List<string>> GetUserRoles(int userId);
        public Task<List<string>> getRoles();
        public Task LoginUser(LoginVM loginVM);

    }
}
