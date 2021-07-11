using asp_net_webpack.Core;
using asp_net_webpack.Core.Infrastructure.Filters;
using asp_net_webpack.Core.Request.User;
using asp_net_webpack.Core.Service;
using asp_net_webpack.Core.Service.Log;
using asp_net_webpack.Domain.Model.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_net_webpack.Controller
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ServiceContext Services => asp_net_webpackAppContext.Current.Services;
        protected LogService LogService => Services.LogService;

        protected UserModel CurrentUser => GetCurrentUser();

        private UserModel _currentUser;
        private UserModel GetCurrentUser()
        {
            if (_currentUser == null && User != null) {
                var user_req = new UserFilterRequest { UserId = long.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) };
                _currentUser = Services.UserService.FirstOrDefault(user_req);
            }
            return _currentUser;
        }
    }
}
