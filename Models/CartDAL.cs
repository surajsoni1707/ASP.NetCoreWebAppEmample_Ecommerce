using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCoreWebAppEmample.Models
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        List<Product> plist = new List<Product>();
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }
        public List<Cart> GetCartProduct(String uid)
        {
            List<Cart> cl = new List<Cart>();
            
            string str = "select * from CartTable where uid=@uid";
            
            
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@uid", uid);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cart c = new Cart();
                    c.Cid= Convert.ToInt32(dr["Cid"]);
                    c.Pid = Convert.ToInt32(dr["Pid"]);
                    c.Quantity = Convert.ToInt32(dr["Quantity"]);
                    cl.Add(c);

                }
                con.Close();
                return cl;
            }
            else
            {
                con.Close();
                return cl;

            }

        }




    }
}
