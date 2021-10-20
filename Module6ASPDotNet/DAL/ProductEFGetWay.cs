using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module6ASPDotNet.DAL
{
    public class ProductEFGetWay
    {
        MyDBEntities db = new MyDBEntities();
        public IQueryable<Product> GetProductList()
        {
            return from prt in db.Products select prt;
        }
        public Product GetProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }
        public void InserProduct(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
        }

        public int UpdateProduct(Product UpObj)
        {
            int count = 0;
            Product obj = GetProduct(UpObj.ProductId);
            obj.ProductName = UpObj.ProductName;
            obj.PurchaseDate = UpObj.PurchaseDate;
            obj.VendorEmail = UpObj.VendorEmail;
            obj.ImageName = UpObj.ImageName;
            obj.ImageName = UpObj.ImageUrl;
            obj.CategoryId = UpObj.CategoryId;
            obj.Price = UpObj.Price;
            count = db.SaveChanges();
            return count;
        }
        public int DeleteProduct(int id)
        {
            int count = 0;
            Product delProduct = GetProduct(id);
            db.Products.Remove(delProduct);
            count = db.SaveChanges();
            return count;
        }
    }
}