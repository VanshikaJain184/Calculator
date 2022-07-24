using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class AdditionOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result = 0;

            //Addition
            result = firstOperand + secondOperand;

            return result;
        }
    }
}
