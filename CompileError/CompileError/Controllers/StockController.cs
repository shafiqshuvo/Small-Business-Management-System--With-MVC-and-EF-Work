using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Models;
using CompileError.DatabaseContext.DatabaseContext;

namespace CompileError.Controllers
{
    //private readonly PurchasedProduct purchasedProduct = new 
    
    public class StockController : Controller
    {
        
        ProjectDbContext _projectDbContext = new ProjectDbContext();

        [HttpGet]
        public ActionResult Search()
        {
            StockViewModel stockViewModel = new StockViewModel();

            //stockViewModel.PurchaseProducts = _projectDbContext.GetALL();
            return View(stockViewModel);
        }

        [HttpPost]
        public ActionResult Search(StockViewModel stockViewModel)
        {
            return View();
        }

        //public fillComboBox(StockViewModel stockViewModel)
        //{
        ////    stockViewModel.SalesSelectListItems =
        //}
    }
}