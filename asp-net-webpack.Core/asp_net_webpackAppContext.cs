using asp_net_webpack.Core.Service;
using System;

namespace asp_net_webpack.Core
{
    public class asp_net_webpackAppContext
    {
        public static asp_net_webpackAppContext Current;

        public readonly ServiceContext Services;

        public asp_net_webpackAppContext(ServiceContext serviceContext)
        {
            if (Current != null)
                throw new InvalidOperationException("TagItAppContext is already initialized");
            Services = serviceContext;
        }
    }
}
