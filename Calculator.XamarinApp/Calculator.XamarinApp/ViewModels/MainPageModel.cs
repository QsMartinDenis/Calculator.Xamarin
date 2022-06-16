using Calculator.XamarinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator.XamarinApp.ViewModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        private readonly DataStore Local = new DataStore();

        public bool IsEmpty = true;
        public bool IsResult = true;

        private string _display = "";
        private string _display0 = "";
        private string _display1 = "";
        private string _display2 = "";
        private string _display3 = "";
        public string Display
        {
            get => _display;

            set
            {
                _display = value;
                RaisePropertyChanged(nameof(Display));
            }
        }
        public string Display0
        {
            get => _display0;

            set
            {
                _display0 = value;
                RaisePropertyChanged(nameof(Display0));
            }
        }
        public string Display1
        {
            get => _display1;

            set
            {
                _display1 = value;
                RaisePropertyChanged(nameof(Display1));
            }
        }
        public string Display2
        {
            get => _display2;
            set
            {
                _display2 = value;
                RaisePropertyChanged(nameof(Display2));
            }
        }
        public string Display3
        {
            get => _display3;
            set
            {
                _display3 = value;
                RaisePropertyChanged(nameof(Display3));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Input()
        {
            if (IsEmpty)
            {
                Display = "";
            }

            IsEmpty = false;
            IsResult = false;
        }
        public void InputOperation(char c)
        {
            IsEmpty = false;
            char[] temp = Display.ToCharArray();

            if (!(temp[temp.Length - 1] == c))
            {
                if (char.IsDigit(temp[temp.Length - 1]))
                {
                    Display += char.ToString(c);
                }
                else
                {
                    temp[temp.Length - 1] = c;
                    Display = new string(temp);
                }
            }
        }
        public void InputDot(char c)
        {
            IsEmpty = false;

            char[] temp = Display.ToCharArray();
            List<char> test = new List<char>();
            char[] simbol = { '+', '-', '*', '/', '^' };
            bool flag = false;
            bool flag2 = true;

            if (temp.Length - 1 == 1 && temp[temp.Length - 1] == 0)
            {
                Display += ",";
                IsEmpty = false;
            }
            else
            {
                for (int i = temp.Length - 1; i > 0; i--)
                {
                    for (int j = 0; j < simbol.Length; j++)
                    {
                        if (temp[i] == simbol[j])
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            test.Add(temp[i]);
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }

                for (int i = 0; i < test.Count; i++)
                {
                    if (test[i] == c)
                    {
                        flag2 = false;
                        break;
                    }
                }
                if (temp.Length - 1 < 0)
                {
                    //Out of range
                }
                else if (flag2 && char.IsDigit(temp[temp.Length - 1]))
                {
                    Display += c;
                }
            }
        }

        public void Result()
        {
            List<string> rpnExpression = ReversePolishNotation.InfixToPostfix(Display);
            string result = StackCalculator.CalculateRPN(rpnExpression);
            Display += $" = {result}";
            UpdateDisplay();
            IsResult = true;
            IsEmpty = true;
        }

        private void UpdateDisplay()
        {
            Local.SetValue(Display);
            List<string> store = Local.GetList();

            if (store.Count - 1 >= 0)
            {
                Display0 = store[store.Count - 1];
            }
            if (store.Count - 1 >= 1)
            {
                Display1 = store[store.Count - 2];
            }
            if (store.Count - 1 >= 2)
            {
                Display2 = store[store.Count - 3];
            }
            if (store.Count - 1 >= 3)
            {
                Display3 = store[store.Count - 4];
            }
        }

        public void SelectOperation(int index)
        {
            List<string> store = Local.GetList();

            if (store.Count - index >= 0)
            {
                char[] expression = store[store.Count - index].ToCharArray();
                int count = 1;

                for (int i = expression.Length - 1; i > 0; --i)
                {
                    if (expression[i] == '=')
                    {
                        count++;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                char[] temp = new char[expression.Length - count];
                Array.Copy(expression, temp, temp.Length);
                Display = new string(temp);
                IsEmpty = false;
                IsResult = false;
            }
        }

        public void ClearDisplay()
        {
            Display = "";
            IsEmpty = true;
        }
        public void Delete()
        {
            char[] temp = Display.ToCharArray();

            if (temp.Length - 1 > 0)
            {
                char[] tempX = new char[temp.Length - 1];
                Array.Copy(temp, tempX, tempX.Length);
                Display = new string(tempX);
            }
            else
            {
                ClearDisplay();
            }
        }
    }
}
