using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    //To be persisted on DB, using DAL ORM in future.
    public class TaxRate
    {
        //No default constructor: Creating a TaxRate without any of its properties seems meaningless.
        public TaxRate(StateEnum stateCode, double rate)
        {
            StateCode = stateCode;
            Rate = rate;
        }

        #region Properties
        public StateEnum StateCode { get; set; }

        public double Rate { get; set; }
        #endregion
    }
}