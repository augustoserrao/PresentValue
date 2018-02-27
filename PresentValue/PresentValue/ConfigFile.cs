/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;
using System.IO;

namespace PresentValue
{
    // Class used to access configuration file which contains maximum value of Initial Value, Final Value, Interest, and Period, for the sliders
    class ConfigFile
    {
        public const decimal MAX_INITIAL_VALUE = 10000m;
        public const decimal MAX_FINAL_VALUE = 100000m;
        public const decimal MAX_INTERESTS = 50m;
        public const decimal MAX_PERIOD = 10m;

        const string FILES_SUBFOLDER = "InvestmentCalculator";
        const string FILE_NAME = "init.cfg";

        // Constructor
        public ConfigFile()
        {
            // Build directory path and create a new one if it doesn't exist
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, FILES_SUBFOLDER);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Build file path and create a new one with default values if it doesn't exist, or just read it
            path = Path.Combine(path, FILE_NAME);
            if (!File.Exists(path))
            {
                File.AppendAllText(path, $"{MAX_INITIAL_VALUE};{MAX_FINAL_VALUE};{MAX_PERIOD};{MAX_INTERESTS}\n");
            }
        }

        public decimal GetMaxInitialValue()
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILES_SUBFOLDER), FILE_NAME);

            string[] strList = File.ReadAllText(path).Split(';');

            return Decimal.Parse(strList[0]);
        }

        public decimal GetMaxFinalValue()
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILES_SUBFOLDER), FILE_NAME);

            string[] strList = File.ReadAllText(path).Split(';');

            return Decimal.Parse(strList[1]);
        }

        public decimal GetMaxInterest()
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILES_SUBFOLDER), FILE_NAME);

            string[] strList = File.ReadAllText(path).Split(';');

            return Decimal.Parse(strList[3]);
        }

        public decimal GetMaxPeriod()
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILES_SUBFOLDER), FILE_NAME);

            string[] strList = File.ReadAllText(path).Split(';');

            return Decimal.Parse(strList[2]);
        }
    }
}
