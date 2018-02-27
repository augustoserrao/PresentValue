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
    class SliderToPeriod : IValueConverter
    {
        decimal maxPeriod;

        public SliderToPeriod()
        {
            ConfigFile file = new ConfigFile();

            maxPeriod = file.GetMaxPeriod();
        }

        // This is converting method from VM to UI
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value / maxPeriod) * MainWindow.SLIDER_MAX_VALUE;
        }

        // This is converting method from UI to VM
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Round(System.Convert.ToDecimal((double)value) * maxPeriod / MainWindow.SLIDER_MAX_VALUE, MainWindow.PERIOD_PRECISION);
        }
    }
}
