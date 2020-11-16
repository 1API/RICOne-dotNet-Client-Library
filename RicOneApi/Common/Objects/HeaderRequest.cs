using RestSharp;
using RicOneApi.Authentication;
using RicOneApi.Common.Rest;
using System;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.9.0
 * Since       11/13/2020
 */
namespace RicOneApi.Common.Objects
{
    class HeaderRequest : IHeaderRequest
    {
        private RestClient rc;
        private Endpoint endpoint;

        public HeaderRequest(RestClient rc, Endpoint endpoint)
        {
            this.rc = rc;
            this.endpoint = endpoint;
        }

        public HeaderResponse GetHeaders(ServicePath servicePath)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize)
        {
            int navigationPage = 1;
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize, int? schoolYear)
        {
            int navigationPage = 1;
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, int? navigationPageSize, string opaqueMarker)
        {
            int navigationPage = 1;
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter(opaqueMarker);
            RestProperties rp = new RestProperties(endpoint, servicePath, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, string refId)
        {
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader();
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, refId, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, string refId, int? navigationPageSize)
        {
            int navigationPage = 1;
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, refId, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }

        public HeaderResponse GetHeaders(ServicePath servicePath, string refId, int? navigationPageSize, int? schoolYear)
        {
            int navigationPage = 1;
            RestReturn rr = new RestReturn();
            RestHeader rh = new RestHeader(navigationPage, navigationPageSize, schoolYear);
            RestQueryParameter rqp = new RestQueryParameter();
            RestProperties rp = new RestProperties(endpoint, servicePath, refId, rh, rqp);
            return rr.HeadRequest(rc, rp);
        }
    }
}
