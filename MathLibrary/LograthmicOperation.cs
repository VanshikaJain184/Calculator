using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class LograthmicOperation : UnaryOperations
    {

   
        public double Calculate(double firstOperand)
        {
           //double result= Log2n(firstOperand);
           
            //Log calculation logic 
            /*   double result = 0;
               int log = 31;
               int firstOperandInInt = Convert.ToInt32(firstOperand);
               while (log >= 0)
               {
                   uint mask = ((uint)(1 << log));
                   if ((mask & firstOperandInInt) == 0)
                       log--;
                   else
                       return (uint)log;
               }*/
            double result=Math.Log10(firstOperand);
            return result;
        }
    }
}