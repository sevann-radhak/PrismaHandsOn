﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prisma.Controllers
{
    public class AJAXConceptController : Controller
    {
        // GET: AJAX
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult JsonFactorial(int n)
        {
            // Validate if call is ajax
            if (!Request.IsAjaxRequest())
            {
                return null;
            }

            var result = new JsonResult
            {
                Data = new { Factorial = Factorial(n) }
            };

            return result;
        }

        private double Factorial(int n)
        {
            double factorial = 1;

            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}