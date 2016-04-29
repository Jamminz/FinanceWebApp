using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Expenditure
    {
        public int ExpenditureId { get; set; }
        public int Amount { get; set; }
        public string Desciption { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }
}