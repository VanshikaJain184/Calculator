using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class LnOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
           // LograthmicOperation lograthmicClass = new LograthmicOperation();

            //Computing formulae ln(a)=log10(a)/log10(b)

            double result = Math.Log(firstOperand)/ Math.Log(2);

            return result;
        }
    }
}