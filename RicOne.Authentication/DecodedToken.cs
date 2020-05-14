using RicOne.Authentication.Exceptions;
using System;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/20/2020
 */
namespace RicOne.Authentication
{
    public class DecodedToken
    {
        private string token;

        internal DecodedToken(string applicationId, string providerId, string href, string token, int iat, int exp, string iss)
        {
            ApplicationId = applicationId;
            ProviderId = providerId;
            Href = href;
            Token = token;
            Iat = iat;
            Exp = exp;
            Iss = iss;
        }

        /// <summary>
        /// Get applicaiton id.
        /// </summary>
        public string ApplicationId { get; }

        /// <summary>
        /// Get provider id.
        /// </summary>
        public string ProviderId { get; }

        /// <summary>
        /// Get provider href.
        /// </summary>
        public string Href { get; }

        /// <summary>
        /// Get bearer token.
        /// </summary>
        public string Token 
        { 
            get
            {
                if(WillTokenExpire())
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
        /// Get issued at time.
        /// </summary>
        public int Iat { get; }

        /// <summary>
        /// Get expiration time.
        /// </summary>
        public int Exp { get; }

        /// <summary>
        /// Get issuer.
        /// </summary>
        public string Iss { get; }

        /// <summary>
        /// Checks if an endpoint token will expire within the next 10 minutes.
        /// </summary>
        /// <returns>A Boolean type.</returns>
        internal bool WillTokenExpire()
        {
            try
            {
                DateTime expiry = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Exp).ToLocalTime();
                return expiry.AddMinutes(-10) <= DateTime.Now;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return true;
        }
    }
}
