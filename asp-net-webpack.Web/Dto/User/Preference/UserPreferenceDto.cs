using asp_net_webpack.Domain.Enum;

namespace asp_net_webpack.Web.Dto.User.Preference
{
    public class UserPreferenceDto
    {
        public long UserId { get; set; }
        public UserPreferenceEnum PreferenceId { get; set; }
        public string UserPreferenceStr { get; set; }
    }
}
