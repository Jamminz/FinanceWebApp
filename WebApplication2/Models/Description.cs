using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Description
    {
        public int DescriptionId { get; set; }
        public string Category { get; set; }

        public Finance Finance { get; set; }
    }
}