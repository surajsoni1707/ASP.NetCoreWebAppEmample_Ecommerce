using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Models
{
    public class ProductDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        List<Product> plist = new List<Product>();
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string str = "select * from ProductTable";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(dr["pid"]);
                    p.Pname = dr["pName"].ToString();
                    p.Price = Convert.ToSingle(dr["price"]);
                    p.Company = dr["company"].ToString();
                    p.Description = dr["Description"].ToString();
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }
        public Product GetProductById(int id)
        {
            List<Product> pl = new List<Product>();
            Product p = new Product();
            string str = "select * from ProductTable where pid=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.ProductId = Convert.ToInt32(dr["pid"]);
                    p.Pname = dr["pName"].ToString();
                    p.Price = Convert.ToSingle(dr["Price"]);
                    p.Company = dr["company"].ToString();
                    p.Description = dr["Description"].ToString();
                    

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;

            }

        }

        


       public int AddToCart(int pid,string ui,int qty)
        {
            string str = "insert into CartTable values(@pid,@uid,@Quantity)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@uid", ui);
            cmd.Parameters.AddWithValue("@Quantity", qty);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }







        public int Save(Product prod)
        {
            string str = "insert into ProductTable values(@pName,@price,@Company,@Description)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("pName", prod.Pname);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@Company", prod.Company);
            cmd.Parameters.AddWithValue("@Description", prod.Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

        public int update(Product prod)
        {
            string str = "update ProductTable set pName=@pName,price=@price,company=@company,Description=@Description where pid=@pid";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@pid", prod.ProductId);
            cmd.Parameters.AddWithValue("@pName", prod.Pname);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@company", prod.Company);
            cmd.Parameters.AddWithValue("@Description", prod.Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

        public int Delete(int id)
        {
            string str = "delete from ProductTable where pid=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }
}
