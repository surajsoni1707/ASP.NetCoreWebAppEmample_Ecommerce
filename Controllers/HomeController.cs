﻿using ASP.NetCoreWebAppEmample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Controllers
{
    
    public class HomeController : Controller
    {
        
        ProductDAL pd = new ProductDAL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            //HttpContext.Session.SetString("aaa", "pro");

            var model = pd.GetAllProducts();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Index(int pid)
        {
            
            int res=pd.AddToCart(pid);
            if(res==1)
            {
                return RedirectToAction("Cart","Cart",1);
            }

            return View();
;        }




       






        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
