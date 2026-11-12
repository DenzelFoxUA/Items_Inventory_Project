
using System;
using System.Runtime.Serialization;

namespace InventoryCoreLib
{
    public class ObjectNotInitializedException : ArgumentNullException
    {

        public const string MSG = "Parameter not initialized, null reference error.";

        public ObjectNotInitializedException(Exception? innerException) 
            : base(MSG, innerException){}

        public ObjectNotInitializedException(string? paramName) 
            : base(paramName, MSG){}

    }
}
