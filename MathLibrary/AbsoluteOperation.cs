using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class AbsoluteOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            //Always give positive number
            double result = firstOperand;
            if (firstOperand < 0)
                result = result * -1;
            else
                result = firstOperand;

            return result;
        }
    }
}