using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Amount
    {
        public int AmountId { get; set; }
        public string InOrOut { get; set; }

        public Finance Finance { get; set; }

    }
}