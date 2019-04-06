using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public static class Helper
    {
        #region Properties
        //This type of data structure has a very good performance, and easy applicability.
        public static Dictionary<StateEnum, double> TaxRates { get; private set; }

        //This type of data structure has a very good performance, and easy applicability.
        public static SortedDictionary<long, double> DiscountPercentages { get; private set; }
        #endregion

        static Helper()
        {
            PopulateTaxRates();

            PopulateDiscountPercentages();
        }

        /// <summary>
        /// To be populated from DB/Config File/Resources/etc... in future.
        /// </summary>
        static void PopulateTaxRates()
        {
            TaxRates = new Dictionary<StateEnum, double>();

            TaxRates.Add(StateEnum.AL, 0.04);
            TaxRates.Add(StateEnum.CA, 0.0825);
            TaxRates.Add(StateEnum.NV, 0.08);
            TaxRates.Add(StateEnum.TX, 0.0625);
            TaxRates.Add(StateEnum.UT, 0.0685);
        }

        /// <summary>
        /// To be populated from DB/Config File/Resources/etc... in future.
        /// </summary>
        static void PopulateDiscountPercentages()
        {
            DiscountPercentages = new SortedDictionary<long, double>();

            DiscountPercentages.Add(1000, 0.03);
            DiscountPercentages.Add(5000, 0.05);
            DiscountPercentages.Add(7000, 0.07);
            DiscountPercentages.Add(10000, 0.1);
            DiscountPercentages.Add(50000, 0.15);
        }
    }
}