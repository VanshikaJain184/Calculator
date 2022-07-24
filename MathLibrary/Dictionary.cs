using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class OperatorDictionary
    {
        public const double PI = 3.1415926535897931;
        public const double E = 2.7182818284590451;

        static public Dictionary<string, BinaryOperations> binaryDictionary = new Dictionary<string, BinaryOperations>();
        static public Dictionary<string, UnaryOperations> unaryDictionary = new Dictionary<string, UnaryOperations>();


     /*   public static void execute()
      
        {
          //  Dictionary<string, BinaryOperations> binaryDictionary = new Dictionary<string, BinaryOperations>();
           // Dictionary<string, UnaryOperations> unaryDictionary = new Dictionary<string, UnaryOperations>();

            //creating Dictionary for BinaryInterface

            BinaryOperations addition = new AdditionOperation();
            binaryDictionary.Add("+", addition);

            BinaryOperations subtraction = new SubtractionOperation();
            binaryDictionary.Add("-", subtraction);

            BinaryOperations multiplication = new MultiplicationOperation();
            binaryDictionary.Add("*", multiplication);

            BinaryOperations division = new DivisionOperation();
            binaryDictionary.Add("/", division);

            BinaryOperations percent = new PercentOperation();
            binaryDictionary.Add("%", percent);

            BinaryOperations power = new PowerOperation();
            binaryDictionary.Add("^", power);

            BinaryOperations exponential = new ExponentialOperation();
            binaryDictionary.Add("exp", exponential);

            BinaryOperations modulous = new ModulousOperation();
            binaryDictionary.Add("mod", modulous);


            //creating Dictionary for unaryInterface
            UnaryOperations squareRoot = new SquareRootOperation();
            unaryDictionary.Add("sqrt", squareRoot);

            UnaryOperations plusMinus = new PlusMinusOperation();
            unaryDictionary.Add("+/-", plusMinus);

            UnaryOperations lograthmic = new LograthmicOperation();
            unaryDictionary.Add("log", lograthmic);

            UnaryOperations lnBase = new LnOperation();
            unaryDictionary.Add("ln", lnBase);


            UnaryOperations tenPoWX = new TenPowXOperation();
            unaryDictionary.Add("10^x", tenPoWX);

            UnaryOperations sin = new SinOperation();
            unaryDictionary.Add("s", sin);

            UnaryOperations cos = new CosOperation();
            unaryDictionary.Add("cos", cos);

            UnaryOperations tan = new TanOperation();
            unaryDictionary.Add("tan", tan);

            UnaryOperations cot = new CosOperation();
            unaryDictionary.Add("cot", cot);

            UnaryOperations sec = new SecOperation();
            unaryDictionary.Add("sec", sec);

            UnaryOperations csec = new CsecOperation();
            unaryDictionary.Add("csec", csec);

            UnaryOperations absolute = new AbsoluteOperation();
            unaryDictionary.Add("absolute", absolute);

            UnaryOperations square = new SquareOperation();
            unaryDictionary.Add("square", square);
       }*/
      

    }
}
