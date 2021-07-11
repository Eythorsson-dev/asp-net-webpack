using asp_net_webpack.Core.Request.User;
using asp_net_webpack.Core.Service;
using asp_net_webpack.Domain.Model.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_net_webpack.Web.Pages
{
    [Authorize]
    public class BasePage : PageModel
    {
        protected UserModel CurrentUser { get; private set; }

        protected ServiceContext Services => Core.asp_net_webpackAppContext.Current.Services;

        public virtual void OnGet()
        {
            string url = Request.Path.Value;

            CurrentUser = Services.UserService.FirstOrDefault(new UserFilterRequest { Email = User.Identity.Name });


            if (CurrentUser == null) {
                Response.Redirect("account/login");
                return;
            }
            else if (!CurrentUser.IsEmailConfirmed) {
                if (url != "account/verify-account") {
                    Response.Redirect("account/verify");
                    return;
                }
            }

        }
    }
}
