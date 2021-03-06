using asp_net_webpack.Core.Repository;
using asp_net_webpack.Core.Service.Integration;
using asp_net_webpack.Core.Service.Log;
using asp_net_webpack.Core.Service.Mail;
using asp_net_webpack.Core.Service.Order;
using asp_net_webpack.Core.Service.Role;
using asp_net_webpack.Core.Service.Role.Claim;
using asp_net_webpack.Core.Service.User;
using asp_net_webpack.Core.Service.User.Claim;
using asp_net_webpack.Core.Service.User.Preference;
using asp_net_webpack.Core.Service.User.UserRole;

namespace asp_net_webpack.Core.Service
{
    public class ServiceContext
    {
        public MailService MailService { get; private set; }
        public LogService LogService { get; private set; }

        // INTEGRATIONS
        public Integration_ExampleAuthService Integration_ExampleAuthService { get; private set; }
        public IntegrationService IntegrationService { get; private set; }


        public RoleClaimService RoleClaimService { get; private set; }
        public RoleService RoleService { get; private set; }

        public UserClaimService UserClaimService { get; private set; }
        public UserPreferenceService UserPreferenceService { get; private set; }
        public UserRoleService UserRoleService { get; private set; }
        public UserService UserService { get; private set; }

        // ORDER
        public OrderService OrderService { get; private set; }


        public ServiceContext(string sqlConnectionString)
        {
            UnitOfWorkProvider.SqlConnectionString = sqlConnectionString;
            var uowProvider = new UnitOfWorkProvider();
            var repoFactory = new RepositoryFactory();

            MailService = new MailService(uowProvider, repoFactory);
            LogService = new LogService(uowProvider, repoFactory);

            // INTEGRATIONS
            IntegrationService = new IntegrationService(uowProvider, repoFactory);
            Integration_ExampleAuthService = new Integration_ExampleAuthService(uowProvider, repoFactory, IntegrationService);

            // IDENTITY
            RoleClaimService = new RoleClaimService(uowProvider, repoFactory);
            RoleService = new RoleService(uowProvider, repoFactory);

            UserClaimService = new UserClaimService(uowProvider, repoFactory);
            UserPreferenceService = new UserPreferenceService(uowProvider, repoFactory);
            UserRoleService = new UserRoleService(uowProvider, repoFactory);
            UserService = new UserService(uowProvider, repoFactory);

            // ORDER 
            OrderService = new OrderService(uowProvider, repoFactory, Integration_ExampleAuthService, UserService);

        }
    }
}
