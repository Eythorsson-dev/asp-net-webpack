using asp_net_webpack.Core.Repository;
using asp_net_webpack.Core.Service.Log;

namespace asp_net_webpack.Core.Service
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWorkProvider UowProvider;
        protected readonly RepositoryFactory RepoFactory;

        protected LogService LogService => Core.asp_net_webpackAppContext.Current.Services.LogService;

        public BaseService(IUnitOfWorkProvider uowProvider, RepositoryFactory repoFactory)
        {
            UowProvider = uowProvider;
            RepoFactory = repoFactory;
        }
    }
}
