using RicOneApi.Authentication.Models.OneRoster;
using RicOneApi.Authentication.Models.XPress;
using JWT;
using JWT.Serializers;
using System;
using JWT.Exceptions;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/20/2020
 */
namespace RicOneApi.Authentication
{
    /// <summary>
    /// Abstract class for decoding a token.
    /// </summary>
    abstract class TokenDecoder
    {
        internal static T DecodeToken<T>(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);
                return decoder.DecodeToObject<T>(token);
            }
            catch (Exception)
            {
                throw new InvalidTokenPartsException("Invalid authorization token provided.");
            }
        }

        /// <summary>
        /// Return the decoded token information on an xPress token.
        /// </summary>
        /// <param name="dt">An xPress decoded token.</param>
        /// <param name="token">An endpoint token.</param>
        /// <returns>A DecodedToken type.</returns>
        internal static DecodedToken GetDecodedToken(XPressDecodedToken dt, string token)
        {
            return new DecodedToken(dt.ApplicationId, null, null, token, dt.Iat, dt.Exp, dt.Iss);
        }

        /// <summary>
        /// Return the decoded token information on an xPress token.
        /// </summary>
        /// <param name="dt">An xPress decoded token.</param>
        /// <param name="token">An endpoint token.</param>
        /// <returns>A DecodedToken type.</returns>
        internal static DecodedToken GetDecodedToken(OneRosterDecodedToken dt, string token)
        {
            return new DecodedToken(dt.AppId, dt.ProviderId, dt.Href, token, dt.Iat, dt.Exp, dt.Iss);
        }
    }
}
