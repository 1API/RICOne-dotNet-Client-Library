using Newtonsoft.Json;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOne.Authentication.Models.XPress
{
    /// <summary>
    /// XPressDecodedToken type contains application id, issued at time, expiration time, and issuer
    /// for an xPress bearer token.
    /// </summary>
    class XPressDecodedToken
    {
        /// <summary>
        /// Get applicaiton id.
        /// </summary>
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Get issued at time.
        /// </summary>
        [JsonProperty("iat")]
        public int Iat { get; set; }

        /// <summary>
        /// Get expiration time.
        /// </summary>
        [JsonProperty("exp")]
        public int Exp { get; set; }

        /// <summary>
        /// Get issuer.
        /// </summary>
        [JsonProperty("iss")]
        public string Iss { get; set; }
    }
}
