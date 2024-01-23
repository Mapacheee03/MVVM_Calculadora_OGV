using MVVM_Calculadora_OGV.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM_Calculadora_OGV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calculadora();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
