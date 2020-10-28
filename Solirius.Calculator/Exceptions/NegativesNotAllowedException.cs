using System;
using System.Collections.Generic;
using System.Text;

namespace Solirius.Calculator.Exceptions
{
    public class NegativesNotAllowedException: Exception
    {
        public NegativesNotAllowedException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}
