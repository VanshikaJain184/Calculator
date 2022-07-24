using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class ExponentialOperation : UnaryOperations
    {
        public double Calculate(double firstOperand)
        {
           /* PowerOperation powerClass =new PowerOperation();
            LograthmicOperation lograthmicClass =new LograthmicOperation();
            
            //exp is the inverse of log
            double logValue = lograthmicClass.Calculate(firstOperand);
            double result = powerClass.Calculate(baseOperand,logValue);*/
            double result = Math.Exp(firstOperand);
            return result;
        }
    }
}