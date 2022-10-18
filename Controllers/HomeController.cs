//Name: Audrey Ly
//Date: September 23, 2022
//Description: HW2 - Bookstore Checkout

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ly_Audrey_HW2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ly_Audrey_HW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckoutDirect()
        {
            return View();
        }

        public IActionResult DirectTotals(DirectOrder directOrder)

        {
            TryValidateModel(directOrder);
            if (ModelState.IsValid == false)
            {
                return View("CheckoutDirect", directOrder);
            }
            directOrder.CalcTotals();
            directOrder.CustomerType = CustomerType.DirectOrder;
            return View(directOrder);
        }

        public IActionResult CheckoutWholesale()
        {
            return View();
        }

        public IActionResult WholesaleTotals(WholesaleOrder wholesaleOrder)
        {
            TryValidateModel(wholesaleOrder);
            if (ModelState.IsValid == false)
            {
                return View("CheckoutWholesale", wholesaleOrder);
                
            }
            wholesaleOrder.CalcTotals();
            wholesaleOrder.CustomerType = CustomerType.WholesaleOrder;
            return View(wholesaleOrder);
        }
    }
}

