﻿/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.1
 * Since       2015-07-20
 * Filename    XOrganizationAddressType.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicOneApi.Models.XPress
{
    /// <summary>
    /// XOrganizationAddressType
    /// </summary>
    public class XOrganizationAddressType
    {
        public XOrganizationAddressType()
        {
            addressType = null;
            line1 = null;
            line2 = null;
            city = null;
            stateProvince = null;
            countryCode = null;
            postalCode = null;
        }

        public string addressType { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string stateProvince { get; set; }
        public string countryCode { get; set; }
        public string postalCode { get; set; }
    }
}
