using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public interface UnaryOperations
    {
      //classes implementing it will take 1 parameter/argument as input
        double Calculate(double firstOperand);

    }
}