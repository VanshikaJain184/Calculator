using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
  
    public class CotOperation : UnaryOperations { 
        public double Calculate(double firstOperand)
        {
            double result = 0;

            //Tan calculation formula tan=sin/cos

            SinOperation sinclass = new SinOperation();
            double numerator = sinclass.Calculate(firstOperand);

            CosOperation cosclass = new CosOperation();
            double denominator = cosclass.Calculate(firstOperand);

            result = denominator/ numerator;

            
            return result;
        }
    }
}