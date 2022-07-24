using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class CsecOperation : UnaryOperations { 
        public double Calculate(double firstOperand)
        {
            double result = 0;
        //calualting sin value 
        SinOperation sinclass = new SinOperation();
            double denominator = sinclass.Calculate(firstOperand);

        //Since csec=1/sin
      
            result = 1/(denominator);

            return result;
        }
    }
}