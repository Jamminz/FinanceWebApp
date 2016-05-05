using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Expenditure
    {
        public int ExpenditureId { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public ExpendCategory Category { get; set; }

        [Required]
        public string Desciption { get; set; }

        [HiddenInput]
        public string CreatedBy { get; set; }
    }

    public enum ExpendCategory
    {
        Entertainment,
        Education,
        Food,
        Health,
        Utility
    }
}