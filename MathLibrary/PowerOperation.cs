using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class PowerOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result = 1;

            //firstOperand behave as base and secondOperand behave as exponent
            for (int itr = 1; itr <= firstOperand; itr++)
            {
                result = result * secondOperand;
            }
            return result;
        }
    }
}