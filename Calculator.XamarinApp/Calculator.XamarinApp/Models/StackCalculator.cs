using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XamarinApp.Models
{
    public static class StackCalculator
    {
        public static string CalculateRPN(List<string> rpnTokens)
        {
            Stack<decimal> stack = new Stack<decimal>();
            decimal number;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "^":
                        case "pow":
                            {
                                number = stack.Pop();
                                stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)number));
                                break;
                            }
                        case "ln":
                            {
                                stack.Push((decimal)Math.Log((double)stack.Pop(), Math.E));
                                break;
                            }
                        case "sqrt":
                            {
                                stack.Push((decimal)Math.Sqrt((double)stack.Pop()));
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();

                                if (number == 0)
                                {
                                    return "exception";
                                }
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            return stack.Pop().ToString("0.###"); // precizie 2 cifre dupa virgula a treia este rotungita.;
        }
    }
}
