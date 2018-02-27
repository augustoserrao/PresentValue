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
    // Class used to convert the value of the slider into the decimal initial value in the VM
    class SliderToInitialValue : IValueConverter
    {
        decimal maxInitialValue;

        public SliderToInitialValue()
        {
            ConfigFile file = new ConfigFile();

            maxInitialValue = file.GetMaxInitialValue();
        }

        // This is converting method from VM to UI
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal) value / maxInitialValue) * MainWindow.SLIDER_MAX_VALUE;
        }

        // This is converting method from UI to VM
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Round(System.Convert.ToDecimal((double)value) * maxInitialValue / MainWindow.SLIDER_MAX_VALUE, MainWindow.MONEY_PRECISION);
        }
    }
}
