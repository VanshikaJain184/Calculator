using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class ModulousOperation : BinaryOperations
    {
        public double Calculate(double firstOperand, double secondOperand)
        {
            double result = 0;

            //Modulous
            result = secondOperand % firstOperand;

            return result;
        }
    }
}