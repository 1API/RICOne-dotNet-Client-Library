using RestSharp;
using RestSharp.Authenticators;
using RicOneApi.Api;
using RicOneApi.Models.XPress;
using System;
using System.Linq;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.8.0
 * Since       2020-02-12
 */
namespace RicOneApi.Common.Rest
{
    /// <summary>
    /// Class that handles requests and responses to the API.
    /// </summary>
    class RestReturn
    {
        internal HeaderResponse HeadRequest(RestClient rc, RestProperties rp)
        {
            RestRequest request = RequestBuilder(rc, rp);
            HeaderResponse headerResponse = new HeaderResponse();
            var response = rc.Execute<HeaderResponse>(request, Method.HEAD);

            headerResponse.Header = Util.BuildHeader(response);
            headerResponse.StatusCode = (int)response.StatusCode;
            headerResponse.Message = response.StatusCode.ToString();

            if (rp.RestHeader.HasPaging())
            {
                headerResponse.NavigationLastPage = int.Parse(response.Headers.ToList()
                .Find(x => x.Name.Equals("NavigationLastPage", StringComparison.CurrentCultureIgnoreCase))
                .Value.ToString());

                headerResponse.RecordCount = int.Parse(response.Headers.ToList()
                .Find(x => x.Name.Equals("NavigationCount", StringComparison.CurrentCultureIgnoreCase))
                .Value.ToString());
            }
            else
            {
                headerResponse.RecordCount = int.Parse(response.Headers.ToList()
                .Find(x => x.Name.Equals("X-Record-Count", StringComparison.CurrentCultureIgnoreCase))
                .Value.ToString());
            }

            return headerResponse;
        }

        /// <summary>
        /// Generic REST call for list objects.
        /// </summary>
        /// <typeparam name="E">Object Type.</typeparam>
        /// <typeparam name="T">Collection Object Type.</typeparam>
        /// <param name="rc">REST client.</param>
        /// <param name="rp">REST properties for request.</param>
        /// <returns>Multiple object response for a REST call.</returns>
        internal ResponseMulti<E> MakeAllRequest<E,T>(RestClient rc, RestProperties rp) where T : ICollectionType<E,T>, new()
        {
            ResponseMulti<E> output = new ResponseMulti<E>();
            RestRequest request = RequestBuilder(rc, rp);

            var response = rc.Execute<T>(request);

            try
            {
                if (rp.RestHeader.HasPaging())
                {
                    NavigationLastPage = NavigationLastPage = int.Parse(response.Headers.ToList()
                    .Find(x => x.Name.Equals("navigationLastPage", StringComparison.CurrentCultureIgnoreCase))
                    .Value.ToString());
                }
                output.Data = response.Data.GetObjects.GetObject;
                output.Json = response.Content;
                output.Xml = Util.ConvertJson2Xml(response.Content);
                output.StatusCode = (int)response.StatusCode;
                output.Message = response.StatusCode.ToString();
                output.Header = Util.BuildHeader(response);
            }
            catch (Exception)
            {
                output.Data = null;
                output.Json = null;
                output.Xml = null;
                output.StatusCode = (int)response.StatusCode;
                output.Message = response.StatusCode.ToString();
                output.Header = Util.BuildHeader(response);
            }
            return output;
        }

        /// <summary>
        /// Generic REST call for single objects.
        /// </summary>
        /// <typeparam name="E">Object Type.</typeparam>
        /// <typeparam name="T">Collection Object Type.</typeparam>
        /// <param name="rc">REST client.</param>
        /// <param name="rp">REST properties for request.</param>
        /// <returns>Single object response for a REST call.</returns>
        internal ResponseSingle<E> MakeSingleRequest<E,T>(RestClient rc, RestProperties rp) where T : ICollectionType<E,T>, new()
        {
            ResponseSingle<E> output = new ResponseSingle<E>();
            RestRequest request = RequestBuilder(rc, rp);
            var response = rc.Execute<T>(request);

            try
            {
                output.Data = response.Data.GetObject.First();
                output.Json = response.Content;
                output.Xml = Util.ConvertJson2Xml(response.Content);
                output.StatusCode = (int)response.StatusCode;
                output.Message = response.StatusCode.ToString();
                output.Header = Util.BuildHeader(response);
            }
            catch (Exception)
            {
                output.Data = default(E);
                output.Json = null;
                output.Xml = null;
                output.StatusCode = (int)response.StatusCode;
                output.Message = response.StatusCode.ToString();
                output.Header = Util.BuildHeader(response);
            }
            return output;
        }

        /// <summary>
        /// REST Header and Query Parameter builder method. Adds headers for JSON, paging, local/beds ids,
        /// and school year. Adds query parameters for changesSince and AUPP.
        /// </summary>
        /// <param name="rp">REST properties for request.</param>
        /// <returns>The request with appropriate headers and query parameters.</returns>
        private RestRequest RequestBuilder(RestClient rc, RestProperties rp)
        {
            rc.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(rp.Endpoint.Token, "Bearer");
            RestRequest request = new RestRequest(rp.ServicePath.GetServicePath(), Method.GET);

            if (!string.IsNullOrEmpty(rp.RefId))
            {
                request.AddParameter("refId", rp.RefId, ParameterType.UrlSegment);
            }
            if (rp.RestHeader.HasPaging())
            {
                request.AddHeader("NavigationPage", rp.RestHeader.GetNavigationPage());
                request.AddHeader("NavigationPageSize", rp.RestHeader.GetNavigationPageSize());
            }

            if(rp.RestHeader.HasIdType())
            {
                request.AddParameter("id", rp.RestHeader.Id, ParameterType.UrlSegment);
                request.AddHeader("IdType", rp.RestHeader.IdType);
            }
            if (rp.RestHeader.HasSchoolYear())
            {
                request.AddHeader("SchoolYear", rp.RestHeader.GetSchoolYear());
            }
            if (rp.RestQueryParameter.HasOpaqueMarker())
            {
                request.AddQueryParameter("changesSinceMarker", rp.RestQueryParameter.OpaqueMarker);
            }
            if(rp.RestQueryParameter.HasAUPP())
            {
                if (rp.RestQueryParameter.IsCreateUsers())
                {
                    request.AddQueryParameter("createUsers", "true");
                }
                else if (rp.RestQueryParameter.IsDeleteUsers())
                {
                    request.AddQueryParameter("deleteUsers", "true");
                }
                else if (rp.RestQueryParameter.IsDeleteUsernamesPasswords())
                {
                    request.AddQueryParameter("deleteUsers", "true");
                    request.AddQueryParameter("usernames", "true");
                }
                else if (rp.RestQueryParameter.IsGetUsers())
                {
                    request.AddQueryParameter("getUsers", "true");
                }
            }
            return request;
        }

        /// <summary>
        /// Accessor method that holds navigation last page integer value.
        /// </summary>
        internal int NavigationLastPage { get; set; }

        //private void WillTokenExpire(RestProperties rp)
        //{
        //    rp.Endpoint.Token;
        //    rp.Endpoint.DecodedToken.Token;
        //}
    }
}
