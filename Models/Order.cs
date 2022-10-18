using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ly_Audrey_HW2.Models
{ 

    public enum CustomerType
    {
        DirectOrder,
        WholesaleOrder
    }

    public abstract class Order

    {
        //constants
        //hardback and paperback prices
        public const Decimal HARDBACK_PRICE = 17.95M;
        public const Decimal PAPERBACK_PRICE = 9.50M;

        //properties
        //customer type
        public CustomerType CustomerType { get; set; }

        //number of hardbacks
        [Display(Name = "Number of Hardback Books:")]
        [Required(ErrorMessage = "Number of hardbacks is required!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Number of hardbacks must be at least zero!")]
        public Int32 NumberOfHardbacks { get; set; }

        //number of paperbacks
        [Display(Name = "Number of Paperback Books:")]
        [Required(ErrorMessage = "Number of paperbacks is required!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Number of paperbacks must be at least zero!")]
        public Int32 NumberOfPaperbacks { get; set; }

        //hardback subtotal
        [Display(Name = "Hardback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal HardbackSubtotal { get; private set; }

        //paperback subtotal
        [Display(Name = "Paperback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal PaperbackSubtotal { get; private set; }

        //subtotal
        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get; private set; }

        //total
        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get; protected set; }

        //total items
        [Display(Name = "Total Books:")]
        public Int32 TotalItems { get; private set; }

        //methods
        //calculating subtotals
        public void CalcSubtotals()
        {
            //calc total items with zero item min
            TotalItems = NumberOfHardbacks + NumberOfPaperbacks;
            if (TotalItems == 0)
            {
                throw new Exception("You must purchase at least one item.");
            }
            //hardback subtotal
            HardbackSubtotal = NumberOfHardbacks * HARDBACK_PRICE;

            //paperback subtotal
            PaperbackSubtotal = NumberOfPaperbacks * PAPERBACK_PRICE;

            //subtotal
            Subtotal = HardbackSubtotal + PaperbackSubtotal;
        }
    }
}


