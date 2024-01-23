using MVVM_Calculadora_OGV.ModelView;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculadora_OGV_
{
    public class VMcalculadora : BaseViewModel
    {
        #region VARIABLES
        private string _spnFirst;
        private string _spnSecond;
        private string _spnThird;
        private string _lblNumber;

        private double numeroUno = 0, numRespuesta = 0;
        private int operador = -1;
        private bool hayPunto = false;
        #endregion
        #region CONSTRUCTOR
        public VMcalculadora(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS

        public string SpnFirst
        {
            get { return _spnFirst; }
            set { SetProperty(ref _spnFirst, value); }
        }

        public string SpnSecond
        {
            get { return _spnSecond; }
            set { SetProperty(ref _spnSecond, value); }
        }

        public string SpnThird
        {
            get { return _spnThird; }
            set { SetProperty(ref _spnThird, value); }
        }

        public string LblNumber
        {
            get { return _lblNumber; }
            set { SetProperty(ref _lblNumber, value); }
        }
        #endregion
        #region PROCESO
        private void BtnAC()
        {
            numeroUno = 0;
            numRespuesta = 0;
            hayPunto = false;
            SpnFirst = "";
            SpnSecond = "";
            SpnThird = "";
            LblNumber = "0";
        }

        private void Click_C()
        {
            string currentText = LblNumber;
            if (!string.IsNullOrEmpty(currentText))
            {
                currentText = currentText.Remove(currentText.Length - 1);
                LblNumber = currentText;
            }
        }

        private void BtnOperador(string operando)
        {
            int valor = -1;

            switch (operando)
            {
                case "+":
                    valor = 0;
                    break;
                case "-":
                    valor = 1;
                    break;
                case "*":
                    valor = 2;
                    break;
                case "÷":
                    valor = 3;
                    break;
            }

            if (operador != -1)
            {
                BtnEquals();
            }

            IgualarValores(operando, valor);
        }

        private void ClickNumber(string numero)
        {
            IngresarNumero(numero);
        }

        private void ClickPoint()
        {
            IngresarNumero(".");
        }

        private void BtnEquals()
        {
            if (!string.IsNullOrEmpty(SpnFirst) && !string.IsNullOrEmpty(SpnSecond))
            {
                SpnThird = LblNumber;

                double numeroDos = 0;
                if (double.TryParse(SpnThird, out double resultadoSpnThird))
                {
                    numeroDos = resultadoSpnThird;
                }

                switch (operador)
                {
                    case 0:
                        numRespuesta = numeroUno + numeroDos;
                        break;
                    case 1:
                        numRespuesta = numeroUno - numeroDos;
                        break;
                    case 2:
                        numRespuesta = numeroUno * numeroDos;
                        break;
                    case 3:
                        if (numeroUno == 0) { numeroDos = 1; }
                        numRespuesta = numeroUno / numeroDos;
                        break;
                }

                LblNumber = numRespuesta.ToString();
                numeroUno = numRespuesta;
                operador = -1;
                hayPunto = false;
            }
        }

        private void IngresarNumero(string numero)
        {
            if (numero == ".")
            {
                if (!hayPunto)
                {
                    LblNumber += numero;
                    hayPunto = true;
                }
            }
            else
            {
                if (LblNumber == "0" || LblNumber == "0.")
                {
                    LblNumber = numero;
                }
                else
                {
                    LblNumber += numero;
                }
            }
        }

        private void IgualarValores(string operando, int valor)
        {
            double resultadoLblNumber;
            if (double.TryParse(LblNumber, out resultadoLblNumber))
            {
                numeroUno = resultadoLblNumber;
            }
            else
            {
                numeroUno = 0;
            }

            SpnFirst = numeroUno.ToString();
            LblNumber = "0";
            SpnSecond = operando;
            operador = valor;
            hayPunto = false;
        }
        #endregion
        #region COMANDOS
        public ICommand BtnACCommand => new Command(BtnAC);
        public ICommand Click_CCommand => new Command(Click_C);
        public ICommand BtnOperadorCommand => new Command<string>(BtnOperador);
        public ICommand ClickNumberCommand => new Command<string>(ClickNumber);
        public ICommand ClickPointCommand => new Command(ClickPoint);
        public ICommand BtnEqualsCommand => new Command(BtnEquals);
        #endregion

    }
}
