using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class ReciprocalOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            //Calling division class to divide
          //  DivisionOperation arithmetic = new DivisionOperation();
            double result = 1/ firstOperand;

            return result;
        }
    }
}