using RicOneApi.Authentication.Exceptions;
using RicOneApi.Authentication.Models.OneRoster;
using RicOneApi.Authentication.Models.XPress;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/16/2020
 */
namespace RicOneApi.Authentication
{
    /// <summary>
    /// The Endpoint class returns data about a specific provider. This includes the provider name, 
    /// href, provider id, token, and decoded token.
    /// </summary>
    public class Endpoint
    {
        private string token;

        /// <summary>
        /// Constructor for an xPress endpoint.
        /// </summary>
        /// <param name="endpoint">An xPress endpoint.</param>
        /// <param name="decodedToken">The decoded token for an xPress endpoint.</param>
        internal Endpoint(XPressEndpoint endpoint, DecodedToken decodedToken)
        {
            Name = endpoint.Name;
            Href = endpoint.Href;
            ProviderId = endpoint.ProviderId;
            Token = endpoint.Token;
            DecodedToken = decodedToken;
        }

        /// <summary>
        /// Constructor for a OneRoster endpoint.
        /// </summary>
        /// <param name="endpoint">A OneRoster endpoint.</param>
        /// <param name="decodedToken">The decoded token for a OneRoster endpoint.</param>
        internal Endpoint(OneRosterEndpoint endpoint, DecodedToken decodedToken)
        {
            Name = endpoint.Name;
            Href = endpoint.Href;
            ProviderId = endpoint.ProviderId;
            Token = endpoint.AccessToken;
            DecodedToken = decodedToken;
        }

        /// <summary>
        /// Get provider name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get provider href.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Get provider id.
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// Get the bearer token for API authentication.
        /// </summary>
        public string Token 
        {
            get
            {
                if (DecodedToken.WillTokenExpire())
                {
                    try
                    {
                        Authenticator.Instance.RefreshToken();
                    }
                    catch (AuthenticationException)
                    {
                        throw new AuthenticationException("Failed to refresh token.");
                    }
                }
                return token;
            }
            set => token = value;
        }

        /// <summary>
        /// Get the decoded token information on a bearer token.
        /// </summary>
        public DecodedToken DecodedToken { get; set; }
    }
}
