﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}