using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication2.Models
{
    public class Finance
    {


        public int FinanceId { get; set; }

        [ForeignKey("DescriptionId")]
        public ICollection<Description> Category  { get; set; }

        [ForeignKey("AmountId")]
        public ICollection<Amount> Type { get; set; }

        public int Amount { get; set; }

        internal string CreatedBy { get; set; }
    }
}