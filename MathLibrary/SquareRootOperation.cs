using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class SquareRootOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            double result = 1;
            int i = 0;

            //The Babylonian Method for Computing Square Roots
            while (true)
            {
                i = i + 1;
                result = (firstOperand / result + result) / 2;
                if (i == firstOperand + 1) { break; }
            }
            return result;
        }
    }
}