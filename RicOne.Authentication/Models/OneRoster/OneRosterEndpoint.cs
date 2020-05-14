using Newtonsoft.Json;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOne.Authentication.Models.OneRoster
{
    /// <summary>
    /// OneRosterEndpoint type contains endpoint name, href, providerId, access token, and token type.
    /// </summary>
    class OneRosterEndpoint
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
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Get the token type i.e. bearer.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
