using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class MultiplicationOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result = 1;

            //Multiplication Logic
            result = firstOperand * secondOperand;

            return result;
        }
    }
}