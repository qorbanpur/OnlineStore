namespace ConsoleApp
{
    class Order
    {
        #region Properties
        public long Amount { get; set; }
        public long UnitPrice { get; set; }
        public StateEnum StateCode { get; set; }

        public long RawValue { get { return Amount * UnitPrice; } }
        #endregion

        /// <summary>
        /// No default constructor: Creating an order witout any of its properties seems meaningless.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="unitPrice"></param>
        /// <param name="stateCode"></param>
        public Order(long amount, long unitPrice, StateEnum stateCode)
        {
            Amount = amount;
            UnitPrice = unitPrice;
            StateCode = stateCode;
        }

        /// <summary>
        /// I decided not to use a local variable. Besides that, I prefered performance to readability in here.
        /// </summary>
        /// <returns>Discount Rate</returns>
        public double GetDiscountRate()
        {
            var orderValue = RawValue;

            if (orderValue < 1000)
                return 0;
            else if (orderValue < 5000)
                return 0.03;
            else if (orderValue < 7000)
                return 0.05;
            else if (orderValue < 10000)
                return 0.07;
            else if (orderValue < 50000)
                return 0.1;
            else
                return 0.15;
        }

        public double GetTotalPrice()
        {
            var discountRate = GetDiscountRate();

            return (RawValue * (1 - discountRate)) * (1 + Helper.TaxRates[StateCode]);
        }
    }
}
