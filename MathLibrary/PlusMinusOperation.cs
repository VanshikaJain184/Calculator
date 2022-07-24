using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class PlusMinusOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            double result = firstOperand;

            //Sign change Logic
            result = result * (-1);

            return result;
        }
    }
}