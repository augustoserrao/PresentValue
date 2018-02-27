/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentValue
{
    class InvestmentCalculatorVM : INotifyPropertyChanged
    {
        // Bound variables
        decimal initialValue = 0.00m;
        decimal finalValue = 0.00m;
        decimal period = 0.0m;      // in years
        decimal interest = 0.0m;    // percentage of annual interest

        public decimal InitialValue
        {
            get { return initialValue; }
            set { initialValue = value; _propertyChanged(); }
        }

        public decimal FinalValue
        {
            get { return finalValue; }
            set { finalValue = value; _propertyChanged(); }
        }

        public decimal Period
        {
            get { return period; }
            set { period = value; _propertyChanged(); }
        }

        public decimal Interest
        {
            get { return interest; }
            set { interest = value; _propertyChanged(); }
        }

        public void UpdateFinalValue()
        {
            FinalValue = Investment.CalcFutureValue(InitialValue, (float)Interest / 100, (float)Period);
        }

        public void UpdateInitialValue()
        {
            InitialValue = Investment.CalcPresentValue(FinalValue, (float)Interest / 100, (float)Period);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void _propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
