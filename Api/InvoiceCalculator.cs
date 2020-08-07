using System;
using System.ComponentModel;

namespace MatkaLasku
{
    public class InvoiceCalculator
    {
        public decimal CompensationPerKM
        {
            get
            {
                if (PassengerCount > 0)
                {
                    decimal compensation = 0.43m + (PassengerCount * 0.03m); 
                    return decimal.Round(compensation, 2, MidpointRounding.AwayFromZero);
                }
                return decimal.Round(0.43m, 2, MidpointRounding.AwayFromZero);
            }
            private set {}
        }

        public decimal FullDayBenefit
        {
            get
            {
                if (KM > 15 && Hours > 10)
                {
                    return 43;
                }
                return 0;
            }
            private set {}
        }

        public decimal PartDayBenefit
        {
            get
            {
                if (Math.Floor(Hours / 24) > 0)
                {
                    if (Hours % 24 > 6)
                    {
                        return 43;
                    }

                    if (Hours % 24 >= 2)
                    {
                        return 20;
                    }
                }

                return Hours % 24 > 6 ? 20 : 0;
            }
            private set {}
        }

        public double Hours
        {
            get { return RecurrenceTime.Subtract(Departure).TotalHours; }
            private set {}
        }

        private int PassengerCount { get; set; }
        private int KM { get; set; }
        private DateTime Departure { get; set; }
        private DateTime RecurrenceTime { get; set; }

        public InvoiceCalculator(int PassengerCount, int KM, DateTime Departure, DateTime RecurrenceTime)
        {
            this.PassengerCount = PassengerCount;
            this.KM = KM;
            this.Departure = Departure;
            this.RecurrenceTime = RecurrenceTime;
        }

        public decimal CalculateKMAllowance()
        {
            return KM * CompensationPerKM;
        }

        public decimal CalculateTotalFullDaysBenefit()
        {
            return FullDayBenefit * decimal.Floor(Convert.ToDecimal(Hours) / 24m);
        }

        public decimal CalculateTotalDayBenefit()
        {
            return CalculateTotalFullDaysBenefit() + PartDayBenefit;
        }

        public decimal CalculateTotal()
        {
            return CalculateTotalDayBenefit() + CalculateKMAllowance();
        }
    }
}