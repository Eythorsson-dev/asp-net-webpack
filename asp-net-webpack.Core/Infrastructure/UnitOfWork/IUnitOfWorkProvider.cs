
namespace asp_net_webpack.Core
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork(bool useTransaction = false);
    }
}
