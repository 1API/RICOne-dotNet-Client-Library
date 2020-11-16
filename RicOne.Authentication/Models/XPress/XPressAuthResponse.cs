using Newtonsoft.Json;
using System.Collections.Generic;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOneApi.Authentication.Models.XPress
{
    /// <summary>
    /// XPressAuthResponse type contains id, username, token, and list of endpoints.
    /// </summary>
    class XPressAuthResponse
    {
        /// <summary>
        /// Get the universally unique identifier (UUID)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Get the application user name.
        /// </summary>
        [JsonProperty("user_name")]
        public string Username { get; set; }

        /// <summary>
        /// Get the bearer token for API authentication.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Get all endpoints.
        /// </summary>
        [JsonProperty("endpoint")]
        public List<XPressEndpoint> Endpoint { get; set; }
    }
}
