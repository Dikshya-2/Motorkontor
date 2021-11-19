using System;
using System.Collections.Generic;
using Motorkontor.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Motorkontor.Services
{
    public class AddressService
    {
        // Get all addresses
        public List<Address> GetAddresses()
        {
            List<Address> Addresses = new List<Address>();

            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdtext = "SELECT AdressId, StreetAndNo, ZipcodeId, CreateDate FROM Address";
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
                                Address address = new Address();
                                address.AdressId = reader.GetInt32(0);
                                address.StreetAndNo = reader.GetString(1);
                                address.ZipcodeId = reader.GetInt32(2);
                                address.CreateDate = reader.GetDateTime(3);

                                Addresses.Add(address);
                            }
                        }
                    }
                    return Addresses;
                }
                catch (Exception e)
                {
                    return Addresses;
                }
            }
        }
        // Get address by id
        public Address GetAddressById(int addrId)
        {
            Address Customer = new Address();

            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdtext = "SELECT AdressId, StreetAndNo, ZipcodeId, CreateDate FROM Address WHERE AdressId = @Address";
                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = System.Data.CommandType.Text;

                // username is a unique field on the database...
                cmd.Parameters.AddWithValue("@Address", addrId);
                Address address = new Address();
                con.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address.AdressId = reader.GetInt32(0);
                                address.StreetAndNo = reader.GetString(1);
                                address.ZipcodeId = reader.GetInt32(2);
                                address.CreateDate = reader.GetDateTime(3);
                            }
                        }
                        else
                        {
                            address = null;
                        }
                    }
                    return address;
                }
                catch (Exception e)
                {
                    return address;
                }
            }
        }

        // Apdate an address
        public bool UpdateAddress(Address address)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string upd = "Update Address set StreetAndNo = @streetAndNo, ZipcodeId = @zipcodeId WHERE AdressId = @addressId";
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@streetAndNo", address.StreetAndNo);
                cmd.Parameters.AddWithValue("@zipcodeId", address.ZipcodeId);
                cmd.Parameters.AddWithValue("@addressId", address.AdressId);

                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() <= 0)  // Hvis return value er mindre-end eller lig-med 0, FEJL
                    {
                        returnValue = false;
                    }
                    return returnValue;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        // Add an address
        public bool AddAddress(Address address)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string ins = "insert into Address (StreetAndNo, ZipcodeId) VALUES (@streetAndNo, @zipCodeId )";
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@streetAndNo", address.StreetAndNo);
                cmd.Parameters.AddWithValue("@zipCodeId", address.ZipcodeId);


                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() <= 0)  // Hvis return value er mindre-end eller lig-med 0, FEJL
                    {
                        returnValue = false;
                    }
                    return returnValue;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        // Delete Customer
        public bool DeleteAddress(Address address)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string del = "DELETE FROM address where AdressId = @addressId";
                SqlCommand cmd = new SqlCommand(del, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@addressId", address.AdressId);

                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() <= 0)  // Hvis return value er mindre-end eller lig-med 0, FEJL
                    {
                        returnValue = false;
                    }
                    return returnValue;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
