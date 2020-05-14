using Newtonsoft.Json;
using System.Collections.Generic;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/14/2020
 */
namespace RicOne.Authentication.Models.OneRoster
{
    /// <summary>
    /// OneRosterAuthResponse type contains expires in and list of endpoints.
    /// </summary>
    class OneRosterAuthResponse
    {
        /// <summary>
        /// Get the expired time in seconds.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Get all endpoints.
        /// </summary>
        [JsonProperty("endpoint")]
        public List<OneRosterEndpoint> Endpoint { get; set; }
    }
}
