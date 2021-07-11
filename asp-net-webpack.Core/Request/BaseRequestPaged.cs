
namespace asp_net_webpack.Core.Request
{
    public abstract class BaseRequestPaged<T> : BaseRequest<T>, IBaseRequestPaged
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
    }

    public interface IBaseRequestPaged
    {
        int ItemsPerPage { get; set; }
        int CurrentPage { get; set; }
    }
}
