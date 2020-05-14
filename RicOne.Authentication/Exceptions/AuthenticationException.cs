using System;


/*
 * Author      Andrew Pieniezny <andrew.pieniezny@neric.org>
 * Version     1.0.0
 * Since       4/20/2020
 */
namespace RicOne.Authentication.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException()
        { }

        public AuthenticationException(string message) : base(message)
        { }
        public AuthenticationException(string message, Exception inner) : base(message, inner)
        { }
    }
}
