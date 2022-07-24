using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class SquareOperation : UnaryOperations
    {
        public double Calculate(double FirstOperand)
        {

            double result = 1;


            result = FirstOperand * FirstOperand;

            return result;
        }
    }
}