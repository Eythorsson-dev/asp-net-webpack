using asp_net_webpack.Domain.Enum;

namespace asp_net_webpack.Core.Request.User.Preference
{
    public class UserPreferenceFilterRequest
    {
        public long UserId { get; set; }
        public UserPreferenceEnum PreferenceId { get; set; }
    }
}
