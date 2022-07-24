using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class SecOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            double result = 0;

            //Sec calculation formula= 1/cos

            CosOperation cosclass = new CosOperation();
            double denominator = cosclass.Calculate(firstOperand);

            result = 1/(denominator);

            return result;
        }
    }
}