using Motorkontor.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Motorkontor.Pages
{
    public partial class Login
    {
        LoginClass LoginClass { get; set; } = new LoginClass();
        string mess = "";
       
        private void DoLogin()
        {
            //newId++;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdtext = "SELECT Id FROM login WHERE Username = @username AND Password = @paswd";
                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = System.Data.CommandType.Text;

                // username is a unique field on the database...
                cmd.Parameters.AddWithValue("@username", LoginClass.UserName);
                cmd.Parameters.AddWithValue("@paswd", LoginClass.Password);

                con.Open();
                try
                {
                    int FetchedId = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    { 
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FetchedId = reader.GetInt32(0);
                                
                            }
                        }
                    }
                    if (FetchedId >= 1)
                    { 
                        mess = "Du er nu logget ind...";
                    }
                    else
                    {
                       mess = "Your have enter wrong password or username";
                    }
                }
                catch (Exception e)
                {
                    mess = e.Message;
                }
            }
        }
    }
}
