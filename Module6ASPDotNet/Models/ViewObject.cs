using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module6ASPDotNet.Models
{
    public class ViewObject
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VendorEmail { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}