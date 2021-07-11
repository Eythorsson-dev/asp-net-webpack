using asp_net_webpack.Domain.Model.Order;
using asp_net_webpack.Domain.Model.User;
using asp_net_webpack.Domain.Model.User.Preference;
using asp_net_webpack.Web.Dto.Order;
using asp_net_webpack.Web.Dto.User;
using asp_net_webpack.Web.Dto.User.Preference;
using AutoMapper;

namespace asp_net_webpack.Web.Config.Mapper.Profiles
{
    public class DefaultMapperProfile : Profile
    {
        public DefaultMapperProfile()
        {
            // ARTICLE
            //CreateMap<ArticleModel, LookupItemDto>()
            //   .ForMember(x => x.Id, y => y.MapFrom(m => m.ArticleId))

            // USER
            CreateMap<UserPreferenceModel, UserPreferenceDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();

            // ORDER
            CreateMap<OrderModel, OrderDto>().ReverseMap();
        }
    }
}
