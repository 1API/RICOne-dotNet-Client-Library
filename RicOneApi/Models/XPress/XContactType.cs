﻿using System;
using RestSharp.Deserializers;

/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.7
 * Since       2018-12-20
 * Filename    XContactType.cs
 */
namespace RicOneApi.Models.XPress
{
    /// <summary>
    /// XContactType
    /// </summary>
    public class XContactType
    {
        public XContactType()
        {
            refId = null;
            name = new XPersonNameType();
            otherNames = new XOtherPersonNameListType();
            localId = null;
            otherIds = new XOtherPersonIdListType();
            appProvisioningInfo = new XAppProvisioningInfoType();
            address = new XPersonAddressType();
            phoneNumber = new XTelephoneType();
            otherPhoneNumbers = new XTelephoneListType();
            email = new XEmailType();
            otherEmails = new XEmailListType();
            sex = null;
            employerType = null;
            relationships = new XContactStudentRelationshipListType();
            Metadata = new XMetadata();
        }
        [DeserializeAs(Name = "@refId")]
        public string refId { get; set; }
        public XPersonNameType name { get; set; }
        public XOtherPersonNameListType otherNames { get; set; }
        public string localId { get; set; }
        public XOtherPersonIdListType otherIds { get; set; }
        public XAppProvisioningInfoType appProvisioningInfo { get; set; }
        public XPersonAddressType address { get; set; }
        public XTelephoneType phoneNumber { get; set; }
        public XTelephoneListType otherPhoneNumbers { get; set; }
        public XEmailType email { get; set; }
        public XEmailListType otherEmails { get; set; }
        public string sex { get; set; }
        public string employerType { get; set; }
        public XContactStudentRelationshipListType relationships { get; set; }
        public XMetadata Metadata { get; set; }

        public XContactCollectionType GetObjects { get; set; }
        public XContactType GetObject
        {
            get { return this; }
            set { throw new NotImplementedException(); }
        }

    }
}
