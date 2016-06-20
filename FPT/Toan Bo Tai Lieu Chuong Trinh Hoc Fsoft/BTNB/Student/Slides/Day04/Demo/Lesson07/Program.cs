﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Lesson07
{
    class StoredProcDemo
    {
        static void Main()
        {
            StoredProcDemo storedProcDemo = new StoredProcDemo();

            // run a simple stored procedure
            storedProcDemo.RunStoredProc();

            // run a stored procedure that takes a parameter
            storedProcDemo.RunStoredProcParams();

            Console.ReadLine();
        }

        /// <summary>
        /// Runs the stored proc.
        /// </summary>
        public void RunStoredProc()
        {
            SqlConnection connection = null;
            SqlDataReader dataReader = null;

            Console.WriteLine("\nTop 10 Most Expensive Products:\n");

            try
            {
                // create and open a connection object
                connection = new
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                connection.Open();

                // 1.  create a command object identifying
                //     the stored procedure
                SqlCommand cmd = new SqlCommand("Ten Most Expensive Products", connection);

                // 2. set the command object so it knows
                //    to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                dataReader = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (dataReader.Read())
                {
                    Console.WriteLine("Product: {0,-25} Price: ${1,6:####.00}",
                        dataReader["TenMostExpensiveProducts"],
                        dataReader["UnitPrice"]);
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
        }

        // run a stored procedure that takes a parameter
        public void RunStoredProcParams()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut
            string custId = "FURIB";

            Console.WriteLine("\nCustomer Order History:\n");

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                conn.Open();

                // 1.  create a command object identifying
                //     the stored procedure
                SqlCommand cmd = new SqlCommand("CustOrderHist", conn);

                // 2. set the command object so it knows
                //    to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                //    will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@CustomerID", custId));

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Console.WriteLine(
                        "Product: {0,-35} Total: {1,2}",
                        rdr["ProductName"],
                        rdr["Total"]);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
    }
}

