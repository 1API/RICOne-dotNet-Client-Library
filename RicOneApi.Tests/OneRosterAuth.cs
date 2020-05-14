using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RicOne.Authentication;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     x.x.x
 * Since       m/dd/yyyy
 */
namespace RicOneApi.Tests
{
    class OneRosterAuth
    {
        static string authUrl = "https://auth.test.ricone.org/login";
        //static string authUrl = "https://auth.test.ricone.org/oauth/login";
        static string clientId = "dpaDemo";
        static string clientSecret = "deecd889bff5ed0101a86680752f5f9";
        static string providerId = "localhost";

        static void Main(string[] args)
        {
            Authenticator auth = Authenticator.Instance;
            auth.Authenticate(authUrl, clientId, clientSecret);

            // Get all endpoint info
            //GetAllEndpoints(auth);

            // Get single endpoint info
            //GetSingleEndpoint(auth, providerId);

            // Get token
            //GetToken(auth, providerId);

            // Get Decoded token info
            //GetDecodedToken(auth, providerId);

            //CallRefresh(auth, providerId);

            TestTokenExpiration(auth);
            
            Console.Read();
        }

        private static void GetAllEndpoints(Authenticator authenticator)
        {
            Console.WriteLine("#### Get all endpoint info ####");
            foreach (Endpoint e in authenticator.GetEndpoints())
            {
                Console.WriteLine("name: " + e.Name + " | href: " + e.Href + " | provider_id: " + e.ProviderId + " | token: " + e.Token);
            }
        }

        private static void GetSingleEndpoint(Authenticator authenticator, string providerId)
        {
            Console.WriteLine("#### Get single endpoint info ####");
            Endpoint e = authenticator.GetEndpoints(providerId).First();
            Console.WriteLine("name: " + e.Name + " | href: " + e.Href + " | provider_id: " + e.ProviderId + " | token: " + e.Token);
        }

        private static void GetToken(Authenticator authenticator, string providerId)
        {
            Console.WriteLine("#### Get token ####");
            Console.WriteLine("token: " + authenticator.GetToken(providerId));
        }

        private static void GetDecodedToken(Authenticator authenticator, string providerId)
        {
            foreach (Endpoint e in authenticator.GetEndpoints())
            {
                Console.WriteLine("" + e.DecodedToken.ApplicationId + " | " + e.DecodedToken.Iat + " | " + e.DecodedToken.Exp + " | " + e.DecodedToken.Iss + " | " + e.ProviderId + " | " + e.Token.Substring(e.Token.LastIndexOf(".")));
            }
        }

        private static void TestTokenExpiration(Authenticator authenticator)
        {

            while (true)
            {
                Endpoint e = authenticator.GetEndpoints(providerId).First();
                Console.WriteLine(DateTime.Now + " | "  + WillTokenExpire(e) +  " | Endpoint: " + e.Token.Substring(e.Token.LastIndexOf(".")) + " | DecodendToken: " + e.DecodedToken.Token.Substring(e.DecodedToken.Token.LastIndexOf(".")));
                Thread.Sleep(420000); // 7minutes
            }
        }

        private static bool WillTokenExpire(Endpoint endpoint)
        {
            try
            {
                DateTime expiry = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(endpoint.DecodedToken.Exp).ToLocalTime();
                return expiry.AddMinutes(-10) <= DateTime.Now;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return true;
        }
    }
}
