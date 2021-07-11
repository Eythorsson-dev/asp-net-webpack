using asp_net_webpack.Domain.Enum.Integration;

namespace asp_net_webpack.Core.Request.Integration
{
    public class IntegrationFilterRequest : BaseRequestPaged<IntegrationOrderByEnum>
    {
        public long IntegrationId { get; set; }
        public IntegrationTypeEnum IntegrationType { get; set; }
    }

    public enum IntegrationOrderByEnum
    {
        IntegrationType = 1
    }
}
