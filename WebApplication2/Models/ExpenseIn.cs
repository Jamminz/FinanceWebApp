using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication2.Models
{
    public class ExpenseIn
    {
        public int ExpenseInId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }
}