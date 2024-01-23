using Calculadora_OGV_;
using MVVM_Calculadora_OGV.ModelView;
using MVVM_Calculadora_OGV.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM_Calculadora_OGV.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculadora : ContentPage
    {
        public Calculadora()
        {
            InitializeComponent();
            BindingContext = new VMcalculadora(Navigation);
        }
    }
}