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
        public List<int> GetCartProduct(int uid)
        {
            List<int> cl = new List<int>();
            Cart c = new Cart();
            string str = "select * from CartTable where uid=@uid";
            
            
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@uid", uid);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    c.Pid = Convert.ToInt32(dr["Pid"]);
                    cl.Add(c.Pid);

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
