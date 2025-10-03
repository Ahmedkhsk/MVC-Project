namespace MVC_Project.Filters
{
    public class AuthorizeStudentFilter  : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated || user?.Identity == null)
                context.Result = new RedirectToActionResult("Login", "Account", null);
            
            base.OnActionExecuting(context);
        }
    }
}
