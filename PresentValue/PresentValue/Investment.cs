/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;

namespace PresentValue
{
    class Investment
    {
        public static decimal CalcPresentValue(decimal futureVal, float annualInterest, float numYears)
        {
            return futureVal / (decimal)Math.Pow(1 + annualInterest, numYears);
        }

        public static decimal CalcFutureValue(decimal initialVal, float annualInterest, float numYears)
        {
            return initialVal * (decimal)Math.Pow(1 + annualInterest, numYears);
        }
    }
}
