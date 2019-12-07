using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompileError.Model.Model;
using System.Web.Mvc;

namespace CompileError.Models
{
    public class StockViewModel
    {
        public int Id { set; get; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string ReorderLevel { get; set; }
        public string ExpiredDate { get; set; }
        public string ExpiredQuantity { get; set; }
        public string OpeningBalance { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string IN { get; set; }
        public string Out { get; set; }
        public string ClosingBalance { get; set; }

        

        public List<PurchasedProduct> PurchaseProducts { get; set; }
        public List<SelectListItem> PurchaseSelectListItems { get; set; }


        //public List<SalesProduct> SalesProducts { get; set; }
        public List<SelectListItem> SalesSelectListItems { get; set; }
        
    }
}