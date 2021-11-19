using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Motorkontor.Data;



namespace Motorkontor.Services
{
    public class ZipcodeService
    {
     
           // Get all ZipCodes
            public List<ZipCode> GetZipCodes()
            {
                List<ZipCode> Zipcodes = new List<ZipCode>();

                string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string cmdtext = "SELECT ZipcodeId, ZipcodeName FROM Zipcode ORDER BY ZipcodeName ASC";
                    SqlCommand cmd = new SqlCommand(cmdtext, con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    con.Open();
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ZipCode zipcode = new ZipCode();
                                    zipcode.ZipcodeId = reader.GetInt32(0);
                                    zipcode.ZipcodeName = reader.GetString(1);

                                    Zipcodes.Add(zipcode);
                                }
                            }
                        }
                        return Zipcodes;
                    }
                    catch (Exception e)
                    {
                        return Zipcodes;
                    }
                }
            }
        }
    }
