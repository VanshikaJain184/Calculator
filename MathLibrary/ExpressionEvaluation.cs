using System;
using System.Collections.Generic;
namespace MathLibrary
{
	public class Evaluate 
	{
		static Stack<double> stack = new Stack<double>();
		internal static int Prec(string ch)
		{
			Dictionary<string, int> precedenceDictionary = new Dictionary<string, int>();
			try
			{
				precedenceDictionary.Add("+", 2);
				precedenceDictionary.Add("-", 2);
				precedenceDictionary.Add("*", 3);
				precedenceDictionary.Add("/", 3);
				precedenceDictionary.Add("^", 4);
				precedenceDictionary.Add("p", 4);
				precedenceDictionary.Add("s", 5);
				precedenceDictionary.Add("c", 5);
				precedenceDictionary.Add("t", 5);
				precedenceDictionary.Add("T", 5);
				precedenceDictionary.Add("C", 5);
				precedenceDictionary.Add("S", 5);
				precedenceDictionary.Add("l", 5);
				precedenceDictionary.Add("E", 5);
				precedenceDictionary.Add("m", 5);
				precedenceDictionary.Add("r", 5);
				precedenceDictionary.Add("x", 3);
				precedenceDictionary.Add("$", 3);

			}
			catch(Exception e)
            {
				Console.WriteLine("Invalid Input");
            }
			return precedenceDictionary[ch];
		}
		public static double execute(string key)
		{
			Dictionary<string, BinaryOperations> binaryDictionary = new Dictionary<string, BinaryOperations>();
			Dictionary<string, UnaryOperations> unaryDictionary = new Dictionary<string, UnaryOperations>();

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

			BinaryOperations modulous = new ModulousOperation();
			binaryDictionary.Add("m", modulous);


			//creating Dictionary for unaryInterface
			UnaryOperations squareRoot = new SquareRootOperation();
			unaryDictionary.Add("r", squareRoot);

			UnaryOperations plusMinus = new PlusMinusOperation();
			unaryDictionary.Add("+/-", plusMinus);

			UnaryOperations lograthmic = new LograthmicOperation();
			unaryDictionary.Add("l", lograthmic);

			UnaryOperations lnBase = new LnOperation();
			unaryDictionary.Add("L", lnBase);

			UnaryOperations exponential = new ExponentialOperation();
			unaryDictionary.Add("E", exponential);

			UnaryOperations tenPoWX = new TenPowXOperation();
			unaryDictionary.Add("p", tenPoWX);

			UnaryOperations sin = new SinOperation();
			unaryDictionary.Add("s", sin);

			UnaryOperations cos = new CosOperation();
			unaryDictionary.Add("c", cos);

			UnaryOperations tan = new TanOperation();
			unaryDictionary.Add("t", tan);

			UnaryOperations cot = new CotOperation();
			unaryDictionary.Add("T", cot);

			UnaryOperations sec = new SecOperation();
			unaryDictionary.Add("S", sec);

			UnaryOperations csec = new CsecOperation();
			unaryDictionary.Add("C", csec);

			UnaryOperations absolute = new AbsoluteOperation();
			unaryDictionary.Add("a", absolute);

			UnaryOperations square = new SquareOperation();
			unaryDictionary.Add("$", square);

			UnaryOperations reciprocal = new ReciprocalOperation();
			unaryDictionary.Add("x", reciprocal);

			

			double result = 0;
			if (binaryDictionary.ContainsKey(key))
			{
				double operand1 = stack.Pop();
				double operand2 = stack.Pop();
				result = binaryDictionary[key].Calculate(operand1, operand2);

			}
			else if (unaryDictionary.ContainsKey(key))
			{
				double operand1 = stack.Pop();
				result = unaryDictionary[key].Calculate(operand1);
				
			}
			return result;
		}

		// The main method that converts given infix expression
		// to postfix expression.
		public static string infixToPostfix(string exp)
		{
			// initializing empty String for result
			string result = "";
			int count = 0;

			Stack<char> mstack = new Stack<char>();

			for (int i = 0; i < exp.Length; ++i)
			{
				char c = exp[i];
				if (char.IsNumber(c) || c == '.')
				{
					if (c == '.')
					{
						continue;
					}
					count = 0;
					result += c;

					if (i < exp.Length - 1 && exp[i + 1] == '.')
					{
						result += ".";
						continue;
					}


					if (i < exp.Length - 1 && !(char.IsNumber(exp[i + 1])) && count == 0)
					{
						count = 1;
						result += " ";
					}
					if (i == exp.Length - 1)
					{
						result += " ";
					}
				}
				// If the scanned character is an '(',
				// push it to the stack.
				else if (c == '(')
				{
					mstack.Push(c);
				}

				// If the scanned character is an ')',
				// pop and output from the stack
				// until an '(' is encountered.
				else if (c == ')')
				{
					while (mstack.Count > 0 &&
							mstack.Peek() != '(')
					{
						result += mstack.Pop();
						result += " ";
					}

					if (mstack.Count > 0 && mstack.Peek() != '(')
					{
						return "Invalid Expression"; // invalid expression
					}
					else
					{
						mstack.Pop();

					}
				}

				else // an operator is encountered
				{
					while (mstack.Count > 0 && (Evaluate.Prec(Char.ToString(c)) <= Evaluate.Prec(Char.ToString(mstack.Peek()))))
					{
						result += mstack.Pop();
						result += " ";
					}
					mstack.Push(c);
				}

			}


			while (mstack.Count > 0)
			{
				result += mstack.Pop();
				result += " ";
			}

			return result;
		}

		public static string traversal(string exp)
		{

			string nexp = "";
			for (int i = 0; i < exp.Length; i++)
			{
				int increment = 1;
				string x = "";
				if (Char.IsLetter(exp[i]))
				{
					string expressi = Char.ToString(exp[i]);

					
						while (exp[i + 1] != '(')
						{
						i++;
						expressi += exp[i];
						increment++;
					}
					Dictionary<string, string> Symbol = new Dictionary<string, string>();
					Symbol.Add("sin", "s");
					Symbol.Add("cos", "c");
					Symbol.Add("tan", "t");
					Symbol.Add("x^2", "$");
					Symbol.Add("log", "l");
					Symbol.Add("ln", "L");
					Symbol.Add("exp", "E");
                    Symbol.Add("cot", "T");
					Symbol.Add("sec", "S");
					Symbol.Add("cosec", "C");
					Symbol.Add("mod", "m");
					Symbol.Add("10^", "p");
					Symbol.Add("root", "r");
					Symbol.Add("1/", "x");
					

					x = Symbol[expressi];
				
					nexp += x;
				}
				else
					nexp += exp[i];
			}
			return nexp;
		}
		public static double evaluatePostfix(string exp)
		{
			//OperatorDictionary.execute();
			// create a stack
			exp = traversal(exp);
			exp = infixToPostfix(exp);
		//	Stack<double> stack = new Stack<double>();

			// Scan all characters one by one
			for (int i = 0; i < exp.Length; i++)
			{
				char c = exp[i];

				if (c == ' ')
				{
					continue;
				}

				// If the scanned character is an
				// operand (number here),extract
				// the number. Push it to the stack.
				else if (char.IsDigit(c)||c=='.')
				{
					int n = 0;

					// extract the characters and
					// store it in num
					while (char.IsDigit(c)||c=='.')
					{
						n = n * 10 + (int)(c - '0');
						i++;
						c = exp[i];
						if(c == '.')
                        {
							n += '.';
							i++;
							c=exp[i];
                        }
					}
					i--;

					stack.Push(n);
				}
				else
				{
					double ans = execute(c.ToString());
					stack.Push(ans);
				
				}
			}
			double FinalValue= stack.Pop();
			stack.Clear();
			return FinalValue;
		}

	}
}
