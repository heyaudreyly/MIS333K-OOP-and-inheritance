using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ly_Audrey_HW2.Models

{
    public class DirectOrder : Order
    {

        //constants
        //sales tax rate
        public const Decimal SALES_TAX_RATE = 0.0825M;

        ////properties
        ////customer type - direct order
        //[Display(Name = "Customer Type:")]
        public CustomerType Direct { get; set; }

        //customer name
        [Display(Name = "Customer Name:")]
        public String CustomerName { get; set; }

        //sales tax
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; set; }

        //calculated totals
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal CalculatedTotals { get; set; }


        //methods
        //calc totals
        public void CalcTotals()
        {
            CalcSubtotals();
            SalesTax = Subtotal * SALES_TAX_RATE;
            CalculatedTotals = SalesTax + Subtotal;
        }

    }
}

