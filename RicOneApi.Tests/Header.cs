using RicOneApi.Api;
using RicOneApi.Authentication;
using RicOneApi.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     x.x.x
 * Since       m/dd/yyyy
 */
namespace RicOneApi.Tests
{
    class Header
    {
        #region Test Constants
        static string authUrl = "https://auth.test.ricone.org/login";
        static string clientId = "dpaDemo";
        static string clientSecret = "deecd889bff5ed0101a86680752f5f9";
        static string providerId = "localhost";
        //static string token = ConfigurationManager.AppSettings["authToken"];

        const string LEA_REFID = "03ACF04F-DC12-411A-9A42-E8323516D699";
        const string LEA_BEDSIDTYPE = "beds";
        const string LEA_BEDSID = "530501060000";
        const string LEA_LOCALIDTYPE = "local";
        const string LEA_LOCALID = "530501";
        const string SCHOOL_REFID = "AE6B3441-5E31-4573-BADB-081669D79C7F";
        const string SCHOOL_BEDSIDTYPE = "BEDS";
        const string SCHOOL_BEDSID = "530501060004";
        const string SCHOOL_LOCALIDTYPE = "local";
        const string SCHOOL_LOCALID = "shm";
        const string CALENDAR_REFID = "09F0C2E3-B437-3671-AB05-1BA18B6FA034";
        const string COURSE_REFID = "82045B14-FE41-4FA8-8CD7-2350BF7C4C9B";
        const string ROSTER_REFID = "00E1179D-60AF-4C98-8B59-557830BDD5FC";
        const string STAFF_REFID = "15355903-789E-434E-A0EA-B8F9F0E3374A";
        const string STAFF_STATEIDTYPE = "State";
        const string STAFF_STATEID = "002258565";
        const string STAFF_LOCALIDTYPE = "District";
        const string STAFF_LOCALID = "00225";
        const string STUDENT_REFID = "C5039D85-FEA9-46E2-8D3D-C468937953B4";
        const string STUDENT_STATEIDTYPE = "State";
        const string STUDENT_STATEID = "7037859426";
        const string STUDENT_LOCALIDTYPE = "District";
        const string STUDENT_LOCALID = "611112521";
        const string CONTACT_REFID = "2D6E0697-EDF8-4E9E-ADCF-18CA9EDF0529";
        #endregion
        static void Main(string[] args)
        {
            Authenticator auth = Authenticator.Instance;
            auth.Authenticate(authUrl, clientId, clientSecret);

            foreach (Endpoint e in auth.GetEndpoints(providerId))
            {
                XPress xPress = new XPress(e);

                //Headers(xPress);
                Message(xPress);
                //StatusCode(xPress);
                //NavigationLastPage(xPress);
                //RecordCount(xPress);

                Console.Read();
            }         
        }


        private static void Headers(XPress xPress)
        {
            Console.WriteLine("### HEADERS");
            Console.WriteLine("Header: " + xPress.GetHeaders(ServicePath.GetXRosters).Header);
            Console.WriteLine("Header with RefId: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID).Header);
            Console.WriteLine("Header with Paging " + xPress.GetHeaders(ServicePath.GetXRosters, 100).Header);
            Console.WriteLine("Header with Paging and SchoolYear " + xPress.GetHeaders(ServicePath.GetXRosters, 100, 2020).Header);
            Console.WriteLine("Header with Paging and OpaqueMarker " + xPress.GetHeaders(ServicePath.GetXRosters, 100, "2018-11-30T11:37:55.626-05:00").Header);
            Console.WriteLine("Header with RefId and Paging: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100).Header);
            Console.WriteLine("Header with RefId and Paging and SchoolYear: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100, 2020).Header);
        }

        private static void Message(XPress xPress)
        {
            Console.WriteLine("### MESSAGE");
            Console.WriteLine("Header: " + xPress.GetHeaders(ServicePath.GetXRosters).Message);
            Console.WriteLine("Header with RefId: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID).Message);
            Console.WriteLine("Header with Paging " + xPress.GetHeaders(ServicePath.GetXRosters, 100).Message);
            Console.WriteLine("Header with Paging and SchoolYear " + xPress.GetHeaders(ServicePath.GetXRosters, 100, 2020).Message);
            Console.WriteLine("Header with Paging and OpaqueMarker " + xPress.GetHeaders(ServicePath.GetXRosters, 100, "2018-11-30T11:37:55.626-05:00").Message);
            Console.WriteLine("Header with RefId and Paging: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100).Message);
            Console.WriteLine("Header with RefId and Paging and SchoolYear: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100, 2020).Message);
        }

        private static void StatusCode(XPress xPress)
        {
            Console.WriteLine("### STATUS CODE");
            Console.WriteLine("Header: " + xPress.GetHeaders(ServicePath.GetXRosters).StatusCode);
            Console.WriteLine("Header with RefId: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID).StatusCode);
            Console.WriteLine("Header with Paging " + xPress.GetHeaders(ServicePath.GetXRosters, 100).StatusCode);
            Console.WriteLine("Header with Paging and SchoolYear " + xPress.GetHeaders(ServicePath.GetXRosters, 100, 2020).StatusCode);
            Console.WriteLine("Header with Paging and OpaqueMarker " + xPress.GetHeaders(ServicePath.GetXRosters, 100, "2018-11-30T11:37:55.626-05:00").StatusCode);
            Console.WriteLine("Header with RefId and Paging: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100).StatusCode);
            Console.WriteLine("Header with RefId and Paging and SchoolYear: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100, 2020).StatusCode);
        }

        private static void NavigationLastPage(XPress xPress)
        {
            Console.WriteLine("### LAST PAGE");
            Console.WriteLine("Header: " + xPress.GetHeaders(ServicePath.GetXRosters).NavigationLastPage);
            Console.WriteLine("Header with RefId: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID).NavigationLastPage);
            Console.WriteLine("Header with Paging " + xPress.GetHeaders(ServicePath.GetXRosters, 100).NavigationLastPage);
            Console.WriteLine("Header with Paging and SchoolYear " + xPress.GetHeaders(ServicePath.GetXRosters, 100, 2020).NavigationLastPage);
            Console.WriteLine("Header with Paging and OpaqueMarker " + xPress.GetHeaders(ServicePath.GetXRosters, 100, "2018-11-30T11:37:55.626-05:00").NavigationLastPage);
            Console.WriteLine("Header with RefId and Paging: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100).NavigationLastPage);
            Console.WriteLine("Header with RefId and Paging and SchoolYear: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100, 2020).NavigationLastPage);
        }

        private static void RecordCount(XPress xPress)
        {
            Console.WriteLine("### RECORD COUNT");
            Console.WriteLine("Header: " + xPress.GetHeaders(ServicePath.GetXRosters).RecordCount);
            Console.WriteLine("Header with RefId: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID).RecordCount);
            Console.WriteLine("Header with Paging " + xPress.GetHeaders(ServicePath.GetXRosters, 100).RecordCount);
            Console.WriteLine("Header with Paging and SchoolYear " + xPress.GetHeaders(ServicePath.GetXRosters, 100, 2020).RecordCount);
            Console.WriteLine("Header with Paging and OpaqueMarker " + xPress.GetHeaders(ServicePath.GetXRosters, 100, "2018-11-30T11:37:55.626-05:00").RecordCount);
            Console.WriteLine("Header with RefId and Paging: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100).RecordCount);
            Console.WriteLine("Header with RefId and Paging and SchoolYear: " + xPress.GetHeaders(ServicePath.GetXRostersByXLea, LEA_REFID, 100, 2020).RecordCount);
        }
    }
}
