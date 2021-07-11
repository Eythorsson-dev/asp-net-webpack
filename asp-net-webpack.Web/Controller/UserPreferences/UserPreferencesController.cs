using asp_net_webpack.Controller;
using asp_net_webpack.Core.Request.User.Preference;
using asp_net_webpack.Core.Service.User.Preference;
using asp_net_webpack.Domain.Enum;
using asp_net_webpack.Domain.Model.User;
using asp_net_webpack.Web.Config.Mapper;
using asp_net_webpack.Web.Dto.Login;
using asp_net_webpack.Web.Dto.Register;
using asp_net_webpack.Web.Dto.User.Preference;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_webpack.Web.Controller.Account.Preferences
{
    [ApiController]
    [Route("api/user/{userId}/preferences")]
    public class UserPreferencesController : BaseController
    {
        private UserPreferenceService UserPreferenceService => Services.UserPreferenceService;

        [HttpGet("{preferenceId}")]
        public IActionResult GetById([FromRoute] UserPreferenceEnum preferenceId)
        {
            var model = UserPreferenceService.GetUserPreference(CurrentUser.UserId, preferenceId);
            var dto = Mapper.Map<UserPreferenceDto>(model);
            return Ok(dto);
        }

        [HttpPost("{preferenceId}")]
        public IActionResult Update([FromRoute] UserPreferenceEnum preferenceId, [FromBody] UserPreferenceDto dto)
        {
            if (preferenceId != dto.PreferenceId) return BadRequest();

            var model = UserPreferenceService.GetUserPreference(CurrentUser.UserId, preferenceId);
            model.UserPreferenceStr = dto.UserPreferenceStr;
            UserPreferenceService.Update(model);

            return Ok();
        }
    }
}
