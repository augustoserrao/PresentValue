/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;
using System.Globalization;
using System.Windows.Data;

namespace PresentValue.ValueConverters
{
    class SliderToFinalValue : IValueConverter
    {
        decimal maxFinalValue;

        public SliderToFinalValue()
        {
            ConfigFile file = new ConfigFile();

            maxFinalValue = file.GetMaxFinalValue();
        }
 
        // This is converting method from VM to UI.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value / maxFinalValue) * MainWindow.SLIDER_MAX_VALUE;
        }

        // This is converting method from UI to VM
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Round(System.Convert.ToDecimal((double)value) * maxFinalValue / MainWindow.SLIDER_MAX_VALUE, MainWindow.MONEY_PRECISION);
        }
    }
}
