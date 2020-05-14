using Newtonsoft.Json;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOne.Authentication.Models.XPress
{
    /// <summary>
    /// XPressEndpoint type contains endpoint name, href, providerId, and token.
    /// </summary>
    class XPressEndpoint
    {
        /// <summary>
        /// Get provider name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Get provider href.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// Get provider id.
        /// </summary>
        [JsonProperty("provider_id")]
        public string ProviderId { get; set; }

        /// <summary>
        /// Get the token for API authentication.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
