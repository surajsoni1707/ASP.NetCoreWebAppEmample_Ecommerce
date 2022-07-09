﻿using ASP.NetCoreWebAppEmample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Controllers
{
    public class CartController : Controller
    {
        public 


        CartDAL cd = new CartDAL();
        ProductDAL pd = new ProductDAL();

        // GET: CartController
        [Authorize]
        public ActionResult Cart(int pid)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Product> plist = new List<Product>();
            int res = pd.AddToCart(pid,userId);
            if (res == 1)
            {
                

                var m = cd.GetCartProduct(1);
               foreach(var item in m)
                {
                    Product p = pd.GetProductById(item);
                    plist.Add(p);
                }
               ViewBag.Product = plist;
            }
            return View();
        }

      
       

      
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}