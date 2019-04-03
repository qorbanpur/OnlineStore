using System.Collections.Generic;

namespace ConsoleApp
{
    static class Helper
    {
        #region Properties
        //This type of data structure has a very good performance, and easy applicability.
        public static Dictionary<StateEnum, double> TaxRates = new Dictionary<StateEnum, double>(); 
        #endregion

        static Helper()
        {
            PopulateTaxRates();
        }

        /// <summary>
        /// Typically from DB/Config File/Resources/etc...
        /// </summary>
        static void PopulateTaxRates()
        {
            TaxRates.Add(StateEnum.AL, 0.04);
            TaxRates.Add(StateEnum.CA, 0.0825);
            TaxRates.Add(StateEnum.NV, 0.08);
            TaxRates.Add(StateEnum.TX, 0.0625);
            TaxRates.Add(StateEnum.UT, 0.0685);
        }
    }
}