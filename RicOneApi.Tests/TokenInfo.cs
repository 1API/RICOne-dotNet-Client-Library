using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RicOneApi.Api;
using RicOneApi.Authentication;
using System.Configuration;

namespace RicOneApi.Tests
{
    class TokenInfo
    {
        #region Test Constants
        static string authUrl = ConfigurationManager.AppSettings["authUrl"];
        static string clientId = ConfigurationManager.AppSettings["authClientId"];
        static string clientSecret = ConfigurationManager.AppSettings["authClientSecret"];
        #endregion
        static void Main(string[] args)
        {
            Authenticator auth = Authenticator.Instance;
            auth.Authenticate(authUrl, clientId, clientSecret);


            foreach (Endpoint e in auth.GetEndpoints())
            {
                Console.WriteLine(e.DecodedToken.ApplicationId);
                Console.WriteLine(e.DecodedToken.Iss);
                Console.WriteLine(e.DecodedToken.Iat);
                Console.WriteLine(e.DecodedToken.Exp); 
            }

            Console.Read(); 
        }

    }
}
