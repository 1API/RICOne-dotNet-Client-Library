using RicOneApi.Common.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicOneApi.Common.Objects
{
    interface IHeaderRequest
    {
        HeaderResponse GetHeaders(ServicePath servicePath);
        HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize);
        HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize, int? schoolYear);
        HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize, string opaqueMarker);
        HeaderResponse GetHeaders(ServicePath servicePath, string refId);
        HeaderResponse GetHeaders(ServicePath servicePath, string refId, int? navigationPageSize);
        HeaderResponse GetHeaders(ServicePath servicePath, string refId, int? navigationPageSize, int? schoolYear);
    }
}
