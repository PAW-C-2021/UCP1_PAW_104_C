using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


using UCP_Praktikum.Models;

namespace UCP_Praktikum.Models
{  
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GTRP6JSV;Initial Catalog=TugasAkhir;Integrated Security=True");

        public int LoginCheck(Ad_login ad)
        {
            SqlCommand cmd = new SqlCommand("Sp_Login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Admin_id", ad.Admin_id);
            cmd.Parameters.AddWithValue("@Password", ad.Ad_Password);
            SqlParameter obLogin = new SqlParameter();
            obLogin.ParameterName = "@IsValid";
            obLogin.SqlDbType = System.Data.SqlDbType.Bit;
            obLogin.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(obLogin);         

            con.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(obLogin.Value);
            con.Close();

            return res;
        }
    }
}
