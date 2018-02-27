using System;
/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System.Globalization;
using System.Windows.Data;

namespace PresentValue.ValueConverters
{
    class SliderToInterests : IValueConverter
    {
        decimal maxInterests;

        public SliderToInterests()
        {
            ConfigFile file = new ConfigFile();

            maxInterests = file.GetMaxInterest();
        }

        // This is converting method from VM to UI
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value / maxInterests) * MainWindow.SLIDER_MAX_VALUE;
        }

        // This is converting method from UI to VM
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return decimal.Round(System.Convert.ToDecimal((double)value) * maxInterests / MainWindow.SLIDER_MAX_VALUE, MainWindow.INTERESTS_PRECISION);
        }
    }
}
