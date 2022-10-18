using System;
using System.ComponentModel.DataAnnotations;

namespace Ly_Audrey_HW2.Models
{
    public class WholesaleOrder: Order
    {
        ////properties
        ////customer type -- wholesale
        public CustomerType Wholesale { get; set; }

        //cutomer code
        [Display(Name = "Customer Code:")]
        [Required(ErrorMessage = "Customer code is required!")]
        [StringLength(4)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Customer code may only contain letters.")]
        public String CustomerCode { get; set; }

        //delivery fee
        [Display(Name = "Delivery Fee:")]
        [Required(ErrorMessage = "Delivery fee is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "The field Delivery Fee must be a number.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal DeliveryFee { get; set; }

        //preferred customer
        [Display(Name = "Is this a preferred customer?")]
        public Boolean PreferredCustomer { get; set; }


        //methods
        //calculating totals
        public void CalcTotals()
        {
            CalcSubtotals();
            if (PreferredCustomer || Subtotal >= 1200)
            {
                DeliveryFee = 0m;
            }

            //calc total
            Total = Subtotal + DeliveryFee;
        }


    }

}


