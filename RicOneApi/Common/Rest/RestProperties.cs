using RicOneApi.Authentication;
using RicOneApi.Common.Objects;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.9.0
 * Since       2020-08-15
 */
namespace RicOneApi.Common.Rest
{
    /// <summary>
    /// Accessor class used for building requests based on provided values. This includes base API url, servicepath, refid, 
    /// REST headers, and REST query parameters.
    /// </summary>
    class RestProperties
    {
        public RestProperties(Endpoint endpoint, ServicePath servicePath, RestHeader restHeader, RestQueryParameter restQueryParameter)
        {
            Endpoint = endpoint;
            BaseUrl = endpoint.Href;
            ServicePath = servicePath;
            RestHeader = restHeader;
            RestQueryParameter = restQueryParameter;
        }

        public RestProperties(Endpoint endpoint, ServicePath servicePath, string refId, RestHeader restHeader, RestQueryParameter restQueryParameter)
        {
            Endpoint = endpoint;
            BaseUrl = endpoint.Href;
            ServicePath = servicePath;
            RefId = refId;
            RestHeader = restHeader;
            RestQueryParameter = restQueryParameter;
        }

        public Endpoint Endpoint { get; set; }
        public string BaseUrl { get; set; }
        public string RefId { get; set; }
        public ServicePath ServicePath { get; set; }
        internal RestHeader RestHeader { get; set; }
        internal RestQueryParameter RestQueryParameter { get; set; }

        internal bool HasRefId() { return !string.IsNullOrEmpty(RefId); }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
