
using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Module6ASPDotNet.DAL
{
    public class ProductGateWay
    {
        public static List<Product1> GetProductList()
        {
            List<Product1> list = new List<Product1>();
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ProductId,ProductName,PurchaseDate,VendorEmail,ImageName, ImageUrl,p.CategoryId,Price,c.CategoryName FROM Product p join Category c on p.CategoryId=c.CategoryId";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product1 obj = new Product1();
                    obj.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    obj.ProductName = rdr["ProductName"].ToString();
                    obj.PurchaseDate = Convert.ToDateTime(rdr["PurchaseDate"].ToString());
                    obj.VendorEmail = rdr["VendorEmail"].ToString();
                    obj.ImageName = rdr["ImageName"].ToString();
                    obj.ImageUrl = rdr["ImageUrl"].ToString();
                    obj.Price = Convert.ToDecimal(rdr["Price"].ToString());
                    obj.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    obj.CategoryName = rdr["CategoryName"].ToString();
                    list.Add(obj);
                }
                return list;
            }           
        }
        public static List<ViewObject> GetProductList(string path)
        {           
            List<ViewObject> list = new List<ViewObject>();
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select ProductId,ProductName,PurchaseDate,VendorEmail,ImageName,ImageUrl,p.CategoryId,ct.CategoryName,Price from Product p ,Category ct where p.CategoryId=ct.CategoryId";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ViewObject obj = new ViewObject();
                    obj.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    obj.ProductName = rdr["ProductName"].ToString();
                    obj.PurchaseDate = Convert.ToDateTime(rdr["PurchaseDate"].ToString());
                    obj.VendorEmail = rdr["VendorEmail"].ToString();
                    obj.ImageName = rdr["ImageName"].ToString();
                    obj.ImageUrl = path+rdr["ImageUrl"].ToString();
                    obj.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    obj.CategoryName = rdr["CategoryName"].ToString();
                    obj.Price = Convert.ToDecimal(rdr["Price"]);
                    //+"AuthorizedPages/"
                    list.Add(obj);
                }
                return list;
            }
        }
        public static void SaveProduct(string ProductName, DateTime PurchaseDate,
            string VendorEmail, string ImageName, string ImageUrl, decimal Price, int CategoryId)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Product (ProductName,PurchaseDate,VendorEmail,ImageName,ImageUrl,Price,CategoryId) VALUES(@ProductName,@PurchaseDate,@VendorEmail,@ImageName,@ImageUrl,@Price,@CategoryId)";
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                cmd.Parameters.AddWithValue("@VendorEmail", VendorEmail);
                cmd.Parameters.AddWithValue("@ImageName", ImageName);
                cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateProduct(string ProductName, DateTime PurchaseDate,
            string VendorEmail, string ImageName, string ImageUrl, decimal Price, int CategoryId, int ProductId)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Product Set ProductName=@ProductName, PurchaseDate=@PurchaseDate, VendorEmail=@VendorEmail,  Price=@Price, CategoryId=@CategoryId WHERE ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                cmd.Parameters.AddWithValue("@VendorEmail", VendorEmail);
                //cmd.Parameters.AddWithValue("@ImageName", ImageName);
                //cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteProduct(int ProductId)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM  Product WHERE ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static string ImageName(int ProductId)
        {
            string imageName = "";
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ImageName FROM Product WHERE ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                imageName = cmd.ExecuteScalar().ToString();
            }
            return imageName;
        }
        public static void UpdateImageById(string ImageName, string ImageUrl, int ProductId, int CategoryId)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Product Set ImageName=@ImageName, ImageUrl=@ImageUrl, CategoryId=@CategoryId WHERE ProductId=@ProductId";
                cmd.Parameters.AddWithValue("@ImageName", ImageName);
                cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable Getcategories()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Category";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
            }
            return dt;
        }

        public static void Savecategory(string CategoryName)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Category (CategoryName) VALUES(@CategoryName)";
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}