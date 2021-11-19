using System;
using System.Collections.Generic;
using Motorkontor.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using Motorkontor.Pages;


namespace Motorkontor.Services
{
    public class CustomerService
    {
        // Get all Customer
        public List<Customer> GetCustomers()
        {
            List<Customer> Customers = new List<Customer>();

            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdtext = "SELECT CustomerId, CustomerFirstName, CustomerLastName, AdressId, CreateDate FROM Customer";
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
                                Customer Customer = new Customer();
                                Customer.CustomerId = reader.GetInt32(0);
                                Customer.CustomerFirstName = reader.GetString(1);
                                Customer.CustomerLastName = reader.GetString(2);
                                Customer.AddressId = reader.GetInt32(3);
                                Customer.CreateDate = reader.GetDateTime(4);

                                Customers.Add(Customer);
                            }
                        }
                    }
                    return Customers;
                }
                catch (Exception e)
                {
                    return Customers;
                }
            }
        }
        // Get Customer by id
        public Customer GetCustomersId(int CostomId)
        {
            Customer Fuel = new Customer();

            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmdtext = "SELECT CustomerId, CustomerFirstName, CustomerLastName, AdressId, CreateDate FROM Customer WHERE CustomerId = @customer";
                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = System.Data.CommandType.Text;

                // username is a unique field on the database...
                cmd.Parameters.AddWithValue("@customer", CostomId);
                Customer Customer = new Customer();
                con.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Customer.CustomerId = reader.GetInt32(0);
                                Customer.CustomerFirstName = reader.GetString(1);
                                Customer.CustomerLastName = reader.GetString(2);
                                Customer.AddressId = reader.GetInt32(3);
                                Customer.CreateDate = reader.GetDateTime(4);
                            }
                        }
                        else
                        {
                            Customer = null;
                        }
                    }
                    return Customer;
                }
                catch (Exception e)
                {
                    return Customer;
                }
            }
        }

        // Apdate an address
        public bool UpdateCustomers(Customer customers)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string upd = "Update Customer set CustomerFirstName = @customerFirstName, CustomerLastName = @customerLastName, AdressId = @addressId WHERE CustomerId = @customerId";
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@customerFirstName", customers.CustomerFirstName);
                cmd.Parameters.AddWithValue("@customerLastName", customers.CustomerLastName);
                cmd.Parameters.AddWithValue("@customerId", customers.CustomerId);
                cmd.Parameters.AddWithValue("@addressId", customers.AddressId);

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
        public bool AddCustomer(Customer Customer)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string ins = "insert into Customer (CustomerFirstName, CustomerLastName, AdressId) VALUES (@customerFirstName, @customerLastName, @addressId )";
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@customerFirstName", Customer.CustomerFirstName);
                cmd.Parameters.AddWithValue("@customerLastName", Customer.CustomerLastName);
                cmd.Parameters.AddWithValue("@addressId", Customer.AddressId);


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
        public bool DeleteCustomer(Customer Customer)
        {
            bool returnValue = true;
            string CS = @"Data Source=SKAB2-PC-10;Initial Catalog=Motorkontor;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(CS))
            {
                string del = "DELETE FROM Customer where CustomerId = @customerId";
                SqlCommand cmd = new SqlCommand(del, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@customerId", Customer.CustomerId);

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
