using System;
using System.Threading;

namespace Caching
{
    public class BlueBookService : IBlueBookService
    {
        private int baselineValue = 30000;
        private int yearDiscount = 1000;
        private const int _msToSleep = 5000;

        [Cache]
        public decimal GetCarValue(int year, CarMakeAndModel carType)
        {
            // simulate web service time
            Thread.Sleep(_msToSleep);

            int yearsOld = Math.Abs(DateTime.Now.Year - year);
            int randomAmount = (new Random()).Next(0, 1000);
            int calculatedValue = baselineValue - (yearDiscount*yearsOld) + randomAmount;
            return calculatedValue;
        }
    }
}