using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class TenPowXOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            //calling power class to find 10^ x
            PowerOperation power = new PowerOperation();
            double result = power.Calculate(10, firstOperand);

            return result;
        }

    }
}