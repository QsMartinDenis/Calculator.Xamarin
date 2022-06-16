using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XamarinApp.Models
{
    public static class ReversePolishNotation
    {
        private static List<string> ConvertDisplayToExpression(string display)
        {
            List<string> result = new List<string>();
            char[] temp = DeleteLastElement(display).ToCharArray();
            string word = "";
            int i = 0;

            if (!char.IsDigit(temp[0]))   // daca expresia se incepe cu -2
            {
                i = 1;
                word += temp[0];
            }

            for (; i < temp.Length; i++)
            {
                if (char.IsDigit(temp[i]) || temp[i] == ',')
                {
                    word += temp[i];
                }
                if (!char.IsDigit(temp[i]) && temp[i] != ',')
                {
                    if (word != "")
                    {
                        result.Add(word);
                    }
                    result.Add((temp[i].ToString()));
                    word = "";
                }
                if (i == temp.Length - 1 && word != "")
                {
                    result.Add(word);
                }
            }
            return result;
        }
        private static int Prec(string ch)
        {
            switch (ch)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }

        public static List<string> InfixToPostfix(string display)
        {
            List<string> tokens = ConvertDisplayToExpression(display); //Convert expression to tokens
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < tokens.Count; ++i)
            {
                string c = tokens[i];

                if (double.TryParse(c, out _))
                {
                    result.Add(c);
                }

                else if (c == "(")
                {
                    stack.Push(c);
                }

                else if (c == ")")
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                    }

                    if (stack.Count > 0 && stack.Peek() != ")")
                    {
                        //return "Invalid Expression"; 
                    }
                    else
                    {
                        result.Add(stack.Pop());
                    }
                }
                else
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(c);
                }

            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }

        private static string DeleteLastElement(string Display)
        {
            char[] tempDisplay = Display.ToCharArray();

            if (char.IsDigit(tempDisplay[tempDisplay.Length - 1]))
            {
                return Display;
            }
            else
            {
                char[] result = new char[tempDisplay.Length - 1];
                Array.Copy(tempDisplay, result, result.Length);
                string x = new string(result);
                return x;
            }
        }
    }
}
