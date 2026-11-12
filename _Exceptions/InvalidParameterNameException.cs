using Microsoft.VisualBasic;
using System;

namespace InventoryCoreLib
{
    public class InvalidParameterNameException : ArgumentException
    {
        #region [ CTROR'S ]

        private const string msg = "Correct key/name of parameter required!" +
            "No such name in parameters list";

        public InvalidParameterNameException() 
            : base(msg){}

        public InvalidParameterNameException(string paramName) 
            : base(msg, paramName) { }

        #endregion


    }
}
