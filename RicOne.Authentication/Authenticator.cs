using RestSharp;
using RestSharp.Authenticators;
using RicOne.Authentication.Exceptions;
using RicOne.Authentication.Models.OneRoster;
using RicOne.Authentication.Models.XPress;
using System;
using System.Collections.Generic;
using System.Linq;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/20/2020
 */
namespace RicOne.Authentication
{
    /// <summary>
    /// Handles authentication for user to Authentication server. Included methods return user and provider information necessary to
    /// access the data API (i.e. token and url).
    /// </summary>
    public sealed class Authenticator
    {
        private static readonly Lazy<Authenticator> lazy = new Lazy<Authenticator>(() => new Authenticator());
        private static RestClient client;
        private static RestRequest request;
        private string authUrl;
        private string clientId;
        private string clientSecret;
        private SpecEnum.SpecType specFlag;
        private List<Endpoint> endpoints = new List<Endpoint>();

        /// <summary>
        /// Singleton instantiation.
        /// </summary>
        public static Authenticator Instance { get { return lazy.Value; } }
        private Authenticator() { }

        /// <summary>
        /// Establish connection to authenticate to xPress or OneRoster authentication server.
        /// </summary>
        /// <param name="authUrl">The authentication server url.</param>
        /// <param name="clientId">The clientId for the application.</param>
        /// <param name="clientSecret">The clientSecret for the application.</param>
        public void Authenticate(string authUrl, string clientId, string clientSecret)
        {
            this.authUrl = authUrl;
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            endpoints.Clear();

            if (this.authUrl.EndsWith("/oauth/login"))
            {
                specFlag = SpecEnum.SpecType.OneRoster;
                OneRosterLogin(authUrl, clientId, clientSecret);

            }
            else if (this.authUrl.EndsWith("/login"))
            {
                specFlag = SpecEnum.SpecType.XPress;
                XPressLogin(authUrl, clientId, clientSecret);
            }
        }

        /// <summary>
        /// Re-authenticates with xPress or OneRoster authentication server if token is expired.
        /// </summary>
        internal void RefreshToken()
        {
            if (specFlag.Equals(SpecEnum.SpecType.XPress))
            {
                endpoints.Clear();
                XPressLogin(authUrl, clientId, clientSecret);
            }
            else if (specFlag.Equals(SpecEnum.SpecType.OneRoster))
            {
                endpoints.Clear();
                OneRosterLogin(authUrl, clientId, clientSecret);

            }
        }

        /// <summary>
        /// POST to xPress authentication server with provided credentials.
        /// </summary>
        /// <param name="authUrl">The authentication server url.</param>
        /// <param name="clientId">The clientId for the application.</param>
        /// <param name="clientSecret">The clientSecret for the application.</param>
        /// <returns>A list of type Endpoint.</returns>
        private List<Endpoint> XPressLogin(string authUrl, string clientId, string clientSecret)
        {
            try
            {
                client = new RestClient(authUrl);
                request = new RestRequest(Method.POST);
                request.AddParameter("username", clientId, ParameterType.GetOrPost);
                request.AddParameter("password", clientSecret, ParameterType.GetOrPost);
                IRestResponse<XPressAuthResponse> response = client.Execute<XPressAuthResponse>(request);

                if (response.Data != null)
                {
                    foreach (XPressEndpoint endpoint in response.Data.Endpoint)
                    {
                        DecodedToken decodedToken = TokenDecoder.GetDecodedToken(TokenDecoder.DecodeToken<XPressDecodedToken>(endpoint.Token), endpoint.Token);
                        endpoints.Add(new Endpoint(endpoint, decodedToken));
                    }
                }
            }
            catch (Exception e)
            {
                throw new AuthenticationException("401 UNAUTHORIZED", e);
            }
            return endpoints;
        }

        /// <summary>
        /// POST to OneRoster authentication server with provided credentials.
        /// </summary>
        /// <param name="authUrl">The authentication server url.</param>
        /// <param name="clientId">The clientId for the application.</param>
        /// <param name="clientSecret">The clientSecret for the application.</param>
        /// <returns>A list of type Endpoint.</returns>
        private List<Endpoint> OneRosterLogin(string authUrl, string clientId, string clientSecret)
        {
            try
            {
                client = new RestClient(authUrl);
                client.Authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
                request = new RestRequest(Method.POST);
                request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
                IRestResponse<OneRosterAuthResponse> response = client.Execute<OneRosterAuthResponse>(request);

                if (response.Data != null)
                {
                    foreach (OneRosterEndpoint endpoint in response.Data.Endpoint)
                    {
                        DecodedToken decodedToken = TokenDecoder.GetDecodedToken(TokenDecoder.DecodeToken<OneRosterDecodedToken>(endpoint.AccessToken), endpoint.AccessToken);
                        endpoints.Add(new Endpoint(endpoint, decodedToken));
                    }
                }
            }
            catch (Exception e)
            {
                throw new AuthenticationException("401 UNAUTHORIZED", e);
            }
            return endpoints;
        }

        /// <summary>
        /// Retrieve a provider's token.
        /// </summary>
        /// <param name="providerId">The providerId to be returned.</param>
        /// <returns>String type.</returns>
        public string GetToken(string providerId)
        {
            if(endpoints != null)
            {
                Endpoint e = GetEndpoints(providerId).First();
                if(e != null)
                {
                    return e.Token;
                }
            }
            return null;
        }

        /// <summary>
        /// Details of a specific endpoint by providerId.
        /// </summary>
        /// <param name="providerId">The providerId to be returned.</param>
        /// <returns>List of type Endpoint.</returns>
        public List<Endpoint> GetEndpoints(string providerId)
        {
            if (endpoints != null)
            {
                List<Endpoint> endpoint = endpoints.Where(e => e.ProviderId.Equals(providerId)).ToList();
                return endpoint;

            }
            return new List<Endpoint>();
        }

        /// <summary>
        /// A list of all endpoints an application is associated with and it's details.
        /// </summary>
        /// <returns>List of type Endpoint.</returns>
        public List<Endpoint> GetEndpoints()
        {
            if (endpoints != null)
            {
                return endpoints;
            }
            return new List<Endpoint>();
        }
    }
}
