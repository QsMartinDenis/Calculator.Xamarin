using Calculator.XamarinApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel mainPageModel = new MainPageModel();
        public MainPage()
        {
            InitializeComponent();
            MainGrid.BindingContext = mainPageModel; //x:Name = MainGrid
        }

        private void Button_Clicked_AC(object sender, EventArgs e)
        {
            mainPageModel.ClearDisplay();
        }
        private void Button_Clicked_Result(object sender, EventArgs e)
        {
            if (!mainPageModel.IsResult)
            {
                mainPageModel.Result();
            }
        }
        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
            {
                mainPageModel.Delete();
            }
        }
        private void Button_Clicked_Sum(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
            {
                mainPageModel.InputOperation('+');
            }
        }
        private void Button_Clicked_Sub(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
                mainPageModel.InputOperation('-');
        }
        private void Button_Clicked_Div(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
            {
                mainPageModel.InputOperation('/');
            }
        }
        private void Button_Clicked_Mul(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
            {
                mainPageModel.InputOperation('*');
            }
        }
        private void Button_Clicked_Dot(object sender, EventArgs e) // virgula pentru android
        {
            if (!mainPageModel.IsEmpty)
                mainPageModel.InputDot(',');
        }
        private void Button_Clicked_Pow(object sender, EventArgs e)
        {
            if (!mainPageModel.IsEmpty)
                mainPageModel.InputOperation('^');
        }
        private void Button_Clicked_0(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "0";

            if (mainPageModel.IsEmpty)
            {
                mainPageModel.Display = "0";
            }
        }
        private void Button_Clicked_Display0(object sender, EventArgs e)
        {
            mainPageModel.SelectOperation(1);
        }
        private void Button_Clicked_Display1(object sender, EventArgs e)
        {
            mainPageModel.SelectOperation(2);
        }
        private void Button_Clicked_Display2(object sender, EventArgs e)
        {
            mainPageModel.SelectOperation(3);
        }
        private void Button_Clicked_Display3(object sender, EventArgs e)
        {
            mainPageModel.SelectOperation(4);
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "1";
        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "2";
        }
        private void Button_Clicked_3(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "3";
        }
        private void Button_Clicked_4(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "4";
        }
        private void Button_Clicked_5(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "5";
        }
        private void Button_Clicked_6(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "6";
        }
        private void Button_Clicked_7(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "7";
        }
        private void Button_Clicked_8(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "8";
        }
        private void Button_Clicked_9(object sender, EventArgs e)
        {
            mainPageModel.Input();
            mainPageModel.Display += "9";
        }
    }
}