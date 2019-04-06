using System.Linq;

namespace BusinessLayer
{
    public class Order
    {
        // No default constructor: Creating an order without any of its properties seems meaningless.
        public Order(long amount, long unitPrice, StateEnum stateCode)
        {
            Amount = amount;
            UnitPrice = unitPrice;
            StateCode = stateCode;
        }

        #region Properties
        public long Amount { get; set; }
        public long UnitPrice { get; set; }
        public StateEnum StateCode { get; set; }
        public long RawValue { get { return Amount * UnitPrice; } }
        #endregion

        public double GetTotalPrice()
        {
            var discountRate = GetDiscountPercentage();

            return (RawValue * (1 - discountRate)) * (1 + Helper.TaxRates[StateCode]);
        }

        public double GetDiscountPercentage()
        {
            //This works well because 'SortedDictionary' has been used.
            var lowerThreshold = Helper.DiscountPercentages.Keys.LastOrDefault(x => x <= RawValue);

            return lowerThreshold > 0
                ? Helper.DiscountPercentages[lowerThreshold]
                : 0;
        }
    }
}