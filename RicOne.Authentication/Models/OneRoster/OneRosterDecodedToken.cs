using Newtonsoft.Json;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOne.Authentication.Models.OneRoster
{
    /// <summary>
    /// OneRosterDecodedToken type contains application id, IMS global security scope,
    /// provider id, href, issued at time, expiration time, and issuer for a OneRoster bearer token.
    /// </summary>
    class OneRosterDecodedToken
    {
        /// <summary>
        /// Get applicaiton id.
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// Get the ims.global.org.security.scope.
        /// </summary>
        [JsonProperty("ims.global.org.security.scope")]
        public string ImsGlobalOrgSecurityScope { get; set; }

        /// <summary>
        /// Get provider id.
        /// </summary>
        [JsonProperty("provider_id")]
        public string ProviderId { get; set; }

        /// <summary>
        /// Get provider href.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

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
