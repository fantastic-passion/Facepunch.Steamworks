using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAPIValidator
{
    public class FilthyPirateException : Exception
    {
        public override string Message => "Steam API files could not be validated as being official.";
    }
}