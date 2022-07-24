using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class SinOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            firstOperand = (firstOperand * (Math.PI)) / 180;
            //Calculating Sin Value
              double sin = firstOperand, term, numerator = firstOperand, denominator = 1, xsquare = firstOperand * firstOperand, factorial = 1, sign = -1;
              do
              {
                  numerator *= xsquare;
                  denominator = denominator * (factorial + 1) * (factorial + 2);
                  factorial = factorial + 2;
                  term = numerator / denominator;
                  sin = sin + (sign * term);
                  sign *= -1;
              } while (term > 0.00001);

           // double sin=Math.Sin(b);
            return sin;
        }
    }
}