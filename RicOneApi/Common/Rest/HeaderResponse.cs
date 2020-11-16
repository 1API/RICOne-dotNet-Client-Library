using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.9.0
 * Since       11/13/2020
 */
namespace RicOneApi.Common.Rest
{
    public class HeaderResponse
    {
        /// <summary>
        /// Returns the headers of the response.
        /// </summary>
        public string Header { get; internal set; }
        /// <summary>
        /// Returns the status code of the response.
        /// </summary>
        public int StatusCode { get; internal set; }
        /// <summary>
        /// Returns the message of the response.
        /// </summary>
        public string Message { get; internal set; }
        /// <summary>
        /// Returns the last page value for specified service path object.
        /// </summary>
        public int NavigationLastPage { get; internal set; }
        /// <summary>
        /// Returns the record count for specified service path object.
        /// </summary>
        public int RecordCount { get; internal set; }
    }
}
