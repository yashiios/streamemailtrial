using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmailService
{
    class Database
    {
        //SqlConnection con = null;
        public string getallemails()
        {
            //con = new SqlConnection("server=CYG152; database=practise; User Id=sa; Password=P@ssw0rd;");
            string email = null;
            using (SqlConnection con = new SqlConnection("server=CYG152; database=practise; User Id=sa; Password=P@ssw0rd;"))
            {
                SqlCommand cmd = new SqlCommand("Select EMAIL from tblEmployee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        email += rdr["Email"].ToString() + ",";
                    }
                }
                con.Close();
                return email;
            }
        }

    }
}
