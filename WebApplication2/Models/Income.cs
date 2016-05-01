using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Income
    {
        public int IncomeId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public IncomeCategory Category { get; set; }

        [Required]
        public string Desciption { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }

    public enum IncomeCategory
    {
        Bonus,
        Refund,
        Overtime,
        Liquidation
    }
}