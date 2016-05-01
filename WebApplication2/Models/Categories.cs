using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication2.Models
{
    public class Categories
    {
        DropDownList _categoryDdl = new DropDownList();

        public List<string> Category = new List<string>()
        {
            "Food",
            "Utility",
            "Savings",
            "Luxury",
            "Leisure"

        };
    }
}