/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System.Windows;

namespace PresentValue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public constants also accessed by value converters
        public const int SLIDER_MAX_VALUE = 100;
        public const int MONEY_PRECISION = 2;
        public const int INTERESTS_PRECISION = 1;
        public const int PERIOD_PRECISION = 1;
        
        const int MIN_CANVAS_WIDTH = 130;
        const int MAX_CANVAS_WIDTH = 430;

        InvestmentCalculatorVM vm = new InvestmentCalculatorVM();

        // Constructor
        public MainWindow()
        {
            ConfigFile cfgFile = new ConfigFile();

            InitializeComponent();
            DataContext = vm;
            canvasPeriod.Width = MIN_CANVAS_WIDTH;
        }

        // Callback method when Initial Value slider changes
        private void Slider_Initial_Value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.UpdateFinalValue();
        }

        // Callback method when Period slider changes
        private void Slider_Period_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            canvasPeriod.Width = (sliderPeriod.Value / SLIDER_MAX_VALUE) * (MAX_CANVAS_WIDTH - MIN_CANVAS_WIDTH) + MIN_CANVAS_WIDTH;
            vm.UpdateFinalValue();
        }

        // Callback method when Interest slider changes
        private void Slider_Interest_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.UpdateFinalValue();
        }

        // Callback method when Final Value slider changes
        private void Slider_Final_Value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.UpdateInitialValue();
        }
    }
}
