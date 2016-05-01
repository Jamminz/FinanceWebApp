using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
        public IncomeCategory Category { get; set; }
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