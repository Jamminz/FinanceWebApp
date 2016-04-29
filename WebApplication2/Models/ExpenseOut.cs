using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class ExpenseOut
    {
        public int ExpenseOutId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }
}