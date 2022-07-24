using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class DivisionOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result = 0;

            //Division logic
            result = secondOperand / firstOperand;

            return result;
        }
    }
}