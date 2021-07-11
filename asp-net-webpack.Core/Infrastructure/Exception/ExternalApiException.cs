using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace asp_net_webpack.Core
{
    class ExternalApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ExternalApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
