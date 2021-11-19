using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Motorkontor.Pages
{
    public partial class Vehicle
    {
        //private int newId = 0;

        //private string mess = "";

        private void SaveVehicle()

        {
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))

            {

                SqlCommand cmd = new SqlCommand("spInsertLogin", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                // variables to serve as dummy input for the SP

                // IMPORTANT!!!!!! you need to change input value for this example

                // because i have username as a unique field.

                // Normally you would receive data from an input field...

                string Username = "Dikshya";

                string Password = "dik";



                cmd.Parameters.AddWithValue("@username", Username);

                cmd.Parameters.AddWithValue("@paswd", Password);



                SqlParameter outputParameter = new SqlParameter();

                outputParameter.ParameterName = "@loginId";

                outputParameter.SqlDbType = System.Data.SqlDbType.Int;

                outputParameter.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(outputParameter);



                con.Open();

            //    try

            //    //{

            //    //    cmd.ExecuteNonQuery();

            //    //    newId = (int)outputParameter.Value;

            //    //    mess = "Login oprettet...";

            //    //}

            //    //catch (Exception e)

            //    //{

            //    //    mess = e.Message;

            //    //    newId = 0;

            //    //}





            }

        }

    }
}


