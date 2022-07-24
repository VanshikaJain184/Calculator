using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class PercentOperation : BinaryOperations
    {
        public double Calculate(double firstOperand,double secondOperand)
        {
            double result;

            //Percentage calculation Logic
            result = (secondOperand / firstOperand) * 100;

            return result;
        }
    }
}