using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public interface BinaryOperations
    {
        //classes implementing it will take 2 parameters/arguments as input
        double Calculate(double firstOperand,double secondOperand);

    }
}