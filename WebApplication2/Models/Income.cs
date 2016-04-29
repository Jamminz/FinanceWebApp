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
        public int Amount { get; set; }
        public string Desciption { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }
}