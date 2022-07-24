using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class CosOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
            double result;
           /* double R;
            double S;
           

            PowerOperation power = new PowerOperation();

            R = power.Calculate(firstOperand, 2);
            S = power.Calculate(R, 2);

            // Substituting p,q in the below formula
            result = 1.0 - R / 2 + S / 24 - R * S / 720 + S * S / 40320 - R * S * S / 3628800;*/
            double b = (firstOperand * (Math.PI)) / 180;
            result =Math.Cos(b);
            return result;
        }
    }
}