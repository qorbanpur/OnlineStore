namespace BusinessLayer
{
    //To be persisted on DB, using DAL ORM in future.
    public class Discount
    {
        //No default constructor: Creating a Discount without any of its properties seems meaningless.
        public Discount(long lowerThreshold, double discountPercentage)
        {
            LowerThreshold = lowerThreshold;
            DiscountPercentage = discountPercentage;
        }

        #region Properties
        public long LowerThreshold { get; set; }

        public double DiscountPercentage { get; set; } 
        #endregion
    }
}