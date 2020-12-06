using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AreULub.Models
{
    public class TaxModel
    {
        [Required(ErrorMessage = "Please enter a total bill amount.")]
        [Range(1, 10000, ErrorMessage = "Total bill amount must be between 1 and 10000.")]
        public decimal? TotalBill { get; set; }

        [Required(ErrorMessage = "Please enter a tax percentage rate.")]
        [Range(0.1, 20.0, ErrorMessage = "tax percentage rate must be between 0.1 and 20.0.")]
        public decimal? StatePercentageTax { get; set; }

        public decimal Calculate()
        {            
           decimal totalWithTax = TotalBill.Value + (TotalBill.Value * (StatePercentageTax.Value / 100));          
            return totalWithTax;
        }
    }
}
