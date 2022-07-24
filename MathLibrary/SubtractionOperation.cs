using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class SubtractionOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result;

            //Division Logic
            result = secondOperand - firstOperand;

            return result;
        }
    }
}